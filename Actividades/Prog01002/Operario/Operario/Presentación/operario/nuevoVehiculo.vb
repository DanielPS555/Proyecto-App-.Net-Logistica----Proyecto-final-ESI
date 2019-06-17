Public Class nuevoVehiculo

    'crear una entidad lote y hacer una propery publica para acceder a ella desde el panel nuevoLote y enviar el lote creado  



    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        carcarComboBox()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub carcarComboBox()
        tipo.SelectedIndex = 0
        anio.Items.Clear()
        For i As Integer = 1900 To DateTime.Now.Year
            anio.Items.Add(i)
        Next
        anio.SelectedIndex = anio.Items.Count - 1
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

    Private Sub nuevoLote_Click(sender As Object, e As EventArgs)
        Dim d As New NuevoLote
        d.ShowDialog()
    End Sub

    Private Sub infoDaños_Click(sender As Object, e As EventArgs)
        MarcoPuerto.getInstancia.cargarPanel(Of crearInformaDeDaños)(New crearInformaDeDaños)
    End Sub
End Class