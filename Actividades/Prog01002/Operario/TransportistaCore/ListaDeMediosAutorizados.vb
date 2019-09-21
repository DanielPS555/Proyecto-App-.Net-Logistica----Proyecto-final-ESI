Imports System.Windows.Forms
Imports Controladores

Public Class ListaDeMediosAutorizados
    Dim dataTabla As New DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        dataTabla = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        medios.DataSource = dataTabla

    End Sub

    Private Sub Medios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles medios.CellContentDoubleClick
        Marco.getInstancia.cargarPanel(Of PanelMedioDeTrasporte)(New PanelMedioDeTrasporte(dataTabla.Rows(e.RowIndex).Item(0)))
    End Sub
End Class