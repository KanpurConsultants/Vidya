<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLateFeeParameter
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
        Me.TxtFor = New AgControls.AgTextBox
        Me.LblAcGroup_Student = New System.Windows.Forms.Label
        Me.TxtLateFeeAc = New AgControls.AgTextBox
        Me.LblDiscountAc = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 4
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
        'TxtFor
        '
        Me.TxtFor.AgAllowUserToEnableMasterHelp = False
        Me.TxtFor.AgMandatory = False
        Me.TxtFor.AgMasterHelp = False
        Me.TxtFor.AgNumberLeftPlaces = 0
        Me.TxtFor.AgNumberNegetiveAllow = False
        Me.TxtFor.AgNumberRightPlaces = 0
        Me.TxtFor.AgPickFromLastValue = False
        Me.TxtFor.AgRowFilter = ""
        Me.TxtFor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFor.AgSelectedValue = Nothing
        Me.TxtFor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFor.Location = New System.Drawing.Point(312, 77)
        Me.TxtFor.MaxLength = 10
        Me.TxtFor.Name = "TxtFor"
        Me.TxtFor.Size = New System.Drawing.Size(99, 18)
        Me.TxtFor.TabIndex = 1
        '
        'LblAcGroup_Student
        '
        Me.LblAcGroup_Student.AutoSize = True
        Me.LblAcGroup_Student.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup_Student.Location = New System.Drawing.Point(181, 81)
        Me.LblAcGroup_Student.Name = "LblAcGroup_Student"
        Me.LblAcGroup_Student.Size = New System.Drawing.Size(77, 13)
        Me.LblAcGroup_Student.TabIndex = 30
        Me.LblAcGroup_Student.Text = "Late Fee For"
        '
        'TxtLateFeeAc
        '
        Me.TxtLateFeeAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtLateFeeAc.AgMandatory = False
        Me.TxtLateFeeAc.AgMasterHelp = False
        Me.TxtLateFeeAc.AgNumberLeftPlaces = 0
        Me.TxtLateFeeAc.AgNumberNegetiveAllow = False
        Me.TxtLateFeeAc.AgNumberRightPlaces = 0
        Me.TxtLateFeeAc.AgPickFromLastValue = False
        Me.TxtLateFeeAc.AgRowFilter = ""
        Me.TxtLateFeeAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLateFeeAc.AgSelectedValue = Nothing
        Me.TxtLateFeeAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLateFeeAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLateFeeAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLateFeeAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLateFeeAc.Location = New System.Drawing.Point(312, 97)
        Me.TxtLateFeeAc.MaxLength = 10
        Me.TxtLateFeeAc.Name = "TxtLateFeeAc"
        Me.TxtLateFeeAc.Size = New System.Drawing.Size(293, 18)
        Me.TxtLateFeeAc.TabIndex = 2
        '
        'LblDiscountAc
        '
        Me.LblDiscountAc.AutoSize = True
        Me.LblDiscountAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscountAc.Location = New System.Drawing.Point(181, 101)
        Me.LblDiscountAc.Name = "LblDiscountAc"
        Me.LblDiscountAc.Size = New System.Drawing.Size(81, 13)
        Me.LblDiscountAc.TabIndex = 28
        Me.LblDiscountAc.Text = "Late Fee A/C"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(312, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(181, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(311, 145)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(170, 19)
        Me.LinkLabel1.TabIndex = 828
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LATE FEE DETAIL:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pnl1.Location = New System.Drawing.Point(312, 169)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(293, 263)
        Me.Pnl1.TabIndex = 3
        '
        'FrmLateFeeParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(872, 516)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtFor)
        Me.Controls.Add(Me.LblAcGroup_Student)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtLateFeeAc)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblDiscountAc)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLateFeeParameter"
        Me.Text = "Late Fee Parameter"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLateFeeAc As AgControls.AgTextBox
    Friend WithEvents LblDiscountAc As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtFor As AgControls.AgTextBox
    Friend WithEvents LblAcGroup_Student As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
End Class
