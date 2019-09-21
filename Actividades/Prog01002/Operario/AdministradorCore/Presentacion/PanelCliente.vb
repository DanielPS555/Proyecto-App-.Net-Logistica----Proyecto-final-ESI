Public Class PanelCliente
    Private clienteFinal As Controladores.Cliente
    Public Sub New(idcliente As Integer)
        InitializeComponent()
        cargardatos(idcliente)
    End Sub

    Private Sub cargardatos(idcliente As Integer)
        clienteFinal = Controladores.Fachada.getInstancia.DevolverDatosBasicosCliente(idcliente)
        Me.idcliente.Text = clienteFinal.IDCliente
        Me.rut.Text = clienteFinal.RUT
        Me.nombre.Text = clienteFinal.Nombre
        Me.usuariocreador.Text = clienteFinal.Creador.Nombre
        Me.fechacreacion.Text = clienteFinal.FechaRegistro
        Me.lugares.DataSource = Controladores.Fachada.getInstancia.EstablesimientoDeCliente(idcliente)

    End Sub
End Class