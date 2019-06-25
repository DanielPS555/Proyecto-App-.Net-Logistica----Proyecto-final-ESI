Public Class LugarDeTrabajo
    Private Sub LugarDeTrabajo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(lugares.Location, lugares.Size))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not URepo.ConectarEn(lugares.SelectedItem) Then
            MsgBox("Hubo un error conectando al lugar. Cierre la aplicacion y vuelva a abrirla por favor")
        Else
            Principal.getInstancia.cargarPanel(Marco.getInstancia)
            Principal.getInstancia.cerrarPanel(Of LugarDeTrabajo)()
        End If
    End Sub

    Private Sub lugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugares.SelectedIndexChanged
        If lugares.SelectedIndex < 0 Then
            Button2.Enabled = False
            Return
        End If
        Button2.Enabled = True
        Dim lugar = LRepo.LugarPorNombre(lugares.SelectedItem)
        nom.Text = lugar.Nombre
        ubi.Text = $"{lugar.Posicion.X:F1}, {lugar.Posicion.Y:F1}"
        uConn.Text = URepo.UltimaConexionEn(lugar.Nombre).DarFormato
    End Sub

    Private Sub LugarDeTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lugares.Items.Clear()
        lugares.Items.AddRange(URepo.LugaresTrabaja.ToArray)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Principal.getInstancia.cerrarPanel(Of LugarDeTrabajo)()
    End Sub
End Class