Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)

        Dim FrmObj As Form = Nothing
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(PubModuleName, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End

        If IsEntryPoint Then
            Select Case StrSender
                'Case MDI.MnuAmRegistrationEntry.Name, MDI.MnuRegistrationEntryAuthenticated.Name
                '    FrmObj = New FrmRegistrationEntry(StrUserPermission, DTUP)

                '    If AgL.StrCmp(StrSender, MDI.MnuAmRegistrationEntry.Name) Then
                '        CType(FrmObj, FrmRegistrationEntry).FormType = FrmRegistrationEntry.eFormType.RegistrationEntry

                '    ElseIf AgL.StrCmp(StrSender, MDI.MnuRegistrationEntryAuthenticated.Name) Then
                '        CType(FrmObj, FrmRegistrationEntry).FormType = FrmRegistrationEntry.eFormType.RegistrationEntryAuthenticated
                '    End If

                'Case MDI.MnuAmRegistrationCancelEntry.Name, MDI.MnuRegistrationCancelEntryAuthenticated.Name
                '    FrmObj = New FrmRegistrationCancelEntry(StrUserPermission, DTUP)

                '    If AgL.StrCmp(StrSender, MDI.MnuAmRegistrationCancelEntry.Name) Then
                '        CType(FrmObj, FrmRegistrationCancelEntry).FormType = FrmRegistrationCancelEntry.eFormType.RegistrationCancelEntry

                '    ElseIf AgL.StrCmp(StrSender, MDI.MnuRegistrationCancelEntryAuthenticated.Name) Then
                '        CType(FrmObj, FrmRegistrationCancelEntry).FormType = FrmRegistrationCancelEntry.eFormType.RegistrationCancelEntryAuthenticated
                '    End If


                Case MDI.MnuAmAdmissionEntry.Name, MDI.MnuAdmissionEntryAuthenticated.Name
                    FrmObj = New FrmAdmissionEntry(StrUserPermission, DTUP)

                    If AgL.StrCmp(StrSender, MDI.MnuAmAdmissionEntry.Name) Then
                        CType(FrmObj, FrmAdmissionEntry).FormType = FrmAdmissionEntry.eFormType.AdmissionEntry

                    ElseIf AgL.StrCmp(StrSender, MDI.MnuAdmissionEntryAuthenticated.Name) Then
                        CType(FrmObj, FrmAdmissionEntry).FormType = FrmAdmissionEntry.eFormType.AdmissionEntryAuthenticated
                    End If


                Case MDI.MnuAmEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentMaster.Name
                    FrmObj = New FrmStudentMaster(StrUserPermission, DTUP)

                Case MDI.mnuClassSubjectAllotment.Name
                    FrmObj = New FrmStreamYearSemesterSubject(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentAttendanceEntry.Name
                    FrmObj = New FrmStudentAttendance(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentLeftEntry.Name
                    FrmObj = New FrmStudentLeft(StrUserPermission, DTUP)

                Case MDI.MnuAmStudentPromotionEntry.Name
                    If AgLibrary.ClsConstant.BlnManageUserControl Then
                        FrmObj = New FrmStudentPromotion()
                    Else
                        If MsgBox("This Is A Very Critical Section!..." & vbCrLf & "It Is Suggested To Take Backup Before Proceeding!..." & vbCrLf & "Want To Continue?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                            FrmObj = Nothing
                        Else
                            FrmObj = New FrmStudentPromotion()
                        End If
                    End If

                Case MDI.MnuAmStudentLeaveEntry.Name
                    FrmObj = New FrmStudentLeave(StrUserPermission, DTUP)

                Case MDI.MnuAmTeacherMaster.Name
                    FrmObj = New FrmTeacher(StrUserPermission, DTUP)

                    'Case MDI.MnuAmEnrollmentNoAssignEntry.Name
                    '    FrmObj = New FrmEnrollmentNoAssign(StrUserPermission, DTUP)

                Case MDI.MnuAmRollNoAssignEntry.Name
                    FrmObj = New FrmRollNoAssign(StrUserPermission, DTUP)

                Case MDI.MnuStudentFamilyIncomeEntry.Name
                    FrmObj = New FrmStudentFamilyIncome(StrUserPermission, DTUP)

                Case MDI.MnuDocumentIssueEntry.Name
                    FrmObj = New FrmDocumentIssue(StrUserPermission, DTUP)

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

