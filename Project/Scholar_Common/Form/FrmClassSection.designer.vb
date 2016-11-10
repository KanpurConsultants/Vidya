<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClassSection
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtClass = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSection = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 3
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
        'TxtClass
        '
        Me.TxtClass.AgAllowUserToEnableMasterHelp = False
        Me.TxtClass.AgMandatory = True
        Me.TxtClass.AgMasterHelp = False
        Me.TxtClass.AgNumberLeftPlaces = 0
        Me.TxtClass.AgNumberNegetiveAllow = False
        Me.TxtClass.AgNumberRightPlaces = 0
        Me.TxtClass.AgPickFromLastValue = False
        Me.TxtClass.AgRowFilter = ""
        Me.TxtClass.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClass.AgSelectedValue = Nothing
        Me.TxtClass.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClass.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClass.Location = New System.Drawing.Point(326, 119)
        Me.TxtClass.MaxLength = 20
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Size = New System.Drawing.Size(219, 21)
        Me.TxtClass.TabIndex = 0
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(206, 119)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(38, 13)
        Me.LblManualCode.TabIndex = 0
        Me.LblManualCode.Text = "Class"
        '
        'TxtDescription
        '
        Me.TxtDescription.AgAllowUserToEnableMasterHelp = False
        Me.TxtDescription.AgMandatory = False
        Me.TxtDescription.AgMasterHelp = False
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.Enabled = False
        Me.TxtDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(326, 163)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(219, 21)
        Me.TxtDescription.TabIndex = 2
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(206, 163)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(71, 13)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Description"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(312, 124)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 2
        Me.LblBank_NameReq.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(312, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ä"
        '
        'TxtSection
        '
        Me.TxtSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtSection.AgMandatory = True
        Me.TxtSection.AgMasterHelp = False
        Me.TxtSection.AgNumberLeftPlaces = 0
        Me.TxtSection.AgNumberNegetiveAllow = False
        Me.TxtSection.AgNumberRightPlaces = 0
        Me.TxtSection.AgPickFromLastValue = False
        Me.TxtSection.AgRowFilter = ""
        Me.TxtSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSection.AgSelectedValue = Nothing
        Me.TxtSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSection.Location = New System.Drawing.Point(326, 141)
        Me.TxtSection.MaxLength = 20
        Me.TxtSection.Name = "TxtSection"
        Me.TxtSection.Size = New System.Drawing.Size(83, 21)
        Me.TxtSection.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(206, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Section"
        '
        'FrmClassSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 266)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSection)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtClass)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmClassSection"
        Me.Text = "Class Section Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtClass As AgControls.AgTextBox
    Friend WithEvents LblManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSection As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
