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
        Me.MnuFeeManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuFmStreamYearSemesterFeeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFeeStructureChangeEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmReceiveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeDueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeReceiveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeRefundEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAdvanceReminder = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInstallmentCreateEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInstallmentReminder = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFeeReAssignEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeDueReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmCategoryWiseCourseWiseOutstanding = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmStudentOutstandingReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmStudentOutstandingReportCategoryWise = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmStudentOutstandingReportFeeHeadWise = New System.Windows.Forms.ToolStripMenuItem
        Me.OutStandingReportFeeHeadWiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeReceiveReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmAdditionalFeeFineReceiptReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeReceiptHeadWiseReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFeeReceiptReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmStudentLedger = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmBankScrollList = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeCollectionReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeCollectionSummaryStudentWise = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFeeReceiveRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeManagementReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeStructureReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmClassWiseSubjectReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmAdvanceReceiveRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmFeeRefundRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFeeReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFeeReportSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInstallmentReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFmUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLateFeeParameter = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFeeManagement})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuFeeManagement
        '
        Me.MnuFeeManagement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmMasters, Me.MnuFmTransactions, Me.MnuFmReports, Me.MnuFmUtility})
        Me.MnuFeeManagement.Name = "MnuFeeManagement"
        Me.MnuFeeManagement.Size = New System.Drawing.Size(37, 20)
        Me.MnuFeeManagement.Text = "Fee"
        '
        'MnuFmMasters
        '
        Me.MnuFmMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmFeeGroupMaster, Me.MnuFmFeeMaster, Me.ToolStripMenuItem1, Me.MnuFmStreamYearSemesterFeeMaster})
        Me.MnuFmMasters.Name = "MnuFmMasters"
        Me.MnuFmMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuFmMasters.Text = "Masters"
        '
        'MnuFmFeeGroupMaster
        '
        Me.MnuFmFeeGroupMaster.Name = "MnuFmFeeGroupMaster"
        Me.MnuFmFeeGroupMaster.Size = New System.Drawing.Size(179, 22)
        Me.MnuFmFeeGroupMaster.Text = "Fee Group Master"
        '
        'MnuFmFeeMaster
        '
        Me.MnuFmFeeMaster.Name = "MnuFmFeeMaster"
        Me.MnuFmFeeMaster.Size = New System.Drawing.Size(179, 22)
        Me.MnuFmFeeMaster.Text = "Fee Master"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 6)
        '
        'MnuFmStreamYearSemesterFeeMaster
        '
        Me.MnuFmStreamYearSemesterFeeMaster.Name = "MnuFmStreamYearSemesterFeeMaster"
        Me.MnuFmStreamYearSemesterFeeMaster.Size = New System.Drawing.Size(179, 22)
        Me.MnuFmStreamYearSemesterFeeMaster.Text = "Class Fee Allotment"
        '
        'MnuFmTransactions
        '
        Me.MnuFmTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFeeStructureChangeEntry, Me.MnuFmReceiveEntry, Me.MnuFmFeeDueEntry, Me.MnuFmFeeReceiveEntry, Me.MnuFmFeeRefundEntry, Me.MnuAdvanceReminder, Me.MnuInstallmentCreateEntry, Me.MnuInstallmentReminder, Me.mnuFeeReAssignEntry})
        Me.MnuFmTransactions.Name = "MnuFmTransactions"
        Me.MnuFmTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuFmTransactions.Text = "Transactions"
        '
        'MnuFeeStructureChangeEntry
        '
        Me.MnuFeeStructureChangeEntry.Name = "MnuFeeStructureChangeEntry"
        Me.MnuFeeStructureChangeEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuFeeStructureChangeEntry.Text = "Fee Structure Change Entry"
        '
        'MnuFmReceiveEntry
        '
        Me.MnuFmReceiveEntry.Name = "MnuFmReceiveEntry"
        Me.MnuFmReceiveEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuFmReceiveEntry.Text = "Receive Entry"
        '
        'MnuFmFeeDueEntry
        '
        Me.MnuFmFeeDueEntry.Name = "MnuFmFeeDueEntry"
        Me.MnuFmFeeDueEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuFmFeeDueEntry.Text = "Fee Due Entry"
        '
        'MnuFmFeeReceiveEntry
        '
        Me.MnuFmFeeReceiveEntry.AccessibleDescription = ""
        Me.MnuFmFeeReceiveEntry.Name = "MnuFmFeeReceiveEntry"
        Me.MnuFmFeeReceiveEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuFmFeeReceiveEntry.Text = "Fee Receive Entry"
        '
        'MnuFmFeeRefundEntry
        '
        Me.MnuFmFeeRefundEntry.Name = "MnuFmFeeRefundEntry"
        Me.MnuFmFeeRefundEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuFmFeeRefundEntry.Text = "Fee Refund Entry"
        '
        'MnuAdvanceReminder
        '
        Me.MnuAdvanceReminder.Name = "MnuAdvanceReminder"
        Me.MnuAdvanceReminder.Size = New System.Drawing.Size(220, 22)
        Me.MnuAdvanceReminder.Text = "Advance Reminder"
        '
        'MnuInstallmentCreateEntry
        '
        Me.MnuInstallmentCreateEntry.Name = "MnuInstallmentCreateEntry"
        Me.MnuInstallmentCreateEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuInstallmentCreateEntry.Text = "Installment Create Entry"
        '
        'MnuInstallmentReminder
        '
        Me.MnuInstallmentReminder.Name = "MnuInstallmentReminder"
        Me.MnuInstallmentReminder.Size = New System.Drawing.Size(220, 22)
        Me.MnuInstallmentReminder.Text = "Installment Reminder"
        '
        'mnuFeeReAssignEntry
        '
        Me.mnuFeeReAssignEntry.Name = "mnuFeeReAssignEntry"
        Me.mnuFeeReAssignEntry.Size = New System.Drawing.Size(220, 22)
        Me.mnuFeeReAssignEntry.Text = "Fee Re-Assign Entry"
        '
        'MnuFmReports
        '
        Me.MnuFmReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmFeeDueReports, Me.MnuFmFeeReceiveReports, Me.MnuFmFeeManagementReports})
        Me.MnuFmReports.Name = "MnuFmReports"
        Me.MnuFmReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuFmReports.Text = "Reports"
        '
        'MnuFmFeeDueReports
        '
        Me.MnuFmFeeDueReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmCategoryWiseCourseWiseOutstanding, Me.MnuFmStudentOutstandingReport, Me.MnuFmStudentOutstandingReportCategoryWise, Me.MnuFmStudentOutstandingReportFeeHeadWise, Me.OutStandingReportFeeHeadWiseToolStripMenuItem})
        Me.MnuFmFeeDueReports.Name = "MnuFmFeeDueReports"
        Me.MnuFmFeeDueReports.Size = New System.Drawing.Size(209, 22)
        Me.MnuFmFeeDueReports.Text = "Fee Due Reports"
        '
        'MnuFmCategoryWiseCourseWiseOutstanding
        '
        Me.MnuFmCategoryWiseCourseWiseOutstanding.Name = "MnuFmCategoryWiseCourseWiseOutstanding"
        Me.MnuFmCategoryWiseCourseWiseOutstanding.Size = New System.Drawing.Size(296, 22)
        Me.MnuFmCategoryWiseCourseWiseOutstanding.Tag = "ACADEMIC MAIN"
        Me.MnuFmCategoryWiseCourseWiseOutstanding.Text = "Category Wise Course Wise Outstanding"
        '
        'MnuFmStudentOutstandingReport
        '
        Me.MnuFmStudentOutstandingReport.Name = "MnuFmStudentOutstandingReport"
        Me.MnuFmStudentOutstandingReport.Size = New System.Drawing.Size(296, 22)
        Me.MnuFmStudentOutstandingReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmStudentOutstandingReport.Text = "Student Outstanding Report"
        '
        'MnuFmStudentOutstandingReportCategoryWise
        '
        Me.MnuFmStudentOutstandingReportCategoryWise.Name = "MnuFmStudentOutstandingReportCategoryWise"
        Me.MnuFmStudentOutstandingReportCategoryWise.Size = New System.Drawing.Size(296, 22)
        Me.MnuFmStudentOutstandingReportCategoryWise.Tag = "ACADEMIC MAIN"
        Me.MnuFmStudentOutstandingReportCategoryWise.Text = "Student Outstanding Report Category Wise"
        '
        'MnuFmStudentOutstandingReportFeeHeadWise
        '
        Me.MnuFmStudentOutstandingReportFeeHeadWise.Name = "MnuFmStudentOutstandingReportFeeHeadWise"
        Me.MnuFmStudentOutstandingReportFeeHeadWise.Size = New System.Drawing.Size(296, 22)
        Me.MnuFmStudentOutstandingReportFeeHeadWise.Tag = "ACADEMIC MAIN"
        Me.MnuFmStudentOutstandingReportFeeHeadWise.Text = "Student Outstanding Report Fee Head Wise"
        '
        'OutStandingReportFeeHeadWiseToolStripMenuItem
        '
        Me.OutStandingReportFeeHeadWiseToolStripMenuItem.Name = "OutStandingReportFeeHeadWiseToolStripMenuItem"
        Me.OutStandingReportFeeHeadWiseToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.OutStandingReportFeeHeadWiseToolStripMenuItem.Tag = "Report"
        Me.OutStandingReportFeeHeadWiseToolStripMenuItem.Text = "OutStanding Report Fee Head Wise"
        '
        'MnuFmFeeReceiveReports
        '
        Me.MnuFmFeeReceiveReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmAdditionalFeeFineReceiptReport, Me.MnuFmFeeReceiptHeadWiseReport, Me.MnuFeeReceiptReport, Me.MnuFmStudentLedger, Me.MnuFmBankScrollList, Me.MnuFmFeeCollectionReport, Me.MnuFmFeeCollectionSummaryStudentWise, Me.mnuFeeReceiveRegister})
        Me.MnuFmFeeReceiveReports.Name = "MnuFmFeeReceiveReports"
        Me.MnuFmFeeReceiveReports.Size = New System.Drawing.Size(209, 22)
        Me.MnuFmFeeReceiveReports.Text = "Fee Receive Reports"
        '
        'MnuFmAdditionalFeeFineReceiptReport
        '
        Me.MnuFmAdditionalFeeFineReceiptReport.Name = "MnuFmAdditionalFeeFineReceiptReport"
        Me.MnuFmAdditionalFeeFineReceiptReport.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmAdditionalFeeFineReceiptReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmAdditionalFeeFineReceiptReport.Text = "Additional/Fee Fine Receipt Report"
        '
        'MnuFmFeeReceiptHeadWiseReport
        '
        Me.MnuFmFeeReceiptHeadWiseReport.Name = "MnuFmFeeReceiptHeadWiseReport"
        Me.MnuFmFeeReceiptHeadWiseReport.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmFeeReceiptHeadWiseReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmFeeReceiptHeadWiseReport.Text = "Fee Receipt Head Wise Report"
        '
        'MnuFeeReceiptReport
        '
        Me.MnuFeeReceiptReport.Name = "MnuFeeReceiptReport"
        Me.MnuFeeReceiptReport.Size = New System.Drawing.Size(266, 22)
        Me.MnuFeeReceiptReport.Tag = "ACADEMIC MAIN"
        Me.MnuFeeReceiptReport.Text = "Fee Receipt Report"
        '
        'MnuFmStudentLedger
        '
        Me.MnuFmStudentLedger.Name = "MnuFmStudentLedger"
        Me.MnuFmStudentLedger.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmStudentLedger.Tag = "ACADEMIC MAIN"
        Me.MnuFmStudentLedger.Text = "Student Ledger"
        '
        'MnuFmBankScrollList
        '
        Me.MnuFmBankScrollList.Name = "MnuFmBankScrollList"
        Me.MnuFmBankScrollList.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmBankScrollList.Tag = "ACADEMIC MAIN"
        Me.MnuFmBankScrollList.Text = "Bank Scroll List"
        '
        'MnuFmFeeCollectionReport
        '
        Me.MnuFmFeeCollectionReport.Name = "MnuFmFeeCollectionReport"
        Me.MnuFmFeeCollectionReport.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmFeeCollectionReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmFeeCollectionReport.Text = "Fee Collection Report"
        '
        'MnuFmFeeCollectionSummaryStudentWise
        '
        Me.MnuFmFeeCollectionSummaryStudentWise.Name = "MnuFmFeeCollectionSummaryStudentWise"
        Me.MnuFmFeeCollectionSummaryStudentWise.Size = New System.Drawing.Size(266, 22)
        Me.MnuFmFeeCollectionSummaryStudentWise.Tag = "ACADEMIC MAIN"
        Me.MnuFmFeeCollectionSummaryStudentWise.Text = "Fee Collection Summary Student Wise"
        '
        'mnuFeeReceiveRegister
        '
        Me.mnuFeeReceiveRegister.Name = "mnuFeeReceiveRegister"
        Me.mnuFeeReceiveRegister.Size = New System.Drawing.Size(266, 22)
        Me.mnuFeeReceiveRegister.Tag = "Report"
        Me.mnuFeeReceiveRegister.Text = "Fee Receive Register"
        '
        'MnuFmFeeManagementReports
        '
        Me.MnuFmFeeManagementReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFmFeeStructureReport, Me.MnuFmClassWiseSubjectReport, Me.MnuFmAdvanceReceiveRegister, Me.MnuFmFeeRefundRegister, Me.MnuFeeReport, Me.MnuFeeReportSummary, Me.MnuInstallmentReport})
        Me.MnuFmFeeManagementReports.Name = "MnuFmFeeManagementReports"
        Me.MnuFmFeeManagementReports.Size = New System.Drawing.Size(209, 22)
        Me.MnuFmFeeManagementReports.Text = "Fee Management Reports"
        '
        'MnuFmFeeStructureReport
        '
        Me.MnuFmFeeStructureReport.Name = "MnuFmFeeStructureReport"
        Me.MnuFmFeeStructureReport.Size = New System.Drawing.Size(211, 22)
        Me.MnuFmFeeStructureReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmFeeStructureReport.Text = "Fee Structure Report"
        '
        'MnuFmClassWiseSubjectReport
        '
        Me.MnuFmClassWiseSubjectReport.Name = "MnuFmClassWiseSubjectReport"
        Me.MnuFmClassWiseSubjectReport.Size = New System.Drawing.Size(211, 22)
        Me.MnuFmClassWiseSubjectReport.Tag = "ACADEMIC MAIN"
        Me.MnuFmClassWiseSubjectReport.Text = "Class Wise Subject Report"
        '
        'MnuFmAdvanceReceiveRegister
        '
        Me.MnuFmAdvanceReceiveRegister.Name = "MnuFmAdvanceReceiveRegister"
        Me.MnuFmAdvanceReceiveRegister.Size = New System.Drawing.Size(211, 22)
        Me.MnuFmAdvanceReceiveRegister.Tag = "ACADEMIC MAIN"
        Me.MnuFmAdvanceReceiveRegister.Text = "Advance Receive Register"
        '
        'MnuFmFeeRefundRegister
        '
        Me.MnuFmFeeRefundRegister.Name = "MnuFmFeeRefundRegister"
        Me.MnuFmFeeRefundRegister.Size = New System.Drawing.Size(211, 22)
        Me.MnuFmFeeRefundRegister.Tag = "ACADEMIC MAIN"
        Me.MnuFmFeeRefundRegister.Text = "Fee Refund Register"
        '
        'MnuFeeReport
        '
        Me.MnuFeeReport.Name = "MnuFeeReport"
        Me.MnuFeeReport.Size = New System.Drawing.Size(211, 22)
        Me.MnuFeeReport.Tag = "ACADEMIC MAIN"
        Me.MnuFeeReport.Text = "Fee Report"
        '
        'MnuFeeReportSummary
        '
        Me.MnuFeeReportSummary.Name = "MnuFeeReportSummary"
        Me.MnuFeeReportSummary.Size = New System.Drawing.Size(211, 22)
        Me.MnuFeeReportSummary.Tag = "ACADEMIC MAIN"
        Me.MnuFeeReportSummary.Text = "Fee Report Summary"
        '
        'MnuInstallmentReport
        '
        Me.MnuInstallmentReport.Name = "MnuInstallmentReport"
        Me.MnuInstallmentReport.Size = New System.Drawing.Size(211, 22)
        Me.MnuInstallmentReport.Tag = "Report"
        Me.MnuInstallmentReport.Text = "Installment Report"
        '
        'MnuFmUtility
        '
        Me.MnuFmUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLateFeeParameter})
        Me.MnuFmUtility.Name = "MnuFmUtility"
        Me.MnuFmUtility.Size = New System.Drawing.Size(152, 22)
        Me.MnuFmUtility.Text = "Utility"
        '
        'mnuLateFeeParameter
        '
        Me.mnuLateFeeParameter.Name = "mnuLateFeeParameter"
        Me.mnuLateFeeParameter.Size = New System.Drawing.Size(180, 22)
        Me.mnuLateFeeParameter.Text = "Late Fee Parameter"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(967, 663)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Fee Module"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuFmMasters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmStreamYearSemesterFeeMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmTransactions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmReceiveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeDueEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeReceiveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeRefundEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeDueReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmCategoryWiseCourseWiseOutstanding As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmStudentOutstandingReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmStudentOutstandingReportCategoryWise As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmStudentOutstandingReportFeeHeadWise As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeReceiveReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmAdditionalFeeFineReceiptReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeReceiptHeadWiseReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFeeReceiptReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmStudentLedger As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmBankScrollList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeCollectionReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeCollectionSummaryStudentWise As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeManagementReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeStructureReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmClassWiseSubjectReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmAdvanceReceiveRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmFeeRefundRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFmUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuFeeManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuAdvanceReminder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFeeReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFeeReportSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFeeStructureChangeEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuInstallmentCreateEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuInstallmentReminder As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuInstallmentReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OutStandingReportFeeHeadWiseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFeeReceiveRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFeeReAssignEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLateFeeParameter As System.Windows.Forms.ToolStripMenuItem

End Class
