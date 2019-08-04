Imports Operario
Imports Controladores.Extenciones.Extensiones

Public Class nuevoVehiculo
    Implements LoteReceiver
    'crear una entidad lote y hacer una propery publica para acceder a ella desde el panel nuevoLote y enviar el lote creado  
    Private vehi As New Controladores.Vehiculo()
    Private lotesDisponibles As New List(Of Controladores.Lote)
    Private zonasDisponibles As New List(Of Controladores.Zona)
    Private clienteshabi As New List(Of Controladores.Cliente)

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

    Private WriteOnly Property LoteReceiver_Lote As String Implements LoteReceiver.Lote
        Set(value As String)
            lote_s = value
            loadLotes()
            lote.SelectedItem = lote_s
        End Set
    End Property

    Private Sub carcarComboBox()
        tipo.Items.Clear()
        tipo.Items.AddRange(Controladores.Vehiculo.TIPOS_VEHICULOS)
        tipo.SelectedIndex = 0
        anio.Items.Clear()
        For i As Integer = 1900 To DateTime.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedItem = DateTime.Now.Year
        zonas.Items.Clear()
        Controladores.Fachada.getInstancia().CargarTrabajaEnConLugarZonasySubzonas()
        zonas.Items.Clear()

        For Each z As Controladores.Zona In Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.Zonas
            zonas.Items.Add(z.Nombre)
        Next

        zonasDisponibles = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar.Zonas
        zonas.SelectedIndex = 0


    End Sub

    Private Sub loadLotes()
        lote.Items.Clear()
        lotesDisponibles = Controladores.Fachada.getInstancia.lotesDisponiblesPorLugarActual()
        For Each l As Controladores.Lote In lotesDisponibles
            lote.Items.Add("Nom:" & l.Nombre & "ID:" & l.IDLote)
        Next
        If lote.Items.Count > 0 Then
            lote.SelectedIndex = 0
        End If
    End Sub

    Private Sub loadClientes()
        clientes.Items.Clear()
        clienteshabi = Controladores.Fachada.getInstancia.ClientesDelSistema()
        For Each ce As Controladores.Cliente In clienteshabi
            clientes.Items.Add("Nom:" & ce.Nombre & "RUT:" & ce.RUT)
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

        Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(Controladores.Fachada.getInstancia.id_vehiculoPorVin(buscador.Text.Trim)))

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
        Else
            EstadoBusqueda.Text = "Vin sin precarga o no existe"
            EstadoBusqueda.ForeColor = Drawing.Color.FromArgb(180, 20, 20)
            habilitar(False)
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
        infoDaños.Enabled = j


    End Sub

    Private Sub cargarDatosDeLaPrecarga()
        If vehi.Marca IsNot Nothing Then
            marca.Text = vehi.Marca
            marca.Enabled = False 'si el dato esta precargado no puede ser modificado

        End If
        If vehi.Modelo IsNot Nothing Then
            modelo.Text = vehi.Modelo
            modelo.Enabled = False

        End If
        If vehi.Año <> 0 Then
            anio.SelectedItem = vehi.Año
            anio.Enabled = False

        End If
        If vehi.Tipo IsNot Nothing Then
            tipo.SelectedItem = vehi.Tipo
            tipo.Enabled = False
        End If
        If vehi.Tipo IsNot Nothing Then
            tipo.SelectedItem = vehi.Tipo
            tipo.Enabled = False
        End If

        If vehi.Cliente IsNot Nothing Then
            For i As Integer = 0 To clienteshabi.Count - 1
                If clienteshabi(i).IDCliente = vehi.Cliente.IDCliente Then
                    clientes.SelectedIndex = i
                    Exit For
                End If
            Next
        Else
            clientes.Enabled = False
        End If
        If vehi.Color <> Drawing.Color.Empty Then
            muestra_color.BackColor = Drawing.Color.FromArgb(vehi.Color.R, vehi.Color.G, vehi.Color.B)
        Else
            color.Enabled = False
        End If

    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        subzonas.Items.Clear()
        For Each su As Controladores.Subzona In zonasDisponibles(zonas.SelectedIndex).Subzonas
            subzonas.Items.Add(su.Nombre)
        Next
    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        posDis.Items.Clear()
        Dim posi As List(Of Integer) = Controladores.Fachada.getInstancia.PosicionesActualmenteOcupadasPorSubzona(zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex))
        For i As Integer = 1 To zonasDisponibles(zonas.SelectedIndex).Subzonas(subzonas.SelectedIndex).Capasidad
            If Not posi.Contains(i) Then
                posDis.Items.Add(i)
            End If
        Next
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs) Handles ingresar.Click
        If (buscador.Text.Count * marca.Text.Count * modelo.Text.Count * anio.Text.Count * lote.Text.Count) = 0 Then
            MsgBox("Todos los datos deben estar llenados para ingresar un vehiculo")
        End If
        Dim v = VRepo.VehiculoIncompleto(buscador.Text)
        If v Is Nothing Then
            MsgBox("Ese vehículo no existe, por favor verifique el VIN.")
            Return
        End If
        If URepo.AltaVehiculo(buscador.Text, marca.Text, modelo.Text, Integer.Parse(anio.Text), zonas.SelectedItem, subzonas.SelectedItem, Integer.Parse(posDis.SelectedItem), ColorDialog1.Color, lote.Text) Then
            Marco.getInstancia.cerrarPanel(Of ListaVehiculos)()
            Marco.getInstancia.cargarPanel(New ListaVehiculos)
            Marco.getInstancia.cerrarPanel(Of nuevoVehiculo)()
        Else
            MsgBox("No pudo ingresarse ese vehículo. Confirme que no ha sido ingresado aún.")
        End If
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

    Private Sub buscador_Leave(sender As Object, e As EventArgs) Handles buscador.Leave
        'cliente.Text = VRepo.Cliente(buscador.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim d As New NuevoLote(Me)
        d.ShowDialog()
    End Sub

    Public Sub NotificarDeLote(l As Controladores.Lote)

    End Sub

    Public Sub NotificarDeInforme(info As Controladores.InformeDeDaños)

    End Sub

End Class