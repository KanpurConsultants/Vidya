Public Class FrmImportAccessationFromExcel
    Public WithEvents Dgl1 As New AgControls.AgDataGrid

    Dim mUserAction As String = "None"
    Dim DsExcelData As New DataSet
    Dim MyConnection As System.Data.OleDb.OleDbConnection

    Dim _StrVDate_Column$ = ""

    Protected Const Col_AccessationDate As String = "Accessation Date"
    Protected Const Col_AccessionNo As String = "Accession No"
    Protected Const Col_AccessionNoPrefix As String = "Accession No Prefix"
    Protected Const Col_AccessionNoSufix As String = "Accession No Sufix"
    Protected Const Col_AccessionNoSr As String = "Accession No Sr"
    Protected Const Col_BookName As String = "Book Name"
    Protected Const Col_Subject As String = "Subject"
    Protected Const Col_BookType As String = "Book Type"
    Protected Const Col_Series As String = "Series"
    Protected Const Col_Volume As String = "Volume"
    Protected Const Col_ISBN As String = "ISBN"
    Protected Const Col_Language As String = "Language"
    Protected Const Col_Writer As String = "Writer"
    Protected Const Col_Publisher As String = "Publisher"
    Protected Const Col_PublicationYear As String = "Publication Year"
    Protected Const Col_Pages As String = "Pages"
    Protected Const Col_MRP As String = "MRP"
    Protected Const Col_Rate As String = "Rate"
    Protected Const Col_CallNo As String = "Call No"
    Protected Const Col_Place As String = "Place"
    Protected Const Col_Almira As String = "Almira"
    Protected Const Col_Shelf As String = "Shelf"

    Private Declare Function ShellEx Lib "shell32.dll" Alias "ShellExecuteA" ( _
     ByVal hWnd As Integer, ByVal lpOperation As String, _
     ByVal lpFile As String, ByVal lpParameters As String, _
     ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer


    Public Property VDate_Column() As String
        Get
            VDate_Column = _StrVDate_Column
        End Get
        Set(ByVal value As String)
            _StrVDate_Column = value
        End Set
    End Property


    Public ReadOnly Property UserAction() As String
        Get
            UserAction = mUserAction
        End Get
    End Property

    Public ReadOnly Property P_DsExcelData() As DataSet
        Get
            Return DsExcelData
        End Get
    End Property

    Private Sub Ini_Grid()
        AgL.AddAgDataGrid(Dgl1, Panel2)
        Dgl1.ColumnHeadersHeight = 40
        Dgl1.EnableHeadersVisualStyles = False
        AgL.GridDesign(Dgl1)
        Dgl1.Columns(0).Width = 40
        Dgl1.Columns(1).Width = 150
        Dgl1.Columns(2).Width = 80
        Dgl1.Columns(3).Width = 80
        Dgl1.Columns(4).Width = 80 : Dgl1.Columns(4).Visible = False
        Dgl1.ReadOnly = True
        Dgl1.AllowUserToAddRows = False

        AgCL.AddAgTextColumn(Dgl1, "CFieldName", 100, 0, "CFieldName", False)
    End Sub

    Private Sub FrmImportFromExcel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ini_Grid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectExcelFile.Click
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter = Nothing
        Dim DsTemp As New DataSet
        Dim myExcelFilePath As String

        Try
            Opn.Filter = "Excel Files (*.xls)|*.xls"
            Opn.ShowDialog()
            myExcelFilePath = Opn.FileName
            TxtExcelPath.Text = myExcelFilePath
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " & _
                           "data source='" & myExcelFilePath & " '; " & "Extended Properties=Excel 8.0;")
            MyConnection.Open()

            FCheckExcelFile(MyConnection)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click, BtnCancel.Click
        Dim MyCommand As OleDb.OleDbDataAdapter = Nothing
        Dim mQry As String = ""
        Try
            Select Case sender.name
                Case BtnOK.Name
                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select *  from [sheet1$] ", MyConnection)
                    MyCommand.Fill(DsExcelData, "Table1")

                    mQry = "Select Distinct "
                    mQry += " [" & Col_AccessationDate & "], "
                    mQry += " [" & Col_BookName & "], "
                    mQry += " [" & Col_Subject & "], "
                    mQry += " [" & Col_BookType & "], "
                    mQry += " [" & Col_Series & "], "
                    mQry += " [" & Col_Volume & "], "
                    mQry += " [" & Col_ISBN & "], "
                    mQry += " [" & Col_Language & "], "
                    mQry += " [" & Col_Writer & "], "
                    mQry += " [" & Col_Publisher & "], "
                    mQry += " [" & Col_PublicationYear & "], "
                    mQry += " [" & Col_Pages & "], "
                    mQry += " [" & Col_MRP & "], "
                    mQry += " [" & Col_Rate & "], "
                    mQry += " [" & Col_CallNo & "], "
                    mQry += " [" & Col_Pages & "], "
                    mQry += " [" & Col_Almira & "], "
                    mQry += " [" & Col_Shelf & "], "

                    mQry += " Sum(1) As Qty "

                    mQry += " From [sheet1$] "
                    mQry += " Where [" & Col_AccessionNo & "] Is Not Null "

                    mQry += " Group By  "
                    mQry += " [" & Col_AccessationDate & "], "
                    mQry += " [" & Col_BookName & "], "
                    mQry += " [" & Col_Subject & "], "
                    mQry += " [" & Col_BookType & "], "
                    mQry += " [" & Col_Series & "], "
                    mQry += " [" & Col_Volume & "], "
                    mQry += " [" & Col_ISBN & "], "
                    mQry += " [" & Col_Language & "], "
                    mQry += " [" & Col_Writer & "], "
                    mQry += " [" & Col_Publisher & "], "
                    mQry += " [" & Col_PublicationYear & "], "
                    mQry += " [" & Col_Pages & "], "
                    mQry += " [" & Col_MRP & "], "
                    mQry += " [" & Col_Rate & "], "
                    mQry += " [" & Col_CallNo & "], "
                    mQry += " [" & Col_Pages & "], "
                    mQry += " [" & Col_Almira & "], "
                    mQry += " [" & Col_Shelf & "] "
                    MyCommand = New System.Data.OleDb.OleDbDataAdapter(mQry, MyConnection)
                    MyCommand.Fill(DsExcelData, "Table2")


                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select Distinct [" & VDate_Column & "]  from [sheet1$] Where [" & VDate_Column & "] Is Not Null", MyConnection)
                    MyCommand.Fill(DsExcelData, "Table3")

                    mUserAction = sender.text
                    Me.Dispose()
                Case BtnCancel.Name



                    mUserAction = sender.text
                    Me.Dispose()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FCheckExcelFile(ByVal mConn As OleDb.OleDbConnection)
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter = Nothing
        Dim DsTemp As New DataSet
        Dim I As Integer, J As Integer
        Dim mFieldExist As Boolean = False
        Try
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select *  from [sheet1$] Where 1=2", mConn)
            MyCommand.Fill(DsTemp)

            For I = 0 To Dgl1.Rows.Count - 1
                mFieldExist = False
                For J = 0 To DsTemp.Tables(0).Columns.Count - 1
                    If AgL.StrCmp(Dgl1.Item(1, I).Value, DsTemp.Tables(0).Columns(J).ColumnName) Then
                        mFieldExist = True
                        Exit For
                    End If
                Next

                If mFieldExist = False Then
                    Dgl1.Item("CFieldName", I).Value = "1"
                End If
            Next

            Dim StrMsg$ = ""
            For I = 0 To Dgl1.Rows.Count - 1
                If AgL.StrCmp(Dgl1.Item("CFieldName", I).Value, "1") Then
                    If StrMsg.ToString.Length <> 0 Then StrMsg += ", "
                    StrMsg += Dgl1.Item(1, I).Value
                End If
            Next
            If StrMsg.ToString.Length > 0 Then
                MsgBox(StrMsg & " - Fields not found in excel file. Please Select Correct File. ")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'DsTemp.Dispose()
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim FileName As String = ""
            FileName = GetFileName()
            ExportExcel(FileName, 1)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GetFileName(Optional ByVal FilePath As String = "") As String
        Dim SaveFileDialogBox As SaveFileDialog
        Dim sFilePath As String = ""
        Try
            SaveFileDialogBox = New SaveFileDialog

            SaveFileDialogBox.Title = "File Name"
            SaveFileDialogBox.Filter = "Microsoft Excel Worksheet(*.xls)|*.xls|XLSX Files(*.xlsx)|*.xlsx"

            If FilePath.Trim = "" Then FilePath = My.Application.Info.DirectoryPath
            SaveFileDialogBox.InitialDirectory = FilePath
            SaveFileDialogBox.DefaultExt = "*.xls"
            SaveFileDialogBox.FilterIndex = 1


            SaveFileDialogBox.FileName = ""

            If SaveFileDialogBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Function

            sFilePath = SaveFileDialogBox.FileName
        Catch ex As Exception
        Finally
            GetFileName = sFilePath
        End Try
    End Function

    Private Sub ExportExcel(ByVal mFileName As String, ByVal hWnd As Integer)

        ' Choose the path, name, and extension for the Excel file
        Dim myFile As String = mFileName
        ' Open the file and write the headers
        Dim fs As New IO.StreamWriter(myFile, False)
        fs.WriteLine("<?xml version=""1.0""?>")
        fs.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
        fs.WriteLine("<ss:Workbook xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"">")

        'Create the styles for the worksheet
        fs.WriteLine("  <ss:Styles>")
        ' Style for the column headers
        fs.WriteLine("    <ss:Style ss:ID=""1"">")
        fs.WriteLine("      <ss:Font ss:Bold=""1""/>")
        fs.WriteLine("      <ss:Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" " & _
            "ss:WrapText=""1""/>")
        fs.WriteLine("      <ss:Interior ss:Color=""#C0C0C0"" ss:Pattern=""Solid""/>")
        fs.WriteLine("    </ss:Style>")
        ' Style for the column information
        fs.WriteLine("    <ss:Style ss:ID=""2"">")
        fs.WriteLine("      <ss:Alignment ss:Vertical=""Center"" ss:WrapText=""1""/>")
        fs.WriteLine("    </ss:Style>")
        fs.WriteLine("  </ss:Styles>")

        'Write the worksheet contents
        fs.WriteLine("<ss:Worksheet ss:Name=""Sheet1"">")
        fs.WriteLine("  <ss:Table>")
        For i As Integer = 0 To Dgl1.Rows.Count - 1
            If Dgl1.Item(1, i).Value <> "" Then
                fs.WriteLine("<ss:Column ss:AutoFitWidth=""1"" ss:Width=""70""/>")
            End If
        Next

        fs.WriteLine("    <ss:Row>")

        For i As Integer = 0 To Dgl1.Rows.Count - 1
            If Dgl1.Item(1, i).Value <> "" And Dgl1.Item(4, i).Value = "Yes" Then
                fs.WriteLine(String.Format("      <ss:Cell ss:StyleID=""1"">" & _
                    "<ss:Data ss:Type=""String""><Html:Font Html:Color=""#0000FF""><html:B><html:I>{0}</html:I></html:B></Html:Font></ss:Data></ss:Cell>", _
                    Dgl1.Item(1, i).Value))
            ElseIf Dgl1.Item(1, i).Value <> "" Then
                fs.WriteLine(String.Format("      <ss:Cell ss:StyleID=""1"">" & _
                       "<ss:Data ss:Type=""String"">{0}</ss:Data></ss:Cell>", _
                       Dgl1.Item(1, i).Value))
            End If
        Next

        fs.WriteLine("    </ss:Row>")


        '' Check for an empty row at the end due to Adding allowed on the DataGridView
        'Dim subtractBy As Integer, cellText As String
        'If Dgl1.AllowUserToAddRows = True Then subtractBy = 2 Else subtractBy = 1
        '' Write contents for each cell
        'For i As Integer = 0 To Dgl1.RowCount - subtractBy
        '    fs.WriteLine(String.Format("    <ss:Row ss:Height=""{0}"">", _
        '        Dgl1.Rows(i).Height))
        '    For intCol As Integer = 0 To Dgl1.Columns.Count - 1
        '        If Dgl1.Columns(intCol).Visible = True Then
        '            cellText = CStr(IIf(IsDBNull(Dgl1.Item(intCol, i).FormattedValue), "", Dgl1.Item(intCol, i).FormattedValue))
        '            ' Check for null cell and change it to empty to avoid error
        '            If cellText = vbNullString Then cellText = ""

        '            fs.WriteLine(String.Format("      <ss:Cell ss:StyleID=""2"">" & _
        '                "<ss:Data ss:Type=""String"">{0}</ss:Data></ss:Cell>", _
        '                cellText.ToString))
        '        End If
        '    Next
        '    fs.WriteLine("    </ss:Row>")
        'Next

        ' Close up the document
        fs.WriteLine("  </ss:Table>")
        fs.WriteLine("</ss:Worksheet>")
        fs.WriteLine("</ss:Workbook>")
        fs.Close()

        ' Open the file in Microsoft Excel
        ' 10 = SW_SHOWDEFAULT
        ShellEx(hWnd, "Open", myFile, "", "", 10)

    End Sub
End Class