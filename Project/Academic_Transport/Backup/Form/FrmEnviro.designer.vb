<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnviro
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
        Me.TpAcParameter = New System.Windows.Forms.TabPage
        Me.TxtEmployeeAcGroup = New AgControls.AgTextBox
        Me.LblEmployeeAcGroup = New System.Windows.Forms.Label
        Me.TxtMemberACGroup = New AgControls.AgTextBox
        Me.LblMemberACGroup = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.TpAcParameter.SuspendLayout()
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
        Me.GroupBox4.Location = New System.Drawing.Point(674, 462)
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
        Me.GrpUP.Location = New System.Drawing.Point(7, 462)
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 451)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 202
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TpAcParameter
        '
        Me.TpAcParameter.Controls.Add(Me.TxtEmployeeAcGroup)
        Me.TpAcParameter.Controls.Add(Me.LblEmployeeAcGroup)
        Me.TpAcParameter.Controls.Add(Me.TxtMemberACGroup)
        Me.TpAcParameter.Controls.Add(Me.LblMemberACGroup)
        Me.TpAcParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpAcParameter.Name = "TpAcParameter"
        Me.TpAcParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAcParameter.Size = New System.Drawing.Size(666, 319)
        Me.TpAcParameter.TabIndex = 0
        Me.TpAcParameter.Text = "A/c Parameter"
        Me.TpAcParameter.UseVisualStyleBackColor = True
        '
        'TxtEmployeeAcGroup
        '
        Me.TxtEmployeeAcGroup.AgMandatory = False
        Me.TxtEmployeeAcGroup.AgMasterHelp = False
        Me.TxtEmployeeAcGroup.AgNumberLeftPlaces = 0
        Me.TxtEmployeeAcGroup.AgNumberNegetiveAllow = False
        Me.TxtEmployeeAcGroup.AgNumberRightPlaces = 0
        Me.TxtEmployeeAcGroup.AgPickFromLastValue = False
        Me.TxtEmployeeAcGroup.AgRowFilter = ""
        Me.TxtEmployeeAcGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmployeeAcGroup.AgSelectedValue = Nothing
        Me.TxtEmployeeAcGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmployeeAcGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmployeeAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployeeAcGroup.Location = New System.Drawing.Point(246, 34)
        Me.TxtEmployeeAcGroup.MaxLength = 10
        Me.TxtEmployeeAcGroup.Name = "TxtEmployeeAcGroup"
        Me.TxtEmployeeAcGroup.Size = New System.Drawing.Size(341, 21)
        Me.TxtEmployeeAcGroup.TabIndex = 1
        '
        'LblEmployeeAcGroup
        '
        Me.LblEmployeeAcGroup.AutoSize = True
        Me.LblEmployeeAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeAcGroup.Location = New System.Drawing.Point(80, 38)
        Me.LblEmployeeAcGroup.Name = "LblEmployeeAcGroup"
        Me.LblEmployeeAcGroup.Size = New System.Drawing.Size(125, 13)
        Me.LblEmployeeAcGroup.TabIndex = 737
        Me.LblEmployeeAcGroup.Text = "Employee A/c Group"
        '
        'TxtMemberACGroup
        '
        Me.TxtMemberACGroup.AgMandatory = False
        Me.TxtMemberACGroup.AgMasterHelp = False
        Me.TxtMemberACGroup.AgNumberLeftPlaces = 0
        Me.TxtMemberACGroup.AgNumberNegetiveAllow = False
        Me.TxtMemberACGroup.AgNumberRightPlaces = 0
        Me.TxtMemberACGroup.AgPickFromLastValue = False
        Me.TxtMemberACGroup.AgRowFilter = ""
        Me.TxtMemberACGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberACGroup.AgSelectedValue = Nothing
        Me.TxtMemberACGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberACGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberACGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberACGroup.Location = New System.Drawing.Point(246, 11)
        Me.TxtMemberACGroup.MaxLength = 10
        Me.TxtMemberACGroup.Name = "TxtMemberACGroup"
        Me.TxtMemberACGroup.Size = New System.Drawing.Size(341, 21)
        Me.TxtMemberACGroup.TabIndex = 0
        '
        'LblMemberACGroup
        '
        Me.LblMemberACGroup.AutoSize = True
        Me.LblMemberACGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberACGroup.Location = New System.Drawing.Point(80, 15)
        Me.LblMemberACGroup.Name = "LblMemberACGroup"
        Me.LblMemberACGroup.Size = New System.Drawing.Size(115, 13)
        Me.LblMemberACGroup.TabIndex = 30
        Me.LblMemberACGroup.Text = "Member A/c Group"
        '
        'TcEnviro
        '
        Me.TcEnviro.Controls.Add(Me.TpAcParameter)
        Me.TcEnviro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcEnviro.Location = New System.Drawing.Point(99, 100)
        Me.TcEnviro.Name = "TcEnviro"
        Me.TcEnviro.SelectedIndex = 0
        Me.TcEnviro.Size = New System.Drawing.Size(674, 345)
        Me.TcEnviro.TabIndex = 1
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = True
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
        Me.TxtSite_Code.BackColor = System.Drawing.SystemColors.Control
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'FrmEnviro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 516)
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
        Me.TpAcParameter.ResumeLayout(False)
        Me.TpAcParameter.PerformLayout()
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
    Friend WithEvents TpAcParameter As System.Windows.Forms.TabPage
    Friend WithEvents TcEnviro As System.Windows.Forms.TabControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtMemberACGroup As AgControls.AgTextBox
    Friend WithEvents LblMemberACGroup As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtEmployeeAcGroup As AgControls.AgTextBox
    Friend WithEvents LblEmployeeAcGroup As System.Windows.Forms.Label
End Class
