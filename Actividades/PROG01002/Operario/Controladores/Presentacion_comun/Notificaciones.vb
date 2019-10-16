Public Class Notificaciones
    Dim alfa As Alfa
    Private listaNotificaciones As List(Of Notificacion)
    Private tiposElementos As New List(Of Tuple(Of String, String))

    Public Sub New()
        InitializeComponent()
        tiposElementos.Add(New Tuple(Of String, String)(Nothing, "Todos"))
        Select Case Fachada.getInstancia.DevolverUsuarioActual.Rol
            Case Usuario.TIPO_ROL_OPERARIO
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_CAMBIO_DISTIBUCION_LUGAR, "Cambio de lugar"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_TRABAJAEN, "Nueva lugar de trabajo para operario"))
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_CAMBIO_DISTIBUCION_LUGAR, "Cambio de lugar"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_TRABAJAEN, "Nueva lugar de trabajo para operario"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_GENERICO, "Genericos"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_INTENTO_ALTA_CON_MAL_VIN, "Intento fallido de alta"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVA_ANULACION, "Nueva anulacion"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVA_ENTREGA, "Nueva entrega"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_ALTA, "Nueva alta"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_LUGAR, "Nueva Lugar"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_MEDIO, "Nueva Medio"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_PERDIDA, "Nueva Perdida"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_USUARIO, "Nueva usuario"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_GENERICO, "Generica"))
            Case Usuario.TIPO_ROL_TRANSPORTISTA
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_TRANSPORTE_FALLIDO, "Transporte fallidos"))
                tiposElementos.Add(New Tuple(Of String, String)(Notificacion.TIPO_NOTIFICACION_NUEVO_PERMITE, "Nueva Permite"))
        End Select

        For Each t In tiposElementos
            tipos.Items.Add(t.Item2)
        Next

        alfa = New Alfa(GetType(Notificacion), GetType(SUB_Notificacion))
        Me.Controls.Add(alfa)
        alfa.Size = New Drawing.Size(495, 625)
        alfa.Location = New Point(373, 12)
        alfa.Anchor = (AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top)
        listaNotificaciones = Controladores.Fachada.getInstancia.ListaDeTodasLasNotificacionesDelSistema(Fachada.getInstancia.DevolverUsuarioActual.Rol)
        tipos.SelectedIndex = 0

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipos.SelectedIndexChanged
        alfa.Limpiar()
        Dim elementos As New List(Of Notificacion)
        Dim tipoElegido = tiposElementos(tipos.SelectedIndex).Item1
        If tipoElegido Is Nothing Then
            elementos = listaNotificaciones
        Else
            For Each nnn As Notificacion In listaNotificaciones
                If nnn.Tipo = tipoElegido Then
                    elementos.Add(nnn)
                End If
            Next
        End If
        If elementos.Count = 0 Then
            alfa.Visible = False
            SinElementos.Visible = True
        Else
            alfa.Visible = True
            SinElementos.Visible = False
        End If
        For Each no As Notificacion In elementos
            alfa.Nuevo(no, False)
        Next
        alfa.render()
    End Sub
End Class