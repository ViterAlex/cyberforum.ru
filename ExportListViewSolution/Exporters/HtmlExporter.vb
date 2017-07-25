Imports System.Windows.Forms
Imports Exporters

Public Class HtmlExporter
    Implements IExport

    Public Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False) Implements IExport.Save
        Throw New NotImplementedException()
    End Sub
End Class
