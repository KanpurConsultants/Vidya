Public Class FrmDivisionSelection
    Private Const GSNo As Byte = 0
    Private Const GDivCode As Byte = 1
    Private Const GDivName As Byte = 2
    Private Const GDataPath As Byte = 3
    Private WithEvents FGMain As New CustomDataGridView

    Private Sub FrmCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Agl.GridDesign(FGMain)
        IniGrid()
        MoveRec()
    End Sub

    Private Sub IniGrid()
        FGMain.Height = PnlMain.Height
        FGMain.Width = PnlMain.Width
        FGMain.Top = PnlMain.Top
        FGMain.Left = PnlMain.Left
        Controls.Add(FGMain)
        FGMain.Visible = True
        FGMain.BringToFront()
        Agl.AddTextColumn(FGMain, "SNo", 50, 5, "S.No.", True, True, False)
        Agl.AddTextColumn(FGMain, "DivCode", 0, 5, "Division Code", False, True, False)
        Agl.AddTextColumn(FGMain, "DivName", 615, 5, "Division Name", True, True, False)
        Agl.AddTextColumn(FGMain, "DataPath", 0, 50, "Data Path", False, True, False)
        FGMain.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom)
        Agl.FSetSNo(FGMain, GSNo)
        FGMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        FGMain.BackgroundColor = Color.White
        FGMain.TabIndex = 0
        FGMain.BorderStyle = BorderStyle.None
        FGMain.GridColor = Color.White
    End Sub

    Public Sub MoveRec()
        Dim ADTemp As OleDb.OleDbDataAdapter
        Dim DTTemp As New DataTable
        Dim I As Integer

        FGMain.Rows.Clear()
        DTTemp = AgL.FillData("Select Div_Code,Div_Name,DataPath From Division ", AgL.GcnMain).TABLES(0)
        FGMain.Rows.Add(DTTemp.Rows.Count)
        For I = 0 To DTTemp.Rows.Count - 1
            FGMain(GSNo, I).Value = Trim(I + 1)
            FGMain(GDivCode, I).Value = DTTemp.Rows(I).Item("Div_Code")
            FGMain(GDivName, I).Value = DTTemp.Rows(I).Item("Div_Name")
            FGMain(GDataPath, I).Value = DTTemp.Rows(I).Item("DataPath")
        Next
        ADTemp = Nothing
        DTTemp = Nothing
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnCancel.Click
        Select Case sender.Name
            Case BtnOk.Name
                FSelectDivision()
            Case BtnCancel.Name
                Me.Dispose()
                FrmLogin.Show()
        End Select
    End Sub

    Private Sub FSelectDivision()
        Dim mQry As String = "", mTable_Schema As String = ""
        Dim bDtDivision As DataTable = Nothing
        Dim bIntI% = 0

        If FGMain(GDivCode, FGMain.CurrentRow.Index).Value <> "" Then
            AgL.PubDivCode = FGMain(GDivCode, FGMain.CurrentRow.Index).Value
            AgL.PubDivisionDBName = FGMain(GDataPath, FGMain.CurrentRow.Index).Value

            If Not AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName) Then
                If AgL.GCnComp IsNot Nothing Then AgL.GCnComp = Nothing
                If AgL.ECompConn IsNot Nothing Then AgL.ECompConn = Nothing

                AgL.GCnComp = New OleDb.OleDbConnection()
                AgL.ECompConn = New SqlClient.SqlConnection()
                If UCase(Trim(AgL.PubChkPasswordSQL)) = "Y" Then
                    AgL.GcnComp_ConnectionString = "Provider=SQLOLEDB;User ID='" & AgL.PubDBUserSQL & "';password=" & AgL.PubDBPasswordSQL & ";Data Source=" & AgL.PubServerName & ";Database=" & AgL.PubDivisionDBName & ""
                    AgL.GCnComp.ConnectionString = AgL.GcnComp_ConnectionString

                    AgL.ECompConn_ConnectionString = "Persist Security Info=False;User ID='" & AgL.PubDBUserSQL & "';pwd=" & AgL.PubDBPasswordSQL & ";Initial Catalog=" & AgL.PubDivisionDBName & ";Data Source=" & AgL.PubServerName
                    AgL.ECompConn.ConnectionString = AgL.ECompConn_ConnectionString
                Else
                    AgL.GcnComp_ConnectionString = "Provider=SQLOLEDB;User ID='sa';password=;Data Source=" & AgL.PubServerName & ";Database=" & AgL.PubDivisionDBName & ""
                    AgL.GCnComp.ConnectionString = AgL.GcnComp_ConnectionString

                    AgL.ECompConn_ConnectionString = "Persist Security Info=False;User ID='sa';pwd=;Initial Catalog=" & AgL.PubDivisionDBName & ";Data Source=" & AgL.PubServerName
                    AgL.ECompConn.ConnectionString = AgL.ECompConn_ConnectionString
                End If
                AgL.GCnComp.Open()
                AgL.ECompConn.Open()


                mQry = "Select D.* From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".Division As D With (NoLock) "
                bDtDivision = AgL.FillData(mQry, AgL.ECompConn).Tables(0)

                ''Updating Base Table in Division Database==
                mQry = "Select Table_Schema From INFORMATION_SCHEMA.Tables Where Table_Type='BASE TABLE' And Table_Name In (" & BaseTableList & ")"
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnMain)
                mTable_Schema = AgL.ECmd.ExecuteScalar

                AgL.DeleteForeignKey(AgL.ECompConn, "FK_UserSite_Company_CompCode", "UserSite")

                AgL.Dman_ExecuteNonQry("Delete From EntryPointPermission", AgL.ECompConn)
                AgL.Dman_ExecuteNonQry("Delete From User_Permission", AgL.ECompConn)
                AgL.Dman_ExecuteNonQry("Delete From User_Control_Permission", AgL.ECompConn)

                AgL.Dman_ExecuteNonQry("Delete From Company", AgL.ECompConn)
                AgL.Dman_ExecuteNonQry("Delete From UserMast", AgL.ECompConn)

                mQry = "Insert Into UserMast (USER_NAME,Code,PASSWD,Description,Admin) " & _
                        " (Select USER_NAME,Code,PASSWD,Description,Admin From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".UserMast)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)


                For bIntI = 0 To bDtDivision.Rows.Count - 1
                    mQry = "If Not EXISTS(SELECT * FROM Division With (NoLock) WHERE Div_Code = " & AgL.Chk_Text(bDtDivision.Rows(bIntI)("Div_Code")) & ") " & _
                                " Insert Into Division (Div_Code,Div_Name,DataPath,address1,address2,address3,city,pin,PreparedBy,U_EntDt,U_AE,Edit_Date,ModifiedBy) " & _
                                " (Select Div_Code,Div_Name,DataPath,address1,address2,address3,city,pin,PreparedBy,U_EntDt,U_AE,Edit_Date,ModifiedBy From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".Division WHERE Div_Code = " & AgL.Chk_Text(bDtDivision.Rows(bIntI)("Div_Code")) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)
                Next

                mQry = "Insert Into Company (Comp_Code,Div_Code,Comp_Name,CentralData_Path,Repo_Path, DbPrefix, Start_Dt,End_Dt,address1,address2,city,pin,phone,fax,lstno,lstdate,cstno,cstdate,cyear,pyear,SerialKeyNo,SName,EMail,Gram,Desc1,Desc2,Desc3,ECCCode,ExDivision,ExRegNo,ExColl,ExRange,Desc4,VatNo,VatDate,TinNo,Site_Code,LogSiteCode,PrevDBName,PANNo,State,U_Name,U_EntDt,U_AE,DeletedYN,Country,V_Prefix,NotificationNo,WorkAddress1,WorkAddress2,WorkCity,WorkCountry,WorkPin,WorkPhone,WorkFax,ImageDBName) " & _
                        " (Select Comp_Code,Div_Code,Comp_Name,CentralData_Path,Repo_Path, DbPrefix, Start_Dt,End_Dt,address1,address2,city,pin,phone,fax,lstno,lstdate,cstno,cstdate,cyear,pyear,SerialKeyNo,SName,EMail,Gram,Desc1,Desc2,Desc3,ECCCode,ExDivision,ExRegNo,ExColl,ExRange,Desc4,VatNo,VatDate,TinNo,Site_Code,LogSiteCode,PrevDBName,PANNo,State,U_Name,U_EntDt,U_AE,DeletedYN,Country,V_Prefix,NotificationNo,WorkAddress1,WorkAddress2,WorkCity,WorkCountry,WorkPin,WorkPhone,WorkFax,ImageDBName " & _
                        " From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".Company)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)


                mQry = "Insert Into User_Permission (UserName, MnuModule, MnuName, MnuText, SNo, MnuLevel, Parent, Permission, ReportFor, Active, MainStreamCode, GroupLevel, ControlPermissionGroups) " & _
                        " (Select UserName, MnuModule, MnuName, MnuText, SNo, MnuLevel, Parent, Permission, ReportFor, Active, MainStreamCode, GroupLevel, ControlPermissionGroups " & _
                        " From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".User_Permission)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)

                mQry = "Insert Into User_Control_Permission (UserName, MnuModule, MnuName, MnuText, GroupText, GroupName) " & _
                        " (Select UserName, MnuModule, MnuName, MnuText, GroupText, GroupName " & _
                        " From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".User_Control_Permission)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)

                mQry = "INSERT INTO EntryPointPermission (MnuModule, MnuName, IsOnLineEntry, IsOffLineEntry) " & _
                        "(SELECT MnuModule, MnuName, IsOnLineEntry, IsOffLineEntry " & _
                        " FROM " & AgL.PubCompanyDBName & "." & mTable_Schema & ".EntryPointPermission) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)


                mQry = "Select IsNull(Count(Table_Name),0) As Cnt From INFORMATION_SCHEMA.Tables Where Table_Name='Login_Log' And Table_Type='BASE TABLE'"
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.ECompConn)
                If AgL.ECmd.ExecuteScalar > 0 Then
                    AgL.Dman_ExecuteNonQry("Delete From Login_Log", AgL.ECompConn)

                    mQry = "Insert Into Login_Log (User_Name, MachineName, Div_Code, Site_Code , Comp_Code, U_EntDt) " & _
                            " (Select User_Name, MachineName, Div_Code, Site_Code , Comp_Code, U_EntDt " & _
                            " From " & AgL.PubCompanyDBName & "." & mTable_Schema & ".Login_Log)"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.ECompConn)
                End If
                ''==========================================
            End If

            FrmCompany.Show()
            Me.Dispose()
        End If
    End Sub

    

    Private Sub FrmCompany_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim LGBBaseBackGround As System.Drawing.Drawing2D.LinearGradientBrush
        Dim RctVar As Rectangle
        Dim CtlVar As Control
        Dim StrVar As String

        'For Form Left
        RctVar = New Rectangle(0, Me.LblBottom.Height + 32, Me.LblLeft.Width, Me.LblLeft.Height)
        LGBBaseBackGround = New System.Drawing.Drawing2D.LinearGradientBrush(RctVar, Color.Gray, _
                                Color.WhiteSmoke, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(LGBBaseBackGround, RctVar)

        'For Form Right
        RctVar = New Rectangle(Me.Width - Me.LblLeft.Width, Me.LblBottom.Height + 32, Me.LblRight.Width, Me.LblRight.Height)
        LGBBaseBackGround = New System.Drawing.Drawing2D.LinearGradientBrush(RctVar, Color.WhiteSmoke, _
                                Color.Gray, System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(LGBBaseBackGround, RctVar)

        For Each CtlVar In Me.Controls
            StrVar = CtlVar.GetType.ToString
            If StrVar = "System.Windows.Forms.Label" Then
                CtlVar.BackColor = System.Drawing.Color.Transparent
            End If
        Next
    End Sub

    Private Sub FGMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FGMain.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            FSelectDivision()
        End If
    End Sub
End Class