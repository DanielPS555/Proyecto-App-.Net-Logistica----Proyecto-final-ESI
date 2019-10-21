Public Class NuevoTrabajaEn
    Private lugares As List(Of Controladores.Lugar)
    Private user As Controladores.Usuario
    Private actualizacion As Controladores.NotificacionSimple
    Public Sub New(user As Controladores.Usuario, act As Controladores.NotificacionSimple)
        InitializeComponent()
        lugares = Controladores.Fachada.getInstancia.todoslosPatiosYPuertos
        If lugares.Count > 0 Then
            For Each lug As Controladores.Lugar In lugares
                lugar.Items.Add($"Nom: {lug.Nombre} / Id: {lug.Tipo}")
            Next
            Me.user = user
            actualizacion = act
            lugar.SelectedIndex = 0
        Else
            lugar.Enabled = False
            MsgBox("No hay lugares que selecionar", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lugar.SelectedIndex = -1 Then
            MsgBox("Debe Selecionar un lugar", MsgBoxStyle.Critical)
            Return
        End If
        If Controladores.Fachada.getInstancia.TrabajaenVijente(lugares.Item(lugar.SelectedIndex).IDLugar, user.ID_usuario) Then
            MsgBox("Este usuario ya trabaja en este lugar", MsgBoxStyle.Critical)
            Return
        Else
            Dim tr As New Controladores.TrabajaEn With {.Lugar = lugares.Item(lugar.SelectedIndex),
                                                      .Usuario = user}
            Dim id = Controladores.Fachada.getInstancia.NuevoTrabajaEn(tr)
            Dim notifi As New Notificacion(Notificacion.TIPO_NOTIFICACION_NUEVO_TRABAJAEN) With {.Fecha = DateTime.Now,
                                                                                            .Ref1 = id,
                                                                                            .Ref2 = Fachada.getInstancia.DevolverUsuarioActual.ID_usuario}
            Fachada.getInstancia.NuevaNotificacion(notifi)
            actualizacion.actualizarPanel()
            MsgBox("Ingrezado con exito", MsgBoxStyle.Information)

            Me.Close()
        End If
    End Sub
End Class