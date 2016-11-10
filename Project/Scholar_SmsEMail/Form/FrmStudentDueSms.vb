Public Class FrmStudentDueSms
    Inherits TempCommonSmsStudent

    Dim mQry$ = ""

    Protected Const Col1DueAmount As String = "Due Amount"

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFooter
        '
        Me.PnlFooter.Location = New System.Drawing.Point(47, 581)
        Me.PnlFooter.Size = New System.Drawing.Size(878, 24)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(47, 264)
        Me.Pnl1.Size = New System.Drawing.Size(878, 317)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(47, 246)
        Me.LinkLabel1.Size = New System.Drawing.Size(878, 20)
        '
        'FrmStudentDueSms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Name = "FrmStudentDueSms"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub FrmStudentDueSms_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        mQry = "Update Sms_Trans " & _
                " Set DueAmount = " & Val(DGL1.Item(Col1DueAmount, mGridRow).Value) & " " & _
                " Where Code = " & AgL.Chk_Text(SearchCode) & " " & _
                " And Sr = " & Sr & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmStudentDueSms_BaseFunction_FillData() Handles Me.BaseFunction_FillData
        Dim DtTemp As DataTable
        Dim bIntI% = 0
        Dim bCondStr$ = " WHERE 1=1 ", bDueQry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            bCondStr += " And " & AgL.PubSiteCondition("Sg.Site_Code", TxtSite_Code.AgSelectedValue) & " "

            If TxtStreamYearSemester.Text.Trim <> "" Then
                bCondStr += " And A.CurrentSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "

            Else
                If TxtSession.Text.Trim <> "" Then
                    bCondStr += " And A.SessionCode = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " "
                End If

                If TxtProgramme.Text.Trim <> "" Then
                    bCondStr += " And A.ProgrammeCode = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & " "
                End If

                If TxtStream.Text.Trim <> "" Then
                    bCondStr += " And A.StreamCode = " & AgL.Chk_Text(TxtStream.AgSelectedValue) & " "
                End If

                If TxtSemester.Text.Trim <> "" Then
                    bCondStr += " And A.SemesterCode = " & AgL.Chk_Text(TxtSemester.AgSelectedValue) & " "
                End If

            End If

            bDueQry = "SELECT L.SubCode, IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0)  AS Balance " & _
                         " FROM Ledger L WITH (NoLock) " & _
                         " GROUP BY L.SubCode  " & _
                         " HAVING IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0) > 0 "

            mQry = "Select A.Student As StudentCode, Sg.Name, " & _
                    " Right(IsNull(Sg.Mobile,''),10) As Mobile, " & _
                    " Sg.ManualCode,  " & _
                    " Sg.DispName, " & _
                    " A.DocId As AdmissionDocId, " & _
                    " A.CurrentSemester, " & _
                    " Sem.StreamYearSemesterDesc, " & _
                    " Sem.SemesterDesc, " & _
                    " Sem.ProgrammeManualCode, " & _
                    " Sem.StreamManualCode, " & _
                    " Sem.SessionManualCode, " & _
                    " Sem.YearSerial,  " & _
                    " vD.Balance As DueAmount" & _
                    " FROM (Sch_Admission A WITH (NoLock) " & _
                    " Inner Join (" & bDueQry & ") As vD On vD.SubCode = A.Student) " & _
                    " LEFT JOIN Sch_Student S WITH (NoLock) ON A.Student = S.SubCode  " & _
                    " Left Join SubGroup Sg With (NoLock) On Sg.SubCode = S.SubCode  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem WITH (NoLock) ON Sem.Code = A.CurrentSemester " & _
                    " " & bCondStr & ""


            DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For bIntI = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count

                        If AgL.StrCmp(TxtSelectAll.Text, "Yes") Then
                            DGL1(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Else
                            DGL1(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        End If

                        DGL1.AgSelectedValue(Col1Name, bIntI) = AgL.XNull(.Rows(bIntI)("AdmissionDocId"))
                        DGL1.Item(Col1SubCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("StudentCode"))
                        DGL1.Item(Col1Name, bIntI).Value = AgL.XNull(.Rows(bIntI)("Name"))
                        DGL1.Item(Col1DispName, bIntI).Value = AgL.XNull(.Rows(bIntI)("DispName"))
                        DGL1.Item(Col1ManualCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("ManualCode"))
                        DGL1.Item(Col1Mobile, bIntI).Value = AgL.XNull(.Rows(bIntI)("Mobile"))
                        DGL1.AgSelectedValue(Col1StreamYearSemester, bIntI) = AgL.XNull(.Rows(bIntI)("CurrentSemester"))
                        DGL1.Item(Col1DueAmount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("DueAmount")), "0.00")
                    Next bIntI
                Else
                    MsgBox("No Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub FrmStudentDueSms_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgNumberColumn(DGL1, Col1DueAmount, 90, 8, 2, False, Col1DueAmount, True, True, True)
        End With
    End Sub

    Private Sub FrmStudentDueSms_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine
        Dim bDtTemp As DataTable = Nothing
        Try
            mQry = "Select L.* From Sms_Trans L With (NoLock) " & _
                    " Where L.Code = " & AgL.Chk_Text(SearchCode) & " " & _
                    " And L.Sr = " & Sr & " "
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            With bDtTemp
                If .Rows.Count > 0 Then
                    DGL1.Item(Col1DueAmount, mGridRow).Value = Format(AgL.VNull(.Rows(0)("DueAmount")), "0.00")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
        End Try
    End Sub
End Class
