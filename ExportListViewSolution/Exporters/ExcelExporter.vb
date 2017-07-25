Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Text
Imports System.Drawing

Public Class ExcelExporter
    Inherits ExporterBase

    Public Overrides Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False)
        MyBase.Save(path, lvw, exportHeaders)
        CreatePackage(path)
    End Sub


    Public Sub CreatePackage(filePath As String)
        Using package As SpreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook)
            CreateParts(package)
        End Using
    End Sub

    Private Sub CreateParts(document As SpreadsheetDocument)
        Dim wbPart As WorkbookPart = document.AddWorkbookPart()
        GenerateWorkbookPartContent(wbPart)

        GenerateWorkbookStylesPart1Content(wbPart.AddNewPart(Of WorkbookStylesPart)("rId3"))

        GenerateWorksheetPartContent(wbPart.AddNewPart(Of WorksheetPart)("rId1"))

        GenerateSharedStringTablePartContent(wbPart.AddNewPart(Of SharedStringTablePart)("rId4"))
    End Sub

    Private Sub GenerateWorkbookPartContent(workbookPart1 As WorkbookPart)
        workbookPart1.Workbook = New Workbook() With {
                .MCAttributes = New MarkupCompatibilityAttributes() With {
                    .Ignorable = "x15"
                }
            }
        With workbookPart1.Workbook

            .AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships")
            .AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
            .AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main")

            .AppendChild(New Sheets()).Append(New Sheet() With {
                .Name = "Лист1",
                .SheetId = 1,
                .Id = "rId1"
            })

        End With
    End Sub

    Private Sub GenerateWorkbookStylesPart1Content(workbookStylesPart1 As WorkbookStylesPart)
        workbookStylesPart1.Stylesheet = New Stylesheet() With {
                .MCAttributes = New MarkupCompatibilityAttributes() With {
                    .Ignorable = "x14ac x16r2"
                }
            }
        With workbookStylesPart1.Stylesheet
            .AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
            .AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac")
            .AddNamespaceDeclaration("x16r2", "http://schemas.microsoft.com/office/spreadsheetml/2015/02/main")
        End With
    End Sub

    Private Sub GenerateWorksheetPartContent(wsPart As WorksheetPart)
        wsPart.Worksheet = New Worksheet() With {
                .MCAttributes = New MarkupCompatibilityAttributes() With {
                    .Ignorable = "x14ac"
                }
            }
        Dim cols As Columns
        Dim shData As SheetData

        With wsPart.Worksheet

            .AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships")
            .AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006")
            .AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac")

            .Append(New SheetFormatProperties() With {
                .DefaultRowHeight = 15.0,
                .DyDescent = 0.25
            })

            cols = .AppendChild(New Columns())
            shData = .AppendChild(New SheetData())
        End With

        'Считаем максимальное количество символов в столбце
        Dim colMaxTextLen = New Single(_listView.Columns.Count - 1) {}
        'Счётчик строк и столбцов
        Dim rowCounter, colCounter As Integer
        If _exportHeaders Then
            rowCounter = AddHeader(shData)
        End If

        For Each lvi As ListViewItem In _listView.Items
            rowCounter += 1
            colCounter = 0
            'Добавляем строку
            Dim r = shData.AppendChild(New Row() With {
                .RowIndex = rowCounter
                })

            For Each lvsi As ListViewItem.ListViewSubItem In lvi.SubItems
                'Добавляем ячейку с текстом
                r.AppendChild(New Cell() With {
                    .CellReference = GetColumnCaption(rowCounter, colCounter),
                    .DataType = CellValues.InlineString
                }) _
                .AppendChild(New InlineString()).Append(New Text(lvsi.Text))
                'Записываем максимальное количество символов в столбце
                If colMaxTextLen(colCounter) < lvsi.Text.Length Then
                    colMaxTextLen(colCounter) = lvsi.Text.Length
                End If
                colCounter += 1
            Next
        Next
        'Задаём ширины столбцов
        For i = 0 To colMaxTextLen.Count - 1
            cols.Append(New Column With {
                            .Min = i + 1,
                            .Max = i + 1,
                            .CustomWidth = True,
                            .Width = GetWidth(colMaxTextLen(i))
                        })
        Next

    End Sub

    'Добавление строки с заголовками
    Private Function AddHeader(shData As SheetData) As Integer
        Dim r = shData.AppendChild(New Row() With {
            .RowIndex = 1
            })
        For Each ch As ColumnHeader In _listView.Columns
            r.AppendChild(New Cell() With {
                    .CellReference = GetColumnCaption(1, ch.Index),
                    .DataType = CellValues.InlineString
                }) _
                .AppendChild(New InlineString()).Append(New Text(ch.Text))
        Next

        Return 1
    End Function

    Private Sub GenerateSharedStringTablePartContent(sharedStringTablePart1 As SharedStringTablePart)
        sharedStringTablePart1.SharedStringTable = New SharedStringTable()
    End Sub

    'Вычисление ширины столбца в зависимости от длины текста
    Private Shared Function GetWidth(textLen As Single) As Single
        Dim maxW = TextRenderer.MeasureText("W", SystemFonts.DefaultFont).Width
        Dim w = System.Math.Truncate(((textLen * maxW + 5.0F) / maxW * 256.0F) / 256.0F)
        Return w + 2
    End Function

    'Адрес ячейки по номеру строки и столбца
    Private Shared Function GetColumnCaption(row As Integer, col As Integer) As String
        Dim sb = New StringBuilder()
        sb.Insert(0, ChrW(col Mod 26 + 65))
        col /= 26
        While col <> 0
            sb.Insert(0, ChrW(col Mod 26 - 1 + 65))
            col /= 26
        End While
        Return $"{sb}{row}"
    End Function
End Class
