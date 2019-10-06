Imports System.Windows.Forms

Public Class ConfigurarRed
    Public Interface INotifyCallback
        Sub NotificarDeConexion(exitoso As Boolean, Optional config As ConfiguracionEnRed = Nothing)
    End Interface
    Private papa As INotifyCallback
    Private Config As ConfiguracionEnRed
    Public Sub New(p As INotifyCallback)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        papa = p
        Config = LeerConfiguracion()
        ip.Text = Config.IP
        puerto.Text = Config.Puerto
        nomservidor.Text = Config.ServerName
        nomInformix.Text = Config.UserName
        pass.Text = Config.Password
        nomBd.Text = Config.Database
    End Sub

    Public Function EnviarDatos() As Boolean
        Config.IP = ip.Text
        Config.Puerto = Integer.Parse(puerto.Text)
        Config.ServerName = nomservidor.Text
        Config.UserName = nomInformix.Text
        Config.Password = pass.Text
        Config.Database = nomBd.Text
        If Config.Probar() Then
            Config.Guardar()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If EnviarDatos() Then
            If papa IsNot Nothing Then
                papa.NotificarDeConexion(True, Me.Config)
            End If
            Me.Close()
        Else
            MsgBox("No se puedo realizar la conexcion", MsgBoxStyle.Critical)
            If papa IsNot Nothing Then
                papa.NotificarDeConexion(False)
            End If
        End If
    End Sub
End Class