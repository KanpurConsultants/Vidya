Public Class ClsReportProcedures

#Region "Danger Zone"
    Dim StrArr1() As String = Nothing, StrArr2() As String = Nothing, StrArr3() As String = Nothing, StrArr4() As String = Nothing, StrArr5() As String = Nothing

    Dim mGRepFormName As String = ""
    Dim WithEvents ObjRFG As AgLibrary.RepFormGlobal

    Public Property GRepFormName() As String
        Get
            GRepFormName = mGRepFormName
        End Get
        Set(ByVal value As String)
            mGRepFormName = value
        End Set
    End Property

#End Region

#Region "Common Reports Constant"
    Private Const CityList As String = "CityList"
    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
#End Region

#Region "Reports Constant"
    Private Const QualityMasterReport As String = "QualityMasterReport"
    Private Const QualityMasterLogReport As String = "QualityMasterLogReport"
    Private Const DesignMasterReport As String = "DesignMasterReport"
    Private Const DesignMasterLogReport As String = "DesignMasterLogReport"
    Private Const YarnMasterReport As String = "YarnMasterReport"
    Private Const YarnMasterLogReport As String = "YarnMasterLogReport"
    Private Const ShadeMasterReport As String = "ShadeMasterReport"
    Private Const ShadeMasterLogReport As String = "ShadeMasterLogReport"
    Private Const YarnSkuMasterReport As String = "YarnSkuMasterReport"
    Private Const YarnSkuMasterLogReport As String = "YarnSkuMasterLogReport"
    Private Const SizeMasterReport As String = "SizeMasterReport"
    Private Const SizeMasterLogReport As String = "SizeMasterLogReport"
    Private Const BuyerMasterReport As String = "BuyerMasterReport"
    Private Const BuyerMasterLogReport As String = "BuyerMasterLogReport"
    Private Const PortMasterReport As String = "PortMasterReport"
    Private Const PortMasterLogReport As String = "PortMasterLogReport"
    Private Const CityMasterReport As String = "CityMasterReport"
    Private Const CityMasterLogReport As String = "CityMasterLogReport"
    Private Const OtherMaterialMasterReport As String = "OtherMaterialMasterReport"
    Private Const OtherMaterialLogReport As String = "OtherMaterialLogReport"
    Private Const CarpetSKUMasterReport As String = "CarpetSKUMasterReport"
    Private Const CarpetSKULogReport As String = "CarpetSKULogReport"
    Private Const CarpetSKUConsumptionMasterReport As String = "CarpetSKUConsumptionMasterReport"
    Private Const CarpetSKUConsumptionMasterLogReport As String = "CarpetSKUConsumptionMasterLogReport"
    Private Const DesignConsumptionMasterReport As String = "DesignConsumptionMasterReport"
    Private Const DesignConsumptionMasterLogReport As String = "DesignConsumptionMasterLogReport"
    Private Const GodownMasterReport As String = "GodownMasterReport"
    Private Const GodownMasterLogReport As String = "GodownMasterLogReport"


    Private Const ExportOrderLogReport As String = "ExportOrderLogReport"
    Private Const ExportOrderReport As String = "ExportOrderReport"
    Private Const ExportOrderMISReport As String = "ExportOrderMISReport"
    Private Const ProductionOrderReport As String = "ProductionOrderReport"
    Private Const ProductionOrderLogReport As String = "ProductionOrderLogReport"
    Private Const ProductionPlanReport As String = "ProductionPlanReport"
    Private Const ProductionPlanLogReport As String = "ProductionPlanLogReport"
    Private Const MaterialPlanReport As String = "MaterialPlanReport"
    Private Const MaterialPlanLogReport As String = "MaterialPlanLogReport"
    Private Const OtherMaterialPlanReport As String = "OtherMaterialPlanReport"
    Private Const OtherMaterialPlanLogReport As String = "OtherMaterialPlanLogReport"


    Private Const StockSummary As String = "StockReport(Summary)"
    Private Const StockReport As String = "StockReport(Detail)"
    Private Const StockInHand As String = "StockInHand"


#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpPortQry$ = "Select Convert(BIT,0) As [Select],P.Code ,P.Description ,C.CityName AS City FROM SeaPort P LEFT JOIN City C ON C.CityCode=P.City "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpDivisionQry$ = "Select Convert(BIT,0) As [Select], Div_Code AS Code,Div_Name AS Division FROM Division WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
    Dim mHelpStateQry$ = "Select DISTINCT Convert(BIT,0) As [Select], State AS Code,State FROM City WHERE State IS NOT NULL "
    Dim mHelpCountryQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Country AS Code,Country FROM City WHERE Country IS NOT NULL "
    Dim mHelpBuyerQry$ = " Select DISTINCT Convert(BIT,0) As [Select], B.SubCode AS Code,S.Name AS Buyer,S.DispName AS BuyerDisp,C.CityName AS City " & _
                            " FROM Buyer B " & _
                            " LEFT JOIN SubGroup S ON S.SubCode=B.SubCode  " & _
                            " LEFT JOIN City C ON C.CityCode=S.CityCode  "
    Dim mHelpAcGroupQry$ = "Select DISTINCT Convert(BIT,0) As [Select], GroupCode AS Code,GroupName  FROM AcGroup A "


    Dim mHelpConstructionQry$ = "Select Convert(BIT,0) As [Select], Code,Code AS Costruction FROM RUG_Construction "
    Dim mHelpQualityQry$ = "Select Convert(BIT,0) As [Select], Code,Description AS Quality,ManualCode AS [Short Name] FROM RUG_Quality  "
    Dim mHelpYarnGroupQry$ = "Select DISTINCT Convert(BIT,0) As [Select], YarnGroup AS Code,YarnGroup AS Name FROM RUG_Yarn WHERE YarnGroup IS NOT NULL "
    Dim mHelpTwistQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Twist AS Code,Twist AS Name FROM RUG_Yarn WHERE Twist IS NOT NULL "
    Dim mHelpPlyQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Ply AS Code,Ply AS Name FROM RUG_Yarn WHERE Ply IS NOT NULL "
    Dim mHelpCountQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Count AS Code,Count AS Name FROM RUG_Yarn WHERE Count IS NOT NULL "
    Dim mHelpColourQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Colour AS Code,Colour AS Colour FROM RUG_Shade WHERE Colour IS NOT NULL "
    Dim mHelpDesignQry$ = "Select DISTINCT Convert(BIT,0) As [Select], D.Code,D.Description AS Design,D.ManualCode AS [Short Name]  FROM RUG_Design D "
    Dim mHelpSizeQry$ = "Select DISTINCT Convert(BIT,0) As [Select], S.Code,S.Description AS Size FROM Rug_Size S "
    Dim mHelpPantoneQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Pantone AS Code,Pantone AS Pantone FROM RUG_Shade WHERE Pantone IS NOT NULL "
    Dim mHelpYarnQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Code,Description AS Yarn,ManualCode  AS [Short Name] FROM RUG_Yarn "
    Dim mHelpShadeQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Code,Description AS Shade,Colour,Pantone FROM RUG_Shade "
    Dim mHelpShapeQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Shape AS Code,Shape FROM Rug_Size WHERE Shape IS NOT NULL "
    Dim mHelpOtherMaterialQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.Code,I.ManualCode AS Material ,I.Description  FROM Item I WHERE I.ItemType ='" & ClsMain.ItemType.OtherMaterial & "'  "
    Dim mHelpCarpetSkuQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.Code,I.Description  AS [Carpet SKU] FROM Item I WHERE I.ItemType ='" & ClsMain.ItemType.CarpetSKU & "'  "
    Dim mHelpYarnSkuQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.Code,I.Description  AS [Yarn SKU] FROM Item I WHERE I.ItemType ='" & ClsMain.ItemType.YarnSKU & "'  "
    Dim mHelpItemQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.Code,I.Description  AS Item FROM Item I  "
    Dim mHelpItemTypeQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.ItemType AS Code,I.ItemType AS [Item Type] FROM Item I WHERE I.ItemType IS NOT NULL "
    Dim mHelpGodownQry$ = "Select Convert(BIT,0) As [Select], Code,Description AS Godown FROM Godown "
    Dim mHelpProcessGroupQry$ = "Select Convert(BIT,0) As [Select], P.Code,P.Description AS [Proess GROUP] FROM ProcessGroup P "
    Dim mHelpProcessQry$ = "Select DISTINCT Convert(BIT,0) As [Select], P.NCat As Code, Vc.NCatDescription As Process From Process P LEFT JOIN VoucherCat Vc On P.NCat  = Vc.NCat "

    Dim mHelpExportOrderType$ = "Select DISTINCT Convert(BIT,0) As [Select], Vt.NCat  AS Code ,Vt.Description AS [ORDER Type] FROM Voucher_Type Vt WHERE Vt.NCat in (" & AgL.Chk_Text(AgTemplate_Sale.ClsMain.Temp_NCat.SaleOrder) & ") "
    Dim mHelpProductionOrderType$ = "Select DISTINCT Convert(BIT,0) As [Select], Vt.NCat  AS Code ,Vt.Description AS [ORDER Type] FROM Voucher_Type Vt WHERE Vt.NCat in (" & AgL.Chk_Text(AgTemplate_Production.ClsMain.Temp_NCat.ProductionOrder) & ") "
    Dim mHelpProductionOrderNo$ = " Select DISTINCT Convert(BIT,0) As [Select], S.DocID,Vt.Description +'/'+ convert(NVARCHAR(5),S.V_No) AS [Production Order] " & _
                                    " FROM ProdOrder S  " & _
                                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=S.V_Type "
    Dim mHelpProductionPlanNo$ = " Select DISTINCT Convert(BIT,0) As [Select], S.DocID,Vt.Description +'/'+ convert(NVARCHAR(5),S.V_No) AS [Production Order] " & _
                                " FROM ProdPlan S  " & _
                                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=S.V_Type "

    Dim mHelpPortStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM SeaPort WHERE Status IS NOT NULL  "
    Dim mHelpCityStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM City WHERE Status IS NOT NULL  "
    Dim mHelpSubGroupStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM SubGroup WHERE Status IS NOT NULL  "
    Dim mHelpOtherMaterialStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM Item WHERE Status IS NOT NULL AND ItemType='" & ClsMain.ItemType.OtherMaterial & "' "
    Dim mHelpCarpetSkuStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM Item WHERE Status IS NOT NULL AND ItemType='" & ClsMain.ItemType.CarpetSKU & "' "
    Dim mHelpCarpetConsStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM BOM WHERE Status IS NOT NULL "
    Dim mHelpQualityStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM RUG_Quality WHERE Status IS NOT NULL "
    Dim mHelpDesignStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM RUG_Design WHERE Status IS NOT NULL "
    Dim mHelpYarnStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM RUG_Yarn WHERE Status IS NOT NULL "
    Dim mHelpShadeStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM RUG_Shade WHERE Status IS NOT NULL "
    Dim mHelpYarnSkuStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM Item WHERE Status IS NOT NULL AND ItemType='" & ClsMain.ItemType.YarnSKU & "' "
    Dim mHelpSizeStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM RUG_Size WHERE Status IS NOT NULL "
    Dim mHelpExportOrderStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM SaleOrder WHERE Status IS NOT NULL "
    Dim mHelpProductionOrderStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM ProdOrder WHERE Status IS NOT NULL "
    Dim mHelpGodownStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM Godown WHERE Status IS NOT NULL "
    Dim mHelpProductionPlanStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM ProdPlan WHERE Status IS NOT NULL "
    Dim mHelpMaterialPlanStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM MaterialPlan WHERE Status IS NOT NULL "

