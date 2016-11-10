<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentPromotion
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
        Me.BtnFillStudent = New System.Windows.Forms.Button
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblTotalStudent = New System.Windows.Forms.Label
        Me.TxtTotalStudent = New AgControls.AgTextBox
        Me.LblSessionProgrammeReq = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.LblSessionProgrammeStreamReq = New System.Windows.Forms.Label
        Me.TxtSessionProgrammeStream = New AgControls.AgTextBox
        Me.LblSessionProgrammeStream = New System.Windows.Forms.Label
        Me.LblFromStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.TxtFromClass = New AgControls.AgTextBox
        Me.LblFromStreamYearSemester = New System.Windows.Forms.Label
        Me.LblSelectAllReq = New System.Windows.Forms.Label
        Me.LblSelectAll = New System.Windows.Forms.Label
        Me.TxtSelectAll = New AgControls.AgTextBox
        Me.TxtPromotionDate = New AgControls.AgTextBox
        Me.LblPromotionDate = New System.Windows.Forms.Label
        Me.LblPromotionDateReq = New System.Windows.Forms.Label
        Me.LblToStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.TxtToClass = New AgControls.AgTextBox
        Me.LblToStreamYearSemester = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(763, 107)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(100, 27)
        Me.BtnFillStudent.TabIndex = 5
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(149, 134)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(596, 415)
        Me.Pnl1.TabIndex = 6
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(137, 32)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 511
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(33, 28)
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
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(149, 26)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblTotalStudent
        '
        Me.LblTotalStudent.AutoSize = True
        Me.LblTotalStudent.BackColor = System.Drawing.Color.Cornsilk
        Me.LblTotalStudent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalStudent.Location = New System.Drawing.Point(339, 7)
        Me.LblTotalStudent.Name = "LblTotalStudent"
        Me.LblTotalStudent.Size = New System.Drawing.Size(136, 15)
        Me.LblTotalStudent.TabIndex = 516
        Me.LblTotalStudent.Text = "Total Promoted Student"
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
        Me.TxtTotalStudent.BackColor = System.Drawing.Color.White
        Me.TxtTotalStudent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalStudent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalStudent.Location = New System.Drawing.Point(487, 5)
        Me.TxtTotalStudent.MaxLength = 255
        Me.TxtTotalStudent.Name = "TxtTotalStudent"
        Me.TxtTotalStudent.ReadOnly = True
        Me.TxtTotalStudent.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalStudent.TabIndex = 8
        Me.TxtTotalStudent.Text = "AgTextBox1"
        Me.TxtTotalStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(851, 12)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeReq.TabIndex = 520
        Me.LblSessionProgrammeReq.Text = "Ä"
        Me.LblSessionProgrammeReq.Visible = False
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgAllowUserToEnableMasterHelp = False
        Me.TxtSessionProgramme.AgMandatory = False
        Me.TxtSessionProgramme.AgMasterHelp = False
        Me.TxtSessionProgramme.AgNumberLeftPlaces = 0
        Me.TxtSessionProgramme.AgNumberNegetiveAllow = False
        Me.TxtSessionProgramme.AgNumberRightPlaces = 0
        Me.TxtSessionProgramme.AgPickFromLastValue = False
        Me.TxtSessionProgramme.AgRowFilter = ""
        Me.TxtSessionProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSessionProgramme.AgSelectedValue = Nothing
        Me.TxtSessionProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgramme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSessionProgramme.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(788, 26)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(41, 18)
        Me.TxtSessionProgramme.TabIndex = 1
        Me.TxtSessionProgramme.Visible = False
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(728, 9)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(122, 15)
        Me.LblSessionProgramme.TabIndex = 519
        Me.LblSessionProgramme.Text = "Session/Programme"
        Me.LblSessionProgramme.Visible = False
        '
        'LblSessionProgrammeStreamReq
        '
        Me.LblSessionProgrammeStreamReq.AutoSize = True
        Me.LblSessionProgrammeStreamReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeStreamReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeStreamReq.Location = New System.Drawing.Point(851, 34)
        Me.LblSessionProgrammeStreamReq.Name = "LblSessionProgrammeStreamReq"
        Me.LblSessionProgrammeStreamReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeStreamReq.TabIndex = 523
        Me.LblSessionProgrammeStreamReq.Text = "Ä"
        Me.LblSessionProgrammeStreamReq.Visible = False
        '
        'TxtSessionProgrammeStream
        '
        Me.TxtSessionProgrammeStream.AgAllowUserToEnableMasterHelp = False
        Me.TxtSessionProgrammeStream.AgMandatory = False
        Me.TxtSessionProgrammeStream.AgMasterHelp = False
        Me.TxtSessionProgrammeStream.AgNumberLeftPlaces = 0
        Me.TxtSessionProgrammeStream.AgNumberNegetiveAllow = False
        Me.TxtSessionProgrammeStream.AgNumberRightPlaces = 0
        Me.TxtSessionProgrammeStream.AgPickFromLastValue = False
        Me.TxtSessionProgrammeStream.AgRowFilter = ""
        Me.TxtSessionProgrammeStream.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSessionProgrammeStream.AgSelectedValue = Nothing
        Me.TxtSessionProgrammeStream.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgrammeStream.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgrammeStream.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSessionProgrammeStream.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgrammeStream.Location = New System.Drawing.Point(788, 56)
        Me.TxtSessionProgrammeStream.MaxLength = 50
        Me.TxtSessionProgrammeStream.Name = "TxtSessionProgrammeStream"
        Me.TxtSessionProgrammeStream.Size = New System.Drawing.Size(41, 18)
        Me.TxtSessionProgrammeStream.TabIndex = 2
        Me.TxtSessionProgrammeStream.Visible = False
        '
        'LblSessionProgrammeStream
        '
        Me.LblSessionProgrammeStream.AutoSize = True
        Me.LblSessionProgrammeStream.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgrammeStream.Location = New System.Drawing.Point(728, 28)
        Me.LblSessionProgrammeStream.Name = "LblSessionProgrammeStream"
        Me.LblSessionProgrammeStream.Size = New System.Drawing.Size(47, 15)
        Me.LblSessionProgrammeStream.TabIndex = 522
        Me.LblSessionProgrammeStream.Text = "Stream"
        Me.LblSessionProgrammeStream.Visible = False
        '
        'LblFromStreamYearSemesterReq
        '
        Me.LblFromStreamYearSemesterReq.AutoSize = True
        Me.LblFromStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromStreamYearSemesterReq.Location = New System.Drawing.Point(137, 53)
        Me.LblFromStreamYearSemesterReq.Name = "LblFromStreamYearSemesterReq"
        Me.LblFromStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromStreamYearSemesterReq.TabIndex = 526
        Me.LblFromStreamYearSemesterReq.Text = "Ä"
        '
        'TxtFromClass
        '
        Me.TxtFromClass.AgAllowUserToEnableMasterHelp = False
        Me.TxtFromClass.AgMandatory = True
        Me.TxtFromClass.AgMasterHelp = False
        Me.TxtFromClass.AgNumberLeftPlaces = 0
        Me.TxtFromClass.AgNumberNegetiveAllow = False
        Me.TxtFromClass.AgNumberRightPlaces = 0
        Me.TxtFromClass.AgPickFromLastValue = False
        Me.TxtFromClass.AgRowFilter = ""
        Me.TxtFromClass.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtFromClass.AgSelectedValue = Nothing
        Me.TxtFromClass.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromClass.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFromClass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFromClass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromClass.Location = New System.Drawing.Point(149, 47)
        Me.TxtFromClass.MaxLength = 50
        Me.TxtFromClass.Name = "TxtFromClass"
        Me.TxtFromClass.Size = New System.Drawing.Size(300, 18)
        Me.TxtFromClass.TabIndex = 1
        '
        'LblFromStreamYearSemester
        '
        Me.LblFromStreamYearSemester.AutoSize = True
        Me.LblFromStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromStreamYearSemester.Location = New System.Drawing.Point(33, 49)
        Me.LblFromStreamYearSemester.Name = "LblFromStreamYearSemester"
        Me.LblFromStreamYearSemester.Size = New System.Drawing.Size(72, 15)
        Me.LblFromStreamYearSemester.TabIndex = 525
        Me.LblFromStreamYearSemester.Text = "From Class"
        '
        'LblSelectAllReq
        '
        Me.LblSelectAllReq.AutoSize = True
        Me.LblSelectAllReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSelectAllReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectAllReq.Location = New System.Drawing.Point(610, 53)
        Me.LblSelectAllReq.Name = "LblSelectAllReq"
        Me.LblSelectAllReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSelectAllReq.TabIndex = 532
        Me.LblSelectAllReq.Text = "Ä"
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(512, 49)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(57, 15)
        Me.LblSelectAll.TabIndex = 531
        Me.LblSelectAll.Text = "Select All"
        '
        'TxtSelectAll
        '
        Me.TxtSelectAll.AgAllowUserToEnableMasterHelp = False
        Me.TxtSelectAll.AgMandatory = True
        Me.TxtSelectAll.AgMasterHelp = False
        Me.TxtSelectAll.AgNumberLeftPlaces = 0
        Me.TxtSelectAll.AgNumberNegetiveAllow = False
        Me.TxtSelectAll.AgNumberRightPlaces = 0
        Me.TxtSelectAll.AgPickFromLastValue = False
        Me.TxtSelectAll.AgRowFilter = ""
        Me.TxtSelectAll.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectAll.AgSelectedValue = Nothing
        Me.TxtSelectAll.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectAll.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtSelectAll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSelectAll.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectAll.Location = New System.Drawing.Point(622, 47)
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(100, 18)
        Me.TxtSelectAll.TabIndex = 4
        '
        'TxtPromotionDate
        '
        Me.TxtPromotionDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPromotionDate.AgMandatory = True
        Me.TxtPromotionDate.AgMasterHelp = False
        Me.TxtPromotionDate.AgNumberLeftPlaces = 0
        Me.TxtPromotionDate.AgNumberNegetiveAllow = False
        Me.TxtPromotionDate.AgNumberRightPlaces = 0
        Me.TxtPromotionDate.AgPickFromLastValue = False
        Me.TxtPromotionDate.AgRowFilter = ""
        Me.TxtPromotionDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPromotionDate.AgSelectedValue = Nothing
        Me.TxtPromotionDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPromotionDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPromotionDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPromotionDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPromotionDate.Location = New System.Drawing.Point(622, 26)
        Me.TxtPromotionDate.Name = "TxtPromotionDate"
        Me.TxtPromotionDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtPromotionDate.TabIndex = 3
        '
        'LblPromotionDate
        '
        Me.LblPromotionDate.AutoSize = True
        Me.LblPromotionDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromotionDate.Location = New System.Drawing.Point(512, 28)
        Me.LblPromotionDate.Name = "LblPromotionDate"
        Me.LblPromotionDate.Size = New System.Drawing.Size(93, 15)
        Me.LblPromotionDate.TabIndex = 528
        Me.LblPromotionDate.Text = "Promotion Date"
        '
        'LblPromotionDateReq
        '
        Me.LblPromotionDateReq.AutoSize = True
        Me.LblPromotionDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPromotionDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPromotionDateReq.Location = New System.Drawing.Point(610, 32)
        Me.LblPromotionDateReq.Name = "LblPromotionDateReq"
        Me.LblPromotionDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPromotionDateReq.TabIndex = 533
        Me.LblPromotionDateReq.Text = "Ä"
        '
        'LblToStreamYearSemesterReq
        '
        Me.LblToStreamYearSemesterReq.AutoSize = True
        Me.LblToStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblToStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblToStreamYearSemesterReq.Location = New System.Drawing.Point(137, 74)
        Me.LblToStreamYearSemesterReq.Name = "LblToStreamYearSemesterReq"
        Me.LblToStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblToStreamYearSemesterReq.TabIndex = 536
        Me.LblToStreamYearSemesterReq.Text = "Ä"
        '
        'TxtToClass
        '
        Me.TxtToClass.AgAllowUserToEnableMasterHelp = False
        Me.TxtToClass.AgMandatory = True
        Me.TxtToClass.AgMasterHelp = False
        Me.TxtToClass.AgNumberLeftPlaces = 0
        Me.TxtToClass.AgNumberNegetiveAllow = False
        Me.TxtToClass.AgNumberRightPlaces = 0
        Me.TxtToClass.AgPickFromLastValue = False
        Me.TxtToClass.AgRowFilter = ""
        Me.TxtToClass.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtToClass.AgSelectedValue = Nothing
        Me.TxtToClass.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToClass.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtToClass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToClass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToClass.Location = New System.Drawing.Point(149, 68)
        Me.TxtToClass.MaxLength = 50
        Me.TxtToClass.Name = "TxtToClass"
        Me.TxtToClass.Size = New System.Drawing.Size(300, 18)
        Me.TxtToClass.TabIndex = 2
        '
        'LblToStreamYearSemester
        '
        Me.LblToStreamYearSemester.AutoSize = True
        Me.LblToStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToStreamYearSemester.Location = New System.Drawing.Point(33, 70)
        Me.LblToStreamYearSemester.Name = "LblToStreamYearSemester"
        Me.LblToStreamYearSemester.Size = New System.Drawing.Size(57, 15)
        Me.LblToStreamYearSemester.TabIndex = 535
        Me.LblToStreamYearSemester.Text = "To Class"
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(16, 245)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(51, 41)
        Me.Topctrl1.TabIndex = 9
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
        Me.Topctrl1.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(788, 583)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 8
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(707, 583)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Cornsilk
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(596, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Student List"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(149, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 28)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtTotalStudent)
        Me.Panel2.Controls.Add(Me.LblTotalStudent)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(149, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 28)
        Me.Panel2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Cornsilk
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(596, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmStudentPromotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblSessionProgrammeStreamReq)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.TxtSessionProgrammeStream)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LblSessionProgrammeReq)
        Me.Controls.Add(Me.LblToStreamYearSemesterReq)
        Me.Controls.Add(Me.LblSessionProgrammeStream)
        Me.Controls.Add(Me.TxtToClass)
        Me.Controls.Add(Me.LblToStreamYearSemester)
        Me.Controls.Add(Me.BtnFillStudent)
        Me.Controls.Add(Me.LblPromotionDateReq)
        Me.Controls.Add(Me.LblSelectAllReq)
        Me.Controls.Add(Me.LblSelectAll)
        Me.Controls.Add(Me.TxtSelectAll)
        Me.Controls.Add(Me.LblPromotionDate)
        Me.Controls.Add(Me.TxtPromotionDate)
        Me.Controls.Add(Me.LblFromStreamYearSemesterReq)
        Me.Controls.Add(Me.TxtFromClass)
        Me.Controls.Add(Me.LblFromStreamYearSemester)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmStudentPromotion"
        Me.Text = "Student Promotion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgrammeStreamReq As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgrammeStream As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeStream As System.Windows.Forms.Label
    Friend WithEvents LblFromStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtFromClass As AgControls.AgTextBox
    Friend WithEvents LblFromStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents LblSelectAllReq As System.Windows.Forms.Label
    Friend WithEvents LblSelectAll As System.Windows.Forms.Label
    Friend WithEvents TxtSelectAll As AgControls.AgTextBox
    Friend WithEvents TxtPromotionDate As AgControls.AgTextBox
    Friend WithEvents LblPromotionDate As System.Windows.Forms.Label
    Friend WithEvents LblPromotionDateReq As System.Windows.Forms.Label
    Friend WithEvents LblToStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtToClass As AgControls.AgTextBox
    Friend WithEvents LblToStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
