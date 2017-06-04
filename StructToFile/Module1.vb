Imports System.Drawing
Imports System.Runtime.InteropServices

Module Module1

    Sub Main()
        Dim rect = New Rectangle(100, 100, 895, 471)
        Dim pt = New PointF(254.45, 66.64)
        Dim sz = New Size(172, 345)
        'StructToFile.IsLittleEndian = True
        Console.WriteLine("До сохранения:")
        PrintStruct(rect)
        PrintStruct(pt)
        PrintStruct(sz)
        Const path = "structs.dat"

        StructToFile.Write(rect, path)
        StructToFile.Write(pt, path)
        StructToFile.Write(sz, path)

        rect = New Rectangle()
        pt = New PointF()
        sz = New Size()

        rect = StructToFile.Read(Of Rectangle)(path)
        pt = StructToFile.Read(Of PointF)(path)
        sz = StructToFile.Read(Of Size)(path)

        Console.WriteLine("После чтения из файла:")
        PrintStruct(rect)
        PrintStruct(pt)
        PrintStruct(sz)

    End Sub

    Private Sub PrintStruct(Of TStruct As Structure)(struct As TStruct)
        Console.WriteLine(struct)
    End Sub
End Module

<StructLayout(LayoutKind.Explicit, Pack:=1)>
Structure Struct1
    Private _prop2 As Double

    Property Prop1() As Double
        Get
            Return _prop2
        End Get
        Set
            _prop2 = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("Prop1 = {0:f3}", Prop1)
    End Function
End Structure