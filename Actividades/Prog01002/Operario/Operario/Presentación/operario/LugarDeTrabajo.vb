Public Class LugarDeTrabajo
    Private Sub LugarDeTrabajo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(lugares.Location, lugares.Size))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Principal.getInstancia.cargarPanel(Of MarcoPuerto)(MarcoPuerto.getInstancia)
    End Sub

    Private Sub lugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugares.SelectedIndexChanged
        If lugares.SelectedIndex < 0 Then
            Return
        End If
        Dim lugar = LRepo.LugarPorNombre(lugares.SelectedItem)
        nom.Text = lugar.Nombre
        ubi.Text = $"{lugar.Posicion.X:F1}, {lugar.Posicion.Y:F1}"
    End Sub

    Private Sub LugarDeTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lugares.Items.Clear()
        lugares.Items.AddRange(URepo.LugaresTrabaja.Select(Function(x) x.Nombre).ToArray)
    End Sub
End Class