<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStreamYearSemesterFee
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
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtCopyFrom = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtTotalFee = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 6
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
        'TxtDescription
        '
        Me.TxtDescription.AgAllowUserToEnableMasterHelp = False
        Me.TxtDescription.AgMandatory = True
        Me.TxtDescription.AgMasterHelp = True
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(359, 73)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.ForeColor = System.Drawing.Color.Black
        Me.LblDescription.Location = New System.Drawing.Point(216, 76)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(78, 15)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Class-Sction"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(343, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "�"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pnl1.Location = New System.Drawing.Point(60, 176)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(747, 312)
        Me.Pnl1.TabIndex = 3
        '
        'TxtCopyFrom
        '
        Me.TxtCopyFrom.AgAllowUserToEnableMasterHelp = False
        Me.TxtCopyFrom.AgMandatory = False
        Me.TxtCopyFrom.AgMasterHelp = False
        Me.TxtCopyFrom.AgNumberLeftPlaces = 0
        Me.TxtCopyFrom.AgNumberNegetiveAllow = False
        Me.TxtCopyFrom.AgNumberRightPlaces = 0
        Me.TxtCopyFrom.AgPickFromLastValue = False
        Me.TxtCopyFrom.AgRowFilter = ""
        Me.TxtCopyFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCopyFrom.AgSelectedValue = Nothing
        Me.TxtCopyFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCopyFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCopyFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCopyFrom.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCopyFrom.Location = New System.Drawing.Point(359, 94)
        Me.TxtCopyFrom.MaxLength = 50
        Me.TxtCopyFrom.Name = "TxtCopyFrom"
        Me.TxtCopyFrom.Size = New System.Drawing.Size(325, 18)
        Me.TxtCopyFrom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(216, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Copy From"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(60, 154)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(747, 22)
        Me.Panel1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(297, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Fee Detail"
        '
        'TxtTotalFee
        '
        Me.TxtTotalFee.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalFee.AgMandatory = False
        Me.TxtTotalFee.AgMasterHelp = False
        Me.TxtTotalFee.AgNumberLeftPlaces = 8
        Me.TxtTotalFee.AgNumberNegetiveAllow = False
        Me.TxtTotalFee.AgNumberRightPlaces = 2
        Me.TxtTotalFee.AgPickFromLastValue = False
        Me.TxtTotalFee.AgRowFilter = ""
        Me.TxtTotalFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalFee.AgSelectedValue = Nothing
        Me.TxtTotalFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalFee.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalFee.BackColor = System.Drawing.Color.White
        Me.TxtTotalFee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalFee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalFee.Location = New System.Drawing.Point(581, 494)
        Me.TxtTotalFee.MaxLength = 50
        Me.TxtTotalFee.Name = "TxtTotalFee"
        Me.TxtTotalFee.ReadOnly = True
        Me.TxtTotalFee.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalFee.TabIndex = 5
        Me.TxtTotalFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(516, 496)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total &Fee"
        '
        'FrmStreamYearSemesterFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(872, 566)
        Me.Controls.Add(Me.TxtTotalFee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtCopyFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmStreamYearSemesterFee"
        Me.Text = "Class Fee Allotment"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtCopyFrom As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalFee As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
