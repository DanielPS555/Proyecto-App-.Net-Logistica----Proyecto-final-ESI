Public Class LugarDeTrabajo
    Private Sub LugarDeTrabajo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(lugares.Location, lugares.Size))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Principal.getInstancia.cargarPanel(Of MarcoPuerto)(MarcoPuerto.getInstancia)
    End Sub

    Private Sub lugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugares.SelectedIndexChanged
        'cuando haya objetos de tipo lugar se puede cargar la informacion de la derecha por cada uno en este metodo
    End Sub
End Class