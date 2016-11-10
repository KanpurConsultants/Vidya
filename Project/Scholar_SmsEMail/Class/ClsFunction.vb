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
            If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuSMSEventMaster.Name
                    FrmObj = New FrmSmsEvent(StrUserPermission, DTUP)

                Case MDI.MnuSMSSend.Name
                    FrmObj = New FrmSms(StrUserPermission, DTUP, AgL)

                Case MDI.MnuSMS_EnvironmentSettings.Name
                    FrmObj = New FrmSmsEnviro(StrUserPermission, DTUP)

                Case MDI.MnuEmployeeCommonSMS.Name
                    FrmObj = New FrmCommonSmsEmployee(StrUserPermission, DTUP)

                    'Case MDI.mnuEnquiryCommonSMS.Name
                    '    FrmObj = New FrmEnquiryCommonSms(StrUserPermission, DTUP)

                Case MDI.MnuStudentCommonSMS.Name
                    FrmObj = New FrmCommonSmsStudent(StrUserPermission, DTUP)
                    CType(FrmObj, TempCommonSmsStudent).SmsCategory = ClsMain.SmsCategorty.CommonStudent

                Case MDI.MnuStudentDueMessage.Name
                    FrmObj = New FrmStudentDueSms(StrUserPermission, DTUP)
                    CType(FrmObj, TempCommonSmsStudent).SmsCategory = ClsMain.SmsCategorty.StudentDueSms

                Case MDI.MnuComposeEMail.Name
                    FrmObj = New FrmComposeEMail(StrUserPermission, DTUP, AgL)

                Case MDI.MnuEMail_EnvironmentSettings.Name
                    FrmObj = New FrmEMailEnviro(StrUserPermission, DTUP)


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

