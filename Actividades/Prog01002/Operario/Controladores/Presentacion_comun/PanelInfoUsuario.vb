Imports Controladores.Extenciones.Extensiones
Public Class PanelInfoUsuario
    Implements NotificacionSimple
    Dim filaSelexMedio As Integer = -1
    Dim filaSelex As Integer = -1
    Protected Friend user As Controladores.Usuario
    Dim ListaTrabajaen As DataTable
    Dim listaMedios As DataTable
    Private cambioDatos As Boolean = False
    Private anteriorLINk As String

    Public Sub New(idusuario As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label13.Traducir
        Label1.Traducir
        Label6.Traducir
        Label2.Traducir
        Label5.Traducir
        Label3.Traducir
        Label4.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        editarInfo.Traducir
        CambiarDatosPersonales.Traducir
        Button1.Traducir
        Button2.Traducir
        Button4.Traducir
        Button3.Traducir


        'falta traducir la tablita de arriba tab.tabpages algo -facu.
        user = New Controladores.Usuario() With {.ID_usuario = idusuario}
        cargarDatosBasicos()
        editarInfo.Visible = (idusuario = Fachada.getInstancia.DevolverUsuarioActual.ID_usuario)
    End Sub

    Public Sub actualizarPanel() Implements NotificacionSimple.actualizarPanel
        If user.Rol = Controladores.Usuario.TIPO_ROL_OPERARIO Then
            ListaTrabajaen = Controladores.Fachada.getInstancia.DevolverLosTrabajaEnPorUsuario(user.ID_usuario)
            lugarDeTrabajos.DataSource = ListaTrabajaen
        End If


        If user.Rol = Controladores.Usuario.TIPO_ROL_TRANSPORTISTA Or user.Rol = Controladores.Usuario.TIPO_ROL_ADMINISTRADOR Then
            listaMedios = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(user.ID_usuario)
            mediosAuto.DataSource = listaMedios
        End If
    End Sub

    Private Sub cargarDatosBasicos()
        user = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(user.ID_usuario)
        nombreDeUsuario.Text = user.NombreDeUsuario
        idusuario.Text = user.ID_usuario
        conect.DataSource = Controladores.Fachada.getInstancia.ConexcionDeUsuarioTabla(user)

        nombre.Text = user.Nombre
        apellido.Text = user.Apellido
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
                rol.Text = Controladores.Funciones_comunes.I18N("Administrador", Controladores.Marco.Language)
                tab.TabPages.RemoveAt(1)
                listaMedios = Controladores.Fachada.getInstancia.TablaDeMediosPorIDUsuario(user.ID_usuario)
                mediosAuto.DataSource = listaMedios
                tablatransportes.DataSource = Controladores.Fachada.getInstancia.ListaDeTrasportesPorIdUsuario(user.ID_usuario)
                anteriorLINk = Fachada.getInstancia.linkDelTransportista(user.ID_usuario)
                link.Text = anteriorLINk
                nuevosVehiculos.DataSource = Controladores.Fachada.getInstancia.devolverVehiculosIngresadosPorIdusuario(user.ID_usuario)
                inspecionadosVehiculos.DataSource = Controladores.Fachada.getInstancia.vehiculosInspecionadosPorUsuario(user.ID_usuario)
                Label10.Visible = True
                link.Visible = True
            Case "O"
                rol.Text = Controladores.Funciones_comunes.I18N("Operario", Controladores.Marco.Language)
                datosDelOperario()
            Case "T"
                rol.Text = Controladores.Funciones_comunes.I18N("Transportista", Controladores.Marco.Language)
                datosDelTransportista()
                Label10.Visible = True
                link.Visible = True

        End Select

        If user.ID_usuario = Controladores.Fachada.getInstancia.DevolverUsuarioActual.ID_usuario Then
            invalidado.Visible = False
        Else
            cargarinvalidado()
        End If
    End Sub

    Private Sub cargarinvalidado()
        If Controladores.Fachada.getInstancia.usuarioInvalidado(user.NombreDeUsuario) Then
            invalidado.Text = "Validar"
        Else
            invalidado.Text = "Invalidar"
        End If
        invalidado.Traducir
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
        anteriorLINk = Fachada.getInstancia.linkDelTransportista(user.ID_usuario)
        link.Text = anteriorLINk
    End Sub




    Private Sub LugarDeTrabajos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles lugarDeTrabajos.CellClick
        filaSelex = e.RowIndex
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            MsgBox("Debe ser administrador para realizar esta accion", MsgBoxStyle.Critical)
            Return
        End If

        If filaSelex <> -1 Then
            If Controladores.Funciones_comunes.AutoNull(Of Object)(ListaTrabajaen.Rows(filaSelex).Item(3)) Is Nothing Then
                Controladores.Fachada.getInstancia.terminarTrabajaEn(New Controladores.TrabajaEn() With {.Id = ListaTrabajaen.Rows(filaSelex).Item(0)})
                actualizarPanel()
                MsgBoxI18N("Perido terminado", MsgBoxStyle.Information)
            Else
                MsgBoxI18N("Este periodo de trabajo ya expiro", MsgBoxStyle.Critical)
            End If
        Else
            MsgBoxI18N("Debe selecionar una fila que eliminar", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub MediosAuto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles mediosAuto.CellClick
        filaSelexMedio = e.RowIndex
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            MsgBox("Debe ser administrador para realizar esta accion", MsgBoxStyle.Critical)
            Return
        End If
        If filaSelexMedio = -1 Then
            MsgBoxI18N("Selecione un permiso de conducion que eliminar", MsgBoxStyle.Critical)
            Return
        End If

        If MsgBox(Controladores.Funciones_comunes.I18N("Esta seguro que desea eliminar el permiso", Controladores.Marco.Language), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Controladores.Fachada.getInstancia.InavilitarPermite(New Controladores.MedioDeTransporte With {.ID = listaMedios.Rows(filaSelexMedio).Item(0)}, user)
            actualizarPanel()
            MsgBoxI18N("Eliminacion realizada")
        End If

    End Sub

    Private Sub EditarInfo_Click(sender As Object, e As EventArgs) Handles editarInfo.Click
        Dim ee = New CredencialesUsuario(False)
        ee.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR Then
            Dim m As New NuevoTrabajaEn(user, Me)
            m.ShowDialog()
        Else
            MsgBox("Debe ser administrador para realizar esta accion", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            MsgBox("Debe ser administrador para realizar esta accion", MsgBoxStyle.Critical)
            Return
        End If
        Dim m As New NuevoPermite(user, Me)
        m.ShowDialog()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Invalidado_Click(sender As Object, e As EventArgs) Handles invalidado.Click
        Controladores.Fachada.getInstancia.modificarInvalidadoDelUsuario(user.ID_usuario, Not Controladores.Fachada.getInstancia.usuarioInvalidado(user.NombreDeUsuario))
        cargarinvalidado()
    End Sub

    Private Sub CambiarDatosPersonales_Click(sender As Object, e As EventArgs) Handles CambiarDatosPersonales.Click
        If cambioDatos Then
            'ENVIAR DATOS NUEVOS PERO ANTES VERIFICAR 
            If nombre.Text.Trim.Length * apellido.Text.Trim.Length * email.Text.Trim.Length * telefono.Text.Trim.Length = 0 Then
                MsgBoxI18N("Alguno de los campos esta vacio, verifiquelos", MsgBoxStyle.Critical)
                Return
            End If

            If nombre.Text.Trim.Length > 50 Then
                MsgBoxI18N("El nombre de usuario es demaciado largo, no mas de 50 caracteres", MsgBoxStyle.Critical)
                Return
            End If

            If apellido.Text.Trim.Length > 50 Then
                MsgBoxI18N("El Apellido de usuario es demaciado largo, no mas de 50 caracteres", MsgBoxStyle.Critical)
                Return
            End If

            If Not Controladores.Funciones_comunes.formatoCorrectoDelEmail(email.Text) Then
                MsgBoxI18N("El correo no tiene el formato correcto", MsgBoxStyle.Critical)
                Return
            End If

            If telefono.Text.Length < 9 OrElse telefono.Text.Length > 15 Then
                MsgBoxI18N("El telefono puede ser unicamente entre 9 a 15 numeros", MsgBoxStyle.Critical)
                Return
            End If

            If Not Controladores.Funciones_comunes.soloNumeros(telefono.Text) Then
                MsgBoxI18N("El telefono debe ser puramente numerico", MsgBoxStyle.Critical)
                Return
            End If

            If sexo.SelectedIndex = -1 Then
                MsgBoxI18N("Debe selecionar un sexo", MsgBoxStyle.Critical)
                Return
            End If
            If fechaNac.Value > Date.Now Then
                MsgBoxI18N("No puede haber nacido en el futuro", MsgBoxStyle.Critical)
                Return
            End If
            Dim edadUsuario = (Date.Now - fechaNac.Value).TotalDays / 365.0!
            If edadUsuario < 18 OrElse edadUsuario > 55 Then ' Jubilación prematura y jornada laboral de 6 horas YA
                MsgBoxI18N("No puede tener menos de 18 años o más de 55", MsgBoxStyle.Critical)
                Return
            End If
            user.Nombre = nombre.Text
            user.Email = email.Text
            user.Telefono = telefono.Text
            user.Apellido = apellido.Text
            user.FechaNacimiento = fechaNac.Value
            Select Case sexo.SelectedIndex
                Case 0
                    user.sexo = "M"
                Case 1
                    user.sexo = "F"
                Case 2
                    user.sexo = "O"
            End Select
            Controladores.Fachada.getInstancia.cambiarDatosbasicosUsuario(user)
            habilitar(False)
            cambioDatos = False
            CambiarDatosPersonales.Text = "Editar informacion Personal"
            CambiarDatosPersonales.Traducir
        Else
            habilitar(True)
            cambioDatos = True
            CambiarDatosPersonales.Text = "Guardar"
            CambiarDatosPersonales.Traducir
        End If
    End Sub

    Private Sub habilitar(j As Boolean)
        nombre.Enabled = j
        apellido.Enabled = j
        email.Enabled = j
        telefono.Enabled = j
        sexo.Enabled = j
        fechaNac.Enabled = j
        cambioDatos = j
    End Sub

    Private Sub Link_TextChanged(sender As Object, e As EventArgs) Handles link.TextChanged
        If link.Text.Trim.Length > 0 AndAlso Not link.Text.Equals(anteriorLINk) Then
            If link.Text.Length > 255 Then
                MsgBoxI18N("No puede superar los 255 caracteres", MsgBoxStyle.Critical)
            Else
                guardar.Enabled = True
            End If

        Else
                guardar.Enabled = False
        End If
    End Sub

    Private Sub Guardar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles guardar.LinkClicked
        anteriorLINk = link.Text
        Controladores.Fachada.getInstancia.modificarLinkTransportista(user.ID_usuario, anteriorLINk)
        guardar.Enabled = False
        MsgBoxI18N("Cambio realizado con exito", MsgBoxStyle.Information)
    End Sub
End Class