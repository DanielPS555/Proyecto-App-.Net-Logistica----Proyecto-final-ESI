Imports Controladores.Extenciones.Extensiones
Imports Controladores
Imports System.Windows.Forms
Imports System.Drawing
Public Class NuevoVehiculo
    Implements NotificacionLote

    Private clienteshabi As New List(Of Cliente)
    Private informe As InformeDeDaños
    Private LoteFinal As Lote

    Public Property Vehiculo As New Vehiculo()

    Private lote_s As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        loadClientes()
        CarcarComboBox()
        habilitar(True)
        loadClientes()

    End Sub


    Private Sub CarcarComboBox()
        tipo.Items.Clear()
        tipo.Items.AddRange(Vehiculo.TIPOS_VEHICULOS)
        tipo.SelectedIndex = 0
        anio.Items.Clear()
        For i As Integer = 1900 To Date.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedItem = Date.Now.Year

        Dim lugares = Fachada.getInstancia.listarTodosLosPuertos.ToList.Select(Function(x) Fachada.getInstancia.informacionBaseDelLugarPorIdlugar(x(0))).ToArray
        lugar.Items.Clear()
        lugar.Items.AddRange(lugares)
        lugar.SelectedIndex = -1
        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            lugar.Enabled = False
            lugar.SelectedIndex = Array.IndexOf(lugares, Fachada.getInstancia.TrabajaEnAcutual.Lugar)
        Else
            lugar.SelectedIndex = 0
        End If
    End Sub

    Private Sub loadLotes()
        lote.Items.Clear()

        For Each l As Lote In Fachada.getInstancia.LotesDisponiblesPorLugar(lugar.SelectedItem)
            lote.Items.Add(l)
        Next
        If lote.Items.Count > 0 Then
            lote.SelectedIndex = 0
        Else
            lote.Enabled = False
        End If
    End Sub

    Private Sub loadClientes()
        clientes.Items.Clear()
        clienteshabi = Controladores.Fachada.getInstancia.ClientesDelSistema()
        For Each ce As Controladores.Cliente In clienteshabi
            clientes.Items.Add(ce)
        Next
    End Sub

    Private Sub nuevoVehiculo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        For Each textCo In Me.Controls
            If TypeOf (textCo) Is TextBox Then
                Dim text As TextBox = DirectCast(textCo, TextBox)
                g.DrawLine(New Pen(Drawing.Color.FromArgb(35, 35, 35)), text.Location.X, text.Location.Y + text.Height, text.Location.X + text.Size.Width, text.Location.Y + text.Height)
            End If
        Next
    End Sub

    Private Sub color_Click(sender As Object, e As EventArgs) Handles color.Click
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            muestra_color.BackColor = ColorDialog1.Color
        End If
    End Sub


    Private Sub infoDaños_Click(sender As Object, e As EventArgs) Handles infoDaños.Click
        Marco.getInstancia.CargarPanel(New crearInformaDeDaños(Fachada.getInstancia.id_vehiculoPorVin(buscador.Text.Trim), Me) With {.ListaDeTodosLosInformes = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(Vehiculo)})
    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        If Controladores.Fachada.getInstancia.ExistenciaDevehiculoPrecargado(buscador.Text) Then
            EstadoBusqueda.Text = "Aceptado"
            EstadoBusqueda.ForeColor = Drawing.Color.FromArgb(18, 161, 13)
            Dim vehiculo As Controladores.Vehiculo = Controladores.Fachada.getInstancia.DevolverDatosBasicosPorVIN_Vehiculo(buscador.Text)
            ingresar.Enabled = False
            infoDaños.Enabled = False
            Me.Vehiculo = vehiculo


            ingresar.Enabled = True
            infoDaños.Enabled = True
            habilitar(True)
            cargarDatosDeLaPrecarga()
            ingresar.Enabled = True
        Else
            EstadoBusqueda.Text = "Vin sin precarga o no existe"
            EstadoBusqueda.ForeColor = Drawing.Color.FromArgb(180, 20, 20)
            habilitar(False)
            ingresar.Enabled = False
        End If

    End Sub

    Private Sub habilitar(j As Boolean)
        marca.Enabled = True
        modelo.Enabled = j
        anio.Enabled = j
        tipo.Enabled = j
        color.Enabled = j
        zonas.Enabled = j
        subzonas.Enabled = j
        lote.Enabled = j
        infoDaños.Enabled = j
        posDis.Enabled = j
        crearomodificarLote.Enabled = j
        ingresar.Enabled = j

    End Sub

    Private Sub cargarDatosDeLaPrecarga()
        If Vehiculo.Marca IsNot Nothing Then
            marca.Text = Vehiculo.Marca
            marca.Enabled = False 'si el dato esta precargado no puede ser modificado
        Else
            marca.Enabled = True
        End If
        If Vehiculo.Modelo IsNot Nothing Then
            modelo.Text = Vehiculo.Modelo
            modelo.Enabled = False
        Else
            modelo.Enabled = True
        End If
        If Vehiculo.Año <> 0 Then
            anio.SelectedItem = Vehiculo.Año
            anio.Enabled = False
        Else
            anio.Enabled = True
        End If
        If Vehiculo.Tipo IsNot Nothing Then
            tipo.SelectedItem = Vehiculo.Tipo
            tipo.Enabled = False
        Else
            tipo.Enabled = True
        End If
        If Vehiculo.Tipo IsNot Nothing Then
            tipo.SelectedItem = Vehiculo.Tipo
            tipo.Enabled = False
        Else
            tipo.Enabled = True
        End If

        If Vehiculo.Cliente IsNot Nothing Then
            For i As Integer = 0 To clienteshabi.Count - 1
                If clienteshabi(i).IDCliente = Vehiculo.Cliente.IDCliente Then
                    clientes.SelectedIndex = i
                    Exit For
                End If
            Next
            clientes.Enabled = False
        Else
            clientes.Enabled = True
        End If
        If Vehiculo.Color <> Drawing.Color.Empty Then
            muestra_color.BackColor = Drawing.Color.FromArgb(Vehiculo.Color.R, Vehiculo.Color.G, Vehiculo.Color.B)
            color.Enabled = False
        Else
            muestra_color.BackColor = Drawing.Color.FromArgb(255, 255, 255)
            color.Enabled = True
        End If

    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        subzonas.Items.Clear()
        For Each su As Controladores.Subzona In DirectCast(zonas.SelectedItem, Zona).Subzonas
            subzonas.Items.Add(su)
        Next
        subzonas.SelectedIndex = 0
    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        posDis.Items.Clear()
        Dim posi As List(Of Integer) = Controladores.Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(subzonas.SelectedItem)
        For i As Integer = 1 To DirectCast(subzonas.SelectedItem, Subzona).Capasidad
            If Not posi.Contains(i) Then
                posDis.Items.Add(i)
            End If
        Next
        posDis.SelectedIndex = 0
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs) Handles ingresar.Click
        If marca.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar la marca")
            Return
        End If
        Vehiculo.Marca = marca.Text

        If modelo.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el modelo del vehiculo")
            Return
        Else
            Vehiculo.Modelo = modelo.Text
        End If

        If anio.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el año ")
            Return
        Else
            Vehiculo.Año = anio.SelectedItem
        End If

        If tipo.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el tipo de vehiculo")
            Return
        Else
            Vehiculo.Tipo = tipo.SelectedItem
        End If

        If clientes.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el cliente del vehiculo")
            Return
        Else
            Vehiculo.Cliente = clienteshabi(clientes.SelectedIndex)
        End If

        Vehiculo.Color = muestra_color.BackColor

        Fachada.getInstancia.altaVehiculoConUpdate(Vehiculo, Fachada.getInstancia.DevolverUsuarioActual)
        If LoteFinal IsNot Nothing Then
            LoteFinal.IDLote = Fachada.getInstancia.nuevoLote(LoteFinal)
            Fachada.getInstancia.insertIntegra(LoteFinal, Vehiculo, Fachada.getInstancia.DevolverUsuarioActual, False)
        Else
            Fachada.getInstancia.insertIntegra(lote.SelectedItem, Vehiculo, Fachada.getInstancia.DevolverUsuarioActual, False)
        End If

        If informe IsNot Nothing Then
            Fachada.getInstancia.nuevoInformeDeDaños(informe)
        End If
        Fachada.getInstancia.AsignarNuevaPosicion(New Posicion() With {.Subzona = subzonas.SelectedItem,
                                                  .Posicion = posDis.SelectedItem,
                                                  .IngresadoPor = Fachada.getInstancia.DevolverUsuarioActual,
                                                  .Desde = DateTime.Now,
                                                  .Vehiculo = Vehiculo}, False)
        Marco.getInstancia.CargarPanel(New ListaVehiculos)
        Me.Dispose()
    End Sub

    Private completionIndex As Integer = 0

    Private Sub buscador_TextChanged(sender As Object, e As EventArgs) Handles buscador.TextChanged
        If buscador.Text.Count > 0 Then
            Dim autos = Controladores.Fachada.getInstancia.AutoComplete(buscador.Text)
            If autos.Count > 0 Then
                Dim index = buscador.Text.Count
                If completionIndex < 0 Then
                    completionIndex = autos.Count - completionIndex
                End If
                buscador.Text = autos(completionIndex Mod autos.Count)
                buscador.SelectionStart = index
                buscador.SelectionLength = buscador.Text.Length - index
            End If
        End If
    End Sub

    Private Sub buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles buscador.KeyDown
        If e.KeyCode = Keys.Tab Then
            If e.Shift Then
                completionIndex -= 1
            Else
                completionIndex += 1
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles crearomodificarLote.LinkClicked
        If LoteFinal Is Nothing Then
            Dim d As New NuevoLote(Me, DirectCast(lugar.SelectedItem, Lugar))
            d.ShowDialog()
        Else
            Dim d As New NuevoLote(Me, LoteFinal)
            d.ShowDialog()
        End If

    End Sub


    Private Sub ModificarInforme_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ModificarInforme.LinkClicked
        Marco.getInstancia.CargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informe, Me))
    End Sub

    Private Sub EliminarInforme_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles eliminarInforme.LinkClicked
        eliminarInforme.Visible = False
        ModificarInforme.Visible = False
        EstadoInforme.Text = "Sin informe"
        infoDaños.Enabled = True
        informe = Nothing
    End Sub

    Private Sub Eliminarlote_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles eliminarlote.LinkClicked
        lote.Enabled = True
        LoteFinal = Nothing
        eliminarlote.Visible = False
        crearomodificarLote.Text = "Crear lote"
    End Sub

    Public Sub NotificarDeInforme(info As InformeDeDaños)
        eliminarInforme.Visible = True
        ModificarInforme.Visible = True
        informe = info
        EstadoInforme.Text = "Informe realizado"
        infoDaños.Enabled = False
    End Sub

    Public Sub NotificarLote(l As Lote) Implements NotificacionLote.NotificarLote
        lote.Enabled = False
        crearomodificarLote.Text = "Modifica lote"
        eliminarlote.Visible = True
        LoteFinal = l
    End Sub

    Public Function dameVehiculoalLote() As Object Implements NotificacionLote.dameVehiculoalLote
        Return Vehiculo
    End Function


    Private Sub lugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugar.SelectedIndexChanged
        zonas.Items.Clear()
        Dim lug = DirectCast(lugar.SelectedItem, Lugar)
        Fachada.getInstancia.LugarZonasySubzonas(lug.IDLugar, lug)
        For Each z As Zona In lug.Zonas
            zonas.Items.Add(z)
        Next
        zonas.SelectedIndex = 0
        loadLotes()
    End Sub

    Private Sub QR_Click(sender As Object, e As EventArgs) Handles QR.Click
        buscador.Text = WebcamForm.GetQR()
    End Sub
End Class