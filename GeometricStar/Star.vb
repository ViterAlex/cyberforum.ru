Public Class Star
    Private _verticesCount As Integer
    Private _step As Integer
    Private _radius As Single
    Public ReadOnly Property Radius As Single
        Get
            Return _radius
        End Get
    End Property

    Private _allVertices As PointF()
    Public ReadOnly Property AllVertices() As PointF()
        Get
            Return _allVertices
        End Get
    End Property
    ''' <summary>
    ''' Создание нового экземпляра класса Star с заданным количеством вершин, шагом и радиусом
    ''' </summary>
    ''' <param name="n">Количество вершин звезды</param>
    ''' <param name="m">Шаг соединения вершин между собой</param>
    ''' <param name="radius">Радиус описанной окружности</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal n As Integer, ByVal m As Integer, ByVal radius As Single)
        _verticesCount = n
        _step = m
        _radius = radius
        CreateVertices()
    End Sub

    Private Sub CreateVertices()
        Dim _polygonVertices() As PointF = New PointF(_verticesCount - 1) {}
        'Определение вершин многоугольника
        For i = 0 To _verticesCount - 1
            _polygonVertices(i) = New PointF(CSng(_radius * Math.Cos(2 * Math.PI * i / _verticesCount)), CSng(_radius * Math.Sin(2 * Math.PI * i / _verticesCount)))
        Next
        _allVertices = New PointF(2 * _verticesCount - 1) {}
        Dim n As Integer
        For i = 0 To _verticesCount - 1
            n = i + _step
            If (n > _verticesCount - 1) Then n = n - _verticesCount
            _allVertices(i * 2) = _polygonVertices(i)
            _allVertices(i * 2 + 1) = _polygonVertices(n)
        Next

    End Sub
End Class
