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

#Region "Reports Constant"
    Private Const SMSLogReport As String = "SMSLogReport"
    Private Const EMailLogReport As String = "EMailLogReport"
#End Region

#Region "Queries Definition"

    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", mQry1$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case SMSLogReport
                    StrArr1 = New String() {"All", "Pending", "Send"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site/Branch")

                Case EMailLogReport
                    StrArr1 = New String() {"All", "Pending", "Send"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site/Branch")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case SMSLogReport
                procSmsLogReport()

            Case EMailLogReport
                procEmailLogReport()
        End Select
    End Sub

#Region "Sms Log Report"
    Private Sub procSmsLogReport()
        Try
            Dim mCondStr$ = "", mQry$ = "", RepName$ = "", RepTitle$ = ""

            Call ObjRFG.FillGridString()

            mCondStr = " Where s.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("DS.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("s.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.Site_Code", 0)
            End If

            If ObjRFG.ParameterCmbo1_Value = "Pending" Then
                mCondStr = mCondStr & " and s.Status ='Pending'"
            ElseIf ObjRFG.ParameterCmbo1_Value = "Send" Then
                mCondStr = mCondStr & " and s.Status ='Send'"

            End If
            mQry = " SELECT S.V_Date,s.Category,s.Mobile,s.Msg,s.Status,SubGroup.DispName AS Sendto " & _
                   " FROM Sms_Trans S LEFT JOIN SubGroup ON s.SubCode=SubGroup.SubCode " & _
                     " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Sms_SmsLogReport" : RepTitle = "Sms Log Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Email Log Report"
    Private Sub procEmailLogReport()
        Try
            Call ObjRFG.FillGridString()
            Dim mCondStr$ = "", mQry$ = "", RepName$ = "", RepTitle$ = ""
            mCondStr = " Where s.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            If ObjRFG.GetWhereCondition("DS.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("s.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.Site_Code", 0)
            End If
            If ObjRFG.ParameterCmbo1_Value = "Pending" Then
                mCondStr = mCondStr & " and s.issend =0"
            ElseIf ObjRFG.ParameterCmbo1_Value = "Send" Then
                mCondStr = mCondStr & " and s.issend =1"

            End If
            mQry = " SELECT S.V_Date,s.subject,s.message AS  Msg,(case when s.issend=0 then 'Pending' else 'Send' end) as status," & _
                   " s1.EMailAddress AS Sendto FROM EMail_OutBox S LEFT JOIN EMail_OutBox1 s1 ON s.GUID=s1.guid " & _
                     " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "EMail_MailLogReport" : RepTitle = "Mail Log Report"

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
