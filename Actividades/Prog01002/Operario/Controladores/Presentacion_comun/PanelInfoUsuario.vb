Public Class PanelInfoUsuario
    Implements NotificacionSimple
    Dim filaSelexMedio As Integer = -1
    Dim filaSelex As Integer = -1
    Protected Friend user As Controladores.Usuario
    Dim ListaTrabajaen As DataTable
    Dim listaMedios As DataTable

    Public Sub New(idusuario As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        user = New Controladores.Usuario() With {.ID_usuario = idusuario}
        cargarDatosBasicos()
    End Sub

    Public Sub actualizarPanel() Implements NotificacionSimple.actualizarPanel
        If user.Rol = Controladores.Usuario.TIPO_ROL_OPERARIO Then
            ListaTrabajaen = Controladores.Fachada.getInstancia.DevolverLosTrabajaEnPorUsuario(user.ID_usuario)
            lugarDeTrabajos.DataSource = ListaTrabajaen
        End If


        If user.Rol = Controladores.Usuario.TIPO_ROL_TRANSPORTISTA Then
            listaMedios = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(user.ID_usuario)
            mediosAuto.DataSource = listaMedios
        End If
    End Sub

    Private Sub cargarDatosBasicos()
        user = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(user.ID_usuario)
        nombreDeUsuario.Text = user.NombreDeUsuario
        idusuario.Text = user.ID_usuario
        conect.DataSource = Controladores.Fachada.getInstancia.ConexcionDeUsuarioTabla(user)

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
                tab.TabPages.RemoveAt(2)
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
        listaMedios = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(user.ID_usuario)
        mediosAuto.DataSource = listaMedios
        tablatransportes.DataSource = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(user.ID_usuario)
    End Sub




    Private Sub LugarDeTrabajos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles lugarDeTrabajos.CellClick
        filaSelex = e.RowIndex
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If filaSelex <> -1 Then
            If Controladores.Funciones_comunes.AutoNull(Of Object)(ListaTrabajaen.Rows(filaSelex).Item(3)) Is Nothing Then
                Controladores.Fachada.getInstancia.terminarTrabajaEn(New Controladores.TrabajaEn() With {.Id = ListaTrabajaen.Rows(filaSelex).Item(0)})
                actualizarPanel()
                MsgBox("Perido terminado", MsgBoxStyle.Information)
            Else
                MsgBox("Este periodo de trabajo ya expiro", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Debe selecionar una fila que eliminar", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub MediosAuto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles mediosAuto.CellClick
        filaSelexMedio = e.RowIndex
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If filaSelexMedio = -1 Then
            MsgBox("Selecione un permiso de conducion que eliminar", MsgBoxStyle.Critical)
            Return
        End If

        If MsgBox("Esta seguro que desea eliminar el permiso", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Controladores.Fachada.getInstancia.InavilitarPermite(New Controladores.MedioDeTransporte With {.ID = listaMedios.Rows(filaSelexMedio).Item(0)}, user)
            actualizarPanel()
            MsgBox("Eliminacion realizada")
        End If

    End Sub
End Class