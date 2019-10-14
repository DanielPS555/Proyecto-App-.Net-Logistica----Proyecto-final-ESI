Imports System.Windows.Forms
Imports Controladores.Extenciones.Extensiones
Public Class ListaDeTrasportes
    Dim lista As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        buscar.Traducir
        lista = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        trasportes.DataSource = lista
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Trasportes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles trasportes.CellClick
        Controladores.Marco.getInstancia.CargarPanel(Of PanelTrasporte)(New PanelTrasporte(lista.Rows(e.RowIndex).Item(0)))
    End Sub
End Class