Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmEnquiryCommonSms
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Dim mQry As String = "", mSearchCode As String = ""

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Tick As String = "Tick"
    Protected Const Col1AssignTo As String = "Employee Name"
    Protected Const Col1Name As String = "Name"
    Protected Const Col1ManualCode As String = "Manual Code"
    Protected Const Col1Mobile As String = "Mobile"
    Protected Const Col1Status As String = "Status"
    Protected Const Col1DocId As String = "DocId"
    Protected Const Col1EnquiryNo As String = "Enquiry No."
    Protected Const Col1ReferenceNo As String = "Reference No."
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

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        Try
            With AgCL
                .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
                .AddAgCheckColumn(DGL1, Col1Tick, 50, Col1Tick, True)
                .AddAgTextColumn(DGL1, Col1Name, 150, 0, Col1Name, True, True, False)
                .AddAgTextColumn(DGL1, Col1EnquiryNo, 120, 0, Col1EnquiryNo, True, True, False)
                .AddAgTextColumn(DGL1, Col1ReferenceNo, 120, 0, Col1ReferenceNo, True, True, False)
                .AddAgTextColumn(DGL1, Col1AssignTo, 250, 0, Col1AssignTo, False, True, False)
                .AddAgTextColumn(DGL1, Col1ManualCode, 100, 0, Col1ManualCode, False, True, False)
                .AddAgNumberColumn(DGL1, Col1Mobile, 100, 10, 0, False, Col1Mobile, True, False, True)
                .AddAgTextColumn(DGL1, Col1Status, 100, 0, Col1Status, True, True, False)
                .AddAgTextColumn(DGL1, Col1EntryBy, 100, 0, Col1EntryBy, False, True, False)
                .AddAgTextColumn(DGL1, Col1EntryDate, 100, 0, Col1EntryDate, False, True, False)
                .AddAgTextColumn(DGL1, Col1EditBy, 100, 0, Col1EditBy, False, True, False)
                .AddAgTextColumn(DGL1, Col1EditDate, 100, 0, Col1EditDate, False, True, False)
                .AddAgTextColumn(DGL1, Col1DocId, 100, 0, Col1DocId, False, True, False)
              
            End With
            AgL.AddAgDataGrid(DGL1, Pnl1)
            DGL1.EnableHeadersVisualStyles = False
            DGL1.AgSkipReadOnlyColumns = True
            DGL1.Anchor = AnchorStyles.None
            PnlFooter.Anchor = DGL1.Anchor
            DGL1.ColumnHeadersHeight = 40
            DGL1.AllowUserToAddRows = False
            Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))

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
            SmsCategory = ClsMain.SmsCategorty.CommonEnquiry

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

            mQry = "Select E.Subcode As Code, Sg.Name, " & _
                    " Right(IsNull(Sg.Mobile,''),10) As Mobile, " & _
                    " Case When IsNull(E.IsTeachingStaff,0) <> 0 Then 'Yes' Else 'No' End As [Teaching Staff], " & _
                    " City.CityName As City, " & _
                    " Sg.ManualCode, " & _
                    " Sg.DispName " & _
                    " From Pay_Employee E With (NoLock) " & _
                    " Left Join SubGroup Sg With (NoLock) On Sg.SubCode = E.SubCode " & _
                    " Left Join City With (NoLock) On City.CityCode = Sg.SubCode " & _
                    " Where 1=1 And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
            DGL1.AgHelpDataSet(Col1Name, 3) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                   " FROM Sch_Session S " & _
                   " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                   " Order By S.ManualCode "
            TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Stream " & _
                    " FROM Sch_Stream S " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            TxtStream.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.ManualCode AS Programme " & _
                    " FROM Sch_Programme P " & _
                    " WHERE " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By P.ManualCode "
            TxtProgramme.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT E.SubCode AS Code, SG.DispName AS Employee, Sg.LogInUser, " & _
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsLeft, " & _
                    " E.DateOfResign As [Resign Date] " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode  " & _
                    " WHERE 1=1 " & _
                    " ORDER BY SG.DispName  "
            TxtAssignedTo.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Distinct R.ReferenceNo AS Code,R.ReferenceNo  FROM Enquiry_Enquiry R " & _
              " WHERE R.ReferenceNo IS NOT NULL "
            TxtReferenceNo.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT H.Code, H.Code AS Name FROM Sch_EnquiryMode H With (NoLock) ORDER BY H.Code"
            TxtEnquiryMode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.Description AS Name FROM Sch_Semester S With (NoLock) ORDER BY S.SerialNo"
            TxtSemester.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtV_Date.Text = AgL.PubLoginDate
        TxtPending.Text = "No"

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
            'mCondStr += " And H.V_Date <= " & AgL.Chk_Text(AgL.PubEndDate) & " "
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
                                " Code, Sr, Category, V_Date, Div_Code, Site_Code, Mobile, DocID, MsgDate, Msg, Status, " & _
                                " PreparedBy, U_EntDt, U_AE, Edit_Date, ModifiedBy) " & _
                                " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & _
                                " " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(SmsCategory) & ", " & _
                                " " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                                " '" & AgL.PubDivCode & "', " & _
                                " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Mobile, bIntI).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1DocId, bIntI).Value) & ", " & _
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

                mQry = "SELECT L.* ," & AgL.V_No_Field("E.DocId") & " As EnquiryNo, E.ReferenceNo, " & _
                        " isnull(E.FirstName,'') +' '+ isnull(E.MiddleName,'') +' '+ isnull(E.LastName,'') AS Name " & _
                        " FROM Sms_Trans L WITH (NoLock) " & _
                        " Left join  Enquiry_Enquiry E  With (NoLock) On L.DocID=E.DocID " & _
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

                            DGL1.Item(Col1Name, bIntI).Value = AgL.XNull(.Rows(bIntI)("Name"))

                            DGL1.Item(Col1EnquiryNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("EnquiryNo"))
                            DGL1.Item(Col1ReferenceNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("ReferenceNo"))
                            DGL1.Item(Col1DocId, bIntI).Value = AgL.XNull(.Rows(bIntI)("DocID"))
                            DGL1.Item(Col1Mobile, bIntI).Value = AgL.XNull(.Rows(bIntI)("Mobile"))
                            DGL1.Item(Col1Status, bIntI).Value = AgL.XNull(.Rows(bIntI)("Status"))
                            DGL1.Item(Col1EntryBy, bIntI).Value = AgL.XNull(.Rows(bIntI)("PreparedBy"))
                            DGL1.Item(Col1EditBy, bIntI).Value = AgL.XNull(.Rows(bIntI)("ModifiedBy"))
                            DGL1.Item(Col1EntryDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("U_EntDt")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1EditDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("Edit_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

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
            TxtSite_Code.Enter, TxtMessage.Enter, TxtV_Date.Enter, TxtMsgDate.Enter, _
              TxtSelectAll.Enter

        Try
            Select Case sender.NAME
                'Case sender.Name
                '<Executable Code>
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtMessage.Validating, TxtV_Date.Validating, TxtMsgDate.Validating, _
          TxtSelectAll.Validating

        Try
            Select Case sender.NAME
                Case TxtV_Date.Name
                    '<Executable Code>
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
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
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

    Private Sub Calculation()
        Dim bIntI% = 0
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        LblValTotalSMS.Text = 0

        With DGL1
            For bIntI = 0 To .Rows.Count - 1
                If .Item(Col1Name, bIntI).Value Is Nothing Then .Item(Col1Name, bIntI).Value = ""
                If .Item(Col1AssignTo, bIntI).Value Is Nothing Then .Item(Col1AssignTo, bIntI).Value = ""
                If .Item(Col1Mobile, bIntI).Value Is Nothing Then .Item(Col1Mobile, bIntI).Value = ""
                If .Item(Col1Status, bIntI).Value Is Nothing Then .Item(Col1Status, bIntI).Value = ClsMain.SmsStatus.Pending
                If .Item(Col1Status, bIntI).Value.ToString.Trim = "" Then .Item(Col1Status, bIntI).Value = ClsMain.SmsStatus.Pending

                If AgL.XNull(.Item(Col1Mobile, bIntI).Value).ToString.Trim.Length <> 10 Then
                    .Item(Col1Mobile, bIntI).Value = ""
                End If

                If .Item(Col1Tick, bIntI).Value Is Nothing Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If AgL.XNull(.Item(Col1Tick, bIntI).Value).ToString.Trim = "" Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If AgL.XNull(.Item(Col1Mobile, bIntI).Value).ToString.Trim = "" Then
                    .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End If

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
                    '<Executable code>
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
        Dim DtTemp As DataTable
        Dim bIntI% = 0
        Dim bCondStr$ = " WHERE 1=1 "
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            bCondStr += " And " & AgL.PubSiteCondition("Sg.Site_Code", TxtSite_Code.AgSelectedValue) & " "

            If AgL.StrCmp(TxtPending.Text, "Yes") Then
                bCondStr += " And IsNull(H.IsClosed,0) <> 0  "
            Else
                bCondStr += " And IsNull(H.IsClosed,0) = 0  "
            End If

            If TxtEnquiryMode.Text.Trim <> "" Then
                bCondStr += " And H.EnquiryMode = " & AgL.Chk_Text(TxtEnquiryMode.AgSelectedValue) & " "
            End If

            If TxtReferenceNo.Text.Trim <> "" Then
                bCondStr += " And H.ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.AgSelectedValue) & " "
            End If

            If TxtAssignedTo.Text.Trim <> "" Then
                bCondStr += " And H.AssignedTo = " & AgL.Chk_Text(TxtAssignedTo.AgSelectedValue) & " "
            End If

            If TxtSemester.Text.Trim <> "" Then
                bCondStr += " And H.Semester = " & AgL.Chk_Text(TxtSemester.AgSelectedValue) & " "
            End If

            'If TxtSession.Text.Trim <> "" Then
            '    bCondStr += " And H.Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " "
            'End If

            'If TxtProgramme.Text.Trim <> "" Then
            '    bCondStr += " And H.Programme = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & " "
            'End If

            mQry = "Select H.AssignedTo, isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                    " Right(IsNull(H.Mobile,''),10) As Mobile," & AgL.V_No_Field("H.DocId") & " As EnquiryNo,H.ReferenceNo,H.DocID, " & _
                    " City.CityName As City, " & _
                    " Sg.ManualCode, " & _
                    " Sg.DispName As AssignTo" & _
                    " FROM Enquiry_Enquiry H  With (NoLock) " & _
                    " Left Join SubGroup Sg With (NoLock) On Sg.SubCode = H.AssignedTo " & _
                    " Left Join City With (NoLock) On City.CityCode = H.CityCode " & _
                    " " & bCondStr & ""

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For bIntI = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count

                        If AgL.StrCmp(TxtSelectAll.Text, "Yes") Then
                            DGL1(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Else
                            DGL1(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        End If
                        DGL1.Item(Col1DocId, bIntI).Value = AgL.XNull(.Rows(bIntI)("DocID"))
                        DGL1.Item(Col1Name, bIntI).Value = AgL.XNull(.Rows(bIntI)("Name"))
                        DGL1.Item(Col1AssignTo, bIntI).Value = AgL.XNull(.Rows(bIntI)("AssignTo"))
                        DGL1.Item(Col1ManualCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("ManualCode"))
                        DGL1.Item(Col1Mobile, bIntI).Value = AgL.XNull(.Rows(bIntI)("Mobile"))
                        DGL1.Item(Col1EnquiryNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("EnquiryNo"))
                        DGL1.Item(Col1ReferenceNo, bIntI).Value = AgL.XNull(.Rows(bIntI)("ReferenceNo"))
                    Next bIntI
                Else
                    MsgBox("No Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub
End Class
