<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScholarshipDemand
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
        Me.TxtProgramme = New AgControls.AgTextBox
        Me.LblProgramme = New System.Windows.Forms.Label
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.LblProgrammeReq = New System.Windows.Forms.Label
        Me.LblDemandDetail = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtTotalDemandAmount = New AgControls.AgTextBox
        Me.LblTotalAmt = New System.Windows.Forms.Label
        Me.LblCategoryReq = New System.Windows.Forms.Label
        Me.TxtCategory = New AgControls.AgTextBox
        Me.LblCategory = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.TxtDocId = New AgControls.AgTextBox
        Me.BtnFillStudents = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClass = New AgControls.AgTextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtProgramme
        '
        Me.TxtProgramme.AgAllowUserToEnableMasterHelp = False
        Me.TxtProgramme.AgMandatory = False
        Me.TxtProgramme.AgMasterHelp = False
        Me.TxtProgramme.AgNumberLeftPlaces = 0
        Me.TxtProgramme.AgNumberNegetiveAllow = False
        Me.TxtProgramme.AgNumberRightPlaces = 0
        Me.TxtProgramme.AgPickFromLastValue = False
        Me.TxtProgramme.AgRowFilter = ""
        Me.TxtProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProgramme.AgSelectedValue = Nothing
        Me.TxtProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProgramme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProgramme.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProgramme.Location = New System.Drawing.Point(550, 152)
        Me.TxtProgramme.MaxLength = 123
        Me.TxtProgramme.Name = "TxtProgramme"
        Me.TxtProgramme.Size = New System.Drawing.Size(56, 18)
        Me.TxtProgramme.TabIndex = 6
        Me.TxtProgramme.Visible = False
        '
        'LblProgramme
        '
        Me.LblProgramme.AutoSize = True
        Me.LblProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProgramme.Location = New System.Drawing.Point(455, 154)
        Me.LblProgramme.Name = "LblProgramme"
        Me.LblProgramme.Size = New System.Drawing.Size(73, 15)
        Me.LblProgramme.TabIndex = 644
        Me.LblProgramme.Text = "Programme"
        Me.LblProgramme.Visible = False
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(253, 123)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(43, 15)
        Me.LblV_No.TabIndex = 640
        Me.LblV_No.Text = "Vr. No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_No.AgMandatory = True
        Me.TxtV_No.AgMasterHelp = False
        Me.TxtV_No.AgNumberLeftPlaces = 8
        Me.TxtV_No.AgNumberNegetiveAllow = False
        Me.TxtV_No.AgNumberRightPlaces = 0
        Me.TxtV_No.AgPickFromLastValue = False
        Me.TxtV_No.AgRowFilter = ""
        Me.TxtV_No.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_No.AgSelectedValue = Nothing
        Me.TxtV_No.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_No.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtV_No.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_No.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_No.Location = New System.Drawing.Point(344, 121)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(106, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 643
        Me.Label5.Text = "�"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(106, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 642
        Me.Label2.Text = "�"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(5, 123)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(81, 15)
        Me.LblV_Date.TabIndex = 638
        Me.LblV_Date.Text = "Voucher Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(106, 106)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 641
        Me.LblV_TypeReq.Text = "�"
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Date.AgMandatory = True
        Me.TxtV_Date.AgMasterHelp = False
        Me.TxtV_Date.AgNumberLeftPlaces = 0
        Me.TxtV_Date.AgNumberNegetiveAllow = False
        Me.TxtV_Date.AgNumberRightPlaces = 0
        Me.TxtV_Date.AgPickFromLastValue = False
        Me.TxtV_Date.AgRowFilter = ""
        Me.TxtV_Date.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Date.AgSelectedValue = Nothing
        Me.TxtV_Date.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Date.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtV_Date.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_Date.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Date.Location = New System.Drawing.Point(119, 121)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Date.TabIndex = 3
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(5, 102)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(81, 15)
        Me.LblV_Type.TabIndex = 637
        Me.LblV_Type.Text = "Voucher Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(106, 87)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 636
        Me.LblSite_CodeReq.Text = "�"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(5, 81)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 639
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(119, 79)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 18)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(5, 60)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(39, 15)
        Me.LblDocId.TabIndex = 634
        Me.LblDocId.Text = "DocId"
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
        Me.Topctrl1.Size = New System.Drawing.Size(884, 41)
        Me.Topctrl1.TabIndex = 10
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
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(305, 124)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 635
        Me.LblPrefix.Text = "LblPrefix"
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 536)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 647
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
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(658, 536)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 648
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
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 526)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(892, 4)
        Me.GroupBox2.TabIndex = 646
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TxtRemark
        '
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
        Me.TxtRemark.AgMandatory = False
        Me.TxtRemark.AgMasterHelp = False
        Me.TxtRemark.AgNumberLeftPlaces = 0
        Me.TxtRemark.AgNumberNegetiveAllow = False
        Me.TxtRemark.AgNumberRightPlaces = 0
        Me.TxtRemark.AgPickFromLastValue = False
        Me.TxtRemark.AgRowFilter = ""
        Me.TxtRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemark.AgSelectedValue = Nothing
        Me.TxtRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(550, 100)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 18)
        Me.TxtRemark.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(461, 102)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 649
        Me.Label12.Text = "&Remark"
        '
        'LblProgrammeReq
        '
        Me.LblProgrammeReq.AutoSize = True
        Me.LblProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblProgrammeReq.Location = New System.Drawing.Point(537, 87)
        Me.LblProgrammeReq.Name = "LblProgrammeReq"
        Me.LblProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblProgrammeReq.TabIndex = 654
        Me.LblProgrammeReq.Text = "�"
        '
        'LblDemandDetail
        '
        Me.LblDemandDetail.AutoSize = True
        Me.LblDemandDetail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDemandDetail.ForeColor = System.Drawing.Color.Blue
        Me.LblDemandDetail.Location = New System.Drawing.Point(93, 160)
        Me.LblDemandDetail.Name = "LblDemandDetail"
        Me.LblDemandDetail.Size = New System.Drawing.Size(93, 15)
        Me.LblDemandDetail.TabIndex = 656
        Me.LblDemandDetail.Text = "Demand Detail:"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(96, 177)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(692, 323)
        Me.Pnl1.TabIndex = 9
        '
        'TxtTotalDemandAmount
        '
        Me.TxtTotalDemandAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalDemandAmount.AgMandatory = False
        Me.TxtTotalDemandAmount.AgMasterHelp = False
        Me.TxtTotalDemandAmount.AgNumberLeftPlaces = 8
        Me.TxtTotalDemandAmount.AgNumberNegetiveAllow = False
        Me.TxtTotalDemandAmount.AgNumberRightPlaces = 2
        Me.TxtTotalDemandAmount.AgPickFromLastValue = False
        Me.TxtTotalDemandAmount.AgRowFilter = ""
        Me.TxtTotalDemandAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalDemandAmount.AgSelectedValue = Nothing
        Me.TxtTotalDemandAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalDemandAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalDemandAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalDemandAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDemandAmount.ForeColor = System.Drawing.Color.Black
        Me.TxtTotalDemandAmount.Location = New System.Drawing.Point(688, 504)
        Me.TxtTotalDemandAmount.Name = "TxtTotalDemandAmount"
        Me.TxtTotalDemandAmount.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalDemandAmount.TabIndex = 657
        Me.TxtTotalDemandAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalAmt
        '
        Me.LblTotalAmt.AutoSize = True
        Me.LblTotalAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmt.Location = New System.Drawing.Point(542, 506)
        Me.LblTotalAmt.Name = "LblTotalAmt"
        Me.LblTotalAmt.Size = New System.Drawing.Size(109, 15)
        Me.LblTotalAmt.TabIndex = 658
        Me.LblTotalAmt.Text = "Total Demand Amt"
        '
        'LblCategoryReq
        '
        Me.LblCategoryReq.AutoSize = True
        Me.LblCategoryReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblCategoryReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCategoryReq.Location = New System.Drawing.Point(537, 64)
        Me.LblCategoryReq.Name = "LblCategoryReq"
        Me.LblCategoryReq.Size = New System.Drawing.Size(10, 7)
        Me.LblCategoryReq.TabIndex = 661
        Me.LblCategoryReq.Text = "�"
        '
        'TxtCategory
        '
        Me.TxtCategory.AgAllowUserToEnableMasterHelp = False
        Me.TxtCategory.AgMandatory = False
        Me.TxtCategory.AgMasterHelp = False
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
        Me.TxtCategory.Location = New System.Drawing.Point(550, 58)
        Me.TxtCategory.MaxLength = 123
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(325, 18)
        Me.TxtCategory.TabIndex = 5
        '
        'LblCategory
        '
        Me.LblCategory.AutoSize = True
        Me.LblCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategory.Location = New System.Drawing.Point(461, 60)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.Size = New System.Drawing.Size(56, 15)
        Me.LblCategory.TabIndex = 660
        Me.LblCategory.Text = "Category"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Type.AgMandatory = True
        Me.TxtV_Type.AgMasterHelp = False
        Me.TxtV_Type.AgNumberLeftPlaces = 0
        Me.TxtV_Type.AgNumberNegetiveAllow = False
        Me.TxtV_Type.AgNumberRightPlaces = 0
        Me.TxtV_Type.AgPickFromLastValue = False
        Me.TxtV_Type.AgRowFilter = ""
        Me.TxtV_Type.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Type.AgSelectedValue = Nothing
        Me.TxtV_Type.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Type.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtV_Type.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_Type.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Type.Location = New System.Drawing.Point(119, 100)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(325, 18)
        Me.TxtV_Type.TabIndex = 2
        '
        'TxtDocId
        '
        Me.TxtDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtDocId.AgMandatory = False
        Me.TxtDocId.AgMasterHelp = False
        Me.TxtDocId.AgNumberLeftPlaces = 0
        Me.TxtDocId.AgNumberNegetiveAllow = False
        Me.TxtDocId.AgNumberRightPlaces = 0
        Me.TxtDocId.AgPickFromLastValue = False
        Me.TxtDocId.AgRowFilter = ""
        Me.TxtDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDocId.AgSelectedValue = Nothing
        Me.TxtDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocId.Location = New System.Drawing.Point(119, 58)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.Size = New System.Drawing.Size(325, 18)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        '
        'BtnFillStudents
        '
        Me.BtnFillStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudents.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudents.Location = New System.Drawing.Point(688, 152)
        Me.BtnFillStudents.Name = "BtnFillStudents"
        Me.BtnFillStudents.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillStudents.TabIndex = 8
        Me.BtnFillStudents.Text = "Fill &Students"
        Me.BtnFillStudents.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(461, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 948
        Me.Label3.Text = "Class"
        '
        'TxtClass
        '
        Me.TxtClass.AgAllowUserToEnableMasterHelp = False
        Me.TxtClass.AgMandatory = False
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
        Me.TxtClass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClass.Location = New System.Drawing.Point(550, 79)
        Me.TxtClass.MaxLength = 123
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Size = New System.Drawing.Size(325, 18)
        Me.TxtClass.TabIndex = 6
        '
        'FrmScholarshipDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(884, 592)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtClass)
        Me.Controls.Add(Me.BtnFillStudents)
        Me.Controls.Add(Me.LblCategoryReq)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.LblCategory)
        Me.Controls.Add(Me.LblTotalAmt)
        Me.Controls.Add(Me.TxtTotalDemandAmount)
        Me.Controls.Add(Me.LblDemandDetail)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblProgrammeReq)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtProgramme)
        Me.Controls.Add(Me.LblProgramme)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.LblV_TypeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmScholarshipDemand"
        Me.Text = "FrmAdvance"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtProgramme As AgControls.AgTextBox
    Friend WithEvents LblProgramme As System.Windows.Forms.Label
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents LblDemandDetail As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotalDemandAmount As AgControls.AgTextBox
    Friend WithEvents LblTotalAmt As System.Windows.Forms.Label
    Friend WithEvents LblCategoryReq As System.Windows.Forms.Label
    Friend WithEvents TxtCategory As AgControls.AgTextBox
    Friend WithEvents LblCategory As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents BtnFillStudents As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClass As AgControls.AgTextBox
End Class
