<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScholarShipParameter
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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblApplicableFrom = New System.Windows.Forms.Label
        Me.TxtApplicableFrom = New AgControls.AgTextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblApplicableUpto = New System.Windows.Forms.Label
        Me.TxtApplicableUpto = New AgControls.AgTextBox
        Me.LblDemandDetail = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl1.Location = New System.Drawing.Point(75, 151)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(757, 243)
        Me.Pnl1.TabIndex = 3
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
        Me.Topctrl1.Size = New System.Drawing.Size(864, 41)
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
        Me.TxtSite_Code.Enabled = False
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(327, 78)
        Me.TxtSite_Code.MaxLength = 25
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(324, 21)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(312, 86)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 498
        Me.LblSite_CodeReq.Text = "�"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(205, 81)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 499
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(311, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 508
        Me.Label3.Text = "�"
        '
        'LblApplicableFrom
        '
        Me.LblApplicableFrom.AutoSize = True
        Me.LblApplicableFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblApplicableFrom.Location = New System.Drawing.Point(205, 103)
        Me.LblApplicableFrom.Name = "LblApplicableFrom"
        Me.LblApplicableFrom.Size = New System.Drawing.Size(98, 13)
        Me.LblApplicableFrom.TabIndex = 505
        Me.LblApplicableFrom.Text = "Applicable From"
        '
        'TxtApplicableFrom
        '
        Me.TxtApplicableFrom.AgMandatory = True
        Me.TxtApplicableFrom.AgMasterHelp = False
        Me.TxtApplicableFrom.AgNumberLeftPlaces = 0
        Me.TxtApplicableFrom.AgNumberNegetiveAllow = False
        Me.TxtApplicableFrom.AgNumberRightPlaces = 0
        Me.TxtApplicableFrom.AgPickFromLastValue = False
        Me.TxtApplicableFrom.AgRowFilter = ""
        Me.TxtApplicableFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtApplicableFrom.AgSelectedValue = Nothing
        Me.TxtApplicableFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtApplicableFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtApplicableFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApplicableFrom.Location = New System.Drawing.Point(327, 100)
        Me.TxtApplicableFrom.MaxLength = 10
        Me.TxtApplicableFrom.Name = "TxtApplicableFrom"
        Me.TxtApplicableFrom.Size = New System.Drawing.Size(100, 21)
        Me.TxtApplicableFrom.TabIndex = 1
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 451)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 654
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(659, 453)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 655
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 434)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(864, 4)
        Me.GroupBox2.TabIndex = 656
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblApplicableUpto
        '
        Me.LblApplicableUpto.AutoSize = True
        Me.LblApplicableUpto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblApplicableUpto.Location = New System.Drawing.Point(499, 103)
        Me.LblApplicableUpto.Name = "LblApplicableUpto"
        Me.LblApplicableUpto.Size = New System.Drawing.Size(33, 13)
        Me.LblApplicableUpto.TabIndex = 658
        Me.LblApplicableUpto.Text = "Upto"
        Me.LblApplicableUpto.Visible = False
        '
        'TxtApplicableUpto
        '
        Me.TxtApplicableUpto.AgMandatory = False
        Me.TxtApplicableUpto.AgMasterHelp = False
        Me.TxtApplicableUpto.AgNumberLeftPlaces = 0
        Me.TxtApplicableUpto.AgNumberNegetiveAllow = False
        Me.TxtApplicableUpto.AgNumberRightPlaces = 0
        Me.TxtApplicableUpto.AgPickFromLastValue = False
        Me.TxtApplicableUpto.AgRowFilter = ""
        Me.TxtApplicableUpto.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtApplicableUpto.AgSelectedValue = Nothing
        Me.TxtApplicableUpto.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtApplicableUpto.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtApplicableUpto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApplicableUpto.Location = New System.Drawing.Point(550, 100)
        Me.TxtApplicableUpto.MaxLength = 10
        Me.TxtApplicableUpto.Name = "TxtApplicableUpto"
        Me.TxtApplicableUpto.Size = New System.Drawing.Size(101, 21)
        Me.TxtApplicableUpto.TabIndex = 2
        Me.TxtApplicableUpto.Text = "TxtApplicableUpto"
        Me.TxtApplicableUpto.Visible = False
        '
        'LblDemandDetail
        '
        Me.LblDemandDetail.AutoSize = True
        Me.LblDemandDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDemandDetail.ForeColor = System.Drawing.Color.Blue
        Me.LblDemandDetail.Location = New System.Drawing.Point(72, 137)
        Me.LblDemandDetail.Name = "LblDemandDetail"
        Me.LblDemandDetail.Size = New System.Drawing.Size(113, 13)
        Me.LblDemandDetail.TabIndex = 659
        Me.LblDemandDetail.Text = "Parameter Detail :"
        '
        'FrmScholarShipParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 512)
        Me.Controls.Add(Me.LblDemandDetail)
        Me.Controls.Add(Me.LblApplicableUpto)
        Me.Controls.Add(Me.TxtApplicableUpto)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblApplicableFrom)
        Me.Controls.Add(Me.TxtApplicableFrom)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmScholarShipParameter"
        Me.Text = "Scholarship Parameter"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblApplicableFrom As System.Windows.Forms.Label
    Friend WithEvents TxtApplicableFrom As AgControls.AgTextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblApplicableUpto As System.Windows.Forms.Label
    Friend WithEvents TxtApplicableUpto As AgControls.AgTextBox
    Friend WithEvents LblDemandDetail As System.Windows.Forms.Label
End Class
