Public Class MDIMain
    Private Sub MDIMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim mCount As Integer = 0
        If e.KeyCode = Keys.Escape Then
            For Each ChildForm As Form In Me.MdiChildren
                mCount = mCount + 1
            Next

            If mCount = 0 Then
                If MsgBox("Do You Want to Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'End
                End If
            End If
        End If
    End Sub

    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If AgL Is Nothing Then
            If FOpenIni(StrPath + IniName, AgLibrary.ClsConstant.PubSuperUserName, AgLibrary.ClsConstant.PubSuperUserPassword) Then
                AgIniVar.FOpenConnection("1", "1", False)
            End If

            Dim ClsObj As New ClsMain(AgL, PLib)
            ClsObj.UpdateTableStructure()
            ClsObj = Nothing

            Call IniDtEnviro()
        End If
    End Sub

    Private Sub MnuSalesOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen(sender.name, sender.Text)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

    Private Sub MnuReports_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Dim FrmObj As AgLibrary.RepFormGlobal
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen(e.ClickedItem.Name, e.ClickedItem.Text, False)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

  
    Private Sub MnuTransactions_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) _
        Handles MnuCommonMaster.DropDownItemClicked

        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen(e.ClickedItem.Name, e.ClickedItem.Text)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

    Public Shared Function FunRetLinkForm_CommonMaster(ByVal MasterName As String, ByVal StrUserPermission As String, Optional ByVal DTUP As DataTable = Nothing) As Form
        Dim Mdi As MDIMain = New MDIMain
        Dim DtTemp As DataTable = Nothing
        Dim MnuName$ = "", MnuText$ = "", mQry$ = ""
        Dim CFOpen As New ClsFunction
        Try
            'mQry = " SELECT Vt.MnuName, Vt.MnuText FROM Voucher_Type Vt WHERE Vt.V_Type = '" & MasterName & "'"
            'DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            'With DtTemp
            '    If .Rows.Count > 0 Then
            '        MnuName = AgL.XNull(.Rows(0)("MnuName"))
            '        MnuText = AgL.XNull(.Rows(0)("MnuText"))
            '    End If
            'End With
            'FunRetLinkForm_CommonMaster = CFOpen.FOpen(MnuName, MnuText, True)
            FunRetLinkForm_CommonMaster = Nothing
        Catch ex As Exception
            FunRetLinkForm_CommonMaster = Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Public Class EntryPointName
        Public Const City As String = "City"
        Public Const State As String = "State"
        Public Const Country As String = "Country"
        Public Const LedgerMaster As String = "LedgerMaster"
        Public Const Division As String = "Division"
        Public Const Site As String = "Site"
        Public Const Company As String = "Company"
        Public Const Bank As String = "Bank"

    End Class


End Class
