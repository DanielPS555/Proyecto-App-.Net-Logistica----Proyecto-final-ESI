Imports Controladores.Extenciones.Extensiones

Public Class PanelTrasporte
    Private t As Controladores.Trasporte
    Public Sub New(idtransporte)
        InitializeComponent()
        Label2.Traducir
        Label3.Traducir
        Label10.Traducir
        Label4.Traducir
        Label5.Traducir
        Label6.Traducir
        Label7.Traducir
        Label8.Traducir
        Label9.Traducir
        verUbicacion.Traducir

        t = Controladores.Fachada.getInstancia.InformacionCompletaDelTrasporteSIN_LOTES(idtransporte)
        id.Text = t.ID
        conductor.Text = t.Trasportista.NombreDeUsuario
        nombreMedio.Text = t.MedioDeTrasporte.Nombre
        tipoMedio.Text = t.MedioDeTrasporte.Tipo.Nombre
        HoraDeCreacion.Text = t.FechaCreacion
        FechaDeInico.Text = t.FechaSalida
        estado.Text = t.Estado
        If t.Estado.Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO) And Fachada.getInstancia.DevolverUsuarioActual.Rol = Usuario.TIPO_ROL_ADMINISTRADOR Then
            cancelacion.Visible = True
            verUbicacion.Visible = True
        End If

        Dim lotes As DataTable = Controladores.Fachada.getInstancia.listaDeLotesPorTransporte(idtransporte)
        lote.DataSource = lotes

        Dim real As DateTime? = Controladores.Funciones_comunes.AutoNull(Of Object)(lotes.Rows(0).Item(6))
        Dim estimada As DateTime? = Controladores.Funciones_comunes.AutoNull(Of Object)(lotes.Rows(0).Item(7))

        For Each l As DataRow In lotes.Rows
            If real IsNot Nothing AndAlso l.Item(6) > real Then
                real = l.Item(6)
            End If

            If estimada IsNot Nothing AndAlso l.Item(7) > estimada Then
                estimada = l.Item(7)
            End If
        Next


        FechaDeFinalizacionEstimada.Text = If(estimada Is Nothing, Controladores.Funciones_comunes.I18N("SIN INFORMACION", Controladores.Marco.Language), estimada)
        FechaDeFinalizacionReal.Text = If(real Is Nothing, Controladores.Funciones_comunes.I18N("SIN INFORMACION", Controladores.Marco.Language), real)

    End Sub

    Private Sub Cancelacion_Click(sender As Object, e As EventArgs) Handles cancelacion.Click
        If MsgBox("¿Esta seguro que desea cancelar el transprote?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Controladores.Fachada.getInstancia.estadoDeUnTrasporte(t.ID).Equals(Controladores.Trasporte.TIPO_ESTADO_PROSESO) Then
                Controladores.Fachada.getInstancia.CancelacionAbrutctaTransporte(t)
                MsgBox("Transporte finalizado", MsgBoxStyle.Information)
                cancelacion.Visible = False
            Else
                MsgBox("El transporte ya habia finalizado")
                cancelacion.Visible = False
            End If
        End If
    End Sub

    Private Sub VerUbicacion_Click(sender As Object, e As EventArgs) Handles verUbicacion.Click
        Dim ss As String = Fachada.getInstancia.linkTransportistaPorIdTransporte(t.ID)
        If ss IsNot Nothing AndAlso Controladores.Funciones_comunes.URLExist(ss) Then
            Dim pepe As New Controladores.TiempoRealGooglePlex(ss)
            pepe.ShowDialog()
        Else
            MsgBox("URL invalida")
        End If
    End Sub
End Class