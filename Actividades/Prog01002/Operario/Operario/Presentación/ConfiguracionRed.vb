Imports Controladores.Fachada
Public Class ConfiguracionRed
    Private papa As Login
    Private Config As Controladores.FachadaRegistro.ConfiguracionEnRed
    Public Sub New(p As Login)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        papa = p
        Config = Controladores.FachadaRegistro.LeerConfiguracion
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
        If Controladores.Fachada.getInstancia.ProbarConexcion(Config) Then
            Controladores.FachadaRegistro.GuardarConfiguracion(Config)
            Controladores.Fachada.getInstancia.IniciarConexcion(Config)
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
            papa.NotificarDeConexcion(True)
            Me.Close()
        Else
            MsgBox("No se puedo realizar la conexcion", MsgBoxStyle.Critical)
            papa.NotificarDeConexcion(False)
        End If
    End Sub

    Private Sub ConfiguracionRed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class