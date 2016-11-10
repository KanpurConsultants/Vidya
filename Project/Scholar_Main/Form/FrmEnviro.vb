Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEnviro
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

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

    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid)  Then
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
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select E.Site_Code As SearchCode " & _
                " From Sch_Enviro E " & _
                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.Gcn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT Sg.SubCode Code, Sg.Name " & _
                " FROM SubGroup Sg " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        TxtDiscountAc.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtFeeAdjustmentAc.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtFeeReceiptAdjustmentAc.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtScholarshipAdjustmentAc.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtCounselingFeeAdjustmentAc.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                " FROM AcGroup A " & _
                " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "' AND " & _
                " MainGrLen > " & AgLibrary.ClsConstant.MainGRLenSundryDebtors & " AND AliasYn = 'N'"
        TxtAcGroup_Student.AgHelpDataSet(2, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtAcGroup_Student.Focus()
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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_Enviro Where Site_Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    Call IniDtSch_Enviro()

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
        TcEnviro.SelectedTab = TpAcParameter
        TxtAcGroup_Student.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select  E.Site_Code As SearchCode,  S.Name As [Site Name] " & _
                                " From Sch_Enviro E " & _
                                " Left Join SiteMast S On E.Site_Code = S.Code "


            AgL.PubFindQryOrdBy = "[Site Name]"

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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_Enviro ( Site_Code, DiscountAc, FeeAdjustmentAc, FeeReceiptAdjustmentAc, AcGroup_Student, ScholarshipAdjustmentAc, CounselingFeeAdjustmentAc, LockBackDays, " & _
                        " Div_Code, PreparedBy, U_EntDt, U_AE, AttendanceDbName, AttendanceServer, AttendanceUser, AttendancePassword, IsAutoAcManualCode,ReportFooter1,ReportFooter2) " & _
                        " VALUES ( " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.Chk_Text(TxtDiscountAc.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtFeeAdjustmentAc.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtFeeReceiptAdjustmentAc.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtAcGroup_Student.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtScholarshipAdjustmentAc.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtCounselingFeeAdjustmentAc.AgSelectedValue) & ", " & _
                        " " & Val(TxtLockBackDays.Text) & "," & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A', " & _
                        " " & AgL.Chk_Text(TxtDatabase.Text) & " , " & _
                        " " & AgL.Chk_Text(TxtServer.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtUserID.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtPassward.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsAutoAcManualCode.Text, "Yes"), 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtReportFooter1.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtReportFooter2.Text) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_Enviro " & _
                        " SET " & _
                        " AcGroup_Student = " & AgL.Chk_Text(TxtAcGroup_Student.AgSelectedValue) & ", " & _
                        " DiscountAc = " & AgL.Chk_Text(TxtDiscountAc.AgSelectedValue) & ", " & _
                        " FeeAdjustmentAc = " & AgL.Chk_Text(TxtFeeAdjustmentAc.AgSelectedValue) & ", " & _
                        " FeeReceiptAdjustmentAc = " & AgL.Chk_Text(TxtFeeReceiptAdjustmentAc.AgSelectedValue) & ", " & _
                        " ScholarshipAdjustmentAc = " & AgL.Chk_Text(TxtScholarshipAdjustmentAc.AgSelectedValue) & ", " & _
                        " CounselingFeeAdjustmentAc = " & AgL.Chk_Text(TxtCounselingFeeAdjustmentAc.AgSelectedValue) & ", " & _
                        " LockBackDays = " & Val(TxtLockBackDays.Text) & ", " & _
                        " IsAutoAcManualCode = " & IIf(AgL.StrCmp(TxtIsAutoAcManualCode.Text, "Yes"), 1, 0) & ", " & _
                        " U_AE = 'E', " & _
                        " AttendanceDbName = " & AgL.Chk_Text(TxtDatabase.Text) & ", " & _
                        " AttendanceServer = " & AgL.Chk_Text(TxtServer.Text) & ", " & _
                        " AttendanceUser = " & AgL.Chk_Text(TxtUserID.Text) & ", " & _
                        " AttendancePassword = " & AgL.Chk_Text(TxtPassward.Text) & ", " & _
                        " ReportFooter1 = " & AgL.Chk_Text(TxtReportFooter1.Text) & ", " & _
                        " ReportFooter2 = " & AgL.Chk_Text(TxtReportFooter2.Text) & ", " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                        " Where Site_Code = '" & TxtSite_Code.AgSelectedValue & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()

            mTrans = False
            FIniMaster(0, 1)
            Topctrl1_tbRef()

            Call IniDtSch_Enviro()

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
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select E.* " & _
                        " From Sch_Enviro E " & _
                        " Where E.Site_Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtAcGroup_Student.AgSelectedValue = AgL.XNull(.Rows(0)("AcGroup_Student"))
                        TxtFeeAdjustmentAc.AgSelectedValue = AgL.XNull(.Rows(0)("FeeAdjustmentAc"))
                        TxtDiscountAc.AgSelectedValue = AgL.XNull(.Rows(0)("DiscountAc"))
                        TxtFeeReceiptAdjustmentAc.AgSelectedValue = AgL.XNull(.Rows(0)("FeeReceiptAdjustmentAc"))
                        TxtScholarshipAdjustmentAc.AgSelectedValue = AgL.XNull(.Rows(0)("ScholarshipAdjustmentAc"))
                        TxtCounselingFeeAdjustmentAc.AgSelectedValue = AgL.XNull(.Rows(0)("CounselingFeeAdjustmentAc"))
                        TxtLockBackDays.Text = AgL.VNull(.Rows(0)("LockBackDays"))
                        TxtIsAutoAcManualCode.Text = IIf(AgL.VNull(.Rows(0)("IsAutoAcManualCode")), "Yes", "No")

                        TxtDatabase.Text = AgL.XNull(.Rows(0)("AttendanceDbName"))
                        TxtUserID.Text = AgL.XNull(.Rows(0)("AttendanceUser"))
                        TxtServer.Text = AgL.XNull(.Rows(0)("AttendanceServer"))
                        TxtPassward.Text = AgL.XNull(.Rows(0)("AttendancePassword"))

                        TxtReportFooter1.Text = AgL.XNull(.Rows(0)("ReportFooter1"))
                        TxtReportFooter2.Text = AgL.XNull(.Rows(0)("ReportFooter2"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With
                Topctrl1.tAdd = False
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Topctrl1.tDel = False : Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        TcEnviro.SelectedTab = TpAcParameter
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        LblFeeAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        TxtFeeAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule

        'Code BY Akash On Date 24-01-11
        LblFeeReceiptAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        TxtFeeReceiptAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        'End Code

        'Code BY Akash On Date 8-03-11
        LblScholarshipAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        TxtScholarshipAdjustmentAc.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        'End Code
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            If AgL.RequiredField(TxtSite_Code, "Branch/Site") Then Exit Function

            If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                If AgL.RequiredField(TxtFeeAdjustmentAc, "Fee Adjustment A/c") Then Exit Function
                'If AgL.RequiredField(TxtFeeReceiptAdjustmentAc, "Fee Receipt Adjustment A/c") Then Exit Function
            End If


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


End Class 
