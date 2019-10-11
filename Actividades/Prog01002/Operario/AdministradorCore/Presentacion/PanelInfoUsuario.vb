Imports Controladores

Public Class PanelInfoUsuario
    Inherits Controladores.PanelInfoUsuario

    Public Sub New(idusuario As Integer)
        MyBase.New(idusuario)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim m As New NuevoPermite(user, Me)
        m.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m As New NuevoTrabajaEn(user, Me)
        m.ShowDialog()
    End Sub
End Class
