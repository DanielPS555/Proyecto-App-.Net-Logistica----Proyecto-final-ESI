Imports Operario

Public Class crearInformaDeDaños
    Private idvehiculo As Integer
    Private _listaDeTodosLosinformes As List(Of Controladores.InformeDeDaños)
    Private numRegistroAEditar = -1
    Private PanelDelVehiculo As nuevoVehiculo
    Private subida As Boolean
    Private Info As Controladores.InformeDeDaños
    Private panelVehiculo As panelInfoVehiculo

    Public Property ListaDeTodosLosInformes() As List(Of Controladores.InformeDeDaños)
        Get
            Return _listaDeTodosLosinformes
        End Get
        Set(ByVal value As List(Of Controladores.InformeDeDaños))
            For Each e As Controladores.InformeDeDaños In value
                If e.Fecha < Info.Fecha And e.ID <> Info.ID Then
                    _listaDeTodosLosinformes.Add(e)
                End If
            Next

        End Set
    End Property

    Private _nuevo As Boolean
    Public ReadOnly Property NuevoVehiculo() As Boolean
        Get
            Return _nuevo
        End Get

    End Property




    Public Sub New(id As Integer, padre As nuevoVehiculo)
        idvehiculo = id
        InitializeComponent()
        tipo.SelectedIndex = 0
        If Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR Then
            tipo.Enabled = True
        Else
            tipo.Enabled = False
        End If
        _listaDeTodosLosinformes = New List(Of Controladores.InformeDeDaños)
        Info = New Controladores.InformeDeDaños(New Controladores.Vehiculo With {.IdVehiculo = id}) With {.Fecha = DateTime.Now,
                                                                                                        .Lugar = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar,
                                                                                                        .Creador = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Usuario}
        _nuevo = True
        PanelDelVehiculo = padre
        tipo.SelectedIndex = 0
    End Sub

    Public Sub New(informePrevio As Controladores.InformeDeDaños, subida As Boolean, papote As panelInfoVehiculo) 'FALSE PARA ENVIO POR ACTULIZACION, TRUE POR INSERCION TOTAL
        InitializeComponent()
        Me.subida = subida
        panelVehiculo = papote
        Info = informePrevio
        _nuevo = False
        If Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR Then
            tipo.Enabled = True
        Else
            tipo.Enabled = False
        End If
        descipt.Text = informePrevio.Descripcion
        For Each reg As Controladores.RegistroDaños In informePrevio.Registros
            If reg.Descripcion.Length > 30 Then
                Registros.Items.Add(reg.Descripcion.Substring(0, 30))
            Else
                Registros.Items.Add(reg.Descripcion)
            End If
        Next
        _listaDeTodosLosinformes = New List(Of Controladores.InformeDeDaños)
        If informePrevio.Tipo IsNot Nothing Then
            Select Case informePrevio.Tipo
                Case Controladores.InformeDeDaños.TIPO_INFORME_PARCIAL
                    tipo.SelectedIndex = 0
                Case Controladores.InformeDeDaños.TIPO_INFORME_TOTAL
                    tipo.SelectedIndex = 1
            End Select
        Else
            tipo.SelectedIndex = 0
        End If

    End Sub

    Public Sub New(InformePrevio As Controladores.InformeDeDaños, padre As nuevoVehiculo)
        InitializeComponent()
        Info = InformePrevio
        _nuevo = True
        PanelDelVehiculo = padre
        If Controladores.Fachada.getInstancia.DevolverUsuarioActual.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR Then
            tipo.Enabled = True
        Else
            tipo.Enabled = False
        End If
        descipt.Text = InformePrevio.Descripcion
        For Each reg As Controladores.RegistroDaños In InformePrevio.Registros
            If reg.Descripcion.Length > 30 Then
                Registros.Items.Add(reg.Descripcion.Substring(0, 30))
            Else
                Registros.Items.Add(reg.Descripcion)
            End If
        Next
        _listaDeTodosLosinformes = New List(Of Controladores.InformeDeDaños)
        If InformePrevio.Tipo IsNot Nothing Then
            Select Case InformePrevio.Tipo
                Case Controladores.InformeDeDaños.TIPO_INFORME_PARCIAL
                    tipo.SelectedIndex = 0
                Case Controladores.InformeDeDaños.TIPO_INFORME_TOTAL
                    tipo.SelectedIndex = 1
            End Select
        Else
            tipo.SelectedIndex = 0
        End If

    End Sub

    Public ReadOnly Property InformeDeDaños() As Controladores.InformeDeDaños
        Get
            Return Info
        End Get
    End Property

    Private m As DataTable
    Private ReadOnly informe As Integer



    Private Sub descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        Dim length As Integer = 255 - descipt.Text.Length
        cp.Text = length
        If length < 0 Then
            cp.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            cp.ForeColor = Color.FromArgb(35, 35, 35)
        End If
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel(Me))
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
    End Sub

    Private Sub ingresarBtn_Click(sender As Object, e As EventArgs)
        If descipt.Text.Trim.Length = 0 Then
            MsgBox("Nesesita una descripcion", MsgBoxStyle.Critical)
            Return
        End If
        Info.Descripcion = descipt.Text
        Select Case tipo.SelectedIndex
            Case 0
                Info.Tipo = Controladores.InformeDeDaños.TIPO_INFORME_PARCIAL
            Case 1
                Info.Tipo = Controladores.InformeDeDaños.TIPO_INFORME_PARCIAL
        End Select
        If PanelDelVehiculo Is Nothing Then
            If subida Then
                Controladores.Fachada.getInstancia.nuevoInformeDeDaños(Info)
            Else

            End If
            panelVehiculo.ActualizarLotesExternos()
        Else
            Info.Descripcion = descipt.Text.Trim
            Select Case tipo.SelectedIndex
                Case 0
                    Info.Tipo = Controladores.InformeDeDaños.TIPO_INFORME_PARCIAL
                Case 1
                    Info.Tipo = Controladores.InformeDeDaños.TIPO_INFORME_TOTAL
            End Select
            Info.Fecha = DateTime.Now
            Info.Lugar = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar
            Info.Creador = Controladores.Fachada.getInstancia.DevolverUsuarioActual
            PanelDelVehiculo.NotificarDeInforme(Info)
        End If
        Me.Dispose()
        Marco.cerrarPanel(Of crearInformaDeDaños)()
    End Sub


    Public Sub devolverRegistro(r As Controladores.RegistroDaños)
        If numRegistroAEditar = -1 Then
            Info.Registros.Add(r)
            If r.Descripcion.Length > 30 Then
                Registros.Items.Add(r.Descripcion.Substring(0, 30))
            Else
                Registros.Items.Add(r.Descripcion)
            End If
        Else
            Info.Registros.RemoveAt(numRegistroAEditar)
            Registros.Items.RemoveAt(numRegistroAEditar)
            Info.Registros.Insert(numRegistroAEditar, r)
            If r.Descripcion.Length > 30 Then
                Registros.Items.Insert(numRegistroAEditar, r.Descripcion.Substring(0, 30))
            Else
                Registros.Items.Insert(numRegistroAEditar, r.Descripcion)
            End If
            numRegistroAEditar = -1
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If Registros.SelectedIndex = -1 Then
            MsgBox("Debe selecionar cual registro desea modificar", MsgBoxStyle.Critical)
        Else
            numRegistroAEditar = Registros.SelectedIndex
            Marco.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel(Me, Info.Registros(Registros.SelectedIndex)))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If Registros.SelectedIndex = -1 Then
            MsgBox("Eliga un registro que eliminar")
        Else
            Info.Registros.RemoveAt(Registros.SelectedIndex)
            Registros.Items.RemoveAt(Registros.SelectedIndex)
        End If
    End Sub


End Class