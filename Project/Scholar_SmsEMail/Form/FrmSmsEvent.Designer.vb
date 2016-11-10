<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSmsEvent
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
        Me.LblEventReq = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtEvent = New AgControls.AgTextBox
        Me.LblEvent = New System.Windows.Forms.Label
        Me.TxtMessage = New AgControls.AgTextBox
        Me.LblMessage = New System.Windows.Forms.Label
        Me.TxtCategory = New AgControls.AgTextBox
        Me.LblCategory = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LblEventReq
        '
        Me.LblEventReq.AutoSize = True
        Me.LblEventReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblEventReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblEventReq.Location = New System.Drawing.Point(286, 105)
        Me.LblEventReq.Name = "LblEventReq"
        Me.LblEventReq.Size = New System.Drawing.Size(10, 7)
        Me.LblEventReq.TabIndex = 16
        Me.LblEventReq.Text = "Ä"
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
        'TxtEvent
        '
        Me.TxtEvent.AgMandatory = True
        Me.TxtEvent.AgMasterHelp = False
        Me.TxtEvent.AgNumberLeftPlaces = 0
        Me.TxtEvent.AgNumberNegetiveAllow = False
        Me.TxtEvent.AgNumberRightPlaces = 0
        Me.TxtEvent.AgPickFromLastValue = False
        Me.TxtEvent.AgRowFilter = ""
        Me.TxtEvent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEvent.AgSelectedValue = Nothing
        Me.TxtEvent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEvent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEvent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEvent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEvent.Location = New System.Drawing.Point(302, 99)
        Me.TxtEvent.MaxLength = 50
        Me.TxtEvent.Name = "TxtEvent"
        Me.TxtEvent.Size = New System.Drawing.Size(325, 18)
        Me.TxtEvent.TabIndex = 0
        '
        'LblEvent
        '
        Me.LblEvent.AutoSize = True
        Me.LblEvent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEvent.Location = New System.Drawing.Point(222, 101)
        Me.LblEvent.Name = "LblEvent"
        Me.LblEvent.Size = New System.Drawing.Size(37, 15)
        Me.LblEvent.TabIndex = 14
        Me.LblEvent.Text = "Event"
        '
        'TxtMessage
        '
        Me.TxtMessage.AgMandatory = False
        Me.TxtMessage.AgMasterHelp = False
        Me.TxtMessage.AgNumberLeftPlaces = 0
        Me.TxtMessage.AgNumberNegetiveAllow = False
        Me.TxtMessage.AgNumberRightPlaces = 0
        Me.TxtMessage.AgPickFromLastValue = False
        Me.TxtMessage.AgRowFilter = ""
        Me.TxtMessage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMessage.AgSelectedValue = Nothing
        Me.TxtMessage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMessage.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMessage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessage.Location = New System.Drawing.Point(302, 139)
        Me.TxtMessage.MaxLength = 255
        Me.TxtMessage.Multiline = True
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(325, 77)
        Me.TxtMessage.TabIndex = 2
        '
        'LblMessage
        '
        Me.LblMessage.AutoSize = True
        Me.LblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(222, 141)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(58, 15)
        Me.LblMessage.TabIndex = 22
        Me.LblMessage.Text = "Message"
        '
        'TxtCategory
        '
        Me.TxtCategory.AgMandatory = False
        Me.TxtCategory.AgMasterHelp = True
        Me.TxtCategory.AgNumberLeftPlaces = 0
        Me.TxtCategory.AgNumberNegetiveAllow = False
        Me.TxtCategory.AgNumberRightPlaces = 0
        Me.TxtCategory.AgPickFromLastValue = False
        Me.TxtCategory.AgRowFilter = ""
        Me.TxtCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCategory.AgSelectedValue = Nothing
        Me.TxtCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCategory.Location = New System.Drawing.Point(302, 119)
        Me.TxtCategory.MaxLength = 20
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(325, 18)
        Me.TxtCategory.TabIndex = 1
        '
        'LblCategory
        '
        Me.LblCategory.AutoSize = True
        Me.LblCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategory.Location = New System.Drawing.Point(222, 121)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(56, 15)
        Me.LblCategory.TabIndex = 24
        Me.LblCategory.Text = "Category"
        '
        'FrmSmsEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 266)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.LblCategory)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.LblEventReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtEvent)
        Me.Controls.Add(Me.LblEvent)
        Me.KeyPreview = True
        Me.Name = "FrmSmsEvent"
        Me.Text = "SMS Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblEventReq As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtEvent As AgControls.AgTextBox
    Friend WithEvents LblEvent As System.Windows.Forms.Label
    Friend WithEvents TxtMessage As AgControls.AgTextBox
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents TxtCategory As AgControls.AgTextBox
    Friend WithEvents LblCategory As System.Windows.Forms.Label
End Class
