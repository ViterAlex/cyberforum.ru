Imports System.ComponentModel
Imports System.Windows.Forms.Design
Public Class UserControlDesigner
    Inherits ControlDesigner
    ''' <summary>
    ''' Последняя точка вставки контрола
    ''' </summary>
    Private Shared Property LastLocation() As Point
    ''' <summary>
    ''' Метод, вызываемый при добавлении нового экземпляра на форму
    ''' </summary>
    ''' <param name="defaultValues">Словарь со значениями по умолчанию</param>
    Public Overrides Sub InitializeNewComponent(defaultValues As IDictionary)
        MyBase.InitializeNewComponent(defaultValues)
        'Родительский элемент (форма, панель — всё, что может быть контейнером)
        Dim parent = DirectCast(defaultValues("Parent"), Control)
        'Если нет последней позиции, то она вычисляется так, чтобы контрол был в центре формы
        If LastLocation.IsEmpty Then
            Dim x = (parent.ClientSize.Width - Control.Width) \ 2
            Dim y = (parent.ClientSize.Height - Control.Height) \ 2
            LastLocation = New Point(x, y)
        Else
            'Если есть — то контрол вставляется со смещением от предыдущего на 20 пикселей
            LastLocation = New Point(LastLocation.X + 20, LastLocation.Y + 20)
        End If

        SetProp(Control, "Location", LastLocation, LastLocation.GetType())
    End Sub
    ''' <summary>
    ''' Установка значения свойства
    ''' </summary>
    ''' <param name="ctrl">Контрол</param>
    ''' <param name="prop">Имя свойства</param>
    ''' <param name="value">Новое значение</param>
    ''' <param name="valType">Тип свойства</param>
    Private Shared Sub SetProp(ctrl As Object, prop As String, value As Object, valType As Type)
        Dim propDesc As PropertyDescriptor = TypeDescriptor.GetProperties(ctrl)(prop)

        If propDesc IsNot Nothing AndAlso
           propDesc.PropertyType Is valType AndAlso
           Not propDesc.IsReadOnly AndAlso
           propDesc.IsBrowsable Then
            propDesc.SetValue(ctrl, value)
        End If
    End Sub
End Class

