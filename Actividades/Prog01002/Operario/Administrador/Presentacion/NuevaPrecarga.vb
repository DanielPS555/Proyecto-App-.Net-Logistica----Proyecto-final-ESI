Public Class NuevaPrecarga
    Private clienteshabi As List(Of Controladores.Cliente)
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
        anio.SelectedIndex = 0
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
        'CARGAR EL VEHI

        Controladores.Fachada.getInstancia.nuevaPrecarga()

    End Sub
End Class