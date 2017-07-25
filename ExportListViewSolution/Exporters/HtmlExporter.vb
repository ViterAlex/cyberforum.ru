Imports System.Windows.Forms

Public Class HtmlExporter
    Inherits ExporterBase

    Public Overrides Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False)
        MyBase.Save(path, lvw, exportHeaders)
    End Sub
End Class
