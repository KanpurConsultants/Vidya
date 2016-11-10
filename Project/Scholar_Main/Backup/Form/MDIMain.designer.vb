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
        Me.MnuSASAcademicManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmTeacherMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuClassSubjectAllotment = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmAdmissionEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAdmissionEntryAuthenticated = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStudentFamilyIncomeEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmRollNoAssignEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentAttendanceEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentLeaveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MnuAmStudentLeftEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentPromotionEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDocumentIssueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmTeacherRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmStudentLeftRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmAdmissionRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAttendanceRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStudentCurrentList = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmIdentityCard = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAmEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSASAcademicManagement})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuSASAcademicManagement
        '
        Me.MnuSASAcademicManagement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAmMasters, Me.MnuAmTransactions, Me.MnuAmReports, Me.MnuAmUtility})
        Me.MnuSASAcademicManagement.Name = "MnuSASAcademicManagement"
        Me.MnuSASAcademicManagement.Size = New System.Drawing.Size(64, 20)
        Me.MnuSASAcademicManagement.Text = "Academic"
        '
        'MnuAmMasters
        '
        Me.MnuAmMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAmStudentMaster, Me.MnuAmTeacherMaster, Me.mnuClassSubjectAllotment})
        Me.MnuAmMasters.Name = "MnuAmMasters"
        Me.MnuAmMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuAmMasters.Text = "Masters"
        '
        'MnuAmStudentMaster
        '
        Me.MnuAmStudentMaster.Name = "MnuAmStudentMaster"
        Me.MnuAmStudentMaster.Size = New System.Drawing.Size(197, 22)
        Me.MnuAmStudentMaster.Text = "Student Master"
        '
        'MnuAmTeacherMaster
        '
        Me.MnuAmTeacherMaster.Name = "MnuAmTeacherMaster"
        Me.MnuAmTeacherMaster.Size = New System.Drawing.Size(197, 22)
        Me.MnuAmTeacherMaster.Text = "Teacher Master"
        '
        'mnuClassSubjectAllotment
        '
        Me.mnuClassSubjectAllotment.Name = "mnuClassSubjectAllotment"
        Me.mnuClassSubjectAllotment.Size = New System.Drawing.Size(197, 22)
        Me.mnuClassSubjectAllotment.Text = "Class Subject Allotment"
        '
        'MnuAmTransactions
        '
        Me.MnuAmTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAmAdmissionEntry, Me.MnuAdmissionEntryAuthenticated, Me.MnuStudentFamilyIncomeEntry, Me.MnuAmRollNoAssignEntry, Me.MnuAmStudentAttendanceEntry, Me.MnuAmStudentLeaveEntry, Me.ToolStripMenuItem1, Me.MnuAmStudentLeftEntry, Me.MnuAmStudentPromotionEntry, Me.MnuDocumentIssueEntry})
        Me.MnuAmTransactions.Name = "MnuAmTransactions"
        Me.MnuAmTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuAmTransactions.Text = "Transactions"
        '
        'MnuAmAdmissionEntry
        '
        Me.MnuAmAdmissionEntry.AccessibleDescription = "Approved By "
        Me.MnuAmAdmissionEntry.Name = "MnuAmAdmissionEntry"
        Me.MnuAmAdmissionEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmAdmissionEntry.Text = "Admission Entry"
        '
        'MnuAdmissionEntryAuthenticated
        '
        Me.MnuAdmissionEntryAuthenticated.AccessibleDescription = "ZZZZZ"
        Me.MnuAdmissionEntryAuthenticated.Name = "MnuAdmissionEntryAuthenticated"
        Me.MnuAdmissionEntryAuthenticated.Size = New System.Drawing.Size(240, 22)
        Me.MnuAdmissionEntryAuthenticated.Text = "Admission Entry [Authenticated]"
        '
        'MnuStudentFamilyIncomeEntry
        '
        Me.MnuStudentFamilyIncomeEntry.Name = "MnuStudentFamilyIncomeEntry"
        Me.MnuStudentFamilyIncomeEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuStudentFamilyIncomeEntry.Text = "Student Family Income Entry"
        '
        'MnuAmRollNoAssignEntry
        '
        Me.MnuAmRollNoAssignEntry.Name = "MnuAmRollNoAssignEntry"
        Me.MnuAmRollNoAssignEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmRollNoAssignEntry.Text = "Roll No Assign Entry"
        '
        'MnuAmStudentAttendanceEntry
        '
        Me.MnuAmStudentAttendanceEntry.Name = "MnuAmStudentAttendanceEntry"
        Me.MnuAmStudentAttendanceEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmStudentAttendanceEntry.Text = "Student Attendance Entry"
        '
        'MnuAmStudentLeaveEntry
        '
        Me.MnuAmStudentLeaveEntry.Name = "MnuAmStudentLeaveEntry"
        Me.MnuAmStudentLeaveEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmStudentLeaveEntry.Text = "Student Leave Entry"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(237, 6)
        '
        'MnuAmStudentLeftEntry
        '
        Me.MnuAmStudentLeftEntry.Name = "MnuAmStudentLeftEntry"
        Me.MnuAmStudentLeftEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmStudentLeftEntry.Text = "Student Left Entry"
        '
        'MnuAmStudentPromotionEntry
        '
        Me.MnuAmStudentPromotionEntry.Name = "MnuAmStudentPromotionEntry"
        Me.MnuAmStudentPromotionEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuAmStudentPromotionEntry.Text = "Student Promotion Entry"
        '
        'MnuDocumentIssueEntry
        '
        Me.MnuDocumentIssueEntry.Name = "MnuDocumentIssueEntry"
        Me.MnuDocumentIssueEntry.Size = New System.Drawing.Size(240, 22)
        Me.MnuDocumentIssueEntry.Text = "Document Issue Entry"
        '
        'MnuAmReports
        '
        Me.MnuAmReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAmTeacherRegister, Me.MnuAmStudentRegister, Me.MnuAmStudentLeftRegister, Me.MnuAmAdmissionRegister, Me.mnuAttendanceRegister, Me.mnuStudentCurrentList, Me.MnuAmIdentityCard})
        Me.MnuAmReports.Name = "MnuAmReports"
        Me.MnuAmReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuAmReports.Text = "Reports"
        '
        'MnuAmTeacherRegister
        '
        Me.MnuAmTeacherRegister.Name = "MnuAmTeacherRegister"
        Me.MnuAmTeacherRegister.Size = New System.Drawing.Size(188, 22)
        Me.MnuAmTeacherRegister.Tag = "ACADEMIC MAIN"
        Me.MnuAmTeacherRegister.Text = "Teacher Register"
        '
        'MnuAmStudentRegister
        '
        Me.MnuAmStudentRegister.Name = "MnuAmStudentRegister"
        Me.MnuAmStudentRegister.Size = New System.Drawing.Size(188, 22)
        Me.MnuAmStudentRegister.Tag = "ACADEMIC MAIN"
        Me.MnuAmStudentRegister.Text = "Student Register"
        '
        'MnuAmStudentLeftRegister
        '
        Me.MnuAmStudentLeftRegister.Name = "MnuAmStudentLeftRegister"
        Me.MnuAmStudentLeftRegister.Size = New System.Drawing.Size(188, 22)
        Me.MnuAmStudentLeftRegister.Tag = "ACADEMIC MAIN"
        Me.MnuAmStudentLeftRegister.Text = "Student Left Register"
        '
        'MnuAmAdmissionRegister
        '
        Me.MnuAmAdmissionRegister.Name = "MnuAmAdmissionRegister"
        Me.MnuAmAdmissionRegister.Size = New System.Drawing.Size(188, 22)
        Me.MnuAmAdmissionRegister.Tag = "ACADEMIC MAIN"
        Me.MnuAmAdmissionRegister.Text = "Admission Register"
        '
        'mnuAttendanceRegister
        '
        Me.mnuAttendanceRegister.Name = "mnuAttendanceRegister"
        Me.mnuAttendanceRegister.Size = New System.Drawing.Size(188, 22)
        Me.mnuAttendanceRegister.Tag = "Report"
        Me.mnuAttendanceRegister.Text = "Attendance Register"
        '
        'mnuStudentCurrentList
        '
        Me.mnuStudentCurrentList.Name = "mnuStudentCurrentList"
        Me.mnuStudentCurrentList.Size = New System.Drawing.Size(188, 22)
        Me.mnuStudentCurrentList.Tag = "Report"
        Me.mnuStudentCurrentList.Text = "Student Current List"
        '
        'MnuAmIdentityCard
        '
        Me.MnuAmIdentityCard.Name = "MnuAmIdentityCard"
        Me.MnuAmIdentityCard.Size = New System.Drawing.Size(188, 22)
        Me.MnuAmIdentityCard.Tag = "ACADEMIC MAIN"
        Me.MnuAmIdentityCard.Text = "Identity Card"
        '
        'MnuAmUtility
        '
        Me.MnuAmUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAmEnvironmentSettings})
        Me.MnuAmUtility.Name = "MnuAmUtility"
        Me.MnuAmUtility.Size = New System.Drawing.Size(152, 22)
        Me.MnuAmUtility.Text = "Utility"
        '
        'MnuAmEnvironmentSettings
        '
        Me.MnuAmEnvironmentSettings.Name = "MnuAmEnvironmentSettings"
        Me.MnuAmEnvironmentSettings.Size = New System.Drawing.Size(187, 22)
        Me.MnuAmEnvironmentSettings.Text = "Environment Settings"
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
        Me.Text = "Scholar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuAmMasters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmTeacherMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmTransactions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmAdmissionEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentLeaveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentAttendanceEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmRollNoAssignEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentLeftEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSASAcademicManagement As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentPromotionEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents MnuDocumentIssueEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuStudentFamilyIncomeEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAdmissionEntryAuthenticated As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmTeacherRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmStudentLeftRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmAdmissionRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClassSubjectAllotment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAttendanceRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStudentCurrentList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAmIdentityCard As System.Windows.Forms.ToolStripMenuItem

End Class
