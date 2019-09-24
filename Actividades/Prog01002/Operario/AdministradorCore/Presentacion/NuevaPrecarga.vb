Imports System.Drawing
Imports System.Windows.Forms
Public Class NuevaPrecarga
    Private colorin As Color
    Private isCSVPreload As Boolean = False

    Public Sub New(vehiculo As Controladores.Vehiculo)
        LoadPanel()
        CopyFromVehiculo(vehiculo)
        Me.ingresar.Text = "Guardar"
        isCSVPreload = True
    End Sub

    Private Sub CopyFromVehiculo(vehiculo As Controladores.Vehiculo)
        Me.vehiculo = vehiculo
        Me.vin.Text = vehiculo.VIN
        Me.modelo.Text = vehiculo.Modelo
        Me.marca.Text = vehiculo.Marca
        Me.color.BackColor = vehiculo.Color
        Me.anio.Text = vehiculo.Año
        Dim zippedClients = Me.clientes.Items.
            Cast(Of Controladores.Cliente).
            Zip(Enumerable.Range(0, clientes.Items.Count),
                Function(x, y) New Tuple(Of Controladores.Cliente, Integer)(x, y))
        Dim client = zippedClients.Where(Function(x) x.Item1.Nombre = vehiculo.Cliente?.Nombre).SingleOrDefault
        If client IsNot Nothing Then
            Me.clientes.SelectedIndex = client.Item2
        End If
        Me.tipo.SelectedItem = vehiculo.Tipo
    End Sub

    Private Sub LoadPanel()
        InitializeComponent()
        cargarItem()
        cargarAños()
        cargarclientes()
    End Sub

    Public Sub New()
        LoadPanel()
        Me.vehiculo = New Controladores.Vehiculo
    End Sub

    Private Sub cargarItem()
        tipo.Items.Clear()
        tipo.Items.AddRange(Controladores.Vehiculo.TIPOS_VEHICULOS)
        tipo.SelectedIndex = 0
    End Sub

    Private Sub cargarAños()
        For i As Integer = 1900 To DateTime.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedItem = DateTime.Now.Year
    End Sub

    Private Sub cargarclientes()
        clientes.Items.Clear()
        Dim clienteshabi = Controladores.Fachada.getInstancia.ClientesDelSistema()
        For Each ce As Controladores.Cliente In clienteshabi
            clientes.Items.Add(ce)
        Next
    End Sub

    Private Sub NuevaPrecarga_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = Me.CreateGraphics
        For Each textCo In Me.Controls
            If TypeOf (textCo) Is TextBox Then
                Dim text As TextBox = DirectCast(textCo, TextBox)
                g.DrawLine(New Pen(Drawing.Color.FromArgb(35, 35, 35)), text.Location.X, text.Location.Y + text.Height, text.Location.X + text.Size.Width, text.Location.Y + text.Height)
            End If
        Next
    End Sub

    Private vehiculo As Controladores.Vehiculo

    Private Sub Ingresar_Click(sender As Object, e As EventArgs) Handles ingresar.Click
        If clientes.SelectedItem Is Nothing Then
            MsgBox("El cliente no puede ser nulo!")
            Return
        End If

        If Not marcaNoIngrezar.Checked Then
            If marca.Text.Trim.Length > 0 Then
                vehiculo.Marca = marca.Text.Trim
            Else
                MsgBox("Si no desea ingresar un valor para la marca debe explicitarlo con el checkbox")
                Return
            End If
        End If
        If Not modeloNoIngrezar.Checked Then
            If modelo.Text.Trim.Length > 0 Then
                vehiculo.Modelo = modelo.Text.Trim
            Else
                MsgBox("Si no desea ingresar un valor para el modelo debe explicitarlo con el checkbox")
                Return
            End If
        End If

        If Not añoNoIngrezar.Checked Then
            vehiculo.Año = anio.SelectedItem
        Else
            vehiculo.Año = 0
        End If

        If Not tipoNoIngrezar.Checked Then
            vehiculo.Tipo = tipo.SelectedItem
        End If

        If Not colorNoIngrezar.Checked Then
            vehiculo.Color = muestra_color.BackColor
        End If

        vehiculo.VIN = vin.Text

        vehiculo.Cliente = clientes.SelectedItem


        If Not isCSVPreload Then
            Controladores.Fachada.getInstancia.nuevaPrecarga(vehiculo, Controladores.Fachada.getInstancia.DevolverUsuarioActual)

            MsgBox("Precarga realizada", MsgBoxStyle.Information)
        End If
        Controladores.Marco.getInstancia.cerrarPanel(Of NuevaPrecarga)()

    End Sub

    Private Sub Vin_TextChanged(sender As Object, e As EventArgs) Handles vin.TextChanged
        If vin.Text.Length > 0 Then
            For Each c As Char In vin.Text
                If c = " " Then
                    estado.Text = "No puede ingresar espacios en blanco"
                    estado.ForeColor = Drawing.Color.FromArgb(180, 20, 20)
                    Return
                End If
            Next
        End If
        If vin.Text.Length = 17 Then
            If Controladores.Fachada.getInstancia.verificarVinExistente(vin.Text) Then
                estado.Text = "Esta Vin ya fue ingrezada"
            Else
                For Each c As Char In vin.Text
                    If Char.IsLetter(c) Then
                        estado.Text = "Aceptado"
                        estado.ForeColor = Drawing.Color.FromArgb(19, 176, 25)
                        Return
                    End If
                Next
                estado.Text = "Debe incluir al menos una letra"
                estado.ForeColor = Drawing.Color.FromArgb(255, 0, 0)
            End If
        Else
            estado.Text = $"Faltan {17 - vin.Text.Length} caracteres "
        End If
        estado.ForeColor = Drawing.Color.FromArgb(180, 20, 20)


    End Sub

    Private Sub color_Click(sender As Object, e As EventArgs) Handles color.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            muestra_color.BackColor = ColorDialog1.Color
            colorin = ColorDialog1.Color
        End If
    End Sub

    Private Sub añoNoIngrezar_CheckedChanged(sender As Object, e As EventArgs) Handles añoNoIngrezar.CheckedChanged
        anio.Enabled = Not añoNoIngrezar.Checked
    End Sub

    Private Sub tipoNoIngrezar_CheckedChanged(sender As Object, e As EventArgs) Handles tipoNoIngrezar.CheckedChanged
        tipo.Enabled = Not tipoNoIngrezar.Checked
    End Sub

    Private Sub colorNoIngrezar_CheckedChanged(sender As Object, e As EventArgs) Handles colorNoIngrezar.CheckedChanged
        Me.color.Enabled = Not colorNoIngrezar.Checked
    End Sub
End Class