Public Class Form1
    Dim MyStar As Star

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        If (MyStar Is Nothing) Then Return
        e.Graphics.TranslateTransform(CSng(PictureBox1.ClientSize.Width / 2), CSng(PictureBox1.ClientSize.Height / 2))
        e.Graphics.DrawEllipse(Pens.Red, -MyStar.Radius, -MyStar.Radius, 2 * MyStar.Radius, 2 * MyStar.Radius)
        For index = 0 To MyStar.AllVertices.GetUpperBound(0) - 1 Step 2
            e.Graphics.DrawLine(Pens.Blue, MyStar.AllVertices(index), MyStar.AllVertices(index + 1))
        Next

    End Sub

    Private Sub BuildUpButton_Click(sender As Object, e As EventArgs) Handles BuildUpButton.Click
        MyStar = New Star(CInt(N_NUD.Value), CInt(M_NUD.Value), R_NUD.Value)
        PictureBox1.Refresh()
    End Sub

    Private Sub N_NUD_ValueChanged(sender As Object, e As EventArgs) Handles N_NUD.ValueChanged
        M_NUD.Maximum = CInt(N_NUD.Value) \ 2
    End Sub
End Class
