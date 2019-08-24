Imports Operario
Imports Controladores.Extenciones.Extensiones
Imports Controladores

Public Class nuevoVehiculo
    Implements NotificacionDeLote

    'crear una entidad lote y hacer una propery publica para acceder a ella desde el panel nuevoLote y enviar el lote creado  
    Private vehi As New Controladores.Vehiculo()
    Private lotesDisponibles As New List(Of Controladores.Lote)
    Private zonasDisponibles As New List(Of Controladores.Zona)
    Private clienteshabi As New List(Of Controladores.Cliente)
    Private informe As Controladores.InformeDeDaños
    Private LoteFinal As Controladores.Lote

    Public Property Vehiculo() As Controladores.Vehiculo
        Get
            Return vehi
        End Get
        Set(ByVal value As Controladores.Vehiculo)
            vehi = value
        End Set
    End Property

    Private lote_s As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        loadClientes()
        carcarComboBox()
        habilitar(False)
        loadLotes()
        loadClientes()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub carcarComboBox()
        tipo.Items.Clear()
        tipo.Items.AddRange(Controladores.Vehiculo.TIPOS_VEHICULOS)
        tipo.SelectedIndex = 0
        anio.Items.Clear()
        For i As Integer = 1900 To DateTime.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedItem = DateTime.Now.Year

        lugares = Fachada.getInstancia.listarTodosLosLugares.ToList.ToDictionary(Function(x) x.Item(1), Function(x) x.Item(0))
        lugar.Items.Clear()
        lugar.Items.AddRange(lugares.Keys.ToArray)
        zonas.Items.Clear()
    End Sub

    Private Sub loadLotes()
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

    Private Sub loadClientes()
        clientes.Items.Clear()
        clienteshabi = Controladores.Fachada.getInstancia.ClientesDelSistema()
        For Each ce As Controladores.Cliente In clienteshabi
            clientes.Items.Add("Nom: " & ce.Nombre & "RUT: " & ce.RUT)
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
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            muestra_color.BackColor = ColorDialog1.Color
        End If
    End Sub


    Private Sub infoDaños_Click(sender As Object, e As EventArgs) Handles infoDaños.Click
        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(Controladores.Fachada.getInstancia.id_vehiculoPorVin(buscador.Text.Trim), Me) With {.ListaDeTodosLosInformes = Controladores.Fachada.getInstancia.devolverTodosLosInformesYregistrosCompletos(Vehiculo)})

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        If Controladores.Fachada.getInstancia.ExistenciaDevehiculoPrecargado(buscador.Text) Then
            EstadoBusqueda.Text = "Aceptado"
            EstadoBusqueda.ForeColor = Drawing.Color.FromArgb(18, 161, 13)
            Dim vehiculo As Controladores.Vehiculo = Controladores.Fachada.getInstancia.DevolverDatosBasicosPorVIN_Vehiculo(buscador.Text)
            ingresar.Enabled = False
            infoDaños.Enabled = False
            vehi = vehiculo


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
        If vehi.Marca IsNot Nothing Then
            marca.Text = vehi.Marca
            marca.Enabled = False 'si el dato esta precargado no puede ser modificado
        Else
            marca.Enabled = True
        End If
        If vehi.Modelo IsNot Nothing Then
            modelo.Text = vehi.Modelo
            modelo.Enabled = False
        Else
            modelo.Enabled = True
        End If
        If vehi.Año <> 0 Then
            anio.SelectedItem = vehi.Año
            anio.Enabled = False
        Else
            anio.Enabled = True
        End If
        If vehi.Tipo IsNot Nothing Then
            tipo.SelectedItem = vehi.Tipo
            tipo.Enabled = False
        Else
            tipo.Enabled = True
        End If
        If vehi.Tipo IsNot Nothing Then
            tipo.SelectedItem = vehi.Tipo
            tipo.Enabled = False
        Else
            tipo.Enabled = True
        End If

        If vehi.Cliente IsNot Nothing Then
            For i As Integer = 0 To clienteshabi.Count - 1
                If clienteshabi(i).IDCliente = vehi.Cliente.IDCliente Then
                    clientes.SelectedIndex = i
                    Exit For
                End If
            Next
            clientes.Enabled = False
        Else
            clientes.Enabled = True
        End If
        If vehi.Color <> Drawing.Color.Empty Then
            muestra_color.BackColor = Drawing.Color.FromArgb(vehi.Color.R, vehi.Color.G, vehi.Color.B)
            color.Enabled = False
        Else
            muestra_color.BackColor = Drawing.Color.FromArgb(255, 255, 255)
            color.Enabled = True
        End If

    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        subzonas.Items.Clear()
        For Each su As Controladores.Subzona In zonasDisponibles(zonas.SelectedIndex).Subzonas
            subzonas.Items.Add(su.Nombre)
        Next
        subzonas.SelectedIndex = 0
    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        posDis.Items.Clear()
        Dim posi As List(Of Integer) = Controladores.Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex))
        For i As Integer = 1 To zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex).Capasidad
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
        vehi.Marca = marca.Text

        If modelo.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el modelo del vehiculo")
            Return
        Else
            vehi.Modelo = modelo.Text
        End If

        If anio.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el año ")
            Return
        Else
            vehi.Año = anio.SelectedItem
        End If

        If tipo.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el tipo de vehiculo")
            Return
        Else
            vehi.Tipo = tipo.SelectedItem
        End If

        If clientes.SelectedIndex = -1 Then
            MsgBox("Debe ingresar el cliente del vehiculo")
            Return
        Else
            vehi.Cliente = clienteshabi(clientes.SelectedIndex)
        End If

        vehi.Color = muestra_color.BackColor

        Fachada.getInstancia.altaVehiculoConUpdate(vehi, Fachada.getInstancia.TrabajaEnAcutual.Usuario)
        If LoteFinal IsNot Nothing Then
            LoteFinal.IDLote = Fachada.getInstancia.nuevoLote(LoteFinal)
            Fachada.getInstancia.insertIntegra(LoteFinal, vehi, Fachada.getInstancia.TrabajaEnAcutual.Usuario, False)
        Else
            Fachada.getInstancia.insertIntegra(lotesDisponibles(lote.SelectedIndex), vehi, Fachada.getInstancia.TrabajaEnAcutual.Usuario, False)
        End If

        If informe IsNot Nothing Then
            Fachada.getInstancia.nuevoInformeDeDaños(informe)
        End If
        Fachada.getInstancia.AsignarNuevaPosicion(New Posicion() With {.Subzona = zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex),
                                                  .Posicion = posDis.SelectedItem,
                                                  .IngresadoPor = Fachada.getInstancia.TrabajaEnAcutual.Usuario,
                                                  .Desde = DateTime.Now,
                                                  .Vehiculo = vehi}, False)
        Marco.getInstancia.cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
        Me.Dispose()
    End Sub

    Private completionIndex As Integer = 0
    Private lugares As Dictionary(Of Object, Object)
    Private lug As Lugar

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
            Dim d As New NuevoLote(Me)
            d.ShowDialog()
        Else
            Dim d As New NuevoLote(Me, LoteFinal)
            d.ShowDialog()
        End If

    End Sub


    Private Sub ModificarInforme_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ModificarInforme.LinkClicked
        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(informe, Me))
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

    Public Sub NotificarLote(l As Lote) Implements NotificacionDeLote.NotificarLote
        lote.Enabled = False
        crearomodificarLote.Text = "Modifica lote"
        eliminarlote.Visible = True
        LoteFinal = l
    End Sub

    Public Function dameVehiculoalLote() As Object Implements NotificacionDeLote.dameVehiculoalLote
        Return Vehiculo
    End Function


    Private Sub lugar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugar.SelectedIndexChanged
        zonas.Items.Clear()
        lug = Fachada.getInstancia.LugarZonasySubzonas(lugares(lugar.SelectedItem))
        For Each z As Controladores.Zona In lug.Zonas
            zonas.Items.Add(z.Nombre)
        Next

        zonasDisponibles = lug.Zonas
        zonas.SelectedIndex = 0
    End Sub
End Class