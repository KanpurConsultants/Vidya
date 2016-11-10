<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeeDueEntry
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtAmount = New AgControls.AgTextBox()
        Me.Pnl1 = New System.Windows.Forms.Panel()
        Me.LblPrefix = New System.Windows.Forms.Label()
        Me.LblV_No = New System.Windows.Forms.Label()
        Me.LblSite_Code = New System.Windows.Forms.Label()
        Me.LblSite_CodeReq = New System.Windows.Forms.Label()
        Me.TxtV_Date = New AgControls.AgTextBox()
        Me.TxtV_No = New AgControls.AgTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtRemark = New AgControls.AgTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtModified = New System.Windows.Forms.TextBox()
        Me.GrpUP = New System.Windows.Forms.GroupBox()
        Me.TxtPrepared = New System.Windows.Forms.TextBox()
        Me.Topctrl1 = New Topctrl.Topctrl()
        Me.TxtDocId = New AgControls.AgTextBox()
        Me.LblDocId = New System.Windows.Forms.Label()
        Me.TxtSite_Code = New AgControls.AgTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblV_Date = New System.Windows.Forms.Label()
        Me.TxtV_Type = New AgControls.AgTextBox()
        Me.LblV_Type = New System.Windows.Forms.Label()
        Me.BtnFill = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClass = New AgControls.AgTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMonthStartDate = New AgControls.AgTextBox()
        Me.LblMonthStartDate = New System.Windows.Forms.Label()
        Me.TxtFee = New AgControls.AgTextBox()
        Me.LblFee = New System.Windows.Forms.Label()
        Me.LblFeeAmt = New System.Windows.Forms.Label()
        Me.TxtFeeAmt = New AgControls.AgTextBox()
        Me.BtnAcPosting = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(357, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 7)
        Me.Label10.TabIndex = 403
        Me.Label10.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(672, 510)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 398
        Me.Label1.Text = "Total Amount"
        '
        'TxtAmount
        '
        Me.TxtAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtAmount.AgLastValueTag = Nothing
        Me.TxtAmount.AgLastValueText = Nothing
        Me.TxtAmount.AgMandatory = True
        Me.TxtAmount.AgMasterHelp = False
        Me.TxtAmount.AgNumberLeftPlaces = 8
        Me.TxtAmount.AgNumberNegetiveAllow = False
        Me.TxtAmount.AgNumberRightPlaces = 0
        Me.TxtAmount.AgPickFromLastValue = False
        Me.TxtAmount.AgRowFilter = ""
        Me.TxtAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAmount.AgSelectedValue = Nothing
        Me.TxtAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Location = New System.Drawing.Point(760, 508)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(100, 18)
        Me.TxtAmount.TabIndex = 9
        Me.TxtAmount.Text = "TxtAmount"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 221)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(848, 279)
        Me.Pnl1.TabIndex = 10
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(583, 143)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(48, 13)
        Me.LblPrefix.TabIndex = 391
        Me.LblPrefix.Text = "LblPrefix"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(507, 142)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(76, 15)
        Me.LblV_No.TabIndex = 381
        Me.LblV_No.Text = "Fee Due No."
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(208, 82)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 384
        Me.LblSite_Code.Text = "Site/Branch"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(357, 86)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 387
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Date.AgLastValueTag = Nothing
        Me.TxtV_Date.AgLastValueText = Nothing
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
        Me.TxtV_Date.Location = New System.Drawing.Point(373, 140)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Date.TabIndex = 5
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'TxtV_No
        '
        Me.TxtV_No.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_No.AgLastValueTag = Nothing
        Me.TxtV_No.AgLastValueText = Nothing
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
        Me.TxtV_No.Location = New System.Drawing.Point(620, 140)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(78, 18)
        Me.TxtV_No.TabIndex = 6
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(357, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 396
        Me.Label13.Text = "Ä"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 510)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Remark"
        '
        'TxtRemark
        '
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
        Me.TxtRemark.AgLastValueTag = Nothing
        Me.TxtRemark.AgLastValueText = Nothing
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
        Me.TxtRemark.Location = New System.Drawing.Point(68, 508)
        Me.TxtRemark.MaxLength = 150
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 18)
        Me.TxtRemark.TabIndex = 11
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(357, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 392
        Me.Label5.Text = "Ä"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 549)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 389
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
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 549)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 388
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
        Me.Topctrl1.TabIndex = 12
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
        'TxtDocId
        '
        Me.TxtDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtDocId.AgLastValueTag = Nothing
        Me.TxtDocId.AgLastValueText = Nothing
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
        Me.TxtDocId.ForeColor = System.Drawing.Color.Blue
        Me.TxtDocId.Location = New System.Drawing.Point(373, 60)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(325, 18)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.ForeColor = System.Drawing.Color.Blue
        Me.LblDocId.Location = New System.Drawing.Point(208, 62)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(79, 15)
        Me.LblDocId.TabIndex = 383
        Me.LblDocId.Text = "Document ID"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
        Me.TxtSite_Code.AgLastValueTag = Nothing
        Me.TxtSite_Code.AgLastValueText = Nothing
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
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(373, 80)
        Me.TxtSite_Code.MaxLength = 25
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 18)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.Text = "TxtFromSite_Code"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(2, 539)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(872, 4)
        Me.GroupBox2.TabIndex = 390
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(208, 142)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(83, 15)
        Me.LblV_Date.TabIndex = 382
        Me.LblV_Date.Text = "Fee Due Date"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Type.AgLastValueTag = Nothing
        Me.TxtV_Type.AgLastValueText = Nothing
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
        Me.TxtV_Type.Location = New System.Drawing.Point(373, 100)
        Me.TxtV_Type.MaxLength = 25
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(325, 18)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(208, 102)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(82, 15)
        Me.LblV_Type.TabIndex = 386
        Me.LblV_Type.Text = "Fee Due Type"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(760, 191)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 28)
        Me.BtnFill.TabIndex = 9
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(357, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Ä"
        '
        'TxtClass
        '
        Me.TxtClass.AgAllowUserToEnableMasterHelp = False
        Me.TxtClass.AgLastValueTag = Nothing
        Me.TxtClass.AgLastValueText = Nothing
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
        Me.TxtClass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClass.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClass.Location = New System.Drawing.Point(373, 120)
        Me.TxtClass.MaxLength = 25
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Size = New System.Drawing.Size(178, 18)
        Me.TxtClass.TabIndex = 3
        Me.TxtClass.Text = "AgTextBox1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Class"
        '
        'TxtMonthStartDate
        '
        Me.TxtMonthStartDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtMonthStartDate.AgLastValueTag = Nothing
        Me.TxtMonthStartDate.AgLastValueText = Nothing
        Me.TxtMonthStartDate.AgMandatory = False
        Me.TxtMonthStartDate.AgMasterHelp = False
        Me.TxtMonthStartDate.AgNumberLeftPlaces = 0
        Me.TxtMonthStartDate.AgNumberNegetiveAllow = False
        Me.TxtMonthStartDate.AgNumberRightPlaces = 0
        Me.TxtMonthStartDate.AgPickFromLastValue = False
        Me.TxtMonthStartDate.AgRowFilter = ""
        Me.TxtMonthStartDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMonthStartDate.AgSelectedValue = Nothing
        Me.TxtMonthStartDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMonthStartDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtMonthStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMonthStartDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonthStartDate.Location = New System.Drawing.Point(620, 120)
        Me.TxtMonthStartDate.Name = "TxtMonthStartDate"
        Me.TxtMonthStartDate.Size = New System.Drawing.Size(78, 18)
        Me.TxtMonthStartDate.TabIndex = 4
        '
        'LblMonthStartDate
        '
        Me.LblMonthStartDate.AutoSize = True
        Me.LblMonthStartDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonthStartDate.Location = New System.Drawing.Point(554, 122)
        Me.LblMonthStartDate.Name = "LblMonthStartDate"
        Me.LblMonthStartDate.Size = New System.Drawing.Size(56, 15)
        Me.LblMonthStartDate.TabIndex = 439
        Me.LblMonthStartDate.Text = "Month/Yr."
        '
        'TxtFee
        '
        Me.TxtFee.AgAllowUserToEnableMasterHelp = False
        Me.TxtFee.AgLastValueTag = Nothing
        Me.TxtFee.AgLastValueText = Nothing
        Me.TxtFee.AgMandatory = False
        Me.TxtFee.AgMasterHelp = False
        Me.TxtFee.AgNumberLeftPlaces = 0
        Me.TxtFee.AgNumberNegetiveAllow = False
        Me.TxtFee.AgNumberRightPlaces = 0
        Me.TxtFee.AgPickFromLastValue = False
        Me.TxtFee.AgRowFilter = ""
        Me.TxtFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFee.AgSelectedValue = Nothing
        Me.TxtFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFee.Location = New System.Drawing.Point(373, 160)
        Me.TxtFee.MaxLength = 25
        Me.TxtFee.Name = "TxtFee"
        Me.TxtFee.Size = New System.Drawing.Size(325, 18)
        Me.TxtFee.TabIndex = 7
        '
        'LblFee
        '
        Me.LblFee.AutoSize = True
        Me.LblFee.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFee.Location = New System.Drawing.Point(208, 162)
        Me.LblFee.Name = "LblFee"
        Me.LblFee.Size = New System.Drawing.Size(61, 15)
        Me.LblFee.TabIndex = 442
        Me.LblFee.Text = "Fee Head"
        '
        'LblFeeAmt
        '
        Me.LblFeeAmt.AutoSize = True
        Me.LblFeeAmt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeAmt.Location = New System.Drawing.Point(208, 182)
        Me.LblFeeAmt.Name = "LblFeeAmt"
        Me.LblFeeAmt.Size = New System.Drawing.Size(72, 15)
        Me.LblFeeAmt.TabIndex = 444
        Me.LblFeeAmt.Text = "Fee Amount"
        '
        'TxtFeeAmt
        '
        Me.TxtFeeAmt.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeAmt.AgLastValueTag = Nothing
        Me.TxtFeeAmt.AgLastValueText = Nothing
        Me.TxtFeeAmt.AgMandatory = False
        Me.TxtFeeAmt.AgMasterHelp = False
        Me.TxtFeeAmt.AgNumberLeftPlaces = 8
        Me.TxtFeeAmt.AgNumberNegetiveAllow = False
        Me.TxtFeeAmt.AgNumberRightPlaces = 2
        Me.TxtFeeAmt.AgPickFromLastValue = False
        Me.TxtFeeAmt.AgRowFilter = ""
        Me.TxtFeeAmt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeAmt.AgSelectedValue = Nothing
        Me.TxtFeeAmt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeAmt.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFeeAmt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeeAmt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeAmt.Location = New System.Drawing.Point(373, 180)
        Me.TxtFeeAmt.Name = "TxtFeeAmt"
        Me.TxtFeeAmt.Size = New System.Drawing.Size(100, 18)
        Me.TxtFeeAmt.TabIndex = 8
        Me.TxtFeeAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAcPosting
        '
        Me.BtnAcPosting.Location = New System.Drawing.Point(429, 573)
        Me.BtnAcPosting.Name = "BtnAcPosting"
        Me.BtnAcPosting.Size = New System.Drawing.Size(81, 26)
        Me.BtnAcPosting.TabIndex = 445
        Me.BtnAcPosting.Text = "A/c Posting"
        Me.BtnAcPosting.UseVisualStyleBackColor = True
        '
        'FrmFeeDueEntry
        '
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(864, 612)
        Me.Controls.Add(Me.BtnAcPosting)
        Me.Controls.Add(Me.LblFeeAmt)
        Me.Controls.Add(Me.TxtFeeAmt)
        Me.Controls.Add(Me.TxtFee)
        Me.Controls.Add(Me.LblFee)
        Me.Controls.Add(Me.TxtMonthStartDate)
        Me.Controls.Add(Me.LblMonthStartDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtClass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFeeDueEntry"
        Me.Text = "Fee Due Entry"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As AgControls.AgTextBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClass As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMonthStartDate As AgControls.AgTextBox
    Friend WithEvents LblMonthStartDate As System.Windows.Forms.Label
    Friend WithEvents TxtFee As AgControls.AgTextBox
    Friend WithEvents LblFee As System.Windows.Forms.Label
    Friend WithEvents LblFeeAmt As System.Windows.Forms.Label
    Friend WithEvents TxtFeeAmt As AgControls.AgTextBox
    Friend WithEvents BtnAcPosting As System.Windows.Forms.Button
End Class
