Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmLateFeeParameter
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mCode As String = ""


    Public Const Col_SNo As String = "S.No."
    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1_Day As String = "After Day"
    Protected Const Col1_Amount As String = "Amount"
 


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

            .AddAgTextColumn(DGL1, Col_SNo, 40, 5, Col_SNo, True, True, False)
            .AddAgNumberColumn(DGL1, Col1_Day, 90, 3, 0, False, Col1_Day, True, False, True)
            .AddAgNumberColumn(DGL1, Col1_Amount, 100, 8, 3, False, Col1_Amount, True, False, True)

        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
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
        mQry = "Select E.Site_Code As SearchCode " & _
                " From LateFeeParameter E " & _
                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.Gcn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select F.Code, F.Name as [Fee], F.ManualCode,F.FeeNature " & _
                  " From ViewSch_Fee F " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                  " Order By F.Name "
        TxtLateFeeAc.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select '" & ClsMain.LateFeeFor.Student & "' As Code, '" & ClsMain.LateFeeFor.Student & "' As Name " & _
                   " Union All " & _
                   " Select '" & ClsMain.LateFeeFor.DayScholar & "' As Code, '" & ClsMain.LateFeeFor.DayScholar & "' As Name " & _
                   " Union All " & _
                   " Select '" & ClsMain.LateFeeFor.Boarders & "' As Code, '" & ClsMain.LateFeeFor.Boarders & "' As Name "
                  
        TxtFor.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)


    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtLateFeeAc.Focus()
        TxtFor.AgSelectedValue = ClsMain.LateFeeFor.Student

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

                    AgL.Dman_ExecuteNonQry("Delete From LateFeeParameter Where Site_Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


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
        TxtFor.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select  E.Site_Code As SearchCode,  S.Name As [Site Name] " & _
                                " From LateFeeParameter E " & _
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
        Dim I As Integer, mSr As Integer
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mCode = AgL.GetMaxId("LateFeeParameter", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)

                mQry = "INSERT INTO LateFeeParameter (Code, Site_Code, LateFeeFor, LateFeeAC,  " & _
                        " Div_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " '" & mCode & "'," & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ",  " & AgL.Chk_Text(TxtFor.AgSelectedValue) & ", " & AgL.Chk_Text(TxtLateFeeAc.AgSelectedValue) & ", " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A' )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update LateFeeParameter " & _
                        " SET " & _
                        " LateFeeFor = " & AgL.Chk_Text(TxtFor.AgSelectedValue) & ", " & _
                        " LateFeeAC = " & AgL.Chk_Text(TxtLateFeeAc.AgSelectedValue) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                        " Where Site_Code = '" & TxtSite_Code.AgSelectedValue & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From LateFeeParameter1 Where Code = '" & mCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                mSr = 0
                For i = 0 To .Rows.Count - 1
                    If AgL.VNull(.Item(Col1_Day, I).Value) <> 0 Then
                        mSr = mSr + 1
                        mQry = " INSERT INTO LateFeeParameter1(Code,Sr,AfterDay,Amount )" & _
                               " VALUES (" & AgL.Chk_Text(mCode) & "," & mSr & ", " & _
                               "" & Val(.Item(Col1_Day, I).Value) & ",	" & Val(.Item(Col1_Amount, I).Value) & " )"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next i
            End With


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
        Dim I As Integer = 0
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select E.* " & _
                        " From LateFeeParameter E " & _
                        " Where E.Site_Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        mCode = AgL.XNull(.Rows(0)("Code"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtFor.AgSelectedValue = AgL.XNull(.Rows(0)("LateFeeFor"))
                        TxtLateFeeAc.AgSelectedValue = AgL.XNull(.Rows(0)("LateFeeAC"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "SELECT L.* " & _
                     " FROM LateFeeParameter1 L " & _
                     " WHERE L.Code = '" & mCode & "' order by L.Sr  "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1_Day, I).Value = AgL.VNull(.Rows(I)("AfterDay"))
                            DGL1.Item(Col1_Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                        Next I
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            If AgL.RequiredField(TxtSite_Code, "Branch/Site") Then Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtLateFeeAc.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtLateFeeAc.Name
                    If TxtLateFeeAc.AgHelpDataSet IsNot Nothing Then
                        bStrFilter = " 1=1 "
                        bStrFilter += " And FeeNature ='Late Fee'"
                        TxtLateFeeAc.AgRowFilter = bStrFilter
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub


    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        'AgL.FSetSNo(sender, Col_SNo)
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
              
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        With DGL1
            For I = 0 To .Rows.Count - 1
                DGL1.Item(Col1_Amount, I).Value = Format(AgL.VNull(DGL1.Item(Col1_Amount, I).Value), "0.00")
               
            Next
        End With
    End Sub
End Class
