Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmFeeDueEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1Fee As Byte = 2
    Private Const Col1MonthYear As Byte = 3
    Private Const Col1Amount As Byte = 4
    Private Const Col1IsReversePostable As Byte = 5
    Private Const Col1IsReversePosted As Byte = 6
    Private Const Col1Code As Byte = 7

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
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 50, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1AdmissionDocId", 300, 8, "Student", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Item", 250, 30, "Fee", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1DueMonth", 80, 30, "Due Month", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Amount", True, False, True)
            .AddAgYesNoColumn(DGL1, "Is Reverse Postable", 60, "Is Reverse Postable", True, True, False)
            .AddAgYesNoColumn(DGL1, "Is Reverse Posted", 60, "Is Reverse Posted", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 100, 8, "Code", False, False, False)
        End With

        DGL1.ColumnHeadersHeight = 60
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
            AgL.WinSetting(Me, 650, 880, 0, 0)
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
        If AgL.PubMoveRecApplicable Then
            mQry = "Select ST.DocId As SearchCode " & _
                    " From Sch_FeeDue ST " & _
                    " Left Join Voucher_Type Vt On St.V_Type = Vt.V_Type " & _
                    " Where St.V_Date Between Case Vt.NCat When " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & " Then " & AgL.ConvertDate(CDate(AgL.PubStartDate).AddDays(-1)) & " Else " & AgL.ConvertDate(AgL.PubStartDate) & "  End  And " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " And " & AgL.PubSiteCondition("St.Site_Code", AgL.PubSiteCode) & " " & _
                    " And Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ")"
            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                    " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Vt.V_Type As Code, Vt.Description As [Voucher Type], Vt.Category, Vt.Ncat " & _
                    " From Voucher_Type Vt " & _
                     " where Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ")" & _
                    " Order By Vt.Description"
            TxtV_Type.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.Description AS ClassSection, S.Semester, S.Section,C.SerialNo  " & _
                      " FROM Sch_StreamYearSemester S WITH (NoLock) " & _
                      " LEFT JOIN Sch_Semester C WITH (NoLock) ON C.Code = S.Semester " & _
                      " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                      " Order By C.SerialNo "
            TxtClass.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], P.CurrentSemesterCode " & _
                    " FROM ViewSch_Admission V1 " & _
                    " LEFT JOIN (SELECT Ap.AdmissionDocId, Ap.FromStreamYearSemester AS CurrentSemesterCode FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) P ON V1.DocId = P.AdmissionDocId " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            DGL1.AgHelpDataSet(Col1AdmissionDocId, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select F.Code, F.Name as [Fee], F.ManualCode " & _
                    " From ViewSch_Fee F " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                    " Order By F.Name "
            DGL1.AgHelpDataSet(Col1Fee) = AgL.FillData(mQry, AgL.GCn)
            TxtFee.AgHelpDataSet = DGL1.AgHelpDataSet(Col1Fee).Copy
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Dim DrTemp As DataRow() = Nothing
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtDocId.Enabled = False
        TxtSite_Code.Enabled = False
        TxtAmount.Enabled = False
        TxtMonthStartDate.Text = CDate(AgL.PubLoginDate).ToString("MMM/yyyy")

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.ReadOnly = True
            TxtV_Date.Focus()
        Else
            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & "")
            If DrTemp IsNot Nothing Then
                TxtV_Type.AgSelectedValue = Academic_ProjLib.ClsMain.NCat_FeeDue
                LblV_Type.Tag = Academic_ProjLib.ClsMain.NCat_FeeDue
            Else
                TxtV_Type.AgSelectedValue = ""
                LblV_Type.Tag = ""
            End If
            DrTemp = Nothing

            TxtV_Type.Enabled = True
            TxtV_Type.ReadOnly = False
            TxtV_Date.Focus()
        End If

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtClass.Focus()
        End If

    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue1 Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl1_tbRef()
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

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
        TxtDocId.Enabled = False
        TxtSite_Code.Enabled = False
        TxtAmount.Enabled = False

        TxtV_No.Enabled = False
        TxtV_Type.Enabled = False

    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Dim bBlnIsStudnetWise As Boolean = False
        Try
            If MsgBox("Want To Find Student Wise Due?...", MsgBoxStyle.YesNo, "Fee Due Entry") = MsgBoxResult.Yes Then
                bBlnIsStudnetWise = True

                AgL.PubFindQry = "Select  Fd1.Code As SearchCode, A.StudentName AS [Student], A.AdmissionID, A.RollNo, A.EnrollmentNo,  SgF.Name AS [Fee Head], Fd1.Amount AS [Fee Due Amount],  " & _
                                    " Case When IsNull(Fd1.IsReversePostable,0) <> 0 Then 'Yes' Else 'No' End As [Is Reverse Postable], Convert(nVarChar,ST.V_Date,3) As [Voucher Date], " & _
                                    " " & AgL.V_No_Field("ST.DocId") & " As [Voucher No.], S.StreamYearSemesterDesc as [Semester], " & _
                                    " St.TotalAmount as [Total Amount], Vt.Description AS [Voucher Type], ST.Remark as Remark, SiteMast.Name As [Site/Branch Name] " & _
                                    " From  Sch_FeeDue ST " & _
                                    " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd1.DocId = ST.DocId " & _
                                    " LEFT JOIN ViewSch_Admission A ON A.DocId = Fd1.AdmissionDocId " & _
                                    " LEFT JOIN SubGroup SgF ON SgF.SubCode = Fd1.Fee " & _
                                    " Left Join  SiteMast  On SiteMast.Code = ST.Site_Code " & _
                                    " Left Join Voucher_Type Vt On St.V_Type = Vt.V_Type " & _
                                    " LEFT JOIN ViewSch_StreamYearSemester S ON ST.StreamYearSemester=S.Code " & _
                                    " Where St.V_Date Between Case Vt.NCat When " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & " Then " & AgL.ConvertDate(CDate(AgL.PubStartDate).AddDays(-1)) & " Else " & AgL.ConvertDate(AgL.PubStartDate) & "  End  And " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                                    " And " & AgL.PubSiteCondition("St.Site_Code", AgL.PubSiteCode) & " " & _
                                    " And Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ")  AND Fd1.Code IS NOT NULL  "
            Else
                AgL.PubFindQry = "Select  ST.DocId As SearchCode,  Convert(nVarChar,ST.V_Date,3) As [Voucher Date], " & _
                                    " " & AgL.V_No_Field("ST.DocId") & " As [Voucher No.], S.StreamYearSemesterDesc as [Semester], " & _
                                    " St.TotalAmount as [Total Amount], Vt.Description AS [Voucher Type], ST.Remark as Remark, " & _
                                    " SiteMast.Name As [Site/Branch Name] " & _
                                    " From  Sch_FeeDue ST " & _
                                    " Left Join  SiteMast  On SiteMast.Code = ST.Site_Code " & _
                                    " Left Join Voucher_Type Vt On St.V_Type = Vt.V_Type " & _
                                    " LEFT JOIN ViewSch_StreamYearSemester S ON ST.StreamYearSemester=S.Code " & _
                                    " Where St.V_Date Between Case Vt.NCat When " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & " Then " & AgL.ConvertDate(CDate(AgL.PubStartDate).AddDays(-1)) & " Else " & AgL.ConvertDate(AgL.PubStartDate) & "  End  And " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                                    " And " & AgL.PubSiteCondition("St.Site_Code", AgL.PubSiteCode) & " " & _
                                    " And Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ")"
            End If

            AgL.PubFindQryOrdBy = "[SearchCode]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If bBlnIsStudnetWise Then
                    AgL.PubSearchRow = AgL.Dman_Execute("SELECT Fd1.DocId  FROM Sch_FeeDue1 Fd1 WHERE Fd1.Code ='" & AgL.PubSearchRow & "'", AgL.GcnRead).ExecuteScalar
                End If

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

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub


    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Fee Due"
            RepName = "Academic_Main_FeeDue" : RepTitle = "Fee Due"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT VFD.DocId," & AgL.V_No_Field("VFD.DocID") & " AS V_No,VFD.Site_Code,SM.Name AS SiteName ,VFD.V_Date,VFD.TotalAmount,VFD.Remark,VFD.StreamYearSemester ,VSYS.Description as StreamYearSemesterDesc ,LEFT(datename(Month,VFD.MonthStartDate),3) as DueMonth, " & _
                    " VFD.FeeCode ,SF.name AS Fee,VFD.DueAmount ,VFD.AdmissionDocId,VSA.StudentName,VFD.PreparedBy  " & _
                    " FROM ViewSch_FeeDue VFD " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=VFD.Site_Code  " & _
                    " LEFT JOIN viewSch_Fee SF ON SF.Code=VFD.FeeCode  " & _
                    " LEFT JOIN Sch_StreamYearSemester VSYS ON VSYS.Code=VFD.StreamYearSemester " & _
                    " LEFT JOIN ViewSch_Admission VSA ON VSA.DocId=VFD.AdmissionDocId  " & _
                    " WHERE VFD.DocId='" & mDocId & "' "


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0, J As Integer
        Dim mTrans As Boolean = False, mFlagBln As Boolean = False
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            With bFeeDueObj
                .DocId = mSearchCode
                .Div_Code = AgL.PubDivCode
                .Site_Code = TxtSite_Code.AgSelectedValue
                .V_Type = TxtV_Type.AgSelectedValue
                .V_Prefix = LblPrefix.Text
                .V_No = Val(TxtV_No.Text)
                .V_Date = TxtV_Date.Text
                .Remark = TxtRemark.Text
                .TotalAmount = Val(TxtAmount.Text)
                .StreamYearSemester = TxtClass.AgSelectedValue
                .StreamYearSemesterDesc = TxtClass.Text
            End With

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .AgSelectedValue(Col1Fee, I) <> "" Then

                        If mFlagBln = False Then
                            J = 0
                            mFlagBln = True
                        Else
                            J = UBound(bFeeDue1Obj) + 1
                        End If
                        ReDim Preserve bFeeDue1Obj(J)
                        bFeeDue1Obj(J).FeeDue1()

                        bFeeDue1Obj(J).Code = .Item(Col1Code, I).Value
                        bFeeDue1Obj(J).DocId = mSearchCode
                        bFeeDue1Obj(J).AdmissionDocId = .AgSelectedValue(Col1AdmissionDocId, I)
                        bFeeDue1Obj(J).Fee = .AgSelectedValue(Col1Fee, I)
                        bFeeDue1Obj(J).IsReversePostable = AgL.StrCmp(.Item(Col1IsReversePostable, I).Value, "Yes")
                        bFeeDue1Obj(J).Amount = Val(.Item(Col1Amount, I).Value)
                        bFeeDue1Obj(J).MonthStartDate = CDate(AgL.XNull(.Item(Col1MonthYear, I).Value)).ToString("01/MMM/yyyy")

                    End If
                Next
            End With


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeDueObj, bFeeDue1Obj)
            Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeDueObj, AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue))

            Call AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            Call AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""
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
        Dim I As Integer
        Dim mTransFlag As Boolean = False

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Count > 0 Then
                    MastPos = BMBMaster.Position
                    mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                Else
                    mSearchCode = ""
                End If
            Else
                mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then

                mQry = "Select ST.*, Vt.NCat " & _
                        " From Sch_FeeDue ST " & _
                        " Left Join Voucher_Type Vt On st.V_Type = Vt.V_Type " & _
                        " Where st.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = AgL.RetDate(AgL.XNull(.Rows(0)("V_Date")))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCAt"))
                        TxtClass.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        TxtAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With




                mQry = "Select st.* From Sch_FeeDue1 st " & _
                        " Where st.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            If AgL.XNull(.Rows(I)("MonthStartDate")) <> "" Then
                                DGL1.Item(Col1MonthYear, I).Value = CDate(.Rows(I)("MonthStartDate")).ToString("MMM/yyyy")
                            End If
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1IsReversePostable, I).Value = IIf(AgL.VNull(.Rows(I)("IsReversePostable")), "Yes", "No")
                            DGL1.Item(Col1IsReversePosted, I).Value = IIf(AgL.VNull(.Rows(I)("IsReversePosted")), "Yes", "No")

                            If AgL.VNull(.Rows(I)("IsReversePosted")) Then
                                If mTransFlag = False Then mTransFlag = True
                            End If

                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))


                        Next I
                    End If
                End With
            Else
                BlankText()
            End If

            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
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
        End Try
    End Sub
    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = "" : LblPrefix.Text = ""

        LblV_Type.Tag = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If

    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtV_No.Enabled = False
        TxtSite_Code.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtV_Type.Enabled = False
            TxtClass.Enabled = False

            If TxtMonthStartDate.Text.ToString.Trim <> "" Then
                DGL1.Columns(Col1MonthYear).ReadOnly = True
                DGL1.Columns(Col1MonthYear).DefaultCellStyle.BackColor = Color.LightYellow
            End If

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
                Case Col1AdmissionDocId
                    If TxtClass.Text.Trim <> "" Then
                        DGL1.AgRowFilter(Col1AdmissionDocId) = " CurrentSemesterCode = " & AgL.Chk_Text(TxtClass.AgSelectedValue) & " "
                    Else
                        DGL1.AgRowFilter(Col1AdmissionDocId) = ""
                    End If
            End Select
        Catch ex As Exception

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

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1AdmissionDocId
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        '<Executable Code>
                    Else
                        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                            If TxtClass.Text.Trim = "" Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                TxtClass.AgSelectedValue = AgL.XNull(DrTemp(0)("CurrentSemesterCode"))
                            End If

                            If TxtClass.Text.Trim <> "" Then
                                If TxtClass.Enabled = True Then TxtClass.Enabled = False
                            End If
                        End If
                    End If
                Case Col1MonthYear
                    DGL1.Item(Col1MonthYear, mRowIndex).Value = CDate(DGL1.Item(Col1MonthYear, mRowIndex).Value).ToString("MMM/yyyy")
                Case Col1Fee
                    If AgL.XNull(DGL1.Item(Col1Fee, mRowIndex).Value) <> "" And TxtMonthStartDate.Text.ToString.Trim <> "" Then
                        DGL1.Item(Col1MonthYear, mRowIndex).Value = CDate(TxtMonthStartDate.Text).ToString("MMM/yyyy")
                    End If


            End Select
            Call Calculation()
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

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If TxtClass.Enabled = False Then TxtClass.Enabled = True
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
         TxtV_Type.Enter
        Try
            Select Case sender.name
                'Case TxtAcCode.Name
                '    Call IniAccountHelp(False)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_Type.Validating, TxtClass.Validating, TxtMonthStartDate.Validating

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

                Case TxtClass.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            '<Executable Code>
                        End If
                    End If

                Case TxtMonthStartDate.Name
                    Call ProcValidatingControls(sender)


                Case TxtV_Date.Name
                    'If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    Call ProcValidatingControls(sender)
               

            End Select


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
    Private Sub ProcValidatingControls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtMonthStartDate.Name
                If TxtMonthStartDate.Text.Trim = "" Then
                    LblMonthStartDate.Tag = ""
                    TxtV_Date.Text = CDate(AgL.PubLoginDate).ToString("01/MMM/yyyy")
                Else
                    TxtMonthStartDate.Text = CDate(TxtMonthStartDate.Text).ToString("MMM/yyyy")
                    LblMonthStartDate.Tag = CDate(TxtMonthStartDate.Text).ToString("01/MMM/yyyy")
                    TxtV_Date.Text = CDate(TxtMonthStartDate.Text).ToString("01/MMM/yyyy")
                End If


            Case TxtV_Date.Name
                If TxtV_Date.Text.Trim = "" Then
                    TxtV_Date.Text = CDate(TxtMonthStartDate.Text).ToString("01/MMM/yyyy")
                End If
                If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) Then
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)
                End If

        End Select
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim mPostAC As String = ""
        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function


            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) Then
                If CDate(TxtV_Date.Text) > CDate(AgL.PubStartDate) Then
                    MsgBox("Voucher Date Can't Be Greater Than From " & AgL.PubStartDate & "!...")
                    TxtV_Date.Focus() : Exit Function
                ElseIf CDate(TxtV_Date.Text) < CDate(AgL.PubStartDate).AddDays(-1) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & Format(CDate(AgL.PubStartDate).AddDays(-1), AgLibrary.ClsConstant.DateFormat_ShortDate) & "!...")
                    TxtV_Date.Focus() : Exit Function
                End If
            Else
                If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            End If

            If AgCL.AgIsBlankGrid(DGL1, Col1Fee) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "," & Col1Fee & "," & Col1MonthYear & "") Then Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtAmount.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If DGL1.Item(Col1AdmissionDocId, I).Value Is Nothing Then DGL1.Item(Col1AdmissionDocId, I).Value = ""
                If DGL1.Item(Col1Fee, I).Value Is Nothing Then DGL1.Item(Col1Fee, I).Value = ""
                If DGL1.Item(Col1Amount, I).Value Is Nothing Then DGL1.Item(Col1Amount, I).Value = ""
                If DGL1.Item(Col1IsReversePostable, I).Value Is Nothing Then DGL1.Item(Col1IsReversePostable, I).Value = ""
                If DGL1.Item(Col1IsReversePosted, I).Value Is Nothing Then DGL1.Item(Col1IsReversePosted, I).Value = ""

                If DGL1.Item(Col1IsReversePostable, I).Value.ToString.Trim = "" Then DGL1.Item(Col1IsReversePostable, I).Value = "No"
                If DGL1.Item(Col1IsReversePosted, I).Value.ToString.Trim = "" Then DGL1.Item(Col1IsReversePosted, I).Value = "No"

                If .Item(Col1AdmissionDocId, I).Value <> "" And .Item(Col1Fee, I).Value <> "" Then
                    TxtAmount.Text = Format(Val(TxtAmount.Text) + Val(.Item(Col1Amount, I).Value), "0.00")
                End If
            Next
        End With
    End Sub
    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Call ProcFillCharge()
    End Sub

    Private Sub ProcFillCharge_Backup()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bAdvanceAmount As Double = 0
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            If AgL.RequiredField(TxtMonthStartDate) Then Exit Sub
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            'If FunIsChargeDueExists() Then MsgBox("Fee For """ & TxtMonthStartDate.Text & """ Are Already Due.......!", MsgBoxStyle.Information) : TxtMonthStartDate.Focus() : Exit Sub

            mQry = "SELECT DISTINCT V.* FROM (" & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth = LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3)   " & _
                    " UNION ALL " & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) AND AdmFee.IsFirstTimeRequired<>0  " & _
                    " AND AdmFee.Fee NOT IN ( SELECT CD1.Fee FROM Sch_FeeDue1 CD1  WHERE CD1.AdmissionDocId=AdmFee.DocId ) " & _
                    " UNION ALL " & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth, LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Monthly & "'  " & _
                    " UNION ALL " & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Bimonthly & "' " & _
                    " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%2)=0   " & _
                     " UNION ALL " & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Quaterly & "' " & _
                    " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%3)=0   " & _
                     " UNION ALL " & _
                    " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                    " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                    " AdmFee.FeeStreamYearSemester,AdmFee.FeeType,Admfee.DueMonth,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                    " Admfee.IsFirstTimeRequired, Fd1.Code As FeeDueCode   " & _
                    " FROM Sch_Admission Adm WITH (NoLock)   " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                    " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.HalfYearly & "' " & _
                    " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%6)=0   " & _
                    " ) V "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1(Col1MonthYear, I).ReadOnly = True
                        DGL1(Col1MonthYear, I).Style.BackColor = Color.LightYellow
                        If AgL.XNull(.Rows(I)("DueMonth")) <> "" Then
                            DGL1.Item(Col1MonthYear, I).Value = (.Rows(I)("MonthYear")) & "/" & CDate(LblMonthStartDate.Tag).Year.ToString
                        End If
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I
                Else
                    MsgBox("No Fee Exists To Due!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub ProcFillCharge()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bAdvanceAmount As Double = 0
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            If AgL.RequiredField(TxtMonthStartDate) Then Exit Sub
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If TxtFee.Text.Trim <> "" Then
                If AgL.RequiredField(TxtFeeAmt, LblFeeAmt.Text, True) Then Exit Sub

                mQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student, " & _
                        " Adm.AdmissionID ,  Adm.V_Date, Adm.CurrentSemester AS StreamYearSemester, " & _
                        " " & AgL.Chk_Text(TxtFee.AgSelectedValue) & " AS Fee, " & _
                        " " & Val(TxtFeeAmt.Text) & " AS Amount, " & _
                        " '' AS FeeType, " & AgL.Chk_Text(AgL.MidStr(TxtMonthStartDate.Text, 0, 3)) & " AS MonthYear, " & _
                        " convert(BIT,0) as IsOnceInLife, " & _
                        " convert(BIT,0) IsFirstTimeRequired " & _
                        " FROM Sch_Admission Adm WITH (NoLock) Where  Adm.CurrentSemester = '" & TxtClass.AgSelectedValue & "'"

            Else
                mQry = "SELECT DISTINCT V.* FROM (" & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                        " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth = LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) AND IsNull(AdmFee.IsFirstTimeRequired,0) = 0  " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) AND IsNull(AdmFee.IsFirstTimeRequired,0) <> 0  " & _
                        " AND AdmFee.Fee NOT IN ( SELECT CD1.Fee FROM Sch_FeeDue1 CD1  WHERE CD1.AdmissionDocId=AdmFee.DocId ) " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType, LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Monthly & "'  " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Bimonthly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%2)=0   " & _
                         " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Quaterly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%3)=0   " & _
                         " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.HalfYearly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%6)=0   " & _
                       " ) V Left Join (Select AdmissionDocId,MonthStartDate From Sch_FeeDue1 Where MonthStartDate='" & CDate(LblMonthStartDate.Tag) & "' " & _
                       " )  V2 on V.AdmissionDocId=V2.AdmissionDocId and V.MonthYear=LEFT(datename(Month,V2.MonthStartDate),3) Where V2.AdmissionDocId IS Null"



                mQry = "SELECT DISTINCT V.* FROM (" & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId  " & _
                        " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth = LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) AND IsNull(AdmFee.IsFirstTimeRequired,0) = 0  " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,Admfee.DueMonth as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) AND IsNull(AdmFee.IsFirstTimeRequired,0) <> 0  " & _
                        " AND AdmFee.Fee NOT IN ( SELECT CD1.Fee FROM Sch_FeeDue1 CD1  WHERE CD1.AdmissionDocId=AdmFee.DocId ) " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType, LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Monthly & "'  " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                        " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Bimonthly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%2)=0   " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                         " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.Quaterly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%3)=0   " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                         " UNION ALL " & _
                        " SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student ,  " & _
                        " Adm.AdmissionID ,  Adm.V_Date, AdmFee.StreamYearSemester,Admfee.Fee,Admfee.Amount, " & _
                        " AdmFee.FeeType,LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) as MonthYear,AdmFee.IsOnceInLife, " & _
                        " Admfee.IsFirstTimeRequired   " & _
                        " FROM Sch_Admission Adm WITH (NoLock)   " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId  " & _
                        " Left Join Sch_AdmissionPromotion AdmPro With (NoLock) On AdmPro.AdmissionDocID = Adm.DocID " & _
                        " Where  AdmFee.StreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmFee.DueMonth <>  LEFT(datename(Month,'" & CDate(LblMonthStartDate.Tag) & "'),3) And AdmFee.FeeType = '" & Academic_ProjLib.ClsMain.FeeType.HalfYearly & "' " & _
                        " AND ((month('" & CDate(LblMonthStartDate.Tag) & "')-month('01/'+ Admfee.DueMonth +'/ " & CDate(LblMonthStartDate.Tag).Year.ToString & " '))%6)=0   " & _
                        " And AdmPro.FromStreamYearSemester = '" & TxtClass.AgSelectedValue & "' And AdmPro.PromotionDate Is Null  " & _
                       " ) V Left Join (Select AdmissionDocId,MonthStartDate From Sch_FeeDue1 Where MonthStartDate='" & CDate(LblMonthStartDate.Tag) & "' " & _
                       " )  V2 on V.AdmissionDocId=V2.AdmissionDocId and V.MonthYear=LEFT(datename(Month,V2.MonthStartDate),3) Where V2.AdmissionDocId IS Null"
            End If


            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1(Col1MonthYear, I).ReadOnly = True
                        DGL1(Col1MonthYear, I).Style.BackColor = Color.LightYellow
                        If AgL.XNull(.Rows(I)("MonthYear")) <> "" Then
                            DGL1.Item(Col1MonthYear, I).Value = (.Rows(I)("MonthYear")) & "/" & CDate(LblMonthStartDate.Tag).Year.ToString
                        End If
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I
                Else
                    MsgBox("No Fee Exists To Due!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    'Private Function FunIsChargeDueExists() As Boolean
    '    Dim bFlag As Boolean = False

    '    mQry = "SELECT count(Fd.V_Type) AS Cnt " & _
    '            " FROM Sch_FeeDue1 Cd With (noLock)" & _
    '            " LEFT JOIN Sch_FeeDue Fd With (noLock) ON Cd.DocId = Fd.DocId " & _
    '            " WHERE Fd.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
    '            " AND fd.V_Type in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ") AND Cd.MonthStartDate='" & CDate(LblMonthStartDate.Tag) & "' " & _
    '            " And Fd.StreamYearSemester= '" & TxtStreamYearSemester.AgSelectedValue & "' AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Cd.DocId <> '" & mSearchCode & "' ") & " "

    '    If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then bFlag = True

    '    FunIsChargeDueExists = bFlag
    'End Function

    Private Sub Topctrl1_Load(sender As Object, e As EventArgs) Handles Topctrl1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAcPosting.Click
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0, J As Integer
        Dim mTrans As Boolean = False, mFlagBln As Boolean = False
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            With bFeeDueObj
                .DocId = mSearchCode
                .Div_Code = AgL.PubDivCode
                .Site_Code = TxtSite_Code.AgSelectedValue
                .V_Type = TxtV_Type.AgSelectedValue
                .V_Prefix = LblPrefix.Text
                .V_No = Val(TxtV_No.Text)
                .V_Date = TxtV_Date.Text
                .Remark = TxtRemark.Text
                .TotalAmount = Val(TxtAmount.Text)
                .StreamYearSemester = TxtClass.AgSelectedValue
                .StreamYearSemesterDesc = TxtClass.Text
            End With

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .AgSelectedValue(Col1Fee, I) <> "" Then

                        If mFlagBln = False Then
                            J = 0
                            mFlagBln = True
                        Else
                            J = UBound(bFeeDue1Obj) + 1
                        End If
                        ReDim Preserve bFeeDue1Obj(J)
                        bFeeDue1Obj(J).FeeDue1()

                        bFeeDue1Obj(J).Code = .Item(Col1Code, I).Value
                        bFeeDue1Obj(J).DocId = mSearchCode
                        bFeeDue1Obj(J).AdmissionDocId = .AgSelectedValue(Col1AdmissionDocId, I)
                        bFeeDue1Obj(J).Fee = .AgSelectedValue(Col1Fee, I)
                        bFeeDue1Obj(J).IsReversePostable = AgL.StrCmp(.Item(Col1IsReversePostable, I).Value, "Yes")
                        bFeeDue1Obj(J).Amount = Val(.Item(Col1Amount, I).Value)
                        bFeeDue1Obj(J).MonthStartDate = CDate(AgL.XNull(.Item(Col1MonthYear, I).Value)).ToString("01/MMM/yyyy")

                    End If
                Next
            End With


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeDueObj, AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue))


            AgL.ETrans.Commit()
            mTrans = False
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
