<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRollNoAssign
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.BtnFillStudent = New System.Windows.Forms.Button
        Me.LblTotalStudent = New System.Windows.Forms.Label
        Me.TxtTotalStudent = New AgControls.AgTextBox
        Me.LblSessionProgrammeReq = New System.Windows.Forms.Label
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(152, 124)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 28)
        Me.Panel1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Cornsilk
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(591, 27)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Student List"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(152, 152)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(591, 432)
        Me.Pnl1.TabIndex = 3
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(352, 61)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 511
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(182, 57)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 512
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(365, 55)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(749, 124)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(100, 27)
        Me.BtnFillStudent.TabIndex = 2
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'LblTotalStudent
        '
        Me.LblTotalStudent.AutoSize = True
        Me.LblTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalStudent.Location = New System.Drawing.Point(443, 593)
        Me.LblTotalStudent.Name = "LblTotalStudent"
        Me.LblTotalStudent.Size = New System.Drawing.Size(196, 13)
        Me.LblTotalStudent.TabIndex = 516
        Me.LblTotalStudent.Text = "Total Student (Roll No. Assigned)"
        '
        'TxtTotalStudent
        '
        Me.TxtTotalStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalStudent.AgMandatory = False
        Me.TxtTotalStudent.AgMasterHelp = False
        Me.TxtTotalStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalStudent.AgNumberRightPlaces = 0
        Me.TxtTotalStudent.AgPickFromLastValue = False
        Me.TxtTotalStudent.AgRowFilter = ""
        Me.TxtTotalStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalStudent.AgSelectedValue = Nothing
        Me.TxtTotalStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalStudent.Location = New System.Drawing.Point(644, 589)
        Me.TxtTotalStudent.MaxLength = 255
        Me.TxtTotalStudent.Name = "TxtTotalStudent"
        Me.TxtTotalStudent.ReadOnly = True
        Me.TxtTotalStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalStudent.TabIndex = 517
        Me.TxtTotalStudent.Text = "AgTextBox1"
        Me.TxtTotalStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(352, 81)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeReq.TabIndex = 520
        Me.LblSessionProgrammeReq.Text = "Ä"
        '
        'TxtClassSection
        '
        Me.TxtClassSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSection.AgMandatory = True
        Me.TxtClassSection.AgMasterHelp = False
        Me.TxtClassSection.AgNumberLeftPlaces = 0
        Me.TxtClassSection.AgNumberNegetiveAllow = False
        Me.TxtClassSection.AgNumberRightPlaces = 0
        Me.TxtClassSection.AgPickFromLastValue = False
        Me.TxtClassSection.AgRowFilter = ""
        Me.TxtClassSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSection.AgSelectedValue = Nothing
        Me.TxtClassSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClassSection.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(365, 75)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(325, 18)
        Me.TxtClassSection.TabIndex = 1
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(182, 77)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(85, 15)
        Me.LblSessionProgramme.TabIndex = 519
        Me.LblSessionProgramme.Text = "Class-Section"
        '
        'FrmRollNoAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.LblSessionProgrammeReq)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.TxtTotalStudent)
        Me.Controls.Add(Me.LblTotalStudent)
        Me.Controls.Add(Me.BtnFillStudent)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRollNoAssign"
        Me.Text = "Roll No. Assign Entry"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel

    Private Sub FrmClassSectionSemesterAdmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents BtnFillStudent As System.Windows.Forms.Button
    Friend WithEvents LblTotalStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalStudent As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
End Class
