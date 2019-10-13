Imports GMap.NET

Public Class PanelLugar


    Private lugar As Controladores.Lugar

    Public Sub New(idlugar As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargarInfoBasica(idlugar)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargarInfoBasica(idlugar As Integer)
        lugar = Controladores.Fachada.getInstancia.informacionBaseDelLugarPorIdlugar(idlugar)
        Me.idlugar.Text = lugar.IDLugar
        Me.nombre.Text = lugar.Nombre
        Me.tipoLugar.Text = lugar.Tipo
        Me.usuariocreador.Text = lugar.Creador.Nombre
        Me.fechacreacion.Text = lugar.FechaCreacion

        If lugar.Tipo = Controladores.Lugar.TIPO_LUGAR_ESTABLECIMIENTO Then
            Label2.Text = "Cliente dueño:"
            Me.capasidad.Text = lugar.Dueño.Nombre
            Label5.Text = "Vehiculos entregados"
            usuarios.DataSource = Controladores.Fachada.getInstancia.todosLosVehiculosEntregadosEnUnLugar(lugar.IDLugar)
            EditarSubzonas.Visible = False
            verZonas.Visible = False
        Else
            Me.capasidad.Text = lugar.Capasidad
            usuarios.DataSource = Controladores.Fachada.getInstancia.devolverListaDeTrabajaEnPorIdlugar(lugar.IDLugar)
        End If

    End Sub

    Private Sub VerUbicacion_Click_1(sender As Object, e As EventArgs) Handles verUbicacion.Click
        Dim m As New Controladores.MapaPanelGrande(New PointLatLng(lugar.PosicionX, lugar.PosicionY))
        m.ShowDialog()
    End Sub

    Private Sub verZonas_Click(sender As Object, e As EventArgs) Handles verZonas.Click

        Controladores.Marco.getInstancia.CargarPanel(Of OperarioCore.ListaZonas)(New OperarioCore.ListaZonas(lugar.IDLugar))
    End Sub

    Private Sub EditarSubzonas_Click(sender As Object, e As EventArgs) Handles EditarSubzonas.Click
        Controladores.Marco.getInstancia.CargarPanel(Of AdministrarZonasYSubzonas)(New AdministrarZonasYSubzonas(lugar.IDLugar))
    End Sub
End Class