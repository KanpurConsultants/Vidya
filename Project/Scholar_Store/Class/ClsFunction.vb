Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures
   
    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)
        Dim FrmObj As Form
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuItemCategoryMaster.Name
                    FrmObj = New Store.FrmItemCategory(StrUserPermission, DTUP)

                Case MDI.MnuItemGroupMaster.Name
                    FrmObj = New Store.FrmItemGroup(StrUserPermission, DTUP)

                Case MDI.MnuItemMaster.Name
                    FrmObj = New Store.FrmItem(StrUserPermission, DTUP)

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New Store.FrmGodown(StrUserPermission, DTUP)

                Case MDI.MnuPartyMaster.Name
                    FrmObj = New Store.FrmParty(StrUserPermission, DTUP)

                Case MDI.MnuStoreIssueEntry.Name
                    FrmObj = New Store.FrmStoreIssue(StrUserPermission, DTUP, AgTemplate.ClsMain.Temp_NCat.StoreIssue)

                Case MDI.MnuStoreReceiveEntry.Name
                    FrmObj = New Store.FrmStoreIssue(StrUserPermission, DTUP, AgTemplate.ClsMain.Temp_NCat.StoreReceive)

                Case MDI.MnuSaleEntry.Name
                    FrmObj = New FrmSaleInvoice(StrUserPermission, DTUP, "RM")
                    'CType(FrmObj, FrmSaleInvoice).FSetParameter(False, False, False, False, False, False, False, False, False, False, False, False, False, True)

                Case MDI.MnuPurchaseEntry.Name
                    FrmObj = New Purchase.FrmPurchInvoice(StrUserPermission, DTUP, "RM")
                    CType(FrmObj, Purchase.FrmPurchInvoice).FSetParameter(False, False, False, False, False, False, False, False, False, False, False, False, True)

                Case Else
                    FrmObj = Nothing
            End Select
        Else
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)
            CRepProc.GRepFormName = Replace(Replace(StrSenderText, "&", ""), " ", "")
            CRepProc.Ini_Grid()
            FrmObj = ObjRepFormGlobal
        End If
        If FrmObj IsNot Nothing Then
            FrmObj.Text = StrSenderText
        End If
        Return FrmObj
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

