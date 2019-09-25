Imports System.Windows.Forms
Imports Controladores

Public Class ListaDeMediosAutorizados
    Dim dataTabla As New DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        If Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_TRANSPORTISTA Then
            dataTabla = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
        ElseIf Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR Then
            dataTabla = Fachada.getInstancia.TablaDeMedios()
        End If
        medios.DataSource = dataTabla
    End Sub

    Private Sub Medios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles medios.CellContentDoubleClick
        Marco.getInstancia.CargarPanel(Of PanelMedioDeTrasporte)(New PanelMedioDeTrasporte(dataTabla.Rows(e.RowIndex).Item(0)))
    End Sub
End Class