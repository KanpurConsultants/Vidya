<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommonSmsEmployee
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
        Me.TxtIsTeachingStaff = New AgControls.AgTextBox
        Me.LblIsTeachingStaff = New System.Windows.Forms.Label
        Me.TxtLeftEmployee = New AgControls.AgTextBox
        Me.LblLeftEmployee = New System.Windows.Forms.Label
        Me.LblMessageReq = New System.Windows.Forms.Label
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMessage
        '
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
        Me.TxtMessage.Location = New System.Drawing.Point(348, 81)
        Me.TxtMessage.MaxLength = 255
        Me.TxtMessage.Multiline = True
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.Size = New System.Drawing.Size(325, 57)
        Me.TxtMessage.TabIndex = 2
        '
        'LblMessage
        '
        Me.LblMessage.AutoSize = True
        Me.LblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(233, 83)
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
        Me.LblEventReq.Location = New System.Drawing.Point(332, 67)
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
        Me.Topctrl1.TabIndex = 8
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
        Me.BtnFill.Location = New System.Drawing.Point(743, 145)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 25)
        Me.BtnFill.TabIndex = 6
        Me.BtnFill.Text = "Fill Data"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'PnlFooter
        '
        Me.PnlFooter.BackColor = System.Drawing.Color.Cornsilk
        Me.PnlFooter.Controls.Add(Me.LblValTotalSMS)
        Me.PnlFooter.Controls.Add(Me.LblTextTotalSMS)
        Me.PnlFooter.Location = New System.Drawing.Point(149, 581)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(694, 24)
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
        Me.Pnl1.Location = New System.Drawing.Point(149, 192)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(694, 389)
        Me.Pnl1.TabIndex = 7
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(149, 171)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(694, 20)
        Me.LinkLabel1.TabIndex = 743
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "EMPLOYEE LIST"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(773, 48)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 745
        Me.LblSite_Code.Text = "Branch/Site"
        Me.LblSite_Code.Visible = False
        '
        'TxtSite_Code
        '
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(853, 47)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 744
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Visible = False
        '
        'TxtV_Date
        '
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
        Me.TxtV_Date.Location = New System.Drawing.Point(348, 61)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Date.TabIndex = 0
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(233, 63)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(63, 15)
        Me.LblV_Date.TabIndex = 747
        Me.LblV_Date.Text = "Entry Date"
        '
        'TxtMsgDate
        '
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
        Me.TxtMsgDate.Location = New System.Drawing.Point(573, 61)
        Me.TxtMsgDate.Name = "TxtMsgDate"
        Me.TxtMsgDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtMsgDate.TabIndex = 1
        '
        'LblMsgDate
        '
        Me.LblMsgDate.AutoSize = True
        Me.LblMsgDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsgDate.Location = New System.Drawing.Point(476, 63)
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
        Me.Label1.Location = New System.Drawing.Point(557, 67)
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
        Me.LblSelectAllReq.Location = New System.Drawing.Point(609, 147)
        Me.LblSelectAllReq.Name = "LblSelectAllReq"
        Me.LblSelectAllReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSelectAllReq.TabIndex = 753
        Me.LblSelectAllReq.Text = "Ä"
        '
        'TxtSelectAll
        '
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
        Me.TxtSelectAll.Location = New System.Drawing.Point(625, 140)
        Me.TxtSelectAll.MaxLength = 3
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(48, 18)
        Me.TxtSelectAll.TabIndex = 5
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(554, 143)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(57, 15)
        Me.LblSelectAll.TabIndex = 752
        Me.LblSelectAll.Text = "Select All"
        '
        'TxtIsTeachingStaff
        '
        Me.TxtIsTeachingStaff.AgMandatory = True
        Me.TxtIsTeachingStaff.AgMasterHelp = False
        Me.TxtIsTeachingStaff.AgNumberLeftPlaces = 0
        Me.TxtIsTeachingStaff.AgNumberNegetiveAllow = False
        Me.TxtIsTeachingStaff.AgNumberRightPlaces = 0
        Me.TxtIsTeachingStaff.AgPickFromLastValue = False
        Me.TxtIsTeachingStaff.AgRowFilter = ""
        Me.TxtIsTeachingStaff.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsTeachingStaff.AgSelectedValue = Nothing
        Me.TxtIsTeachingStaff.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsTeachingStaff.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIsTeachingStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsTeachingStaff.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsTeachingStaff.Location = New System.Drawing.Point(348, 140)
        Me.TxtIsTeachingStaff.MaxLength = 3
        Me.TxtIsTeachingStaff.Name = "TxtIsTeachingStaff"
        Me.TxtIsTeachingStaff.Size = New System.Drawing.Size(48, 18)
        Me.TxtIsTeachingStaff.TabIndex = 3
        '
        'LblIsTeachingStaff
        '
        Me.LblIsTeachingStaff.AutoSize = True
        Me.LblIsTeachingStaff.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsTeachingStaff.Location = New System.Drawing.Point(233, 143)
        Me.LblIsTeachingStaff.Name = "LblIsTeachingStaff"
        Me.LblIsTeachingStaff.Size = New System.Drawing.Size(85, 15)
        Me.LblIsTeachingStaff.TabIndex = 755
        Me.LblIsTeachingStaff.Text = "Teaching Staff"
        '
        'TxtLeftEmployee
        '
        Me.TxtLeftEmployee.AgMandatory = True
        Me.TxtLeftEmployee.AgMasterHelp = False
        Me.TxtLeftEmployee.AgNumberLeftPlaces = 0
        Me.TxtLeftEmployee.AgNumberNegetiveAllow = False
        Me.TxtLeftEmployee.AgNumberRightPlaces = 0
        Me.TxtLeftEmployee.AgPickFromLastValue = False
        Me.TxtLeftEmployee.AgRowFilter = ""
        Me.TxtLeftEmployee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLeftEmployee.AgSelectedValue = Nothing
        Me.TxtLeftEmployee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLeftEmployee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLeftEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLeftEmployee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeftEmployee.Location = New System.Drawing.Point(502, 140)
        Me.TxtLeftEmployee.MaxLength = 3
        Me.TxtLeftEmployee.Name = "TxtLeftEmployee"
        Me.TxtLeftEmployee.Size = New System.Drawing.Size(48, 18)
        Me.TxtLeftEmployee.TabIndex = 4
        '
        'LblLeftEmployee
        '
        Me.LblLeftEmployee.AutoSize = True
        Me.LblLeftEmployee.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLeftEmployee.Location = New System.Drawing.Point(404, 143)
        Me.LblLeftEmployee.Name = "LblLeftEmployee"
        Me.LblLeftEmployee.Size = New System.Drawing.Size(85, 15)
        Me.LblLeftEmployee.TabIndex = 758
        Me.LblLeftEmployee.Text = "Left Employee"
        '
        'LblMessageReq
        '
        Me.LblMessageReq.AutoSize = True
        Me.LblMessageReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMessageReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMessageReq.Location = New System.Drawing.Point(332, 89)
        Me.LblMessageReq.Name = "LblMessageReq"
        Me.LblMessageReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMessageReq.TabIndex = 798
        Me.LblMessageReq.Text = "Ä"
        '
        'FrmCommonSmsEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LblMessageReq)
        Me.Controls.Add(Me.TxtLeftEmployee)
        Me.Controls.Add(Me.LblLeftEmployee)
        Me.Controls.Add(Me.TxtIsTeachingStaff)
        Me.Controls.Add(Me.LblIsTeachingStaff)
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
        Me.Name = "FrmCommonSmsEmployee"
        Me.Text = "FrmCommonSmsEmployee"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMessage As AgControls.AgTextBox
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents LblEventReq As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents BtnFill As System.Windows.Forms.Button
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblSelectAllReq As System.Windows.Forms.Label
    Friend WithEvents TxtSelectAll As AgControls.AgTextBox
    Friend WithEvents LblSelectAll As System.Windows.Forms.Label
    Friend WithEvents TxtIsTeachingStaff As AgControls.AgTextBox
    Friend WithEvents LblIsTeachingStaff As System.Windows.Forms.Label
    Friend WithEvents TxtLeftEmployee As AgControls.AgTextBox
    Friend WithEvents LblLeftEmployee As System.Windows.Forms.Label
    Friend WithEvents LblMessageReq As System.Windows.Forms.Label
End Class
