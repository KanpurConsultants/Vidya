Public Class FrmYarnSKUTransferIssue
    Inherits TempStockTransferIssue

    Protected Const Col1Colour As String = "Colour"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.YarnSkuTransferIssue
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.Visible = False
        '
        'FrmYarnSKUTransferIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(901, 562)
        Me.LogLineTableCsv = "Stock_LOG,StockProcess_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,StockProcess,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmYarnSKUTransferIssue"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.YarnSKU)
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCL.AddAgTextColumn(Dgl1, Col1Colour, 150, 0, Col1Colour, True, True)
        Dgl1.Columns(Col1Colour).DisplayIndex = 2
        Dgl1.Columns(Col1Item).HeaderText = "Yarn SKU"
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
    End Sub

    Private Sub FrmYarnSKUTransferIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 596, 909)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Protected Shadows Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.YarnSKU & "' "
        End Select
    End Sub

    Private Shadows Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String = ""
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = "SELECT S.Colour " & _
                    " FROM RUG_YarnSKU Y  " & _
                    " LEFT JOIN RUG_SHADE S ON Y.SHADE = S.Code " & _
                    " Where Y.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Colour, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Colour"))
            Else
                Dgl1.Item(Col1Colour, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function (" & Me.Name & ") ")
        End Try
    End Sub
End Class
