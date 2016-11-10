Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSmsEvent
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Dim mQry As String = "", mSearchCode As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        StrUPVar = StrUPVar.Replace("A", "*")
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
        '<Executable Code>
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
            AgL.WinSetting(Me, 300, 880, 0, 0)
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
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 "

        mQry = "SELECT Event As SearchCode FROM SMS_Event H With (NoLock) " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        Try
            mQry = "Select Event As Code, Event As Name From SMS_Event H With (NoLock) " & _
                    " Order By Event "
            TxtEvent.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Distinct H.Category As Code, H.Category As Name From SMS_Event H With (NoLock) " & _
                    " Where IsNull(H.Category,'') <> '' " & _
                    " Order By H.Category "
            TxtCategory.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtEvent.Focus()
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

                    mQry = "Delete From SMS_Event Where Event = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

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
        TxtCategory.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "SELECT H.Event As SearchCode ,H.Event as [" & LblEvent.Text & "], " & _
                                " H.Category As [" & LblCategory.Text & "], " & _
                                " H.Message As [" & LblMessage.Text & "] " & _
                                " FROM SMS_Event H With (NoLock) "

            AgL.PubFindQryOrdBy = "[" & LblEvent.Text & "]"

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
            AgL.PubReportTitle = "Expense List"

            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select H.Event As [" & LblEvent.Text & "], " & _
                        " H.Category As [" & LblCategory.Text & "], " & _
                        " H.Message As [" & LblMessage.Text & "] " & _
                        " From  SMS_Event H "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = AgL.PubReportTitle
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

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into SMS_Event (Event, Message, Category) Values(" & _
                        " '" & mSearchCode & "', " & _
                        " " & AgL.Chk_Text(TxtMessage.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtCategory.Text) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update SMS_Event Set " & _
                        " Event = " & AgL.Chk_Text(TxtEvent.Text) & ", " & _
                        " Message = " & AgL.Chk_Text(TxtMessage.Text) & ", " & _
                        " Category = " & AgL.Chk_Text(TxtCategory.Text) & " " & _
                        " Where Event='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


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
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select H.* " & _
                  " From SMS_Event h Where H.Event='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtEvent.AgSelectedValue = AgL.XNull(.Rows(0)("Event"))
                        TxtCategory.Text = AgL.XNull(.Rows(0)("Category"))
                        TxtMessage.Text = AgL.XNull(.Rows(0)("Message"))
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

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtEvent.Enabled = False
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtEvent.Validating
        Try
            Select Case sender.NAME
                Case TxtEvent.Name
                    '<Executable Code>
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            If AgL.RequiredField(TxtEvent, LblEvent.Text) Then Exit Function

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SMS_Event Where Event='" & TxtEvent.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Evnet Already Exist!") : TxtEvent.Focus() : Exit Function

                mSearchCode = TxtEvent.Text
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SMS_Event Where Event='" & TxtEvent.Text & "' And Event<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Event Already Exist!") : TxtEvent.Focus() : Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
End Class