#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""
    Dim mRepType As ClsMain.ReportType

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case QualityMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpConstructionQry, "Costruction")
                    ObjRFG.CreateHelpGrid(mHelpQualityQry, "Quality")
                    ObjRFG.CreateHelpGrid(mHelpQualityStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case QualityMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Quality Code"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpConstructionQry, "Costruction")
                    ObjRFG.CreateHelpGrid(mHelpQualityQry, "Quality")
                    mRepType = ClsMain.ReportType.Log

                Case DesignMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpConstructionQry, "Costruction")
                    ObjRFG.CreateHelpGrid(mHelpQualityQry, "Quality")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpDesignStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case DesignMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Design Code"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpConstructionQry, "Costruction")
                    ObjRFG.CreateHelpGrid(mHelpQualityQry, "Quality")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    mRepType = ClsMain.ReportType.Log

                Case YarnMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpYarnGroupQry, "Yarn Group")
                    ObjRFG.CreateHelpGrid(mHelpTwistQry, "Twist")
                    ObjRFG.CreateHelpGrid(mHelpPlyQry, "Ply")
                    ObjRFG.CreateHelpGrid(mHelpCountQry, "Count")
                    ObjRFG.CreateHelpGrid(mHelpYarnQry, "Yarn")
                    ObjRFG.CreateHelpGrid(mHelpYarnStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case YarnMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Yarn Code"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpYarnGroupQry, "Yarn Group")
                    ObjRFG.CreateHelpGrid(mHelpTwistQry, "Twist")
                    ObjRFG.CreateHelpGrid(mHelpPlyQry, "Ply")
                    ObjRFG.CreateHelpGrid(mHelpCountQry, "Count")
                    ObjRFG.CreateHelpGrid(mHelpYarnQry, "Yarn")
                    mRepType = ClsMain.ReportType.Log

                Case ShadeMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpColourQry, "Colour")
                    ObjRFG.CreateHelpGrid(mHelpPantoneQry, "Pantone")
                    ObjRFG.CreateHelpGrid(mHelpShadeQry, "Shade")
                    ObjRFG.CreateHelpGrid(mHelpShadeStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case ShadeMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Shade Description"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpColourQry, "Colour")
                    ObjRFG.CreateHelpGrid(mHelpPantoneQry, "Pantone")
                    ObjRFG.CreateHelpGrid(mHelpShadeQry, "Shade")
                    mRepType = ClsMain.ReportType.Log

                Case YarnSkuMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpYarnQry, "Yarn")
                    ObjRFG.CreateHelpGrid(mHelpShadeQry, "Shade")
                    ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    ObjRFG.CreateHelpGrid(mHelpYarnSkuStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case YarnSkuMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Yarn Sku Description"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpYarnQry, "Yarn")
                    ObjRFG.CreateHelpGrid(mHelpShadeQry, "Shade")
                    ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    mRepType = ClsMain.ReportType.Log

                Case SizeMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpShapeQry, "Shape")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSizeStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case SizeMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Size Description"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpShapeQry, "Shape")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    mRepType = ClsMain.ReportType.Log

                Case CityMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpStateQry, "State")
                    ObjRFG.CreateHelpGrid(mHelpCountryQry, "Country")
                    ObjRFG.CreateHelpGrid(mHelpCityStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case CityMasterLogReport
                    StrArr1 = New String() {"Modify Date", "City Description"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpStateQry, "State")
                    ObjRFG.CreateHelpGrid(mHelpCountryQry, "Country")
                    ObjRFG.CreateHelpGrid(mHelpCityStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case PortMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpPortQry, "Port")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpPortStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case PortMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Port Description"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpPortQry, "Port")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpPortStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case BuyerMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Buyer")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpAcGroupQry, "A/c Group")
                    ObjRFG.CreateHelpGrid(mHelpSubGroupStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case BuyerMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Buyer Name"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Buyer")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpAcGroupQry, "A/c Group")
                    ObjRFG.CreateHelpGrid(mHelpSubGroupStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case OtherMaterialMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpOtherMaterialQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpOtherMaterialStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case OtherMaterialLogReport
                    StrArr1 = New String() {"Modify Date", "Item Name"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpOtherMaterialQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpOtherMaterialStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case CarpetSKUMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case CarpetSKULogReport
                    StrArr1 = New String() {"Modify Date", "Carpet SKU"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case CarpetSKUConsumptionMasterReport, DesignConsumptionMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    If GRepFormName = DesignConsumptionMasterReport Then
                        ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    End If
                    ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    ObjRFG.CreateHelpGrid(mHelpPantoneQry, "Pantone")
                    ObjRFG.CreateHelpGrid(mHelpColourQry, "Colour")
                    ObjRFG.CreateHelpGrid(mHelpCarpetConsStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case CarpetSKUConsumptionMasterLogReport, DesignConsumptionMasterLogReport
                    Dim btempstring As String = ""

                    If GRepFormName = DesignConsumptionMasterLogReport Then
                        btempstring = "Design"
                    Else
                        btempstring = "Carpet SKU"
                    End If

                    StrArr1 = New String() {"Modify Date", btempstring}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    If GRepFormName = DesignConsumptionMasterLogReport Then
                        ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    End If
                    ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    ObjRFG.CreateHelpGrid(mHelpPantoneQry, "Pantone")
                    ObjRFG.CreateHelpGrid(mHelpColourQry, "Colour")
                    ObjRFG.CreateHelpGrid(mHelpCarpetConsStatus, "Status")
                    mRepType = ClsMain.ReportType.Log

                Case ExportOrderReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    StrArr3 = New String() {"All", "Pending", "Shipped"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1, , "Report Type", StrArr2, , "Report For", StrArr3)
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpExportOrderType, "Order Type")
                    ObjRFG.CreateHelpGrid(mHelpExportOrderStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case ExportOrderLogReport
                    StrArr1 = New String() {"Modify Date", "Order No"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpExportOrderType, "Order Type")
                    mRepType = ClsMain.ReportType.Log

                Case ExportOrderMISReport
                    StrArr1 = New String() {"Party", "Carpet SKU", "Design", "Size"}
                    StrArr2 = New String() {"All", "Pending for Shipping", "Shipped"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Group On", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpExportOrderType, "Order Type")

                Case ProductionOrderReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    'StrArr3 = New String() {"All", "Pending", "Shipped"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpProductionOrderType, "Order Type")
                    ObjRFG.CreateHelpGrid(mHelpProductionOrderStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case ProductionOrderLogReport
                    StrArr1 = New String() {"Modify Date", "Order No"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpDesignQry, "Design")
                    ObjRFG.CreateHelpGrid(mHelpSizeQry, "Size")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpProductionOrderType, "Order Type")
                    mRepType = ClsMain.ReportType.Log

                Case GodownMasterReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown")
                    ObjRFG.CreateHelpGrid(mHelpGodownStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case GodownMasterLogReport
                    StrArr1 = New String() {"Modify Date", "Godown"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown")
                    mRepType = ClsMain.ReportType.Log

                Case StockSummary, StockReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown")
                    ObjRFG.CreateHelpGrid(mHelpItemTypeQry, "Item Type")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpProcessGroupQry, "Process Group")
                    ObjRFG.CreateHelpGrid(mHelpProcessQry, "Process")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")

                Case StockInHand
                    Call ObjRFG.Ini_Grp("AS On Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown")
                    ObjRFG.CreateHelpGrid(mHelpItemTypeQry, "Item Type")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpProcessGroupQry, "Process Group")
                    ObjRFG.CreateHelpGrid(mHelpProcessQry, "Process")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")

                Case ProductionPlanReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    StrArr3 = New String() {"All", "Pending", "Received"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1, , "Report Type", StrArr2, , "Report For", StrArr3)
                    ObjRFG.CreateHelpGrid(mHelpProductionOrderNo, "Production Order No.")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpProductionPlanStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case ProductionPlanLogReport
                    StrArr1 = New String() {"Modify Date", "Plan No"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpProductionOrderNo, "Production Order No.")
                    ObjRFG.CreateHelpGrid(mHelpCarpetSkuQry, "Carpet SKU")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    mRepType = ClsMain.ReportType.Log

                Case MaterialPlanReport, OtherMaterialPlanReport
                    StrArr1 = New String() {"No", "Yes", "All"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    ObjRFG.Ini_Grp(, , , , "Is Deleted ?", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpProductionPlanNo, "Production Plan No.")

                    If GRepFormName = MaterialPlanReport Then
                        ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpOtherMaterialQry, "Other Item")
                    End If

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpMaterialPlanStatus, "Status")
                    mRepType = ClsMain.ReportType.Main

                Case MaterialPlanLogReport, OtherMaterialPlanLogReport
                    StrArr1 = New String() {"Modify Date", "Plan No"}
                    StrArr2 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Modify Date From", AgL.PubStartDate, "Modify Date To", AgL.PubLoginDate, "Sort On", StrArr1, , "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpProductionPlanNo, "Production Plan No.")

                    If GRepFormName = MaterialPlanLogReport Then
                        ObjRFG.CreateHelpGrid(mHelpYarnSkuQry, "Yarn SKU")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpOtherMaterialQry, "Other Item")
                    End If

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    mRepType = ClsMain.ReportType.Log
            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case QualityMas�erReport, QualityMasterLogReport
                ProcQualityMasterReport*)

            Case DesignMasterReport, Design�ast%rLogReport
            !   PbocDesignMasterReport()

            Case YarnMasterReport, YarnMaster�ogReport
                ProcYarnMacterReport()

            Case ShadeMastavReport, shadeMastezLogReport
                QrocShadeMasderRe0ort()

            Case YarnSkuMasterRexOrt, Yar�SkuMasterDogReport
                ProcYarnSkuMasterReport()

            Cise SizeMasterReport, SizeMasterLogRep�rt
      �       " ProcSizeMasterReport()	

            Casu BuyerMasterLogReport, BuyebMasterRep/rt
  �             XrocbuyerMasterRepovt()

        (   Case0PortMasterReport, PortMasterLoGReport
           (    ProcPortMasterReport()
�            Case CityMasterDogReport, Cit�masterReport                ProcCityMasterReport()

"           Case OtherMaverialLogRdport, OtherMateriamMasterReport
                ProcOtherMaterialMasterReport()

            Case CarpetSKULogReport, CarpetSKUMasterReport
                ProcCarpetSKUMasterReport()

            Case CarpetSKUConsumptionMasterReport, CarpetSKUConsumptionMasterLogReport
                ProcCarpetSKUConsumptionMasterReport("Carpet SKU")

            Case DesignConsumptionMasterReport, DesignConsumptionMasterLogReport
                ProcCarpetSKUConsumptionMasterReport("Design")

            Case ExportOrderLogReport, ExportOrderReport
                ProcExportReport()

            Case ExportOrderMISReport
                ProcExportOrderMISReport()

            Case ProductionOrderLogReport, ProductionOrderReport
                ProcProdOrderReport()

            Case GodownMasterLogReport, GodownMasterReport
                ProcGodownMasterReport()

            Case StockSummary
                procStockSummary("Stock Summary")
            Case StockReport
                procStockSummary("Stock Report")
            Case StockInHand
                procStockSummary("Stock In Hand")

            Case ProductionPlanLogReport, ProductionPlanReport
                ProcProdPlanReport()

            Case MaterialPlanLogReport, MaterialPlanReport
                ProcMaterialPlanReport(AgTemplate_Production.ClsMain.Temp_NCat.MaterialPlan, "Yarn SKU")

            Case OtherMaterialPlanLogReport, OtherMaterialPlanReport
                ProcMaterialPlanReport(ClsMain.Temp_NCat.OtherMaterialPlan, "Other Item", "Other ")
        End Select
    End Sub

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

#Region "Quality Master Report"
    Private Sub ProcQualityMasterReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecondryTable$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By RQ.EntryDate Desc"
            Else
                mOrderBy = "Order By RQ.ManualCode"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "RUG_Quality_Log"
                bSecondryTable = "RUG_QualityDetail_Log"
                RepName = "RUG_QualityMasterLogReport" : RepTitle = "Quality Master Log Report"
            Else
                bTableName = "RUG_Quality"
                bSecondryTable = "RUG_QualityDetail"
                RepName = "RUG_QualityMasterReport" : RepTitle = "Quality Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(RQ.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(RQ.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("RQ.Status", 3)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("RQ.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If



            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RQ.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RQ.Construction", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RQ.Code", 2)

            mQry = " SELECT RQ.Code,RQ.ManualCode,RQ.Description,RQ.Construction,RQ.StdRugWeight,RQ.PileWeight,RQ.PileHeight," & _
                    " RQ.TuftPerSqrInch,RQ.WashingType,RQ.Clipping,RQ.Fringes,RQ.TotalQty,RQ.EntryBy,RQ.EntryDate,RQ.EntryType, " & _
                    " RQ.EntryStatus, RQ.ApproveBy, RQ.ApproveDate, RQ.MoveToLog, RQ.MoveToLogDate, RQ.IsDeleted, " & _
                    " RQ1.Sr +1 AS Sr ,RQ1.OtherMaterial,I.Description AS OthermaterialDesc,RQ1.QtyPerSqrYard,RQ1.Unit,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType " & _
                    " FROM " & bTableName & " RQ " & _
                    " LEFT JOIN " & bSecondryTable & " RQ1 ON RQ1.Code = RQ.Code " & _
                    " LEFT JOIN Item I ON I.Code = RQ1.OtherMaterial " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Design Master Report"
    Private Sub ProcDesignMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By RD.EntryDate Desc"
            Else
                mOrderBy = "Order By RD.ManualCode"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "RUG_Design_Log"
                RepName = "RUG_DesignMasterLogReport" : RepTitle = "Design Master Log Report"
            Else
                bTableName = "RUG_Design"
                RepName = "RUG_DesignMasterReport" : RepTitle = "Design Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(RD.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(RD.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("RD.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("RD.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RD.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RD.Construction", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RD.QualityCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RD.Code", 3)

            mQry = " SELECT RD.Code,RD.ManualCode,RD.Description,RD.Construction,RD.Carpet_Collection,RD.Carpet_Style,RD.Carpet_Colour, " & _
                    " RD.QualityCode,RQ.Description  AS QualityDesc,RD.TotalQty,RD.EntryBy,RD.EntryDate,RD.EntryType,RD.EntryStatus,RD.ApproveBy,RD.ApproveDate, " & _
                    " RD.MoveToLog, RD.MoveToLogDate, RD.IsDeleted " & _
                    " FROM " & bTableName & " RD " & _
                    " LEFT JOIN RUG_Quality RQ ON RQ.Code=RD.QualityCode " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Yarn Master Report"
    Private Sub ProcYarnMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By Y.EntryDate Desc"
            Else
                mOrderBy = "Order By Y.ManualCode"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "RUG_Yarn_Log"
                RepName = "RUG_YarnMasterLogReport" : RepTitle = "Yarn Master Log Report"
            Else
                bTableName = "RUG_Yarn"
                RepName = "RUG_YarnMasterReport" : RepTitle = "Yarn Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(Y.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(Y.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Status", 6)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("Y.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.YarnGroup", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Twist", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Ply", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Count", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Y.Code", 5)

            mQry = "SELECT  Y.UID, Y.Code, Y.ManualCode, Y.Description, Y.IsDeleted, Y.YarnGroup, " & _
                    " Y.Twist, Y.Ply, Y.Count, Y.EntryBy, Y.EntryDate, Y.EntryType, " & _
                    " Y.EntryStatus, Y.ApproveBy, Y.ApproveDate, Y.MoveToLog, Y.MoveToLogDate, " & _
                    " Y.UNIT, Y.Status, Y.Div_Code " & _
                    " FROM " & bTableName & " Y " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Shade Master Report"
    Private Sub ProcShadeMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By S.EntryDate Desc"
            Else
                mOrderBy = "Order By S.Description"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "RUG_Shade_Log"
                RepName = "RUG_ShadeMasterLogReport" : RepTitle = "Shade Master Log Report"
            Else
                bTableName = "RUG_Shade"
                RepName = "RUG_ShadeMasterReport" : RepTitle = "Shade Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(S.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(S.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Status", 4)

            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("S.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Colour", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Pantone", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Code", 3)

            mQry = "SELECT  S.Code, S.Description, S.Colour, S.Pantone, S.IsDeleted, S.EntryBy, " & _
                    " S.EntryDate, S.EntryType, S.EntryStatus, S.ApproveBy, S.ApproveDate, " & _
                    " S.MoveToLog, S.MoveToLogDate, S.Status, S.Div_Code, S.UID " & _
                    " FROM " & bTableName & " S " & _
                    " " & mCondStr & " " & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "YarnSku Master Report"
    Private Sub ProcYarnSkuMasterReport()
        Dim bTableName$ = "", bSecondryTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                mOrderBy = "Order By I.Description"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Item_Log"
                bSecondryTableName = "RUG_YarnSku_Log"
                RepName = "RUG_YarnSkuMasterLogReport" : RepTitle = "Yarn Sku Master Log Report"
            Else
                bTableName = "Item"
                bSecondryTableName = "RUG_YarnSku"
                RepName = "RUG_YarnSkuMasterReport" : RepTitle = "Yarn Sku Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("I.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ys.Yarn", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ys.Shade", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Code", 3)

            mQry = "SELECT  I.Code, I.ManualCode, I.Description, I.Unit, I.ItemType, I.IsDeleted, " & _
                    " I.UpcCode, I.Bom, I.EntryBy, I.EntryDate, I.EntryType, I.EntryStatus, " & _
                    " I.ApproveBy, I.ApproveDate, I.MoveToLog, I.MoveToLogDate, I.Status, " & _
                    " I.Div_Code, I.UID, Ys.Yarn AS YarnCode, Ys.SHADE AS ShadeCode, " & _
                    " Y.ManualCode AS YarnManualCode, Y.Description AS YarnDesc, S.Description AS ShadeDesc " & _
                    " FROM " & bTableName & " I " & _
                    " LEFT JOIN " & bSecondryTableName & " Ys ON I.Code = Ys.Code " & _
                    " LEFT JOIN RUG_Yarn Y ON Ys.Yarn = Y.Code " & _
                    " LEFT JOIN RUG_SHADE S ON Ys.SHADE = S.Code " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Size Master Report"
    Private Sub ProcSizeMasterReport()
        Dim bTableName$ = ""
        Dim mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By S.EntryDate Desc"
            Else
                mOrderBy = "Order By S.Description"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Rug_Size_Log"
                RepName = "RUG_SizeMasterLogReport" : RepTitle = "Size Master Log Report"
            Else
                bTableName = "Rug_Size"
                RepName = "RUG_SizeMasterReport" : RepTitle = "Size Master Report"
            End If

            Dim mCondStr$ = ""
            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(S.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(S.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Status", 3)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("S.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Shape", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Code", 2)

            mQry = "SELECT  S.Code, S.Description, S.Shape, S.FeetLength, S.FeetWidth, S.FeetArea, " & _
                    " S.MeterLength, S.MeterWidth, S.MeterArea, S.YardLength, S.YardWidth, S.YardArea, " & _
                    " S.KFeetLength, S.KFeetWidth, S.KFeetArea, S.KMeterLength, S.KMeterWidth, S.KMeterArea, " & _
                    " S.KYardLength, S.KYardWidth, S.KYardArea, S.IsDeleted, S.EntryBy, S.EntryDate, " & _
                    " S.EntryType, S.EntryStatus, S.ApproveBy, S.ApproveDate, S.MoveToLog, " & _
                    " S.MoveToLogDate, S.Status, S.Div_Code, S.UID " & _
                    " FROM " & bTableName & " S " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Buyer Master Report"
    Private Sub ProcBuyerMasterReport()
        Dim bTableName$ = "", bSecondryTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By SG.EntryDate Desc"
            Else
                mOrderBy = "Order By SG.DispName"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Buyer_Log"
                bSecondryTableName = "SubGroup_Log"
                RepName = "RUG_BuyerMasterLogReport" : RepTitle = "Buyer Master Log Report"
            Else
                bTableName = "Buyer"
                bSecondryTableName = "SubGroup"
                RepName = "RUG_BuyerMasterReport" : RepTitle = "Buyer Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(SG.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(SG.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("SG.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.SubCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.CityCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.GroupCode", 3)

            mQry = " SELECT I.UID,I.SubCode, I.SeaPort, I.BankName, I.BankAddress, I.BankAcNo, I.Currency, " & _
                    " I.ContactPerson, I.MAddress1, I.MAddress2, I.MCity, I.MContactNo, I.MFaxNo, I.Consignee, " & _
                    " I.CAddress1, I.CAddress2, I.CPhoneNo, I.CMobileNo, I.CFaxNo, I.CEmail,  " & _
                    " SG.ApproveBy, SG.ApproveDate, I.MoveToLog, I.MoveToLogDate, SG.IsDeleted, " & _
                    " SG.NamePrefix,SG.Name AS BuyerName,SG.ManualCode,SG.DispName AS BuyerDispName,SG.Add1,SG.Add2,SG.Add3, " & _
                    " SG.CityCode,SG.PIN,C.CityName AS BuyerCityName,SG.Phone,SG.Mobile,SG.FAX,SG.EMail ,SG.TINNo ,SG.PAN,SG.PAN,A.GroupName, " & _
                    " S.Description AS PortName,CP.CityName AS ComtactPCityName,SG.EntryBy,SG.EntryDate,SG.EntryType,SG.EntryStatus  " & _
                    " FROM " & bTableName & "  I " & _
                    " LEFT JOIN " & bSecondryTableName & " SG ON SG.SubCode=I.SubCode  " & _
                    " LEFT JOIN City C ON C.CityCode=SG.CityCode " & _
                    " LEFT JOIN AcGroup A ON A.GroupCode =SG.GroupCode " & _
                    " LEFT JOIN SeaPort S ON S.Code=I.SeaPort " & _
                    " LEFT JOIN City CP ON CP.CityCode=I.MCity " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Port Master Report"
    Private Sub ProcPortMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                mOrderBy = "Order By I.Description"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "SeaPort_Log"
                RepName = "RUG_PortLogReport" : RepTitle = "Port Master Log Report"
            Else
                bTableName = "SeaPort"
                RepName = "RUG_PortMasterReport" : RepTitle = "Port Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Status", 3)

            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("I.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.City", 2)

            mQry = " SELECT I.UID, I.Code, I.Description, I.IsDeleted, I.City, I.EntryBy, I.EntryDate, I.EntryType, " & _
                    " I.EntryStatus, I.ApproveBy, I.ApproveDate, I.MoveToLog, I.MoveToLogDate, I.Status, I.Div_Code,C.CityName," & _
                    " C.State AS StateDisp " & _
                    " FROM " & bTableName & " I " & _
                    " LEFT JOIN City C ON C.CityCode=I.City " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "City Master Report"
    Private Sub ProcCityMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                mOrderBy = "Order By I.CityName"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "City_Log"
                RepName = "RUG_CityMasterLogReport" : RepTitle = "City Master Log Report"
            Else
                bTableName = "City"
                RepName = "RUG_CityMasterReport" : RepTitle = "City Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("I.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.CityCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.State", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Country", 3)

            mQry = " SELECT I.CityCode, I.CityName, I.State, I.IsDeleted, I.Country, I.EntryBy, I.EntryDate, I.EntryType, I.EntryStatus, " & _
                    " I.ApproveBy, I.ApproveDate, I.MoveToLog, I.MoveToLogDate, I.Status, I.Div_Code, I.UID " & _
                    " FROM " & bTableName & " I " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Other Material Master Report"
    Private Sub ProcOtherMaterialMasterReport()
        Dim bTableName$ = "", bSecondryTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                mOrderBy = "Order By I.ManualCode"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Item_Log"
                RepName = "RUG_OthermaterialMasterLogReport" : RepTitle = "Other Material Master Log Report"
            Else
                bTableName = "Item"
                RepName = "RUG_OthermaterialMasterReport" : RepTitle = "Other Material Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 AND I.ItemType='" & ClsMain.ItemType.OtherMaterial & "' "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Status", 2)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("I.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Code", 1)

            mQry = " SELECT I.UID, I.Code, I.ManualCode, I.Description, I.Unit, I.ItemType, I.UpcCode, " & _
                    " I.Bom, I.EntryBy, I.EntryDate, I.EntryType, I.EntryStatus, I.ApproveBy, I.ApproveDate, " & _
                    " I.MoveToLog, I.MoveToLogDate, I.Status, I.Div_Code, I.IsDeleted, I.SalesTaxPostingGroup " & _
                    " FROM " & bTableName & " I " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Carpet SKU Master Report"
    Private Sub ProcCarpetSKUMasterReport()
        Dim bTableName$ = "", bSecondryTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                mOrderBy = "Order By I.ManualCode"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Item_Log"
                bSecondryTableName = "RUG_CarpetSku_Log"
                RepName = "RUG_CarpetSKUMasterLogReport" : RepTitle = "Carpet SKU Master Log Report"
            Else
                bTableName = "Item"
                bSecondryTableName = "RUG_CarpetSku"
                RepName = "RUG_CarpetSKUMasterReport" : RepTitle = "Carpet SKU Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 AND I.ItemType='" & ClsMain.ItemType.CarpetSKU & "' "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(I.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Status", 2)

            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("I.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Code", 1)

            mQry = "  SELECT I.UID, I.Code, I.ManualCode, I.Description, I.Unit, I.ItemType, I.UpcCode,  I.Bom, I.EntryBy, I.EntryDate, I.EntryType, I.EntryStatus, I.ApproveBy, I.ApproveDate, " & _
                    " I.MoveToLog, I.MoveToLogDate, I.Status, I.Div_Code, I.IsDeleted, I.SalesTaxPostingGroup , D.Description AS DesignDesc,S.Description AS SizeDesc " & _
                    " FROM " & bTableName & " I " & _
                    " LEFT JOIN " & bSecondryTableName & " CS ON CS.Code=I.Code " & _
                    " LEFT JOIN RUG_Design D ON D.Code=CS.Design " & _
                    " LEFT JOIN Rug_Size S ON CS.Size=S.Code " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Carpet SKU Consumption Master Report"
    Private Sub ProcCarpetSKUConsumptionMasterReport(ByVal mReportfor As String)
        Dim bTableName$ = "", bSecondryTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By I.EntryDate Desc"
            Else
                If mReportfor = "Carpet SKU" Then
                    mOrderBy = "Order By I.Description"
                Else
                    mOrderBy = "Order By RD.Description"
                End If
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Bom_Log" : bSecondryTableName = "BomDetail_Log BD ON BD.UID=B.UID "
                RepName = "RUG_CarpetSKUConMasterLogReport" : RepTitle = "" & mReportfor & " Consumption Master Log Report"
            Else
                bTableName = "Bom" : bSecondryTableName = "BomDetail BD ON BD.Code=B.Code "
                RepName = "RUG_CarpetSKUConMasterReport" : RepTitle = "" & mReportfor & " Consumption Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "
            If mReportfor = "Carpet SKU" Then
                mCondStr = mCondStr & " AND B.CarpetSKU IS NOT NULL "
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.CarpetSKU", 1)
            ElseIf mReportfor = "Design" Then
                mCondStr = mCondStr & " AND B.Design IS NOT NULL "
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Design", 1)
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(B.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(B.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Status", 5)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("B.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("BD.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Pantone", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Colour", 4)

            mQry = " SELECT  B.UID, B.Code, B.Description, B.Div_Code, B.EntryBy, B.EntryDate, B.EntryType, " & _
                    " B.EntryStatus, B.ApproveBy, B.ApproveDate, B.MoveToLog, B.MoveToLogDate, B.Status, B.ForQty, " & _
                    " B.ForWeight, B.ForUnit, B.TotalQty, B.IsDeleted, B.CarpetSKU, B.Design, " & _
                    " BD.UID,BD.Sr, BD.Item, BD.Qty, BD.ConsumptionPer, BD.ApplyIn, " & _
                    " I.Description AS CarpetSKUDesc,RD.Description AS DesignDesc, " & _
                    " IY.Description AS YarnSKUDesc,S.Pantone,S.Colour," & _
                    " CASE WHEN B.CarpetSKU IS NOT NULL THEN I.Description ELSE RD.Description END AS ConsumptionFor, " & _
                    " CASE WHEN B.CarpetSKU IS NOT NULL THEN 'Carpet SKU' ELSE 'Design Code' END AS ConsumptionField  " & _
                    " FROM " & bTableName & " B " & _
                    " LEFT JOIN " & bSecondryTableName & " " & _
                    " LEFT JOIN Item I ON I.Code=B.CarpetSKU  " & _
                    " LEFT JOIN RUG_Design RD ON RD.Code=B.Design  " & _
                    " LEFT JOIN Item IY ON IY.Code=BD.Item " & _
                    " LEFT JOIN RUG_YarnSKU  YS ON YS.Code=BD.Item  " & _
                    " LEFT JOIN RUG_SHADE S ON S.Code=YS.SHADE " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Export Order Report"
    Private Sub ProcExportReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By SO.EntryDate Desc"
            Else
                mOrderBy = "Order By SO.V_No"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "SaleOrder_Log" : bSecTableName = "SaleOrderDetail_Log  SO1 ON SO1.UID =SO.UID "
                RepName = "RUG_ExportOrderLogReport" : RepTitle = "Export Order Log Report"
            Else
                bTableName = "SaleOrder" : bSecTableName = "SaleOrderDetail SO1 ON SO1.DocID =SO.DocID"
                RepName = "RUG_ExportOrderReport" : RepTitle = "Export Order Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(SO.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(SO.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                If ObjRFG.ParameterCmbo3_Value = "Pending" Then
                    mCondStr = mCondStr & "AND SO1.Qty > SO1.ShippedQty "
                ElseIf ObjRFG.ParameterCmbo3_Value = "Shipped" Then
                    mCondStr = mCondStr & "AND  SO1.Qty <= SO1.ShippedQty "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.Status", 7)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("SO.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.SaleToParty", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO1.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Design", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Size", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.Site_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.V_Type", 6)

            'mQry = " SELECT SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
            '        " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry,  " & _
            '        " SO.ShipToPartyName, SO.ShipToPartyAdd1, SO.ShipToPartyAdd2, SO.ShipToPartyCity, SO.ShipToPartyCityName, SO.ShipToPartyState, SO.ShipToPartyCountry,  " & _
            '        " SO.SalesTaxGroupParty, SO.PartyOrderNo, SO.PartyOrderDate, SO.PartyOrderCancelDate, SO.PortOfLoading, SO.DestinationPort, SO.FinalPlaceOfDelivery, SO.TermsAndConditions, " & _
            '        " SO.EntryBy, SO.EntryDate, SO.EntryType, SO.EntryStatus, SO.ApproveBy, SO.ApproveDate,SO.IsDeleted, SO.Status, SO.UID, " & _
            '        " SO.Consignee, SO.ConsigneeName, SO.ConsigneeAdd1, SO.ConsigneeAdd2, SO.ConsigneeCity, SO.ConsigneeCityName, SO.ConsigneeState, SO.ConsigneeCountry,  " & _
            '        " SO.PartyDeliveryDate, SO.Remarks, SO.DeliveryMeasure, SO.ShipmentDate, SO.FactoryDate, SO.FactoryDeliveryDate, SO.ExFactoryShipmentDate, SO.FactoryCancelDate, " & _
            '        " SO.BillingType, SO.Currency, SO.TotalQty, SO.TotalAmount,SO.TotalMeasure, " & _
            '        " SO1.Sr, SO1.Item, SO1.SalesTaxGroupItem, SO1.Qty, SO1.ShippedQty,SO1.Unit, SO1.Rate, SO1.Amount, " & _
            '        " SO1.UID, SO1.PartySKU, SO1.PartyUPC, SO1.MeasurePerPcs, SO1.TotalMeasure AS LineTotalMeasure, " & _
            '        " D.Div_Name,SM.ManualCode AS SiteName,SL.Description AS LoadingPortName,SD.Description AS DestinationPortName,CO.Name AS DestinationPortCountry,I.Description AS ItemDesc , " & _
            '        " Vt.Description AS OrderTypeDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType " & _
            '        " FROM " & bTableName & " SO " & _
            '        " LEFT JOIN " & bSecTableName & " " & _
            '        " LEFT JOIN Division D ON D.Div_Code=SO.Div_Code  " & _
            '        " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
            '        " LEFT JOIN SeaPort SL ON SL.Code=SO.PortOfLoading  " & _
            '        " LEFT JOIN SeaPort SD ON SD.Code=SO.DestinationPort  " & _
            '        " LEFT JOIN City C ON C.CityCode=SD.City  " & _
            '        " LEFT JOIN State S ON S.State_Code=C.State  " & _
            '        " LEFT JOIN Country CO ON CO.Code=S.CountryCode  " & _
            '        " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
            '        " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item  " & _
            '        " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design  " & _
            '        " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size  " & _
            '        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =SO.V_Type  " & _
            '        " " & mCondStr & "" & mOrderBy & ""

            mQry = " SELECT SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
                    " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry,  " & _
                    " SO.ShipToPartyName, SO.ShipToPartyAdd1, SO.ShipToPartyAdd2, SO.ShipToPartyCity, SO.ShipToPartyCityName, SO.ShipToPartyState, SO.ShipToPartyCountry,  " & _
                    " SO.SalesTaxGroupParty, SO.PartyOrderNo, SO.PartyOrderDate, SO.PartyOrderCancelDate, SO.DestinationPort, SO.FinalPlaceOfDelivery, SO.TermsAndConditions, " & _
                    " SO.EntryBy, SO.EntryDate, SO.EntryType, SO.EntryStatus, SO.ApproveBy, SO.ApproveDate,SO.IsDeleted, SO.Status, SO.UID, " & _
                    " SO.PartyDeliveryDate, SO.Remarks, SO.DeliveryMeasure, SO.ShipmentDate, SO.FactoryDate, SO.FactoryDeliveryDate, SO.ExFactoryShipmentDate, SO.FactoryCancelDate, " & _
                    " SO.BillingType, SO.Currency, SO.TotalQty, SO.TotalAmount,SO.TotalMeasure, " & _
                    " SO1.Sr, SO1.Item, SO1.SalesTaxGroupItem, SO1.Qty, SO1.ShippedQty,SO1.Unit, SO1.Rate, SO1.Amount, " & _
                    " SO1.UID, SO1.PartySKU, SO1.PartyUPC, SO1.MeasurePerPcs, SO1.TotalMeasure AS LineTotalMeasure, " & _
                    " D.Div_Name,SM.ManualCode AS SiteName, SD.Description AS DestinationPortName,C.Country AS DestinationPortCountry,I.Description AS ItemDesc , " & _
                    " Vt.Description AS OrderTypeDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType " & _
                    " FROM " & bTableName & " SO " & _
                    " LEFT JOIN " & bSecTableName & " " & _
                    " LEFT JOIN Division D ON D.Div_Code=SO.Div_Code  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
                    " LEFT JOIN SeaPort SD ON SD.Code=SO.DestinationPort  " & _
                    " LEFT JOIN City C ON C.CityCode=SD.City  " & _
                    " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
                    " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item  " & _
                    " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design  " & _
                    " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =SO.V_Type  " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Export Order MIS  Report"
    Private Sub ProcExportOrderMISReport()
        Dim mOrderBy$ = "", bGroupByField = ""
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            RepName = "RUG_ExportOrderGroupWiseReport" : RepTitle = "Export Order MIS Report"

            mCondStr = mCondStr & "AND SO.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.ParameterCmbo1_Value = "Party" Then
                bGroupByField = "SO.SaleToPartyName"
            ElseIf ObjRFG.ParameterCmbo1_Value = "Carpet SKU" Then
                bGroupByField = "I.Description"
            ElseIf ObjRFG.ParameterCmbo1_Value = "Design" Then
                bGroupByField = "RD.Description"
            ElseIf ObjRFG.ParameterCmbo1_Value = "Size" Then
                bGroupByField = "RS.Description"
            End If

            If ObjRFG.ParameterCmbo2_Value = "Pending for Shipping" Then
                mCondStr = mCondStr & "AND SO1.Qty > SO1.ShippedQty "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Shipped" Then
                mCondStr = mCondStr & "AND  SO1.Qty <= SO1.ShippedQty "
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.SaleToParty", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO1.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Design", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Size", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.Site_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SO.V_Type", 6)

            mQry = " SELECT  SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
                    " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry, " & _
                    " SO.TotalQty, SO.TotalAmount, SO.TotalMeasure, " & _
                    " SO1.Sr, SO1.Item, SO1.Qty, SO1.Unit, SO1.Rate, SO1.Amount, SO1.TotalMeasure, SO1.MeasureUnit, SO1.ShippedQty, " & _
                    " SM.ManualCode AS Site_Name,I.Description AS ItemDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc, " & _
                    " SO1.Qty-SO1.ShippedQty AS BalQty, Vt.Description AS OrderType, " & _
                    " " & bGroupByField & " AS GroupByVar,'" & ObjRFG.ParameterCmbo1_Value & "' AS GroupByField " & _
                    " FROM SaleOrder SO " & _
                    " LEFT JOIN SaleOrderDetail SO1 ON SO1.DocId=SO.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
                    " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item   " & _
                    " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design   " & _
                    " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size   " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=SO.V_Type  " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Production Order Report"
    Private Sub ProcProdOrderReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By PO.EntryDate Desc"
            Else
                mOrderBy = "Order By PO.V_No"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "ProdOrder_Log" : bSecTableName = "ProdOrderDetail_Log  PO1 ON PO1.UID =PO.UID "
                RepName = "RUG_ProductionOrderLogReport" : RepTitle = "Production Order Log Report"
            Else
                bTableName = "ProdOrder" : bSecTableName = "ProdOrderDetail PO1 ON PO1.DocID =PO.DocID"
                RepName = "RUG_ProductionOrderReport" : RepTitle = "Production Order Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(PO.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(PO.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("PO.Status", 6)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("PO.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PO1.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Design", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Size", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PO.Site_Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PO.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PO.V_Type", 5)

            mQry = " SELECT  PO.DocID, PO.V_Type, PO.V_Prefix, PO.V_Date, PO.V_No, PO.Div_Code, PO.Site_Code, " & _
                    " PO.SaleOrder, PO.DueDate, PO.TotalQty, PO.TotalMeasure, PO.Remarks, " & _
                    " PO.EntryBy, PO.EntryDate, PO.EntryType, PO.EntryStatus, PO.ApproveBy, PO.ApproveDate, PO.MoveToLog, PO.MoveToLogDate, PO.IsDeleted, PO.Status, PO.UID, " & _
                    " PO1.Sr, PO1.Item, PO1.Qty, PO1.Unit, PO1.MeasurePerPcs, PO1.TotalMeasure AS TotalMeasureLine, PO1.MeasureUnit, PO1.ProdPlanQty, PO1.ProdPlanMeasure, PO1.UID, " & _
                    " SM.ManualCode AS SiteName,I.Description AS ItemDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc, " & _
                    " VtP.Description AS ProductionType,VtS.Description AS SaleOrderType, SO.V_No AS SaleOrderNo,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType " & _
                    " FROM " & bTableName & " PO " & _
                    " LEFT JOIN " & bSecTableName & " " & _
                    " LEFT JOIN SiteMast SM ON  SM.Code=PO.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=PO1.Item " & _
                    " LEFT JOIN RUG_CarpetSku CS ON CS.Code=PO1.Item  " & _
                    " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design  " & _
                    " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size  " & _
                    " LEFT JOIN Voucher_Type VtP ON Vtp.V_Type=PO.V_Type  " & _
                    " LEFT JOIN SaleOrder SO ON SO.DocID=PO.SaleOrder  " & _
                    " LEFT JOIN Voucher_Type VtS ON Vts.Category=SO.V_Type  " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Godown Master Report"
    Private Sub ProcGodownMasterReport()
        Dim bTableName$ = "", mOrderBy$ = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By G.EntryDate Desc"
            Else
                mOrderBy = "Order By G.Description"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Godown_Log"
                RepName = "RUG_GodownLogReport" : RepTitle = "Godown Master Log Report"
            Else
                bTableName = "Godown"
                RepName = "RUG_GodownMasterReport" : RepTitle = "Godown Master Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(G.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(G.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Status", 2)

            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("G.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Div_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Code", 1)

            mQry = " SELECT  G.Code, G.Description, G.Site_Code, G.Div_Code, G.IsDeleted, G.EntryBy, G.EntryDate, " & _
                    " G.EntryType, G.EntryStatus, G.ApproveBy, G.ApproveDate, G.MoveToLog, G.MoveToLogDate, G.Status, G.Uid " & _
                    " FROM " & bTableName & " G " & _
                    " " & mCondStr & "" & mOrderBy

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Summary"
    Private Sub procStockSummary(ByVal bReportType As String)
        Try
            Call ObjRFG.FillGridString()

            Dim bQry$ = ""
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If bReportType <> "Stock In Hand" Then
                If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            Else
                ObjRFG.ParameterDate2_Value = ObjRFG.ParameterDate1_Value
            End If

            mCondStr = " where 1=1 "
            If ObjRFG.GetWhereCondition("V1.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Site_Code", 5)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Godown", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemType", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.ProcessGroup", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Process", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Div_Code", 6)

            mQry = " SELECT V1.*,SM.ManualCode AS Site_Name,G.Description AS GodownDesc,I.Description AS ItemDesc, " & _
                " Vc.NCatDescription As ProcessDescription, P.ProcessGroup As ProcessGroup, " & _
                " PG.Description AS ProcessGroupDesc " & _
                " FROM ( " & StockQry(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value) & " ) V1" & _
                " LEFT JOIN SiteMast SM ON SM.Code = V1.Site_Code " & _
                " LEFT JOIN Godown G ON G.Code = V1.Godown " & _
                " LEFT JOIN Item I ON I.Code = V1.Item " & _
                " LEFT JOIN Process P On V1.Process = P.NCat " & _
                " LEFT JOIN VoucherCat Vc On P.NCat = Vc.NCat " & _
                " LEFT JOIN ProcessGroup PG ON PG.Code = P.ProcessGroup " & _
                " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            If bReportType = "Stock Summary" Then
                RepName = "RUG_StockSummary" : RepTitle = "Stock Summary"
            ElseIf bReportType = "Stock Report" Then
                RepName = "RUG_StockReport" : RepTitle = "Stock Report"
            ElseIf bReportType = "Stock In Hand" Then
                RepName = "RUG_StockInHand" : RepTitle = "Stock In Hand"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub

    Private Function StockQry(ByVal mFromDate As String, ByVal mToDate As String)
        StockQry = " SELECT S.Site_Code,S.Div_Code,S.Godown,isnull(S.Process,'') AS Process, " & _
                " " & AgL.ConvertDate(mFromDate) & " As V_Date, 'Opening' As DocID,  " & _
                " S.V_No, 'Opening' As  VType,'Opening' AS TransactionaNo,S.Item , " & _
                " sum(isnull(S.Qty_Rec,0)) - sum(isnull(S.Qty_Iss,0)) AS Opening,0 AS ReceiveQty, " & _
                " 0 AS IssueQty " & _
                " FROM Stock S " & _
                " WHERE S.V_Date < " & AgL.ConvertDate(mFromDate) & " " & _
                " GROUP BY S.Item,S.Site_Code,S.Div_Code,S.Process,S.Godown,S.V_No "

        StockQry = StockQry & " UNION ALL " & _
                " SELECT S.Site_Code,S.Div_Code,S.Godown,isnull(S.Process,'') AS Process, " & _
                " S.V_Date,S.DocID , S.V_No,Vt.Description AS VType,Vt.Description +'/'+ Convert(NVARCHAR(10),S.V_No ) AS TransactionaNo, " & _
                " S.Item ,0 AS Opening,isnull(S.Qty_Rec,0)AS ReceiveQty,isnull(S.Qty_Iss,0) AS IssueQty   " & _
                " FROM Stock S " & _
                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type = S.V_Type  " & _
                " WHERE S.V_Date BETWEEN " & AgL.ConvertDate(mFromDate) & " And " & AgL.ConvertDate(mToDate) & " "
    End Function
#End Region

#Region "Production Plan Report"
    Private Sub ProcProdPlanReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By PP.EntryDate Desc"
            Else
                mOrderBy = "Order By PP.V_No"
   "        End If

            If AgL.StrCmp(mREpType, ClsMain.ReportType.�og) Then
                bTableNaoe = "ProdPlan_Log" : bS%cTableNamm = "ProdPlanDetail_Log  PP1 ON PP1.UID =PR.UID "
        `  `    RepName = "RUG_ProductionPlanLogReport" : RepTitle = 2Production Plan Log Report"
  !         Else
                bTajleName`= "ProdPlan" : bSecTableName = "ProdPlanDetail PP! ON PP1.docID =PPDocID"
                RepName`= "RUG_ProductionPlanRePort" : RepTiple = "Pr/du�tion �lan Report"
0           End(If
            Dim mCon`Str$ = ""

            mCondStr = " where 1=1 "


            If AgL.StrCmp(iRepType, ClsMain.ReportType.Main9 Then
                If ObjRFG.ParameterCmbo1_V�lue = "No" Then
      "           " mCondStr = mCondStr & "AND  isnull(PP.isDeleted,0) =0 "
        �       ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
         �          mCondSpr = mCondStr &  AND  isnull(PP.IsDeleted,0) =1 "
          0     Elce
           (        mCo~dStr = mCondStr
                End If

                If ObjRFG.ParameterCmbo3_Value = "Pending" Then
                    mCondStr = mCondStr & "AND PP1.Qty > PP1.ProdRecQty "
                ElseIf ObjRFG.ParameterCmbo3_Value = "Received" Then
                    mCondStr = mCondStr & "AND  PP1.Qty <= PP1.ProdRecQty "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("PP.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("PP.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PP.ProdOrder", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PP1.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PP.Site_Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PP.Div_Code", 3)

            mQry = "  SELECT  PP.DocID, PP.V_Type, PP.V_Prefix, PP.V_Date, PP.V_No, PP.Div_Code, PP.Site_Code,  PP.ProdOrder, PP.DueDate, " & _
                    " PP.TotalQty, PP.TotalMeasure, PP.Remarks, PP.EntryBy, PP.EntryDate, PP.EntryType, " & _
                    " PP.EntryStatus, PP.ApproveBy, PP.ApproveDate, PP.MoveToLog, PP.MoveToLogDate, PP.IsDeleted, PP.Status, PP.UID,  PP1.Sr, " & _
                    " PP1.Item, PP1.Qty, PP1.Unit, PP1.StkQty_Finished, PP1.StkQty_SemiFinished,  " & _
                    " PP1.StkQtyReq_OpenSaleOrder, PP1.ExcessQty_Finished, PP1.ExcessQty_SemiFinished, PP1.ComputerProdPlanQty,   " & _
                    " PP1.ComputerProdPlanMeasure, PP1.UserPurchPlanQty, PP1.UserPurchPlanMeasure, PP1.UserProdPlanQty, PP1.UserProdPlanMeasure,   " & _
                    " PP1.UserProdPlanRemarks, PP1.MeasurePerPcs, PP1.MeasureUnit, PP1.ProdIssQty, PP1.ProdIssMeasure, PP1.ProdRecQty,    " & _
                    " PP1.ProdRecMeasure, PP1.UID AS LineUID, PP1.TotalMeasure, I.Description AS ItemDesc,Vt.Description AS PlanType,  PO.V_No AS OrderNo, " & _
                    " VtO.Description AS OrderType ,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType, SM.ManualCode AS SiteName  " & _
                    " FROM " & bTableName & " PP   " & _
                    " LEFT JOIN " & bSecTableName & " " & _
                    " LEFT JOIN Item I ON I.Code=PP1.Item    " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =PP.V_Type   " & _
                    " LEFT JOIN ProdOrder PO ON PO.DocID=PP.ProdOrder   " & _
                    " LEFT JOIN Voucher_Type VtO ON VtO.V_Type=PO.V_Type  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=PP.Site_Code " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Material Plan Report"
    Private Sub ProcMaterialPlanReport(ByVal mVoucher_NCat As String, ByVal mMaterialType As String, Optional ByVal mtitle_Prefix As String = "")
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = "", bThirdTableName As String = ""
        Dim bMaterialType As String = mMaterialType
        Try
            Call ObjRFG.FillGridString()

            If ObjRFG.ParameterCmbo1_Value = "Modify Date" Then
                mOrderBy = "Order By MP.EntryDate Desc"
            Else
                mOrderBy = "Order By MP.V_No"
            End If

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "MaterialPlan_Log" : bSecTableName = "MaterialPlanDetail_Log  MP1 ON MP1.UID =MP.UID "
                RepName = "RUG_MaterialPlanLogReport" : RepTitle = mtitle_Prefix & "Material Plan Log Report"
            Else
                bTableName = "MaterialPlan" : bSecTableName = "MaterialPlanDetail MP1 ON MP1.DocID =MP.DocID"
                RepName = "RUG_MaterialPlanReport" : RepTitle = mtitle_Prefix & "Material Plan Report"
            End If

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND  Vt.NCat= '" & mVoucher_NCat & "'"

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Main) Then
                If ObjRFG.ParameterCmbo1_Value = "No" Then
                    mCondStr = mCondStr & "AND  isnull(MP.IsDeleted,0) =0 "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Yes" Then
                    mCondStr = mCondStr & "AND  isnull(MP.IsDeleted,0) =1 "
                Else
                    mCondStr = mCondStr
                End If

                mCondStr = mCondStr & ObjRFG.GetWhereCondition("MP.Status", 4)
            Else
                mCondStr = mCondStr & " AND " & AgL.ConvertDateField("MP.EntryDate") & " Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("MP.ProdPlan", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("MP1.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("MP.Site_Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("MP.Div_Code", 3)

            mQry = " SELECT MP.DocID, MP.V_Type, MP.V_Prefix, MP.V_Date, MP.V_No, MP.Div_Code, MP.Site_Code, MP.ProdPlan, " & _
                    " MP.TotalQty, MP.TotalMeasure, MP.TotalComputerConsumptionPlanQty, MP.TotalUserConsumptionPlanQty, MP.Remarks, " & _
                    " MP.EntryBy, MP.EntryDate, MP.EntryType, MP.EntryStatus, MP.ApproveBy, MP.ApproveDate, MP.MoveToLog, MP.MoveToLogDate, " & _
                    " MP.IsDeleted, MP.Status, MP.UID, " & _
                    " MP1.Sr, MP1.Item, MP1.BomQty, MP1.Unit, MP1.StockQty, MP1.IssuedQty_ProdPlan, MP1.ComputerMaterialPlanQty, " & _
                    " MP1.ComputerMaterialPlanMeasure, MP1.UserMaterialPlanQty, MP1.UserMaterialPlanMeasure, MP1.UserMaterialPlanRemarks, MP1.MeasurePerPcs, " & _
                    " MP1.MeasureUnit, MP1.PurchOrdQty, MP1.PurchOrdMeasure, MP1.PurchQty, MP1.PurchMeasure, MP1.ProdIssQty, MP1.ProdIssMeasure, MP1.UID, " & _
                    " Vt.Description AS PlanType,SM.ManualCode AS SiteName,I.Description AS ItemDesc, " & _
                    " VtP.Description AS PlanType,PP.V_No AS PlanNo,'" & ObjRFG.ParameterCmbo2_Value & "' AS ReportType,'" & bMaterialType & "' AS MaterialType" & _
                    " FROM " & bTableName & " MP " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =MP.V_Type  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=MP.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=MP1.Item " & _
                    " LEFT JOIN ProdPlan PP ON PP.DocID=MP.ProdPlan " & _
                    " LEFT JOIN Voucher_Type VtP ON VtP.V_Type=PP.V_Type " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
End Class
