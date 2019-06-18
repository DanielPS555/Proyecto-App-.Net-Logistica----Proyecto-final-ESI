Public Class ListaVehiculos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        EstableserEncabesadosTamaños()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub EstableserEncabesadosTamaños()
        DataGridView2.Columns(0).Width = 50
        DataGridView2.Columns(1).Width = 200
        DataGridView2.Columns(2).Width = 200
        DataGridView2.Columns(3).Width = 200
        DataGridView2.Columns(4).Width = 130
        DataGridView2.Columns(5).Width = 70
    End Sub

    Public Sub CargarDatos()

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.ColumnIndex = 5 Then
            ' con el e.RomIndex sabemos cual va a ser el vim del vehiculo (nos fijamos en la primera columna de el), luego encontramos el objeto vehiculo en la lista 
            ' a partir de ese vim, eso se lo pasamos al panel del vehiculo 
            MarcoPuerto.getInstancia.cargarPanel(Of panelInfoVehiculo)(New panelInfoVehiculo)
        End If
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        MarcoPuerto.getInstancia.cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
    End Sub
End Class

