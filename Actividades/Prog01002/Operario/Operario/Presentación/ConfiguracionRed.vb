Imports Controladores.Fachada
Public Class ConfiguracionRed
    Private Const KeyName As String = "HKEY_CURRENT_USER\Software\Bit\SLTA"
    Private papa As Login
    Public Sub New(p As Login)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        papa = p
        If Microsoft.Win32.Registry.GetValue(KeyName, "Informix IP", Nothing) Is Nothing Then
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix IP", "localhost", Microsoft.Win32.RegistryValueKind.String)
        End If
        ip.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Informix IP", "localhost")
        puerto.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Informix Port", "9088")
        nomservidor.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Informix Server name", "ol_esi")
        nomInformix.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Username", "root")
        pass.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Password", Nothing)
        nomBd.Text = Microsoft.Win32.Registry.GetValue(KeyName, "Database", "bit")
    End Sub

    Public Function enviarDatos()

        If Controladores.Fachada.getInstancia.ProbarConexcion(ip.Text, puerto.Text, nomservidor.Text, nomInformix.Text, pass.Text, nomBd.Text) Then
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix IP", ip.Text, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix Port", puerto.Text, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix Server name", nomservidor.Text, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Username", nomInformix.Text, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Password", pass.Text, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Database", nomBd.Text, Microsoft.Win32.RegistryValueKind.String)
            Controladores.Fachada.getInstancia.IniciarConexcion(ip.Text, puerto.Text, nomservidor.Text, nomInformix.Text, pass.Text, nomBd.Text)
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
            papa.NotificarDeConexcion(True)
            Me.Close()
        Else
            MsgBox("No se puedo realizar la conexcion", MsgBoxStyle.Critical)
            papa.NotificarDeConexcion(False)
        End If
    End Sub


End Class