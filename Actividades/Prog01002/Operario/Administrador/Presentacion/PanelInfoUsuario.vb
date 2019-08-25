
Public Class PanelInfoUsuario

    Dim user As Controladores.Usuario
    Dim ListaTrabajaen As DataTable

    Public Sub New(idusuario As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        user = New Controladores.Usuario() With {.ID_usuario = idusuario}
        cargarDatosBasicos()



    End Sub

    Private Sub cargarDatosBasicos()
        user = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(user.ID_usuario)
        nombreDeUsuario.Text = user.NombreDeUsuario
        idusuario.Text = user.ID_usuario

        nombreCompleto.Text = $"{user.Nombre} {user.Apellido}"
        fechaNac.Value = user.FechaNacimiento
        email.Text = user.Email
        telefono.Text = user.Telefono
        Select Case user.sexo
            Case "M"
                sexo.SelectedIndex = 0
            Case "F"
                sexo.SelectedIndex = 1
            Case "O"
                sexo.SelectedIndex = 2
        End Select
        creador.Text = user.Creador.Nombre
        fechaCreacion.Text = user.FechaCreacion

        Select Case user.Rol
            Case "A"
                rol.Text = "Administrador"

            Case "O"
                rol.Text = "Operario"
                datosDelOperario()
            Case "T"
                rol.Text = "Transportista"
                datosDelTransportista()
        End Select

    End Sub

    Private Sub datosDelOperario()
        tab.TabPages.RemoveAt(5)
        tab.TabPages.RemoveAt(4)
        ListaTrabajaen = Controladores.Fachada.getInstancia.DevolverLosTrabajaEnPorUsuario(user.ID_usuario)
        lugarDeTrabajos.DataSource = ListaTrabajaen
        nuevosVehiculos.DataSource = Controladores.Fachada.getInstancia.devolverVehiculosIngresadosPorIdusuario(user.ID_usuario)
        inspecionadosVehiculos.DataSource = Controladores.Fachada.getInstancia.vehiculosInspecionadosPorUsuario(user.ID_usuario)
    End Sub

    Private Sub datosDelTransportista()
        tab.TabPages.RemoveAt(3)
        tab.TabPages.RemoveAt(2)
        tab.TabPages.RemoveAt(1)
        mediosAuto.DataSource = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(user.ID_usuario)
        tablatransportes.DataSource = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(user.ID_usuario)
    End Sub



End Class