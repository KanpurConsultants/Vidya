Imports System.Data.SqlClient

Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Academic"
    Public Const FeeModuleName As String = "Fee"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Class SmsEvent
        Public Const BirthDay_Student As String = "Student Birthday"
        Public Const BirthDay_Employee As String = "Employee Birthday"
        Public Const MarriageAnniversary_Employee As String = "Employee Marriage Anniversary "
        Public Const StudentAdmission As String = "Student Admission"
        Public Const StudentRegistration As String = "Student Registration"
        Public Const StudentAttendance As String = "Student Attendance"
        Public Const StudentLeave As String = "Student Leave"
    End Class


    Public Structure StructTransportMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberCardNo As String
        Public StrCardPrefix As String
        Public StrCardSrNo As Integer
        Public StrValidTillDate As String
        Public StrVehicle As String
        Public StrSeatno As String
        Public StrRoute As String
        Public StrPickupPoint As String
        Public StrUID As String
        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberCardNo = ""
            StrUID = ""
            StrCardPrefix = ""
            StrCardSrNo = 0
            StrValidTillDate = ""
            StrVehicle = ""
            StrSeatno = ""
            StrRoute = ""
            StrPickupPoint = ""
        End Sub
    End Structure

    Public Structure StructMessMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberType As String
        Public StrJoinDate As String
        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberType = ""
            StrJoinDate = ""
        End Sub
    End Structure
    Class MemberType
        Public Const Student As String = "Student"
        Public Const Employee As String = "Employee"
    End Class

