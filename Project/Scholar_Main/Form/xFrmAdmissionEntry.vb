Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class xFrmAdmissionEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mLastSessionProgrammeStreamDesc$ = "", mLastFromStreamYearSemesterCode_Fee$ = "", mLastToStreamYearSemesterCode_Fee$ = "", mLastFromStreamYearSemesterCode_Subject$ = "", mLastToStreamYearSemesterCode_Subject$ = ""


    Dim mIsPromotionDetailExists As Boolean = False, mIsSubjectLocked As Boolean = False, mIsFeeLocked As Boolean = False, mIsNewAdmissionPromotion As Boolean = False
    Dim mBlnIsLibraryMemberExists As Boolean = False
    Dim mFeeDueDocId$ = "", mCurrentSemesterStartDate$ = ""

    Dim mFirstStreamCode$ = "", mFromSemesterStreamCode$ = "", mToSemesterStreamCode$ = "", mCurrentSemesterStreamCode$ = ""
    Dim mProgrammeCode$ = "", mNewProgrammeCode$ = "", mCurrentStreamYearSemester$ = ""
    Dim mFromSemesterSerialNo As Integer = 0, mToSemesterSerialNo As Integer = 0, mCurrentSemesterSerialNo As Integer = 0

    Dim mObjClsMain As New ClsMain(AgL, PLib)
    Dim mObjStructLibraryMember As ClsMain.StructLibraryMember = Nothing


    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1StreamYearSemester As Byte = 1
    Private Const Col1Fee As Byte = 2
    Private Const Col1Amount As Byte = 3
    Private Const Col1FeeStreamYearSemester As Byte = 4

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2SemesterSubject As Byte = 1
    Private Const Col2Subject As Byte = 2
    Private Const Col2ManualCode As Byte = 3
    Private Const Col2PaperID As Byte = 4
    Private Const Col2MinCreditHours As Byte = 5
    Private Const Col2IsSubjectSelected As Byte = 6
    Private Const Col2IsElectiveSubject As Byte = 7
    Private Const Col2OtherSemesterSubject As Byte = 8

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Private Const Col3DocumentCode As Byte = 1

    Public WithEvents DGL4 As New AgControls.AgDataGrid
    Private Const Col4FromStreamYearSemester As Byte = 1
    Private Const Col4PromotionDate As Byte = 2
    Private Const Col4ToStreamYearSemester As Byte = 3
    Private Const Col4PromotionType As Byte = 4


    Dim mBlnIsUserCanApprove As Boolean = False, mBlnIsAutoApproved As Boolean = False
    Dim _FormType As eFormType

    Public Enum eFormType
        AdmissionEntry
        AdmissionEntryAuthenticated
    End Enum

    Public Property FormType() As eFormType
        Get
            FormType = _FormType
        End Get
        Set(ByVal value As eFormType)
            _FormType = value
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
        ''==============================================================================
        ''================< Semester/Fee Data Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1StreamYearSemester", 300, 50, "Semester", True, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Fee", 420, 50, "Fee Head", True, False, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Amount", True, False, True, True)
            .AddAgTextColumn(DGL1, "DGL1FeeStreamYearSemester", 200, 50, "FeeStreamYearSemester", False, True, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40

        DGL1.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        LblFeeDetail.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        BtnFillFee.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        ''==============================================================================
        ''================< Semester/Subject Data Grid >================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "Dgl2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2StreamYearSemester", 220, 50, "Semester", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2SemesterSubject", 350, 73, "Subject", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2ManualCode", 80, 50, "Manual Code", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2PaperID", 60, 50, "Paper ID", True, True, False, True)
            .AddAgNumberColumn(DGL2, "Dgl2MinCreditHours", 50, 3, 2, False, "Credit Hrs.", True, True, True)
            .AddAgListColumn(DGL2, "Yes,No", "Dgl2IsSubjectSelected", 60, "1,0", "Yes/No", True, False)
            .AddAgTextColumn(DGL2, "Dgl2IsElectiveSubject", 100, 1, "IsElectiveSubject", False, True, False)
            .AddAgTextColumn(DGL2, "Dgl2OtherSemesterSubject", 200, 1, "Subject Swap", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False

        ''==============================================================================
        ''================< Document Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL3, "DGL3DocumentCode", 340, 8, "Document", True, False, False)
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)


        ''==============================================================================
        ''================< Promotion Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL4, "DGL4SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4FromStreamYearSemester", 240, 8, "From Semester", True, True, False)
            .AddAgDateColumn(DGL4, "Dgl4PromotionDate", 80, "Promotion Date", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4ToStreamYearSemester", 240, 8, "To Semester", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4PromotionType", 120, 20, "Promotion Type", True, True, False)

        End With
        AgL.AddAgDataGrid(DGL4, Pnl4)
        DGL4.ColumnHeadersHeight = 40
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

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Dim FrmObj As Form = Nothing
        Dim CFOpen As New ClsFunction
        Dim MDI As New MDIMain
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                Case TxtStudent.Name
                    FrmObj = CFOpen.FOpen(MDI.MnuAmStudentMaster.Name, MDI.MnuAmStudentMaster.Text, True)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmStudentMaster).RegistrationDocId = TxtRegistrationDocId.AgSelectedValue
                        CType(FrmObj, FrmStudentMaster).AsOnDate = TxtV_Date.Text
                    End If
            End Select

            If FrmObj IsNot Nothing Then
                FrmObj.MdiParent = Me.MdiParent
                FrmObj.Show()
                FrmObj = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default

            FrmObj = Nothing
            MDI = Nothing
            CFOpen = Nothing
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            AgL.GridDesign(DGL4)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            Topctrl1.ChangeAgGridState(DGL4, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where A.V_Date <=  '" & AgL.PubEndDate & "' " & _
                       " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.AdmissionEntry Then
                mCondStr += " And IsNull(A.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.AdmissionEntryAuthenticated Then
                mCondStr += " And IsNull(A.ApprovedBy,'')<>'' "
            End If

            mQry = "Select A.DocId As SearchCode " & _
                    " From Sch_Admission A " & _
                    " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Dim MDI As New MDIMain
        Try
            mBlnIsUserCanApprove = AgL.FunHaveControlPermission(FunGetModuleName, MDI.MnuAmAdmissionEntry.Text, AgL.PubUserName, GroupBox1.Text)

            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_StudentAdmission) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.SubCode AS Code, Sg.Name, Sg.ManualCode, S.FirstName, S.MiddleName, S.LastName, S.Sex, S.NationalityCode, " & _
                      " S.Occupation, S.MotherName, S.MotherNamePrefix, S.FamilyIncome, S.Religion, S.Category, S.IsInternationalStudent," & _
                      " S.PassportNo, S.VisaExpiryDate, S.VisaType, S.EnglishProficiency_IELTS, S.EnglishProficiency_TOEFL, " & _
                      " S.EnglishProficiency_Others, S.BloodGroup, Sg.FatherNamePrefix , Sg.FatherName, Sg.Add1 , Sg.Add2 , Sg.Add3 ," & _
                      " Sg.CityCode, Sg.PIN , Sg.Phone , Sg.Mobile , Sg.EMail, Sg.DOB, " & _
                      " S.FatherCompany, S.FatherCompanyAddress, S.FatherDesignation, S.MotherOccupation, S.MotherCompany, S.MotherCompanyAddress, " & _
                      " S.MotherDesignation, S.MotherIncome, S.MarkOfId, S.TAdd1, S.TAdd2, S.TAdd3, S.TCityCode, S.TPin, S.TPhone, S.TMobile, S.TFax,  S.LocalGuardian, " & _
                      " Sg.PAdd1, Sg.PAdd2, Sg.PAdd3, Sg.PCityCode, Sg.PPin, Sg.PPhone, Sg.PMobile, Sg.PFax, S.FatherIncome " & _
                      " From Sch_Student S " & _
                      " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                      " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                      " Order By Sg.Name "
            TxtStudent.AgHelpDataSet(58) = AgL.FillData(mQry, AgL.GCn)

            TxtCategory.AgHelpDataSet = AgL.FillData("SELECT C.Code , C.ManualCode AS Name FROM Sch_Category C Order By C.ManualCode ", AgL.GCn)

            mQry = "SELECT R.Code, R.Description AS Religion FROM Sch_Religion R ORDER BY R.Description "
            TxtReligion.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code , VS.SessionProgrammeStream Name, VS.SessionProgramme, VS.SessionStartDate, " & _
                    " Vs.Stream AS StreamCode, Vs.ProgrammeCode " & _
                    " FROM ViewSch_SessionProgrammeStream VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgrammeStream "
            TxtSessionProgrammeStream.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT VSem.Code , VSem.Description AS Semester, VSem.SemesterStartDate , VYear.SessionProgrammeStreamCode,  " & _
                    " VSem.SessionProgrammeCode, VSem.SemesterSerialNo, VSem.SessionStartDate, VSem.StreamCode, VSem.ProgrammeCode " & _
                    " FROM ViewSch_StreamYearSemester VSem " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear VYear ON VSem.SessionProgrammeStreamYear = VYear.SessionProgrammeStreamYearCode " & _
                    " Where " & AgL.PubSiteCondition("VSem.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By VYear.SessionProgrammeStreamCode, VSem.SemesterStartDate "
            TxtFromStreamYearSemester.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)
            TxtToStreamYearSemester.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)
            'TxtNewStreamYearSemester.AgHelpDataSet(7, Tc1.Top + Tp3.Top, Tc1.Left + Tp3.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL4.AgHelpDataSet(Col4FromStreamYearSemester, 7) = AgL.FillData(mQry, AgL.GCn)
            DGL4.AgHelpDataSet(Col4ToStreamYearSemester, 7) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT N.Code , N.Description AS Name FROM Sch_AdmissionNature N ORDER BY N.Description "
            TxtAdmissionNature.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT R.DocId AS Code, " & AgL.V_No_Field("R.DocId") & " As [Voucher No], " & _
                    " Rs.FirstName + CASE WHEN Rs.MiddleName IS NULL THEN space(1) ELSE Rs.MiddleName + Space(1) END + rs.LastName As [Student Name], R.ManualRegNo As [Manual Registration No], Vs.SessionProgramme Proramme, " & _
                    " R.SessionProgramme , R.AdmissionNature , R.SessionProgrammeStream , Rs.Student, " & _
                    " R.SessionCode, R.ProgrammeCode, R.SessionStartDate, S.Stream As StreamCode, " & _
                    " IsNull(R.AdmissionDocId,'') As AdmissionDocId, CASE WHEN IsNull(R.AdmissionDocId,'') = '' THEN 'No' ELSE 'Yes' END IsAdmited " & _
                    " FROM ViewSch_Registration R " & _
                    " LEFT JOIN Sch_RegistrationStudentDetail Rs ON R.DocId = Rs.DocId " & _
                    " Left Join ViewSch_SessionProgramme Vs On R.SessionProgramme = Vs.Code " & _
                    " Left Join ViewSch_SessionProgrammeStream S On S.Code = S.SessionProgrammeStream " & _
                    " Where R.V_Date < = " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " IsNull(R.IsCancelled,0) = 0 And " & _
                    " " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " "
            TxtRegistrationDocId.AgHelpDataSet(10) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT D.Code , D.Description AS Name  FROM Sch_Document D ORDER BY D.Description "
            DGL3.AgHelpDataSet(Col3DocumentCode, , Tc1.Top + Tp4.Top, Tc1.Left + Tp4.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Ss.Code, Vs.Description AS Semester, S.Description AS Subject, Ss.Subject AS SubjectCode, " & _
                    " Ss.StreamYearSemester, Ss.ManualCode, Ss.PaperID, Ss.MinCreditHours, Ss.IsElectiveSubject " & _
                    " FROM Sch_SemesterSubject Ss " & _
                    " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Vs ON Ss.StreamYearSemester = Vs.Code " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc, S.Description "
            DGL2.AgHelpDataSet(Col2SemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL2.AgHelpDataSet(Col2OtherSemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.Description AS Name " & _
                    " FROM Sch_Subject S " & _
                    " ORDER BY S.Description "
            DGL2.AgHelpDataSet(Col2Subject, , Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code, Vs.Description AS Semester " & _
                    " FROM ViewSch_StreamYearSemester Vs " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Vs.SemesterStartDate , Vs.Description "
            DGL1.AgHelpDataSet(Col1StreamYearSemester, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL1.AgHelpDataSet(Col1FeeStreamYearSemester, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT F.Code, Sg.DispName [Fee Head], F.FeeNature, F.Refundable " & _
                    " FROM Sch_Fee F " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                    " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                    " ORDER BY F.FeeNature , Sg.Name "
            DGL1.AgHelpDataSet(Col1Fee, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code , VS.SessionProgramme, Vs.SessionManualCode, VS.ProgrammeManualCode " & _
                    " FROM ViewSch_SessionProgramme VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgramme "
            TxtSessionProgramme.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtStatus, PubAdmissionStatusStr)

            If AgL.IsTableExist("Lib_MemberType", AgL.GCn) Then
                mQry = "SELECT T.Code, T.Description, " & _
                        " CASE WHEN IsNull(T.IsDeleted,0) <> 0 THEN 'Yes' ELSE 'No' END AS IsDeleted " & _
                        " FROM Lib_MemberType T " & _
                        " ORDER BY T.Description "
                TxtLibraryMemberType.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member Start >====================================================================
                    ''==========================================================================================================================================
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member_Log Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member End >====================================================================
                    ''==========================================================================================================================================

                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDue Where AdmissionDocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mFeeDueDocId)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue1 Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionDocument Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionSubject Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionStatusChangeDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionPromotion Where AdmissionDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_Admission Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, TxtStatus.Text, TxtV_Date.Text, TxtStudent.AgSelectedValue, TxtStudent.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
                    Else
                        AgL.PubSearchRow = ""
                    End If
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where A.V_Date <= '" & AgL.PubEndDate & "' " & _
                       " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.AdmissionEntry Then
                mCondStr += " And IsNull(A.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.AdmissionEntryAuthenticated Then
                mCondStr += " And IsNull(A.ApprovedBy,'')<>'' "
            End If

            AgL.PubFindQry = "SELECT A.DocId As SearchCode, " & AgL.V_No_Field("A.DocId") & " As [Voucher No], A.AdmissionID , A.StudentName , " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], A.V_Date, " & _
                                " A.SessionProgrammeStreamDesc As Stream, N.Description AS [Admission Nature] , " & AgL.V_No_Field("A.RegistrationDocId") & " [Registration VNo], " & _
                                " A.ManualRegNo  AS [Manual Registration No], A.EnrollmentNo , A.RollNo, A.FatherName As [Father Name] , A.MotherName As [Mother Name] , " & _
                                " A.Phone , A.Mobile , A.CityName As City " & _
                                " FROM ViewSch_Admission A " & _
                                " LEFT JOIN Sch_AdmissionNature N ON A.AdmissionNature = N.Code " & _
                                " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON A.Site_Code = S.Code " & mCondStr

            AgL.PubFindQryOrdBy = "[Voucher No]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            'Me.Cursor = Cursors.WaitCursor

            'AgL.PubReportTitle = "Sale Bill"
            'RepName = "SaleInvoice" : RepTitle = "Sale Invoice"

            'If mDocId = "" Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'strQry = "SELECT S.DocId,Vt.Description AS V_TypeDesc,S.V_Prefix,S.V_No,S.V_Date, " & _
            '            "S.SaleOrderDocId,S.SaleDocId,S.CashCredit,C.Name As Customer_AC,S.PartyName, " & _
            '            "S.Add1,S.Add2,S.Add3,S.CityCode,SMan.Name AS SalesMan_Name,Astro.Name AS Astrologer_Name, " & _
            '            "S.Amount AS Amount_H,S.Scheme AS SchemeAmt_H, " & _
            '            "S.Addition AS Addition_H,S.Deduction AS Deduction_H,S.TaxableAmt AS TaxableAmt_H, " & _
            '            "S.TaxPer AS TaxPer_H,S.TaxAmt AS TaxAmt_H,S.AdditionalTaxPer AS AdditionalTaxPer_H, " & _
            '            "S.AdditionalTaxAmt AS AdditionalTaxAmt_H,S.Labour AS Labour_H, " & _
            '            "S.AdditionAfterTax_Per AS AdditionAfterTax_Per_H,S.AdditionAfterTax AS AdditionAfterTax_H, " & _
            '            "S.DeductionAfterTax_Per AS DeductionAfterTax_Per_H,S.DeductionAfterTax AS DeductionAfterTax_H, " & _
            '            "S.TotalAmount AS TotalAmount_H,S.RoundOff AS RoundOff_H,S.NetAmount AS NetAmount_H, " & _
            '            "S.Advance AS Advance_H,S.Balance AS Balance_H,S.Remark AS Remark_H,S.PreparedBy, " & _
            '            "S.U_EntDt,S.U_AE,S.Edit_Date,S.ModifiedBy,Stk.Sr,Stk.OrderDocId,Stk.ReferenceDocID, " & _
            '            "Stk.BarCode,Scheme.Description AS SchemeDescription,Stk.Item,(Case When Stk.ItemDesc Is Null Then I.Description Else Stk.ItemDesc End) As ItemDesc, U.Description As Unit, " & _
            '            "TFL.Description AS TaxForm_L,Stk.SchemeYn,Stk.GroupReceiveQty,Stk.GroupIssueQty,Stk.ReceiveQty, " & _
            '            "Stk.IssueQty,Stk.PrintQty,Stk.Rate,Stk.Amount,Stk.Addition,Stk.Deduction,Stk.TaxableAmt, " & _
            '            "Stk.TaxPer,Stk.TaxAmt,Stk.AdditionalTaxPer,Stk.AdditionalTaxAmt,Stk.AdditionAfterTax, " & _
            '            "Stk.DeductionAfterTax, Stk.NetAmount, Stk.CentralTaxAmt, Stk.LandedRate, Stk.LandedAmount, Stk.Remark, Site.Name As SiteName " & _
            '            "FROM Sale S " & _
            '            "LEFT JOIN Stock Stk ON S.DocId = Stk.DocId " & _
            '            "LEFT JOIN Voucher_Type Vt ON s.V_Type =Vt.V_Type " & _
            '            "LEFT JOIN SubGroup C ON S.Customer = C.SubCode " & _
            '            "LEFT JOIN SubGroup SMan ON S.SalesMan = SMan.SubCode " & _
            '            "LEFT JOIN SubGroup Astro ON S.Astrologer  = Astro.SubCode " & _
            '            " " & _
            '            "LEFT JOIN SCHEME ON Stk.Scheme = Scheme.Code " & _
            '            "LEFT JOIN TaxForm TfL ON Stk.TaxForm =TFL.Code " & _
            '            "Left Join Item I On Stk.Item = I.Code " & _
            '            "Left Join Unit U On I.Unit = U.Code " & _
            '            "Left Join SiteMast Site On I.Site_Code = Site.Code " & _
            '            "Where S.DocId = '" & mDocId & "' "


            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(DsRep)


            'AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic & "\" & RepName & ".ttx", True)
            'mCrd.Load(PLib.PubReportPath_Academic & "\" & RepName & ".rpt")
            'mCrd.SetDataSource(DsRep.Tables(0))
            'CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            'PLib.Formula_Set(mCrd, RepTitle)
            'AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            'Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim GcnRead As SqlClient.SqlConnection
        Dim bStrApprovedDate$ = ""

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            If mBlnIsUserCanApprove Then bStrApprovedDate = AgL.GetDateTime(AgL.GCn)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_Admission ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, RegistrationDocId, " & _
                        " AdmissionNature, SessionProgrammeStream, SessionProgramme, Student, AdmissionID, Remark, ScholarshipApplied, Status, " & _
                        " Rank, RankRemark, MeritPercentage, MeritRemark, IsFeeWavier, IsDiplomaHolder, CounselingFee, CounselingFeeReceiptNo, " & _
                        " AdmissionSemester, PromotionSemester, " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & _
                        " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionID.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & IIf(AgL.StrCmp(TxtScholarshipApplied.Text, "Yes"), 1, 0) & ", " & AgL.Chk_Text(TxtStatus.Text) & "," & _
                        " " & Val(TxtRank.Text) & ", " & AgL.Chk_Text(TxtRankRemark.Text) & ", " & Val(TxtMeritPercentage.Text) & ", " & AgL.Chk_Text(TxtMeritRemark.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsFeeWavier.Text, "Yes"), 1, 0) & ", " & IIf(AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes"), 1, 0) & ", " & _
                        " " & Val(TxtCounselingFee.Text) & ", " & AgL.Chk_Text(TxtCounselingFeeReceiptNo.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ", " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                '===============================================================================================================================================
                '==================< INSERT FIRST RECORD IN >===================================================================================================
                '================< Sch_AdmissionPromotion Table >===============================================================================================
                '===============================================================================================================================================

                mQry = "INSERT INTO Sch_AdmissionPromotion ( " & _
                        " AdmissionDocId, Sr, FromStreamYearSemester,PromotionDate, ToStreamYearSemester, PromotionType, " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', 1, " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(IIf(TxtToStreamYearSemester.Text.Trim = "", "", TxtV_Date.Text).ToString) & ", " & _
                        " " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & AgL.Chk_Text(PLib.FunGetPromotionType(TxtStatus.Text, TxtIsStreamChange.Text)) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                '===============================================================================================================================================
                '==================< INSERT Second RECORD IN >===================================================================================================
                '================< Sch_AdmissionPromotion Table >===============================================================================================
                '===============================================================================================================================================
                If TxtToStreamYearSemester.Text.Trim <> "" Then
                    mQry = "INSERT INTO Sch_AdmissionPromotion ( AdmissionDocId, Sr, FromStreamYearSemester, " & _
                            " PreparedBy, U_EntDt, U_AE ) " & _
                            " VALUES ( " & _
                            " '" & mSearchCode & "', 2, " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
                '===============================================================================================================================================
            Else
                mQry = "UPDATE Sch_Admission SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", Student = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ", " & _
                        " SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " AdmissionNature = " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & _
                        " RegistrationDocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", AdmissionID = " & AgL.Chk_Text(TxtAdmissionID.Text) & ", Remark = " & AgL.Chk_Text(TxtRemark.Text) & " , " & _
                        " ScholarshipApplied = " & IIf(AgL.StrCmp(TxtScholarshipApplied.Text, "Yes"), 1, 0) & ", " & _
                        " Status = " & AgL.Chk_Text(TxtStatus.Text) & ", " & _
                        " Rank = " & Val(TxtRank.Text) & ", " & _
                        " RankRemark = " & AgL.Chk_Text(TxtRankRemark.Text) & ", " & _
                        " MeritPercentage = " & Val(TxtMeritPercentage.Text) & ", " & _
                        " MeritRemark = " & AgL.Chk_Text(TxtMeritRemark.Text) & ", " & _
                        " IsFeeWavier = " & IIf(AgL.StrCmp(TxtIsFeeWavier.Text, "Yes"), 1, 0) & ", IsDiplomaHolder = " & IIf(AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes"), 1, 0) & ", " & _
                        " CounselingFee = " & Val(TxtCounselingFee.Text) & ", " & _
                        " CounselingFeeReceiptNo = " & AgL.Chk_Text(TxtCounselingFeeReceiptNo.Text) & ", " & _
                        " FromStreamYearSemester = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ", " & _
                        " ToStreamYearSemester = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & _
                        " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " Where DocId = '" & mSearchCode & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Select IsNull(Count(*),0) Cnt From Sch_AdmissionPromotion Ap With (NoLock) " & _
                            " Where Ap.AdmissionDocId = '" & mSearchCode & "' And Ap.Sr > 2 "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar() = 0 Then
                    '===============================================================================================================================================
                    '==================< INSERT FIRST RECORD IN >===================================================================================================
                    '================< Sch_AdmissionPromotion Table >===============================================================================================
                    '===============================================================================================================================================
                    mQry = "UPDATE Sch_AdmissionPromotion SET " & _
                            " FromStreamYearSemester = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ", PromotionDate = " & AgL.ConvertDate(IIf(TxtToStreamYearSemester.Text.Trim = "", "", TxtV_Date.Text).ToString) & ", " & _
                            " ToStreamYearSemester = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & _
                            " PromotionType = " & AgL.Chk_Text(PLib.FunGetPromotionType(TxtStatus.Text, TxtIsStreamChange.Text)) & ", " & _
                            " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " Where AdmissionDocId = '" & mSearchCode & "' AND Sr = 1"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    '===============================================================================================================================================
                    '==================< INSERT Second RECORD IN >===================================================================================================
                    '================< Sch_AdmissionPromotion Table >===============================================================================================
                    '===============================================================================================================================================
                    mQry = "UPDATE Sch_AdmissionPromotion SET " & _
                            " FromStreamYearSemester = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", PromotionDate = Null, " & _
                            " ToStreamYearSemester = Null, " & _
                            " PromotionType = Null, " & _
                            " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " Where AdmissionDocId = '" & mSearchCode & "' AND Sr = 2"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            End If


            If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                If Topctrl1.Mode = "Edit" Then
                    mQry = "Delete From Sch_AdmissionFeeDetail Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                With DGL1
                    mSr = 0
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col1StreamYearSemester, I).Value <> "" Then
                            mSr = mSr + 1

                            mQry = "INSERT INTO Sch_AdmissionFeeDetail ( DocId, Sr, StreamYearSemester, Fee, Amount , FeeStreamYearSemester) " & _
                                    " VALUES ( " & _
                                    " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1StreamYearSemester, I)) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1FeeStreamYearSemester, I)) & " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Next I
                End With
            End If


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_AdmissionSubject Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL2
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2SemesterSubject, I).Value <> "" And AgL.StrCmp(.Item(Col2IsSubjectSelected, I).Value, "Yes") Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO Sch_AdmissionSubject ( DocId, Sr, SemesterSubject, OtherSemesterSubject) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2SemesterSubject, I)) & ", " & AgL.Chk_Text(.AgSelectedValue(Col2OtherSemesterSubject, I)) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_AdmissionDocument Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL3
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col3DocumentCode, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO Sch_AdmissionDocument ( DocId, Sr, DocumentCode) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col3DocumentCode, I)) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                If Not mObjClsMain.FunSaveLibraryMember(mObjStructLibraryMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsLibraryMemberExists, "Edit", "Add")) Then
                    Err.Raise(1, , "")
                End If
            End If


            If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                If mBlnIsUserCanApprove Then Call ProcApproveVoucher(AgL.PubUserName, bStrApprovedDate, mBlnIsUserCanApprove)
            End If

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, TxtStatus.Text, TxtV_Date.Text, TxtStudent.AgSelectedValue, TxtStudent.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            If ex.Message <> "" Then MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveFeeDueDetail(Optional ByVal BlnIsApprovalCall As Boolean = False)
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim bStreamYearSemester$ = "", bStreamYearSemesterDesc$ = "", bStrEntryMode As String = Topctrl1.Mode

        If BlnIsApprovalCall Then
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                bStrEntryMode = "Add"
            End If
        End If

        If TxtToStreamYearSemester.AgSelectedValue.Trim <> "" Then
            bStreamYearSemester = TxtToStreamYearSemester.AgSelectedValue
            bStreamYearSemesterDesc = TxtToStreamYearSemester.Text
        Else
            bStreamYearSemester = TxtFromStreamYearSemester.AgSelectedValue
            bStreamYearSemesterDesc = TxtFromStreamYearSemester.Text
        End If

        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            bFeeDueObj.StreamYearSemesterDesc = bStreamYearSemesterDesc
            ProcCreateFeeDueStructure(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, mSearchCode, bStreamYearSemester, bFeeDueObj, bFeeDue1Obj, mFeeDueDocId)

            Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, bFeeDueObj, bFeeDue1Obj, mSearchCode)
            Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, bFeeDueObj)

            If bStrEntryMode = "Edit" Then
                mQry = "Delete From Sch_AdmissionFeeDue Where AdmissionDocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "INSERT INTO Sch_AdmissionFeeDue ( AdmissionDocId, FeeDueDocId, Remark ) " & _
                   " VALUES ( " & _
                   " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mFeeDueDocId) & ", '' )"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            AgL.UpdateVoucherCounter(mFeeDueDocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mFeeDueDocId, Me.Text, AgL.MidStr(bStrEntryMode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)
        End If
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim bStreamYearSemester$ = "", bToStreamYearSemester$ = "", bLastSessionProgrammeStreamCode$ = ""
        Dim mTransFlag As Boolean = False, bIsStatusChanged As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select A.*, Vt.NCat, Af.FeeDueDocId, Sps.SessionProgramme As SessionProgrammeCodeTemp, Sps.SessionStartDate, " & _
                        " Sps.Stream AS StreamCode, Sps.ProgrammeCode " & _
                        " From Sch_Admission A " & _
                        " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                        " Left Join Sch_AdmissionFeeDue Af On A.DocId = Af.AdmissionDocId " & _
                        " Left Join ViewSch_SessionProgrammeStream Sps On A.SessionProgrammeStream = Sps.Code " & _
                        " Where A.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))
                        LblSessionProgrammeStream.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCodeTemp"))

                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                        LblSessionProgrammeStreamReq.Tag = Format(AgL.XNull(.Rows(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        mFirstStreamCode = AgL.XNull(.Rows(0)("StreamCode"))
                        mProgrammeCode = AgL.XNull(.Rows(0)("ProgrammeCode"))

                        TxtAdmissionNature.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionNature"))
                        TxtRegistrationDocId.AgSelectedValue = AgL.XNull(.Rows(0)("RegistrationDocId"))
                        TxtStudent.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
                        LblStudent.Tag = AgL.XNull(.Rows(0)("Student"))

                        TxtScholarshipApplied.Text = IIf(AgL.VNull(.Rows(0)("ScholarshipApplied")), "Yes", "No")
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        mFeeDueDocId = AgL.XNull(.Rows(0)("FeeDueDocId"))

                        If Not mIsFeeLocked Then
                            mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                                    " FROM Sch_FeeDue1 Fd1 " & _
                                    " WHERE Fd1.AdmissionDocId = '" & mSearchCode & "' " & _
                                    " AND Fd1.DocId <> " & AgL.Chk_Text(AgL.XNull(.Rows(0)("FeeDueDocId"))) & " "
                            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mIsFeeLocked = True
                        End If

                        TxtLeavingDate.Text = Format(AgL.XNull(.Rows(0)("LeavingDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtLeavingReason.Text = AgL.XNull(.Rows(0)("LeavingReason"))
                        TxtStatus.Text = AgL.XNull(.Rows(0)("Status"))
                        TxtRank.Text = IIf(AgL.VNull(.Rows(0)("Rank")) = 0, "", AgL.VNull(.Rows(0)("Rank")))
                        TxtRankRemark.Text = AgL.XNull(.Rows(0)("RankRemark"))
                        TxtMeritPercentage.Text = IIf(AgL.VNull(.Rows(0)("MeritPercentage")) = 0, "", Format(AgL.VNull(.Rows(0)("MeritPercentage")), "0.00"))
                        TxtMeritRemark.Text = AgL.XNull(.Rows(0)("MeritRemark"))
                        TxtIsFeeWavier.Text = IIf(AgL.VNull(.Rows(0)("IsFeeWavier")), "Yes", "No")
                        TxtIsDiplomaHolder.Text = IIf(AgL.VNull(.Rows(0)("IsDiplomaHolder")), "Yes", "No")

                        TxtCounselingFee.Text = Format(AgL.VNull(.Rows(0)("CounselingFee")), "0.00")
                        TxtCounselingFeeReceiptNo.Text = AgL.XNull(.Rows(0)("CounselingFeeReceiptNo"))

                        If AgL.IsTableExist("Lib_MemberType", AgL.GCn) Then
                            mQry = "SELECT M.* FROM Lib_Member M WHERE M.SubCode = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("Student"))) & " "
                            DTbl = AgL.FillData(mQry, AgL.GCn).Tables(0)
                            If DTbl.Rows.Count > 0 Then
                                TxtLibraryMemberType.AgSelectedValue = AgL.XNull(DTbl.Rows(0)("MemberType"))
                            End If
                            If DTbl IsNot Nothing Then DTbl.Dispose()
                        End If

                        mBlnIsAutoApproved = AgL.VNull(.Rows(0)("IsAutoApproved"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select S.*, Sg.* " & _
                        " From Sch_Student S " & _
                        " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                        " Where S.SubCode = '" & TxtStudent.AgSelectedValue & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")
                    End If
                End With

                mQry = "Select Ap.*, Sem.SessionProgrammeStreamCode, Sem.SemesterSerialNo, Sem.SemesterStartDate, Sem.StreamCode " & _
                        " From Sch_AdmissionPromotion Ap " & _
                        " Left Join ViewSch_StreamYearSemester Sem On Ap.FromStreamYearSemester = Sem.Code " & _
                        " Where Ap.AdmissionDocId = '" & mSearchCode & "' " & _
                        " Order By Ap.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL4.Rows.Add()
                            DGL4.Item(Col_SNo, I).Value = DGL4.Rows.Count - 1
                            DGL4.AgSelectedValue(Col4FromStreamYearSemester, I) = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                            DGL4.AgSelectedValue(Col4ToStreamYearSemester, I) = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                            DGL4.Item(Col4PromotionDate, I).Value = Format(AgL.XNull(.Rows(I)("PromotionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL4.Item(Col4PromotionType, I).Value = AgL.XNull(.Rows(I)("PromotionType"))
                            bLastSessionProgrammeStreamCode = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))

                            If I = 0 Then
                                TxtFromStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                                mLastFromStreamYearSemesterCode_Fee = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                                mLastFromStreamYearSemesterCode_Subject = AgL.XNull(.Rows(I)("FromStreamYearSemester"))

                                LblFromStreamYearSemester.Tag = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))
                                mFromSemesterSerialNo = AgL.VNull(.Rows(I)("SemesterSerialNo"))
                                mFromSemesterStreamCode = AgL.XNull(.Rows(I)("StreamCode"))

                                If DGL4.Item(Col4PromotionDate, I).Value.ToString.Trim <> "" Then
                                    If CDate(TxtV_Date.Text) = CDate(DGL4.Item(Col4PromotionDate, I).Value.ToString) Then
                                        LblFromStreamYearSemesterReq.Tag = Format(AgL.XNull(.Rows(I)("PromotionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                                        TxtToStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                        mLastToStreamYearSemesterCode_Fee = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                        mLastToStreamYearSemesterCode_Subject = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                        bToStreamYearSemester = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                    End If
                                End If
                            ElseIf I = 1 And .Rows.Count > 1 And LblFromStreamYearSemesterReq.Tag.ToString.Trim <> "" Then
                                LblToStreamYearSemester.Tag = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))
                                mToSemesterSerialNo = AgL.VNull(.Rows(I)("SemesterSerialNo"))
                                mToSemesterStreamCode = AgL.XNull(.Rows(I)("StreamCode"))
                            End If

                            If AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_Ex) Or _
                                AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_ReAdmit) Or _
                                AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_StreamChange) Then

                                If Not mIsSubjectLocked Then mIsFeeLocked = True
                                If Not mIsFeeLocked Then mIsFeeLocked = True
                            End If

                        Next

                        mCurrentSemesterSerialNo = AgL.VNull(.Rows(.Rows.Count - 1)("SemesterSerialNo"))
                        mCurrentSemesterStartDate = Format(AgL.XNull(.Rows(.Rows.Count - 1)("SemesterStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        mCurrentSemesterStreamCode = AgL.XNull(.Rows(.Rows.Count - 1)("StreamCode"))
                        mCurrentStreamYearSemester = AgL.XNull(.Rows(.Rows.Count - 1)("FromStreamYearSemester"))

                        If bToStreamYearSemester.Trim = "" And .Rows.Count > 1 Then
                            mIsPromotionDetailExists = True
                        ElseIf bToStreamYearSemester.Trim <> "" And .Rows.Count > 2 Then
                            mIsPromotionDetailExists = True
                        End If

                    End If
                End With

                If mIsPromotionDetailExists = True And mIsFeeLocked = False Then mIsFeeLocked = True

                If TxtToStreamYearSemester.AgSelectedValue.Trim <> "" Then
                    bStreamYearSemester = TxtToStreamYearSemester.AgSelectedValue
                Else
                    bStreamYearSemester = TxtFromStreamYearSemester.AgSelectedValue
                End If

                mQry = "Select Af.* " & _
                        " From Sch_AdmissionFeeDetail Af " & _
                        " Where Af.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.AgSelectedValue(Col1FeeStreamYearSemester, I) = AgL.XNull(.Rows(I)("FeeStreamYearSemester"))
                        Next I
                    End If
                End With




                mQry = "Select Ads.SemesterSubject, VSub.Subject AS SubjectCode,  VSub.StreamYearSemester, VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.MinCreditHours, VSub.IsElectiveSubject, Convert(Bit,1) As IsSubjectSelected, Ads.Sr, Ads.OtherSemesterSubject    " & _
                        " From Sch_AdmissionSubject Ads   " & _
                        " Left Join ViewSch_SemesterSubject VSub On Ads.SemesterSubject = VSub.Code   " & _
                        " Where Ads.DocId = '" & mSearchCode & "' " & _
                        " UNION ALL  " & _
                        " Select VSub.Code AS SemesterSubject, VSub.Subject AS SubjectCode,  VSub.StreamYearSemester, VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.MinCreditHours, VSub.IsElectiveSubject, Convert(Bit,0) As IsSubjectSelected, 999999 As Sr, Null as OtherSemesterSubject    " & _
                        " FROM ViewSch_SemesterSubject VSub " & _
                        " LEFT JOIN Sch_AdmissionSubject Ads ON VSub.Code = Ads.SemesterSubject  " & _
                        " WHERE VSub.SessionProgrammeStreamCode ='" & TxtSessionProgrammeStream.AgSelectedValue & "' AND Ads.SemesterSubject IS NULL  " & _
                        " ORDER BY Sr "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2SemesterSubject, I) = AgL.XNull(.Rows(I)("SemesterSubject"))
                            DGL2.AgSelectedValue(Col2Subject, I) = AgL.XNull(.Rows(I)("SubjectCode"))
                            DGL2.Item(Col2ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                            DGL2.Item(Col2PaperID, I).Value = AgL.XNull(.Rows(I)("PaperId"))
                            DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("MinCreditHours")), "0.00")
                            DGL2.Item(Col2IsSubjectSelected, I).Value = IIf(AgL.VNull(.Rows(I)("IsSubjectSelected")), "Yes", "No")
                            DGL2.Item(Col2IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), 1, 0)
                            DGL2.AgSelectedValue(Col2OtherSemesterSubject, I) = AgL.XNull(.Rows(I)("OtherSemesterSubject"))

                            If Not mIsSubjectLocked Then
                                If AgL.XNull(.Rows(I)("OtherSemesterSubject")).ToString.Trim <> "" Then mIsSubjectLocked = True
                            End If

                            If Not mIsSubjectLocked Then
                                mQry = "SELECT IsNull(count(*),0) Cnt " & _
                                        " FROM Sch_StudentAttendance A " & _
                                        " LEFT JOIN Sch_StudentAttendance1 A1 ON A.Code = A1.Code  " & _
                                        " WHERE A1.AdmissionDocId = '" & mSearchCode & "' AND " & _
                                        " A.Subject = " & AgL.Chk_Text(AgL.XNull(.Rows(I)("SubjectCode"))) & " "

                                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mIsSubjectLocked = True
                            End If

                        Next I
                    End If
                End With

                mQry = "Select Ad.* " & _
                        " From Sch_AdmissionDocument Ad " & _
                        " Where Ad.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL3.RowCount = 1 : DGL3.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL3.Rows.Add()
                            DGL3.Item(Col_SNo, I).Value = DGL3.Rows.Count - 1
                            DGL3.AgSelectedValue(Col3DocumentCode, I) = AgL.XNull(.Rows(I)("DocumentCode"))
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If TxtLeavingDate.Text.Trim <> "" Then mTransFlag = True

                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If _FormType = eFormType.AdmissionEntry Then
                        If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    End If

                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            Topctrl1.tPrn = False

            Call DispUpText()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()
        DGL4.RowCount = 1 : DGL4.Rows.Clear()

        Call BlankFooterGrid()

        mObjStructLibraryMember = Nothing

        mIsPromotionDetailExists = False : mIsSubjectLocked = False : mIsFeeLocked = False : mIsNewAdmissionPromotion = False : mBlnIsAutoApproved = False : mBlnIsLibraryMemberExists = False

        TxtScholarshipApplied.Text = "No" : TxtIsFeeWavier.Text = "No" : TxtIsStreamChange.Text = "No" : TxtIsDiplomaHolder.Text = "No"
        TxtStatus.Text = Academic_ProjLib.ClsMain.AdmissionStatus_Regular
        mFeeDueDocId = "" : mCurrentSemesterStartDate = "" : mProgrammeCode = "" : mNewProgrammeCode = "" : mCurrentStreamYearSemester = ""
        mLastFromStreamYearSemesterCode_Fee = "" : mLastToStreamYearSemesterCode_Fee = "" : mLastFromStreamYearSemesterCode_Subject = "" : mLastToStreamYearSemesterCode_Subject = ""

        mFirstStreamCode = "" : mFromSemesterStreamCode = "" : mToSemesterStreamCode = "" : mCurrentSemesterStreamCode = ""
        mFromSemesterSerialNo = 0 : mToSemesterSerialNo = 0 : mCurrentSemesterSerialNo = 0

        Tc1.SelectedTab = Tp1
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid()
        '<Executable Code>
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillFee.Enabled = Enb
        BtnFillSubject.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtSessionProgrammeStream.Enabled = False
            TxtSessionProgramme.Enabled = False

            If mIsFeeLocked Or mIsSubjectLocked Or mIsPromotionDetailExists Then
                BtnFillFee.Enabled = False
                BtnFillSubject.Enabled = False
                TxtToStreamYearSemester.Enabled = False
                TxtStatus.Enabled = False
            End If
        End If


        Call DispUpText(Enb)
    End Sub

    Private Sub DispUpText(Optional ByVal Enb As Boolean = False)
        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            If _FormType = eFormType.AdmissionEntryAuthenticated Then
                GroupBox1.Visible = True : BtnApproved.Enabled = False

                Topctrl1.tAdd = False
                If Not mBlnIsUserCanApprove Then Topctrl1.tEdit = False

            ElseIf _FormType = eFormType.AdmissionEntry Then
                GroupBox1.Visible = True
            End If
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1StreamYearSemester
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1StreamYearSemester
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        'DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                'DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("Name", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2IsSubjectSelected
                    If AgL.StrCmp(DGL2.Item(Col2IsSubjectSelected, mRowIndex).Value.ToString, "No") And Val(DGL2.Item(Col2IsElectiveSubject, mRowIndex).Value) = 0 Then
                        DGL2.Item(Col2IsSubjectSelected, mRowIndex).Value = "Yes"
                        MsgBox("""" & DGL2.Item(Col2Subject, mRowIndex).Value & """ Is A Compulsory Subject!...")
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL3.RowsAdded, DGL4.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved, DGL3.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)

        Call Calculation()
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtFromStreamYearSemester.Enter, TxtToStreamYearSemester.Enter, _
        TxtSessionProgrammeStream.Enter, TxtRegistrationDocId.Enter, TxtAdmissionID.Enter, _
        TxtIsStreamChange.Enter, TxtLibraryMemberType.Enter
        Try
            Select Case sender.name
                Case TxtLibraryMemberType.Name
                    TxtLibraryMemberType.AgRowFilter = " IsDeleted = 'No' "

                Case TxtRegistrationDocId.Name
                    TxtRegistrationDocId.AgRowFilter = " (IsAdmited = 'No' Or AdmissionDocId = '" & mSearchCode & "' ) "

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtStudent.Validating, TxtRemark.Validating, TxtReligion.Validating, _
        TxtFromStreamYearSemester.Validating, TxtToStreamYearSemester.Validating, TxtRegistrationDocId.Validating, _
        TxtFamilyIncome.Validating, TxtCategory.Validating, TxtAdmissionNature.Validating, TxtScholarshipApplied.Validating, TxtAdmissionID.Validating, _
        TxtIsStreamChange.Validating, TxtCounselingFee.Validating, TxtCounselingFeeReceiptNo.Validating, TxtLibraryMemberType.Validating, TxtSessionProgrammeStream.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

                Case TxtRegistrationDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        '<Executable Code>
                        sender.AgSelectedValue = ""
                        If TxtSessionProgrammeStream.Text.Trim = "" Then
                            LblSessionProgrammeStream.Tag = ""
                            LblSessionProgrammeStreamReq.Tag = ""
                            mFirstStreamCode = ""
                            mProgrammeCode = ""
                        End If

                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtAdmissionNature.AgSelectedValue = AgL.XNull(DrTemp(0)("AdmissionNature"))
                            TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(DrTemp(0)("SessionProgrammeStream"))
                            LblSessionProgrammeStream.Tag = AgL.XNull(DrTemp(0)("SessionProgramme"))
                            TxtStudent.AgSelectedValue = AgL.XNull(DrTemp(0)("Student"))

                            LblSessionProgrammeStreamReq.Tag = Format(AgL.XNull(DrTemp(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            mFirstStreamCode = AgL.XNull(DrTemp(0)("StreamCode"))
                            mProgrammeCode = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                        End If
                    End If

                Case TxtStudent.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtFamilyIncome.Text = ""
                        TxtReligion.AgSelectedValue = ""
                        TxtCategory.AgSelectedValue = ""

                        If TxtRegistrationDocId.Text.Trim <> "" Then
                            mQry = "SELECT Sd.Student, Vs.Religion , Vs.Category, Vs.FamilyIncome " & _
                                    " FROM Sch_RegistrationStudentDetail Sd With (NoLock) " & _
                                    " LEFT JOIN ViewSch_Student Vs ON Sd.Student = Vs.SubCode " & _
                                    " WHERE Sd.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " "
                            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                            If DtTemp.Rows.Count > 0 Then
                                TxtStudent.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Student"))
                                TxtFamilyIncome.Text = Format(AgL.VNull(DtTemp.Rows(0)("FamilyIncome")), "0.00")
                                TxtReligion.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Religion"))
                                TxtCategory.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Category"))
                            End If
                        End If
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                TxtFamilyIncome.Text = Format(AgL.VNull(.Item("FamilyIncome", .CurrentCell.RowIndex).Value), "0.00")
                                TxtReligion.AgSelectedValue = AgL.XNull(.Item("Religion", .CurrentCell.RowIndex).Value)
                                TxtCategory.AgSelectedValue = AgL.XNull(.Item("Category", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If


                Case TxtFromStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblFromStreamYearSemester.Tag = ""
                        mFromSemesterSerialNo = 0
                        mFromSemesterStreamCode = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblFromStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamCode", .CurrentCell.RowIndex).Value)
                                mFromSemesterSerialNo = AgL.VNull(.Item("SemesterSerialNo", .CurrentCell.RowIndex).Value)
                                mFromSemesterStreamCode = AgL.XNull(.Item("StreamCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtToStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblToStreamYearSemester.Tag = ""
                        mToSemesterSerialNo = 0
                        mToSemesterStreamCode = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblToStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamCode", .CurrentCell.RowIndex).Value)
                                mToSemesterSerialNo = AgL.VNull(.Item("SemesterSerialNo", .CurrentCell.RowIndex).Value)
                                mToSemesterStreamCode = AgL.XNull(.Item("StreamCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtIsStreamChange.Name
                    If TxtIsStreamChange.Text.Trim = "" Then TxtIsStreamChange.Text = "No"
            End Select

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            If mFromSemesterSerialNo > mToSemesterSerialNo And mToSemesterSerialNo > 0 Then
                LblToStreamYearSemester.Tag = ""
                TxtToStreamYearSemester.AgSelectedValue = ""
                mToSemesterSerialNo = 0
                mToSemesterStreamCode = ""
            End If

            If LblToStreamYearSemester.Tag.ToString.Trim <> "" Then
                If AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                    If Not AgL.StrCmp(LblFromStreamYearSemester.Tag, LblToStreamYearSemester.Tag) And Not AgL.StrCmp(TxtIsStreamChange.Text, "Yes") Then
                        LblToStreamYearSemester.Tag = ""
                        TxtToStreamYearSemester.AgSelectedValue = ""
                        mToSemesterSerialNo = 0
                        mToSemesterStreamCode = ""
                    End If
                End If
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
            DrTemp = Nothing
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Call BlankFooterGrid()

    End Sub

    Private Function GetAdmissionID() As String
        Dim mAdmissionID$ = "", mSessionProgrammeStream$ = ""
        Try
            mQry = "SELECT Vs.SessionProgrammeStream FROM ViewSch_SessionProgrammeStream Vs WHERE Vs.Code = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "
            mSessionProgrammeStream = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            mQry = "SELECT IsNull(Max(Convert(INT,RIGHT(A.AdmissionID,5))),0) + 1 " & _
                    " FROM Sch_Admission A " & _
                    " WHERE A.Div_Code = '" & AgL.PubDivCode & "' AND A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND " & _
                    " A.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "
            mAdmissionID = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar).ToString.PadLeft(5, "0")

            mAdmissionID = AgL.PubDivCode + "/" + AgL.PubSiteCode + "/" + mSessionProgrammeStream + "/" + mAdmissionID

        Catch ex As Exception
            mAdmissionID = ""
        Finally
            GetAdmissionID = mAdmissionID
        End Try
    End Function

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = "", bStrModule$ = ""
        Dim bIsNewSemesterFeeExists As Boolean = False

        Try
            Call Calculation()

            Tc1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            'If AgL.RequiredField(TxtSessionProgrammeStream, "Program (Stream)") Then Exit Function
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Program") Then Exit Function
            If AgL.RequiredField(TxtFromStreamYearSemester, "Admission Semester") Then Exit Function
            If AgL.RequiredField(TxtStatus, "Status") Then Exit Function
            If AgL.RequiredField(TxtIsStreamChange, "Is Branch Change?") Then Exit Function
            If AgL.RequiredField(TxtIsFeeWavier, "Is Fee Wavier?") Then Exit Function
            If AgL.RequiredField(TxtIsDiplomaHolder, "Is Diploma Holder?") Then Exit Function
            'If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
            '    If AgL.RequiredField(TxtLibraryMemberType, LblLibraryMemberType.Text) Then Exit Function
            'End If



            If AgL.StrCmp(TxtFromStreamYearSemester.Text, TxtToStreamYearSemester.Text) Then
                MsgBox("""Promotion Semester"" And ""Admission Semester"" Can't Be Same!...") : TxtToStreamYearSemester.Focus() : Exit Function
            End If

            If mFromSemesterSerialNo >= mToSemesterSerialNo And mToSemesterSerialNo > 0 Then
                MsgBox("""Promotion Semester"" Serial No >= ""Admission Semester""!...") : TxtToStreamYearSemester.Focus() : Exit Function
            End If

            If LblToStreamYearSemester.Tag.ToString.Trim <> "" Then
                If Not AgL.StrCmp(TxtIsStreamChange.Text, "Yes") Then
                    If Not AgL.StrCmp(mFirstStreamCode, mToSemesterStreamCode) Then
                        MsgBox("""Promotion Semester"" Stream Is Not Same As ""Admission Semester"" Stream!...") : TxtToStreamYearSemester.Focus() : Exit Function
                    End If
                End If
            End If

            If AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") Then
                If AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid For Diploma Holder Student!...")
                    TxtSessionProgramme.Focus()
                    Exit Function
                End If
            Else
                If Not AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid!...")
                    TxtSessionProgramme.Focus()
                    Exit Function
                End If
            End If


            If AgL.RequiredField(TxtStudent, "Student") Then Exit Function
            If TxtRegistrationDocId.Text.Trim <> "" Then
                bStudentCode = AgL.XNull(AgL.Dman_Execute("SELECT Sd.Student FROM Sch_RegistrationStudentDetail Sd With (NoLock) WHERE Sd.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " ", AgL.GCn).ExecuteScalar)
                If Not AgL.StrCmp(TxtStudent.AgSelectedValue, bStudentCode) Then
                    MsgBox("" & TxtStudent.Text & " Student Is Not Valid!..." & vbCrLf & "Correct Student Is Assisgned!...")
                    TxtStudent.AgSelectedValue = bStudentCode
                End If
            End If

            mQry = "SELECT IsNull(Count(*),0) Cnt FROM ViewSch_Admission A " & _
                    " WHERE A.Student = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " " & _
                    " AND A.LeavingDate IS NULL And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.DocId <> '" & mSearchCode & "' ") & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                MsgBox("Admission Is Not Permitted!..." & vbCrLf & "Student Is Presently Studying!...")
                TxtStudent.Focus() : Exit Function
            End If

            If Val(TxtCounselingFee.Text) > 0 Then
                If AgL.RequiredField(TxtCounselingFeeReceiptNo, "Counseling Fee Receipt No.") Then Exit Function
            Else
                If TxtCounselingFeeReceiptNo.Text.Trim <> "" Then
                    MsgBox("Counseling Fee Receipt No. Is Not Required!...", MsgBoxStyle.Critical, "Validation Check")
                    TxtCounselingFeeReceiptNo.Focus() : Exit Function
                End If
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                Tc1.SelectedTab = Tp1

                If (AgL.StrCmp(mLastFromStreamYearSemesterCode_Fee, TxtFromStreamYearSemester.AgSelectedValue) = False Or _
                    AgL.StrCmp(mLastToStreamYearSemesterCode_Fee, TxtToStreamYearSemester.AgSelectedValue) = False) Then

                    MsgBox("Please Fill Fee Detail!...")
                    BtnFillFee.Focus() : Exit Function
                End If

                AgCL.AgBlankNothingCells(DGL1)
                If AgCL.AgIsBlankGrid(DGL1, Col1StreamYearSemester) Then Exit Function
                If AgCL.AgIsDuplicate(DGL1, "" & Col1StreamYearSemester & "," & Col1Fee & "") Then Exit Function

            End If


            AgCL.AgBlankNothingCells(DGL3)
            If AgCL.AgIsBlankGrid(DGL3, Col3DocumentCode) Then Tc1.SelectedTab = Tp4 : Exit Function
            If AgCL.AgIsDuplicate(DGL3, "" & Col3DocumentCode & "") Then Tc1.SelectedTab = Tp4 : Exit Function

            Tc1.SelectedTab = Tp2
            If (AgL.StrCmp(mLastFromStreamYearSemesterCode_Subject, TxtFromStreamYearSemester.AgSelectedValue) = False Or _
                AgL.StrCmp(mLastToStreamYearSemesterCode_Subject, TxtToStreamYearSemester.AgSelectedValue) = False) Then

                MsgBox("Please Fill Subject Detail!...")
                BtnFillSubject.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsBlankGrid(DGL2, Col2ManualCode) Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function
            If AgCL.AgIsDuplicate(DGL2, "" & Col2SemesterSubject & "," & Col2Subject & "") Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function

            With DGL2
                For I = 0 To DGL2.Rows.Count - 1
                    If .Item(Col2SemesterSubject, I).Value.ToString.Trim <> "" Then
                        If AgL.StrCmp(DGL2.Item(Col2IsSubjectSelected, I).Value.ToString, "No") And Val(DGL2.Item(Col2IsElectiveSubject, I).Value) = 0 Then
                            MsgBox("""" & DGL2.Item(Col2Subject, I).Value & """ Is A Compulsory Subject!...") : DGL2.CurrentCell = DGL2(Col2IsSubjectSelected, I) : DGL2.Focus() : Exit Function
                        End If
                    End If
                Next
            End With

            'If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If

                TxtAdmissionID.Text = GetAdmissionID()
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                mObjStructLibraryMember = Nothing
                If Not FunCreateLibraryMemberStructure(mObjStructLibraryMember, mBlnIsLibraryMemberExists) Then Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If
    End Sub

    Private Sub BtnFillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillFee.Click, BtnFillSubject.Click
        Try
            Select Case sender.name
                Case BtnFillFee.Name
                    Call ProcFillFee()

                Case BtnFillSubject.Name
                    Call ProcFillSubject()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillSubject()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            mLastFromStreamYearSemesterCode_Subject = TxtFromStreamYearSemester.AgSelectedValue
            mLastToStreamYearSemesterCode_Subject = TxtToStreamYearSemester.AgSelectedValue

            If AgL.RequiredField(TxtFromStreamYearSemester) Then Exit Sub


            If TxtToStreamYearSemester.Text.Trim <> "" Then
                bCondStr = " And Sem.Code = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & "  "
            Else
                bCondStr = " And Sem.Code = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & "  "
            End If

            mQry = "SELECT Ss.Code As SemesterSubject, Ss.Subject AS SubjectCode, " & _
                    " Ss.ManualCode, Ss.PaperID, Ss.IsElectiveSubject, " & _
                    " Convert(Bit,Case When Ss.IsElectiveSubject = 0 Then 1 Else 0 End) As IsSubjectSelected, " & _
                    " Ss.RowId As Sr, Null as OtherSemesterSubject, Sem.SemesterStartDate, Ss.MinCreditHours  " & _
                    " FROM Sch_SemesterSubject Ss " & _
                    " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                    " LEFT JOIN Sch_StreamYearSemester Sem ON Ss.StreamYearSemester = Sem.Code " & _
                    " Where 1=1 " & bCondStr & " " & _
                    " ORDER BY Ss.RowId, Sem.Description, S.Description "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                        DGL2.AgSelectedValue(Col2SemesterSubject, I) = AgL.XNull(.Rows(I)("SemesterSubject"))
                        DGL2.AgSelectedValue(Col2Subject, I) = AgL.XNull(.Rows(I)("SubjectCode"))
                        DGL2.Item(Col2ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                        DGL2.Item(Col2PaperID, I).Value = AgL.XNull(.Rows(I)("PaperId"))
                        DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("MinCreditHours")), "0.00")
                        DGL2.Item(Col2IsSubjectSelected, I).Value = IIf(AgL.VNull(.Rows(I)("IsSubjectSelected")), "Yes", "No")
                        DGL2.Item(Col2IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), 1, 0)
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcFillFee()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bCondStr1$ = "", bQrySem$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            mLastFromStreamYearSemesterCode_Fee = TxtFromStreamYearSemester.AgSelectedValue
            mLastToStreamYearSemesterCode_Fee = TxtToStreamYearSemester.AgSelectedValue

            If AgL.RequiredField(TxtFromStreamYearSemester, "Admission Semester") Then Exit Sub

            bCondStr = " Where 1=1 "

            If TxtToStreamYearSemester.Text.Trim <> "" Then
                bCondStr += " And Sem.Code = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ""
            Else
                bCondStr += " And Sem.Code = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ""
            End If

            mQry = "SELECT Sf.StreamYearSemester, Sf.Fee, Sf.Amount, " & _
                    " Sem.SemesterStartDate, Sem.Description StreamYearSemesterDesc, Null As FeeStreamYearSemester " & _
                    " FROM Sch_StreamYearSemesterFee Sf " & _
                    " LEFT JOIN Sch_StreamYearSemester Sem ON Sf.StreamYearSemester = Sem.Code " & _
                    " " & bCondStr & " " & _
                    " ORDER BY Sem.Description, Sf.RowId "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp

                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        DGL1.AgSelectedValue(Col1FeeStreamYearSemester, I) = AgL.XNull(.Rows(I)("FeeStreamYearSemester"))
                    Next I
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcCreateFeeDueStructure(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, ByVal bAdmissionDocId As String, ByVal bStreamYearSemester As String, _
                                                ByRef bFeeDueObj As Academic_ProjLib.ClsMain.Struct_FeeDue, ByRef bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1, ByRef bFeeDueDocId As String, _
                                                Optional ByVal bIsNewStatus_FeeDue As Boolean = False)

        Dim I As Integer, J As Integer, mFlagBln As Boolean = False
        Dim bSite_Code$ = "", bDiv_Code$ = "", bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bV_Date$ = "", bSearchCode$ = ""
        Dim bDtTable As DataTable
        Dim bQry$ = ""
        Dim bTotalAmount As Double = 0

        If bIsNewStatus_FeeDue = False Then
            bQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student , Adm.AdmissionID , " & _
                    " Adm.V_Date, AdmFee.*, Fd1.Code As FeeDueCode " & _
                    " FROM Sch_Admission Adm WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee " & _
                    " Where Adm.DocId = '" & bAdmissionDocId & "' And AdmFee.StreamYearSemester = '" & bStreamYearSemester & "' "
        Else
            bQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student , Adm.AdmissionID , " & _
                    " " & AgL.ConvertDate(bFeeDueObj.V_Date) & " As V_Date, AdmFee.*, Null As FeeDueCode " & _
                    " FROM Sch_Admission Adm WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId " & _
                    " Where Adm.DocId = '" & bAdmissionDocId & "' And AdmFee.StreamYearSemester = '" & bStreamYearSemester & "' "
        End If
        bDtTable = AgL.FillData(bQry, bConnRead).Tables(0)


        With bDtTable
            If .Rows.Count > 0 Then
                bSite_Code = AgL.XNull(.Rows(0)("Site_Code"))
                bDiv_Code = AgL.XNull(.Rows(0)("Div_Code"))
                bV_Date = Format(AgL.XNull(.Rows(0)("V_Date")), "Short Date")

                If (bEntryMode = "Add" And bV_Date.Trim <> "" And bSite_Code.Trim <> "") Or bIsNewStatus_FeeDue Then
                    bQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                            " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeDue & "' "
                    bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)

                    bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
                    If bIsNewStatus_FeeDue Then
                        bFeeDueDocId = bSearchCode
                    Else
                        mFeeDueDocId = bSearchCode
                    End If

                Else
                    If Not bIsNewStatus_FeeDue Then bSearchCode = mFeeDueDocId
                    bV_Type = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherType)
                End If


                If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Fee Due Search Code Generation!...")

                bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                J = 0
                For I = 0 To .Rows.Count - 1
                    If AgL.VNull(.Rows(I)("Amount")) > 0 Then
                        If mFlagBln = False Then
                            J = 0
                            mFlagBln = True
                        Else
                            J = UBound(bFeeDue1Obj) + 1
                        End If
                        ReDim Preserve bFeeDue1Obj(J)

                        bFeeDue1Obj(J).Code = AgL.XNull(.Rows(I)("FeeDueCode"))
                        bFeeDue1Obj(J).DocId = bSearchCode
                        bFeeDue1Obj(J).AdmissionDocId = bAdmissionDocId
                        bFeeDue1Obj(J).Fee = AgL.XNull(.Rows(I)("Fee"))
                        bFeeDue1Obj(J).Amount = AgL.VNull(.Rows(I)("Amount"))

                        bTotalAmount += AgL.VNull(.Rows(I)("Amount"))
                    End If
                Next

                If J = 0 And mFlagBln = False Then
                    ReDim Preserve bFeeDue1Obj(J)

                    bFeeDue1Obj(J).Code = ""
                    bFeeDue1Obj(J).DocId = bSearchCode
                    bFeeDue1Obj(J).AdmissionDocId = bAdmissionDocId
                    bFeeDue1Obj(J).Fee = ""
                    bFeeDue1Obj(J).Amount = 0

                End If

                bFeeDueObj.DocId = bSearchCode
                bFeeDueObj.Div_Code = bDiv_Code
                bFeeDueObj.Site_Code = bSite_Code
                bFeeDueObj.V_Type = bV_Type
                bFeeDueObj.V_Prefix = bV_Prefix
                bFeeDueObj.V_No = bV_No
                bFeeDueObj.V_Date = bV_Date
                bFeeDueObj.Remark = ""
                bFeeDueObj.TotalAmount = bTotalAmount
                bFeeDueObj.StreamYearSemester = bStreamYearSemester
            End If
        End With
    End Sub

    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Dim mApprovedDate$ = ""

        Select Case sender.name
            Case BtnApproved.Name
                Try
                    If Topctrl1.Mode = "Browse" Then
                        If MsgBox("Are You Sure To Approve Record", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Approved Confirmation...") = MsgBoxResult.No Then Exit Sub

                        If mSearchCode <> "" Then
                            ''=======================Approval Start======================================

                            TxtApproved.Text = AgL.PubUserName
                            mApprovedDate = AgL.GetDateTime(AgL.GCn)

                            AgL.ECmd = AgL.GCn.CreateCommand
                            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                            AgL.ECmd.Transaction = AgL.ETrans
                            mTrans = True


                            Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate, False)

                            ''===========================================================================

                            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                            AgL.ETrans.Commit()
                            mTrans = False

                            MsgBox("Voucher Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                            If AgL.PubMoveRecApplicable Then
                                FIniMaster(0, 1) : Topctrl_tbRef()
                            End If
                            MoveRec()
                        End If
                    End If
                Catch ex As Exception
                    If mTrans = True Then AgL.ETrans.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                End Try
        End Select
    End Sub

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String, ByVal BlnIsAutoApproved As Boolean)

        mQry = "Update Sch_Admission Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & ", IsAutoApproved = " & IIf(BlnIsAutoApproved, 1, 0) & " Where DocId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        Call ProcSaveFeeDueDetail(Not BlnIsAutoApproved)

        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub

    Private Function FunCreateLibraryMemberStructure(ByRef ObjStructLibraryMember As ClsMain.StructLibraryMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructLibraryMember = New ClsMain.StructLibraryMember()
            ObjStructLibraryMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
            Else
                mQry = "SELECT M.* FROM Lib_Member M WHERE M.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructLibraryMember
                .StrSubCode = TxtStudent.AgSelectedValue
                .StrStuent = TxtStudent.AgSelectedValue
                .StrEmployee = ""
                .StrMemberType = TxtLibraryMemberType.AgSelectedValue
                .StrAdmissionNo = TxtAdmissionID.Text

                DrTemp = TxtStudent.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    .StrMotherName = AgL.XNull(DrTemp(0)("MotherName"))
                    .StrManualCode = AgL.XNull(DrTemp(0)("ManualCode"))
                End If

                DrTemp = TxtSessionProgramme.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    .StrClass = AgL.XNull(DrTemp(0)("ProgrammeManualCode"))
                    .StrSession = AgL.XNull(DrTemp(0)("SessionManualCode"))
                End If

                If BlnIsMemberExists Then
                    .StrUID = AgL.XNull(bDtMember.Rows(0)("UID").ToString)

                    If Not (AgL.StrCmp(.StrClass, AgL.XNull(bDtMember.Rows(0)("Class"))) _
                        And AgL.StrCmp(.StrSession, AgL.XNull(bDtMember.Rows(0)("Session")))) _
                        Or AgL.XNull(bDtMember.Rows(0)("MemberCardNo")).ToString.Trim = "" Then

                        .StrMemberCardNo = FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                    Else
                        .StrMemberCardNo = AgL.XNull(bDtMember.Rows(0)("MemberCardNo"))
                    End If
                Else
                    .StrMemberCardNo = FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateLibraryMemberStructure = bBlnRerurn
        End Try
    End Function

    Private Function FunGetMemberCardNo(ByVal StrClass As String, ByVal StrSession As String, ByVal StrManualCode As String) As String
        Dim bStrReturn$ = "", bCondStr$ = " Where 1=1 "
        Dim bLongMaxId As Long = 0

        Try
            If StrClass.Trim <> "" Then
                bCondStr += " And M.Class = " & AgL.Chk_Text(StrClass) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrClass, "-" + StrClass)
            End If

            If StrSession.Trim <> "" Then
                bCondStr += " And M.Session = " & AgL.Chk_Text(StrSession) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrSession, "-" + StrSession)
            End If


            mQry = "SELECT IsNull(Max(M.CardSrNo),0) AS MaxId " & _
                    " FROM Lib_Member M " & bCondStr

            bLongMaxId = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) + 1

            bStrReturn += IIf(bStrReturn.Trim = "", bLongMaxId.ToString, "-" + bLongMaxId.ToString)

            If StrManualCode.Trim <> "" Then
                bStrReturn += IIf(bStrReturn.Trim = "", StrManualCode, "-" + StrManualCode)
            End If

        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetMemberCardNo = bStrReturn
        End Try
    End Function

    Private Function FunGetModuleName() As String
        Dim bStrReturn$ = ""
        Try
            If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
                bStrReturn = ClsMain.ModuleName
            ElseIf Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                bStrReturn = ClsMain.FeeModuleName
            Else
                bStrReturn = ""
            End If
        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetModuleName = bStrReturn
        End Try
    End Function
End Class
