<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuStore = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemCategoryMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGodownMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPartyMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStoreIssueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStoreReceiveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.SaleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemWiseSaleReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PurchaseReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemWisePurchaseReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StoreIssueReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStoreReceiveReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuStore})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuStore
        '
        Me.MnuStore.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports})
        Me.MnuStore.Name = "MnuStore"
        Me.MnuStore.Size = New System.Drawing.Size(45, 20)
        Me.MnuStore.Text = "Store"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuItemMaster, Me.MnuItemGroupMaster, Me.MnuItemCategoryMaster, Me.MnuGodownMaster, Me.MnuPartyMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuItemMaster
        '
        Me.MnuItemMaster.Name = "MnuItemMaster"
        Me.MnuItemMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemMaster.Text = "Item Master"
        '
        'MnuItemGroupMaster
        '
        Me.MnuItemGroupMaster.Name = "MnuItemGroupMaster"
        Me.MnuItemGroupMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemGroupMaster.Text = "Item Group Master"
        '
        'MnuItemCategoryMaster
        '
        Me.MnuItemCategoryMaster.Name = "MnuItemCategoryMaster"
        Me.MnuItemCategoryMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemCategoryMaster.Text = "Item Category Master"
        '
        'MnuGodownMaster
        '
        Me.MnuGodownMaster.Name = "MnuGodownMaster"
        Me.MnuGodownMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuGodownMaster.Text = "Godown Master"
        '
        'MnuPartyMaster
        '
        Me.MnuPartyMaster.Name = "MnuPartyMaster"
        Me.MnuPartyMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuPartyMaster.Text = "Party Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuStoreIssueEntry, Me.MnuStoreReceiveEntry, Me.MnuSaleEntry, Me.MnuPurchaseEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuStoreIssueEntry
        '
        Me.MnuStoreIssueEntry.Name = "MnuStoreIssueEntry"
        Me.MnuStoreIssueEntry.Size = New System.Drawing.Size(181, 22)
        Me.MnuStoreIssueEntry.Text = "Store Issue Entry"
        '
        'MnuStoreReceiveEntry
        '
        Me.MnuStoreReceiveEntry.Name = "MnuStoreReceiveEntry"
        Me.MnuStoreReceiveEntry.Size = New System.Drawing.Size(181, 22)
        Me.MnuStoreReceiveEntry.Text = "Store Receive Entry"
        '
        'MnuSaleEntry
        '
        Me.MnuSaleEntry.Name = "MnuSaleEntry"
        Me.MnuSaleEntry.Size = New System.Drawing.Size(181, 22)
        Me.MnuSaleEntry.Text = "Sale Entry"
        '
        'MnuPurchaseEntry
        '
        Me.MnuPurchaseEntry.Name = "MnuPurchaseEntry"
        Me.MnuPurchaseEntry.Size = New System.Drawing.Size(181, 22)
        Me.MnuPurchaseEntry.Text = "Purchase Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaleReportToolStripMenuItem, Me.ItemWiseSaleReportToolStripMenuItem, Me.PurchaseReportToolStripMenuItem, Me.ItemWisePurchaseReportToolStripMenuItem, Me.StoreIssueReportToolStripMenuItem, Me.MnuStoreReceiveReport})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'SaleReportToolStripMenuItem
        '
        Me.SaleReportToolStripMenuItem.Name = "SaleReportToolStripMenuItem"
        Me.SaleReportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SaleReportToolStripMenuItem.Text = "Sale Report"
        '
        'ItemWiseSaleReportToolStripMenuItem
        '
        Me.ItemWiseSaleReportToolStripMenuItem.Name = "ItemWiseSaleReportToolStripMenuItem"
        Me.ItemWiseSaleReportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ItemWiseSaleReportToolStripMenuItem.Tag = "Report"
        Me.ItemWiseSaleReportToolStripMenuItem.Text = "Item Wise Sale Report"
        '
        'PurchaseReportToolStripMenuItem
        '
        Me.PurchaseReportToolStripMenuItem.Name = "PurchaseReportToolStripMenuItem"
        Me.PurchaseReportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.PurchaseReportToolStripMenuItem.Text = "Purchase Report"
        '
        'ItemWisePurchaseReportToolStripMenuItem
        '
        Me.ItemWisePurchaseReportToolStripMenuItem.Name = "ItemWisePurchaseReportToolStripMenuItem"
        Me.ItemWisePurchaseReportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ItemWisePurchaseReportToolStripMenuItem.Tag = "Report"
        Me.ItemWisePurchaseReportToolStripMenuItem.Text = "Item Wise Purchase Report"
        '
        'StoreIssueReportToolStripMenuItem
        '
        Me.StoreIssueReportToolStripMenuItem.Name = "StoreIssueReportToolStripMenuItem"
        Me.StoreIssueReportToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.StoreIssueReportToolStripMenuItem.Tag = "Report"
        Me.StoreIssueReportToolStripMenuItem.Text = "Store Issue Report"
        '
        'MnuStoreReceiveReport
        '
        Me.MnuStoreReceiveReport.Name = "MnuStoreReceiveReport"
        Me.MnuStoreReceiveReport.Size = New System.Drawing.Size(216, 22)
        Me.MnuStoreReceiveReport.Tag = "Reports"
        Me.MnuStoreReceiveReport.Text = "Store Receive Report"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(967, 586)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Store"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuItemCategoryMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStoreIssueEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStoreReceiveEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaleEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGodownMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPartyMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemWiseSaleReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemWisePurchaseReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StoreIssueReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStoreReceiveReport As System.Windows.Forms.ToolStripMenuItem

End Class
