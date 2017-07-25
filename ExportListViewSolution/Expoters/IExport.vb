Imports System.Windows.Forms

Public Interface IExport
    Sub Save(path As String, lvw As ListView, Optional exportHeaders As Boolean = False)
End Interface
