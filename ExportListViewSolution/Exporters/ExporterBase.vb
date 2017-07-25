Imports System.Windows.Forms

Public MustInherit Class ExporterBase
    Implements IExport
    Friend _listView As ListView
    Friend _exportHeaders As Boolean

    Public Overridable Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False) Implements IExport.Save
        _listView = lvw
        _exportHeaders = exportHeaders
    End Sub
End Class
