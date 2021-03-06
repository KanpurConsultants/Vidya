﻿Imports CrystalDecisions.CrystalReports.Engine

Public Class TempCommonSmsStudent
    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseFunction_FillData()
    Public Event BaseFunction_IniGrid()

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Dim mQry As String = "", mSearchCode As String = ""

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Tick As String = "Tick"
    Protected Const Col1DispName As String = "Employee Name"
    Protected Const Col1Name As String = "Name"
    Protected Const Col1ManualCode As String = "Manual Code"
    Protected Const Col1Mobile As String = "Mobile"
    Protected Const Col1Status As String = "Status"
    Protected Const Col1StreamYearSemester As String = "Semester"
    Protected Const Col1SubCode As String = "Subcode"
    Protected Const Col1EntryBy As String = "Entry By"
    Protected Const Col1EntryDate As String = "Entry Date"
    Protected Const Col1EditBy As String = "Edit By"
    Protected Const Col1EditDate As String = "Edit Date"

    Dim _StrSmsCategory As String = ""

    Public Property SmsCategory() As String
        Get
            SmsCategory = _StrSmsCategory
        End Get
        Set(ByVal value As String)
            _StrSmsCategory = value
        End Set
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    'Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    '    AgL.FPaintForm(Me, e, Topctrl1.Height)
    'End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        Try
            With AgCL
                .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
                .AddAgCheckColumn(DGL1, Col1Tick, 50, Col1Tick, True)
                .AddAgTextColumn(DGL1, Col1Name, 250, 0, Col1Name, True, True, False)
                .AddAgTextColumn(DGL1, Col1DispName, 300, 0, Col1DispName, False, True, False)
                .AddAgTextColumn(DGL1, Col1ManualCode, 100, 0, Col1ManualCode, False, True, False)
                .AddAgNumberColumn(DGL1, Col1Mobile, 100, 10, 0, False, Col1Mobile, True, False, True)
                .AddAgTextColumn(DGL1, Col1StreamYearSemester, 240, 0, Col1StreamYearSemester, True, True, False)
                .AddAgTextColumn(DGL1, Col1Status, 80, 0, Col1Status, True, True, False)
                .AddAgTextColumn(DGL1, Col1EntryBy, 100, 0, Col1EntryBy, False, True, False)
                .AddAgTextColumn(DGL1, Col1EntryDate, 100, 0, Col1EntryDate, False, True, False)
                .AddAgTextColumn(DGL1, Col1EditBy, 100, 0, Col1EditBy, False, True, False)
                .AddAgTextColumn(DGL1, Col1EditDate, 100, 0, Col1EditDate, False, True, False)
                .AddAgTextColumn(DGL1, Col1SubCode, 100, 0, Col1SubCode, False, True, False)
            End With
            AgL.AddAgDataGrid(DGL1, Pnl1)
            DGL1.EnableHeadersVisualStyles = False
            DGL1.AgSkipReadOnlyColumns = True
            DGL1.Anchor = AnchorStyles.None
            PnlFooter.Anchor = DGL1.Anchor
            DGL1.ColumnHeadersHeight = 40
            DGL1.AllowUserToAddRows = False

            RaiseEvent BaseFunction_IniGrid()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 650, 1000, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=2 "
        mCondStr += " And H.Category = '" & SmsCategory & "' "
        mCondStr += " And H.V_Date <= " & AgL.Chk_Text(AgL.PubEndDate) & " "
        mCondStr += " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT DISTINCT H.Code AS SearchCode " & _
                " FROM Sms_Trans H WITH (NoLock) " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code, ManualCode, Name, Active From SiteMast  With (NoLock)  Order By ManualCode"
            TxtSite_Code.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select A.DocId As Code, Sg.Name, " & _
                    " Right(IsNull(Sg.Mobile,''),10) As Mobile, " & _
                    " City.CityName As City, " & _
                    " Sg.ManualCode, " & _
                    " Sg.DispName, " & _
                    " A.Student As StudentCode, " & _
                    " A.CurrentSemester " & _
                    " FROM Sch_Admission A WITH (NoLock) " & _
                    " LEFT JOIN Sch_Student S WITH (NoLock) ON A.Student = S.SubCode  " & _
                    " Left Join SubGroup Sg With (NoLock) On Sg.SubCode = A.Student " & _
                    " Left Join City With (NoLock) On City.CityCode = Sg.SubCode " & _
                    " Where 1=1 And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
            DGL1.AgHelpDataSet(Col1Name, 5) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS [Short Name], S.Description AS [Name] FROM Sch_Session S WITH (NoLock) Order By S.ManualCode "
            TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS [Short Name], S.Description AS [Name] FROM Sch_Programme S WITH (NoLock) ORDER BY S.ManualCode"
            TxtProgramme.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS [Short Name], S.Description AS [Name] FROM Sch_Stream S WITH (NoLock) Order By S.ManualCode "
            TxtStream.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.Description AS Name FROM Sch_Semester S With (NoLock) ORDER BY S.SerialNo"
            TxtSemester.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.Description AS ClassSection, S.Semester, S.Section,C.SerialNo,C.Description as Class  " & _
                    " FROM Sch_StreamYearSemester S WITH (NoLock) " & _
                    " LEFT JOIN Sch_Semester C WITH (NoLock) ON C.Code = S.Semester " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By C.SerialNo "
            TxtStreamYearSemester.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GcnRead)
            DGL1.AgHelpDataSet(Col1StreamYearSemester, 4) = TxtStreamYearSemester.AgHelpDataSet.Copy


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtV_Date.Text = AgL.PubLoginDate

        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position


            If mSearchCode.Trim <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    mQry = "Delete From Sms_Trans Where Code = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False


                    FIniMaster(1)
                    Topctrl1_tbRef()
                    AgL.PubSearchRow = ""
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)

        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtMsgDate.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            Dim mCondStr$ = ""

            mCondStr = " Where 1=1 "
            mCondStr += " And H.Category = '" & SmsCategory & "' "
            mCondStr += " And H.V_Date <= " & AgL.Chk_Text(AgL.PubEndDate) & " "
            mCondStr += " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT H.Code AS SearchCode, " & _
                                " " & AgL.ConvertDateField("H.V_Date") & " As [" & LblV_Date.Text & "], " & _
                                " " & AgL.ConvertDateField("H.MsgDate") & " As [" & LblMsgDate.Text & "], " & _
                                " H.Msg As [" & LblMessage.Text & "], " & _
                                " Max(S.Name) As [" & LblSite_Code.Text & "], H.Div_Code " & _
                                " FROM Sms_Trans H WITH (NoLock) " & _
                                " Left Join SiteMast S On S.Code = H.Site_Code " & _
                                " " & mCondStr & " " & _
                                " GROUP BY H.Code, H.Category, H.V_Date, H.Div_Code, H.Site_Code, H.MsgDate, H.Msg "

            AgL.PubFindQryOrdBy = "Convert(SmallDateTime, [" & LblV_Date.Text & "]) Desc "

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                'AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                'BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        '<executable codevi>
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bIntI% = 0, bIntSr% = 0
        Dim bStrEntryBy$ = "", bStrEntryDate$ = "", bStrEditBy$ = "", bStrEditDate$ = "", bStrU_AE$ = ""
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                bStrU_AE = "A"
                bStrEntryBy = AgL.PubUserName
                bStrEntryDate = AgL.PubLoginDate
            Else
                bStrU_AE = "E"
                bStrEditBy = AgL.PubUserName
                bStrEditDate = AgL.PubLoginDate

                mQry = "Delete From Sms_Trans Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                bIntSr = 0
                For bIntI = 0 To .Rows.Count - 1
                    If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                        bStrEntryBy = DGL1.Item(Col1EntryBy, bIntI).Value
                        bStrEntryDate = DGL1.Item(Col1EntryDate, bIntI).Value
                    End If

                    If .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue _
                        And .Item(Col1Name, bIntI).Value.ToString.Trim <> "" _
                        And .Item(Col1Mobile, bIntI).Value.ToString.Trim <> "" Then

                        bIntSr += 1

                        mQry = "INSERT INTO dbo.Sms_Trans (" & _
                                " Code, Sr, Category, V_Date, Div_Code, Site_Code, Mobile, SubCode, MsgDate, Msg, Status, " & _
                                " PreparedBy, U_EntDt, U_AE, Edit_Date, ModifiedBy) " & _
                                " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & _
                                " " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(SmsCategory) & ", " & _
                                " " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                                " '" & AgL.PubDivCode & "', " & _
                                " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Mobile, bIntI).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1SubCode, bIntI).Value) & ", " & _
                                " " & AgL.Chk_Text(TxtMsgDate.Text) & ", " & _
                                " " & AgL.Chk_Text(TxtMessage.Text) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Status, bIntI).Value) & ", " & _
                                " " & AgL.Chk_Text(bStrEntryBy) & ", " & _
                                " " & AgL.Chk_Text(bStrEntryDate) & ", " & _
                                " " & AgL.Chk_Text(bStrU_AE) & ", " & _
                                " " & AgL.Chk_Text(bStrEditDate) & ", " & _
                                " " & AgL.Chk_Text(bStrEditBy) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                        RaiseEvent BaseEvent_Save_InTransLine(mSearchCode, bIntSr, bIntI, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With



            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            Call AgL.SendSms(AgL)

            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim MastPos As Long = 0
        Dim bIntI% = 0
        Try
            FClear()
            BlankText()

            If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            If mSearchCode <> "" Then
                mQry = "SELECT H.Code, H.Category, H.V_Date, H.Div_Code, H.Site_Code, H.MsgDate, H.Msg " & _
                        " FROM Sms_Trans H WITH (NoLock) " & _
                        " WHERE H.Code = '" & mSearchCode & "' " & _
                        " GROUP BY H.Code, H.Category, H.V_Date, H.Div_Code, H.Site_Code, H.MsgDate, H.Msg "
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtMsgDate.Text = Format(AgL.XNull(.Rows(0)("MsgDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtMessage.Text = AgL.XNull(.Rows(0)("Msg"))
                    End If
                End With

                mQry = "SELECT L.* " & _
                        " FROM Sms_Trans L WITH (NoLock) " & _
                        " WHERE L.Code = '" & mSearchCode & "' " & _
                        " Order by L.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()

                    If .Rows.Count > 0 Then
                        LblValTotalSMS.Text = .Rows.Count

                        For bIntI = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count
                            DGL1(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue

                            DGL1.Item(Col1SubCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("SubCode"))

                            DrTemp = DGL1.AgHelpDataSet(Col1Name).Tables(0).Select("StudentCode = " & AgL.Chk_Text(AgL.XNull(.Rows(bIntI)("SubCode"))) & " ")
                            If DrTemp.Length > 0 Then
                                DGL1.Item(Col1Name, bIntI).Value = AgL.XNull(DrTemp(0)("Name"))
                                DGL1.Item(Col1Name, bIntI).Tag = AgL.XNull(DrTemp(0)("Code"))
                                DGL1.Item(Col1ManualCode, bIntI).Value = AgL.XNull(DrTemp(0)("ManualCode"))
                                DGL1.Item(Col1DispName, bIntI).Value = AgL.XNull(DrTemp(0)("DispName"))
                                DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI) = AgL.XNull(DrTemp(0)("CurrentSemester"))
                            End If
                            DrTemp = Nothing

                            DGL1.Item(Col1Mobile, bIntI).Value = AgL.XNull(.Rows(bIntI)("Mobile"))
                            DGL1.Item(Col1Status, bIntI).Value = AgL.XNull(.Rows(bIntI)("Status"))
                            DGL1.Item(Col1EntryBy, bIntI).Value = AgL.XNull(.Rows(bIntI)("PreparedBy"))
                            DGL1.Item(Col1EditBy, bIntI).Value = AgL.XNull(.Rows(bIntI)("ModifiedBy"))
                            DGL1.Item(Col1EntryDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("U_EntDt")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1EditDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("Edit_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)


                            RaiseEvent BaseFunction_MoveRecLine(mSearchCode, AgL.VNull(.Rows(bIntI)("Sr")), bIntI)
                        Next bIntI
                    End If
                End With
            Else
                BlankText()
            End If

            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode <> "" Then
                Topctrl1.tEdit = True
                Topctrl1.tDel = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            Topctrl1.tPrn = False
            Topctrl1.tFind = True : AgL.PubSearchRow = ""
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""

        TxtSelectAll.Text = "Yes"

        LblValTotalSMS.Text = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Date.Enabled = False
        End If
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            TxtSite_Code.Enter, TxtMessage.Enter, TxtV_Date.Enter, TxtMsgDate.Enter, TxtSession.Enter, _
            TxtProgramme.Enter, TxtStream.Enter, TxtSelectAll.Enter, TxtStreamYearSemester.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.NAME
                Case TxtStreamYearSemester.Name
                    bStrFilter = " 1=1 "

                    'If TxtSession.Text.Trim <> "" Then
                    '    bStrFilter += " And SessionCode = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " "
                    'End If

                    'If TxtProgramme.Text.Trim <> "" Then
                    '    bStrFilter += " And ProgrammeCode = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & " "
                    'End If

                    'If TxtStream.Text.Trim <> "" Then
                    '    bStrFilter += " And StreamCode = " & AgL.Chk_Text(TxtStream.AgSelectedValue) & " "
                    'End If

                    If TxtSemester.Text.Trim <> "" Then
                        bStrFilter += " And Semester = " & AgL.Chk_Text(TxtSemester.AgSelectedValue) & " "
                    End If

                    TxtStreamYearSemester.AgRowFilter = bStrFilter

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtMessage.Validating, TxtV_Date.Validating, TxtMsgDate.Validating, TxtSession.Validating, _
        TxtProgramme.Validating, TxtStream.Validating, TxtSelectAll.Validating, TxtStreamYearSemester.Validating

        Try
            Select Case sender.NAME
                Case TxtStreamYearSemester.Name
                    Call Validating_Controls(sender)
            End Select

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            Dim bIntI% = 0

            Call Calculation()

            If AgL.RequiredField(TxtSite_Code, LblSite_Code.Text) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If AgL.RequiredField(TxtMsgDate, LblMsgDate.Text) Then Exit Function
            If AgL.RequiredField(TxtMessage, LblMessage.Text) Then Exit Function

            If CDate(TxtMsgDate.Text) < CDate(TxtV_Date.Text) Then
                MsgBox("" & LblMsgDate.Text & " < " & LblV_Date.Text & "!...")
                TxtMsgDate.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            With DGL1
                For bIntI = 0 To .Rows.Count - 1
                    If .Item(Col1Tick, bIntI).Value Is Nothing Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    If AgL.XNull(.Item(Col1Tick, bIntI).Value).ToString.Trim = "" Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                    If .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue _
                        And .Item(Col1Name, bIntI).Value.ToString.Trim <> "" Then

                        If .Item(Col1Mobile, bIntI).Value.ToString.Trim = "" Then
                            MsgBox("Mobile No Is Required At Row No. : " & .Item(ColSNo, bIntI).Value & "!...")
                            DGL1.CurrentCell = DGL1(Col1Tick, bIntI) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next
            End With

            If Val(LblValTotalSMS.Text) = 0 Then
                MsgBox("Total SMS is Zero!...", MsgBoxStyle.Information, "Validation Check")
                If DGL1.Rows.Count > 0 Then
                    DGL1.CurrentCell = DGL1(Col1Tick, 0)
                    DGL1.Focus()
                Else
                    BtnFill.Focus()
                End If
                Exit Function
            End If



            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sms_Trans", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 6, True, True, , AgL.Gcn_ConnectionString)
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Public Sub Calculation()
        Dim bIntI% = 0
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        LblValTotalSMS.Text = 0

        With DGL1
            For bIntI = 0 To .Rows.Count - 1
                If .Item(Col1Name, bIntI).Value Is Nothing Then .Item(Col1Name, bIntI).Value = ""
                If .Item(Col1DispName, bIntI).Value Is Nothing Then .Item(Col1DispName, bIntI).Value = ""
                If .Item(Col1Mobile, bIntI).Value Is Nothing Then .Item(Col1Mobile, bIntI).Value = ""
                If .Item(Col1Status, bIntI).Value Is Nothing Then .Item(Col1Status, bIntI).Value = ClsMain.SmsStatus.Pending
                If .Item(Col1Status, bIntI).Value.ToString.Trim = "" Then .Item(Col1Status, bIntI).Value = ClsMain.SmsStatus.Pending

                If AgL.XNull(.Item(Col1Mobile, bIntI).Value).ToString.Trim.Length <> 10 Then
                    .Item(Col1Mobile, bIntI).Value = ""
                End If

                If .Item(Col1Tick, bIntI).Value Is Nothing Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If AgL.XNull(.Item(Col1Tick, bIntI).Value).ToString.Trim = "" Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue _
                    And .Item(Col1Name, bIntI).Value.ToString.Trim <> "" _
                    And .Item(Col1Mobile, bIntI).Value.ToString.Trim <> "" Then

                    LblValTotalSMS.Text = Val(LblValTotalSMS.Text) + 1
                End If
            Next
        End With

    End Sub

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Name
                    DGL1.AgRowFilter(mColumnIndex) = " [Is Active] = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Name
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.Item(Col1SubCode, mRowIndex).Value = ""
                            DGL1.Item(Col1Mobile, mRowIndex).Value = ""
                            DGL1.Item(Col1ManualCode, mRowIndex).Value = ""
                            DGL1.Item(Col1DispName, mRowIndex).Value = ""
                            DGL1.AgSelectedValue(Col1StreamYearSemester, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")

                                DGL1.Item(Col1SubCode, mRowIndex).Value = AgL.XNull(DrTemp(0)("Code"))
                                DGL1.Item(Col1Mobile, mRowIndex).Value = AgL.XNull(DrTemp(0)("Mobile"))
                                DGL1.Item(Col1ManualCode, mRowIndex).Value = AgL.XNull(DrTemp(0)("ManualCode"))
                                DGL1.Item(Col1DispName, mRowIndex).Value = AgL.XNull(DrTemp(0)("DispName"))
                                DGL1.AgSelectedValue(Col1StreamYearSemester, mRowIndex) = AgL.XNull(DrTemp(0)("CurrentSemester"))
                            End If
                            DrTemp = Nothing
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            If DGL1.CurrentCell Is Nothing Then Exit Sub

            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Tick
                        Call Calculation()
                End Select
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If DGL1.CurrentCell Is Nothing Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, DGL1.Columns(Col1Tick).Index)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, DGL1.Columns(Col1Tick).Index)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGL1.CellFormatting
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = e.RowIndex
            mColumnIndex = e.ColumnIndex

            If DGL1.Item(Col1Tick, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Tick, mRowIndex).Value = ""
            If DGL1.Item(Col1Tick, mRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1Tick, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            DGL1.Item(Col1Tick, mRowIndex).Style.BackColor = Color.White
            If DGL1.Item(Col1Tick, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.Item(Col1Tick, mRowIndex).Style.ForeColor = Color.Blue
            Else
                DGL1.Item(Col1Tick, mRowIndex).Style.ForeColor = Color.Red
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        Try
            sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Try
            Select Case sender.name
                Case BtnFill.Name
                    Call ProcFillData()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillData()
        RaiseEvent BaseFunction_FillData()
    End Sub

    Public Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing
        Select Case Sender.Name
            Case TxtStreamYearSemester.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")

                        'If Not AgL.StrCmp(TxtSession.AgSelectedValue, AgL.XNull(DrTemp(0)("SessionCode"))) Then
                        '    TxtSession.AgSelectedValue = AgL.XNull(DrTemp(0)("SessionCode"))
                        'End If

                        'If Not AgL.StrCmp(TxtProgramme.AgSelectedValue, AgL.XNull(DrTemp(0)("ProgrammeCode"))) Then
                        '    TxtProgramme.AgSelectedValue = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                        'End If

                        'If Not AgL.StrCmp(TxtStream.AgSelectedValue, AgL.XNull(DrTemp(0)("StreamCode"))) Then
                        '    TxtStream.AgSelectedValue = AgL.XNull(DrTemp(0)("StreamCode"))
                        'End If

                        If Not AgL.StrCmp(TxtSemester.AgSelectedValue, AgL.XNull(DrTemp(0)("Semester"))) Then
                            TxtSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("Semester"))
                        End If
                    End If
                    DrTemp = Nothing
                End If

        End Select
    End Sub

End Class
