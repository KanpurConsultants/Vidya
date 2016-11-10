Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Exam"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub


    Public Class ExamPresentStatus
        Public Const Present As String = "Present"
        Public Const Absent As String = "Absent"
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try

            ''============================< Rati 16/Apr2012 Exam_SemesterExam >=============================================
            AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "ClassSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSection", "Exam_SemesterExam", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExam_ClassSection", "Sch_ClassSection", "Exam_SemesterExam", "Code", "ClassSection")
            End If
            AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Exam_SemesterExam", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExam_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Exam_SemesterExam", "Code", "ClassSectionSubSection")
            End If

            If AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "Description", "nVarChar(255)") Then
                mQry = "UPDATE Exam_SemesterExam   " & _
                        " SET Exam_SemesterExam.Description = ViewSch_StreamYearSemester.StreamYearSemesterDesc + '/' + Exam_ExamType.Description " & _
                        " FROM ViewSch_StreamYearSemester, Exam_ExamType " & _
                        " WHERE Exam_SemesterExam.StreamYearSemester = ViewSch_StreamYearSemester.Code  " & _
                        " AND  Exam_SemesterExam.ExamType = Exam_ExamType.Code " & _
                        " And Exam_SemesterExam.Description IS NULL " & _
                        " AND Exam_SemesterExam.StreamYearSemester IS NOT NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "Session", "nVarChar(8)")
            If AgL.IsFieldExist("Session", "Exam_SemesterExam", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExam_Session", "Sch_Session", "Exam_SemesterExam", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "StartDate", "SmallDateTime")
            AgL.AddNewField(AgL.GCn, "Exam_SemesterExam", "EndDate", "SmallDateTime")

            ''============================< Rati 16/Apr2012 Exam_SemesterExamAdmission >=============================================


            AgL.AddNewField(AgL.GCn, "Exam_SemesterExamAdmission", "ClassSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSection", "Exam_SemesterExamAdmission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission_ClassSection", "Sch_ClassSection", "Exam_SemesterExamAdmission", "Code", "ClassSection")
            End If
            AgL.AddNewField(AgL.GCn, "Exam_SemesterExamAdmission", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Exam_SemesterExamAdmission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Exam_SemesterExamAdmission", "Code", "ClassSectionSubSection")
            End If
            AgL.AddNewField(AgL.GCn, "Exam_SemesterExamAdmission", "Session", "nVarChar(8)")
            If AgL.IsFieldExist("Session", "Exam_SemesterExamAdmission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission_Session", "Sch_Session", "Exam_SemesterExamAdmission", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SemesterExamAdmission", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "Exam_SemesterExamAdmission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission_StreamYearSemester", "Sch_StreamYearSemester", "Exam_SemesterExamAdmission", "Code", "StreamYearSemester")
            End If


            ''============================< Rati 16/Apr2012 Exam_SemesterExamAdmission1 >=============================================
            If AgL.AddNewField(AgL.GCn, "Exam_SemesterExamAdmission1", "StreamYearSemester", "nVarChar(10)") Then
                mQry = "Update dbo.Exam_SemesterExamAdmission1 " & _
                         " Set Exam_SemesterExamAdmission1.StreamYearSemester=Exam_SemesterExam.StreamYearSemester   " & _
                         " FROM Exam_SemesterExamAdmission, Exam_SemesterExam  " & _
                         " Where Exam_SemesterExamAdmission.SemesterExam = Exam_SemesterExam.Code " & _
                         " And Exam_SemesterExamAdmission.DocId=Exam_SemesterExamAdmission1.DocId " & _
                         " And Exam_SemesterExam.StreamYearSemester Is Not Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("StreamYearSemester", "Exam_SemesterExamAdmission1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission1_StreamYearSemester", "Sch_StreamYearSemester", "Exam_SemesterExamAdmission1", "Code", "StreamYearSemester")
            End If
           
            ''============================< ************************* >=====================================
            ''============================< Exam_SubjectMarks >=============================================
            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks", "IsAttendanceMarks", "Bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks", "ClassSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSection", "Exam_SubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SubjectMarks_ClassSection", "Sch_ClassSection", "Exam_SubjectMarks", "Code", "ClassSection")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Exam_SubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SubjectMarks_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Exam_SubjectMarks", "Code", "ClassSectionSubSection")
            End If


            If AgL.IsFieldExist("IsAttendanceMarks", "Exam_SubjectMarks", AgL.GCn) _
                Or AgL.IsFieldExist("ClassSection", "Exam_SubjectMarks", AgL.GCn) _
                Or AgL.IsFieldExist("ClassSectionSubSection", "Exam_SubjectMarks", AgL.GCn) Then

                If AgL.IsConstraintExist("IX_Exam_SubjectMarksEntry_1", "Exam_SubjectMarks", "SemesterExam,Subject", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Exam_SubjectMarks DROP CONSTRAINT [IX_Exam_SubjectMarksEntry_1]", AgL.GCn)
                End If

                If AgL.IsConstraintExist("IX_Exam_SubjectMarksEntry_1", "Exam_SubjectMarks", "SemesterExam,Subject,IsAttendanceMarks", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Exam_SubjectMarks DROP CONSTRAINT [IX_Exam_SubjectMarksEntry_1]", AgL.GCn)
                End If

                AgL.AddUniqueKeyConstraint("IX_Exam_SubjectMarksEntry_1", "Exam_SubjectMarks", "SemesterExam,Subject,IsAttendanceMarks,ClassSection,ClassSectionSubSection", AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks", "Session", "nVarChar(8)")
            If AgL.IsFieldExist("Session", "Exam_SubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SubjectMarks_Session", "Sch_Session", "Exam_SubjectMarks", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "Exam_SubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SubjectMarks_StreamYearSemester", "Sch_StreamYearSemester", "Exam_SubjectMarks", "Code", "StreamYearSemester")
            End If



            ''============================< ************************* >=====================================

            ''============================< Exam_SubjectMarks1 >============================================
            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks1", "ConsolidatedSubjectMarks2GUID", "nVarChar(36)")
            If AgL.IsFieldExist("ConsolidatedSubjectMarks2GUID", "Exam_SubjectMarks1", AgL.GCn) And _
                AgL.IsFieldExist("GUID", "Exam_ConsolidatedSubjectMarks2", AgL.GCn) Then

                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SubjectMarks1_ConsolidatedSubjectMarks2GUID", "Exam_ConsolidatedSubjectMarks2", "Exam_SubjectMarks1", "GUID", "ConsolidatedSubjectMarks2GUID")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks1", "ConsolidatedMarks", "Float", 0, False)

            If AgL.AddNewField(AgL.GCn, "Exam_SubjectMarks1", "PresentStatus", "nVarChar(20)") Then
                mQry = "Update Exam_SubjectMarks1 Set PresentStatus = " & AgL.Chk_Text(ExamPresentStatus.Present) & " Where PresentStatus Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            ''============================< Exam_ConsolidatedSubjectMarks >=====================================
            AgL.AddNewField(AgL.GCn, "Exam_ConsolidatedSubjectMarks", "ClassSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSection", "Exam_ConsolidatedSubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_ConsolidatedSubjectMarks_ClassSection", "Sch_ClassSection", "Exam_ConsolidatedSubjectMarks", "Code", "ClassSection")
            End If
            AgL.AddNewField(AgL.GCn, "Exam_ConsolidatedSubjectMarks", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Exam_ConsolidatedSubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_ConsolidatedSubjectMarks_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Exam_ConsolidatedSubjectMarks", "Code", "ClassSectionSubSection")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_ConsolidatedSubjectMarks", "Session", "nVarChar(8)")
            If AgL.IsFieldExist("Session", "Exam_ConsolidatedSubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_ConsolidatedSubjectMarks_Session", "Sch_Session", "Exam_ConsolidatedSubjectMarks", "Code", "Session")
            End If

            AgL.AddNewField(AgL.GCn, "Exam_ConsolidatedSubjectMarks", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "Exam_ConsolidatedSubjectMarks", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_ConsolidatedSubjectMarks_StreamYearSemester", "Sch_StreamYearSemester", "Exam_ConsolidatedSubjectMarks", "Code", "StreamYearSemester")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            'If AgL.IsFieldExist("Student", "Sch_FeeDue1", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_FeeDue1 DROP CONSTRAINT [IX_Sch_FeeDue1]", AgL.GCn)
            '    AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeDue1_Sch_Student", "Sch_FeeDue1")
            '    AgL.DeleteField("Sch_FeeDue1", "Student", AgL.GCn)
            'End If
            If AgL.IsConstraintExist("IX_Exam_SemesterExam", "Exam_SemesterExam", "StreamYearSemester,ExamType", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Exam_SemesterExam DROP CONSTRAINT [IX_Exam_SemesterExam]", AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            'AgL.EditField("Sch_Admission", "AdmissionID", "nVarChar(61)", AgL.GCn, False)
            'AgL.AddForeignKey(AgL.GCn, "FK_VehicleHireChallan_AdvancePayAc", "SubGroup", "VehicleHireChallan", "SubCode", "AdvancePayAc")

            AgL.EditField("Exam_SemesterExam", "StreamYearSemester", "nVarChar(10)", AgL.GCn, True)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = "", mQry1 As String = "", mQry2 As String = ""

        Try
            mQry = "create table dbo.Exam_ExamType " & _
                    " ( " & _
                    " Code        nvarchar (8) not null, " & _
                    " Description nvarchar (50) not null, " & _
                    " ExamNature  nvarchar (50) not null, " & _
                    " Div_Code    nvarchar (1) not null, " & _
                    " Site_Code   nvarchar (2) not null, " & _
                    " PreparedBy  nvarchar (10) not null, " & _
                    " U_EntDt     datetime not null, " & _
                    " U_AE        nvarchar (1) not null, " & _
                    " Edit_Date   datetime null, " & _
                    " ModifiedBy  nvarchar (10) null, " & _
                    " constraint PK_Exam_ExamType primary key (Code), " & _
                    " constraint IX_Exam_ExamType unique (Description), " & _
                    " constraint FK_Exam_ExamType_SiteMast foreign key (Site_Code) references dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_ExamType", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_ExamType", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "create table dbo.Exam_SemesterExam " & _
                    " (" & _
                    " Code               nvarchar (10) not null, " & _
                    " StreamYearSemester nvarchar (10) not null, " & _
                    " ExamType           nvarchar (8) not null, " & _
                    " Remark             nvarchar (255) constraint DF_Exam_SemesterExam_Remark default ('') null, " & _
                    " Div_Code           nvarchar (1) not null, " & _
                    " Site_Code          nvarchar (2) not null, " & _
                    " PreparedBy         nvarchar (10) not null, " & _
                    " U_EntDt            datetime not null, " & _
                    " U_AE               nvarchar (1) not null, " & _
                    " Edit_Date          datetime null, " & _
                    " ModifiedBy         nvarchar (10) null, " & _
                    " constraint PK_Exam_SemesterExam primary key (Code), " & _
                    " constraint IX_Exam_SemesterExam unique (StreamYearSemester, ExamType), " & _
                    " constraint FK_Exam_SemesterExam_Sch_StreamYearSemester foreign key (StreamYearSemester) references dbo.Sch_StreamYearSemester (Code), " & _
                    " constraint FK_Exam_SemesterExam_Exam_ExamType foreign key (ExamType) references dbo.Exam_ExamType (Code), " & _
                    " constraint FK_Exam_SemesterExam_SiteMast foreign key (Site_Code) references dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SemesterExam", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SemesterExam", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "create table dbo.Exam_SemesterExam1 " & _
                    " ( " & _
                    " Code                nvarchar (10) not null, " & _
                    " Sr                  int not null, " & _
                    " Subject             nvarchar (8) not null, " & _
                    " Exam_MaxMarks       float constraint DF_Exam_SemesterExam1_Exam_MaxMarks default ((0)) not null, " & _
                    " Exam_MinMarks       float constraint DF_Exam_SemesterExam1_Exam_MinMarks default ((0)) not null, " & _
                    " Test_MaxMarks       float constraint DF_Table_1_Exam_MaxMarks1 default ((0)) not null, " & _
                    " Test_MinMarks       float constraint DF_Table_1_Exam_MinMarks1 default ((0)) not null, " & _
                    " Assignment_MaxMarks float constraint DF_Table_1_Exam_MaxMarks2 default ((0)) not null, " & _
                    " Assignment_MinMarks float constraint DF_Table_1_Exam_MinMarks2 default ((0)) not null, " & _
                    " Attendance_MaxMarks float constraint DF_Table_1_Assignment_MaxMarks1_1 default ((0)) not null, " & _
                    " Attendance_MinMarks float constraint DF_Table_1_Assignment_MinMarks1_1 default ((0)) not null, " & _
                    " Total_MaxMarks      float constraint DF_Table_1_Assignment_MaxMarks1 default ((0)) not null, " & _
                    " Total_MinMarks      float constraint DF_Table_1_Assignment_MinMarks1 default ((0)) not null, " & _
                    " constraint PK_Exam_SemesterExam1 primary key (Code,Sr), " & _
                    " constraint IX_Exam_SemesterExam1 unique (Code,Subject), " & _
                    " constraint FK_Exam_SemesterExam1_Sch_Subject foreign key (Subject) references dbo.Sch_Subject (Code), " & _
                    " constraint FK_Exam_SemesterExam1_Exam_SemesterExam foreign key (Code) references dbo.Exam_SemesterExam (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SemesterExam1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SemesterExam1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_SemesterExamAdmission " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " Div_Code     NVARCHAR (1) NOT NULL, " & _
                    " Site_Code    NVARCHAR (2) NOT NULL, " & _
                    " V_Date       SMALLDATETIME NOT NULL, " & _
                    " V_Type       NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix     NVARCHAR (5) NOT NULL, " & _
                    " V_No         BIGINT NOT NULL, " & _
                    " SemesterExam NVARCHAR (10) NOT NULL, " & _
                    " TotalStudent INT CONSTRAINT DF_Exam_SemesterExamAdmission_TotalStudent DEFAULT ((0)) NOT NULL, " & _
                    " Remark       NVARCHAR (255) CONSTRAINT DF_Exam_SemesterExamAdmission_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy   NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt      DATETIME NOT NULL, " & _
                    " U_AE         NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date    DATETIME NULL, " & _
                    " ModifiedBy   NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Exam_SemesterExamAdmission PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Exam_SemesterExamAdmission UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission_Exam_SemesterExam FOREIGN KEY (SemesterExam) REFERENCES dbo.Exam_SemesterExam (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SemesterExamAdmission", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SemesterExamAdmission", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_SemesterExamAdmission1 " & _
                    " ( " & _
                    " Code           NVARCHAR (10) NOT NULL, " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " AdmissionDocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Exam_SemesterExamAdmission1 PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Exam_SemesterExamAdmission1 UNIQUE (DocId,AdmissionDocId), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission1_Exam_SemesterExamAdmission FOREIGN KEY (DocId) REFERENCES dbo.Exam_SemesterExamAdmission (DocId), " & _
                    " CONSTRAINT FK_Exam_SemesterExamAdmission1_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SemesterExamAdmission1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SemesterExamAdmission1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_SubjectMarks " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " Div_Code     NVARCHAR (1) NOT NULL, " & _
                    " Site_Code    NVARCHAR (2) NOT NULL, " & _
                    " V_Date       SMALLDATETIME NOT NULL, " & _
                    " V_Type       NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix     NVARCHAR (5) NOT NULL, " & _
                    " V_No         BIGINT NOT NULL, " & _
                    " SemesterExam NVARCHAR (10) NOT NULL, " & _
                    " Subject      NVARCHAR (8) NOT NULL, " & _
                    " MaxMarks     FLOAT CONSTRAINT DF_Exam_SubjectMarks_Exam_MaxMarks DEFAULT ((0)) NOT NULL, " & _
                    " MinMarks     FLOAT CONSTRAINT DF_Exam_SubjectMarks_Exam_MinMarks DEFAULT ((0)) NOT NULL, " & _
                    " Remark       NVARCHAR (255) CONSTRAINT DF_Exam_SubjectMarksEntry_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy   NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt      DATETIME NOT NULL, " & _
                    " U_AE         NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date    DATETIME NULL, " & _
                    " ModifiedBy   NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Exam_SubjectMarksEntry PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Exam_SubjectMarksEntry UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT IX_Exam_SubjectMarksEntry_1 UNIQUE (SemesterExam,Subject), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry_Exam_SemesterExam FOREIGN KEY (SemesterExam) REFERENCES dbo.Exam_SemesterExam (Code), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SubjectMarks", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SubjectMarks", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_SubjectMarks1 " & _
                    " ( " & _
                    " DocId                  NVARCHAR (21) NOT NULL, " & _
                    " Sr                     INT NOT NULL, " & _
                    " SemesterExamAdmission1 NVARCHAR (10) NOT NULL, " & _
                    " MarksObtain            FLOAT CONSTRAINT DF_Table_1_Exam_MarksObtain1 DEFAULT ((0)) NOT NULL, " & _
                    " GraceMarks             FLOAT CONSTRAINT DF_Table_1_Exam_GraceMarks1 DEFAULT ((0)) NOT NULL, " & _
                    " TotalMarks             FLOAT CONSTRAINT DF_Table_1_Total_GraceMarks DEFAULT ((0)) NOT NULL, " & _
                    " Result                 NVARCHAR (20) NOT NULL, " & _
                    " CONSTRAINT PK_Exam_SubjectMarksEntry1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Exam_SubjectMarksEntry1 UNIQUE (DocId,SemesterExamAdmission1), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry1_Exam_SemesterExamAdmission1 FOREIGN KEY (SemesterExamAdmission1) REFERENCES dbo.Exam_SemesterExamAdmission1 (Code), " & _
                    " CONSTRAINT FK_Exam_SubjectMarksEntry1_Exam_SubjectMarksEntry FOREIGN KEY (DocId) REFERENCES dbo.Exam_SubjectMarks (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_SubjectMarks1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SubjectMarks1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_ConsolidatedSubjectMarks " & _
                    " ( " & _
                    " DocId         NVARCHAR (21) NOT NULL, " & _
                    " Div_Code      NVARCHAR (1) NOT NULL, " & _
                    " Site_Code     NVARCHAR (2) NOT NULL, " & _
                    " V_Date        SMALLDATETIME NOT NULL, " & _
                    " V_Type        NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix      NVARCHAR (5) NOT NULL, " & _
                    " V_No          BIGINT NOT NULL, " & _
                    " SemesterExam  NVARCHAR (10) NOT NULL, " & _
                    " SubExamNature NVARCHAR (50) NOT NULL, " & _
                    " Subject       NVARCHAR (8) NOT NULL, " & _
                    " MaxMarks      FLOAT CONSTRAINT DF_Exam_ConsolidatedSubjectMarks_MaxMarks DEFAULT ((0)) NOT NULL, " & _
                    " MinMarks      FLOAT CONSTRAINT DF_Exam_ConsolidatedSubjectMarks_MinMarks DEFAULT ((0)) NOT NULL, " & _
                    " Remark        NVARCHAR (255) CONSTRAINT DF_Exam_ConsolidatedSubjectMarks_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy    NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt       DATETIME NOT NULL, " & _
                    " U_AE          NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date     DATETIME NULL, " & _
                    " ModifiedBy    NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Exam_ConsolidatedSubjectMarks PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Exam_ConsolidatedSubjectMarks UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks_Exam_SemesterExam FOREIGN KEY (SemesterExam) REFERENCES dbo.Exam_SemesterExam (Code), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_ConsolidatedSubjectMarks1 " & _
                    " ( " & _
                    " DocId           NVARCHAR (21) NOT NULL, " & _
                    " Sr              INT NOT NULL, " & _
                    " SubSemesterExam NVARCHAR (10) NOT NULL, " & _
                    " CONSTRAINT PK_Exam_ConsolidatedSubjectMarks1 PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Exam_ConsolidatedSubjectMarks1 UNIQUE (DocId,SubSemesterExam), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks1_Exam_ConsolidatedSubjectMarks FOREIGN KEY (DocId) REFERENCES dbo.Exam_ConsolidatedSubjectMarks (DocId), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks1_Exam_SemesterExam FOREIGN KEY (SubSemesterExam) REFERENCES dbo.Exam_SemesterExam (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_ConsolidatedSubjectMarks2 " & _
                    " ( " & _
                    " GUID                   NVARCHAR (36) NOT NULL, " & _
                    " DocId                  NVARCHAR (21) NOT NULL, " & _
                    " SemesterExamAdmission1 NVARCHAR (10) NOT NULL, " & _
                    " MarksObtain            FLOAT CONSTRAINT DF_Exam_ConsolidatedSubjectMarks1_MarksObtain DEFAULT ((0)) NOT NULL, " & _
                    " GraceMarks             FLOAT CONSTRAINT DF_Exam_ConsolidatedSubjectMarks1_GraceMarks DEFAULT ((0)) NOT NULL, " & _
                    " TotalMarks             FLOAT CONSTRAINT DF_Exam_ConsolidatedSubjectMarks1_TotalMarks DEFAULT ((0)) NOT NULL, " & _
                    " Result                 NVARCHAR (20) NOT NULL, " & _
                    " CONSTRAINT PK_Exam_ConsolidatedSubjectMarks2 PRIMARY KEY (GUID), " & _
                    " CONSTRAINT IX_Exam_ConsolidatedSubjectMarks2 UNIQUE (DocId,SemesterExamAdmission1), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks2_Exam_ConsolidatedSubjectMarks FOREIGN KEY (DocId) REFERENCES dbo.Exam_ConsolidatedSubjectMarks (DocId), " & _
                    " CONSTRAINT FK_Exam_ConsolidatedSubjectMarks2_Exam_SemesterExamAdmission1 FOREIGN KEY (SemesterExamAdmission1) REFERENCES dbo.Exam_SemesterExamAdmission1 (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks2", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_ConsolidatedSubjectMarks2", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Exam_SemesterExam2 " & _
                    " ( " & _
                    " Code                nvarchar (10) not null, " & _
                    " Sr                  int not null, " & _
                    " StreamYearSemester NVARCHAR (10) NULL, " & _
                    " Session            NVARCHAR (8) NULL, " & _
                    " Programme          NVARCHAR (8) NULL, " & _
                    " Stream             NVARCHAR (8) NULL, " & _
                    " Semester           NVARCHAR (8) NULL, " & _
                    " RowId              BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate         SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Exam_SemesterExam2 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Exam_SemesterExam FOREIGN KEY (Code) REFERENCES dbo.Exam_SemesterExam (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Sch_Session FOREIGN KEY (Session) REFERENCES dbo.Sch_Session (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Sch_Programme FOREIGN KEY (Programme) REFERENCES dbo.Sch_Programme (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Sch_Stream FOREIGN KEY (Stream) REFERENCES dbo.Sch_Stream (Code), " & _
                    " CONSTRAINT FK_Exam_SemesterExam2_Sch_Semester FOREIGN KEY (Semester) REFERENCES dbo.Sch_Semester (Code) " & _
                    " )"

            mQry1 = "INSERT INTO dbo.Exam_SemesterExam2  (Code, Sr, StreamYearSemester,Session,Programme,Stream,Semester) " & _
                            " SELECT S.Code, 1, S.StreamYearSemester,Sem.SessionCode,Sem.ProgrammeCode,Sem.StreamCode,Sem.Semester  " & _
                            " FROM Exam_SemesterExam S With (NoLock) " & _
                            " Inner JOIN ViewSch_StreamYearSemester Sem With (NoLock) ON S.StreamYearSemester = Sem.Code  "


            If Not AgL.IsTableExist("Exam_SemesterExam2", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                AgL.Dman_ExecuteNonQry(mQry1, AgL.GCn)
            End If


            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Exam_SemesterExam2", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                    AgL.Dman_ExecuteNonQry(mQry1, AgL.GcnSite)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CreateView()
        Dim mQry$ = "", mQry1$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section
        Try
            mQry = "CREATE VIEW dbo.ViewExam_SemesterExam As " & _
                  " SELECT E.* , Et.Description AS ExamTypeDesc, Et.ExamNature, " & _
                  " E.Description AS SemesterExamDesc, " & _
                  " '' as SessionProgrammeCode, '' as SessionManualCode, '' as ProgrammeManualCode,'' as StreamManualCode, '' as StreamCode, '' as SessionCode, '' as ProgrammeCode, '' as SessionProgrammeStreamYear, Sem.Description as StreamYearSemesterDesc  " & _
                  " FROM Exam_SemesterExam E " & _
                  " LEFT JOIN Exam_ExamType Et ON E.ExamType = Et.Code  " & _
                  " LEFT JOIN Sch_StreamYearSemester Sem ON E.StreamYearSemester = Sem.Code  "

            AgL.IsViewExist("ViewExam_SemesterExam", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewExam_SemesterExam", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry1 = " SELECT S.Name AS StudentName, S.DispName AS StudentDispName, S.ManualCode AS StudentManualCode, S.FatherName, S.MotherName, " & _
            '        " A.AdmissionID, A.RollNo , A.EnrollmentNo, Ea1.Code As SemesterExamAdmission1, " & _
            '        " Ea1.AdmissionDocId, Ea.SemesterExam , Ea.DocId AS SemesterExamAdmissionDocId, " & _
            '        " E.StreamYearSemester AS StreamYearSemesterCode, E.ExamType, E.Div_Code, E.Site_Code, " & _
            '        " E.ExamTypeDesc, E.ExamNature, E.SemesterExamDesc, E.SessionProgrammeCode, " & _
            '        " E.SessionManualCode, E.ProgrammeManualCode, E.StreamManualCode, E.StreamCode, " & _
            '        " E.SessionCode, E.ProgrammeCode, E.SessionProgrammeStreamYear, E.StreamYearSemesterDesc, " & _
            '        " Sub.Subject AS SubjectCode,  Sub.SubjectDesc, Sub.SubjectDisplayName ,  Sub.SubjectType, Sub.ManualCode AS SubjectManualCode, " & _
            '        " E1.Exam_MaxMarks, E1.Exam_MinMarks, E1.Test_MaxMarks,  " & _
            '        " E1.Test_MinMarks, E1.Assignment_MaxMarks, E1.Assignment_MinMarks,  " & _
            '        " E1.Attendance_MaxMarks, E1.Attendance_MinMarks, E1.Total_MaxMarks, E1.Total_MinMarks,  " & _
            '        " Sm.MaxMarks , Sm.MinMarks , Sm1.MarksObtain , Sm1.GraceMarks , Sm1.TotalMarks , Sm1.Result, Sm1.PresentStatus,  " & _
            '        " Convert(BIT,CASE WHEN Sm.DocId IS NULL THEN 0 ELSE 1 END) AS IsSubjectMarksExists,  " & _
            '        " Convert(BIT,CASE WHEN Sm1.Result IS NULL THEN 0 ELSE 1 END) AS IsStudentMarksExists   " & _
            '        " FROM ViewExam_SemesterExam E " & _
            '        " LEFT JOIN Exam_SemesterExam1 E1 ON E.Code = E1.Code  " & _
            '        " LEFT JOIN Exam_SubjectMarks Sm ON E1.Code = Sm.SemesterExam AND E1.Subject = Sm.Subject  " & _
            '        " LEFT JOIN Exam_SemesterExamAdmission Ea ON E.Code = Ea.SemesterExam  " & _
            '        " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON Ea.DocId = Ea1.DocId  " & _
            '        " LEFT JOIN ViewSch_Admission A ON Ea1.AdmissionDocId = A.DocId  " & _
            '        " LEFT JOIN Exam_SubjectMarks1 Sm1 ON Sm.DocId = Sm1.DocId AND Ea1.Code = Sm1.SemesterExamAdmission1  " & _
            '        " LEFT JOIN ViewSch_SemesterSubject Sub ON E.StreamYearSemester = Sub.StreamYearSemester AND E1.Subject = Sub.Subject  " & _
            '        " LEFT JOIN ViewSch_Student S ON A.Student = S.SubCode  "

            mQry1 = " SELECT S.Name AS StudentName, S.DispName AS StudentDispName, S.ManualCode AS StudentManualCode, S.FatherName, S.MotherName, " & _
                    " A.AdmissionID, A.RollNo , A.EnrollmentNo, Ea1.Code As SemesterExamAdmission1, " & _
                    " Ea1.AdmissionDocId, Ea.SemesterExam , Ea.DocId AS SemesterExamAdmissionDocId, " & _
                    " Ea1.StreamYearSemester AS StreamYearSemesterCode, E.ExamType, E.Div_Code, E.Site_Code, " & _
                    " Et.Description As ExamTypeDesc, Et.ExamNature, E.Description As SemesterExamDesc,'' as SessionProgrammeCode, " & _
                    " '' as SessionManualCode, '' as ProgrammeManualCode, '' as StreamManualCode, '' as StreamCode, " & _
                    " '' as SessionCode, '' as ProgrammeCode, '' as SessionProgrammeStreamYear, Sem.Description as StreamYearSemesterDesc, " & _
                    " Sub.Subject AS SubjectCode,  Sub.SubjectDesc, Sub.SubjectDisplayName ,  Sub.SubjectType, Sub.ManualCode AS SubjectManualCode, " & _
                    " E1.Exam_MaxMarks, E1.Exam_MinMarks, E1.Test_MaxMarks,  " & _
                    " E1.Test_MinMarks, E1.Assignment_MaxMarks, E1.Assignment_MinMarks,  " & _
                    " E1.Attendance_MaxMarks, E1.Attendance_MinMarks, E1.Total_MaxMarks, E1.Total_MinMarks,  " & _
                    " Sm.MaxMarks , Sm.MinMarks , Sm1.MarksObtain , Sm1.GraceMarks , Sm1.TotalMarks , Sm1.Result, Sm1.PresentStatus,  " & _
                    " Convert(BIT,CASE WHEN Sm.DocId IS NULL THEN 0 ELSE 1 END) AS IsSubjectMarksExists,  " & _
                    " Convert(BIT,CASE WHEN Sm1.Result IS NULL THEN 0 ELSE 1 END) AS IsStudentMarksExists   " & _
                    " FROM Exam_SemesterExam E WITH (NoLock) " & _
                    " LEFT JOIN Exam_ExamType Et WITH (NoLock) ON Et.Code = E.ExamType " & _
                    " LEFT JOIN Exam_SemesterExam1 E1 WITH (NoLock) ON E.Code = E1.Code  " & _
                    " LEFT JOIN Exam_SubjectMarks Sm WITH (NoLock) ON E1.Code = Sm.SemesterExam AND E1.Subject = Sm.Subject  " & _
                    " LEFT JOIN Exam_SemesterExamAdmission Ea WITH (NoLock) ON E.Code = Ea.SemesterExam  " & _
                    " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 WITH (NoLock) ON Ea.DocId = Ea1.DocId  " & _
                    " LEFT JOIN ViewSch_Admission A WITH (NoLock) ON Ea1.AdmissionDocId = A.DocId  " & _
                    " LEFT JOIN Sch_StreamYearSemester Sem WITH (NoLock) ON Ea1.StreamYearSemester = Sem.Code " & _
                    " LEFT JOIN Exam_SubjectMarks1 Sm1 WITH (NoLock) ON Sm.DocId = Sm1.DocId AND Ea1.Code = Sm1.SemesterExamAdmission1  " & _
                    " LEFT JOIN ViewSch_SemesterSubject Sub WITH (NoLock) ON Ea1.StreamYearSemester = Sub.StreamYearSemester AND E1.Subject = Sub.Subject  " & _
                    " LEFT JOIN ViewSch_Student S WITH (NoLock) ON A.Student = S.SubCode  "

            mQry = "CREATE VIEW dbo.ViewExam_AdmissionSubjectMarks As " & _
                    " " & mQry1 & " " & _
                    " WHERE Ea1.Code Is Not NULL And IsNull(Sm.IsAttendanceMarks,0) = 0 "
            AgL.IsViewExist("ViewExam_AdmissionSubjectMarks", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewExam_AdmissionSubjectMarks", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If


            mQry = "CREATE VIEW dbo.ViewExam_AdmissionSubjectAttendanceMarks As " & _
                    " " & mQry1 & " " & _
                    " WHERE Ea1.Code Is Not NULL And IsNull(Sm.IsAttendanceMarks,0) <> 0 "
            AgL.IsViewExist("ViewExam_AdmissionSubjectAttendanceMarks", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewExam_AdmissionSubjectAttendanceMarks", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            ''===================================================< Exam_SemesterExamAdmission V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_SemesterExamCreation, Academic_ProjLib.ClsMain.Cat_SemesterExamCreation, "Semester Exam Creation", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_SemesterExamCreation, Academic_ProjLib.ClsMain.Cat_SemesterExamCreation, Academic_ProjLib.ClsMain.NCat_SemesterExamCreation, "Semester Exam Creation", Academic_ProjLib.ClsMain.NCat_SemesterExamCreation, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            ''===================================================< Exam_SubjectMarks V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_SubjectMarksEntry, Academic_ProjLib.ClsMain.Cat_SubjectMarksEntry, "Subject Marks Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_SubjectMarksEntry, Academic_ProjLib.ClsMain.Cat_SubjectMarksEntry, Academic_ProjLib.ClsMain.NCat_SubjectMarksEntry, "Subject Marks Entry", Academic_ProjLib.ClsMain.NCat_SubjectMarksEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            ''===================================================< Exam_ConsolidatedSubjectMarks V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ConsolidatedSubjectMarksEntry, Academic_ProjLib.ClsMain.Cat_ConsolidatedSubjectMarksEntry, "Consolidated Subject Marks Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_ConsolidatedSubjectMarksEntry, Academic_ProjLib.ClsMain.Cat_ConsolidatedSubjectMarksEntry, Academic_ProjLib.ClsMain.NCat_ConsolidatedSubjectMarksEntry, "Consolidated Subject Marks Entry", Academic_ProjLib.ClsMain.NCat_ConsolidatedSubjectMarksEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

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


End Class