Imports Operario

Public Class nuevoVehiculo
    Implements LoteReceiver
    'crear una entidad lote y hacer una propery publica para acceder a ella desde el panel nuevoLote y enviar el lote creado  


    Private lote_s As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        carcarComboBox()

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
        tipo.Items.AddRange([Enum].GetNames(GetType(Logica.TipoVehiculo)))
        tipo.SelectedIndex = 0
        anio.Items.Clear()
        For i As Integer = 1900 To DateTime.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedItem = DateTime.Now.Year
        zonas.Items.Clear()
        zonas.Items.AddRange(LRepo.ZonasEnLugar(URepo.ConectadoEn).ToArray)
        loadLotes()
    End Sub

    Private Sub loadLotes()
        lote.Items.Clear()
        lote.Items.AddRange(LRepo.LotesEnLugar(URepo.ConectadoEn).Where(Function(x) LRepo.LoteAbierto(x)).ToArray)
    End Sub

    Private Sub nuevoVehiculo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        For Each textCo In Me.Controls
            If TypeOf (textCo) Is TextBox Then
                Dim text As TextBox = DirectCast(textCo, TextBox)
                g.DrawLine(New Pen(Color.FromArgb(35, 35, 35)), text.Location.X, text.Location.Y + text.Height, text.Location.X + text.Size.Width, text.Location.Y + text.Height)
            End If
        Next
    End Sub

    Private Sub color_Click(sender As Object, e As EventArgs)
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            muestra_color.BackColor = ColorDialog1.Color
        End If
    End Sub


    Private Sub infoDaños_Click(sender As Object, e As EventArgs)
        Dim vehiculo As Logica.Vehiculo = VRepo.VehiculoIncompleto(buscador.Text)
        If vehiculo Is Nothing Then
            MsgBox("No existe precarga para ese vehículo, reporte a su administrador")
            Return
        End If

        VRepo.IngresosVehiculo(vehiculo)
        If vehiculo.Ingresos.Where(Function(x) x.Tipo = Logica.TipoIngreso.Alta).Count > 0 Then
            MsgBox("Ese vehículo ya ha sido ingresado")
        Else
            Marco.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños(vehiculo.VIN))
        End If
    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs)
        Dim vehiculo As Logica.Vehiculo = VRepo.VehiculoIncompleto(buscador.Text)

        If vehiculo Is Nothing Then
            MsgBox("No existe precarga para ese vehículo, reporte a su administrador")
            Return
        End If

        VRepo.IngresosVehiculo(vehiculo)
        If vehiculo.Ingresos.Where(Function(x) x.Tipo = Logica.TipoIngreso.Alta).Count > 0 Then
            MsgBox("Ese vehículo ya ha sido ingresado")
        Else
            MsgBox("Ese vehículo tiene una precarga pendiente, puede ser ingresado")
        End If
    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        subzonas.Items.Clear()
        subzonas.Items.AddRange(LRepo.SubzonasEnLugar(zonas.SelectedItem, URepo.ConectadoEn).ToArray)
    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        Dim subzona As String = subzonas.SelectedItem
        Dim zona As String = zonas.SelectedItem
        Dim lugar As String = URepo.ConectadoEn
        posDis.Items.Clear()
        For i = 0 To LRepo.CapacidadSubzona(subzona, zona, lugar)
            '            If LRepo.PosicionOcupada(subzona, zona, lugar, i) Then
            posDis.Items.Add(i)
            '            End If
        Next
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
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
            Dim autos = VRepo.AutoComplete(buscador.Text)
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
        cliente.Text = VRepo.Cliente(buscador.Text)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim d As New NuevoLote(Me)
        d.ShowDialog()
    End Sub
End Class