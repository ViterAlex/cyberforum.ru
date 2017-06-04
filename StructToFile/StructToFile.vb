Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class StructToFile

    Private Shared _writeOffset As Long
    Private Shared _readOffset As Long
    Private Shared _prevWritePath As String
    Private Shared _prevReadPath As String

    Public Shared Property IsLittleEndian() As Boolean

    Public Shared Sub Reset()
        _writeOffset = 0
        _readOffset = 0
        _prevWritePath = String.Empty
        _prevReadPath = String.Empty
    End Sub
    ''' <summary>
    ''' Запись структуры в файл
    ''' </summary>
    Public Shared Sub Write(Of TStruct As Structure)(struct As TStruct, path As String)
        If Not path.Equals(_prevWritePath) Then
            _writeOffset = 0
        End If
        _prevWritePath = path
        _writeOffset = WriteStruct(struct, path)
    End Sub
    ''' <summary>
    ''' Чтение структуры из файла
    ''' </summary>
    Public Shared Function Read(Of TStruct As Structure)(path As String) As TStruct
        If Not path.Equals(_prevReadPath) Then
            _readOffset = 0
        End If
        _prevReadPath = path
        Return ReadStruct(Of TStruct)(path)
    End Function

    Private Shared Function WriteStruct(Of TStruct As Structure)(struct As TStruct, path As String) As Long
        Dim bytes = StructToBytes(struct, IsLittleEndian)
        Dim result As Long = -1
        Using writer As New FileStream(path, FileMode.OpenOrCreate)
            writer.Seek(_writeOffset, SeekOrigin.Begin)
            writer.Write(bytes, 0, bytes.Length)
            result = writer.Position
        End Using
        'Освобождаем память
        Return result
    End Function

    Private Shared Function ReadStruct(Of TStruct As Structure)(path As String) As TStruct
        Dim bytes = New Byte(Marshal.SizeOf(GetType(TStruct)) - 1) {}

        Using reader As New FileStream(path, FileMode.Open)
            reader.Seek(_readOffset, SeekOrigin.Begin)
            reader.Read(bytes, 0, bytes.Length)
            _readOffset = reader.Position
        End Using

        Return BytesToStruct(Of TStruct)(bytes, IsLittleEndian)
    End Function
    ''' <summary>
    ''' Выставление очередности байт
    ''' </summary>
    Private Shared Sub AdjustEndianness([type] As Type, ByRef bytes As Byte(), Optional isLe As Boolean = False, Optional startOffset As Integer = 0)
        If Not isLe Then
            Return
        End If
        'Размер структуры определяется открытыми и закрытыми нестатическими полями
        Const flags As BindingFlags = BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Instance
        'Перебор всех полей в типе. Для каждого поля определяем смещение и в массиве переворачиваем соответствующий блок
        For Each field As FieldInfo In type.GetFields(flags)
            Dim fieldType = field.FieldType
            If field.IsStatic Then Continue For
            If fieldType = GetType(String) Then Continue For

            Dim offset = Marshal.OffsetOf(type, field.Name).ToInt32()

            If fieldType.IsEnum Then fieldType = [Enum].GetUnderlyingType(fieldType)

            Dim subFields = fieldType.GetFields(flags).Where(Function(info) Not info.IsStatic).ToArray()

            Dim effectiveOffset = startOffset + offset
            If subFields.Length = 0 Then
                Array.Reverse(bytes, effectiveOffset, Marshal.SizeOf(fieldType))
            Else
                AdjustEndianness(fieldType, bytes, isLe, effectiveOffset)
            End If
        Next
    End Sub
    ''' <summary>
    ''' Массив байт в структуру с учётом порядка байт
    ''' </summary>
    Public Shared Function BytesToStruct(Of TStruct As Structure)(bytes As Byte(), isLe As Boolean) As TStruct
        Dim result As New TStruct()
        AdjustEndianness(GetType(TStruct), bytes, isLe)
        Dim ptr = GCHandle.Alloc(bytes, GCHandleType.Pinned)
        Try
            Dim rawDataPtr = ptr.AddrOfPinnedObject()
            result = DirectCast(Marshal.PtrToStructure(rawDataPtr, GetType(TStruct)), TStruct)
        Catch ex As Exception
            Throw
        Finally
            ptr.Free()
        End Try
        Return result
    End Function
    ''' <summary>
    ''' Структура в массив байт с учётом порядка байт
    ''' </summary>
    Public Shared Function StructToBytes(Of TStruct As Structure)(struct As TStruct, isLe As Boolean) As Byte()
        Dim result = New Byte(Marshal.SizeOf(GetType(TStruct)) - 1) {}
        Dim ptr = GCHandle.Alloc(result, GCHandleType.Pinned)
        Try
            Dim rawDataPtr = ptr.AddrOfPinnedObject()
            Marshal.StructureToPtr(struct, rawDataPtr, False)
        Catch ex As Exception
            Throw
        Finally
            ptr.Free()
        End Try
        AdjustEndianness(GetType(TStruct), result, isLe)
        Return result
    End Function

End Class
