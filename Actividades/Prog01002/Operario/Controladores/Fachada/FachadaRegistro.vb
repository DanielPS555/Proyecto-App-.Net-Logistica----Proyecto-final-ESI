Public Module FachadaRegistro
    Structure ConfiguracionEnRed
        Dim IP As String
        Dim Puerto As Integer
        Dim ServerName As String
        Dim UserName As String
        Dim Password As String
        Dim Database As String

        Friend Sub New(iP As String, puerto As Integer, serverName As String, userName As String, password As String, database As String)
            Me.IP = iP
            Me.Puerto = puerto
            Me.ServerName = serverName
            Me.UserName = userName
            Me.Password = password
            Me.Database = database
        End Sub
    End Structure
    Private Const KeyName As String = "HKEY_CURRENT_USER\Software\Bit\SLTA"
    Public Function GuardarConfiguracion(cfg As ConfiguracionEnRed) As Boolean
        Try
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix IP", cfg.IP, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix Port", cfg.Puerto, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix Server name", cfg.ServerName, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Username", cfg.UserName, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Password", cfg.Password, Microsoft.Win32.RegistryValueKind.String)
            Microsoft.Win32.Registry.SetValue(KeyName, "Database", cfg.Database, Microsoft.Win32.RegistryValueKind.String)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function
    Public Function LeerConfiguracion() As ConfiguracionEnRed
        If Microsoft.Win32.Registry.GetValue(KeyName, "Informix IP", Nothing) Is Nothing Then
            Microsoft.Win32.Registry.SetValue(KeyName, "Informix IP", "localhost", Microsoft.Win32.RegistryValueKind.String)
        End If
        Return New ConfiguracionEnRed(
            Microsoft.Win32.Registry.GetValue(KeyName, "Informix IP", "localhost"),
            Microsoft.Win32.Registry.GetValue(KeyName, "Informix Port", "9088"),
            Microsoft.Win32.Registry.GetValue(KeyName, "Informix Server name", "ol_esi"),
            Microsoft.Win32.Registry.GetValue(KeyName, "Username", "root"),
            Microsoft.Win32.Registry.GetValue(KeyName, "Password", Nothing),
            Microsoft.Win32.Registry.GetValue(KeyName, "Database", "bit"))
    End Function
End Module
