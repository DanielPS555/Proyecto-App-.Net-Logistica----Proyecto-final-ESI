Public Class ListaZonas
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarData()
    End Sub

    Private Sub CargarData()
        DataGridView1.DataSource = LRepo.CapacidadZonas(URepo.ConectadoEn)
    End Sub
End Class