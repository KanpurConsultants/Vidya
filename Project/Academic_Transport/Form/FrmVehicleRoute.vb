Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmVehicleRoute
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col1Code As String = "Code"
    Private Const Col1VehicleCode As String = "Vehicle Code"
    Private Const Col1VehicleDesc As String = "Vehicle"
    Private Const Col1RouteCode As String = "Route Code"
    Private Const Col1RouteDesc As String = "Route"
    Private Const Col1AllotmentDate As String = "Allotment Date"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)

    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''<Executable Code>
    End Sub

    Private Sub IniVehicleRouteGrid()
        ''==============================================================================
        ''================< Vehicle/Route Grid >==========================================
        ''==============================================================================
        Dgl1.Columns(Col1Code).Visible = False
        Dgl1.Columns(Col1VehicleDesc).Visible = True : Dgl1.Columns(Col1VehicleCode).Width = 100
        Dgl1.Columns(Col1RouteDesc).Visible = True : Dgl1.Columns(Col1RouteDesc).Width = 250
        Dgl1.Columns(Col1AllotmentDate).Visible = True : Dgl1.Columns(Col1AllotmentDate).Width = 80

        Dgl1.Columns(Col1RouteCode).Visible = False
        Dgl1.Columns(Col1VehicleCode).Visible = False


        Dgl1.ColumnHeadersHeight = 40
        Dgl1.AllowUserToAddRows = False
        Dgl1.EnableHeadersVisualStyles = False        
        Dgl1.ReadOnly = True
        ''==============================================================================
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Tp_VehicleRoute.Code As SearchCode " & _
                " From Tp_VehicleRoute "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V.Code  As Code, V.RegistrationNo As [Vehicle No], V.Description As [Vehicle Name] " & _
                    " From Tp_Vehicle V " & _
                    " Order By V.RegistrationNo "
            TxtVehicle.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT R.Code, R.Description AS Name FROM Sch_Route R ORDER BY R.Description "
            TxtRoute.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtVehicle.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position
            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Tp_VehicleRoute Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , , , , AgL.PubSiteCode, AgL.PubDivCode)

                    AgL.ETrans.Commit()
                    mTrans = False


                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtVehicle.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "SELECT H.Code AS SearchCode, " & _
                            " V.RegistrationNo AS [" & LblVehicle.Text & "], " & _
                            " R.Description AS [" & LblRoute.Text & "], " & _
                            " " & AgL.ConvertDateField("H.AllotmentDate") & " AS [" & LblAllotmentDate.Text & "] " & _
                            " FROM dbo.Tp_VehicleRoute H " & _
                            " LEFT JOIN Tp_Vehicle V ON V.Code = H.Vehicle " & _
                            " LEFT JOIN Sch_Route R ON R.Code = H.Route "
            AgL.PubFindQryOrdBy = "[" & LblVehicle.Text & "]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> " Then" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            'Me.Cursor = Cursors.WaitCursor
            'AgL.PubReportTitle = "Vehicle Master"
            'If Not DTMaster.Rows.Count > 0 Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If


            'strQry = "Select V.RegistrationNo As [Registration No.],   " & _
            '            " V.Description As [" & LblDescription.Text & "],  " & _
            '            " V.VehicleType As [Vehicle Type],  " & _
            '            " V.VehicleModel As [Vehicle Model],  " & _
            '            " V.ChassisNo As [Chassis No.],  V.EngineNo As [Engine No.]  " & _
            '            " From  Tp_Vehicle V " & _
            '            " Left Join  SiteMast SiteMast1 On SiteMast1.Code = V.Site_Code "

            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(ds)
            'Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            'mPrnHnd.DataSetToPrint = ds
            'mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            'mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            'mPrnHnd.ReportTitle = "Vehicle Master"
            'mPrnHnd.TableIndex = 0
            'mPrnHnd.PageSetupDialog(True)
            'mPrnHnd.PrintPreview()
            'Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Tp_VehicleRoute (" & _
                        " Code, Vehicle, Route, AllotmentDate, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ('" & mSearchCode & "', " & _
                        " " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtAllotmentDate.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "','" & Format(AgL.PubLoginDate, "Short Date") & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update dbo.Tp_VehicleRoute " & _
                        " SET Vehicle = " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & ", " & _
                        " 	Route = " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & ", " & _
                        " 	AllotmentDate = " & AgL.ConvertDate(TxtAllotmentDate.Text) & ", " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "', " & _
                        " 	ModifiedBy =  '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "UPDATE Tp_Vehicle SET Tp_Vehicle.Route = vH.Route " & _
                    " FROM " & _
                    " (SELECT TOP 1  H.Vehicle, H.Route  " & _
                    " FROM Tp_VehicleRoute H " & _
                    " INNER JOIN (SELECT Vr.Vehicle, Max(Vr.AllotmentDate) AllotmentDate " & _
                    " FROM Tp_VehicleRoute Vr WITH (NoLock) " & _
                    " WHERE Vr.Vehicle = " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & " " & _
                    " GROUP BY Vr.Vehicle " & _
                    " ) vVr On vVr.Vehicle = H.Vehicle AND vVr.AllotmentDate = H.AllotmentDate) vH " & _
                    " WHERE Tp_Vehicle.Code = vH.Vehicle " & _
                    " And Tp_Vehicle.Route <> vH.Route "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , , , , AgL.PubSiteCode, AgL.PubDivCode)
            AgL.ETrans.Commit()
            mTrans = False
            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select H.* " & _
                    " From Tp_VehicleRoute  H " & _
                    " Where H.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtVehicle.AgSelectedValue = AgL.XNull(.Rows(0)("Vehicle"))
                        TxtRoute.AgSelectedValue = AgL.XNull(.Rows(0)("Route"))
                        TxtAllotmentDate.Text = Format(AgL.XNull(.Rows(0)("AllotmentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)



                        Call ProcFillVehicleRoute()

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With
            Else
                BlankText()
            End If

            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = ""
        Dgl1.DataSource = Nothing
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
       Handles TxtSite_Code.Validating, TxtVehicle.Validating, TxtRoute.Validating, TxtAllotmentDate.Validating

        Try
            Select Case sender.NAME
                '<Executable Code>
            End Select

            Call ProcFillVehicleRoute()

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Call Calculation()

        If AgL.RequiredField(TxtSite_Code) Then Exit Function
        If AgL.RequiredField(TxtVehicle, LblVehicle.Text) Then Exit Function
        If AgL.RequiredField(TxtRoute, LblRoute.Text) Then Exit Function


        mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                " FROM Tp_VehicleRoute H " & _
                " WHERE H.AllotmentDate = " & AgL.ConvertDate(TxtAllotmentDate.Text) & " " & _
                " AND H.Vehicle = " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & " " & _
                " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.Code <> '" & mSearchCode & "'") & " "
        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
            MsgBox("Record Already Exists!...")
            TxtAllotmentDate.Focus()
            Exit Function
        End If

        If Topctrl1.Mode = "Add" Then
            mSearchCode = AgL.GetMaxId("Tp_VehicleRoute", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True)
        End If

        ''====RETRUN VALUE==============================================================================================================================================================
        Data_Validation = True
    End Function

    Private Sub ProcFillVehicleRoute()
        Dim bDtHeader As DataTable = Nothing
        Dim bCondStrMain$ = " Where 1=1 ", bCondStr$ = " Where 1=1 "
        Dim bStrHeaderQry$ = ""

        Try
            Dgl1.DataSource = Nothing

            bCondStrMain += " And H.Vehicle = " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & " "
            bCondStrMain += " And H.Route = " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & " "
            bCondStrMain += " And H.AllotmentDate <= " & AgL.ConvertDate(TxtAllotmentDate.Text) & " "

            ''=====================================================================================================================================================================================
            ''======================< Visit Detail >===================================================================================================================================================
            ''=====================================================================================================================================================================================

            bStrHeaderQry = "SELECT H.Code AS [" & Col1Code & "], " & _
                            " V.RegistrationNo AS [" & Col1VehicleDesc & "], " & _
                            " R.Description AS [" & Col1RouteDesc & "], " & _
                            " " & AgL.ConvertDateField("H.AllotmentDate") & " AS [" & Col1AllotmentDate & "], " & _
                            " H.Vehicle AS [" & Col1VehicleCode & "], " & _
                            " H.Route AS [" & Col1RouteCode & "] " & _
                            " FROM dbo.Tp_VehicleRoute H " & _
                            " LEFT JOIN Tp_Vehicle V ON V.Code = H.Vehicle " & _
                            " LEFT JOIN Sch_Route R ON R.Code = H.Route " & bCondStrMain

            mQry = "Select vH.* " & _
                    " From (" & bStrHeaderQry & ") as vH " & _
                    " " & bCondStr & " Order By Convert(SmallDateTime, [" & Col1AllotmentDate & "]) Desc "
            bDtHeader = AgL.FillData(mQry, AgL.GCn).Tables(0)

            Dgl1.DataSource = bDtHeader

            Call IniVehicleRouteGrid()

        Catch ex As Exception
            Dgl1.DataSource = Nothing
            MsgBox(ex.Message)
        Finally
            If bDtHeader IsNot Nothing Then bDtHeader.Dispose()
        End Try
    End Sub

End Class

