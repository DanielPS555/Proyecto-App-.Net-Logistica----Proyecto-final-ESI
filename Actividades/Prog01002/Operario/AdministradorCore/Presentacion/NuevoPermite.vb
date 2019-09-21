Public Class NuevoPermite
    Private ListaMedios As List(Of Controladores.MedioDeTransporte)
    Private usuario As Controladores.Usuario
    Private papa As Controladores.NotificacionSimple
    Public Sub New(user As Controladores.Usuario, act As Controladores.NotificacionSimple)
        InitializeComponent()

        Me.ListaMedios = Controladores.Fachada.getInstancia.ListaDeMediosDelSistema
        If ListaMedios.Count = 0 Then
            medios.Enabled = False
            MsgBox("No hay medios disponibles", MsgBoxStyle.Critical)
        Else
            For Each m As Controladores.MedioDeTransporte In Me.ListaMedios
                medios.Items.Add($"Nom: {m.Nombre} / Id: {m.ID}")
            Next
            medios.SelectedIndex = 0
        End If
        usuario = user
        papa = act
    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If medios.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un medio", MsgBoxStyle.Critical)
            Return
        End If

        If Controladores.Fachada.getInstancia.comprobarPermiteExistente(ListaMedios.Item(medios.SelectedIndex), usuario) Then
            MsgBox("Este usuario ya tiene permitido manejar dicho medio", MsgBoxStyle.Critical)
            Return
        End If

        Controladores.Fachada.getInstancia.NuevoPermite(ListaMedios.Item(medios.SelectedIndex), usuario)
        papa.actualizarPanel()
        MsgBox("Permite ingrezado con exito")
        Me.Close()

    End Sub
End Class