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
    Private Const SaleReport As String = "SaleReport"
    Private Const ItemWiseSaleReport As String = "ItemWiseSaleReport"
    Private Const PurchaseReport As String = "PurchaseReport"
    Private Const ItemWisePurchaseReport As String = "ItemWisePurchaseReport"

    Private Const StoreIssueReport As String = "StoreIssueReport"
    Private Const StoreReceiveReport As String = "StoreReceiveReport"
#End Region

#Region "Queries Definition"
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpPartyQry$ = " Select Convert(BIT,0) As [Select], Sg.SubCode As Code, Sg.DispName AS Party FROM SubGroup Sg Where Sg.Nature In ('Customer','Supplier') "
    Dim mHelpItemQry$ = "Select Convert(BIT,0) As [Select],Code, Description As [Item] From Item "
    Dim mHelpGodownQry$ = "Select Convert(BIT,0) As [Select],Code, Description As [Item] From Godown "
    Dim mHelpItemGroupQry$ = "Select Convert(BIT,0) As [Select],Code, Description As [Item] From ItemGroup "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case SaleReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpPartyQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case ItemWiseSaleReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case PurchaseReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpPartyQry, "Party")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case ItemWisePurchaseReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case StoreIssueReport, StoreReceiveReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "From Godown")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case SaleReport
                ProcSaleReport()

            Case ItemWiseSaleReport
                ProcItemWiseSaleReport()

            Case PurchaseReport
                ProcPurchaseReport()

            Case ItemWisePurchaseReport
                ProcItemWisePurchaseReport()

            Case StoreIssueReport
                ProcStoreIssueReceiveReport(AgTemplate.ClsMain.Temp_NCat.StoreIssue, "Store Issue Report")

            Case StoreReceiveReport
                ProcStoreIssueReceiveReport(AgTemplate.ClsMain.Temp_NCat.StoreReceive, "Store Receive Report")
        End Select
    End Sub

