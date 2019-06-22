Public Class trasladoInterno
    Private Sub l_posDis_Click(sender As Object, e As EventArgs) Handles l_posDis.Click

    End Sub

    Private lugar As String = Nothing

    Public Sub New(VIN As String)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DeZona.Text = VRepo.Zona(VIN)
        deSubzona.Text = VRepo.Subzona(VIN)
        dePosicion.Text = VRepo.Posicion(VIN)

        lugar = VRepo.Lugar(VIN)

        haciaZona.Items.Clear()
        haciaZona.Items.AddRange(LRepo.ZonasEnLugar(lugar).ToArray)
    End Sub

    Private Sub haciaZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaZona.SelectedIndexChanged
        haciaSubzona.Items.Clear()
        If haciaZona.SelectedIndex < 0 Then Return
        haciaSubzona.Items.AddRange(LRepo.SubzonasEnLugar(haciaZona.SelectedItem, lugar).ToArray)
    End Sub

    Private Sub haciaSubzona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaSubzona.SelectedIndexChanged

    End Sub
End Class