Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAreamast
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1_Fee As Byte = 1
    Private Const Col1_Amount As Byte = 2
    Private Const Col1FeeType As Byte = 3
    Private Const Col1DueMonth As Byte = 4

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
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Fee", 250, 50, "Fee Head", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1Amount", 100, 8, 2, False, "Amount", True, False, True)            
            .AddAgTextColumn(DGL1, "DGL1ChargeType", 100, 20, "Fee Type", True, False, False, True)
            .AddAgListColumn(DGL1, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "DGL1DueMonth", 70, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "Due Month", True, False)
        End With
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
            AgL.WinSetting(Me, 350, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText(False)
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Sch_Area.Code As SearchCode " & _
        " From Sch_Area "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "Select Code  As Code, ManualCode As Name From Sch_Area " & _
            "  Order By ManualCode"
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, Description As Name From Sch_Area " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select F.Code , S.Name As Name " & _
                " From Sch_Fee F " & _
                " Left Join SubGroup S On F.Code = S.SubCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & " " & _
                " Order By S.Name "
        DGL1.AgHelpDataSet(Col1_Fee) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT FT.Code AS Code,FT.Code AS Description " & _
             " FROM Sch_FeeType FT "

        DGL1.AgHelpDataSet(Col1FeeType) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtDescription.Focus()
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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_Area Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtDescription.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select Sch_Area.Code As SearchCode, Sch_Area.Description As [" & LblDescription.Text & "]  From  Sch_Area "


            AgL.PubFindQryOrdBy = "[" & LblDescription.Text & "]"


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
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Area List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select Sch_Area.Code, Sch_Area.Description As [" & LblDescription.Text & "]  From  Sch_Area "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Area List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If AgL.RequiredField(TxtDescription, LblDescription.Text) Then Exit Sub

            If Topctrl1.Mode = "Add" Then
                If TxtManualCode.Text.Trim <> "" Then
                    AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Area Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                    If AgL.ECmd.ExecuteScalar() > 0 Then
                        If TxtManualCode.Visible Then
                            MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Sub
                        Else
                            TxtManualCode.Text = ""
                        End If
                    End If
                End If

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Area Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Sub

                mSearchCode = AgL.GetMaxId("Sch_Area", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)

                If TxtManualCode.Text.Trim = "" Then TxtManualCode.Text = mSearchCode

            Else
                If TxtManualCode.Text.Trim <> "" Then
                    AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Area Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                    If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Sub
                End If

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Area Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Sub
            End If


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into Sch_Area (Code, ManualCode, Description, Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) Values('" & mSearchCode & "', " & AgL.Chk_Text(TxtManualCode.Text) & ", " & AgL.Chk_Text(TxtDescription.Text) & ",  '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_Area Set ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", Description = " & AgL.Chk_Text(TxtDescription.Text) & ", Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E' Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Dim mSr As Integer = 0
            Dim I As Integer

            mQry = "Delete from TP_AreaFee Where Code = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL1
                mSr = mSr + 1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1_Fee, I).Value <> "" Then                    
                        mQry = "Insert Into TP_AreaFee(Code, Sr, Fee, Amount, FeeType, DueMonth) Values(" & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1_Fee, I)) & "," & Val(.Item(Col1_Amount, I).Value) & "," & AgL.Chk_Text(.AgSelectedValue(Col1FeeType, I)) & "," & AgL.Chk_Text(.Item(Col1DueMonth, I).Value) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If

                Next I
            End With




            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False
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
        Dim MastPos As Long
        Dim I As Integer

        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select Sch_Area.* " & _
                    " From Sch_Area Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtManualCode.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                    End If
                End With



                mQry = "Select F.* " & _
                        " From TP_AreaFee F " & _
                        " Where F.Code='" & mSearchCode & "' Order By F.Sr"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1_Fee, I) = AgL.XNull(.Rows(I)("FEE"))
                            DGL1.Item(Col1_Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.AgSelectedValue(Col1FeeType, I) = AgL.XNull(.Rows(I)("FeeType"))
                            DGL1.Item(Col1DueMonth, I).Value = AgL.XNull(.Rows(I)("DueMonth"))
                        Next I
                    End If
                End With

            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub
    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub
    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
       TxtManualCode.Validating, TxtDescription.Validating
        Try
            Select Case sender.NAME
                Case TxtDescription.Name
                    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
