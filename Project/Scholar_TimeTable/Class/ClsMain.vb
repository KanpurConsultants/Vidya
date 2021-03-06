Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Time Table"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Class Temp_NCat
        Public Const EmployeeLeaveEntry As String = "ELEV"
    End Class

    Class SmsEvent
        Public Const TeacherLeave As String = "Teacher Leave"
		Public Const TeacherAttendance As String = "Teacher Attendance"
    End Class

#Region "Update Table Structure"
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableStructure()
        Try
            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateView()

            Call InitializeTables()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_SMS_Event()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Try
            If AgL.IsTableExist("SMS_Event", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.TeacherLeave & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.TeacherLeave & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            
            If AgL.IsTableExist("SMS_Event", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.TeacherAttendance & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.TeacherAttendance & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< TT_TimeTable >=====================================
            AgL.AddNewField(AgL.GCn, "TT_TimeTable", "IsAllTimeSlot", "bit", 0)
            ''============================< ************************* >=====================================

            ''============================< TT_ReallocateTeacher1 >=====================================
            AgL.AddNewField(AgL.GCn, "TT_ReallocateTeacher1", "IsEngageTimeSlot", "bit", 0)

            If AgL.AddNewField(AgL.GCn, "TT_ReallocateTeacher1", "TimeTableSubject", "nvarchar(8)") Then
                mQry = "UPDATE TT_ReallocateTeacher1 SET TimeTableSubject = Subject WHERE TimeTableSubject IS NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsFieldExist("TimeTableSubject", "TT_ReallocateTeacher1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_TT_ReallocateTeacher1_TimeTableSubject", "Sch_Subject", "TT_ReallocateTeacher1", "Code", "TimeTableSubject")
            End If

            AgL.AddNewField(AgL.GCn, "TT_ReallocateTeacher1", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "TT_ReallocateTeacher1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_TT_ReallocateTeacher1_SemesterStreamYearSemester", "Sch_StreamYearSemester", "TT_ReallocateTeacher1", "Code", "StreamYearSemester")
            End If

            ''============================< ************************* >=====================================

            ''============================< ************TT_TimeTable************** >==================================================
            AgL.AddNewField(AgL.GCn, "TT_TimeTable", "StreamYearSemester", "nVarChar(10)", , False)
            If AgL.IsFieldExist("StreamYearSemester", "TT_TimeTable", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_TT_TimeTable_SemesterStreamYearSemester", "Sch_StreamYearSemester", "TT_TimeTable", "Code", "StreamYearSemester")
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            'AgL.EditField("Sch_Admission", "AdmissionID", "nVarChar(61)", AgL.GCn, False)
            'AgL.AddForeignKey(AgL.GCn, "FK_VehicleHireChallan_AdvancePayAc", "SubGroup", "VehicleHireChallan", "SubCode", "AdvancePayAc")

            If AgL.IsFieldExist("StreamYearSemester", "TT_TimeTable", AgL.GCn) _
                 And AgL.IsFieldExist("WeekDay", "TT_TimeTable", AgL.GCn) _
                 And AgL.IsFieldExist("ApplyDate", "TT_TimeTable", AgL.GCn) Then

                If AgL.IsConstraintExist("IX_TT_TimeTable", "TT_TimeTable", "ClassSection,WeekDay,ApplyDate", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE TT_TimeTable DROP CONSTRAINT [IX_TT_TimeTable]", AgL.GCn)
                End If
                AgL.AddUniqueKeyConstraint("IX_TT_TimeTable", "TT_TimeTable", "StreamYearSemester,WeekDay,ApplyDate", AgL.GCn)
            End If

            AgL.EditField("TT_TimeTable", "ClassSection", "nVarChar(10)", AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = ""

        Try
            mQry = "CREATE TABLE dbo.TT_TimeTable " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " ClassSection NVARCHAR(10) NOT NULL, " & _
                    " WeekDay SMALLINT NOT NULL, " & _
                    " ApplyDate SMALLDATETIME NOT NULL, " & _
                    " Remark NVARCHAR(255) CONSTRAINT DF_TT_TimeTable_Remark DEFAULT ('') NULL, " & _
                    " Div_Code NVARCHAR(1) NOT NULL, " & _
                    " Site_Code NVARCHAR(2) NOT NULL, " & _
                    " PreparedBy NVARCHAR(10) NOT NULL, " & _
                    " U_EntDt DATETIME NOT NULL, " & _
                    " U_AE NVARCHAR(1) NOT NULL, " & _
                    " Edit_Date DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR(10) NULL, " & _
                    " CONSTRAINT PK_TT_TimeTable PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_TT_TimeTable UNIQUE (ClassSection,WeekDay,ApplyDate), " & _
                    " CONSTRAINT FK_TT_TimeTable_Sch_ClassSection FOREIGN KEY (ClassSection) REFERENCES dbo.Sch_ClassSection (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable_Sch_WeekDay FOREIGN KEY (WeekDay) REFERENCES dbo.Sch_WeekDay (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("TT_TimeTable", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("TT_TimeTable", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.TT_TimeTable1 " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " Sr INT NOT NULL, " & _
                    " TimeSlot NVARCHAR(8) NOT NULL, " & _
                    " ClassSectionSubSection NVARCHAR(10) NULL, " & _
                    " Subject NVARCHAR(8) NOT NULL, " & _
                    " Teacher NVARCHAR(10) NOT NULL, " & _
                    " CONSTRAINT PK_TT_TimeTable1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_TT_TimeTable1 UNIQUE (Code,TimeSlot,ClassSectionSubSection), " & _
                    " CONSTRAINT IX_TT_TimeTable1_1 UNIQUE (Code,TimeSlot,Teacher), " & _
                    " CONSTRAINT FK_TT_TimeTable1_TT_TimeTable FOREIGN KEY (Code) REFERENCES dbo.TT_TimeTable (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable1_Sch_TimeSlot FOREIGN KEY (TimeSlot) REFERENCES dbo.Sch_TimeSlot (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable1_Sch_ClassSectionSubSection FOREIGN KEY (ClassSectionSubSection) REFERENCES dbo.Sch_ClassSectionSubSection (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable1_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code), " & _
                    " CONSTRAINT FK_TT_TimeTable1_Pay_Employee FOREIGN KEY (Teacher) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " )"

            If Not AgL.IsTableExist("TT_TimeTable1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("TT_TimeTable1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Pay_DayAttendance " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " A_Date SMALLDATETIME NOT NULL, " & _
                    " Remark NVARCHAR(255) NULL, " & _
                    " Div_Code NVARCHAR(1) NOT NULL, " & _
                    " Site_Code NVARCHAR(2) NOT NULL, " & _
                    " PreparedBy NVARCHAR(10) NOT NULL, " & _
                    " U_EntDt DATETIME NOT NULL, " & _
                    " U_AE NVARCHAR(1) NOT NULL, " & _
                    " Edit_Date DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR(10) NULL, " & _
                    " CONSTRAINT PK_Pay_DayAttendance PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Pay_DayAttendance UNIQUE (Div_Code,Site_Code,A_Date), " & _
                    " CONSTRAINT FK_Pay_DayAttendance_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Pay_DayAttendance", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Pay_DayAttendance", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Pay_DayAttendance1 " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " Sr INT NOT NULL, " & _
                    " Employee NVARCHAR(10) NOT NULL, " & _
                    " IsPresent BIT CONSTRAINT DF_Pay_DayAttendance1_IsPresent DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Pay_DayAttendance1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Pay_DayAttendance1 UNIQUE (Code,Employee), " & _
                    " CONSTRAINT FK_Pay_DayAttendance1_Pay_DayAttendance FOREIGN KEY (Code) REFERENCES dbo.Pay_DayAttendance (Code), " & _
                    " CONSTRAINT FK_Pay_DayAttendance1_Pay_Employee FOREIGN KEY (Employee) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Pay_DayAttendance1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Pay_DayAttendance1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.TT_ReallocateTeacher " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " ReallocationDate SMALLDATETIME NOT NULL, " & _
                    " Teacher NVARCHAR(10) NOT NULL, " & _
                    " Remark NVARCHAR(255) NULL, " & _
                    " Div_Code NVARCHAR(1) CONSTRAINT DF_TT_ReallocateTeacher_Remark DEFAULT ('') NOT NULL, " & _
                    " Site_Code NVARCHAR(2) NOT NULL, " & _
                    " PreparedBy NVARCHAR(10) NOT NULL, " & _
                    " U_EntDt DATETIME NOT NULL, " & _
                    " U_AE NVARCHAR(1) NOT NULL, " & _
                    " Edit_Date DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR(10) NULL, " & _
                    " CONSTRAINT PK_TT_ReallocateTeacher PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_TT_ReallocateTeacher UNIQUE (ReallocationDate,Teacher), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher_Pay_Employee FOREIGN KEY (Teacher) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("TT_ReallocateTeacher", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("TT_ReallocateTeacher", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.TT_ReallocateTeacher1 " & _
                    " ( " & _
                    " Code NVARCHAR(10) NOT NULL, " & _
                    " Sr INT NOT NULL, " & _
                    " TimeSlot NVARCHAR(8) NOT NULL, " & _
                    " ClassSectionSubSection NVARCHAR(10) NULL, " & _
                    " Subject NVARCHAR(8) NOT NULL, " & _
                    " ReallocateTeacher NVARCHAR(10) NULL, " & _
                    " TimeTable NVARCHAR(10) NOT NULL, " & _
                    " CONSTRAINT PK_TT_ReallocateTeacher1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_TT_ReallocateTeacher1 UNIQUE (Code,TimeSlot), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_TT_ReallocateTeacher FOREIGN KEY (Code) REFERENCES dbo.TT_ReallocateTeacher (Code), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_Sch_ClassSectionSubSection FOREIGN KEY (ClassSectionSubSection) REFERENCES dbo.Sch_ClassSectionSubSection (Code), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_Sch_TimeSlot FOREIGN KEY (TimeSlot) REFERENCES dbo.Sch_TimeSlot (Code), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_Pay_Employee FOREIGN KEY (ReallocateTeacher) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_TT_ReallocateTeacher1_TT_TimeTable FOREIGN KEY (TimeTable) REFERENCES dbo.TT_TimeTable (Code) " & _
                    " )"
            If Not AgL.IsTableExist("TT_ReallocateTeacher1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("TT_ReallocateTeacher1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section
        Try
            mQry = "CREATE VIEW dbo.ViewTT_TimeTable As " & _
                    " SELECT T.* , D.Description AS WeekDayDesc, D.ManualCode AS WeekDayManualCode, " & _
                    " S.ClassSectionDesc , S.IsOpenElectiveSection , S.Section , S.SessionCode ,  S.SessionDescription, S.SessionManualCode , S.SessionProgramme AS SessionProgrammeCode, S.SessionProgrammeDesc, S.TotalSubsection " & _
                    " FROM TT_TimeTable T " & _
                    " LEFT JOIN Sch_WeekDay D ON D.Code = T.WeekDay  " & _
                    " LEFT JOIN ViewSch_ClassSection S ON T.ClassSection = S.Code  "

            AgL.IsViewExist("ViewTT_TimeTable", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewTT_TimeTable", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewTT_TimeTable1 As " & _
                    " SELECT T1.* , T.ApplyDate, T.ClassSection AS ClassSectionCode,  T.WeekDay WeekDayCode , T.WeekDayDesc, T.WeekDayManualCode, T.Site_Code , T.Div_Code  ,  S1.ClassSectionSubSectionDesc , S1.SubSection,  " & _
                    " T.ClassSectionDesc , T.IsOpenElectiveSection , T.Section , T.SessionCode ,  T.SessionDescription, T.SessionManualCode , T.SessionProgrammeCode, T.SessionProgrammeDesc, T.TotalSubsection, " & _
                    " Sub.Description AS SubjectDesc, Sub.DisplayName AS SubjectDisplayName, Sub.ManualCode AS SubjectManualCode, Sub.SubjectType , Sub.SubjectGroup AS SubjectGroupCode, " & _
                    " Sg.Name AS TeacherName, Ts.Description AS TimeSlotDesc, Ts.Duration AS TimeSlotDuration, Ts.StartTime, Ts.EndTime " & _
                    " FROM ViewTT_TimeTable T " & _
                    " LEFT JOIN TT_TimeTable1 T1 ON T.Code = T1.Code  " & _
                    " LEFT JOIN Sch_TimeSlot Ts ON T1.TimeSlot = Ts.Code  " & _
                    " LEFT JOIN Sch_Subject Sub ON T1.Subject = Sub.Code  " & _
                    " LEFT JOIN Pay_Employee E ON T1.Teacher = E.SubCode  " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode  " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 ON T1.ClassSectionSubSection = S1.Code  "

            AgL.IsViewExist("ViewTT_TimeTable1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewTT_TimeTable1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            ''===================================================< Employee Leave Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.EmployeeLeaveEntry, ClsMain.Temp_NCat.EmployeeLeaveEntry, "Employee Leave Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.EmployeeLeaveEntry, ClsMain.Temp_NCat.EmployeeLeaveEntry, ClsMain.Temp_NCat.EmployeeLeaveEntry, "Employee Leave Entry", ClsMain.Temp_NCat.EmployeeLeaveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ''===================================================< ************** >===================================================

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

    Public Sub InitializeTables()
        TB_PostingGroupSalesTaxParty()
        TB_SMS_Event()
    End Sub

    Private Sub TB_PostingGroupSalesTaxParty()
        Dim mQry$ = ""

        'If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Local & "'", AgL.GCn).ExecuteScalar = 0 Then
        '    mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Local & "',1)"
        '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        'End If
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FPay_Leave(MdlTable, "Pay_Leave")
    End Sub

    Private Sub FPay_Leave(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ClsMain.ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ToDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalDays", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "CancelledBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CancelledDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)


        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub
#End Region

End Class