Imports GMap.NET
Imports Controladores.Extenciones.Extensiones

Public Class PanelLugar


    Private lugar As Controladores.Lugar

    Public Sub New(idlugar As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargarInfoBasica(idlugar)
        Label1.Traducir
        Label6.Traducir
        Label7.Traducir

        Label3.Traducir
        Label4.Traducir

        verUbicacion.Traducir
        Button1.Traducir
        EditarSubzonas.Traducir
        verZonas.Traducir


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
            Label2.Text = Controladores.Funciones_comunes.I18N("Cliente dueño:", Controladores.Marco.Language)
            Me.capasidad.Text = lugar.Dueño.Nombre
            Label5.Text = Controladores.Funciones_comunes.I18N("Vehiculos entregados", Controladores.Marco.Language)
            usuarios.DataSource = Controladores.Fachada.getInstancia.todosLosVehiculosEntregadosEnUnLugar(lugar.IDLugar)
            EditarSubzonas.Visible = False
            verZonas.Visible = False
        Else
            Label2.Traducir
            Label5.Traducir
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

    Private Sub PanelLugar_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Dim x = (Me.Width / 3) - 20
        Button1.Location = New Drawing.Point(10, Button1.Location.Y)
        Button1.Width = x
        EditarSubzonas.Width = x
        EditarSubzonas.Location = New Drawing.Point(x + 15, EditarSubzonas.Location.Y)
        verZonas.Width = x
        verZonas.Location = New Drawing.Point(2 * x + 20, EditarSubzonas.Location.Y)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ss As New EditarHabilitaciones(lugar)
        ss.ShowDialog()
    End Sub
End Class