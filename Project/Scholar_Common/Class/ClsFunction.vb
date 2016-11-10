Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)

        Dim FrmObj As Form
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain
        Dim TempMdi As New Object

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                'FrmObj = New FrmComposeMail(StrUserPermission, DTUP)

                Case MDI.MnuUniversityMaster.Name
                    FrmObj = New FrmUniversity(StrUserPermission, DTUP)

                Case MDI.MnuAdmissionNatureMaster.Name
                    FrmObj = New FrmAdmissionNature(StrUserPermission, DTUP)

                Case MDI.MnuCategoryMaster.Name
                    FrmObj = New FrmCategory(StrUserPermission, DTUP)

                    'Case MDI.MnuProgrammeNatureMaster.Name
                    '    FrmObj = New FrmProgrammeNature(StrUserPermission, DTUP)

                    'Case MDI.MnuStreamMaster.Name
                    '    FrmObj = New FrmStream(StrUserPermission, DTUP)

                    'Case MDI.MnuProgrammeMaster.Name
                    '    FrmObj = New FrmProgramme(StrUserPermission, DTUP)

                Case MDI.MnuDocumentMaster.Name
                    FrmObj = New FrmDocument(StrUserPermission, DTUP)

                Case MDI.MnuReligionMaster.Name
                    FrmObj = New FrmReligion(StrUserPermission, DTUP)

                Case MDI.MnuOccupationMaster.Name
                    FrmObj = New FrmOccupation(StrUserPermission, DTUP)

                Case MDI.MnuSubjectMaster.Name
                    FrmObj = New FrmSubject(StrUserPermission, DTUP)

                Case MDI.MnuSubjectGroupMaster.Name
                    FrmObj = New FrmSubjectGroup(StrUserPermission, DTUP)

                Case MDI.MnuSemesterMaster.Name
                    FrmObj = New FrmSemester(StrUserPermission, DTUP)

                Case MDI.MnuClassRoomMaster.Name
                    FrmObj = New FrmClassRoom(StrUserPermission, DTUP)

                Case MDI.MnuTimeSlotMaster.Name
                    FrmObj = New FrmTimeSlot(StrUserPermission, DTUP)

                Case MDI.MnuDepartmentMaster.Name
                    FrmObj = New FrmDepartment(StrUserPermission, DTUP)

                Case MDI.MnuLedgerAcMaster.Name
                    TempMdi = AgL.PubMdiParent
                    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.LedgerMaster, StrUserPermission, DTUP)


                Case MDI.MnuDivisionMaster.Name
                    TempMdi = AgL.PubMdiParent
                    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.Division, StrUserPermission, DTUP)

                Case MDI.MnuSiteMaster.Name
                    FrmObj = New FrmSiteMaster(StrUserPermission, DTUP)

                Case MDI.MnuCompanyMaster.Name
                    TempMdi = AgL.PubMdiParent
                    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.Company, StrUserPermission, DTUP)


                    'Case MDI.MnuCountryMaster.Name
                    '    TempMdi = AgL.PubMdiParent
                    '    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.Country, StrUserPermission, DTUP)


                    'Case MDI.MnuStateMaster.Name
                    '    TempMdi = AgL.PubMdiParent
                    '    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.State, StrUserPermission, DTUP)

                    'Case MDI.MnuCityMaster.Name
                    '    TempMdi = AgL.PubMdiParent
                    '    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.City, StrUserPermission, DTUP)

                Case MDI.MnuBankMaster.Name
                    'FrmObj = PObj.FOpen_LinkForm_Common_Master(Academic_Objects.ClsConstant.MenuName_Common_BankMaster, Academic_Objects.ClsConstant.MenuText_Common_BankMaster, MDI, StrUserPermission, DTUP)
                    'If Not AgLibrary.ClsConstant.BlnManageUserControl Then FrmObj = Nothing

                    TempMdi = AgL.PubMdiParent
                    FrmObj = TempMdi.FunRetLinkForm_CommonMaster(MDIMain.EntryPointName.Bank, StrUserPermission, DTUP)


                Case MDI.mnuClassSectionMaster.Name
                    FrmObj = New FrmClassSection(StrUserPermission, DTUP)

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