#Region "Sale Report"
    Private Sub ProcSaleReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Trade_SaleReport" : RepTitle = "Sale Report"


            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SaleToParty", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.SaleToParty, " & _
                        " Sg.DispName As SaleToPartyName, Sg.Add1, Sg.Add2, Sg.Add3, C.CityName As SaleToPartyCityName , H.SaleToPartyMobile, H.ShipToParty, H.ShipToPartyName,  " & _
                        " H.ShipToPartyAddress, H.ShipToPartyCity, H.ShipToPartyMobile, H.SaleOrder, H.SaleChallan, H.Currency,  " & _
                        " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.ReferenceDocId, H.Remarks, H.TotalQty,  " & _
                        " H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate,  " & _
                        " H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Godown, H.Vendor,  " & _
                        " H.SaleToPartyTinNo, H.SaleToPartyCstNo, H.Transporter, H.Vehicle, H.VehicleDescription, H.Driver, H.DriverName,  " & _
                        " H.DriverContactNo, H.LrNo, H.LrDate, H.PrivateMark, H.PortOfLoading, H.DestinationPort, H.FinalPlaceOfDelivery,  " & _
                        " H.PreCarriageBy, H.PlaceOfPreCarriage, H.ShipmentThrough, H.CreditDays, " & _
                        " H.Gross_Amount, H.Freight_Per, H.Freight, H.Discount_Per, H.Discount, " & _
                        " H.Other_Charges_Per, H.Other_Charges, H.Round_Off, H.Net_Amount, H.Landed_Value " & _
                        " FROM SaleInvoice H  " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN SubGroup Sg On H.SaleToParty = Sg.SubCode " & _
                        " LEFT JOIN City C On Sg.CityCode = C.CityCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Sale Report"
    Private Sub ProcItemWiseSaleReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Trade_ItemWiseSaleReport" : RepTitle = "Item Wise Sale Report"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SaleToParty", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)


            mQry = " SELECT L.DocId, L.Sr, L.SaleOrder, L.SaleOrderSr, L.SaleChallan, L.SaleChallanSr, L.BaleNo, L.Item, I.ManualCode AS ItemManualCode, L.SalesTaxGroupItem, L.DocQty, " & _
                        " L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.ReferenceDocId,  " & _
                        " L.LotNo, L.UID, L.Specification, L.Gross_Amount, " & _
                        " L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges, L.Round_Off, L.Net_Amount, L.Landed_Value, " & _
                        " I.Description AS ItemDesc, H.V_Date, H.ReferenceNo, Sg.DispName As SaleToPartyName, L.Remark " & _
                        " FROM SaleInvoiceDetail L " & _
                        " LEFT JOIN SaleInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN SubGroup Sg On H.SaleToParty = Sg.SubCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Report"
    Private Sub ProcPurchaseReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Trade_PurchaseReport" : RepTitle = "Purchase Report"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.Vendor, " & _
                        " Sg.DispName As VendorName, Sg.Add1, Sg.Add2, Sg.Add3, C.CityName As VendorCityName , H.PurchOrder, " & _
                        " H.PurchChallan, H.Currency,  " & _
                        " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.ReferenceDocId, H.Remarks, H.TotalQty,  " & _
                        " H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate,  " & _
                        " H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Godown, H.Vendor, " & _
                        " H.Gross_Amount, H.Discount_Per, H.DIscount, H.Other_Charges_Per, H.Other_Charges, H.Round_Off, H.Net_Amount " & _
                        " FROM PurchInvoice H  " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & _
                        " LEFT JOIN City C On Sg.CityCode = C.CityCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Purchase Report"
    Private Sub ProcItemWisePurchaseReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Trade_ItemWisePurchaseReport" : RepTitle = "Item Wise Purchase Report"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)


            mQry = " SELECT L.DocId, L.Sr, L.PurchOrder, L.PurchChallan, L.PurchChallanSr, L.BaleNo, L.Item, I.ManualCode AS ItemManualCode, " & _
                        " L.SalesTaxGroupItem, L.DocQty, " & _
                        " L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.ReferenceDocId,  " & _
                        " L.LotNo, L.UID, L.Specification, L.Gross_Amount, " & _
                        " L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges, L.Round_Off, L.Net_Amount, " & _
                        " I.Description AS ItemDesc, H.V_Date, H.ReferenceNo, Sg.DispName As VendorName, L.Remark " & _
                        " FROM PurchInvoiceDetail L " & _
                        " LEFT JOIN PurchInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Store Issue Receive Report"
    Private Sub ProcStoreIssueReceiveReport(ByVal bNCat As String, ByVal bReportTitle As String)
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            bTableName = "StockHead" : bSecTableName = "Stock L ON L.DocID =H.DocID"

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Store_IssueReportDetail" : RepTitle = bReportTitle + "(Detail)"
            Else
                RepName = "Store_IssueReport" : RepTitle = bReportTitle + "(Summary)"
            End If


            Dim mCondStr$ = ""

            mCondStr = " Where 1=1 "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(bNCat) & " )"
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.FromGodown", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.ItemGroup", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)

            mQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Unit,L.Qty_Iss,L.Qty_Rec,L.Remarks AS LineRemark," & _
                    " SG.DispName AS OrderByName,L.Status, SH.V_Type AS IssueType, SH.V_No AS IssueNo, " & _
                    " H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate," & _
                    " CASE WHEN L.Qty_Iss IS NULL THEN L.Qty_Rec ELSE L.Qty_Iss END AS Qty, " & _
                    " I.Description AS ItemDesc,IG.Description AS ItemGroup, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                    " GF.Description AS FromGoodownDesc ,GT.Description AS ToGoodownDesc " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " LEFT JOIN ItemGroup IG ON IG.Code = I.ItemGroup " & _
                    " LEFT JOIN Godown GF ON GF.Code=H.FromGodown  " & _
                    " LEFT JOIN Godown GT ON GT.Code=H.ToGodown  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " LEFT JOIN StockHead SH ON SH.DocId=H.ReferenceDocId  " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub
End Class

