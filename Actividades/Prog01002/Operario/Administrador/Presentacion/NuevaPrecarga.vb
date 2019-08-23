Public Class NuevaPrecarga
    Private clienteshabi As List(Of Controladores.Cliente)
    Private colorin As Color
    Public Sub New()
        InitializeComponent()
        cargarItem()
        cargarAños()
        cargarclientes()
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
        clienteshabi = Controladores.Fachada.getInstancia.ClientesDelSistema()
        For Each ce As Controladores.Cliente In clienteshabi
            clientes.Items.Add("Nom: " & ce.Nombre & "RUT: " & ce.RUT)
        Next
        clientes.SelectedIndex = 0
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

    Private Sub ingresar_Click(sender As Object, e As EventArgs) Handles ingresar.Click
        Dim vehi As New Controladores.Vehiculo

        vehi.VIN = vin.Text

        If marca.Text.Trim.Length > 0 Then
            vehi.Marca = marca.Text.Trim
        End If

        If modelo.Text.Trim.Length > 0 Then
            vehi.Modelo = modelo.Text.Trim
        End If

        If Not añoNoIngrezar.Checked Then
            vehi.Año = anio.SelectedItem
        Else
            vehi.Año = 0
        End If

        If Not tipoNoIngrezar.Checked Then
            vehi.Tipo = tipo.SelectedItem
        End If

        If Not colorNoIngrezar.Checked Then
            vehi.Color = muestra_color.BackColor
        End If

        vehi.Cliente = clienteshabi(clientes.SelectedIndex)

        Controladores.Fachada.getInstancia.nuevaPrecarga(vehi, Controladores.Fachada.getInstancia.DevolverUsuarioActual)

        MsgBox("Precarga realizada", MsgBoxStyle.Information)
        Marco.getInstancia.cerrarPanel(Of NuevaPrecarga)()

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
                Dim j As Boolean = False
                For Each c As Char In vin.Text
                    If Char.IsLetter(c) Then
                        j = True
                        Exit For
                    End If
                Next
                If j Then
                    estado.Text = "Aceptado"
                    estado.ForeColor = Drawing.Color.FromArgb(19, 176, 25)
                    Return
                Else
                    estado.Text = "Debe incluir al menos una letra"
                End If

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