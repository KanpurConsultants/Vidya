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
                Case MDI.MnuFmFeeMaster.Name
                    FrmObj = New FrmFee(StrUserPermission, DTUP)
                    'FrmObj = New FrmAdvanceReminder()

                Case MDI.MnuFmFeeGroupMaster.Name
                    FrmObj = New FrmFeeGroup(StrUserPermission, DTUP)

                Case MDI.MnuFmStreamYearSemesterFeeMaster.Name
                    FrmObj = New FrmStreamYearSemesterFee(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeRefundEntry.Name
                    FrmObj = New FrmFeeRefundEntry(StrUserPermission, DTUP)

                Case MDI.MnuFmReceiveEntry.Name
                    FrmObj = New FrmAdvance(StrUserPermission, DTUP)

                Case MDI.mnuFeeReAssignEntry.Name
                    FrmObj = New FrmSemesterFeeAssign(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeDueEntry.Name
                    FrmObj = New FrmFeeDueEntry(StrUserPermission, DTUP)

                Case MDI.MnuFmFeeReceiveEntry.Name
                    FrmObj = New FrmFeeReceiveEntry(StrUserPermission, DTUP)

                Case MDI.MnuAdvanceReminder.Name
                    FrmObj = New FrmAdvanceReminder()


                Case MDI.MnuFeeStructureChangeEntry.Name
                    FrmObj = New FrmStudentFeeChange(StrUserPermission, DTUP)

                Case MDI.MnuInstallmentCreateEntry.Name
                    FrmObj = New FrmInstallmentCreate(StrUserPermission, DTUP)

                Case MDI.MnuInstallmentReminder.Name
                    FrmObj = New FrmInstallmentReminder()

                Case MDI.mnuLateFeeParameter.Name
                    FrmObj = New FrmLateFeeParameter(StrUserPermission, DTUP)

                    'Case MDI.MnuScholarshipParameter.Name
                    '    FrmObj = New FrmScholarShipParameter(StrUserPermission, DTUP)

                    'Case MDI.MnuScholarshipDemandEntry.Name
                    '    FrmObj = New FrmScholarshipDemand(StrUserPermission, DTUP)

                    'Case MDI.MnuScholarshipReceiveEntry.Name, MDI.MnuScholarshipAdjustmentEntry.Name
                    '    FrmObj = New FrmScholarshipReceive(StrUserPermission, DTUP)

                    '    If AgL.StrCmp(StrSender, MDI.MnuScholarshipReceiveEntry.Name) Then
                    '        CType(FrmObj, FrmScholarshipReceive).FormType = FrmScholarshipReceive.eFormType.ScholarshipReceiveEntry

                    '    ElseIf AgL.StrCmp(StrSender, MDI.MnuScholarshipAdjustmentEntry.Name) Then
                    '        CType(FrmObj, FrmScholarshipReceive).FormType = FrmScholarshipReceive.eFormType.ScholarshipAdjustmentEntry
                    '    End If


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

