Imports System.Windows.Forms
Public Class TrasladoInterno
    Private posicion As Controladores.Posicion
    Private idvehiculo As Integer
    Private papote As panelInfoVehiculo
    Private lugar As Controladores.Lugar

    Public Sub New(idvehiculo As Integer, padre As panelInfoVehiculo)
        Me.idvehiculo = idvehiculo

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        StartPosition = FormStartPosition.CenterScreen
        papote = padre
        Dim posi As Controladores.Posicion = Controladores.Fachada.getInstancia.DevolverPosicionActual(idvehiculo)
        Me.posicion = posi
        Dim zona As String = posi.Subzona.ZonaPadre.Nombre
        If zona Is Nothing Then zona = "---"
        DeZona.Text = zona
        Dim subzona As String = posi.Subzona.Nombre
        If subzona Is Nothing Then subzona = "---"
        deSubzona.Text = subzona
        Dim posicion As Integer? = posi.Posicion
        If posicion Is Nothing Then posicion = -1
        dePosicion.Text = posicion

        lugar = posi.Subzona.ZonaPadre.LugarPadre
        haciaZona.Items.Clear()
        For Each z As Controladores.Zona In Controladores.Fachada.getInstancia.LugarZonasySubzonas(lugar.IDLugar, lugar).Zonas
            haciaZona.Items.Add(z)
        Next
        haciaZona.SelectedIndex = 0
    End Sub

    Private Sub haciaZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaZona.SelectedIndexChanged
        haciaSubzona.Items.Clear()
        If haciaZona.SelectedIndex < 0 Then Return
        For Each su As Controladores.Subzona In haciaZona.SelectedItem.Subzonas
            haciaSubzona.Items.Add(su)
        Next
        haciaSubzona.SelectedIndex = 0
    End Sub

    Private Sub haciaSubzona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles haciaSubzona.SelectedIndexChanged
        haciaPosicion.Items.Clear()
        If haciaSubzona.SelectedIndex < 0 Then Return
        Dim posi As List(Of Integer) = Controladores.Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(haciaSubzona.SelectedItem)
        For i As Integer = 1 To haciaSubzona.SelectedItem.Capasidad
            If Not posi.Contains(i) Then
                haciaPosicion.Items.Add(i)
            End If
        Next
        haciaPosicion.SelectedIndex = 0
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        Dim posicionFinal As New Controladores.Posicion With {
            .Subzona = haciaSubzona.SelectedItem,
            .Posicion = haciaPosicion.SelectedItem,
            .Desde = Date.Now,
            .Vehiculo = New Controladores.Vehiculo() With {.IdVehiculo = idvehiculo},
            .IngresadoPor = Controladores.Fachada.getInstancia.DevolverUsuarioActual
        }
        Controladores.Fachada.getInstancia.AsignarNuevaPosicion(posicionFinal, True)
        papote.actualizarTrasportesDeFormaExterna()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class