#Region "Update Table Structure"
    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

            Call CreateFunction()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< Sch_StreamYearSemester >==================================================
            If AgL.IsConstraintExist("IX_Sch_SessionProgrammeStreamYearSemester", "Sch_StreamYearSemester", "SessionProgrammeStreamYear,Semester", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_StreamYearSemester DROP CONSTRAINT [IX_Sch_SessionProgrammeStreamYearSemester]", AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Section", "nvarchar(5)")
            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Description", "nvarchar(255)")

            'If AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Site_Code", "nvarchar(2)") Then
            '    mQry = "UPDATE Sch_StreamYearSemester " & _
            '            " SET Sch_StreamYearSemester.Site_Code = V.Site_Code " & _
            '            " FROM ( " & _
            '            " 	SELECT Sem.Code, Sp.Site_Code, Sp.Div_Code  " & _
            '            " 	FROM Sch_StreamYearSemester Sem " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStreamYear Yr ON Yr.Code = Sem.SessionProgrammeStreamYear  " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStream Stream ON Stream.Code = Yr.SessionProgrammeStream  " & _
            '            " 	INNER JOIN Sch_SessionProgramme Sp ON Sp.Code = Stream.SessionProgramme  " & _
            '            " ) AS V " & _
            '            " WHERE Sch_StreamYearSemester.Code = V.Code "
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            'End If

            'If AgL.IsFieldExist("Site_Code", "Sch_StreamYearSemester", AgL.GCn) Then
            '    AgL.AddForeignKey(AgL.GCn, "FK_Sch_StreamYearSemester_Site_Code", "SiteMast", "Sch_StreamYearSemester", "Code", "Site_Code")
            'End If

            'If AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Div_Code", "nvarchar(1)") Then
            '    mQry = "UPDATE Sch_StreamYearSemester " & _
            '            " SET Sch_StreamYearSemester.Div_Code = V.Div_Code " & _
            '            " FROM ( " & _
            '            " 	SELECT Sem.Code, Sp.Site_Code, Sp.Div_Code  " & _
            '            " 	FROM Sch_StreamYearSemester Sem " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStreamYear Yr ON Yr.Code = Sem.SessionProgrammeStreamYear  " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStream Stream ON Stream.Code = Yr.SessionProgrammeStream  " & _
            '            " 	INNER JOIN Sch_SessionProgramme Sp ON Sp.Code = Stream.SessionProgramme  " & _
            '            " ) AS V " & _
            '            " WHERE Sch_StreamYearSemester.Code = V.Code "
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            'End If

            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "PreparedBy", "nVarChar(10)")
            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "U_EntDt", "DATETIME")
            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "U_AE", "nVarChar(1)")
            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Edit_Date", "DATETIME")
            AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "ModifiedBy", "nVarChar(10)")
            ''============================< ************************** >==================================================
            ''================================<< Lib_MemberType >>====================================================================
            AgL.AddNewField(AgL.GCn, "Lib_MemberType", "Site_Code", "nVarChar(2)")
            AgL.AddNewField(AgL.GCn, "Lib_MemberType_Log", "Site_Code", "nVarChar(2)")

            AgL.AddNewField(AgL.GCn, "Lib_Member", "Site_Code", "nVarChar(2)")
            AgL.AddNewField(AgL.GCn, "Lib_Member_Log", "Site_Code", "nVarChar(2)")
            AgL.AddNewField(AgL.GCn, "SiteMast", "IsLibrary", "bit", 0)

            ''============================< Sch_Admission >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "AdmissionIdSr", "BigInt", 0)
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "AdmissionIdPrefix", "nVarChar(20)")

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "AdmissionSemester", "nVarChar(10)") Then
                mQry = "UPDATE Sch_Admission " & _
                        " SET Sch_Admission.AdmissionSemester = V.FromStreamYearSemester " & _
                        " FROM ( " & _
                        " 	SELECT A.DocId, Ap.FromStreamYearSemester, Ap.ToStreamYearSemester " & _
                        " 	FROM Sch_Admission A " & _
                        " 	INNER JOIN Sch_AdmissionPromotion Ap ON Ap.AdmissionDocId = A.DocId AND Ap.Sr = 1 " & _
                        " ) AS V " & _
                        " WHERE Sch_Admission.DocId = V.DocId "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("AdmissionSemester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_AdmissionSemester", "Sch_StreamYearSemester", "Sch_Admission", "Code", "AdmissionSemester")
            End If

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "PromotionSemester", "nVarChar(10)") Then
                mQry = "UPDATE Sch_Admission " & _
                        " SET Sch_Admission.PromotionSemester = V.ToStreamYearSemester " & _
                        " FROM ( " & _
                        " 	SELECT A.DocId, Ap.FromStreamYearSemester, Ap.ToStreamYearSemester " & _
                        " 	FROM Sch_Admission A " & _
                        " 	INNER JOIN Sch_AdmissionPromotion Ap ON Ap.AdmissionDocId = A.DocId AND Ap.PromotionDate = A.V_Date AND Ap.Sr = 1 " & _
                        " ) AS V " & _
                        " WHERE Sch_Admission.DocId = V.DocId "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("PromotionSemester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_PromotionSemester", "Sch_StreamYearSemester", "Sch_Admission", "Code", "PromotionSemester")
            End If

            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "Sch_Admission", "EnquiryDocId", "nVarChar(21)")
                If AgL.IsFieldExist("EnquiryDocId", "Sch_Admission", AgL.GCn) Then
                    AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_EnquiryDocId", "Enquiry_Enquiry", "Sch_Admission", "DocId", "EnquiryDocId")
                End If
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "RollNo", "nVarChar(60)")
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "Semester", "nVarChar(8)")
            If AgL.IsFieldExist("Semester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Sch_Admission_Semester", "Sch_Semester", "Sch_Admission", "Code", "Semester")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "IsNewStudent", "bit", 0)

            ''============================< Sch_AdmissionPromotion >=====================================
            If AgL.AddNewField(AgL.GCn, "Sch_AdmissionPromotion", "RollNo", "nVarChar(60)") Then
                mQry = "UPDATE Sch_AdmissionPromotion " & _
                            " SET Sch_AdmissionPromotion.RollNo = V.RollNo " & _
                            " FROM ( " & _
                            " 	SELECT A.DocId, A.AdmissionSemester,A.RollNo " & _
                            " 	FROM Sch_Admission A With (NoLock) " & _
                            " ) AS V " & _
                            " WHERE Sch_AdmissionPromotion.AdmissionDocId = V.DocId " & _
                            " and Sch_AdmissionPromotion.FromStreamYearSemester=V.AdmissionSemester"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnRead)
            End If

            ''============================< ***********Sch_AdmissionFeeDetail************** >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionFeeDetail", "FeeType", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionFeeDetail", "DueMonth", "nVarChar(3)")
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionFeeDetail", "IsOnceInLife", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionFeeDetail", "IsFirstTimeRequired", "bit", 0, False)


            ''============================< ************Sch_Registration************** >==================================================
            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "Sch_Registration", "EnquiryDocId", "nVarChar(21)")
                If AgL.IsFieldExist("EnquiryDocId", "Sch_Registration", AgL.GCn) Then
                    AgL.AddForeignKey(AgL.GCn, "FK_Sch_Registration_EnquiryDocId", "Enquiry_Enquiry", "Sch_Registration", "DocId", "EnquiryDocId")
                End If
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Registration", "Semester", "nVarChar(8)")
            If AgL.IsFieldExist("Semester", "Sch_Registration", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Registration_Semester", "Sch_Semester", "Sch_Registration", "Code", "Semester")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStatus", "Semester", "nVarChar(8)")
            If AgL.IsFieldExist("Semester", "Sch_RegistrationStatus", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_RegistrationStatus_Semester", "Sch_Semester", "Sch_RegistrationStatus", "Code", "Semester")
            End If

            ''============================< ************Sch_StudentLeave************** >==================================================
            AgL.AddNewField(AgL.GCn, "Sch_StudentLeave", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "Sch_StudentLeave", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_StudentLeave_SemesterStreamYearSemester", "Sch_StreamYearSemester", "Sch_StudentLeave", "Code", "StreamYearSemester")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            '<Executable Code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            '=========================================================================================================
            '====================< Sch_StreamYearSemester >===========================================================
            '=========================================================================================================
            AgL.EditField("Sch_StreamYearSemester", "SessionProgrammeStreamYear", "nVarChar(8)", AgL.GCn)
            AgL.EditField("Sch_StreamYearSemester", "SemesterStartDate", "SmallDateTime", AgL.GCn)
         
            '====================< Sch_StudentAttendance >===========================================================
            '=========================================================================================================
            AgL.EditField("Sch_StudentAttendance", "TimeSlot", "NVARCHAR (8)", AgL.GCn)
            AgL.EditField("Sch_StudentAttendance", "ClassRoom", "NVARCHAR (8)", AgL.GCn)
            AgL.EditField("Sch_StudentAttendance", "Subject", "NVARCHAR (8)", AgL.GCn)
            AgL.EditField("Sch_StudentAttendance", "Teacher", "NVARCHAR (10)", AgL.GCn)

            If AgL.IsFieldExist("ClassSection", "Sch_StudentAttendance", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_StudentAttendance_Sch_ClassSection", "Sch_StudentAttendance")
            End If
            AgL.AddForeignKey(AgL.GCn, "FK_Sch_StudentAttendance_ClassSection", "Sch_StreamYearSemester", "Sch_StudentAttendance", "Code", "ClassSection")

            If AgL.IsFieldExist("A_Date", "Sch_StudentAttendance", AgL.GCn) _
                 And AgL.IsFieldExist("TimeSlot", "Sch_StudentAttendance", AgL.GCn) _
                  And AgL.IsFieldExist("Teacher", "Sch_StudentAttendance", AgL.GCn) _
                    And AgL.IsFieldExist("Subject", "Sch_StudentAttendance", AgL.GCn) Then

                If AgL.IsConstraintExist("IX_Sch_StudentAttendance_2", "Sch_StudentAttendance", "A_Date,TimeSlot,Teacher,Subject", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_StudentAttendance DROP CONSTRAINT [IX_Sch_StudentAttendance_2]", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("A_Date", "Sch_StudentAttendance", AgL.GCn) _
                And AgL.IsFieldExist("TimeSlot", "Sch_StudentAttendance", AgL.GCn) _
                 And AgL.IsFieldExist("Teacher", "Sch_StudentAttendance", AgL.GCn) Then


                If AgL.IsConstraintExist("IX_Sch_StudentAttendance_1", "Sch_StudentAttendance", "A_Date,TimeSlot,Teacher", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_StudentAttendance DROP CONSTRAINT [IX_Sch_StudentAttendance_1]", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("Div_Code", "Sch_StudentAttendance", AgL.GCn) _
                And AgL.IsFieldExist("Site_Code", "Sch_StudentAttendance", AgL.GCn) _
                 And AgL.IsFieldExist("A_Date", "Sch_StudentAttendance", AgL.GCn) _
                   And AgL.IsFieldExist("ClassSection", "Sch_StudentAttendance", AgL.GCn) _
                     And AgL.IsFieldExist("ClassSectionSubSection", "Sch_StudentAttendance", AgL.GCn) _
                      And AgL.IsFieldExist("ClassRoom", "Sch_StudentAttendance", AgL.GCn) _
                         And AgL.IsFieldExist("TimeSlot", "Sch_StudentAttendance", AgL.GCn) Then

                If AgL.IsConstraintExist("IX_Sch_StudentAttendance", "Sch_StudentAttendance", "Div_Code,Site_Code,A_Date,ClassSection,ClassSectionSubSection,ClassRoom,TimeSlot", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_StudentAttendance DROP CONSTRAINT [IX_Sch_StudentAttendance]", AgL.GCn)
                End If
            End If

            ''*******************************Sch_Student ****************************************
            AgL.EditField("Sch_Student", "FirstName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Sch_Student", "MiddleName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Sch_Student", "LastName", "nVarChar(100)", AgL.GCn)

            ''**************************** Pay_Employee ******************************************
            AgL.EditField("Pay_Employee", "FirstName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Pay_Employee", "MiddleName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Pay_Employee", "LastName", "nVarChar(100)", AgL.GCn)

            ''****************************Sch_RegistrationStudentDetail ****************************
            AgL.EditField("Sch_RegistrationStudentDetail", "FirstName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Sch_RegistrationStudentDetail", "MiddleName", "nVarChar(100)", AgL.GCn)
            AgL.EditField("Sch_RegistrationStudentDetail", "LastName", "nVarChar(100)", AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        '<Executable Code>
    End Sub
    Private Sub CreateFunction()
        Dim mQry$ = "", bStrSch_AdmissionPromotionSql$ = ""
        '' Note Write Each Function in Separate <Try---Catch> Section

        Try
          
            mQry = "CREATE function fn_GetRollNo " & _
                    " (@AdmissionDocId NVARCHAR(21), @Class NVARCHAR(10))     Returns NVARCHAR(60) " & _
                    " AS " & _
                    "   BEGIN  " & _
                    "   Declare @RollNo NVARCHAR(10);  " & _
                    "   SELECT @RollNo = Ap.RollNo  " & _
                    "   FROM Sch_AdmissionPromotion Ap   " & _
                    "   WHERE Ap.AdmissionDocId = @AdmissionDocId  " & _
                    "   AND Ap.FromStreamYearSemester=@Class  " & _
                    "   Return @RollNo " & _
                    "   End "
            AgL.IsFunctionExist("fn_GetRollNo", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsFunctionExist("fn_GetRollNo", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgramme AS " & _
                    " SELECT  SP.*, S.ManualCode AS SessionManualCode, S.Description AS SessionDescription, S.StartDate AS SessionStartDate, S.EndDate AS SessionEndDate, P.Description AS ProgrammeDescription, P.ManualCode AS ProgrammeManualCode, P.ProgrammeDuration, P.Semesters AS ProgrammeSemesters, P.SemesterDuration AS ProgrammeSemesterDuration, P.ProgrammeNature , PN.Description AS ProgrammeNatureDescription  , P.ManualCode  +'/' + S.ManualCode   AS SessionProgramme " & _
                    " FROM Sch_SessionProgramme SP " & _
                    " LEFT JOIN Sch_Session S ON sp.Session =S.Code  " & _
                    " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
                    " LEFT JOIN Sch_ProgrammeNature PN ON P.ProgrammeNature =PN.Code "

            AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgrammeStream As " & _
                    " SELECT SPS.*, P.ManualCode + '/' +  S.ManualCode + '/' +  St.ManualCode AS SessionProgrammeStream, S.ManualCode AS SessionManualCode, " & _
                    " P.ManualCode AS ProgrammeManualCode, St.ManualCode AS StreamManualCode, SP.Div_Code , SP.Site_Code, Sp.SessionProgramme As SessionProgrammeDesc, " & _
                    " S.StartDate As SessionStartDate, Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode " & _
                    " FROM Sch_SessionProgrammeStream SPS " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP ON SP.Code = SPS.SessionProgramme  " & _
                    " LEFT JOIN Sch_Session S ON SP.Session =S.Code  " & _
                    " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
                    " LEFT JOIN Sch_Stream St ON SPS.Stream =St.Code "

            AgL.IsViewExist("ViewSch_SessionProgrammeStream", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgrammeStream", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgrammeStreamYear AS " & _
                    " SELECT SPSY.Code AS SessionProgrammeStreamYearCode, SPSY.SessionProgrammeStream AS SessionProgrammeStreamCode, SPS.Div_Code, SPS.Site_Code, " & _
                    " SPS.SessionProgrammeStream,SPSY.YearSerial,SPSY.YearStartDate, SPS.SessionProgrammeStream + '/' + CONVERT(NVARCHAR, SPSY.YearSerial) AS SessionProgrammeStreamYearDesc, " & _
                    " Convert(VARCHAR(4),DatePart(Year,SPSY.YearStartDate)) + '-' + Convert(VARCHAR(4),DatePart(Year,DateAdd(Day, -1,Dateadd(Year, 1, SPSY.YearStartDate)))) AS AcademicYearDesc  " & _
                    " FROM dbo.Sch_SessionProgrammeStreamYear SPSY " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream SPS On  SPSY.SessionProgrammeStream = SPS.Code"

            AgL.IsViewExist("ViewSch_SessionProgrammeStreamYear", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgrammeStreamYear", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_StreamYearSemester as " & _
                    " SELECT Sem.*,Sem.Description  AS StreamYearSemesterDesc,  " & _
                    " Year.SessionProgrammeStream AS SessionProgrammeStreamDesc, Year.SessionProgrammeStreamCode , Sps.SessionProgramme AS SessionProgrammeCode,  " & _
                    " Sps.SessionManualCode , Sps.ProgrammeManualCode, Sps.StreamManualCode , Sps.Stream AS StreamCode, " & _
                    " Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode, Sp.SessionDescription , Sp.SessionStartDate , Sp.ProgrammeNatureDescription , Sp.ProgrammeNature As ProgrammeNatureCode, " & _
                    " Sp.SessionProgramme AS SessionProgrammeDesc, Year.SessionProgrammeStreamYearDesc , Year.YearSerial , Year.YearStartDate , S.SerialNo AS SemesterSerialNo, S.Description AS SemesterDesc, Year.AcademicYearDesc " & _
                    " FROM Sch_StreamYearSemester Sem  " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear Year ON sem.SessionProgrammeStreamYear =year.SessionProgrammeStreamYearCode  " & _
                    " LEFT JOIN Sch_Semester S ON Sem.Semester =S.Code " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream Sps ON Year.SessionProgrammeStreamCode = Sps.Code  " & _
                    " LEFT JOIN ViewSch_SessionProgramme Sp ON Sps.SessionProgramme = Sp.Code  "

            AgL.IsViewExist("ViewSch_StreamYearSemester", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_StreamYearSemester", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_StreamYearSemesterFee as " & _
                    "SELECT SPSF.Code AS StreamYearSemesterFeeCode, SYS1.SessionProgrammeStreamYear, SPSY.SessionProgrammeStreamYearDesc  ,   SPSF.Fee, SPSF.Amount, S.ManualCode AS FeeManualCode, S.Name AS FeeName, SPSY.YearSerial , SPSY.YearStartDate, SPSY.Div_Code, SPSY.Site_Code   " & _
                    "FROM dbo.Sch_StreamYearSemesterFee SPSF " & _
                    "LEFT JOIN Sch_StreamYearSemester SYS1 ON SPSf.StreamYearSemester = SYS1.Code  " & _
                    "LEFT JOIN ViewSch_SessionProgrammeStreamYear SPSY ON SPSY.SessionProgrammeStreamYearCode = sys1.SessionProgrammeStreamYear  " & _
                    "LEFT JOIN Sch_Fee F ON SPSF.Fee =F.Code  " & _
                    "LEFT JOIN SubGroup S ON F.Code =S.SubCode "
            AgL.IsViewExist("ViewSch_StreamYearSemesterFee", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_StreamYearSemesterFee", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try

            mQry = "CREATE VIEW dbo.ViewSch_Student As " & _
                    " SELECT Sg.Name, Sg.DispName, Sg.ManualCode, Sg.Add1, Sg.add2, Sg.Add3, C.CityCode, " & _
                    " C.CityName, Sg.Site_Code, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, Sg.PAN, " & _
                    " Sg.PAdd1, Sg.PAdd2, Sg.PAdd3, Sg.PCityCode , PC.CityName AS PCityName, Sg.PPin,  " & _
                    " Sg.PPhone, Sg.PMobile, Sg.PFax, Sg.FatherName, Sg.FatherNamePrefix, Sg.HusbandName,  " & _
                    " Sg.HusbandNamePrefix,  Sg.DOB, Sg.Remark, Sg.CommonAc,  S.*,  " & _
                    " Tc.CityName AS TCityName, C1.Description AS CategoryDesc, C1.ManualCode AS CategoryManualCode, R.Description AS ReligionDesc, " & _
                    " Fo.Description AS FatherOccupationDesc, Mo.Description AS MotherOccupationDesc " & _
                    " FROM Sch_Student S   " & _
                    " LEFT JOIN SubGroup Sg ON S.SubCode =Sg.SubCode    " & _
                    " LEFT JOIN City C ON Sg.CityCode =C.CityCode   " & _
                    " LEFT JOIN City PC ON Sg.PCityCode = PC.CityCode  " & _
                    " LEFT JOIN City Tc ON S.TCityCode = Tc.CityCode  " & _
                    " LEFT JOIN Sch_Category C1 ON S.Category = C1.Code  " & _
                    " LEFT JOIN Sch_Religion R ON S.Religion = R.Code  " & _
                    " LEFT JOIN Sch_Occupation Fo ON S.Occupation = Fo.Code  " & _
                    " LEFT JOIN Sch_Occupation Mo ON S.MotherOccupation = Mo.Code "

            AgL.IsViewExist("ViewSch_Student", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_Student", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SemesterSubject As " & _
                    " SELECT Ss.*, S.Description AS SubjectDesc, S.DisplayName AS SubjectDisplayName, S.SubjectType , S.SubjectGroup AS SubjectGroupCode , Sg.Description AS SubjectGroupDesc, " & _
                    " Vs.StreamYearSemesterDesc , Vy.SessionProgrammeStreamYearCode , Vy.SessionProgrammeStreamCode , Vy.SessionProgrammeStream AS SessionProgrammeStreamDesc , Vy.SessionProgrammeStreamYearDesc, " & _
                    " Vs.Div_Code, Vs.Site_Code, Vs.SemesterStartDate  " & _
                    " FROM Sch_SemesterSubject Ss " & _
                    " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                    " LEFT JOIN Sch_SubjectGroup Sg  ON S.SubjectGroup = Sg.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Vs ON Ss.StreamYearSemester = Vs.Code " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear Vy ON Vs.SessionProgrammeStreamYear = Vy.SessionProgrammeStreamYearCode  "

            AgL.IsViewExist("ViewSch_SemesterSubject", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_SemesterSubject", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Admission As " & _
                   " SELECT Adm.*, AdmE.EnrollmentNo , Vs.Name AS StudentName , Vs.DispName  AS StudentDispName, Vs.FatherName , Vs.MotherName , Vs.CityCode , Vs.CityName , Vs.PIN, Vs.CommonAc," & _
                   " VStream.SessionProgrammeStream AS SessionProgrammeStreamDesc, VStream.SessionManualCode , VStream.ProgrammeManualCode, VStream.StreamManualCode, " & _
                   " V1.FromStreamYearSemester, V1.PromotionDate, V1.ToStreamYearSemester, VStream.SessionProgramme As SessionProgrammeCode, VStream.SessionProgrammeDesc, VStream.SessionCode, VStream.ProgrammeCode,  " & _
                   " vS.Phone, vS.Mobile, R.ManualRegNo, Vs.ManualCode As StudentManualCode,SM.Description As CurrentSemesterDesc " & _
                   " FROM Sch_Admission Adm " & _
                   " LEFT JOIN Sch_AdmissionEnrollmentNo AS AdmE ON Adm.DocId = AdmE.DocId  " & _
                   " LEFT JOIN ViewSch_Student Vs ON Adm.Student = Vs.SubCode  " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream VStream ON Adm.SessionProgrammeStream = VStream.Code  " & _
                   " LEFT JOIN Sch_StreamYearSemester SM ON SM.Code=Adm.CurrentSemester" & _
                   " LEFT JOIN Sch_Registration R ON Adm.RegistrationDocId = R.DocId " & _
                   " LEFT JOIN (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.Sr = 1) V1 ON V1.AdmissionDocId = Adm.DocId "

            AgL.IsViewExist("ViewSch_Admission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_Admission", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionPromotion AS " & _
                    " SELECT V2.*, Csa.ClassSectionSubSectionCode, Csa.ClassSectionSubSectionDesc, Csa.SubSection, " & _
                    " Csa.ClassSection AS ClassSectionCode, Csa.ClassSectionDesc, Csa.Section " & _
                    " FROM ( " & _
                    " SELECT V1.*, " & _
                    " 	( " & _
                    " 	SELECT TOP 1 Sa.ClassSectionSemesterAdmissionCode  " & _
                    " 	FROM ViewSch_ClassSectionSemesterAdmission Sa " & _
                    " 	WHERE Sa.AdmissionDocId = V1.AdmissionDocId " & _
                    " 	AND Sa.SemesterStartDate <= V1.AdmissionDate " & _
                    " 	ORDER BY Sa.SemesterStartDate DESC " & _
                    " 	) AS ClassSectionSemesterAdmissionCode " & _
                    " FROM " & _
                    " ( " & _
                    " SELECT  CASE WHEN P.Sr = 1 THEN A.V_Date ELSE P1.PromotionDate  END AS AdmissionDate, " & _
                    " P.* " & _
                    " FROM Sch_AdmissionPromotion P " & _
                    " LEFT JOIN Sch_Admission A ON P.AdmissionDocId = A.DocId " & _
                    " LEFT JOIN Sch_AdmissionPromotion P1 ON P.AdmissionDocId = P1.AdmissionDocId AND P.FromStreamYearSemester = P1.ToStreamYearSemester AND P.Sr = P1.Sr +1 " & _
                    " ) AS V1 " & _
                    " ) AS V2 " & _
                    " LEFT JOIN ViewSch_ClassSectionSemesterAdmission Csa ON V2.ClassSectionSemesterAdmissionCode = CSa.ClassSectionSemesterAdmissionCode "

            AgL.IsViewExist("ViewSch_AdmissionPromotion", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_AdmissionPromotion", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Fee As " & _
                    " SELECT F.*, S.CommonAc, S.ManualCode, S.name, S.DispName, S.groupCode, S.GroupNature, S.Nature, G.GroupName " & _
                    " FROM Sch_Fee F " & _
                    " LEFT JOIN SubGroup S ON F.Code =S.SubCode " & _
                    " LEFT JOIN AcGroup G ON S.GroupCode =G.GroupCode "

            AgL.IsViewExist("ViewSch_Fee", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Fee", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSection As  " & _
                    " SELECT  S.*, C.SessionProgramme + '/' + S.Section AS ClassSectionDesc, " & _
                    " C.SessionProgramme AS SessionProgrammeDesc, C.Div_Code, C.Site_Code, IsNull(V.TotalSubsection,0) As TotalSubsection, " & _
                    " C.Session AS SessionCode, C.SessionManualCode, C.SessionDescription " & _
                    " FROM Sch_ClassSection S " & _
                    " LEFT JOIN ViewSch_SessionProgramme C ON S.SessionProgramme = C.Code " & _
                    " LEFT JOIN (SELECT S.ClassSection , IsNull(Count(S.Code),0) AS TotalSubsection  FROM Sch_ClassSectionSubSection S GROUP BY S.ClassSection ) V ON S.Code = V.ClassSection "

            AgL.IsViewExist("ViewSch_ClassSection", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_ClassSection", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionSemesterAdmission As  " & _
                    " SELECT Ssa.Code + convert(VARCHAR,Ssa.Sr) AS ClassSectionSemesterAdmissionCode, " & _
                    " Ssa.AdmissionDocId , Ssa.Sr, Ssa.ClassSectionSubSection AS ClassSectionSubSectionCode, Ssa.SectionLeftOnDate, S1.ClassSectionSubSectionDesc, S1.SubSection, " & _
                    " Csa.*, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, " & _
                    " Cs.SessionProgramme AS SessionProgrammeCode,  Cs.Section, Cs.SessionProgrammeDesc  ,  " & _
                    " A.AdmissionID , A.StudentName , A.Student AS StudentCode, Sem.StreamYearSemesterDesc , " & _
                    " Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode , " & _
                    " Sem.Semester AS SemesterCode, Sem.SessionProgrammeStreamCode , Sem.SessionProgrammeStreamDesc, " & _
                    " Sem.SemesterStartDate " & _
                    " FROM Sch_ClassSectionSemester Csa " & _
                    " LEFT JOIN Sch_ClassSectionSemesterAdmission Ssa ON Csa.Code = Ssa.Code  " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON Csa.ClassSection = Cs.Code " & _
                    " LEFT JOIN ViewSch_Admission A ON Ssa.AdmissionDocId = A.DocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Csa.StreamYearSemester = sem.Code " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 ON Ssa.ClassSectionSubSection = S1.Code "

            AgL.IsViewExist("ViewSch_ClassSectionSemesterAdmission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_ClassSectionSemesterAdmission", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionSubject As " & _
                    " SELECT V1.*, V2.StreamYearSemester, V2.StreamYearSemesterDesc, V2.SessionProgrammeStreamYearCode, V2.SessionProgrammeStreamCode, V2.SessionProgrammeStreamDesc, V2.SessionProgrammeStreamYearDesc, " & _
                    " V3.Subject AS SubjectCode, V3.ManualCode AS SubjectManualCode, V3.PaperID, V3.MinCreditHours, V3.IsElectiveSubject, V3.SubjectDesc, V3.SubjectDisplayName, V3.SubjectType, V3.SubjectGroupCode, V3.SubjectGroupDesc  " & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT Ads.DocId AS AdmissionDocId, Ads.Sr , Ads.RowId, Ads.SemesterSubject,  " & _
                    " CASE WHEN Ads.OtherSemesterSubject IS NULL THEN Ads.SemesterSubject ELSE Ads.OtherSemesterSubject END OtherSemesterSubject,  " & _
                    " Convert(BIT,CASE WHEN Ads.OtherSemesterSubject IS NULL THEN 0 ELSE 1 END) IsSubjectSwap " & _
                    " FROM Sch_AdmissionSubject Ads " & _
                    " ) V1  " & _
                    " LEFT JOIN ViewSch_SemesterSubject V2 ON V1.SemesterSubject = V2.Code  " & _
                    " LEFT JOIN ViewSch_SemesterSubject V3 ON V1.OtherSemesterSubject = V3.Code  "

            AgL.IsViewExist("ViewSch_AdmissionSubject", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_AdmissionSubject", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionSubSection As " & _
                    " SELECT S.*, V1.ClassSectionDesc + '/' + S.SubSection As ClassSectionSubSectionDesc, " & _
                    " V1.SessionProgramme As SessionProgrammeCode, V1.Section, V1.IsOpenElectiveSection, V1.ClassSectionDesc, " & _
                    " V1.SessionProgrammeDesc, V1.Div_Code, V1.Site_Code " & _
                    " FROM Sch_ClassSectionSubSection S " & _
                    " LEFT JOIN ViewSch_ClassSection V1 ON S.ClassSection = V1.Code "
            AgL.IsViewExist("ViewSch_ClassSectionSubSection", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_ClassSectionSubSection", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionOpenElectiveSemesterAdmission As  " & _
                    " SELECT Ssa.Code + convert(VARCHAR,Ssa.Sr) AS ClassSectionOpenElectiveSemesterAdmissionCode, " & _
                    " Ssa.AdmissionDocId , Ssa.Sr, Ssa.ClassSectionSubSection AS ClassSectionSubSectionCode, Ssa.SectionLeftOnDate, S1.ClassSectionSubSectionDesc, S1.SubSection, " & _
                    " Csa.*, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, " & _
                    " Cs.SessionProgramme AS SessionProgrammeCode,  Cs.Section, Cs.SessionProgrammeDesc, " & _
                    " A.AdmissionID , A.StudentName , A.Student AS StudentCode, Sem.StreamYearSemesterDesc ,  " & _
                    " Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode ,  " & _
                    " Sem.Semester AS SemesterCode, Sem.SessionProgrammeStreamCode , Sem.SessionProgrammeStreamDesc, " & _
                    " Sem.SemesterStartDate " & _
                    " FROM Sch_ClassSectionOpenElectiveSemester Csa   " & _
                    " LEFT JOIN Sch_ClassSectionOpenElectiveSemesterAdmission Ssa ON Csa.Code = Ssa.Code    " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON Csa.ClassSection = Cs.Code   " & _
                    " LEFT JOIN ViewSch_Admission A ON Ssa.AdmissionDocId = A.DocId   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Csa.StreamYearSemester = sem.Code " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 ON Ssa.ClassSectionSubSection = S1.Code  "

            AgL.IsViewExist("ViewSch_ClassSectionOpenElectiveSemesterAdmission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_ClassSectionOpenElectiveSemesterAdmission", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Registration As " & _
                    " SELECT R.*, Rc.DocId AS RegistrationCancelDocId, Rc.V_Date AS CancelVDate, Rc.RefundAmount, " & _
                    " Convert(BIT,CASE WHEN  Rc.DocId IS NULL THEN 0 ELSE 1 END) AS IsCancelled, " & _
                    " Rsd.Student AS StudentCode, Rsd.FirstName, Rsd.MiddleName, Rsd.LastName, Rsd.Add1, Rsd.Add2, Rsd.Add3, Rsd.CityCode, Rsd.PIN, " & _
                    " Rsd.Phone, Rsd.Mobile, Rsd.EMail, Rsd.Sex, Rsd.NationalityCode, Rsd.Occupation, Rsd.DOB, Rsd.FatherName, Rsd.FatherNamePrefix, " & _
                    " Rsd.MotherName, Rsd.MotherNamePrefix, Rsd.FamilyIncome, Rsd.Religion, Rsd.Category, Rsd.IsInternationalStudent, " & _
                    " Rsd.PassportNo, Rsd.VisaExpiryDate, Rsd.VisaType, Rsd.EnglishProficiency_IELTS, Rsd.EnglishProficiency_TOEFL, " & _
                    " Rsd.EnglishProficiency_Others, Rsd.BloodGroup, Rsd.FatherCompany, Rsd.FatherCompanyAddress, Rsd.FatherDesignation, " & _
                    " Rsd.MotherOccupation, Rsd.MotherCompany, Rsd.MotherCompanyAddress, Rsd.MotherDesignation, Rsd.MotherIncome, " & _
                    " Rsd.ScholarshipApplied, Rsd.MarkOfId, Rsd.TAdd1, Rsd.TAdd2, Rsd.TAdd3, Rsd.TCityCode, Rsd.TPin, Rsd.TPhone, Rsd.TMobile, Rsd.TFax, " & _
                    " Rsd.FatherIncome, Rsd.LocalGuardian, Rsd.PAdd1, Rsd.PAdd2, Rsd.PAdd3, Rsd.PCityCode, Rsd.PPin, Rsd.PPhone, Rsd.PMobile, Rsd.PFax, Rsd.IsNewStudent, " & _
                    " Convert(BIT,CASE WHEN A.DocId IS NULL THEN 0 ELSE 1 END) AS IsAdmited, A.DocId AS AdmissionDocId, A.V_Date AS AdmissionVDate, A.SessionProgrammeStream AS AdmissionSessionProgrammeStreamCode, " & _
                    " Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode, Sp.SessionStartDate " & _
                    " FROM Sch_Registration R " & _
                    " Left Join Sch_RegistrationStudentDetail AS Rsd On R.DocId = Rsd.DocId " & _
                    " LEFT JOIN Sch_RegistrationCancel Rc ON R.DocId = Rc.RegistrationDocId " & _
                    " LEFT JOIN Sch_Admission A ON R.DocId = A.RegistrationDocId " & _
                    " Left Join ViewSch_SessionProgramme Sp On R.SessionProgramme = Sp.Code "

            AgL.IsViewExist("ViewSch_Registration", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Registration", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "SELECT A.*, A1.AdmissionDocId, A1.IsPresent, " & _
            '        " ( " & _
            '        " SELECT TOP 1 Oc.OC   " & _
            '        " FROM Sch_SessionProgrammeStreamOC Oc  " & _
            '        " WHERE Oc.SessionProgrammeStream = SemAdm.SessionProgrammeStreamCode  " & _
            '        " AND A.A_Date >= Oc.FromDate " & _
            '        " ORDER BY Oc.FromDate Desc " & _
            '        " ) AS OcCode, Cs.ClassSectionDesc, Css.ClassSectionSubSectionDesc, Sg.Name AS TeacherName, Sg.DispName AS TeacherDispName, Ts.Description TimeSlotDesc, Ts.StartTime, Ts.EndTime " & _
            '        " , Cr.Description ClassRoomDesc, Sub.Description AS SubjectName, Sub.DisplayName AS SubjectDisplayName , Sub.SubjectType , S.Name AS Site_Name " & _
            '        " ,(SELECT P.FromStreamYearSemester   " & _
            '        " FROM ViewSch_AdmissionPromotion P " & _
            '        " WHERE P.AdmissionDocId = A1.AdmissionDocId  " & _
            '        " AND A.A_Date >= P.AdmissionDate  " & _
            '        " AND P.Sr =  " & _
            '        " (SELECT Max(P.Sr) " & _
            '        " FROM ViewSch_AdmissionPromotion P " & _
            '        " WHERE P.AdmissionDocId = A1.AdmissionDocId " & _
            '        " AND A.A_Date >= P.AdmissionDate)) AS CurrentStreamYearSemesterCode  " & _
            '        " FROM Sch_StudentAttendance A " & _
            '        " LEFT JOIN Sch_StudentAttendance1 A1 ON A.Code = A1.Code  " & _
            '        " LEFT JOIN SiteMast S On A.Site_Code = S.Code  " & _
            '        " LEFT JOIN ViewSch_ClassSectionSemesterAdmission SemAdm ON A.ClassSection = SemAdm.Code AND A1.AdmissionDocId = SemAdm.AdmissionDocId  " & _
            '        " LEFT JOIN ViewSch_ClassSection Cs ON A.ClassSection = Cs.Code  " & _
            '        " LEFT JOIN ViewSch_ClassSectionSubSection Css ON A.ClassSectionSubSection = Css.Code  " & _
            '        " LEFT JOIN SubGroup Sg ON A.Teacher = Sg.SubCode  " & _
            '        " LEFT JOIN Sch_TimeSlot Ts ON A.TimeSlot = Ts.Code  " & _
            '        " LEFT JOIN Sch_ClassRoom Cr ON A.ClassRoom = Cr.Code   " & _
            '        " LEFT JOIN Sch_Subject Sub ON A.Subject = Sub.Code "

            mQry = "SELECT A.*, A1.AdmissionDocId, A1.IsPresent, " & _
                    " ( " & _
                    " SELECT TOP 1 Oc.OC   " & _
                    " FROM Sch_SessionProgrammeStreamOC Oc  " & _
                    " WHERE Oc.SessionProgrammeStream = SemAdm.SessionProgrammeStreamCode  " & _
                    " AND A.A_Date >= Oc.FromDate " & _
                    " ORDER BY Oc.FromDate Desc " & _
                    " ) AS OcCode, Cs.ClassSectionDesc, Css.ClassSectionSubSectionDesc, Sg.Name AS TeacherName, Sg.DispName AS TeacherDispName, Ts.Description TimeSlotDesc, Ts.StartTime, Ts.EndTime " & _
                    " , Cr.Description ClassRoomDesc, Sub.Description AS SubjectName, Sub.DisplayName AS SubjectDisplayName , Sub.SubjectType , S.Name AS Site_Name " & _
                    " ,(SELECT TOP 1 P.FromStreamYearSemester   " & _
                    " FROM ViewSch_AdmissionPromotion P " & _
                    " WHERE P.AdmissionDocId = A1.AdmissionDocId  " & _
                    " AND A.A_Date BETWEEN P.AdmissionDate AND CASE WHEN P.PromotionDate IS NULL THEN A.A_Date ELSE P.PromotionDate END ORDER BY P.Sr DESC) AS CurrentStreamYearSemesterCode  " & _
                    " FROM Sch_StudentAttendance A " & _
                    " LEFT JOIN Sch_StudentAttendance1 A1 ON A.Code = A1.Code  " & _
                    " LEFT JOIN SiteMast S On A.Site_Code = S.Code  " & _
                    " LEFT JOIN ViewSch_ClassSectionSemesterAdmission SemAdm ON A.ClassSection = SemAdm.Code AND A1.AdmissionDocId = SemAdm.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON A.ClassSection = Cs.Code  " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection Css ON A.ClassSectionSubSection = Css.Code  " & _
                    " LEFT JOIN SubGroup Sg ON A.Teacher = Sg.SubCode  " & _
                    " LEFT JOIN Sch_TimeSlot Ts ON A.TimeSlot = Ts.Code  " & _
                    " LEFT JOIN Sch_ClassRoom Cr ON A.ClassRoom = Cr.Code   " & _
                    " LEFT JOIN Sch_Subject Sub ON A.Subject = Sub.Code "

            mQry = "CREATE VIEW dbo.ViewSch_StudentAttendance1 As " & _
                    " SELECT V.*, Sub.ManualCode As SubjectManualCode, Sub.PaperID, SgO.Name AS OcName, SgO.DispName AS OcDispName, SgO.ManualCode AS OcManualCode " & _
                    " From (" & mQry & ") As V " & _
                    " LEFT JOIN SubGroup SgO ON V.OcCode = SgO.SubCode " & _
                    " LEFT JOIN ViewSch_SemesterSubject AS Sub  ON Sub.StreamYearSemester =  V.CurrentStreamYearSemesterCode AND Sub.Subject = V.Subject"

            AgL.IsViewExist("ViewSch_StudentAttendance1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_StudentAttendance1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Department As " & _
                    " SELECT D.*, Dp.MainStreamCode AS ParentMainStreamCode, Dp.ManualCode AS ParentManualCode, Dp.Description AS ParentDesc, " & _
                    " (SELECT IsNull(Count(*),0) Cnt  " & _
                    " FROM Sch_Department Dc  " & _
                    " WHERE  " & _
                    " Left(Dc.MainStreamCode, Len(D.MainStreamCode)) = D.MainStreamCode  " & _
                    " AND Len(Dc.MainStreamCode) > Len(D.MainStreamCode) ) AS TotalChildren " & _
                    " FROM Sch_Department D " & _
                    " LEFT JOIN Sch_Department Dp ON D.ParentCode = Dp.Code "

            AgL.IsViewExist("ViewSch_Department", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Department", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionCurrentDetail As " & _
                    " SELECT A.DocId AS AdmissionDocId, A.Site_Code, Sm.Name AS Site_Name, A.Div_Code, A.AdmissionId, A.Status, " & _
                    " Sg.Name AS StudentName, Sg.DispName AS StudentDispName, Sg.ManualCode AS StudentManualCode, Sg.CommonAc, " & _
                    " Ae.EnrollmentNo, Sg.FatherName, S.MotherName, Sg.Add1 AS Address1, Sg.Add2 AS Address2, Sg.Add3 AS Address3, City.CityName, " & _
                    " Sg.Phone, Sg.Mobile, Sg.EMail, Sg.Fax, " & _
                    " VSection.Code AS ClassSectionAsignCode, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, SubSec.Code As ClassSectionSubSectionCode, SubSec.SubSection, " & _
                    " Sem.Code AS StreamYearSemesterCode, Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode,  " & _
                    " Sem.Semester AS SemesterCode, Sem.SemesterStartDate, Sem.StreamYearSemesterDesc, Sem.SessionProgrammeStreamDesc,  " & _
                    " Sem.SessionProgrammeStreamCode, Sem.SessionProgrammeCode, Sem.SessionManualCode, Sem.ProgrammeManualCode, Sem.StreamManualCode,  " & _
                    " Sem.StreamCode, Sem.SessionCode, Sem.ProgrammeCode, Sem.SessionDescription, Sem.SessionStartDate,  " & _
                    " Sem.ProgrammeNatureDescription, Sem.ProgrammeNatureCode, Sem.SessionProgrammeDesc, Sem.SessionProgrammeStreamYearDesc,  " & _
                    " Sem.YearSerial, Sem.YearStartDate, Sem.SemesterSerialNo, Sem.SemesterDesc " & _
                    " FROM  " & _
                    " (SELECT * FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp  " & _
                    " LEFT JOIN Sch_Admission A  ON A.DocId = vAp.AdmissionDocId   " & _
                    " LEFT JOIN SiteMast Sm ON A.Site_Code = Sm.Code   " & _
                    " LEFT JOIN Sch_Student S ON A.Student=S.SubCode     " & _
                    " LEFT JOIN SubGroup sg ON sg.SubCode =S.SubCode " & _
                    " LEFT JOIN City ON City.CityCode = Sg.CityCode     " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo Ae On A.DocId = Ae.DocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code     " & _
                    " Left Join  ( " & _
                    "   SELECT vCsa3.Code, vCsa3.AdmissionDocId, vCsa3.StreamYearSemester,    " & _
                    "   vCsa3.ClassSection, vCsa3.ClassSectionSubSectionCode AS ClassSectionSubSection,  " & _
                    "   vCsa3.SectionLeftOnDate   " & _
                    "   FROM ( " & _
                    "   		SELECT vCsa1.*  " & _
                    "   		FROM ViewSch_ClassSectionSemesterAdmission vCsa1   " & _
                    "   		INNER JOIN  (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate  FROM ViewSch_ClassSectionSemesterAdmission vCsa   GROUP BY vCsa.ClassSection " & _
                    "   	   ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3  WHERE vCsa3.SectionLeftOnDate IS NULL   ) AS VSection ON Vap.AdmissionDocId = Vsection.AdmissionDocId   " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON VSection.ClassSection = Cs.Code   " & _
                    " LEFT JOIN Sch_ClassSectionSubSection SubSec ON VSection.ClassSectionSubSection = SubSec.Code   " & _
                    " WHERE A.Leavingdate IS NULL "

            AgL.IsViewExist("ViewSch_AdmissionCurrentDetail", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_AdmissionCurrentDetail", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'mQry = "CREATE VIEW dbo.<ViewName> As " & _
            '                    " SELECT Query "

            'AgL.IsViewExist("<View Name>", AgL.GCn, True)
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then AgL.IsViewExist("<View Name>", AgL.GcnSite, True)
            'If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CreateVType()
        Try
            '===================================================< Registration Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, Academic_ProjLib.ClsMain.Cat_RegistrationEntry, "Registration Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, Academic_ProjLib.ClsMain.Cat_RegistrationEntry, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, "Registration Entry", Academic_ProjLib.ClsMain.NCat_RegistrationEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Registration Cancel Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.Cat_RegistrationCancelEntry, "Registration Cancel Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.Cat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, "Registration Cancel Entry", Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Student Admission V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_StudentAdmission, Academic_ProjLib.ClsMain.Cat_StudentAdmission, "Student Admission", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_StudentAdmission, Academic_ProjLib.ClsMain.Cat_StudentAdmission, Academic_ProjLib.ClsMain.NCat_StudentAdmission, "Student Admission", Academic_ProjLib.ClsMain.NCat_StudentAdmission, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Due V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, "Fee Due Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, Academic_ProjLib.ClsMain.NCat_FeeDue, "Fee Due Entry", Academic_ProjLib.ClsMain.NCat_FeeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, "Opening Fee Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, "Opening Fee Due", Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, "Fee Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, Academic_ProjLib.ClsMain.NCat_FeeReceive, "Fee Receive Entry", Academic_ProjLib.ClsMain.NCat_FeeReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Refund Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeRefund, Academic_ProjLib.ClsMain.Cat_FeeRefund, "Fee Refund Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeRefund, Academic_ProjLib.ClsMain.Cat_FeeRefund, Academic_ProjLib.ClsMain.NCat_FeeRefund, "Fee Refund Entry", Academic_ProjLib.ClsMain.NCat_FeeRefund, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Advance Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, "Advance Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, "Advance Receive Entry", Academic_ProjLib.ClsMain.NCat_AdvanceReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, "Opening Advance", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, "Opening Advance", Academic_ProjLib.ClsMain.NCat_OpeningAdvance, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewVoucherReference()
        Try
            Dim VRefObj As New Academic_ProjLib.ClsMain.VRef_ReferenceTable

            'VRefObj.VRef_VehicleInsuranceClaimPayment()
            'AgL.AddNewVoucherReference(AgL.GCn, VRefObj.Code, VRefObj.Description, VRefObj.BoundField, VRefObj.DisplayField, VRefObj.IsDocId_DisplayField, VRefObj.HelpQuery, VRefObj.FilterField, VRefObj.SiteField, VRefObj.LastHiddenColumns)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Public Structure StructLibraryMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberCardNo As String
        Public StrMotherName As String
        Public StrMemberType As String
        Public StrAdmissionNo As String
        Public StrClass As String
        Public StrSession As String
        Public StrManualCode As String
        Public StrUID As String
        Public StrSiteCode As String
        Public Structure StructTransportMember
            Public StrSubCode As String
            Public StrStuent As String
            Public StrEmployee As String
            Public StrMemberCardNo As String
            Public StrCardPrefix As String
            Public StrCardSrNo As Integer
            Public StrValidTillDate As String
            Public StrVehicle As String
            Public StrSeatno As String
            Public StrRoute As String
            Public StrPickupPoint As String
            Public StrUID As String
            Sub ProcBlankStruct()
                StrSubCode = ""
                StrStuent = ""
                StrEmployee = ""
                StrMemberCardNo = ""
                StrUID = ""
                StrCardPrefix = ""
                StrCardSrNo = 0
                StrValidTillDate = ""
                StrVehicle = ""
                StrSeatno = ""
                StrRoute = ""
                StrPickupPoint = ""
            End Sub
        End Structure

        Public Structure StructMessMember
            Public StrSubCode As String
            Public StrStuent As String
            Public StrEmployee As String
            Public StrMemberType As String
            Public StrJoinDate As String
            Sub ProcBlankStruct()
                StrSubCode = ""
                StrStuent = ""
                StrEmployee = ""
                StrMemberType = ""
                StrJoinDate = ""
            End Sub
        End Structure

        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberCardNo = ""
            StrMotherName = ""
            StrMemberType = ""
            StrAdmissionNo = ""
            StrClass = ""
            StrSession = ""
            StrManualCode = ""
            StrUID = ""
        End Sub
    End Structure


    Public Function FunSaveLibraryMember(ByVal ObjStructLibraryMember As StructLibraryMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructLibraryMember
                bStrSubCode = ObjStructLibraryMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(AgL.GCn, AgL.ECmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")

                For bIntI = 0 To 1
                    If bIntI = 0 Then
                        bStrTableName = "Lib_Member_Log"
                    Else
                        bStrTableName = "Lib_Member"
                    End If

                    If AgL.StrCmp(StrEntryMode, "Add") Then
                        bQry = "INSERT INTO " & bStrTableName & " (" & _
                                " SubCode, Student, Employee, MemberCardNo, MotherName, MemberType, AdmissionNo, Class, Session, UID,Site_Code) " & _
                                " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                                " " & AgL.Chk_Text(.StrStuent) & ", " & _
                                " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberCardNo) & ", " & _
                                " " & AgL.Chk_Text(.StrMotherName) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberType) & ", " & _
                                " " & AgL.Chk_Text(.StrAdmissionNo) & ", " & _
                                " " & AgL.Chk_Text(.StrClass) & ", " & _
                                " " & AgL.Chk_Text(.StrSession) & ", " & _
                                " " & AgL.Chk_Text(bStrUID) & " ," & _
                                " " & AgL.Chk_Text(.StrSiteCode) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                    Else
                        bQry = "UPDATE " & bStrTableName & " " & _
                                " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                                " 	Student = " & AgL.Chk_Text(.StrSubCode) & "," & _
                                " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                                " 	MemberCardNo = " & AgL.Chk_Text(.StrMemberCardNo) & "," & _
                                " 	MotherName = " & AgL.Chk_Text(.StrMotherName) & "," & _
                                " 	MemberType = " & AgL.Chk_Text(.StrMemberType) & "," & _
                                " 	AdmissionNo = " & AgL.Chk_Text(.StrAdmissionNo) & "," & _
                                " 	Class = " & AgL.Chk_Text(.StrClass) & "," & _
                                " 	Site_Code = " & AgL.Chk_Text(.StrSiteCode) & "," & _
                                " 	Session = " & AgL.Chk_Text(.StrSession) & " " & _
                                " WHERE UID = " & AgL.Chk_Text(bStrUID) & " "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                    End If

                Next
            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveLibraryMember = bBlnReturn
        End Try
    End Function

    Public Function FunCreateCity(ByVal StrCityName As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As String
        Dim bStrCode$ = "", mQry$ = ""
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            SqlCmd = AgL.Dman_Execute("Select CityCode From City With (NoLock) Where CityName='" & StrCityName & "' ", AgL.GcnRead)
            bStrCode = AgL.XNull(SqlCmd.ExecuteScalar())

            If bStrCode.Trim = "" Then
                bStrCode = AgL.GetMaxId("City", "CityCode", AgL.GcnRead, AgL.PubDivCode, AgL.PubSiteCode, 4, True, True, , AgL.Gcn_ConnectionString)

                mQry = "Insert Into City (CityCode, CityName, U_EntDt, U_Name, U_AE) Values(" & _
                        " '" & bStrCode & "', '" & StrCityName & "', " & _
                        " '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)
            End If
        Catch ex As Exception
            bStrCode = ""
        Finally
            FunCreateCity = bStrCode
        End Try
    End Function

    Public Function FunUpdateCurrentSemester(ByVal StrAdmissionDocId As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Sch_Admission " & _
                    " SET Sch_Admission.CurrentSemester = V.CurrentSemester " & _
                    " FROM ( " & _
                    " 	SELECT P.AdmissionDocId, P.FromStreamYearSemester AS CurrentSemester  " & _
                    " 	FROM Sch_AdmissionPromotion P WITH (NoLock)  " & _
                    " 	WHERE 1=1 " & _
                    "   And P.AdmissionDocId = " & AgL.Chk_Text(StrAdmissionDocId) & " " & _
                    "   And P.PromotionDate IS NULL " & _
                    " 	) AS V " & _
                    " WHERE 1=1 " & _
                    " And Sch_Admission.DocId = " & AgL.Chk_Text(StrAdmissionDocId) & " " & _
                    " And Sch_Admission.DocId = V.AdmissionDocId " & _
                    " And IsNull(Sch_Admission.CurrentSemester,'') <> IsNull(V.CurrentSemester,'') "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentSemester = bBlnReturn
        End Try
    End Function

    Public Function FunUpdateCurrentSemester(ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Sch_Admission " & _
                    " SET Sch_Admission.CurrentSemester = V.CurrentSemester " & _
                    " FROM ( " & _
                    " 	SELECT P.AdmissionDocId, P.FromStreamYearSemester AS CurrentSemester  " & _
                    " 	FROM Sch_AdmissionPromotion P WITH (NoLock)  " & _
                    " 	WHERE 1=1 " & _
                    "   And P.PromotionDate IS NULL " & _
                    " 	) AS V " & _
                    " WHERE 1=1 " & _
                    " And Sch_Admission.DocId = V.AdmissionDocId " & _
                    " And IsNull(Sch_Admission.CurrentSemester,'') <> IsNull(V.CurrentSemester,'') "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentSemester = bBlnReturn
        End Try
    End Function
    Public Function FunSaveTransportMember(ByVal ObjStructTransportMember As StructTransportMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructTransportMember
                bStrSubCode = ObjStructTransportMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(SqlConn, SqlCmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")

                For bIntI = 0 To 1
                    If bIntI = 0 Then
                        bStrTableName = "Tp_Member_Log"
                    Else
                        bStrTableName = "Tp_Member"
                    End If

                    If AgL.StrCmp(StrEntryMode, "Add") Then
                        bQry = "INSERT INTO " & bStrTableName & " (" & _
                                " SubCode, Student, Employee, MemberCardNo,CardPrefix,CardSrNo,ValidTillDate,Vehicle,SeatNo,Route,PickUpPoint, UID) " & _
                                " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                                " " & AgL.Chk_Text(.StrStuent) & ", " & _
                                " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberCardNo) & ", " & _
                                 " " & AgL.Chk_Text(.StrCardPrefix) & ", " & _
                                " " & Val(.StrCardSrNo) & ", " & _
                                "  " & AgL.ConvertDate(.StrValidTillDate) & ", " & _
                                " " & AgL.Chk_Text(.StrVehicle) & ", " & _
                                  " " & AgL.Chk_Text(.StrSeatno) & ", " & _
                                " " & AgL.Chk_Text(.StrRoute) & ", " & _
                                " " & AgL.Chk_Text(.StrPickupPoint) & ", " & _
                                " " & AgL.Chk_Text(bStrUID) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                    Else
                        bQry = "UPDATE " & bStrTableName & " " & _
                                " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                                " 	Student = " & AgL.Chk_Text(.StrStuent) & "," & _
                                " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                                " 	MemberCardNo = " & AgL.Chk_Text(.StrMemberCardNo) & "," & _
                                " CardPrefix = " & AgL.Chk_Text(.StrCardPrefix) & ", " & _
                                " CardSrNo = " & AgL.Chk_Text(.StrCardSrNo) & ", " & _
                                " ValidTillDate = " & AgL.ConvertDate(.StrValidTillDate) & ", " & _
                                " Vehicle = " & AgL.Chk_Text(.StrVehicle) & "," & _
                                " SeatNo = " & AgL.Chk_Text(.StrSeatno) & "," & _
                                " Route = " & AgL.Chk_Text(.StrRoute) & "," & _
                                " PickUpPoint = " & AgL.Chk_Text(.StrPickupPoint) & " " & _
                                " WHERE UID = " & AgL.Chk_Text(bStrUID) & " "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                    End If

                Next
            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveTransportMember = bBlnReturn
        End Try
    End Function

    Public Function FunSaveMessMember(ByVal ObjStructMessMember As StructMessMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructMessMember
                bStrSubCode = ObjStructMessMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(SqlConn, SqlCmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")


                bStrTableName = "Mess_Member"


                If AgL.StrCmp(StrEntryMode, "Add") Then
                    bQry = "INSERT INTO " & bStrTableName & " (" & _
                            " SubCode, Student, Employee, MemberType,JoiningDate) " & _
                            " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                            " " & AgL.Chk_Text(.StrStuent) & ", " & _
                            " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                            " " & AgL.Chk_Text(.StrMemberType) & ", " & _
                            " " & AgL.Chk_Text(.StrJoinDate) & " " & _
                            " ) "
                    AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                Else
                    bQry = "UPDATE " & bStrTableName & " " & _
                            " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                            " 	Student = " & AgL.Chk_Text(.StrStuent) & "," & _
                            " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                            " 	MemberType = " & AgL.Chk_Text(.StrMemberType) & "," & _
                            " JoiningDate = " & AgL.Chk_Text(.StrJoinDate) & " " & _
                            " WHERE SubCode = " & AgL.Chk_Text(.StrSubCode) & " "
                    AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                End If

            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveMessMember = bBlnReturn
        End Try
    End Function

    Public Function FunGetMemberCardNo(ByVal StrClass As String, ByVal StrSession As String, ByVal StrManualCode As String) As String
        Dim bStrReturn$ = "", bCondStr$ = " Where 1=1 ", mQry$ = ""
        Dim bLongMaxId As Long = 0

        Try
            If StrClass.Trim <> "" Then
                bCondStr += " And M.Class = " & AgL.Chk_Text(StrClass) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrClass, "-" + StrClass)
            End If

            If StrSession.Trim <> "" Then
                bCondStr += " And M.Session = " & AgL.Chk_Text(StrSession) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrSession, "-" + StrSession)
            End If


            mQry = "SELECT IsNull(Max(M.CardSrNo),0) AS MaxId " & _
                    " FROM Lib_Member M With (NoLock) " & bCondStr

            bLongMaxId = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

            bStrReturn += IIf(bStrReturn.Trim = "", bLongMaxId.ToString, "-" + bLongMaxId.ToString)

            If StrManualCode.Trim <> "" Then
                bStrReturn += IIf(bStrReturn.Trim = "", StrManualCode, "-" + StrManualCode)
            End If

        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetMemberCardNo = bStrReturn
        End Try
    End Function
    Public Function FunUpdateCurrentStatus(ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing, Optional ByVal StrRegistrationDocId As String = "") As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = "", bQryRegistration$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            bQryRegistration$ = "SELECT  R.DocID as RegistrationDocID,R1.Status AS CurrentStatus, " & _
                                " R.StatusDate AS CurrentStatusDate, " & _
                                " R1.SessionProgrammeStream AS CurrentSessionProgrammeStream " & _
                                " FROM (SELECT  max(H.DocID) AS DocID,Max(H.StatusDate) AS StatusDate,max(H.Sr) AS Sr FROM Sch_RegistrationStatus H GROUP BY  H.DocID) R " & _
                                " LEFT JOIN Sch_RegistrationStatus R1 ON R.DocId = R1.DocId AND R.StatusDate = R1.StatusDate AND R.Sr = R1.Sr " & _
                                " Where 1=1 " & _
                                " And " & IIf(StrRegistrationDocId.Trim = "", " 1=1 ", " R.RegistrationDocID = " & AgL.Chk_Text(StrRegistrationDocId) & " ") & " "


            mQry = "UPDATE Sch_Registration " & _
                    " SET Sch_Registration.CurrentStatus = V.CurrentStatus, " & _
                    " Sch_Registration.CurrentStatusDate = V.CurrentStatusDate, " & _
                     " Sch_Registration.CurrentSessionProgrammeStream = V.CurrentSessionProgrammeStream " & _
                    " FROM (" & bQryRegistration$ & ") AS V " & _
                    " WHERE 1=1 " & _
                    " And " & IIf(StrRegistrationDocId.Trim = "", " 1=1 ", " Sch_Registration.DocId = " & AgL.Chk_Text(StrRegistrationDocId) & " ") & " " & _
                    " And Sch_Registration.DocId = V.RegistrationDocID " & _
                    " And (IsNull(Sch_Registration.CurrentStatus,'') <> IsNull(V.CurrentStatus,'') Or IsNull(Sch_Registration.CurrentStatusDate,'') <> IsNull(V.CurrentStatusDate,'') Or IsNull(Sch_Registration.CurrentSessionProgrammeStream,'') <> IsNull(V.CurrentSessionProgrammeStream,'') ) "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentStatus = bBlnReturn
        End Try
    End Function
    Public Function FunCreateNationality(ByVal StrNationalityName As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As String
        Dim bStrCode$ = "", mQry$ = ""
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            SqlCmd = AgL.Dman_Execute("Select NationalityCode From Nationality With (NoLock) Where Nationaliy='" & StrNationalityName & "' ", AgL.GcnRead)
            bStrCode = AgL.XNull(SqlCmd.ExecuteScalar())

            If bStrCode.Trim = "" Then
                bStrCode = AgL.GetMaxId("Nationality", "NationalityCode", AgL.GcnRead, AgL.PubDivCode, AgL.PubSiteCode, 5, True, True, , AgL.Gcn_ConnectionString)

                mQry = "Insert Into Nationality (NationalityCode, Nationaliy, U_EntDt, PreparedBy, U_AE) Values(" & _
                        " '" & bStrCode & "', '" & StrNationalityName & "', " & _
                        " '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)
            End If
        Catch ex As Exception
            bStrCode = ""
        Finally
            FunCreateNationality = bStrCode
        End Try
    End Function

End Class