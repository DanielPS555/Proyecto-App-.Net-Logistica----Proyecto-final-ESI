Public Class trasladoInterno
    Private Sub l_posDis_Click(sender As Object, e As EventArgs) Handles l_posDis.Click

    End Sub

    Private lugar As String = Nothing

    Private vin As String
    Private form As IActualizaMessage

    Public Sub New(VIN As String, form As IActualizaMessage)
        Me.vin = VIN
        Me.form = form
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim zona As String = VRepo.Zona(VIN)
        If zona Is Nothing Then zona = "---"
        DeZona.Text = VIN
        Dim subzona As String = VRepo.Subzona(VIN)
        If subzona Is Nothing Then subzona = "---"
        deSubzona.Text = subzona
        Dim posicion As Integer? = VRepo.Posicion(VIN)
        If posicion Is Nothing Then posicion = -1
        dePosicion.Text = posicion

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
        haciaPosicion.Items.Clear()
        If haciaSubzona.SelectedIndex < 0 Then Return
        haciaPosicion.Items.Clear()
        For i = 0 To LRepo.CapacidadSubzona(haciaSubzona.SelectedItem, haciaZona.SelectedItem, URepo.ConectadoEn)
            haciaPosicion.Items.Add(i)
        Next
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        If VRepo.Posicion(Me.vin, haciaZona.SelectedItem, haciaSubzona.SelectedItem, Me.lugar, Me.haciaPosicion.SelectedItem) Then
            form.Actualizar()
            Me.Close()
        Else
            MsgBox("No se pudo ingresar el vehículo. Intente nuevamente o reporte a su administrador")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class