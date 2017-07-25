Imports System.Windows.Forms
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class WordExporter
    Implements IExport
    'Границы таблицы
    Private ReadOnly _tableBorders As BorderType() =
    {
        New TopBorder() With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 12,
            .Space = 0
        },
        New LeftBorder() With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 12,
            .Space = 0
        },
        New BottomBorder() With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 12,
            .Space = 0
        },
        New RightBorder() With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 12,
            .Space = 0
        },
        New InsideHorizontalBorder With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 6,
            .Space = 0
        },
        New InsideVerticalBorder With
        {
            .Val = BorderValues.Single,
            .Color = "auto",
            .Size = 6,
            .Space = 0
        }
    }
    Private _listView As ListView
    Private _exportHeaders As Boolean
    ''' <summary>
    ''' Экспорт в документ docx
    ''' </summary>
    ''' <param name="path">Путь к документу</param>
    ''' <param name="lvw">ListView, который нужно экспортировать</param>
    ''' <param name="exportHeaders">Нужно ли экспортировать заголовки</param>
    Public Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False) Implements IExport.Save
        _listView = lvw
        _exportHeaders = exportHeaders
        CreatePackage(path)
    End Sub
    'Создание документа
    Private Sub CreatePackage(filePath As String)
        Using package As WordprocessingDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document)
            CreateParts(package)
        End Using
    End Sub

    Private Sub CreateParts(document As WordprocessingDocument)
        Dim documentPart As MainDocumentPart = document.AddMainDocumentPart()
        GenerateMainDocumentPartContent(documentPart)
    End Sub

    'Генерирование содержимого документа
    Private Sub GenerateMainDocumentPartContent(documentPart As MainDocumentPart)
#Region " Минимальный набор данных для документа"

        Dim doc = New Document() With
        {
            .MCAttributes = New MarkupCompatibilityAttributes() With
            {
                .Ignorable = "w14 w15 w16se wp14"
            }
        }
        doc.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing")
        doc.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main")
        doc.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml")
        doc.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml")
        doc.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex")
#End Region
        'К документу добавляем тело, к телу таблицу
        Dim tbl = doc.AppendChild(New Body()).AppendChild(New Table())

        With tbl.AppendChild(New TableProperties())
            'Добавляем границы таблицы
            .Append(New TableBorders(_tableBorders))

            'Добавляем отступы по умолчанию в ячейках таблицы 
            .Append(New TableCellMarginDefault With
            {
                .TableCellLeftMargin = New TableCellLeftMargin With
                {
                    .Width = CentimetersToPoints(0.2F),
                    .Type = TableWidthValues.Dxa
                },
                .TableCellRightMargin = New TableCellRightMargin With
                {
                    .Width = CentimetersToPoints(0.2F),
                    .Type = TableWidthValues.Dxa
                }
            })
        End With

        'Столбцы таблицы
        With tbl.AppendChild(New TableGrid())
            For i = 0 To _listView.Columns.Count - 1
                .Append(New GridColumn())
            Next
        End With

        'Если нужно — добавляем в таблицу первую строку с названиями столбцов ListView
        If _exportHeaders Then
            tbl.Append(GetHeader)
        End If

        'Заполнение таблицы
        For Each lvi As ListViewItem In _listView.Items
            With tbl.AppendChild(New TableRow())
                For Each lvsi As ListViewItem.ListViewSubItem In lvi.SubItems
                    'в строку добавляем ячейку, в ячейку — абзац, в абзац — фрагмент, во фрагмент — текст
                    .AppendChild(New TableCell()) _
                    .AppendChild(New Paragraph()) _
                    .AppendChild(New Run()) _
                    .Append(New Text() With
                    {
                        .Text = lvsi.Text
                    })
                Next
            End With
        Next
        'Формирование документа

        documentPart.Document = doc

    End Sub

    'Создание строки-заголовка таблицы
    Private Function GetHeader() As TableRow
        Dim result As New TableRow()
        For Each ch As ColumnHeader In _listView.Columns
            'в строку добаляем ячейку
            With result.AppendChild(New TableCell()).AppendChild(New Paragraph())
                'в абзац добавляем выравнивание по центру
                .Append(New ParagraphProperties With
                {
                    .Justification = New Justification With
                    {
                        .Val = JustificationValues.Center
                    }
                })
                'И фрагмент с текстом
                .AppendChild(New Run()).Append(New Text With {.Text = ch.Text})
            End With
        Next
        Return result
    End Function

    'Перевод сантиметров в точки
    Private Function CentimetersToPoints(centimeters As Single) As String
        Return CInt(centimeters * 28.34646F).ToString()
    End Function
End Class
