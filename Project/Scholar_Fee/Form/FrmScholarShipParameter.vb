Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmScholarShipParameter

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1GUID As Byte = 1
    Private Const Col1Category As Byte = 2
    Private Const Col1Semester As Byte = 3
    Private Const Col1Programme As Byte = 4
    Private Const Col1ProgrammeYear As Byte = 5
    Private Const Col1FamilyIncome As Byte = 6
    Private Const Col1ScholarShip As Byte = 7
    Public Const Col1BtnFeeHead As Byte = 8
    Public Const Col1FeeList As Byte = 9
    Public Const Col1FeeCodeLIst As Byte = 10
    Public Const Col1ScholarshipList As Byte = 11
    Public Const Col1ProgrammeDuration As Byte = 12
    Private Const Col1FeeHeadWiseTotalScholarShip As Byte = 13

    Dim mStrMasterType As String = Academic_ProjLib.ClsMain.MasterType_ScholarshipParameter
    Dim mStrModuleType As String = ClsMain.ModuleName


    Dim mQry As String = "", mSearchCode As String = ""

    Public Property MasterType() As String
        Get
            MasterType = mStrMasterType
        End Get
        Set(ByVal value As String)
            mStrMasterType = value
        End Set
    End Property

    Public Property ModuleType() As String
        Get
            ModuleType = mStrModuleType
        End Get
        Set(ByVal value As String)
            mStrModuleType = value
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

        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1GUID", 250, 8, "GUID", False, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Category", 125, 50, "Category", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Semester", 135, 50, "Class", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Programme", 135, 50, "Programme", False, False, False)
            .AddAgNumberColumn(DGL1, "DGL1ProgrammeYear", 80, 2, 0, False, "Programme Year", False, False, True)
            .AddAgNumberColumn(DGL1, "DGL1FamilyIncome", 110, 8, 2, False, "Family Income <= ", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1ScholarShip", 100, 8, 2, False, "Scholarship", True, False, True)
            .AddAgButtonColumn(DGL1, "DGL1FillFeeHead", 55, "Fill Fee Heads", True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL1, "Dgl1FeeStr", 240, 50, "Fee", False, False, False)
            .AddAgTextColumn(DGL1, "Dgl1FeeCodeStr", 80, 50, "FeeCode", False, False, False)
            .AddAgTextColumn(DGL1, "Dgl1ScholarshipStr", 240, 50, "Scholarships", False, False, False)
            .AddAgNumberColumn(DGL1, "DGL1ProgrammeDuration", 80, 2, 0, False, "Programme Duration", False, True, True)
            .AddAgNumberColumn(DGL1, "DGL1FeeHeadWiseScholarShip", 100, 8, 2, False, "Fee Head Wise Scholarship", False, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AgSkipReadOnlyColumns = True
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
            AgL.WinSetting(Me, 550, 880, 0, 0)
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
        Dim bCondStr$ = " Where 1=1 "

        bCondStr += " And Sp.ModuleType = " & AgL.Chk_Text(mStrModuleType) & " "
        bCondStr += " AND Sp.MasterType = " & AgL.Chk_Text(mStrMasterType) & " "

        mQry = "SELECT SP.Code AS SearchCode " & _
                " FROM Sch_ScholarShipParameter SP " & bCondStr

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        Try
            mQry = " Select Code As Code, Name As Name From SiteMast " & _
                   "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT C.Code,C.ManualCode AS Category,C.Description   FROM Sch_Category C "
            DGL1.AgHelpDataSet(Col1Category, 0) = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT P.Code, P.ManualCode AS Programme, P.ProgrammeDuration " & _
                    " FROM Sch_Programme P " & _
                    " WHERE " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY P.ManualCode "
            DGL1.AgHelpDataSet(Col1Programme, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.Description AS Name " & _
                   " FROM Sch_Semester P " & _
                   " ORDER BY P.SerialNo "
            DGL1.AgHelpDataSet(Col1Semester) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtApplicableFrom.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            MastPos = BMBMaster.Position

            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    AgL.Dman_ExecuteNonQry(" DELETE FROM Sch_ScholarShipParameter2 WHERE Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry(" DELETE FROM Sch_ScholarShipParameter1 WHERE Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry(" DELETE FROM Sch_ScholarShipParameter WHERE Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    FIniMaster(1)
                    Topctrl1_tbRef()
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
        TxtApplicableFrom.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim bCondStr$ = " Where 1=1 "

        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            bCondStr += " And Sp.ModuleType = " & AgL.Chk_Text(mStrModuleType) & " "
            bCondStr += " AND Sp.MasterType = " & AgL.Chk_Text(mStrMasterType) & " "

            AgL.PubFindQry = " SELECT Sp.Code,SM.Name AS [Site/branch], " & AgL.ConvertDateField("Sp.ApplicableFrom") & " AS [Applicable From] " & _
                                " FROM Sch_ScholarShipParameter Sp  " & _
                                " LEFT JOIN SiteMast SM ON SM.Code=Sp.Site_Code " & bCondStr
            AgL.PubFindQryOrdBy = "[Applicable From]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
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
        ' Call PrintDocument(mSearchCode)
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bFeeReceive1Code$ = ""
        Dim bGUID$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            Dim GcnRead As SqlClient.SqlConnection
            GcnRead = New SqlClient.SqlConnection
            GcnRead.ConnectionString = AgL.Gcn_ConnectionString
            GcnRead.Open()

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = " INSERT INTO Sch_ScholarShipParameter( " & _
                        " Code, ModuleType, MasterType, ApplicableFrom, ApplicableUpto, " & _
                        " Div_Code,	Site_Code, PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES (" & _
                        " " & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(mStrModuleType) & ", " & _
                        " " & AgL.Chk_Text(mStrMasterType) & "," & AgL.ConvertDate(TxtApplicableFrom.Text) & "," & AgL.ConvertDate(TxtApplicableUpto.Text) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubDivCode) & "," & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & "," & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = " UPDATE Sch_ScholarShipParameter " & _
                        " SET	ApplicableFrom = " & AgL.ConvertDate(TxtApplicableFrom.Text) & ", " & _
                        " ApplicableUpto = " & AgL.ConvertDate(TxtApplicableUpto.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & " " & _
                        " WHERE  Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            bSr = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1GUID, I).Value = "" Then
                        If DGL1.Item(Col1Category, I).Value.ToString.Trim <> "" And _
                            DGL1.Item(Col1Semester, I).Value.ToString.Trim <> "" Then


                            bSr += 1
                            bGUID = AgL.GetGUID(AgL.GcnRead).ToString
                            mQry = "INSERT INTO Sch_ScholarShipParameter1(GUID, Code, Sr, Category,	" & _
                                    " FamilyIncome, ScholarShip, Programme,Semester, ProgrammeYear ) " & _
                                    " VALUES " & _
                                    " (" & AgL.Chk_Text(bGUID) & ", " & _
                                    " " & AgL.Chk_Text(mSearchCode) & "," & bSr & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1Category, I)) & ", " & _
                                    " " & Val(.Item(Col1FamilyIncome, I).Value) & ", " & _
                                    " " & Val(.Item(Col1ScholarShip, I).Value) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1Programme, I)) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1Semester, I)) & ", " & _
                                    " " & Val(.Item(Col1ProgrammeYear, I).Value) & ")"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            ProcSaveParameter2(bGUID, mSearchCode, .Item(Col1FeeCodeLIst, I).Value, .Item(Col1ScholarshipList, I).Value, I)
                        End If
                    Else
                        If DGL1.Item(Col1Category, I).Value.ToString.Trim <> "" And _
                            DGL1.Item(Col1Semester, I).Value.ToString.Trim <> "" Then

                            bSr += 1
                            mQry = "UPDATE Sch_ScholarShipParameter1 " & _
                                    " SET " & _
                                    " Category = " & AgL.Chk_Text(.AgSelectedValue(Col1Category, I)) & ", " & _
                                    " FamilyIncome = " & Val(.Item(Col1FamilyIncome, I).Value) & ", " & _
                                    " ScholarShip = " & Val(.Item(Col1ScholarShip, I).Value) & " " & _
                                    " WHERE GUID = " & AgL.Chk_Text(.Item(Col1GUID, I).Value) & " "

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            ProcSaveParameter2(.Item(Col1GUID, I).Value, mSearchCode, .Item(Col1FeeCodeLIst, I).Value, .Item(Col1ScholarshipList, I).Value, I)
                        Else
                            mQry = "Delete From Sch_ScholarShipParameter1 Where GUID = '" & .Item(Col1GUID, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If
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
        Dim DsTemp1 As DataSet = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim mTransFlag As Boolean = False
        Dim MastPos As Long
        Dim I As Integer, bIntJ As Integer
        Dim bDblTotalScholarshipAmt As Double = 0
        Dim bScholarshipStr() As String = Nothing
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")

                mQry = " SELECT * FROM Sch_ScholarShipParameter  WHERE Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtApplicableFrom.Text = AgL.RetDate(AgL.XNull(.Rows(0)("ApplicableFrom")))
                        TxtApplicableUpto.Text = AgL.RetDate(AgL.XNull(.Rows(0)("ApplicableUpto")))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = " SELECT P1.*  " & _
                        " FROM Sch_ScholarShipParameter1 P1 " & _
                        " WHERE P1.Code='" & mSearchCode & "' " & _
                        " Order By P1.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1GUID, I).Value = AgL.XNull(.Rows(I)("GUID"))
                            DGL1.AgSelectedValue(Col1Category, I) = AgL.XNull(.Rows(I)("Category"))
                            DGL1.AgSelectedValue(Col1Programme, I) = AgL.XNull(.Rows(I)("Programme"))
                            DGL1.AgSelectedValue(Col1Semester, I) = AgL.XNull(.Rows(I)("Semester"))
                            DGL1.Item(Col1ProgrammeYear, I).Value = AgL.VNull(.Rows(I)("ProgrammeYear"))

                            DrTemp = DGL1.AgHelpDataSet(Col1Programme).Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(.Rows(I)("Programme"))) & "")
                            If DrTemp.Length > 0 Then
                                DGL1.Item(Col1ProgrammeDuration, I).Value = AgL.VNull(DrTemp(0)("ProgrammeDuration"))
                            End If
                            DrTemp = Nothing

                            DGL1.Item(Col1FamilyIncome, I).Value = Format(AgL.VNull(.Rows(I)("FamilyIncome")), "0.00")
                            DGL1.Item(Col1ScholarShip, I).Value = Format(AgL.VNull(.Rows(I)("ScholarShip")), "0.00")

                            mQry = "DECLARE @bColumnStr1 NVARCHAR(MAX) " & _
                                    " DECLARE @bColumnStr2 NVARCHAR(MAX)    " & _
                                    " DECLARE @bColumnStr3 NVARCHAR(MAX)   " & _
                                    " SET @bColumnStr1 = ''     " & _
                                    " SET @bColumnStr2 = ''     " & _
                                    " SET @bColumnStr3 = ''     " & _
                                    " SELECT @bColumnStr1 = @bColumnStr1 +      " & _
                                    " CASE WHEN  V1.FeeCode IS NULL THEN  '' ELSE ',' + V1.FeeCode  END,   " & _
                                    " @bColumnStr2 = @bColumnStr2 + " & _
                                    " CASE WHEN  V1.FeeName IS NULL THEN  '' ELSE ',' + V1.FeeName  END ,   " & _
                                    " @bColumnStr3 = @bColumnStr3 +    " & _
                                    " CASE WHEN  V1.ScholarShip IS NULL THEN  '' ELSE ',' + V1.ScholarShip  END    " & _
                                    " FROM " & _
                                    " (SELECT P2.Fee AS FeeCode, Sg.Name AS FeeName , convert(nvarchar,P2.ScholarShip) as ScholarShip   " & _
                                    " FROM Sch_ScholarShipParameter2 P2  " & _
                                    " LEFT JOIN sch_fee F ON P2.Fee = F.Code " & _
                                    " LEFT JOIN SubGroup Sg ON F.Code = Sg.SubCode" & _
                                    " WHERE P2.Parameter1Guid = '" & DGL1.Item(Col1GUID, I).Value & "' ) AS V1    " & _
                                    " SELECT CASE WHEN IsNull(@bColumnStr1,'') <> '' " & _
                                    " THEN SubString(@bColumnStr1,2, Len(@bColumnStr1)-1) Else '' END  AS FeeCodeList,   " & _
                                    " CASE WHEN IsNull(@bColumnStr2,'') <> ''     " & _
                                    " THEN SubString(@bColumnStr2,2, Len(@bColumnStr2)-1) Else '' END  AS FeeNameList,   " & _
                                    " CASE WHEN IsNull(@bColumnStr3,'') <> ''     " & _
                                    " THEN SubString(@bColumnStr3,2, Len(@bColumnStr3)-1) Else '' END  AS ScholarShipList "

                            DsTemp = AgL.FillData(mQry, AgL.GCn)

                            DGL1.Item(Col1FeeCodeLIst, I).Value = AgL.XNull(DsTemp.Tables(0).Rows(0)("FeeCodeList"))
                            DGL1.Item(Col1FeeList, I).Value = AgL.XNull(DsTemp.Tables(0).Rows(0)("FeeNameList"))
                            DGL1.Item(Col1ScholarshipList, I).Value = AgL.XNull(DsTemp.Tables(0).Rows(0)("ScholarShipList"))


                            bDblTotalScholarshipAmt = 0
                            If DGL1.Item(Col1ScholarshipList, I).Value.ToString.Trim <> "" Then
                                bScholarshipStr = Split(DGL1.Item(Col1ScholarshipList, I).Value, ",")
                            End If

                            For bIntJ = 0 To bScholarshipStr.Length - 1
                                If bScholarshipStr(bIntJ).ToString.Trim <> "" Then
                                    bDblTotalScholarshipAmt += CType(bScholarshipStr(bIntJ), Double)
                                End If
                            Next

                            DGL1.Item(Col1FeeHeadWiseTotalScholarShip, I).Value = bDblTotalScholarshipAmt
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
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

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1Programme
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            '<Executable Code>
                            DGL1.Item(Col1ProgrammeDuration, mRowIndex).Value = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")

                                DGL1.Item(Col1ProgrammeDuration, mRowIndex).Value = AgL.VNull(DrTemp(0)("ProgrammeDuration"))
                            End If
                            DrTemp = Nothing
                        End If
                End Select
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1

                Select Case .CurrentCell.ColumnIndex

                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL1.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        Try
            Select Case sender.CurrentCell.ColumnIndex
                'Case <Dgl_Column>
                '    <Executable Code>
            End Select
        Catch Ex As NullReferenceException
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
    TxtSite_Code.Validating

        Dim DrTemp As DataRow() = Nothing
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, bAmt As Integer = 0, J As Integer = 0
        Dim bScholarshipStr() As String = Nothing
        Dim bBlnIsDataExists As Boolean = False

        Try
            If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            If AgL.RequiredField(TxtApplicableFrom, "Applicable From") Then Exit Function

            If TxtApplicableFrom.Text <> "" And TxtApplicableUpto.Text <> "" Then
                If CDate(TxtApplicableFrom.Text) > CDate(TxtApplicableUpto.Text) Then
                    MsgBox("Applicable Upto Date Can't Be Greater Than From Applicable Date!") : TxtApplicableUpto.Focus() : Exit Function
                End If
            End If

            mQry = "SELECT IsNull(count(*),0) AS Cnt " & _
                    " FROM Sch_ScholarShipParameter P " & _
                    " WHERE P.ModuleType = " & AgL.Chk_Text(mStrModuleType) & "  " & _
                    " AND P.MasterType = " & AgL.Chk_Text(mStrMasterType) & " " & _
                    " AND P.ApplicableFrom = " & AgL.ConvertDate(TxtApplicableFrom.Text) & " " & _
                    " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " P.Code <> '" & mSearchCode & "' ") & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() > 0 Then MsgBox("Record Exists For Selected Period!...") : TxtApplicableFrom.Focus() : Exit Function

            AgCL.AgBlankNothingCells(DGL1)

            For I = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1Category, I).Value.ToString.Trim <> "" And _
                    DGL1.Item(Col1Semester, I).Value.ToString.Trim <> "" Then


                    'If Val(DGL1.Item(Col1ProgrammeYear, I).Value) > Val(DGL1.Item(Col1ProgrammeDuration, I).Value) Then
                    '    MsgBox("Year Can't Be Greater Than From Duration : " & Val(DGL1.Item(Col1ProgrammeDuration, I).Value) & "!...", MsgBoxStyle.Critical, "Validation Check")
                    '    DGL1.CurrentCell = DGL1(Col1ProgrammeYear, I) : DGL1.Focus() : Exit Function
                    'End If

                    If DGL1.Item(Col1ScholarshipList, I).Value.ToString.Trim <> "" Then
                        bScholarshipStr = Split(DGL1.Item(Col1ScholarshipList, I).Value, ",")
                    End If
                    If DGL1.Item(Col1ScholarshipList, I).Value <> "" Then
                        bAmt = 0
                        For J = 0 To bScholarshipStr.Length - 1
                            If bScholarshipStr(J).ToString.Trim <> "" Then
                                bAmt += CType(bScholarshipStr(J), Double)
                            End If
                        Next

                        If Val(DGL1.Item(Col1ScholarShip, I).Value) <> bAmt Then
                            DGL1.Item(Col1FeeHeadWiseTotalScholarShip, I).Value = bAmt

                            MsgBox("Fee Head Wise Total Scholarship Amount is Mismatching! At Row No : " & Val(DGL1.Item(Col_SNo, I).Value) & "!...", MsgBoxStyle.Information)
                            DGL1.CurrentCell = DGL1(Col1BtnFeeHead, I) : DGL1.Focus() : Exit Function
                        End If
                    End If

                    If Not bBlnIsDataExists Then bBlnIsDataExists = True
                End If
            Next

            If Not bBlnIsDataExists Then
                MsgBox("Scholar Ship Detail Not Exists!...")
                DGL1.CurrentCell = DGL1(Col1Category, 0) : DGL1.Focus() : Exit Function
            End If

            If AgCL.AgIsDuplicate(DGL1, "" & Col1Category & "," & Col1Semester & "") Then Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sch_ScholarShipParameter", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True)
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub DGL1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim FrmObj As Form
        Dim I As Integer = 0
        Dim bFeeCodeStr As String = "", bFeeStr As String = "", bScholarshipStr As String = ""
        Dim bFeeCodeStrArr() As String = Nothing, bFeeStrArr() As String = Nothing, bScholarshipStrArr() As String = Nothing
        Dim bDblTotalScholarshipAmt As Double = 0
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1BtnFeeHead
                    If DGL1.Item(Col1FeeList, mRowIndex).Value Is Nothing Then DGL1.Item(Col1FeeList, mRowIndex).Value = ""
                    If DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value Is Nothing Then DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value = ""

                    bFeeCodeStrArr = Split(DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value.ToString, ",")

                    FrmObj = New FrmScholarshipHeadWise()
                    If FrmObj IsNot Nothing Then
                        If DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value <> "" Then
                            CType(FrmObj, FrmScholarshipHeadWise).FeeHeadStr = DGL1.Item(Col1FeeList, mRowIndex).Value
                            CType(FrmObj, FrmScholarshipHeadWise).FeeCodeStr = DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value
                            CType(FrmObj, FrmScholarshipHeadWise).ScholarshipStr = DGL1.Item(Col1ScholarshipList, mRowIndex).Value
                            CType(FrmObj, FrmScholarshipHeadWise).DblTotalScholarshipAmount = Val(DGL1.Item(Col1FeeHeadWiseTotalScholarShip, mRowIndex).Value)
                        End If
                    End If
                    FrmObj.ShowDialog()

                    'bDblTotalScholarshipAmt = 0
                    'With CType(FrmObj, FrmScholarshipHeadWise).DGL1
                    '    For I = 0 To .Rows.Count - 1
                    '        If .Item(FrmScholarshipHeadWise.Col1FeeCode, I).Value <> "" Then
                    '            bFeeStr += IIf(bFeeStr.Trim = "", .Item(FrmScholarshipHeadWise.Col1FeeCode, I).Value, "," + .Item(FrmScholarshipHeadWise.Col1FeeCode, I).Value)
                    '            bFeeCodeStr += .AgSelectedValue(FrmScholarshipHeadWise.Col1FeeCode, I) + ","
                    '            bScholarshipStr += .Item(FrmScholarshipHeadWise.Col1Scholarship, I).Value + ","
                    '            bDblTotalScholarshipAmt += Val(.Item(FrmScholarshipHeadWise.Col1Scholarship, I).Value)
                    '        End If
                    '    Next
                    'End With
                    DGL1.Item(Col1FeeList, mRowIndex).Value = CType(FrmObj, FrmScholarshipHeadWise).FeeHeadStr
                    DGL1.Item(Col1FeeCodeLIst, mRowIndex).Value = CType(FrmObj, FrmScholarshipHeadWise).FeeCodeStr
                    DGL1.Item(Col1ScholarshipList, mRowIndex).Value = CType(FrmObj, FrmScholarshipHeadWise).ScholarshipStr
                    DGL1.Item(Col1FeeHeadWiseTotalScholarShip, mRowIndex).Value = CType(FrmObj, FrmScholarshipHeadWise).DblTotalScholarshipAmount
                    FrmObj = Nothing
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveParameter2(ByVal bGUID As String, ByVal bSearchCode As String, ByVal bFeeCodeList As String, ByVal bScholarshipList As String, ByVal bRowIndex As Integer)
        Dim I As Integer = 0, bSr As Integer = 0
        Dim bFeeCodeStr() As String = Nothing
        Dim bScholarshipStr() As String = Nothing

        If bFeeCodeList <> "" Then bFeeCodeStr = Split(bFeeCodeList, ",")
        If bScholarshipList <> "" Then bScholarshipStr = Split(bScholarshipList, ",")

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            mQry = "DELETE FROM Sch_ScholarShipParameter2 Where Parameter1Guid = '" & bGUID & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        End If

        With DGL1
            If .Item(Col1FeeCodeLIst, bRowIndex).Value <> "" Then
                For I = 0 To bFeeCodeStr.Length - 1
                    If bFeeCodeStr(I) <> "" Then
                        bSr += 1
                        mQry = "INSERT INTO Sch_ScholarShipParameter2( " & _
                                " Parameter1Guid, Sr, Code, Fee, ScholarShip ) VALUES 	(	" & _
                                " " & AgL.Chk_Text(bGUID) & ",	" & Val(bSr) & ",	" & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & _
                                " " & AgL.Chk_Text(bFeeCodeStr(I)) & ", " & _
                                " " & Val(bScholarshipStr(I)) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End If
        End With
    End Sub

    Private Sub DGL1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL1.CellValidating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1ProgrammeYear
                        If DGL1.Item(Col1ProgrammeDuration, mRowIndex).Value Is Nothing Then DGL1.Item(Col1ProgrammeDuration, mRowIndex).Value = ""

                        If AgL.VNull(e.FormattedValue) > Val(.Item(Col1ProgrammeDuration, e.RowIndex).Value) Then
                            MsgBox("Year Can't Be Greater Than From Duration : " & Val(.Item(Col1ProgrammeDuration, e.RowIndex).Value) & "!...", MsgBoxStyle.Critical, "Validation Check")
                            e.Cancel = True : Exit Sub
                        End If
                    Case Col1BtnFeeHead
                        If Val(DGL1.Item(Col1ScholarShip, mRowIndex).Value) <> Val(DGL1.Item(Col1FeeHeadWiseTotalScholarShip, mRowIndex).Value) Then
                            MsgBox("Fee Head Wise Total Scholarship Amount is Mismatching!...", MsgBoxStyle.Critical, "Validation Check")
                            e.Cancel = True : Exit Sub
                        End If

                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
