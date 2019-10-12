Imports System.Windows.Forms
Public Class ListarClientes
    Private clientesTabla As DataTable
    Private alfa As Controladores.Alfa
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        alfa = New Controladores.Alfa(GetType(Controladores.Cliente), GetType(Controladores.SUB_cliente), Sub(x) Controladores.Marco.getInstancia.CargarPanel(Of PanelCliente)(New PanelCliente(DirectCast(x, Controladores.Cliente).IDCliente)))
        Me.Controls.Add(alfa)
        alfa.Size = New Drawing.Size(855, 570)
        alfa.Location = New Drawing.Point(13, 68)
        cargarDatos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub cargarDatos()
        clientesTabla = Controladores.Fachada.getInstancia.listaDeClientesActuales
        For Each r As DataRow In clientesTabla.Rows
            alfa.Nuevo(New Controladores.Cliente With {.IDCliente = r.Item(0), .RUT = r.Item(1), .Nombre = r.Item(2)}, False)
        Next
        alfa.render()
    End Sub

    Private Sub Clientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Controladores.Marco.getInstancia.CargarPanel(Of PanelCliente)(New PanelCliente(clientesTabla.Rows(e.RowIndex).Item(0)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controladores.Marco.getInstancia.CargarPanel(Of panel)(New panel) 'POR ALGUN MOTIVO NUEVO CLIENTE SE LLAMA PANEL¿¿¿¿¿?????
    End Sub


End Class