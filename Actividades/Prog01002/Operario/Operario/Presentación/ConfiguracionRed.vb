Public Class ConfiguracionRed
    Private papa As Login
    Public Sub New(padre As Login)
        papa = padre
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Function enviarDatos()

        If papa.pruebaConect(ip.Text, puerto.Text, nomservidor.Text, nomInformix.Text, pass.Text, nomBd.Text) = 1 Then
            papa.conectar(ip.Text, puerto.Text, nomservidor.Text, nomInformix.Text, pass.Text, nomBd.Text)
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If enviarDatos() = 1 Then
            Me.Close()
        Else
            MsgBox("No se puedo realizar la conexcion", MsgBoxStyle.Critical)
        End If
    End Sub


End Class