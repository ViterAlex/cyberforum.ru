Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.IO
Module Helper
    ''' <summary>
    ''' Запись структуры в файл
    ''' </summary>
    ''' <typeparam name="T">Тип структруры</typeparam>
    ''' <param name="struct">Экземпляр структуры</param>
    ''' <param name="path">Путь к файлу</param>
    <Extension()>
    Public Sub WriteToFile(Of T As Structure)(ByVal struct As T, path As String)
        'Память, занимаемая структурой
        Dim s = Marshal.SizeOf(struct)
        'Выделение памяти под структуру
        Dim ptr = Marshal.AllocHGlobal(s)
        'Место, куда будем копировать структуру
        Dim bytes = New Byte(s-1) {}
        'Указатель на структуру
        Marshal.StructureToPtr(struct, ptr, False)
        'Копируем структуру в массив
        Marshal.Copy(ptr, bytes, 0, s)
        'Записываем байты в файл
        File.WriteAllBytes(path, bytes)
        'Освобождаем память
        Marshal.FreeHGlobal(ptr)
    End Sub

    ''' <summary>
    ''' Запись структуры в файл
    ''' </summary>
    ''' <typeparam name="T">Тип структруры</typeparam>
    ''' <param name="struct">Экземпляр структуры</param>
    ''' <param name="path">Путь к файлу</param>
    <Extension()>
    Public Sub WriteToFile(Of T As Structure)(ByVal struct As T, path As String, append As Boolean)
        If Not append Then
            struct.WriteToFile(path)
            Return
        End If
        Dim s = Marshal.SizeOf(struct)
        Dim ptr = Marshal.AllocHGlobal(s)
        Dim bytes = New Byte(s - 1) {}
        Marshal.StructureToPtr(struct, ptr, False)
        Marshal.Copy(ptr, bytes, 0, s)
        'Записываем байты в файл
        Using writer As New FileStream(path, FileMode.Open)
            'Переход в конец файла. -1, чтобы не учитывать EOF
            writer.Seek(writer.Length, SeekOrigin.Begin)
            writer.Write(bytes, 0, bytes.Length)
        End Using
        'Освобождаем память
        Marshal.FreeHGlobal(ptr)
    End Sub

    ''' <summary>
    ''' Чтение структуры из файла
    ''' </summary>
    ''' <typeparam name="T">Тип структуры</typeparam>
    ''' <param name="path">Путь к файлу</param>
    <Extension()>
    Public Function ReadFromFile(Of T As Structure)(path As String) As T
        Dim s = Marshal.SizeOf(GetType(T))
        Dim ptr = Marshal.AllocHGlobal(s)
        Dim bytes = File.ReadAllBytes(path)
        Marshal.Copy(bytes, 0, ptr, bytes.Length)
        Dim buff = DirectCast(Marshal.PtrToStructure(ptr, GetType(T)), T)
        Marshal.FreeHGlobal(ptr)
        Return buff
    End Function

    ''' <summary>
    ''' Чтение структуры из файла
    ''' </summary>
    ''' <typeparam name="T">Тип структуры</typeparam>
    ''' <param name="path">Путь к файлу</param>
    ''' <param name="offset">Смещение, по которому располагается структура</param>
    <Extension()>
    Public Function ReadFromFile(Of T As Structure)(path As String, offset As Long) As T
        Dim s = Marshal.SizeOf(GetType(T))
        Dim ptr = Marshal.AllocHGlobal(s)
        Dim bytes = New Byte(s - 1) {}
        Using reader As New FileStream(path, FileMode.Open)
            reader.Seek(offset, SeekOrigin.Begin)
            reader.Read(bytes, 0, s)
        End Using
        Marshal.Copy(bytes, 0, ptr, bytes.Length)
        Dim buff = DirectCast(Marshal.PtrToStructure(ptr, GetType(T)), T)
        Marshal.FreeHGlobal(ptr)
        Return buff
    End Function


End Module
