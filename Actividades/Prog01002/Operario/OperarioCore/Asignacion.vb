Imports Controladores
Imports System.Windows.Forms
Public Class Asignacion
    Implements NotificacionLote
    Private lotesDisponibles As New List(Of Lote)
    Private LoteFinal As Lote
    Private vehiculo As Vehiculo
    Private zonasDisponibles As List(Of Zona)
    Public Sub New(vin As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        vehiculo = Fachada.getInstancia.DevolverDatosBasicosPorVIN_Vehiculo(vin)
        CargarZonas()

    End Sub
    Private lugarvehiculo As Lugar
    Public Sub CargarZonas()
        Fachada.getInstancia().CargarTrabajaEnConLugarZonasySubzonas()
        lugarvehiculo = Fachada.getInstancia.DevolverPosicionActual(vehiculo.IdVehiculo).Subzona.ZonaPadre.LugarPadre
        zonas.Items.Clear()

        For Each z As Zona In lugarvehiculo.Zonas
            zonas.Items.Add(z)
        Next

        zonas.SelectedIndex = 0
    End Sub

    Public Sub CargarLotes()
        lote.Items.Clear()
        lotesDisponibles = Fachada.getInstancia.LotesDisponiblesPorLugar(lugarvehiculo)
        For Each l As Lote In lotesDisponibles
            lote.Items.Add(l)
        Next
        If lote.Items.Count > 0 Then
            lote.SelectedIndex = 0
        Else
            lote.Enabled = False
        End If
    End Sub

    Public Sub NotificarLote(lote As Lote) Implements NotificacionLote.NotificarLote
        LoteFinal = lote
        Me.lote.Enabled = False
        crearomodificarLote.Text = "Modifica lote"
        eliminarlote.Visible = True
    End Sub

    Public Function dameVehiculoalLote() As Object Implements NotificacionLote.dameVehiculoalLote
        Return vehiculo
    End Function

    Private Sub CrearomodificarLote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles crearomodificarLote.LinkClicked
        If LoteFinal Is Nothing Then
            Dim d As New NuevoLote(Me)
            d.ShowDialog()
        Else
            Dim d As New NuevoLote(Me, LoteFinal)
            d.ShowDialog()
        End If
    End Sub

    Private Sub Eliminarlote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles eliminarlote.LinkClicked
        If lote.SelectedIndex = -1 Then
            lote.Enabled = False
        Else
            lote.Enabled = True
        End If
        LoteFinal = Nothing
        eliminarlote.Visible = False
        crearomodificarLote.Text = "Crear lote"
    End Sub

    Private Sub Zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        subzonas.Items.Clear()
        For Each su As Subzona In DirectCast(zonas.SelectedItem, Zona).Subzonas
            subzonas.Items.Add(su.Nombre)
        Next
        subzonas.SelectedIndex = 0
    End Sub

    Private Sub Subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        posDis.Items.Clear()
        Dim posi As List(Of Integer) = Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(DirectCast(subzonas.SelectedItem, Subzona))
        For i As Integer = 1 To DirectCast(subzonas.SelectedItem, Subzona).Capasidad
            If Not posi.Contains(i) Then
                posDis.Items.Add(i)
            End If
        Next
        posDis.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
        Me.Close()
    End Sub

    Private Sub Ingresar_Click(sender As Object, e As EventArgs)

        If LoteFinal IsNot Nothing Then
            LoteFinal.IDLote = Fachada.getInstancia.nuevoLote(LoteFinal)
            Fachada.getInstancia.insertIntegra(LoteFinal, vehiculo, Fachada.getInstancia.DevolverUsuarioActual, False)
        Else
            If lote.SelectedIndex = -1 Then
                MsgBox("Debe selecionar un lote, sino hay cree uno")
            Else
                Fachada.getInstancia.insertIntegra(lotesDisponibles(lote.SelectedIndex), vehiculo, Fachada.getInstancia.DevolverUsuarioActual, False)
            End If
        End If

        Fachada.getInstancia.AsignarNuevaPosicion(New Posicion() With {.Subzona = subzonas.SelectedItem,
                                                  .Posicion = posDis.SelectedItem,
                                                  .IngresadoPor = Fachada.getInstancia.DevolverUsuarioActual,
                                                  .Desde = Date.Now,
                                                  .Vehiculo = vehiculo}, False)
        Marco.getInstancia.cargarPanel(New ListaVehiculos)
        Me.Close()
    End Sub
End Class