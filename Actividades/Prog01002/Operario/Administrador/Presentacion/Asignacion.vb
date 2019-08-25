Imports Controladores
Imports Operario

Public Class Asignacion
    Implements NotificacionLote
    Private lotesDisponibles As New List(Of Controladores.Lote)
    Private LoteFinal As Controladores.Lote
    Private vehiculo As Controladores.Vehiculo
    Private zonasDisponibles As List(Of Controladores.Zona)
    Public Sub New(vin As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        vehiculo = Controladores.Fachada.getInstancia.DevolverDatosBasicosPorVIN_Vehiculo(vin)
        cargarZonas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub cargarZonas()
        Controladores.Fachada.getInstancia().CargarTrabajaEnConLugarZonasySubzonas()
        zonas.Items.Clear()

        For Each z As Controladores.Zona In Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.Zonas
            zonas.Items.Add(z.Nombre)
        Next

        zonasDisponibles = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.Zonas
        zonas.SelectedIndex = 0
    End Sub

    Public Sub cargarLotes()
        lote.Items.Clear()
        lotesDisponibles = Controladores.Fachada.getInstancia.LotesDisponiblesPorLugarActual()
        For Each l As Controladores.Lote In lotesDisponibles
            lote.Items.Add("Nom: " & l.Nombre & "ID: " & l.IDLote)
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
        For Each su As Controladores.Subzona In zonasDisponibles(zonas.SelectedIndex).Subzonas
            subzonas.Items.Add(su.Nombre)
        Next
        subzonas.SelectedIndex = 0
    End Sub

    Private Sub Subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        posDis.Items.Clear()
        Dim posi As List(Of Integer) = Controladores.Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex))
        For i As Integer = 1 To zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex).Capasidad
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
            Fachada.getInstancia.insertIntegra(LoteFinal, vehiculo, Fachada.getInstancia.TrabajaEnAcutual.Usuario, False)
        Else
            If lote.SelectedIndex = -1 Then
                MsgBox("Debe selecionar un lote, sino hay cree uno")
            Else
                Fachada.getInstancia.insertIntegra(lotesDisponibles(lote.SelectedIndex), vehiculo, Fachada.getInstancia.TrabajaEnAcutual.Usuario, False)
            End If
        End If

        Fachada.getInstancia.AsignarNuevaPosicion(New Posicion() With {.Subzona = zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex),
                                                  .Posicion = posDis.SelectedItem,
                                                  .IngresadoPor = Fachada.getInstancia.TrabajaEnAcutual.Usuario,
                                                  .Desde = DateTime.Now,
                                                  .Vehiculo = vehiculo}, False)
        Marco.getInstancia.cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
        Me.Close()
    End Sub
End Class