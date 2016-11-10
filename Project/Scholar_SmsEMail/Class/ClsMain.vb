Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "SMS & EMail"
    'Public MdlTable As AgLibrary.ClsMain.LITable()

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        ObjAgTemplate = New AgTemplate.ClsMain(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtSms_Enviro()
    End Sub

    Public Shared PurchaseAddition_Text = "Addition"
    Public Shared PurchaseAddition_H_Text = "Addition"
    Public Shared PurchaseDeduction_Text = "Deduction"
    Public Shared PurchaseDeduction_H_Text = "Deduction"
    Public Shared SaleAddition_Text = "Addition"
    Public Shared SaleAddition_H_Text = "Addition"
    Public Shared SaleDeduction_Text = "Deduction"
    Public Shared SaleDeduction_H_Text = "Deduction"

    Public Shared Item_Nature1_Description = "Item Nature1"
    Public Shared Item_Nature2_Description = "Item Nature2"
    Public Shared Item_Batch_Description = "Batch No"


    Class OwnRental
        Public Const Own As String = "Own"
        Public Const Rental As String = "Rental"
    End Class

    Class MemberType
        Public Const Student As String = "Student"
        Public Const Employee As String = "Employee"
    End Class

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Enum ReportType
        Main
        Log
    End Enum

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

    Public Class PostingGroupSalesTaxParty
        Public Const Local As String = "Local"
        Public Const Central As String = "Central"
        Public Const LocalWithFormH As String = "Local {Form `H`}"
        Public Const CentralWithFormC As String = "Central {Form `C`}"
        Public Const Export As String = "Export"
    End Class

    Class Temp_NCat
        Public Const CanteenPurchase As String = "CPUR"
        Public Const CanteenPurchaseReturn As String = "CPRT"

        Public Const CanteenSale As String = "CSAL"
        Public Const CanteenSaleReturn As String = "CSRT"

        Public Const CanteenStockAdjustment As String = "CSADJ"
        Public Const CanteenStockOpening As String = "CSOP"
    End Class

    Class Temp_Structure
        Public Const CanteenPurchase As String = "CPUR"
        Public Const CanteenPurchaseReturn As String = "CPRT"

        Public Const CanteenSale As String = "CSAL"
        Public Const CanteenSaleReturn As String = "CSRT"
    End Class

    Class SmsCategorty
        Public Const CommonEnquiry As String = "Common SMS Enquiry"
        Public Const CommonEmployee As String = "Common SMS Employee"
        Public Const CommonStudent As String = "Common SMS Student"
        Public Const StudentDueSms As String = "Student Due SMS"
    End Class

    Class SmsStatus
        Public Const Pending As String = "Pending"
        Public Const Send As String = "Send"
    End Class

    Public Class Temp_Charges
        Public Const GrossAmount As String = "GAMT"
        Public Const LineAddition As String = "LAdd"
        Public Const LineDeduction As String = "LDed"
        Public Const LineNetAmount As String = "LNAmt"
        Public Const HeaderAddition As String = "HAdd"
        Public Const HeaderDeduction As String = "HDed"
        Public Const NetSubTotal As String = "NSTot"
        Public Const RoundOff As String = "ROff"
        Public Const NetAmount As String = "NAMT"
    End Class




#Region " Structure Update Code "
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableInitialiser()
        Call EditField()
        Call DeleteField()
        Call CreateVType()
        Call CreateView()
        Call InitializeTables()
        Call InitializeStructure()
    End Sub

    Sub EditField()
        Dim mQry$ = ""
        Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()

        Try
            'AgL.EditField("Store_Item", "Unit", "nvarchar(20)", GcnRead)
            AgL.AddNewField(AgL.GCn, "Sms_Trans", "DocID", "nVarChar(36)")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            'If AgL.IsFieldExist("ScholarshipApplied", "Sch_Student", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP CONSTRAINT [DF_Sch_Student_EnglishProficiency_TOEFL1]", AgL.GCn)
            '    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP COLUMN ScholarshipApplied", AgL.GCn)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Function RetDivFilterStr() As String
        Try
            RetDivFilterStr = "IsNull(Div_Code,'" & AgL.PubDivCode & "') = '" & AgL.PubDivCode & "'"
        Catch ex As Exception
            RetDivFilterStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            'mQry = "CREATE VIEW dbo.ViewSch_SessionProgramme AS " & _
            '        " SELECT  SP.*, S.ManualCode AS SessionManualCode, S.Description AS SessionDescription, S.StartDate AS SessionStartDate, S.EndDate AS SessionEndDate, P.Description AS ProgrammeDescription, P.ManualCode AS ProgrammeManualCode, P.ProgrammeDuration, P.Semesters AS ProgrammeSemesters, P.SemesterDuration AS ProgrammeSemesterDuration, P.ProgrammeNature , PN.Description AS ProgrammeNatureDescription  , P.ManualCode  +'/' + S.ManualCode   AS SessionProgramme " & _
            '        " FROM Sch_SessionProgramme SP " & _
            '        " LEFT JOIN Sch_Session S ON sp.Session =S.Code  " & _
            '        " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
            '        " LEFT JOIN Sch_ProgrammeNature PN ON P.ProgrammeNature =PN.Code "

            'AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GCn, True)
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GcnSite, True)
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            ' ''===================================================< Canteen Purchase Entry V_Type >===================================================
            'AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.CanteenPurchase, ClsMain.Temp_NCat.CanteenPurchase, "Canteen Purchase", AgL.PubSiteCode)
            'AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.CanteenPurchase, ClsMain.Temp_NCat.CanteenPurchase, ClsMain.Temp_NCat.CanteenPurchase, "Canteen Purchase", ClsMain.Temp_NCat.CanteenPurchase, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            ' ''===================================================< ************** >===================================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FSms_Trans(MdlTable, "Sms_Trans")
    End Sub

    Private Sub FSms_Trans(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MsgDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Msg", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "DueAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Public Sub InitializeTables()
        'TB_PostingGroupSalesTaxParty()
    End Sub

    Public Sub InitializeStructure()
        'Call ST_CanteenPurchase()
    End Sub

    Private Function FunFindField(ByVal SqlConn As SqlClient.SqlConnection, ByVal StrColumnName As String, ByVal StrTableName As String, Optional ByVal IntFieldSize As Integer = 0) As Boolean
        Dim mQry$ = "", bCondStr$ = "Where 1=1 "
        Dim bBlnReturn As Boolean = False
        Try
            bCondStr += " And T.COLUMN_NAME = '" & StrColumnName & "' " & _
                            " AND T.TABLE_NAME = '" & StrTableName & "' "

            If IntFieldSize > 0 Then
                bCondStr += " AND T.CHARACTER_MAXIMUM_LENGTH = " & IntFieldSize & " "
            End If

            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM INFORMATION_SCHEMA.COLUMNS T With (NoLock) " & bCondStr
            If AgL.Dman_Execute(mQry, SqlConn).ExecuteScalar > 0 Then
                bBlnReturn = True
            End If
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunFindField = bBlnReturn
        End Try
    End Function

#End Region
End Class