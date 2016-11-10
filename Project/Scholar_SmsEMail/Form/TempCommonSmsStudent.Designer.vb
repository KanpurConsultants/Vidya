<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TempCommonSmsStudent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtMessage = New AgControls.AgTextBox
        Me.LblMessage = New System.Windows.Forms.Label
        Me.LblEventReq = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnFill = New System.Windows.Forms.Button
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblValTotalSMS = New System.Windows.Forms.Label
        Me.LblTextTotalSMS = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.TxtMsgDate = New AgControls.AgTextBox
        Me.LblMsgDate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblSelectAllReq = New System.Windows.Forms.Label
        Me.TxtSelectAll = New AgControls.AgTextBox
        Me.LblSelectAll = New System.Windows.Forms.Label
        Me.TxtProgramme = New AgControls.AgTextBox
        Me.LblProgramme = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.TxtStream = New AgControls.AgTextBox
        Me.LblStream = New System.Windows.Forms.Label
        Me.TxtSemester = New AgControls.AgTextBox
        Me.LblSemester = New System.Windows.Forms.Label
        Me.LblMessageReq = New System.Windows.Forms.Label
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMessage
        '
        Me.TxtMessage.AgAllowUserToEnableMasterHelp = False
        Me.TxtMessage.AgMandatory = True
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
        Me.TxtMessage.Location = New System.Drawing.Point(413, 99)
        Me.TxtMessage.MaxLength = 255
        Me.TxtMessage.Multiline = True
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(350, 57)
        Me.TxtMessage.TabIndex = 3
        '
        'LblMessage
        '
        Me.LblMessage.AutoSize = True
        Me.LblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(294, 101)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(58, 15)
        Me.LblMessage.TabIndex = 31
        Me.LblMessage.Text = "Message"
        '
        'LblEventReq
        '
        Me.LblEventReq.AutoSize = True
        Me.LblEventReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblEventReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblEventReq.Location = New System.Drawing.Point(399, 85)
        Me.LblEventReq.Name = "LblEventReq"
        Me.LblEventReq.Size = New System.Drawing.Size(10, 7)
        Me.LblEventReq.TabIndex = 30
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
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
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
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnFill.Location = New System.Drawing.Point(663, 218)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 25)
        Me.BtnFill.TabIndex = 7
        Me.BtnFill.Text = "Fill Data"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalSMS)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalSMS)
        Me.PnlFooter.Location = New System.Drawing.Point(139, 581)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(786, 24)
        Me.PnlFooter.TabIndex = 742
        '
        'LblValTotalSMS
        '
        Me.LblValTotalSMS.AutoSize = True
        Me.LblValTotalSMS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValTotalSMS.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblValTotalSMS.Location = New System.Drawing.Point(620, 4)
        Me.LblValTotalSMS.Name = "LblValTotalSMS"
        Me.LblValTotalSMS.Size = New System.Drawing.Size(12, 16)
        Me.LblValTotalSMS.TabIndex = 680
        Me.LblValTotalSMS.Text = "."
        Me.LblValTotalSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTextTotalSMS
        '
        Me.LblTextTotalSMS.AutoSize = True
        Me.LblTextTotalSMS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTextTotalSMS.ForeColor = System.Drawing.Color.Maroon
        Me.LblTextTotalSMS.Location = New System.Drawing.Point(529, 4)
        Me.LblTextTotalSMS.Name = "LblTextTotalSMS"
        Me.LblTextTotalSMS.Size = New System.Drawing.Size(85, 16)
        Me.LblTextTotalSMS.TabIndex = 679
        Me.LblTextTotalSMS.Text = "Total SMS  :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(139, 264)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(786, 317)
        Me.Pnl1.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(139, 246)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(786, 20)
        Me.LinkLabel1.TabIndex = 743
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "STUDENT LIST"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(294, 60)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 745
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(413, 59)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
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
        Me.TxtV_Date.Location = New System.Drawing.Point(413, 79)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        Me.TxtV_Date.TabIndex = 1
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(294, 81)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(63, 15)
        Me.LblV_Date.TabIndex = 747
        Me.LblV_Date.Text = "Entry Date"
        '
        'TxtMsgDate
        '
        Me.TxtMsgDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtMsgDate.AgMandatory = True
        Me.TxtMsgDate.AgMasterHelp = False
        Me.TxtMsgDate.AgNumberLeftPlaces = 0
        Me.TxtMsgDate.AgNumberNegetiveAllow = False
        Me.TxtMsgDate.AgNumberRightPlaces = 0
        Me.TxtMsgDate.AgPickFromLastValue = False
        Me.TxtMsgDate.AgRowFilter = ""
        Me.TxtMsgDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMsgDate.AgSelectedValue = Nothing
        Me.TxtMsgDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMsgDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtMsgDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMsgDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMsgDate.Location = New System.Drawing.Point(643, 79)
        Me.TxtMsgDate.Name = "TxtMsgDate"
        Me.TxtMsgDate.Size = New System.Drawing.Size(120, 18)
        Me.TxtMsgDate.TabIndex = 2
        '
        'LblMsgDate
        '
        Me.LblMsgDate.AutoSize = True
        Me.LblMsgDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsgDate.Location = New System.Drawing.Point(564, 81)
        Me.LblMsgDate.Name = "LblMsgDate"
        Me.LblMsgDate.Size = New System.Drawing.Size(61, 15)
        Me.LblMsgDate.TabIndex = 749
        Me.LblMsgDate.Text = "SMS Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(624, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 750
        Me.Label1.Text = "Ä"
        '
        'LblSelectAllReq
        '
        Me.LblSelectAllReq.AutoSize = True
        Me.LblSelectAllReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSelectAllReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectAllReq.Location = New System.Drawing.Point(399, 185)
        Me.LblSelectAllReq.Name = "LblSelectAllReq"
        Me.LblSelectAllReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSelectAllReq.TabIndex = 753
        Me.LblSelectAllReq.Text = "Ä"
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
        Me.TxtSelectAll.Location = New System.Drawing.Point(413, 178)
        Me.TxtSelectAll.MaxLength = 3
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(48, 18)
        Me.TxtSelectAll.TabIndex = 6
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(294, 181)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(57, 15)
        Me.LblSelectAll.TabIndex = 752
        Me.LblSelectAll.Text = "Select All"
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
        Me.TxtProgramme.Location = New System.Drawing.Point(88, 100)
        Me.TxtProgramme.MaxLength = 0
        Me.TxtProgramme.Name = "TxtProgramme"
        Me.TxtProgramme.Size = New System.Drawing.Size(120, 18)
        Me.TxtProgramme.TabIndex = 5
        Me.TxtProgramme.Visible = False
        '
        'LblProgramme
        '
        Me.LblProgramme.AutoSize = True
        Me.LblProgramme.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProgramme.Location = New System.Drawing.Point(12, 102)
        Me.LblProgramme.Name = "LblProgramme"
        Me.LblProgramme.Size = New System.Drawing.Size(73, 15)
        Me.LblProgramme.TabIndex = 790
        Me.LblProgramme.Text = "Programme"
        Me.LblProgramme.Visible = False
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgAllowUserToEnableMasterHelp = False
        Me.TxtStreamYearSemester.AgMandatory = False
        Me.TxtStreamYearSemester.AgMasterHelp = False
        Me.TxtStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamYearSemester.AgPickFromLastValue = False
        Me.TxtStreamYearSemester.AgRowFilter = ""
        Me.TxtStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamYearSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(626, 158)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(137, 18)
        Me.TxtStreamYearSemester.TabIndex = 5
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(540, 160)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(85, 15)
        Me.LblStreamYearSemester.TabIndex = 789
        Me.LblStreamYearSemester.Text = "Class-Section"
        '
        'TxtSession
        '
        Me.TxtSession.AgAllowUserToEnableMasterHelp = False
        Me.TxtSession.AgMandatory = False
        Me.TxtSession.AgMasterHelp = False
        Me.TxtSession.AgNumberLeftPlaces = 0
        Me.TxtSession.AgNumberNegetiveAllow = False
        Me.TxtSession.AgNumberRightPlaces = 0
        Me.TxtSession.AgPickFromLastValue = False
        Me.TxtSession.AgRowFilter = ""
        Me.TxtSession.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSession.AgSelectedValue = Nothing
        Me.TxtSession.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSession.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSession.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSession.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSession.Location = New System.Drawing.Point(88, 60)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(120, 18)
        Me.TxtSession.TabIndex = 4
        Me.TxtSession.Visible = False
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(13, 62)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(53, 15)
        Me.LblSession.TabIndex = 792
        Me.LblSession.Text = "Session"
        Me.LblSession.Visible = False
        '
        'TxtStream
        '
        Me.TxtStream.AgAllowUserToEnableMasterHelp = False
        Me.TxtStream.AgMandatory = False
        Me.TxtStream.AgMasterHelp = False
        Me.TxtStream.AgNumberLeftPlaces = 0
        Me.TxtStream.AgNumberNegetiveAllow = False
        Me.TxtStream.AgNumberRightPlaces = 0
        Me.TxtStream.AgPickFromLastValue = False
        Me.TxtStream.AgRowFilter = ""
        Me.TxtStream.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStream.AgSelectedValue = Nothing
        Me.TxtStream.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStream.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStream.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStream.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStream.Location = New System.Drawing.Point(88, 80)
        Me.TxtStream.MaxLength = 0
        Me.TxtStream.Name = "TxtStream"
        Me.TxtStream.Size = New System.Drawing.Size(120, 18)
        Me.TxtStream.TabIndex = 6
        Me.TxtStream.Visible = False
        '
        'LblStream
        '
        Me.LblStream.AutoSize = True
        Me.LblStream.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStream.Location = New System.Drawing.Point(13, 82)
        Me.LblStream.Name = "LblStream"
        Me.LblStream.Size = New System.Drawing.Size(47, 15)
        Me.LblStream.TabIndex = 794
        Me.LblStream.Text = "Stream"
        Me.LblStream.Visible = False
        '
        'TxtSemester
        '
        Me.TxtSemester.AgAllowUserToEnableMasterHelp = False
        Me.TxtSemester.AgMandatory = False
        Me.TxtSemester.AgMasterHelp = False
        Me.TxtSemester.AgNumberLeftPlaces = 0
        Me.TxtSemester.AgNumberNegetiveAllow = False
        Me.TxtSemester.AgNumberRightPlaces = 0
        Me.TxtSemester.AgPickFromLastValue = False
        Me.TxtSemester.AgRowFilter = ""
        Me.TxtSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemester.AgSelectedValue = Nothing
        Me.TxtSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemester.Location = New System.Drawing.Point(413, 158)
        Me.TxtSemester.MaxLength = 0
        Me.TxtSemester.Name = "TxtSemester"
        Me.TxtSemester.Size = New System.Drawing.Size(120, 18)
        Me.TxtSemester.TabIndex = 4
        '
        'LblSemester
        '
        Me.LblSemester.AutoSize = True
        Me.LblSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemester.Location = New System.Drawing.Point(294, 160)
        Me.LblSemester.Name = "LblSemester"
        Me.LblSemester.Size = New System.Drawing.Size(40, 15)
        Me.LblSemester.TabIndex = 796
        Me.LblSemester.Text = "Class"
        '
        'LblMessageReq
        '
        Me.LblMessageReq.AutoSize = True
        Me.LblMessageReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMessageReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMessageReq.Location = New System.Drawing.Point(399, 106)
        Me.LblMessageReq.Name = "LblMessageReq"
        Me.LblMessageReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMessageReq.TabIndex = 797
        Me.LblMessageReq.Text = "Ä"
        '
        'TempCommonSmsStudent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LblMessageReq)
        Me.Controls.Add(Me.TxtSemester)
        Me.Controls.Add(Me.LblSemester)
        Me.Controls.Add(Me.TxtStream)
        Me.Controls.Add(Me.LblStream)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.TxtProgramme)
        Me.Controls.Add(Me.LblProgramme)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.LblSelectAllReq)
        Me.Controls.Add(Me.TxtSelectAll)
        Me.Controls.Add(Me.LblSelectAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMsgDate)
        Me.Controls.Add(Me.LblMsgDate)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.LblMessage)
        Me.Controls.Add(Me.LblEventReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.Name = "TempCommonSmsStudent"
        Me.Text = "FrmCommonSmsEmployee"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents TxtMessage As AgControls.AgTextBox
    Protected WithEvents LblMessage As System.Windows.Forms.Label
    Protected WithEvents LblEventReq As System.Windows.Forms.Label
    Protected WithEvents Topctrl1 As Topctrl.Topctrl
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents PnlFooter As System.Windows.Forms.Panel
    Protected WithEvents LblValTotalSMS As System.Windows.Forms.Label
    Protected WithEvents LblTextTotalSMS As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Public WithEvents LblSite_Code As System.Windows.Forms.Label
    Public WithEvents TxtSite_Code As AgControls.AgTextBox
    Public WithEvents TxtV_Date As AgControls.AgTextBox
    Public WithEvents LblV_Date As System.Windows.Forms.Label
    Public WithEvents TxtMsgDate As AgControls.AgTextBox
    Public WithEvents LblMsgDate As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LblSelectAllReq As System.Windows.Forms.Label
    Protected WithEvents TxtSelectAll As AgControls.AgTextBox
    Protected WithEvents LblSelectAll As System.Windows.Forms.Label
    Protected WithEvents TxtProgramme As AgControls.AgTextBox
    Protected WithEvents LblProgramme As System.Windows.Forms.Label
    Protected WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Protected WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Protected WithEvents TxtSession As AgControls.AgTextBox
    Protected WithEvents LblSession As System.Windows.Forms.Label
    Protected WithEvents TxtStream As AgControls.AgTextBox
    Protected WithEvents LblStream As System.Windows.Forms.Label
    Protected WithEvents TxtSemester As AgControls.AgTextBox
    Protected WithEvents LblSemester As System.Windows.Forms.Label
    Protected WithEvents LblMessageReq As System.Windows.Forms.Label
End Class
