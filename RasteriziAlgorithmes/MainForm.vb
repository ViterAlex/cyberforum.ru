Imports System.Drawing.Drawing2D

Public Class MainForm
#Region " Алгоритм "
    'Реализация алгоритма Брезенхайма
    'https://habrahabr.ru/post/185086/
    Private Shared Iterator Function BresenhamPoints(pt1 As Point, pt2 As Point, w As Integer) As IEnumerable(Of Point)
        Dim x0 = pt1.X, y0 = pt1.Y, x1 = pt2.X, y1 = pt2.Y
        Dim dir = Math.Abs(y1 - y0) > Math.Abs(x1 - x0)
        If dir Then
            Swap(x0, y0)
            Swap(x1, y1)
        End If
        If x0 > x1 Then
            Swap(x0, x1)
            Swap(y0, y1)
        End If
        Dim dx = x1 - x0, dy = Math.Abs(y1 - y0)
        Dim signY = Math.Sign(y1 - y0)
        Dim y = y0
        Dim err = dx >> 1
        For x = x0 To x1 Step w
            Yield New Point(IIf(dir, y, x), IIf(dir, x, y))
            err -= dy
            If err < 0 Then
                y += signY * w
                err += dx
            End If
        Next
    End Function

    'Обмен значений между переменными
    Private Shared Sub Swap(ByRef x0 As Integer, ByRef y0 As Integer)
        Dim temp = x0
        x0 = y0
        y0 = temp
    End Sub

    'Реализация алгоритма ЦДА
    Private Shared Iterator Function DdaPoints(pt1 As Point, pt2 As Point, w As Integer) As IEnumerable(Of Point)
        Dim x0 = pt1.X, y0 = pt1.Y, x1 = pt2.X, y1 = pt2.Y
        Dim dir = Math.Abs(y1 - y0) > Math.Abs(x1 - x0)
        If dir Then
            Swap(x0, y0)
            Swap(x1, y1)
        End If
        If x0 > x1 Then
            Swap(x0, x1)
            Swap(y0, y1)
        End If
        Dim l = Math.Max(x1 - x0, y1 - y0) + 1.0F
        Dim x As Single = x0, y As Single = y0
        Dim dx = Math.Abs(x1 - x0) * w / l, dy = Math.Abs(y1 - y0) * w / l
        Dim signX = Math.Sign(x1 - x0)
        Dim signY = Math.Sign(y1 - y0)
        For i = 0 To l Step w
            Yield New Point(IIf(dir, y, x), IIf(dir, x, y))
            x += signX * dx : y += signY * dy
        Next
    End Function
#End Region

#Region " Поля "
    Private _width As Integer
    'Переменная со ссылкой на алгоритм
    Private _alg As Func(Of Point, Point, Integer, IEnumerable(Of Point))
    Private _grid As GraphicsPath
    'Первая точка прямой
    Private _firstPoint As Point
    'Вторая точка прямой
    Private _secondPoint As Point
    'Режим указания точек прямой
    Private _pointMode As Boolean
    Private ReadOnly _gridPen = New Pen(Color.Black, 1) With {.DashStyle = DashStyle.Dash}
    Private ReadOnly _algs = New List(Of Func(Of Point, Point, Integer, IEnumerable(Of Point))) _
        (New Func(Of Point, Point, Integer, IEnumerable(Of Point))() {
                                                                         AddressOf BresenhamPoints,
                                                                         AddressOf DdaPoints
                                                                     }
         )

#End Region

#Region " События формы "
    'Рисование с алгоритмом
    Private Sub Bresenham_Paint(sender As Object, e As PaintEventArgs)
        'Если точек нет — выходим
        If _firstPoint.IsEmpty OrElse _secondPoint.IsEmpty Then Return
        'Если функция алгоритма не задана — выходим
        If _alg Is Nothing Then Return
        'Получаем точки растра по выбранному алгоритму
        Dim list = _alg(_firstPoint, _secondPoint, _width).ToList()
        Using fillBrush As New SolidBrush(Color.FromArgb(80, 255, 255, 0))
            'Для каждой точки растра делаем заливку соответствующего квадрата
            list.ForEach(Sub(point)
                             Dim x = point.X \ _width
                             Dim y = point.Y \ _width
                             x *= _width
                             y *= _width
                             e.Graphics.FillRectangle(fillBrush, x, y, _width, _width)
                             e.Graphics.DrawRectangle(Pens.Red, x, y, _width, _width)
                         End Sub)
        End Using
        'Рисуем саму линию
        e.Graphics.DrawLine(Pens.Blue, _firstPoint, _secondPoint)
    End Sub


    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        _firstPoint = e.Location
        _pointMode = True
        RemoveHandler Panel1.Paint, AddressOf Bresenham_Paint
        AddHandler Panel1.Paint, AddressOf MouseMovePaint
    End Sub

    'Рисование линии при указании точек прямой
    Private Sub MouseMovePaint(sender As Object, e As PaintEventArgs)
        e.Graphics.DrawLine(Pens.Green, _firstPoint, _secondPoint)
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        RemoveHandler Panel1.Paint, AddressOf MouseMovePaint
        AddHandler Panel1.Paint, AddressOf Bresenham_Paint
        _pointMode = False
        _width = NumericUpDown1.Value
        Panel1.Invalidate()
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If Not _pointMode Then
            Return
        End If
        _secondPoint = e.Location
        Panel1.Invalidate()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        _width = NumericUpDown1.Value
        CreateGrid()
        Panel1.Invalidate()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        _alg = _algs(ComboBox1.SelectedIndex)
        Panel1.Invalidate()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Panel1_SizeChanged(sender As Object, e As EventArgs) Handles Panel1.SizeChanged
        If (_width = 0) Then Return
        CreateGrid()
        Panel1.Invalidate()
    End Sub

    'Основной метод прорисовки панели. В нём просто рисуем сетку
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        'Рисуем сетку
        e.Graphics.DrawPath(_gridPen, _grid)
    End Sub
#End Region

    'создание сетки
    Private Sub CreateGrid()
        _grid = New GraphicsPath()
        For i = _width To Panel1.ClientSize.Width Step _width
            _grid.StartFigure()
            _grid.AddLine(i, 0, i, Panel1.ClientSize.Height)
            _grid.CloseFigure()
        Next
        For i = _width To Panel1.ClientSize.Height Step _width
            _grid.StartFigure()
            _grid.AddLine(0, i, Panel1.ClientSize.Width, i)
            _grid.CloseFigure()
        Next
    End Sub
End Class
