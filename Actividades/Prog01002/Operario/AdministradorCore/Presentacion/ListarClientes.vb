Imports System.Windows.Forms
Public Class ListarClientes
    Private clientesTabla As DataTable
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargarDatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub cargarDatos()
        clientesTabla = Controladores.Fachada.getInstancia.listaDeClientesActuales
        clientes.DataSource = clientesTabla
    End Sub

    Private Sub Clientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles clientes.CellDoubleClick
        Controladores.Marco.getInstancia.cargarPanel(Of PanelCliente)(New PanelCliente(clientesTabla.Rows(e.RowIndex).Item(0)))
    End Sub
End Class