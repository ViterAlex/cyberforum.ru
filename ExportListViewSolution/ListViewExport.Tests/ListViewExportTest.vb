Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Validation
Imports Expoters

<TestClass()>
Public Class ListViewExportTest
    Private exporter As IExport
    Private Shared _listView As ListView


    <ClassInitialize>
    Public Shared Sub Init(context As TestContext)
        _listView = New ListView() With {.View = View.Details}
        Dim rnd = New Random(DateTime.Now.Millisecond)
        Dim itemsCount = rnd.Next(10, 25)
        Dim subitemsCount = rnd.Next(4, 10)

        For i = 1 To itemsCount
            Dim lvi = New ListViewItem($"Items{i}")
            For j = 1 To subitemsCount
                lvi.SubItems.Add($"{lvi.Text}_SubItem{j}")
            Next
            _listView.Items.Add(lvi)
        Next
        For i = 0 To subitemsCount
            _listView.Columns.Add($"Column{i}")
        Next
    End Sub

    <ClassCleanup>
    Public Shared Sub Cleanup()
        _listView.Dispose()
    End Sub

    <TestMethod()>
    Public Sub WordExporterTest()
        Try
            exporter = New WordExporter()
            exporter.Save("wordExport.docx", _listView)
            Debug.WriteLine(Path.GetFullPath("wordExport.docx"))
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
        Dim validator = New OpenXmlValidator()
        Assert.AreEqual(0, validator.Validate(WordprocessingDocument.Open("wordExport.docx", False)).Count())
    End Sub

    <TestMethod()>
    Public Sub ExcelExporterTest()
        Try
            exporter = New ExcelExporter()
            exporter.Save("excelExport.xlsx", _listView)
            Debug.WriteLine(Path.GetFullPath("excelExport.xlsx"))
        Catch ex As Exception
            Assert.Fail(ex.Message)
        End Try
        Dim validator = New OpenXmlValidator()
        Assert.AreEqual(0, validator.Validate(SpreadsheetDocument.Open("excelExport.xlsx", False)).Count())
    End Sub

End Class