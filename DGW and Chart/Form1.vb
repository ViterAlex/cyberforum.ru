Public Class Form1
    Dim a As Double = 0.00001
    Dim R As Double = 8.31
    Dim h As Double = 0.0001

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p() As Double = New Double(4) {0.1, 1.0, 1.5, 2, 3}
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn() {New DataColumn("Аргумент", GetType(Integer)), New DataColumn("Функция", GetType(Double))})

        For i As Integer = 0 To 4
            dt.Rows.Add(i, (9 * R / p(i) ^ 3) * simps(a, p(i), h))
        Next
        DataGridView1.DataSource = dt
        With DataGridView1.Columns(1)
            .DefaultCellStyle.Format = "f5"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Chart1
            .Series.Clear()
            .Legends.Clear()
            With .Series.Add("function")
                .ChartType = DataVisualization.Charting.SeriesChartType.Spline
                .XValueMember = "Аргумент"
                .YValueMembers = "Функция"
            End With
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Function f(ByRef x As Double) As Double
        Return x ^ 4 * (Math.Exp(x) / (Math.Exp(x) - 1) ^ 2)
    End Function

    Function simps(ByRef a As Double, ByRef b As Double, ByRef n As Double) As Double
        Dim h As Double, s1 As Double, s2 As Double
        s1 = 0
        For i As Double = a To b
            s1 = s1 + f(h * i + a)
        Next i
        s2 = 0
        For i = 2 To n - 2
            s2 = s2 + f(h * i - 0.5 * h + a)
        Next i
        Return (h / 3) * 0.5 * f(a) + s1 + (2 * s2) + 0.5 * f(b)
    End Function
End Class
