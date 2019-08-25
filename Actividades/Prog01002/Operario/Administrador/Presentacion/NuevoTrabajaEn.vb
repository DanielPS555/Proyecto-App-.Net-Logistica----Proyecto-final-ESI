Public Class NuevoTrabajaEn
    Private lugares As List(Of Controladores.Lugar)
    Private user As Controladores.Usuario
    Private actualizacion As NotificacionTrabajaEn
    Public Sub New(user As Controladores.Usuario, act As NotificacionTrabajaEn)
        InitializeComponent()
        lugares = Controladores.Fachada.getInstancia.todoslosPatiosYPuertos
        For Each lug As Controladores.Lugar In lugares
            lugar.Items.Add($"Nom: {lug.Nombre} / Id: {lug.Tipo}")
        Next
        Me.user = user
        actualizacion = act
    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Controladores.Fachada.getInstancia.TrabajaenVijente(lugares.Item(lugar.SelectedIndex).IDLugar, user.ID_usuario) Then
            MsgBox("Este usuario ya trabaja en este lugar", MsgBoxStyle.Critical)
            Return
        Else
            Dim tr As New Controladores.TrabajaEn With {.Lugar = lugares.Item(lugar.SelectedIndex),
                                                      .Usuario = user}
            Controladores.Fachada.getInstancia.NuevoTrabajaEn(tr)
            actualizacion.actualizarPanel()
            MsgBox("Ingrezado con exito")

            Me.Close()
        End If
    End Sub
End Class