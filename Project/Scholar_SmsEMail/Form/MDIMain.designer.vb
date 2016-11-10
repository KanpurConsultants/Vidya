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
        Me.MnuCanteen = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMS = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMSEventMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEmployeeCommonSMS = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStudentCommonSMS = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStudentDueMessage = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMSSend = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMS_EnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMS_Reports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSMSLogReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEMail = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuComposeEMail = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEMail_EnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEMail_Reports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEMailLogReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCanteen})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuCanteen
        '
        Me.MnuCanteen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSMS, Me.MnuEMail})
        Me.MnuCanteen.Name = "MnuCanteen"
        Me.MnuCanteen.Size = New System.Drawing.Size(73, 20)
        Me.MnuCanteen.Text = "SMS / EMail"
        '
        'MnuSMS
        '
        Me.MnuSMS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSMSEventMaster, Me.MnuEmployeeCommonSMS, Me.MnuStudentCommonSMS, Me.MnuStudentDueMessage, Me.MnuSMSSend, Me.MnuSMS_EnvironmentSettings, Me.MnuSMS_Reports})
        Me.MnuSMS.Name = "MnuSMS"
        Me.MnuSMS.Size = New System.Drawing.Size(152, 22)
        Me.MnuSMS.Text = "SMS"
        '
        'MnuSMSEventMaster
        '
        Me.MnuSMSEventMaster.Name = "MnuSMSEventMaster"
        Me.MnuSMSEventMaster.Size = New System.Drawing.Size(201, 22)
        Me.MnuSMSEventMaster.Text = "SMS Event Master"
        '
        'MnuEmployeeCommonSMS
        '
        Me.MnuEmployeeCommonSMS.Name = "MnuEmployeeCommonSMS"
        Me.MnuEmployeeCommonSMS.Size = New System.Drawing.Size(201, 22)
        Me.MnuEmployeeCommonSMS.Text = "Employee Common  SMS"
        '
        'MnuStudentCommonSMS
        '
        Me.MnuStudentCommonSMS.Name = "MnuStudentCommonSMS"
        Me.MnuStudentCommonSMS.Size = New System.Drawing.Size(201, 22)
        Me.MnuStudentCommonSMS.Text = "Student Common  SMS"
        '
        'MnuStudentDueMessage
        '
        Me.MnuStudentDueMessage.Name = "MnuStudentDueMessage"
        Me.MnuStudentDueMessage.Size = New System.Drawing.Size(201, 22)
        Me.MnuStudentDueMessage.Text = "Student Due SMS"
        '
        'MnuSMSSend
        '
        Me.MnuSMSSend.Name = "MnuSMSSend"
        Me.MnuSMSSend.Size = New System.Drawing.Size(201, 22)
        Me.MnuSMSSend.Text = "SMS Send"
        '
        'MnuSMS_EnvironmentSettings
        '
        Me.MnuSMS_EnvironmentSettings.Name = "MnuSMS_EnvironmentSettings"
        Me.MnuSMS_EnvironmentSettings.Size = New System.Drawing.Size(201, 22)
        Me.MnuSMS_EnvironmentSettings.Text = "Environment Settings"
        '
        'MnuSMS_Reports
        '
        Me.MnuSMS_Reports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSMSLogReport})
        Me.MnuSMS_Reports.Name = "MnuSMS_Reports"
        Me.MnuSMS_Reports.Size = New System.Drawing.Size(201, 22)
        Me.MnuSMS_Reports.Text = "Reports"
        '
        'MnuSMSLogReport
        '
        Me.MnuSMSLogReport.Name = "MnuSMSLogReport"
        Me.MnuSMSLogReport.Size = New System.Drawing.Size(161, 22)
        Me.MnuSMSLogReport.Tag = "SMS"
        Me.MnuSMSLogReport.Text = "SMS Log Report"
        '
        'MnuEMail
        '
        Me.MnuEMail.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuComposeEMail, Me.MnuEMail_EnvironmentSettings, Me.MnuEMail_Reports})
        Me.MnuEMail.Name = "MnuEMail"
        Me.MnuEMail.Size = New System.Drawing.Size(152, 22)
        Me.MnuEMail.Text = "EMail"
        '
        'MnuComposeEMail
        '
        Me.MnuComposeEMail.Name = "MnuComposeEMail"
        Me.MnuComposeEMail.Size = New System.Drawing.Size(187, 22)
        Me.MnuComposeEMail.Text = "Compose EMail"
        '
        'MnuEMail_EnvironmentSettings
        '
        Me.MnuEMail_EnvironmentSettings.Name = "MnuEMail_EnvironmentSettings"
        Me.MnuEMail_EnvironmentSettings.Size = New System.Drawing.Size(187, 22)
        Me.MnuEMail_EnvironmentSettings.Text = "Environment Settings"
        '
        'MnuEMail_Reports
        '
        Me.MnuEMail_Reports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEMailLogReport})
        Me.MnuEMail_Reports.Name = "MnuEMail_Reports"
        Me.MnuEMail_Reports.Size = New System.Drawing.Size(187, 22)
        Me.MnuEMail_Reports.Text = "Reports"
        '
        'MnuEMailLogReport
        '
        Me.MnuEMailLogReport.Name = "MnuEMailLogReport"
        Me.MnuEMailLogReport.Size = New System.Drawing.Size(165, 22)
        Me.MnuEMailLogReport.Tag = "EMail"
        Me.MnuEMailLogReport.Text = "EMail Log Report"
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
        Me.Text = "SMS & EMail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuCanteen As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMSEventMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEmployeeCommonSMS As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuStudentCommonSMS As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuStudentDueMessage As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMS As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMS_Reports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMSLogReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEMail As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEMail_Reports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEMailLogReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuComposeEMail As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMSSend As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSMS_EnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEMail_EnvironmentSettings As System.Windows.Forms.ToolStripMenuItem

End Class
