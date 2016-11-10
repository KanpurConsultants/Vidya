Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmFeeReceiveEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mRegistrationDocId$ = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mStrNCatList$ = ""
    Dim mRefundAmount As Double = 0, mAdvanceBroughtForward As Double = 0

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1MonthYear As Byte = 1
    Private Const Col1FeeCode As Byte = 2
    Private Const Col1FeeDue1 As Byte = 3
    Private Const Col1Amount As Byte = 4
    Private Const Col1Discount As Byte = 5
    Private Const Col1NetAmount As Byte = 6
    Private Const Col1TempAmount As Byte = 7
    Private Const Col1IsFeeDueReversePosted As Byte = 8
    Private Const Col1Code As Byte = 9
    Private Const Col1FeeNature As Byte = 10
    Private Const Col1TempFeeDue1 As Byte = 11
    Private Const Col1ArrayIndex As Byte = 12

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2AdvanceDocId As Byte = 1
    Private Const Col2AdvanceVDate As Byte = 2
    Private Const Col2AdvanceReceive As Byte = 3
    Private Const Col2AdjustYesNo As Byte = 4

    'Code By Akash On date 24-01-11
    Public WithEvents DGLAccounts As New AgControls.AgDataGrid
    '=============== <Column Index> ========================
    Private Const DACC_Account As Byte = 0
    Private Const DACC_Description As Byte = 1

    '=============== <Row Index> ===========================
    Private Const DACR_RegFeeAdjustmentAc As Byte = 0
    Private Const DACR_FeeReceiptAdjustmentAc As Byte = 1
    Private Const DACR_ScholarshipAdjustmentAc As Byte = 2
    Private Const DACR_CounselingFeeAdjustmentAc As Byte = 3
    'End Code

    Public WithEvents DGLFooter1 As New AgControls.AgDataGrid
    '=============== <Column Index> ========================
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Percentage As Byte = 1
    Private Const DFC_Amount As Byte = 2

    '=============== <Row Index> ===========================
    Private Const DF1R_TotalLineAmount As Byte = 0
    Private Const DF1R_TotalLineDiscount As Byte = 1
    Private Const DF1R_TotalLineNetAmount As Byte = 2


    Public WithEvents DGLFooter2 As New AgControls.AgDataGrid

    '=============== <Row Index> ===========================
    Private Const DF2R_TotalAdvanceAdjusted As Byte = 0
    Private Const DF2R_Advance As Byte = 1
    Private Const DF2R_SubTotal1 As Byte = 2
    Private Const DF2R_CounselingFeeAdjusted As Byte = 3
    Private Const DF2R_AdjustmentAmount As Byte = 4
    Private Const DF2R_TotalFeeReceiveAdjusted As Byte = 5
    Private Const DF2R_ScholarshipAdjusted As Byte = 6
    Private Const DF2R_SubTotal2 As Byte = 7
    Private Const DF2R_Discount As Byte = 8
    Private Const DF2R_TotalNetAmount As Byte = 9
    Private Const DF2R_AdvanceCarriedForward As Byte = 10

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing
    Dim mObjFrmPaymentDetail As AgLibrary.FrmPaymentDetail = Nothing
    '=============== <Form Type Index> ===========================
    'Private FormType As Byte
    'Private Const FeeReceiveEntry As Byte = 0
    'Private Const FeeReceiveAdjustmentEntry As Byte = 1

    Dim _AdmissionDocId$ = ""
    Dim _DueInstallmentUId$ = ""
    Dim _DueInstallmentSr% = 0
    Dim _InstallmentAmount As Double = 0

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Dim mStrFeeDueDocID As String = "", mStrFeeDuePrefix = ""
    Dim mLongFeeDueVrNo As Long = 0

    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property

    Public Property AdmissionDocId() As String
        Get
            AdmissionDocId = _AdmissionDocId
        End Get
        Set(ByVal value As String)
            _AdmissionDocId = value
        End Set
    End Property


    Public Property DueInstallmentUId() As String
        Get
            DueInstallmentUId = _DueInstallmentUId
        End Get
        Set(ByVal value As String)
            _DueInstallmentUId = value
        End Set
    End Property

    Public Property DueInstallmentSr() As Integer
        Get
            DueInstallmentSr = _DueInstallmentSr
        End Get
        Set(ByVal value As Integer)
            _DueInstallmentSr = value
        End Set
    End Property

    Public Property InstallmentAmount() As Double
        Get
            InstallmentAmount = _InstallmentAmount
        End Get
        Set(ByVal value As Double)
            _InstallmentAmount = value
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
        ''================< Fee Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1MonthYear", 90, 8, "Month/Year", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeCode", 160, 8, "Fee Head", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeDue1", 250, 8, "Fee Due1", False, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Fee Amount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Discount", 70, 8, 2, False, "Discount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 100, 8, 2, False, "Net Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1TempAmount", 100, 8, 2, False, "Fee Amount (Temp)", False, True, True)
            .AddAgTextColumn(DGL1, "Is Fee Due Reverse Posted", 100, 3, "Is Fee Due Reverse Posted", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 30, 10, "Code", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeNature", 250, 8, "Fee Nature", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1TempFeeDue1", 250, 8, "Temp Fee Due1", False, True, False)
            .AddAgNumberColumn(DGL1, "DGL1ArrayIndex", 50, 8, 0, True, "ArrayIndex", False, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.AgSkipReadOnlyColumns = True
        ''==============================================================================
        ''================< Advance Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "Dgl2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2AdvanceDocId", 150, 8, "Voucher No", True, True, False)
            .AddAgDateColumn(DGL2, "Dgl2AdvanceVDate", 80, "Voucher Date", True, True, False)
            .AddAgNumberColumn(DGL2, "Dgl2AdvanceReceive", 100, 8, 2, False, "Advance", True, True, True)
            .AddAgCheckBoxColumn(DGL2, "Dgl2AdjustYesNo", 60, "Adjust (Yes/No)", True, False, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False
        DGL2.AgSkipReadOnlyColumns = True

        'Code By Akash On Date 24-01-11
        ''==============================================================================
        ''================< A/C Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLAccounts, "DACCAccount", 195, 5, " ", True, True, False)
            .AddAgTextColumn(DGLAccounts, "DACCDescription", 230, 5, "A/c Head", True, False, False)
        End With
        AgL.AddAgDataGrid(DGLAccounts, Pnl4)
        DGLAccounts.RowCount = 5
        DGLAccounts.AllowUserToAddRows = False
        DGLAccounts.Item(DACC_Account, DACR_RegFeeAdjustmentAc).Value = "Reg. Fee Adjustment A/C".ToUpper
        DGLAccounts.Item(DACC_Account, DACR_FeeReceiptAdjustmentAc).Value = "Fee Receipt Adjustment A/C".ToUpper
        DGLAccounts.Item(DACC_Account, DACR_ScholarshipAdjustmentAc).Value = "Scholarship Adjustment A/C".ToUpper
        'DGLAccounts.Item(DACC_Account, DACR_CounselingFeeAdjustmentAc).Value = "Counseling Adjustment A/C".ToUpper
        DGLAccounts.AgSkipReadOnlyColumns = True
        DGLAccounts.Rows(1).Visible = False

        'End Code
        ''==============================================================================
        ''================< Footer Data Grid-1 >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter1, "DGLF1Description", 195, 5, "Description", True, True, False)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Percentage", 40, 2, 2, False, " % ", False, True, True)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Amount", 100, 8, 2, False, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter1, PnlFooter1)
        DGLFooter1.RowCount = 4
        DGLFooter1.AllowUserToAddRows = False
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineAmount).Value = "Fee Amount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineDiscount).Value = "(-) Fee Discount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineNetAmount).Value = "Net Fee".ToUpper
        DGLFooter1.AgSkipReadOnlyColumns = True
        ''==============================================================================
        ''================< Footer Data Grid-2 >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter2, "DGLF2Description", 175, 5, "Description", True, True, False)
            .AddAgNumberColumn(DGLFooter2, "DGLF2Percentage", 40, 2, 2, False, " % ", True, True, True)
            .AddAgNumberColumn(DGLFooter2, "DGLF2Amount", 80, 8, 2, False, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter2, PnlFooter2)
        DGLFooter2.RowCount = 12
        DGLFooter2.AgSkipReadOnlyColumns = True
        DGLFooter2.AllowUserToAddRows = False
        DGLFooter2.Item(DFC_Description, DF2R_TotalAdvanceAdjusted).Value = "(-) Advance Adjusted ".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_Advance).Value = "(-) Advance B/F ".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_SubTotal1).Value = "Sub Total-1".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_CounselingFeeAdjusted).Value = "(-) Counseling Fee Adj.".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_AdjustmentAmount).Value = "(-) Reg. Fee Adjustment".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_TotalFeeReceiveAdjusted).Value = "(-) Receive Adjustment".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_ScholarshipAdjusted).Value = "(-) Scholarship Adjustment".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_SubTotal2).Value = "Sub Total-2".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_Discount).Value = "(-) Discount".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_TotalNetAmount).Value = "Net Amount".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_AdvanceCarriedForward).Value = "Advance C/F".ToUpper


        DGLFooter2.Rows(DF2R_TotalAdvanceAdjusted).Visible = False
        DGLFooter2.Rows(DF2R_CounselingFeeAdjusted).Visible = False
        DGLFooter2.Rows(DF2R_TotalFeeReceiveAdjusted).Visible = False
        'DGLFooter2.Rows(DF2R_ScholarshipAdjusted).Visible = False

        DGLFooter2.CurrentCell = DGLFooter2(DFC_Percentage, DF2R_Discount)
        DGLFooter2.CurrentCell.Style.BackColor = Color.White
        DGLFooter2.CurrentCell.Style.ForeColor = Color.Black

        DGLFooter2.CurrentCell = DGLFooter2(DFC_Amount, DF2R_Discount)
        DGLFooter2.CurrentCell.Style.BackColor = Color.White
        DGLFooter2.CurrentCell.Style.ForeColor = Color.Black
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

            If e.KeyCode <> Keys.Return And Me.ActiveControl.Name = TxtReceiveAmount.Name Then
                If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) And LblV_Type.Tag.ToString.Trim <> "" Then
                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                    AgL.PubObjFrmPaymentDetail.ShowDialog()
                    PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                    TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                    If Val(TxtReceiveAmount.Text) <> Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                        MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """")
                    End If

                    Call Calculation()
                    AgL.PubObjFrmPaymentDetail = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mStrNCatList = " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & ", " & _
                              " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment) & ", " & _
                              " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) & " "

            AgL.WinSetting(Me, 690, 950, _FormLocation.Y, _FormLocation.X)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGLFooter1)
            AgL.GridDesign(DGLFooter2)
            AgL.GridDesign(DGLAccounts)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGLFooter1, False)
            Topctrl1.ChangeAgGridState(DGLFooter2, False)
            Topctrl1.ChangeAgGridState(DGLAccounts, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()

            If AgL.StrCmp(_EntryMode, "Add") Then
                Topctrl1.FButtonClick(0)
            Else
                MoveRec()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Fr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat In (" & mStrNCatList & ") "


            mQry = "Select Fr.DocId As SearchCode " & _
                    " From Sch_FeeReceive Fr " & _
                    " LEFT JOIN Voucher_Type Vt ON Fr.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Dim MDI As New MDIMain

        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat In (" & mStrNCatList & ")" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.Student As StudentCode,V1.CurrentSemester,S.Description as Class " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Left Join Sch_streamYearSemester S on V1.CurrentSemester=S.Code " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Fd1.Code, SgF.Name AS [Fee Name], Fd.V_Date AS [Due Date], Fd1.Amount, Fd1.AdmissionDocId, Fd1.Fee AS FeeCode " & _
                    " FROM Sch_FeeDue1 Fd1 " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd1.DocId = Fd.DocId " & _
                    " LEFT JOIN SubGroup SgF ON Fd1.Fee = SgF.SubCode " & _
                    " Where Fd.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " " & AgL.PubSiteCondition("Fd.Site_Code", AgL.PubSiteCode) & " "
            DGL1.AgHelpDataSet(Col1FeeDue1, 3) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT ARec.DocId Code, " & AgL.V_No_Field("ARec.DocId") & " As [Voucher No], " & _
                    " ARec.V_Date , ARec.ReceiveAmount " & _
                    " FROM ViewSch_AdvanceReceive ARec " & _
                    " Where ARec.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " " & AgL.PubSiteCondition("ARec.Site_Code", AgL.PubSiteCode) & " "
            DGL2.AgHelpDataSet(Col2AdvanceDocId, 2) = AgL.FillData(mQry, AgL.GCn)

            'Code By Akash On Date 24-01-11
            mQry = "SELECT Sg.SubCode Code, Sg.Name " & _
                " FROM SubGroup Sg " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
            DGLAccounts.AgHelpDataSet(DACC_Description, 0, Tc1.Top + Tp3.Top, Tc1.Left + Tp3.Left) = AgL.FillData(mQry, AgL.GCn)
            'End Code

            mQry = "Select F.Code, F.Name as [Fee], F.ManualCode,F.FeeNature " & _
                " From ViewSch_Fee F " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                " Order By F.Name "
            DGL1.AgHelpDataSet(Col1FeeCode, 2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code  As Code, Code As Name From Sch_FeeNature " & _
             "  Order By Code"
            DGL1.AgHelpDataSet(Col1FeeNature) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.Description AS ClassSection, S.Semester, S.Section,C.SerialNo  " & _
               " FROM Sch_StreamYearSemester S WITH (NoLock) " & _
               " LEFT JOIN Sch_Semester C WITH (NoLock) ON C.Code = S.Semester " & _
               " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
               " Order By C.SerialNo "
            TxtClass.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

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
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceivePaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceiveAdvance Where FeeReceiveDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    'AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceiveAdjustableFeeReceive Where FeeReceiveDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceiveRegistration Where FeeReceiveDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceive1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReceive Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


                    If mStrFeeDueDocID.Trim <> "" Then
                        ''*******************
                        AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & mStrFeeDueDocID & "'", AgL.GCn, AgL.ECmd)
                        AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mStrFeeDueDocID)

                        AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue1 Where DocId = '" & mStrFeeDueDocID & "'", AgL.GCn, AgL.ECmd)
                        AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue Where DocId = '" & mStrFeeDueDocID & "'", AgL.GCn, AgL.ECmd)
                        ''************************
                    End If

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

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
        Dim CancelAmt As Double = 0.0
        Dim ReceiveAmt As Double = 0.0
        Dim AdjustAmt As Double = 0.0

        DispText(True)

        Call ProcAssignAccount()

        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Fr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & "  " & _
                            " And Vt.NCat In (" & mStrNCatList & ") "

            AgL.PubFindQry = "SELECT Fr.DocId As SearchCode, " & AgL.V_No_Field("Fr.DocId") & " As [Voucher No], Fr.ReferenceNo As [" & LblRefNo.Text & "], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], Fr.V_Date,SYSem.Description as Class, Fr.ReceiveAmount AS [Receive Amount], " & _
                                " VAdm.StudentName as [Student], VAdm.AdmissionID, Fr.Remark, Case When IsNull(IsAdjustableReceipt,0) <> 0 Then 'Yes' Else 'No' End As [Is Adjustable Receipt], " & _
                                " Fr.TotalAdvanceAdjusted, Fr.AdjustmentAmount as [Reg. Fee Adjusted], Fr.TotalFeeReceiveAdjusted  as [Fee Receipt Adjusted]" & _
                                " FROM dbo.Sch_FeeReceive Fr " & _
                                " LEFT JOIN Sch_StreamYearSemester SYSem ON sysem.Code =Fr.StreamYearSemester  " & _
                                " LEFT JOIN Voucher_Type Vt ON Fr.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON Fr.Site_Code = S.Code " & _
                                " Left Join ViewSch_Admission VAdm On Fr.AdmissionDocId = VAdm.DocId " & mCondStr

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
        Dim bReceiptType As String = ""
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try

            If MsgBox("Print Summary?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                bReceiptType = "Summary"
            Else
                bReceiptType = "Detail"
            End If
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Fee Receipt"
            RepName = "Academic_Main_FeeReceipt" : RepTitle = "Fee Receipt"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT FR.DocId, " & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.TotalLineAmount,FR.TotalLineDiscount,FR.TotalLineNetAmount,FR.Advance,FR.SubTotal1,FR.AdjustmentAmount,FR.SubTotal2,FR.DiscountPer,FR.DiscountAmount,FR.TotalNetAmount,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.RowId,FR.UpLoadDate,FR.IsManageFee,FR.ReceiveAmount,FR.AdvanceCarriedForward,FR.AdmissionDocId,  " & _
                    " FR1.Code AS Line_Code,FR1.FeeDue1 AS Line_FeeDue,FR1.Amount AS Line_Amount,FR1.Discount AS Line_Discount,FR1.NetAmount AS Line_NetAmount, FD1.DocId AS DocID_FeeDue, FD.V_Date as FeeDue_V_Date, FD1.Fee, F.Name AS Fee_Description, FD1.Amount AS AmountDue, SYSem.Description as StreamYearSemesterDesc, " & _
                    " Adm.DocId, Adm.RegistrationDocId, Adm.AdmissionID, Stu.name As Student_Name, stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.RollNo as EnrollmentNo , " & _
                    " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                    " PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3, " & _
                    " Fr.TotalFeeReceiveAdjusted, Fr.TotalAdvanceAdjusted, S.Photo As SitePhoto,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName," & AgL.Chk_Text(bReceiptType) & " AS ReceiptType, Fr1.MonthStartDate, Stu.DispName AS StudentDispName, Stu.ManualCode AS StudentManualCode, S.Photo " & _
                    " FROM (Select * From dbo.ViewSch_FeeReceive Where DocId = '" & mDocId & "' ) FR " & _
                    " LEFT Join dbo.Sch_FeeReceive1 FR1 ON FR.DocId =FR1.DocId  " & _
                    " Left Join SiteMast S On FR.Site_Code =  S.Code " & _
                    " LEFT JOIN dbo.Sch_FeeDue1 FD1 ON FR1.FeeDue1 =FD1.Code  " & _
                    " LEFT JOIN dbo.Sch_FeeDue FD ON FD1.DocId  =FD.DocId  " & _
                    " LEFT JOIN ViewSch_Fee F ON FD1.Fee =F.Code  " & _
                    " LEFT JOIN Sch_StreamYearSemester SYSem ON sysem.Code =Fr.StreamYearSemester  " & _
                    " LEFT JOIN dbo.PaymentDetail PD ON Fr.DocId =PD.DocId  " & _
                    " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
                    " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  " & _
                    " Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
                    " Left Join Bank b2 on pd.bank_code2=b2.bank_code  " & _
                    " Left Join Bank b3 on pd.bank_code3=b3.bank_code  " & _
                    " LEFT JOIN SubGroup SGT ON SGT.SubCode=PD.AcTransferBankAc " & _
                    " LEFT JOIN bank BT ON BT.Bank_Code=PD.AcTransferBank_Code "




            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)

            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, PLib.PubReportPath_Academic_Main)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim J As Integer = 0
        Dim I As Integer, bSr As Integer = 0, K = 0, X = 0
        Dim mTrans As Boolean = False, bBlnExitFlag As Boolean = False, mFlagBln As Boolean = False
        Dim bFeeReceive1Code$ = "", bStrFeeDue1Code$ = ""
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim mTotalLateFeeAmt As Double = 0
        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            'IsAdjustableReceipt, TotalFeeReceiveAdjusted
            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Sch_FeeReceive ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " TotalLineAmount, TotalLineDiscount, TotalLineNetAmount, Advance, SubTotal1, AdjustmentAmount, " & _
                        " SubTotal2, DiscountPer, DiscountAmount, TotalNetAmount, IsManageFee, ReceiveAmount, " & _
                        " AdvanceCarriedForward, AdmissionDocId, Remark, TotalAdvanceAdjusted, " & _
                        " IsAdjustableReceipt, TotalFeeReceiveAdjusted, ScholarShipAmount, " & _
                        " PreparedBy, U_EntDt, U_AE, FeeAdjustmentAc, FeeReceiptAdjustmentAc, ScholarshipAdjustmentAc, CounselingFeeAdjusted, CounselingFeeAdjustmentAc,ReferenceNo,ManualCodePrefix,ManualCodeSr ,StreamYearSemester) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value) & ", " & Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsManageFee.Text, "Yes"), 1, 0) & ", " & Val(TxtReceiveAmount.Text) + Val(TxtOpeningAdvance.Text) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsAdjustableReceipt.Text, "Yes"), 1, 0) & ", " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' , " & _
                        " " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc)) & ", " & _
                        " " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_FeeReceiptAdjustmentAc)) & ", " & _
                        " " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc)) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value) & ", " & _
                        " " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc)) & " ," & AgL.Chk_Text(TxtRefNo.Text) & "," & AgL.Chk_Text(LblManualPrefix.Text) & "," & AgL.VNull(TxtManualCodeSr.Text) & ", " & AgL.Chk_Text(TxtClass.AgSelectedValue) & "" & _
                        " )"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                If Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) > 0 Then
                    mQry = "INSERT INTO Sch_FeeReceiveRegistration ( FeeReceiveDocId, RegistrationDocId, Remark ) " & _
                            " VALUES ( '" & mSearchCode & "', " & AgL.Chk_Text(mRegistrationDocId) & ", NULL )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

            Else
                mQry = "Update Sch_FeeReceive " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " TotalLineAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " TotalLineDiscount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) & ", " & _
                        " TotalLineNetAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & _
                        " TotalAdvanceAdjusted = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) & ", " & _
                        " Advance = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) & ", " & _
                        " SubTotal1 = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) & ", " & _
                        " AdjustmentAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) & ", " & _
                        " SubTotal2 = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value) & ", " & _
                        " DiscountPer = " & Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) & ", " & _
                        " DiscountAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value) & ", " & _
                        " TotalNetAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " IsManageFee = " & IIf(AgL.StrCmp(TxtIsManageFee.Text, "Yes"), 1, 0) & ", " & _
                        " ReceiveAmount = " & Val(TxtReceiveAmount.Text) + Val(TxtOpeningAdvance.Text) & ", " & _
                        " AdvanceCarriedForward = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value) & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " IsAdjustableReceipt = " & IIf(AgL.StrCmp(TxtIsAdjustableReceipt.Text, "Yes"), 1, 0) & ", " & _
                        " TotalFeeReceiveAdjusted = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value) & ", " & _
                        " ScholarShipAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value) & ", " & _
                        " CounselingFeeAdjusted = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value) & ", " & _
                        " CounselingFeeAdjustmentAc = " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc)) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "', " & _
                        " FeeAdjustmentAc = " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc)) & ", " & _
                        " FeeReceiptAdjustmentAc = " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_FeeReceiptAdjustmentAc)) & ", " & _
                        " ScholarshipAdjustmentAc = " & AgL.Chk_Text(DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc)) & " ,ReferenceNo=" & AgL.Chk_Text(TxtRefNo.Text) & ", " & _
                        " ManualCodePrefix=" & AgL.Chk_Text(LblManualPrefix.Text) & ", " & _
                        " ManualCodeSr=" & AgL.VNull(TxtManualCodeSr.Text) & " " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            ''***********Fee Due***********
            'With DGL1
            '    For X = 0 To .Rows.Count - 1
            '        If AgL.XNull(.AgSelectedValue(Col1FeeNature, X)) = "Late Fee" And AgL.VNull(.Item(Col1Amount, X).Value) > 0 Then
            '        End If
            '    Next
            'End With

            mTotalLateFeeAmt = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If AgL.XNull(.AgSelectedValue(Col1FeeNature, I)) = "Late Fee" _
                        And AgL.XNull(.AgSelectedValue(Col1FeeDue1, I)).ToString.Trim = "" _
                        And AgL.VNull(.Item(Col1Amount, I).Value) > 0 Then

                        If mFlagBln = False Then
                            J = 0
                            mFlagBln = True
                        Else
                            J = UBound(bFeeDue1Obj) + 1
                        End If

                        ReDim Preserve bFeeDue1Obj(J)
                        bFeeDue1Obj(J).FeeDue1()

                        If Topctrl1.Mode = "Add" Then
                            bFeeDue1Obj(J).Code = ""
                        Else
                            bFeeDue1Obj(J).Code = .AgSelectedValue(Col1FeeDue1, I)
                        End If

                        bFeeDue1Obj(J).TempCode = ""
                        bFeeDue1Obj(J).DocId = mStrFeeDueDocID
                        bFeeDue1Obj(J).AdmissionDocId = TxtAdmissionDocId.AgSelectedValue
                        bFeeDue1Obj(J).Fee = .AgSelectedValue(Col1FeeCode, I)
                        bFeeDue1Obj(J).IsReversePostable = AgL.StrCmp(.Item(Col1IsFeeDueReversePosted, I).Value, "Yes")
                        bFeeDue1Obj(J).Amount = Val(.Item(Col1Amount, I).Value)
                        bFeeDue1Obj(J).MonthStartDate = CDate(AgL.XNull(.Item(Col1MonthYear, I).Value)).ToString("01/MMM/yyyy")
                        mTotalLateFeeAmt = mTotalLateFeeAmt + Val(.Item(Col1Amount, I).Value)
                        DGL1.Item(Col1ArrayIndex, I).Value = J
                    End If
                Next
            End With

            If mTotalLateFeeAmt > 0 Then
                With bFeeDueObj
                    .DocId = mStrFeeDueDocID
                    .Div_Code = AgL.PubDivCode
                    .Site_Code = TxtSite_Code.AgSelectedValue
                    .V_Type = Academic_ProjLib.ClsMain.NCat_FeeDue
                    .V_Prefix = mStrFeeDuePrefix
                    .V_No = mLongFeeDueVrNo
                    .V_Date = TxtV_Date.Text
                    .Remark = ""
                    .TotalAmount = Val(mTotalLateFeeAmt)
                    .StreamYearSemester = TxtClass.AgSelectedValue
                    .StreamYearSemesterDesc = TxtClass.Text
                End With

                Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeDueObj, bFeeDue1Obj)
                Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeDueObj, False)

                Call AgL.UpdateVoucherCounter(mStrFeeDueDocID, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

                If Topctrl1.Mode = "Add" Then
                    ''*****************************
                    mQry = "Update Sch_FeeReceive " & _
                               " SET  " & _
                               " FeeDueDocId = " & AgL.Chk_Text(mStrFeeDueDocID) & " " & _
                               " WHERE DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    '************************************
                Else
                    ''*****************************
                    mQry = "Update Sch_FeeReceive " & _
                               " SET  " & _
                               " FeeDueDocId = Null " & _
                               " WHERE DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    '************************************
                End If
            End If


            I = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    bStrFeeDue1Code = ""

                    If Val(.Item(Col1ArrayIndex, I).Value) >= 0 Then
                        .Item(Col1TempFeeDue1, I).Value = bFeeDue1Obj(Val(.Item(Col1ArrayIndex, I).Value)).TempCode                    
                    End If

                    If AgL.XNull(.AgSelectedValue(Col1FeeDue1, I)).ToString.Trim <> "" Then
                        bStrFeeDue1Code = .AgSelectedValue(Col1FeeDue1, I)
                    Else
                        bStrFeeDue1Code = .Item(Col1TempFeeDue1, I).Value
                    End If

                    If .Item(Col1Code, I).Value = "" Then
                        If .Item(Col1FeeCode, I).Value <> "" And Val(.Item(Col1Amount, I).Value) > 0 Then
                            bFeeReceive1Code = AgL.GetMaxId("Sch_FeeReceive1", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Sch_FeeReceive1 ( " & _
                                    " Code, DocId, FeeDue1, Amount, Discount, NetAmount	,MonthStartDate) " & _
                                    " VALUES ( " & _
                                    " '" & bFeeReceive1Code & "', '" & mSearchCode & "', " & AgL.Chk_Text(bStrFeeDue1Code) & ", " & _
                                    " " & Val(.Item(Col1Amount, I).Value) & ", " & Val(.Item(Col1Discount, I).Value) & ", " & Val(.Item(Col1NetAmount, I).Value) & " , '" & CDate(AgL.XNull(.Item(Col1MonthYear, I).Value)).ToString("01/MMM/yyyy") & "')"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1FeeCode, I).Value <> "" Then


                            mQry = "UPDATE Sch_FeeReceive1 SET " & _
                                    " FeeDue1 = " & AgL.Chk_Text(bStrFeeDue1Code) & ", " & _
                                    " Amount = " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                    " Discount = " & Val(.Item(Col1Discount, I).Value) & ", " & _
                                    " MonthStartDate = '" & CDate(AgL.XNull(.Item(Col1MonthYear, I).Value)).ToString("01/MMM/yyyy") & "', " & _
                                    " NetAmount = " & Val(.Item(Col1NetAmount, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Sch_FeeReceive1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_FeeReceiveAdvance Where FeeReceiveDocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL2
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2AdvanceDocId, I).Value <> "" And CBool(.Item(Col2AdjustYesNo, I).Value) Then
                        bSr += 1

                        mQry = "INSERT INTO Sch_FeeReceiveAdvance ( " & _
                                " FeeReceiveDocId, Sr, AdvanceDocId ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2AdvanceDocId, I)) & " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            If DueInstallmentUId.Trim <> "" Then
                mQry = "UPDATE Sch_DueInstallment1 " & _
                        " SET IsInActive = 1 " & _
                        " WHERE UID = " & AgL.Chk_Text(DueInstallmentUId) & " " & _
                        " AND Sr = " & DueInstallmentSr & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Update Sch_FeeReceivePaymentDetail Set PaymentDetailDocId = Null Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
            mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
            AgL.PubObjFrmPaymentDetail = Nothing

            Dim bStrPaymentDetailDocId$ = ""
            If Val(PaymentRec.TotalAmount) > 0 Then
                bStrPaymentDetailDocId = mSearchCode
            Else
                bStrPaymentDetailDocId = ""
            End If

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_FeeReceivePaymentDetail ( DocId, PaymentDetailDocId, LedgerMDocId) VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(bStrPaymentDetailDocId) & ",Null )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_FeeReceivePaymentDetail Set PaymentDetailDocId = " & AgL.Chk_Text(bStrPaymentDetailDocId) & " Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            '===========================================================================================================
            '=============================< Call Accounts Post Procedure >==============================================
            '=========================================< Start >=========================================================
            '===========================================================================================================
            mQry = "Update Sch_FeeReceivePaymentDetail " & _
                    " Set " & _
                    " LedgerMDocId = Null " & _
                    " Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            AgL.PubObjFrmPaymentDetail = mObjFrmPaymentDetail
            Call AccountPosting()

            mQry = "Update Sch_FeeReceivePaymentDetail " & _
                    " Set " & _
                    " LedgerMDocId = '" & mSearchCode & "' " & _
                    " Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            '===========================================================================================================
            '=============================< Call Accounts Post Procedure >==============================================
            '=========================================< End >===========================================================
            '===========================================================================================================


            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False



            Try
                If AgLibrary.ClsConstant.IsSmsActive Then
                    Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = ""
                    Dim bDtSmsEvent As DataTable = Nothing

                    mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & ClsMain.SmsEvent.FeeReceive & "'"
                    bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                    If bDtSmsEvent.Rows.Count > 0 Then
                        bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                        bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
                    End If
                    If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

                    mQry = "SELECT LEFT(IsNull(Sg.Mobile,''),10) AS Mobile  FROM SubGroup Sg WITH (NoLock) WHERE Sg.SubCode = " & AgL.Chk_Text(LblAdmissionDocId.Tag) & ""
                    bStrMobileNo = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar).ToString

                    If bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, AgL.XNull(LblAdmissionDocId.Tag).ToString, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                        Call AgL.SendSms(AgL)
                    End If
                End If
            Catch ex As Exception

            End Try

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                If _AdmissionDocId.Trim <> "" Then
                    InstallmentAmount = 0
                    _AdmissionDocId = ""
                    bBlnExitFlag = True
                End If

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag
                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call PrintDocument(mDocId)
                End If

                If bBlnExitFlag Then
                    Me.Close()
                End If

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

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim mTransFlag As Boolean = False
        Dim DrTemp As DataRow() = Nothing

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
                mQry = "Select Fr.*, Vt.NCat, FrReg.RegistrationDocId, Va.AdmissionId As StudentAdmissionId " & _
                        " From ViewSch_FeeReceive Fr " & _
                        " Left Join Voucher_Type Vt On Fr.V_Type = Vt.V_Type " & _
                        " Left Join Sch_FeeReceiveRegistration FrReg On Fr.DocId = FrReg.FeeReceiveDocId " & _
                        " LEFT JOIN ViewSch_Admission Va ON Fr.AdmissionDocId = Va.DocId " & _
                        " Where Fr.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        mStrFeeDueDocID = AgL.XNull(.Rows(0)("FeeDueDocId"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                       
                        TxtClass.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))

                        LblAdmissionDocId.Tag = AgL.XNull(.Rows(0)("StudentCode"))
                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("StudentAdmissionId"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        mRegistrationDocId = AgL.XNull(.Rows(0)("RegistrationDocId"))
                        mRefundAmount = AgL.VNull(.Rows(0)("RefundAmount"))

                        TxtRefNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                        LblRefNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))
                        LblManualPrefix.Text = AgL.XNull(.Rows(0)("ManualCodePrefix"))
                        TxtManualCodeSr.Text = AgL.VNull(.Rows(0)("ManualCodeSr"))

                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineAmount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = Format(AgL.VNull(.Rows(0)("TotalLineDiscount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineNetAmount")), "0.00")

                        DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = Format(AgL.VNull(.Rows(0)("TotalAdvanceAdjusted")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = Format(AgL.VNull(.Rows(0)("Advance")), "0.00")
                        mAdvanceBroughtForward = AgL.VNull(.Rows(0)("Advance"))
                        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = Format(AgL.VNull(.Rows(0)("SubTotal1")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = Format(AgL.VNull(.Rows(0)("AdjustmentAmount")), "0.00")

                        TxtIsAdjustableReceipt.Text = IIf(AgL.VNull(.Rows(0)("IsAdjustableReceipt")), "Yes", "No")
                        DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value = Format(AgL.VNull(.Rows(0)("TotalFeeReceiveAdjusted")), "0.00")

                        DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value = Format(AgL.VNull(.Rows(0)("ScholarShipAmount")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value = Format(AgL.VNull(.Rows(0)("CounselingFeeAdjusted")), "0.00")

                        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = Format(AgL.VNull(.Rows(0)("SubTotal2")), "0.00")
                        DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = Format(AgL.VNull(.Rows(0)("DiscountPer")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = Format(AgL.VNull(.Rows(0)("DiscountAmount")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = Format(AgL.VNull(.Rows(0)("AdvanceCarriedForward")), "0.00")

                        TxtIsManageFee.Text = IIf(AgL.VNull(.Rows(0)("IsManageFee")), "Yes", "No")

                        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
                            TxtOpeningAdvance.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")
                        Else
                            TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")
                        End If

                        'Code BY Akash On Date 24-01-11
                        DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc) = AgL.XNull(.Rows(I)("FeeAdjustmentAc"))
                        DGLAccounts.AgSelectedValue(DACC_Description, DACR_FeeReceiptAdjustmentAc) = AgL.XNull(.Rows(I)("FeeReceiptAdjustmentAc"))
                        'End Code
                        DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc) = AgL.XNull(.Rows(I)("ScholarshipAdjustmentAc"))
                        DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc) = AgL.XNull(.Rows(I)("CounselingFeeAdjustmentAc"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If
                End With

                mQry = "Select ST.* From Sch_FeeDue ST Where st.DocId='" & mStrFeeDueDocID & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        mStrFeeDuePrefix = AgL.XNull(.Rows(0)("V_Prefix"))
                        mLongFeeDueVrNo = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                    End If
                End With


                        mQry = "Select Fr1.*, Fd.V_Date, Fd.IsReversePosted ,FD.FeeCode,F.FeeNature " & _
                                " From Sch_FeeReceive1 Fr1 " & _
                                " LEFT JOIN ViewSch_FeeDue Fd ON FR1.FeeDue1 = Fd.FeeDue1Code " & _
                                " Left Join Sch_Fee F On FD.FeeCode=F.Code " & _
                                " Where Fr1.DocId='" & mSearchCode & "'"
                        DsTemp = AgL.FillData(mQry, AgL.GCn)

                        With DsTemp.Tables(0)
                            DGL1.RowCount = 1 : DGL1.Rows.Clear()
                            If .Rows.Count > 0 Then
                                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                                    DGL1.Rows.Add()
                                    DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                                    If AgL.XNull(.Rows(I)("MonthStartDate")) <> "" Then
                                        DGL1.Item(Col1MonthYear, I).Value = CDate(AgL.XNull(.Rows(I)("MonthStartDate"))).ToString("MMM/yyyy")
                                    End If

                                    DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                                    DGL1.AgSelectedValue(Col1FeeDue1, I) = AgL.XNull(.Rows(I)("FeeDue1"))
                                    DGL1.AgSelectedValue(Col1FeeCode, I) = AgL.XNull(.Rows(I)("FeeCode"))
                                    DGL1.AgSelectedValue(Col1FeeNature, I) = AgL.XNull(.Rows(I)("FeeNature"))
                                    DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                                    DGL1.Item(Col1TempAmount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                                    DGL1.Item(Col1Discount, I).Value = Format(AgL.VNull(.Rows(I)("Discount")), "0.00")
                                    DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")

                                    DGL1.Item(Col1IsFeeDueReversePosted, I).Value = IIf(AgL.VNull(.Rows(I)("IsReversePosted")), "Yes", "No")

                                    If AgL.VNull(.Rows(I)("IsReversePosted")) Then
                                        If mTransFlag = False Then mTransFlag = True
                                    End If

                                Next I
                                BtnFillFee.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End With

                        mQry = "Select Fra.*, ARec.V_Date, ARec.ReceiveAmount, ARec.IsAdjusted  " & _
                                " From Sch_FeeReceiveAdvance Fra " & _
                                " Left Join ViewSch_AdvanceReceive ARec On FRa.AdvanceDocId = ARec.DocId " & _
                                " Where Fra.FeeReceiveDocId = '" & mSearchCode & "' " & _
                                " Order By ARec.V_Date "
                        DsTemp = AgL.FillData(mQry, AgL.GCn)

                        With DsTemp.Tables(0)
                            DGL2.RowCount = 1 : DGL2.Rows.Clear()
                            If .Rows.Count > 0 Then
                                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                                    DGL2.Rows.Add()
                                    DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                                    DGL2.AgSelectedValue(Col2AdvanceDocId, I) = AgL.XNull(.Rows(I)("AdvanceDocId"))
                                    DGL2.Item(Col2AdvanceVDate, I).Value = Format(AgL.XNull(.Rows(I)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                    DGL2.Item(Col2AdvanceReceive, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                                    DGL2.Item(Col2AdjustYesNo, I).Value = AgL.VNull(.Rows(I)("IsAdjusted"))
                                Next I
                                BtnFillAdvanceVoucher.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End With

                        ''Payment Detail Moverec Common
                        AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                        AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                        PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                        mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                        AgL.PubObjFrmPaymentDetail = Nothing
                    Else
                        BlankText()
                    End If
                    If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

                    If mSearchCode.Trim <> "" Then
                        mQry = "SELECT isnull(count(Afr.AdjustableFeeReceiveDocId),0) AS Cnt  " & _
                              " FROM Sch_FeeReceiveAdjustableFeeReceive Afr " & _
                              " WHERE Afr.AdjustableFeeReceiveDocId = '" & mSearchCode & "'"
                        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                            mTransFlag = True
                        Else
                            mQry = "SELECT isnull(count(Fr1.FeeReceiveDocId),0) AS Cnt  " & _
                                  " FROM Sch_FeeRefund1 Fr1 " & _
                                  " WHERE Fr1.FeeReceiveDocId = '" & mSearchCode & "'"
                            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                                mTransFlag = True
                            Else
                                mQry = "SELECT isnull(count(Sr1.FeeReceiveDocId),0) AS Cnt  " & _
                                      " FROM Sch_ScholarShipReceive1 Sr1 " & _
                                      " WHERE Sr1.FeeReceiveDocId = '" & mSearchCode & "'"
                                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
                            End If
                        End If
                        If mTransFlag Then
                            Topctrl1.tEdit = False
                            Topctrl1.tDel = False
                        Else
                            If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                            If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                        End If
                    End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = "" : mRegistrationDocId = "" : LblManualPrefix.Text = ""
        mRefundAmount = 0 : mAdvanceBroughtForward = 0

        mStrFeeDueDocID = "" : mStrFeeDuePrefix = "" : mLongFeeDueVrNo = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        Call BlankFooterGrid()
        PaymentRec = Nothing : mObjFrmPaymentDetail = Nothing

        LblInstallment.Text = "Installment : #####.##" : LblInstallment.Visible = False

        lblAdjustment.Text = "Adjustable : #####.##" : lblAdjustment.Visible = False

        TxtIsManageFee.Text = "No" : TxtIsAdjustableReceipt.Text = "No"
        BtnFillFee.Tag = "" : BtnFillAdvanceVoucher.Tag = "" : BtnFillAdvanceVoucher.Tag = ""

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid(Optional ByVal bIsCalculationCall As Boolean = False)
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineDiscount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineNetAmount).Value = ""

        DGLFooter2.Item(DFC_Percentage, DF2R_AdjustmentAmount).Value = ""

        DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalAdvanceAdjusted).Value = ""
        'Code By Akash On Date 11-01-11
        DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalFeeReceiveAdjusted).Value = ""
        'End Code


        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_SubTotal1).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_SubTotal2).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalNetAmount).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_AdvanceCarriedForward).Value = ""

        If Not bIsCalculationCall Then
            DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_Advance).Value = ""
            DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_AdjustmentAmount).Value = ""
            DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = ""
            'Code By Akash On Date 11-1-10
            DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalFeeReceiveAdjusted).Value = ""
            'End code
            DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_ScholarshipAdjusted).Value = ""
            DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_CounselingFeeAdjusted).Value = ""
        End If

    End Sub


    Private Sub ProcAssignAccount()
        Try
            If AgL.XNull(DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc)).ToString.Trim = "" Then
                DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc) = AgL.XNull(DtSch_Enviro.Rows(0)("FeeAdjustmentAc"))
            End If

            If AgL.XNull(DGLAccounts.AgSelectedValue(DACC_Description, DACR_FeeReceiptAdjustmentAc)).ToString.Trim = "" Then
                DGLAccounts.AgSelectedValue(DACC_Description, DACR_FeeReceiptAdjustmentAc) = AgL.XNull(DtSch_Enviro.Rows(0)("FeeReceiptAdjustmentAc"))
            End If

            'If AgL.XNull(DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc)).ToString.Trim = "" Then
            '    DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc) = AgL.XNull(DtSch_Enviro.Rows(0)("ScholarshipAdjustmentAc"))
            'End If

            'If AgL.XNull(DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc)).ToString.Trim = "" Then
            '    DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc) = AgL.XNull(DtSch_Enviro.Rows(0)("CounselingFeeAdjustmentAc"))
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False : TxtRefNo.Enabled = False

        BtnFillFee.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtAdmissionDocId.Enabled = False
            TxtClass.Enabled = False
            '=========================================================
            '===========< BtnFillFee Will Remain Disable >============
            '======< As Code Generated in FeeReceive1 Table >=========
            '=========================================================
            BtnFillFee.Enabled = False
            '=========================================================
        End If


        If Enb Then
            DGLFooter2.CurrentCell = DGLFooter2(DFC_Percentage, DF2R_Discount) : DGLFooter2.CurrentCell.ReadOnly = False
            DGLFooter2.CurrentCell = DGLFooter2(DFC_Amount, DF2R_Discount) : DGLFooter2.CurrentCell.ReadOnly = False
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
                Case Col1FeeDue1
                    DGL1.AgRowFilter(Col1FeeDue1) = " AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "'"
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

    Private Sub DGL2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2AdjustYesNo
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
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
                Case Col1FeeDue1
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        'DGL1.Item(Col1FeeDue1Code, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                'DGL1.Item(Col1FeeDue1Code, mRowIndex).Value = AgL.XNull(.Item("Code", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case Col1Amount
                    If Val(DGL1.Item(Col1Amount, mRowIndex).Value) > Val(DGL1.Item(Col1TempAmount, mRowIndex).Value) Then
                        DGL1.Item(Col1Amount, mRowIndex).Value = Format(Val(DGL1.Item(Col1TempAmount, mRowIndex).Value), "0.00")
                        MsgBox(DGL1.Item(Col1FeeDue1, mRowIndex).Value.ToString + " Can't Be Greater Than From " & Format(Val(DGL1.Item(Col1TempAmount, mRowIndex).Value)) & "")
                    Else
                        DGL1.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGL1.Item(mColumnIndex, mRowIndex).Value), "0.00")
                    End If

                Case Col1Discount
                    If Val(DGL1.Item(Col1Discount, mRowIndex).Value) > Val(DGL1.Item(Col1Amount, mRowIndex).Value) Then
                        DGL1.Item(Col1Discount, mRowIndex).Value = ""
                        MsgBox("Discount On " & DGL1.Item(Col1FeeDue1, mRowIndex).Value.ToString & " Is Not Valid!...")
                    Else
                        DGL1.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGL1.Item(mColumnIndex, mRowIndex).Value), "0.00")
                    End If

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
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

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1FeeDue1, 0).Value Is Nothing Then DGL1.Item(Col1FeeDue1, 0).Value = ""
            If DGL1.Item(Col1FeeDue1, 0).Value.ToString.Trim = "" Then
                If TxtV_Type.Enabled = False Then TxtV_Type.Enabled = True
            End If
        End If

        Call Calculation()
    End Sub

    Private Sub DGLFooter2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGLFooter2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGLFooter2.CurrentCell.RowIndex
            mColumnIndex = DGLFooter2.CurrentCell.ColumnIndex

            If DGLFooter2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGLFooter2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGLFooter2.CurrentCell.ColumnIndex
                Case DFC_Percentage, DFC_Amount
                    DGLFooter2.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGLFooter2.Item(mColumnIndex, mRowIndex).Value), "0.00")
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        TxtV_Type.Enter, TxtAdmissionDocId.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                'Case <Sender>.Name
                '<Executable code>
                Case TxtAdmissionDocId.Name
                    bStrFilter = " 1=1 And CurrentSemester='" & TxtClass.AgSelectedValue & "'"
                    TxtAdmissionDocId.AgRowFilter = bStrFilter


            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtAdmissionDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, TxtAdmissionID.Validating, _
          TxtReceiveAmount.Validating, TxtIsManageFee.Validating, TxtOpeningAdvance.Validating, TxtRefNo.Validating, TxtManualCodeSr.Validating

        Dim DrTemp As DataRow() = Nothing
        Dim CancelAmt As Double = 0.0
        Dim ReceiveAmt As Double = 0.0
        Dim AdjustAmt As Double = 0.0
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    Call ProcValidatingControls(sender)

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
                        TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)
                    End If

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtAdmissionID.Text = ""
                        LblAdmissionDocId.Tag = ""
                        lblAdjustment.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtAdmissionID.Text = AgL.XNull(DrTemp(0)("AdmissionID"))
                            LblAdmissionDocId.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
                        End If
                        DrTemp = Nothing


                    End If

                Case TxtIsManageFee.Name
                    Call ProcManageFee()

            End Select

            Call Calculation()
            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)


            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function FunGetManualCode() As String
        Dim bStrReturn As String = ""
        Try
            If TxtSite_Code.Text.Trim <> "" And LblPrefix.Text.Trim <> "" And Val(TxtManualCodeSr.Text) > 0 Then
                LblManualPrefix.Text = TxtSite_Code.AgSelectedValue + "-" + LblPrefix.Text
                bStrReturn = LblManualPrefix.Text & TxtManualCodeSr.Text
            End If

        Catch ex As Exception
            bStrReturn = ""
            MsgBox(ex.Message)
        Finally
            FunGetManualCode = bStrReturn
        End Try
    End Function

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim I As Integer = 0
        Dim DrTemp As DataRow() = Nothing

        Call BlankFooterGrid(True)

        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
            TxtReceiveAmount.Text = ""
        Else
            TxtOpeningAdvance.Text = ""
        End If

        If TxtAdmissionDocId.Text.Trim <> "" Then
            DrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & "")
            If DrTemp.Length > 0 Then
                If Not AgL.StrCmp(LblAdmissionDocId.Tag, AgL.XNull(DrTemp(0)("StudentCode"))) Then
                    TxtAdmissionID.Text = AgL.XNull(DrTemp(0)("AdmissionID"))
                    LblAdmissionDocId.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
                End If
            End If
        End If


        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                .Item(Col1ArrayIndex, I).Value = -1
                .Item(Col1TempFeeDue1, I).Value = ""

                If .Item(Col1FeeCode, I).Value <> "" Then
                    .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")
                    'Footer Detail
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) + Val(.Item(Col1Amount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) + Val(.Item(Col1Discount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                End If
            Next
        End With

        With DGL2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2AdvanceReceive, I).Value Is Nothing Then .Item(Col2AdvanceReceive, I).Value = ""
                If .Item(Col2AdjustYesNo, I).Value Is Nothing Then .Item(Col2AdjustYesNo, I).Value = ""

                Try
                    If .Item(Col2AdjustYesNo, I).Value = "" Then .Item(Col2AdjustYesNo, I).Value = False
                Catch ex As Exception

                End Try

                If .Item(Col2AdvanceDocId, I).Value <> "" And CBool(.Item(Col2AdjustYesNo, I).Value) Then
                    'Footer Detail
                    DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) + Val(.Item(Col2AdvanceReceive, I).Value), "0.00")
                End If
            Next
        End With

        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value), "0.00")
        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value), "0.00")

        If Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) > 0 Then
            DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value) * Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) * 0.01, "0.00")
        End If
        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value), "0.00")

        If (Val(TxtReceiveAmount.Text) + Val(TxtOpeningAdvance.Text)) > Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
            DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = Format((Val(TxtReceiveAmount.Text) + Val(TxtOpeningAdvance.Text)) - Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value), "0.00")
        Else
            DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = ""
        End If

    End Sub

    Private Sub ProcManageFee()
        Dim I As Integer = 0
        Dim bTotal As Double = 0, bDiffAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        bDiffAmount = Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) - Val(TxtReceiveAmount.Text)

        If AgL.StrCmp(TxtIsManageFee.Text, "Yes") Then
            If bDiffAmount <= 0 Then
                TxtIsManageFee.Text = "No"
            Else
                If Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) > 0 Then DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = ""

                With DGL1
                    For I = .Rows.Count - 1 To 0 Step -1
                        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                        If .Item(Col1FeeCode, I).Value <> "" And Val(.Item(Col1NetAmount, I).Value) > 0 Then
                            If bDiffAmount >= bTotal + Val(.Item(Col1NetAmount, I).Value) Then
                                bTotal += Val(.Item(Col1NetAmount, I).Value)
                                .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1NetAmount, I).Value), "0.00")
                            ElseIf bTotal < bDiffAmount Then
                                .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - (bDiffAmount - bTotal), "0.00")
                                bTotal = bDiffAmount
                            Else
                                Exit For
                            End If
                        End If

                    Next
                End With
            End If
        End If
        Call Calculation()
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Function

            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
                If CDate(TxtV_Date.Text) > CDate(AgL.PubStartDate) Then
                    MsgBox("Voucher Date Can't Be Greater Than From " & AgL.PubStartDate & "!...")
                    TxtV_Date.Focus() : Exit Function
                ElseIf CDate(TxtV_Date.Text) < CDate(AgL.PubStartDate).AddDays(-1) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & Format(CDate(AgL.PubStartDate).AddDays(-1), AgLibrary.ClsConstant.DateFormat_ShortDate) & "!...")
                    TxtV_Date.Focus() : Exit Function
                End If

                If Val(TxtReceiveAmount.Text) > 0 Then MsgBox("Receive Amount Can't Be Greater Than Zero!...") : TxtReceiveAmount.Focus()
                If AgL.RequiredField(TxtOpeningAdvance, "Opening Amount", True) Then Exit Function
            Else
                If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
                If Val(TxtOpeningAdvance.Text) <> 0 Then MsgBox("Opening Amount Is Not Required!...") : TxtOpeningAdvance.Focus()
            End If


            'AgCL.AgBlankNothingCells(DGL1)
            'If AgCL.AgIsBlankGrid(DGL1, Col1FeeDue1) Then Exit Function

            If BtnFillFee.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillFee.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillFee.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If BtnFillAdvanceVoucher.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillAdvanceVoucher.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillAdvanceVoucher.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If BtnFillAdvanceVoucher.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillAdvanceVoucher.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillAdvanceVoucher.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            'If Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) <= 0 Then
            '    MsgBox("Net Fee Can't Be <= 0 (Zero)!...")
            '    DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
            '    Exit Function
            'End If

            Dim bTotalDiscount As Double = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) + Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value)

            If Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) < 0 Then
                If Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) + _
                    (Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) + _
                    Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) + _
                    Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) + _
                    Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value)) < 0 Then

                    MsgBox("Net Fee Can't Be < 0 (Zero)!...")
                    DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
                    Exit Function
                End If
            ElseIf Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) = 0 Then
                If MsgBox("Net Fee Amount Is 0 (Zero)!..." & vbCrLf & "Do You Want To Continue?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, "Validation Check") = MsgBoxResult.No Then
                    DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
                    Exit Function
                End If
            End If

            If Val(TxtReceiveAmount.Text) < Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """")
                TxtReceiveAmount.Focus() : Exit Function
            ElseIf Val(TxtReceiveAmount.Text) > Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                If MsgBox("Receive Amount Is Greater Than From Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """" & vbCrLf & "Do You Want To Receive Advance!...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    TxtReceiveAmount.Focus() : Exit Function
                End If
            End If

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) > 0 Then
                mQry = "Select IsNull(Count(*),0) As Cnt " & _
                        " From Sch_FeeReceiveRegistration FrReg " & _
                        " Where FrReg.RegistrationDocId = " & AgL.Chk_Text(mRegistrationDocId) & "  And " & _
                        " " & IIf(Topctrl1.Mode = "Edit", " FrReg.FeeReceiveDocId <> '" & mSearchCode & "' ", " 1=1 ") & " "

                If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then
                    MsgBox("Please Fill Grid Again As Registration Amount Is Adjusted In Another Receipt!...")
                    BtnFillFee.Focus() : Exit Function
                End If
            End If

            If AgL.XNull(DtSch_Enviro.Rows(0)("DiscountAc")).ToString.Trim = "" Then MsgBox("Define Discount A/c In Environment Settings!...") : Exit Function
            'If AgL.XNull(DtSch_Enviro.Rows(0)("FeeAdjustmentAc")).ToString.Trim = "" Then MsgBox("Define Fee Adjustment A/c In Environment Settings!...") : Exit Function
            If DGLAccounts.Item(DACC_Description, DACR_RegFeeAdjustmentAc).Value = "" And Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) > 0 Then MsgBox("Define Reg. Fee Adjustment A/c !...") : Tc1.SelectedTab = Tp3 : DGLAccounts.CurrentCell = DGLAccounts.Item(DACC_Description, DACR_RegFeeAdjustmentAc) : DGLAccounts.Focus() : Exit Function
            If DGLAccounts.Item(DACC_Description, DACR_FeeReceiptAdjustmentAc).Value = "" And Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalFeeReceiveAdjusted).Value) > 0 Then MsgBox("Define Fee Receipt Adjustment A/c !...") : Tc1.SelectedTab = Tp3 : DGLAccounts.CurrentCell = DGLAccounts.Item(DACC_Description, DACR_FeeReceiptAdjustmentAc) : DGLAccounts.Focus() : Exit Function
            'If DGLAccounts.Item(DACC_Description, DACR_ScholarshipAdjustmentAc).Value = "" And Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value) > 0 Then MsgBox("Define Scholarship Adjustment A/c !...") : Tc1.SelectedTab = Tp3 : DGLAccounts.CurrentCell = DGLAccounts.Item(DACC_Description, DACR_ScholarshipAdjustmentAc) : DGLAccounts.Focus() : Exit Function
            'If DGLAccounts.Item(DACC_Description, DACR_CounselingFeeAdjustmentAc).Value = "" And Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value) > 0 Then MsgBox("Define Counseling Fee Adjustment A/c !...") : Tc1.SelectedTab = Tp3 : DGLAccounts.CurrentCell = DGLAccounts.Item(DACC_Description, DACR_CounselingFeeAdjustmentAc) : DGLAccounts.Focus() : Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If
            '******** Fee Due DocID ********************
            If Topctrl1.Mode = "Add" Then
                mStrFeeDueDocID = AgL.GetDocId(Academic_ProjLib.ClsMain.NCat_FeeDue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                mLongFeeDueVrNo = Val(AgL.DeCodeDocID(mStrFeeDueDocID, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                mStrFeeDuePrefix = AgL.DeCodeDocID(mStrFeeDueDocID, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                TxtRefNo.Text = AgL.ConvertDocId(mSearchCode)
                LblRefNo.Tag = AgL.ConvertDocId(mSearchCode)
            End If


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        Dim DrTemp As DataRow() = Nothing
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtV_Date.Text = AgL.PubLoginDate
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & "")
            If DrTemp IsNot Nothing Then
                TxtV_Type.AgSelectedValue = Academic_ProjLib.ClsMain.NCat_FeeReceive
                LblV_Type.Tag = Academic_ProjLib.ClsMain.NCat_FeeReceive
            Else
                TxtV_Type.AgSelectedValue = ""
                LblV_Type.Tag = ""
            End If
            DrTemp = Nothing

            TxtV_Type.Enabled = True
        End If

        Call ProcAssignAccount()

        If mTmV_Type.Trim = "" Then            
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If



        If _AdmissionDocId.Trim <> "" Then
            TxtAdmissionDocId.Focus()
            TxtAdmissionDocId.AgSelectedValue = _AdmissionDocId

            If InstallmentAmount > 0 Then
                LblInstallment.Visible = True
                LblInstallment.Text = "Installment : " + Format(InstallmentAmount, "0.00")
            Else
                LblInstallment.Visible = False
            End If

            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
            Call ProcValidatingControls(TxtV_Date)

            TxtV_Type.Focus()

            If TxtAdmissionDocId.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & "")
                TxtAdmissionID.Text = AgL.XNull(DrTemp(0)("AdmissionID"))
                LblAdmissionDocId.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
            End If

            Call ProcFillFee()
        End If
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection
        Dim bTotalDiscount As Double


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()


        bTotalDiscount = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) + Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value)

        I = 0
        ReDim Preserve LedgAry(I)

        If bTotalDiscount > 0 Then
            mNarr = "Being Total Discount Of Rs. " & Format(bTotalDiscount, "0.00") & " Provided!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = AgL.XNull(DtSch_Enviro.Rows(0)("DiscountAc"))
            LedgAry(I).ContraSub = LblAdmissionDocId.Tag
            LedgAry(I).AmtDr = bTotalDiscount
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAdmissionDocId.Tag
            LedgAry(I).ContraSub = AgL.XNull(DtSch_Enviro.Rows(0)("DiscountAc"))
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = bTotalDiscount
            LedgAry(I).Narration = mNarr

        End If

        If Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) > 0 Then
            mNarr = "Being Registration Fee Adjusted Of Rs. " & Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value), "0.00") & "!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc)
            LedgAry(I).ContraSub = LblAdmissionDocId.Tag
            LedgAry(I).AmtDr = Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAdmissionDocId.Tag
            LedgAry(I).ContraSub = DGLAccounts.AgSelectedValue(DACC_Description, DACR_RegFeeAdjustmentAc)
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value)
            LedgAry(I).Narration = mNarr

        End If

        If Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value) > 0 Then
            mNarr = "Being Counseling Fee Adjusted Of Rs. " & Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value), "0.00") & "!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc)
            LedgAry(I).ContraSub = LblAdmissionDocId.Tag
            LedgAry(I).AmtDr = Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAdmissionDocId.Tag
            LedgAry(I).ContraSub = DGLAccounts.AgSelectedValue(DACC_Description, DACR_CounselingFeeAdjustmentAc)
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value)
            LedgAry(I).Narration = mNarr

        End If

        'Code For Scholarship Adjustment

        If Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value) > 0 Then
            mNarr = "Being Scholarship Adjusted Of Rs. " & Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value), "0.00") & "!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc)
            LedgAry(I).ContraSub = LblAdmissionDocId.Tag
            LedgAry(I).AmtDr = Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAdmissionDocId.Tag
            LedgAry(I).ContraSub = DGLAccounts.AgSelectedValue(DACC_Description, DACR_ScholarshipAdjustmentAc)
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(DGLFooter2.Item(DFC_Amount, DF2R_ScholarshipAdjusted).Value)
            LedgAry(I).Narration = mNarr
        End If
        'End Scholarship Code

        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If Val(TxtOpeningAdvance.Text) > 0 Then
            mNarr = ""
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAdmissionDocId.Tag
            LedgAry(I).ContraSub = ""
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(TxtOpeningAdvance.Text)
            LedgAry(I).Narration = mNarr
        End If

        If Val(TxtReceiveAmount.Text) > 0 Then
            If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        End If

        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, True, AgL.Gcn_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        Else
            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        End If


        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Private Sub BtnFillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillFee.Click, BtnFillAdvanceVoucher.Click
        Try
            Select Case sender.name
                Case BtnFillFee.Name
                    Call ProcFillFee()

                Case BtnFillAdvanceVoucher.Name
                    Call ProcFillAdvanceVoucher()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillFee()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer, J = 0, K = 0
        Dim DsHeader As New DataSet
        Dim mLateFee As String = ""
        Dim bAdvanceAmount As Double = 0, mLateFeeAmount = 0
        Dim StrTblParam As String = ""
        Dim StrTblParamIni As String = " Declare @TblParm AS Table(MonthStartDate SmallDateTime,V_Date SmallDateTime, " & _
                                       " AdmissionDocID nvarchar(21) ,FeeNature nvarchar(20))"

        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            TxtIsManageFee.Text = "No"
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillFee.Tag = ""

            If AgL.RequiredField(TxtV_Type, "Voucher Type") Then Exit Sub
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Sub
            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
                MsgBox("Fee Detail Is Not Requied For Opening Advance!...", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            mQry = "SELECT VFd.FeeDue1Code, VFd.NetBalance + IsNull(V1.ReceiveAmount,0) As NetBalance, VFd.V_Date, Vfd.IsReversePosted, Vfd.MonthStartDate,F.FeeNature, VFD.FeeCode " & _
                    " FROM ViewSch_FeeDue VFd " & _
                    " Left Join Sch_Fee F On VFD.FeeCode=F.Code " & _
                    " Left Join (SELECT Fr1.FeeDue1 AS FeeDue1Code, IsNULL(Sum(Fr1.Amount),0) AS ReceiveAmount, IsNULL(Sum(Fr1.Discount),0) AS Discount, IsNULL(Sum(Fr1.NetAmount),0) AS NetReceiveAmount FROM dbo.Sch_FeeReceive1 Fr1 Where Fr1.DocId = " & AgL.Chk_Text(IIf(Topctrl1.Mode = "Add", "", mSearchCode)) & "  GROUP BY Fr1.FeeDue1 ) V1 On VFd.FeeDue1Code = V1.FeeDue1Code " & _
                    " WHERE VFd.NetBalance + IsNull(V1.ReceiveAmount,0) > 0 " & _
                    " AND VFd.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    " AND IsNull(Vfd.IsReversePosted,0) = 0 " & _
                    " AND VFd.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
                    " Order By Vfd.V_Date "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtAdmissionDocId.Enabled = False
                    StrTblParam = StrTblParamIni
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.Item(Col1MonthYear, I).Value = CDate(AgL.XNull(DtTemp.Rows(I)("MonthStartDate"))).ToString("MMM/yyyy")
                        DGL1.AgSelectedValue(Col1FeeDue1, I) = AgL.XNull(.Rows(I)("FeeDue1Code"))
                        DGL1.AgSelectedValue(Col1FeeCode, I) = AgL.XNull(.Rows(I)("FeeCode"))
                        DGL1.AgSelectedValue(Col1FeeNature, I) = AgL.XNull(.Rows(I)("FeeNature"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                        DGL1.Item(Col1TempAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                        DGL1.Item(Col1IsFeeDueReversePosted, I).Value = IIf(AgL.VNull(.Rows(I)("IsReversePosted")), "Yes", "No")

                        'Insert Temp Table*****************
                        StrTblParam += " INSERT INTO @TblParm  ( MonthStartDate, V_Date,AdmissionDocID,FeeNature) " & _
                                            " VALUES ( '" & CDate(.Rows(I)("MonthStartDate")) & "', " & _
                                            " '" & CDate(.Rows(I)("V_Date")) & "', " & _
                                            " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                                            " " & AgL.Chk_Text(.Rows(I)("FeeNature")) & " " & _
                                            " ) "

                    Next I
                    BtnFillFee.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    '**********Late Fee Parameter *****************
                    K = DGL1.Rows.Count
                    mQry = StrTblParam & _
                       " SELECT T.MonthStartDate,T.V_Date,T.AdmissionDocID " & _
                       " " & _
                       " FROM @TblParm T  " & _
                       " Where T.FeeNature<>'Late Fee' AND T.MonthStartDate<= T.V_Date " & _
                       " Group By T.AdmissionDocID, T.MonthStartDate, T.V_Date "

                    DsHeader = AgL.FillData(mQry, AgL.GCn)
                    If DsHeader.Tables(0).Rows.Count > 0 Then
                        For J = 0 To DsHeader.Tables(0).Rows.Count - 1
                            mLateFeeAmount = mObjClsMain.FunGetLateFee(AgL.XNull(DsHeader.Tables(0).Rows(J)("AdmissionDocID")), CDate(DsHeader.Tables(0).Rows(J)("V_Date")), CDate(TxtV_Date.Text), CDate(DsHeader.Tables(0).Rows(J)("MonthStartDate")))
                            If mLateFeeAmount > 0 Then
                                mQry = " Select isnull(Count(*),0) " & _
                                       " From LateFeeParameter L With (NoLock) Where L.Site_Code='" & AgL.PubSiteCode & "'"
                                If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then
                                    mQry = " Select isnull(LateFeeAC,'') " & _
                                                       " From LateFeeParameter L With (NoLock) Where L.Site_Code='" & AgL.PubSiteCode & "'"
                                    If AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) Is Nothing Or AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) = "" Then
                                        MsgBox("Please Define Late Fee A/c In Late Fee Parameter!...")
                                        Exit Sub
                                    Else
                                        mLateFee = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
                                    End If
                                    ''Fill Data ********

                                    DGL1.Rows.Add()
                                    DGL1.Item(Col_SNo, K).Value = DGL1.Rows.Count
                                    DGL1.Item(Col1MonthYear, K).Value = CDate(AgL.XNull(DsHeader.Tables(0).Rows(J)("MonthStartDate"))).ToString("MMM/yyyy")
                                    DGL1.AgSelectedValue(Col1FeeCode, K) = AgL.XNull(mLateFee)
                                    DGL1.AgSelectedValue(Col1FeeNature, K) = "Late Fee"
                                    DGL1.Item(Col1Amount, K).Value = Format(AgL.VNull(mLateFeeAmount), "0.00")
                                    DGL1.Item(Col1TempAmount, K).Value = Format(AgL.VNull(mLateFeeAmount), "0.00")
                                    DGL1.Item(Col1IsFeeDueReversePosted, K).Value = "No"
                                    K = K + 1
                                End If
                            End If

                        Next
                    End If

                    '********************************************


                    mQry = "SELECT Reg.DocId, IsNULL(Sum(Reg.NetAmount),0) TotalNetAmount " & _
                            " FROM Sch_RegistrationFee Reg   " & _
                            " LEFT JOIN Sch_Fee F ON Reg.Fee = F.Code  " & _
                            " LEFT JOIN Sch_Admission Adm ON Reg.DocId = Adm.RegistrationDocId    " & _
                            " LEFT JOIN Sch_FeeReceiveRegistration FrReg ON Reg.DocId = FrReg.RegistrationDocId    " & _
                            " WHERE Adm.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND IsNull(F.Refundable,0)<>0 AND " & _
                            " " & IIf(Topctrl1.Mode = "Add", " FrReg.RegistrationDocId IS Null ", " Reg.DocId = " & AgL.Chk_Text(mRegistrationDocId) & " ") & "  " & _
                            " GROUP BY Reg.DocId "
                    DtTemp1 = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    With DtTemp1
                        If .Rows.Count > 0 Then
                            mRegistrationDocId = AgL.XNull(.Rows(0)("DocId"))
                            DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                        Else
                            mRegistrationDocId = ""
                            DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = ""
                        End If
                        .Dispose()
                    End With

                    mQry = "Select A.CounselingFee, vFrec.CounselingFeeAdjusted " & _
                            " FROM Sch_Admission A  " & _
                            " LEFT JOIN (SELECT * FROM Sch_FeeReceive FRec WHERE FRec.CounselingFeeAdjusted > 0 AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " FRec.DocId <> '" & mSearchCode & "' ") & ") vFrec ON vFrec.AdmissionDocId = A.DocId  " & _
                            " WHERE A.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' And A.CounselingFee > 0 "
                    DtTemp1 = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    With DtTemp1
                        DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value = ""
                        If .Rows.Count > 0 Then
                            If AgL.VNull(.Rows(0)("CounselingFeeAdjusted")) = 0 And AgL.VNull(.Rows(0)("CounselingFee")) > 0 Then
                                DGLFooter2.Item(DFC_Amount, DF2R_CounselingFeeAdjusted).Value = Format(AgL.VNull(.Rows(0)("CounselingFee")), "0.00")
                            End If
                        End If
                        .Dispose()
                    End With



                    bAdvanceAmount = FunGetAdvanceAmount()
                    DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = Format(bAdvanceAmount, "0.00")

                Else
                    TxtAdmissionDocId.Enabled = True

                    MsgBox("No Fee Exists To Receive!...")
                End If
            End With

            Call ProcFillAdvanceVoucher()
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillFee.Tag = ""
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub ProcFillAdvanceVoucher()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            BtnFillAdvanceVoucher.Tag = ""

            If AgL.RequiredField(TxtV_Type, "Voucher Type") Then Exit Sub
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Sub
            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) Then
                MsgBox("Advance Voucher Detail Is Not Requied For Opening Advance!...", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If

            mQry = "SELECT ARec.DocId As AdvanceDocId, ARec.V_Date, ARec.ReceiveAmount, ARec.IsAdjusted " & _
                    " FROM ViewSch_AdvanceReceive ARec " & _
                    " WHERE ARec.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " AND " & _
                    " ARec.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And " & _
                    " " & IIf(Topctrl1.Mode = "Add", " ARec.FeeReceiveDocId IS NULL ", " CASE WHEN ARec.FeeReceiveDocId IS NULL THEN '" & mSearchCode & "' ELSE ARec.FeeReceiveDocId END = '" & mSearchCode & "' ") & " " & _
                    " Order By ARec.V_Date "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                        DGL2.AgSelectedValue(Col2AdvanceDocId, I) = AgL.XNull(.Rows(I)("AdvanceDocId"))
                        DGL2.Item(Col2AdvanceVDate, I).Value = Format(AgL.XNull(.Rows(I)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        DGL2.Item(Col2AdvanceReceive, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                        DGL2.Item(Col2AdjustYesNo, I).Value = AgL.VNull(.Rows(I)("IsAdjusted"))
                    Next I
                    BtnFillAdvanceVoucher.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            BtnFillAdvanceVoucher.Tag = ""
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Function FunGetAdvanceAmount() As Double
        Dim bAdvanceAmount As Double = 0
        Try
            'mQry = "Select Case When IsNull(Sum(V2.NetAdvance),0) >= IsNull(Sum(V1.Advance),0) Then IsNull(Sum(V1.Advance),0) Else IsNull(Sum(V2.NetAdvance),0) End As NetAdvance " & _
            '        " From Sch_Admission Adm " & _
            '        " Left Join " & _
            '        "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) - IsNull(Sum(vFRef.ExcessRefund),0) AS Advance " & _
            '        "           FROM Sch_FeeReceive Fr " & _
            '        "           Left Join (SELECT FRef.FeeReceiveDocId, IsNull(Sum(Fref.ExcessRefund),0) AS ExcessRefund  FROM ViewSch_FeeRefund FRef Where FRef.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And FRef.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " GROUP BY FRef.FeeReceiveDocId) As vFRef On Fr.DocId = vFRef.FeeReceiveDocId " & _
            '        "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '        "           GROUP BY Fr.AdmissionDocId) As V1 On Adm.DocId = V1.AdmissionDocId " & _
            '        " Left Join " & _
            '        "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) - IsNull(Sum(vFRef.ExcessRefund),0) AS NetAdvance " & _
            '        "           FROM Sch_FeeReceive Fr " & _
            '        "           Left Join (SELECT FRef.FeeReceiveDocId, IsNull(Sum(Fref.ExcessRefund),0) AS ExcessRefund  FROM ViewSch_FeeRefund FRef Where FRef.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " GROUP BY FRef.FeeReceiveDocId) As vFRef On Fr.DocId = vFRef.FeeReceiveDocId " & _
            '        "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '        "           GROUP BY Fr.AdmissionDocId) As V2 On Adm.DocId = V2.AdmissionDocId " & _
            '        " Where Adm.DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
            '        " Group By Adm.DocId "

            mQry = "Select Case When IsNull(Sum(V2.NetAdvance),0) >= IsNull(Sum(V1.Advance),0) Then IsNull(Sum(V1.Advance),0) Else IsNull(Sum(V2.NetAdvance),0) End As NetAdvance " & _
                    " From Sch_Admission Adm " & _
                    " Left Join " & _
                    "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) - IsNull(Sum(vFRef.ExcessRefund),0) AS Advance " & _
                    "           FROM Sch_FeeReceive Fr " & _
                    "           Left Join (" & _
                    "                       SELECT vFRef1.FeeReceiveDocId, IsNull(Sum(vFref1.ExcessRefund),0) AS ExcessRefund  " & _
                    "                       FROM Sch_FeeRefund FRef " & _
                    "                       Inner Join ( " & _
                    "                                   SELECT FRef1.DocId, FRef1.FeeReceiveDocId, Sum(FRef1.NetAmount) AS ExcessRefund " & _
                    "                                   FROM Sch_FeeRefund1 FRef1 " & _
                    "                                   WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' " & _
                    "                                   GROUP BY FRef1.DocId, FRef1.FeeReceiveDocId " & _
                    "                                   ) vFRef1 On vFRef1.DocId = FRef.DocId " & _
                    "                       Where FRef.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
                    "                       And FRef.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    "                       GROUP BY vFRef1.FeeReceiveDocId " & _
                    "                       ) As vFRef On Fr.DocId = vFRef.FeeReceiveDocId " & _
                    "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
                    "           GROUP BY Fr.AdmissionDocId) As V1 On Adm.DocId = V1.AdmissionDocId " & _
                    " Left Join " & _
                    "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) - IsNull(Sum(vFRef.ExcessRefund),0) AS NetAdvance " & _
                    "           FROM Sch_FeeReceive Fr " & _
                    "           Left Join (" & _
                    "                       SELECT vFRef1.FeeReceiveDocId, IsNull(Sum(vFref1.ExcessRefund),0) AS ExcessRefund  " & _
                    "                       FROM Sch_FeeRefund FRef " & _
                    "                       Inner Join ( " & _
                    "                                   SELECT FRef1.DocId, FRef1.FeeReceiveDocId, Sum(FRef1.NetAmount) AS ExcessRefund " & _
                    "                                   FROM Sch_FeeRefund1 FRef1 " & _
                    "                                   WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' " & _
                    "                                   GROUP BY FRef1.DocId, FRef1.FeeReceiveDocId " & _
                    "                                   ) vFRef1 On vFRef1.DocId = FRef.DocId " & _
                    "                       Where FRef.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
                    "                       GROUP BY vFRef1.FeeReceiveDocId " & _
                    "                       ) As vFRef On Fr.DocId = vFRef.FeeReceiveDocId " & _
                    "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
                    "           GROUP BY Fr.AdmissionDocId) As V2 On Adm.DocId = V2.AdmissionDocId " & _
                    " Where Adm.DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
                    " Group By Adm.DocId "

            bAdvanceAmount = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
        Catch ex As Exception
            bAdvanceAmount = 0
            MsgBox(ex.Message)
        Finally
            FunGetAdvanceAmount = bAdvanceAmount
        End Try
    End Function

    Private Sub ProcValidatingControls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtV_Type.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblV_Type.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                    End If
                    DrTemp = Nothing
                End If

        End Select
    End Sub

End Class
