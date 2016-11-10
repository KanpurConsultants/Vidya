<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEMailEnviro
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.          [Ag]
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TpParameter = New System.Windows.Forms.TabPage
        Me.TxtEmailPassword = New AgControls.AgTextBox
        Me.LblEmailPassword = New System.Windows.Forms.Label
        Me.TxtSmtpHost = New AgControls.AgTextBox
        Me.LblSmtpHost = New System.Windows.Forms.Label
        Me.TxtSmtpPort = New AgControls.AgTextBox
        Me.LblSmtpPort = New System.Windows.Forms.Label
        Me.TxtEmailAddress = New AgControls.AgTextBox
        Me.LblEmailAddress = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtEnableSsl = New AgControls.AgTextBox
        Me.LblEnableSsl = New System.Windows.Forms.Label
        Me.LblSmtpHostReq = New System.Windows.Forms.Label
        Me.LblSmtpPortReq = New System.Windows.Forms.Label
        Me.LblEnableSslReq = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.TpParameter.SuspendLayout()
        Me.TcEnviro.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(872, 41)
        Me.Topctrl1.TabIndex = 2
        Me.Topctrl1.tAdd = True
        Me.Topctrl1.tCancel = True
        Me.Topctrl1.tDel = True
        Me.Topctrl1.tDiscard = False
        Me.Topctrl1.tEdit = True
        Me.Topctrl1.tExit = True
        Me.Topctrl1.tFind = True
        Me.Topctrl1.tFirst = True
        Me.Topctrl1.tLast = True
        Me.Topctrl1.tNext = True
        Me.Topctrl1.tPrev = True
        Me.Topctrl1.tPrn = True
        Me.Topctrl1.tRef = True
        Me.Topctrl1.tSave = False
        Me.Topctrl1.tSite = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 409)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 201
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BackColor = System.Drawing.Color.White
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(7, 409)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 200
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BackColor = System.Drawing.Color.White
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 398)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 202
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TpParameter
        '
        Me.TpParameter.BackColor = System.Drawing.Color.LightGray
        Me.TpParameter.Controls.Add(Me.LblEnableSslReq)
        Me.TpParameter.Controls.Add(Me.LblSmtpPortReq)
        Me.TpParameter.Controls.Add(Me.LblSmtpHostReq)
        Me.TpParameter.Controls.Add(Me.TxtEnableSsl)
        Me.TpParameter.Controls.Add(Me.LblEnableSsl)
        Me.TpParameter.Controls.Add(Me.TxtEmailPassword)
        Me.TpParameter.Controls.Add(Me.LblEmailPassword)
        Me.TpParameter.Controls.Add(Me.TxtSmtpHost)
        Me.TpParameter.Controls.Add(Me.LblSmtpHost)
        Me.TpParameter.Controls.Add(Me.TxtSmtpPort)
        Me.TpParameter.Controls.Add(Me.LblSmtpPort)
        Me.TpParameter.Controls.Add(Me.TxtEmailAddress)
        Me.TpParameter.Controls.Add(Me.LblEmailAddress)
        Me.TpParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpParameter.Name = "TpParameter"
        Me.TpParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpParameter.Size = New System.Drawing.Size(666, 232)
        Me.TpParameter.TabIndex = 0
        Me.TpParameter.Text = "Parameter"
        '
        'TxtEmailPassword
        '
        Me.TxtEmailPassword.AgMandatory = False
        Me.TxtEmailPassword.AgMasterHelp = False
        Me.TxtEmailPassword.AgNumberLeftPlaces = 0
        Me.TxtEmailPassword.AgNumberNegetiveAllow = False
        Me.TxtEmailPassword.AgNumberRightPlaces = 0
        Me.TxtEmailPassword.AgPickFromLastValue = False
        Me.TxtEmailPassword.AgRowFilter = ""
        Me.TxtEmailPassword.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmailPassword.AgSelectedValue = Nothing
        Me.TxtEmailPassword.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmailPassword.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmailPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmailPassword.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmailPassword.Location = New System.Drawing.Point(260, 108)
        Me.TxtEmailPassword.MaxLength = 100
        Me.TxtEmailPassword.Name = "TxtEmailPassword"
        Me.TxtEmailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtEmailPassword.Size = New System.Drawing.Size(341, 18)
        Me.TxtEmailPassword.TabIndex = 4
        '
        'LblEmailPassword
        '
        Me.LblEmailPassword.AutoSize = True
        Me.LblEmailPassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailPassword.Location = New System.Drawing.Point(67, 112)
        Me.LblEmailPassword.Name = "LblEmailPassword"
        Me.LblEmailPassword.Size = New System.Drawing.Size(98, 15)
        Me.LblEmailPassword.TabIndex = 527
        Me.LblEmailPassword.Text = "Email Password"
        '
        'TxtSmtpHost
        '
        Me.TxtSmtpHost.AgMandatory = True
        Me.TxtSmtpHost.AgMasterHelp = False
        Me.TxtSmtpHost.AgNumberLeftPlaces = 0
        Me.TxtSmtpHost.AgNumberNegetiveAllow = False
        Me.TxtSmtpHost.AgNumberRightPlaces = 0
        Me.TxtSmtpHost.AgPickFromLastValue = False
        Me.TxtSmtpHost.AgRowFilter = ""
        Me.TxtSmtpHost.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSmtpHost.AgSelectedValue = Nothing
        Me.TxtSmtpHost.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSmtpHost.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSmtpHost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSmtpHost.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSmtpHost.Location = New System.Drawing.Point(260, 48)
        Me.TxtSmtpHost.MaxLength = 255
        Me.TxtSmtpHost.Name = "TxtSmtpHost"
        Me.TxtSmtpHost.Size = New System.Drawing.Size(341, 18)
        Me.TxtSmtpHost.TabIndex = 0
        '
        'LblSmtpHost
        '
        Me.LblSmtpHost.AutoSize = True
        Me.LblSmtpHost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSmtpHost.Location = New System.Drawing.Point(67, 50)
        Me.LblSmtpHost.Name = "LblSmtpHost"
        Me.LblSmtpHost.Size = New System.Drawing.Size(68, 15)
        Me.LblSmtpHost.TabIndex = 523
        Me.LblSmtpHost.Text = "SMTP Host"
        '
        'TxtSmtpPort
        '
        Me.TxtSmtpPort.AgMandatory = True
        Me.TxtSmtpPort.AgMasterHelp = False
        Me.TxtSmtpPort.AgNumberLeftPlaces = 3
        Me.TxtSmtpPort.AgNumberNegetiveAllow = False
        Me.TxtSmtpPort.AgNumberRightPlaces = 0
        Me.TxtSmtpPort.AgPickFromLastValue = False
        Me.TxtSmtpPort.AgRowFilter = ""
        Me.TxtSmtpPort.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSmtpPort.AgSelectedValue = Nothing
        Me.TxtSmtpPort.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSmtpPort.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSmtpPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSmtpPort.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSmtpPort.Location = New System.Drawing.Point(260, 68)
        Me.TxtSmtpPort.MaxLength = 10
        Me.TxtSmtpPort.Name = "TxtSmtpPort"
        Me.TxtSmtpPort.Size = New System.Drawing.Size(92, 18)
        Me.TxtSmtpPort.TabIndex = 1
        '
        'LblSmtpPort
        '
        Me.LblSmtpPort.AutoSize = True
        Me.LblSmtpPort.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSmtpPort.Location = New System.Drawing.Point(67, 70)
        Me.LblSmtpPort.Name = "LblSmtpPort"
        Me.LblSmtpPort.Size = New System.Drawing.Size(64, 15)
        Me.LblSmtpPort.TabIndex = 522
        Me.LblSmtpPort.Text = "SMTP Port"
        '
        'TxtEmailAddress
        '
        Me.TxtEmailAddress.AgMandatory = False
        Me.TxtEmailAddress.AgMasterHelp = False
        Me.TxtEmailAddress.AgNumberLeftPlaces = 0
        Me.TxtEmailAddress.AgNumberNegetiveAllow = False
        Me.TxtEmailAddress.AgNumberRightPlaces = 0
        Me.TxtEmailAddress.AgPickFromLastValue = False
        Me.TxtEmailAddress.AgRowFilter = ""
        Me.TxtEmailAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmailAddress.AgSelectedValue = Nothing
        Me.TxtEmailAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmailAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmailAddress.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmailAddress.Location = New System.Drawing.Point(260, 88)
        Me.TxtEmailAddress.MaxLength = 255
        Me.TxtEmailAddress.Name = "TxtEmailAddress"
        Me.TxtEmailAddress.Size = New System.Drawing.Size(341, 18)
        Me.TxtEmailAddress.TabIndex = 3
        '
        'LblEmailAddress
        '
        Me.LblEmailAddress.AutoSize = True
        Me.LblEmailAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailAddress.Location = New System.Drawing.Point(67, 92)
        Me.LblEmailAddress.Name = "LblEmailAddress"
        Me.LblEmailAddress.Size = New System.Drawing.Size(88, 15)
        Me.LblEmailAddress.TabIndex = 521
        Me.LblEmailAddress.Text = "Email Address"
        '
        'TcEnviro
        '
        Me.TcEnviro.Controls.Add(Me.TpParameter)
        Me.TcEnviro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcEnviro.Location = New System.Drawing.Point(99, 100)
        Me.TcEnviro.Name = "TcEnviro"
        Me.TcEnviro.SelectedIndex = 0
        Me.TcEnviro.Size = New System.Drawing.Size(674, 258)
        Me.TcEnviro.TabIndex = 1
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = False
        Me.TxtSite_Code.AgMasterHelp = False
        Me.TxtSite_Code.AgNumberLeftPlaces = 0
        Me.TxtSite_Code.AgNumberNegetiveAllow = False
        Me.TxtSite_Code.AgNumberRightPlaces = 0
        Me.TxtSite_Code.AgPickFromLastValue = False
        Me.TxtSite_Code.AgRowFilter = ""
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtEnableSsl
        '
        Me.TxtEnableSsl.AgMandatory = True
        Me.TxtEnableSsl.AgMasterHelp = False
        Me.TxtEnableSsl.AgNumberLeftPlaces = 0
        Me.TxtEnableSsl.AgNumberNegetiveAllow = False
        Me.TxtEnableSsl.AgNumberRightPlaces = 0
        Me.TxtEnableSsl.AgPickFromLastValue = False
        Me.TxtEnableSsl.AgRowFilter = ""
        Me.TxtEnableSsl.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEnableSsl.AgSelectedValue = Nothing
        Me.TxtEnableSsl.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEnableSsl.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtEnableSsl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEnableSsl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEnableSsl.Location = New System.Drawing.Point(509, 68)
        Me.TxtEnableSsl.MaxLength = 10
        Me.TxtEnableSsl.Name = "TxtEnableSsl"
        Me.TxtEnableSsl.Size = New System.Drawing.Size(92, 18)
        Me.TxtEnableSsl.TabIndex = 2
        '
        'LblEnableSsl
        '
        Me.LblEnableSsl.AutoSize = True
        Me.LblEnableSsl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEnableSsl.Location = New System.Drawing.Point(410, 72)
        Me.LblEnableSsl.Name = "LblEnableSsl"
        Me.LblEnableSsl.Size = New System.Drawing.Size(72, 15)
        Me.LblEnableSsl.TabIndex = 529
        Me.LblEnableSsl.Text = "Enable SSL"
        '
        'LblSmtpHostReq
        '
        Me.LblSmtpHostReq.AutoSize = True
        Me.LblSmtpHostReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSmtpHostReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSmtpHostReq.Location = New System.Drawing.Point(244, 54)
        Me.LblSmtpHostReq.Name = "LblSmtpHostReq"
        Me.LblSmtpHostReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSmtpHostReq.TabIndex = 530
        Me.LblSmtpHostReq.Text = "Ä"
        '
        'LblSmtpPortReq
        '
        Me.LblSmtpPortReq.AutoSize = True
        Me.LblSmtpPortReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSmtpPortReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSmtpPortReq.Location = New System.Drawing.Point(244, 74)
        Me.LblSmtpPortReq.Name = "LblSmtpPortReq"
        Me.LblSmtpPortReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSmtpPortReq.TabIndex = 531
        Me.LblSmtpPortReq.Text = "Ä"
        '
        'LblEnableSslReq
        '
        Me.LblEnableSslReq.AutoSize = True
        Me.LblEnableSslReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblEnableSslReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblEnableSslReq.Location = New System.Drawing.Point(493, 76)
        Me.LblEnableSslReq.Name = "LblEnableSslReq"
        Me.LblEnableSslReq.Size = New System.Drawing.Size(10, 7)
        Me.LblEnableSslReq.TabIndex = 532
        Me.LblEnableSslReq.Text = "Ä"
        '
        'FrmEnviro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 463)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TcEnviro)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEnviro"
        Me.Text = "Enviro Settings"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.TpParameter.ResumeLayout(False)
        Me.TpParameter.PerformLayout()
        Me.TcEnviro.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TpParameter As System.Windows.Forms.TabPage
    Friend WithEvents TcEnviro As System.Windows.Forms.TabControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtEmailPassword As AgControls.AgTextBox
    Friend WithEvents LblEmailPassword As System.Windows.Forms.Label
    Friend WithEvents TxtSmtpHost As AgControls.AgTextBox
    Friend WithEvents LblSmtpHost As System.Windows.Forms.Label
    Friend WithEvents TxtSmtpPort As AgControls.AgTextBox
    Friend WithEvents LblSmtpPort As System.Windows.Forms.Label
    Friend WithEvents TxtEmailAddress As AgControls.AgTextBox
    Friend WithEvents LblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents TxtEnableSsl As AgControls.AgTextBox
    Friend WithEvents LblEnableSsl As System.Windows.Forms.Label
    Friend WithEvents LblEnableSslReq As System.Windows.Forms.Label
    Friend WithEvents LblSmtpPortReq As System.Windows.Forms.Label
    Friend WithEvents LblSmtpHostReq As System.Windows.Forms.Label
End Class
