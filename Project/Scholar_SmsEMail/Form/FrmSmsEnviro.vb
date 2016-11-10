Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSmsEnviro
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
            AgL.WinSetting(Me, 497, 880, 0, 0)
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
                " From Sms_Enviro E " & _
                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.Gcn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtAPICode.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        'Dim BlnTrans As Boolean = False
        'Dim GCnCmd As New SqlClient.SqlCommand
        'Dim MastPos As Long
        'Dim mTrans As Boolean = False


        'Try
        '    MastPos = BMBMaster.Position


        '    If DTMaster.Rows.Count > 0 Then
        '        If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


        '            AgL.ECmd = AgL.Gcn.CreateCommand
        '            AgL.ETrans = AgL.Gcn.BeginTransaction(IsolationLevel.ReadCommitted)
        '            AgL.ECmd.Transaction = AgL.ETrans
        '            mTrans = True
        '            AgL.Dman_ExecuteNonQry("Delete From Enviro_Sale Where ID='" & mSearchCode & "'", AgL.Gcn, AgL.ECmd)


        '            Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.Gcn, AgL.ECmd)

        '            AgL.ETrans.Commit()
        '            mTrans = False

        '            FIniMaster(1)
        '            Topctrl1_tbRef()
        '            Call IniDtSch_Enviro()

        '            MoveRec()
        '        End If
        '    End If
        'Catch Ex As Exception
        '    If mTrans = True Then AgL.ETrans.Rollback()
        '    MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        'End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TcEnviro.SelectedTab = TpParameter
        TxtAPICode.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select  E.Site_Code As SearchCode,  S.Name As [Site Name] " & _
                                " From Sms_Enviro E " & _
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

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sms_Enviro ( Site_Code, APICode, UserName, PassWord, " & _
                        " Div_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.Chk_Text(TxtAPICode.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtUserName.Text) & ", " & AgL.Chk_Text(TxtPassword.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A' )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = "Update Sms_Enviro " & _
                         " SET " & _
                         " APICode =" & AgL.Chk_Text(TxtAPICode.Text) & ", " & _
                         " UserName =" & AgL.Chk_Text(TxtUserName.Text) & ", " & _
                         " PassWord =" & AgL.Chk_Text(TxtPassword.Text) & ", " & _
                         " U_AE = 'E', " & _
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

            Call IniDtSms_Enviro()

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
                        " From Sms_Enviro E " & _
                        " Where E.Site_Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))

                        TxtAPICode.Text = AgL.XNull(.Rows(0)("APICode"))
                        TxtUserName.Text = AgL.XNull(.Rows(0)("UserName"))
                        TxtPassword.Text = AgL.XNull(.Rows(0)("Password"))

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
        TcEnviro.SelectedTab = TpParameter
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

End Class
