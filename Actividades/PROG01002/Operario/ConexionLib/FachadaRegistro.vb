Imports System.Data.Odbc

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

        Public Function Probar() As Boolean
            Try
                Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & Database & ";Host=" & IP & ";Server=" & ServerName & ";Service=" &
                Puerto & ";UID=" & UserName & ";PWD=" & Password & ";"
                Dim con As New OdbcConnection(creacion)
                con.Open()
                con.Close()
                Return True
            Catch ee As Exception
                MsgBox("Error en la conexcion: " & ee.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Public Function Guardar() As Boolean
            Return GuardarConfiguracion(Me)
        End Function
    End Structure

    Private Const KeyName As String = "HKEY_CURRENT_USER\Software\Bit\SLTA"
    Public Function EliminarConfiguracion() As Boolean
        Try
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", True).DeleteSubKeyTree("Bit")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RegistrarPrograma(InstallPath As String) As Boolean
        If EstaRegistrado() Then Return False
        Try
            Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software", True).OpenSubKey("Bit", True).OpenSubKey("SLTA", True).SetValue("Path", InstallPath)
            Return True
        Catch e As Exception
            Console.WriteLine(e.ToString)
            Return False
        End Try
    End Function

    Public Function RegistrarDesinstalador(UninstallerPath As String) As Boolean
        Try
            Dim uninstKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software")
            uninstKey = uninstKey.OpenSubKey("Microsoft")
            uninstKey = uninstKey.OpenSubKey("Windows")
            uninstKey = uninstKey.OpenSubKey("CurrentVersion")
            uninstKey = uninstKey.OpenSubKey("Uninstall")
            uninstKey = uninstKey.OpenSubKey("SLTA", True)
            uninstKey.SetValue("DisplayName", "SLTA", Microsoft.Win32.RegistryValueKind.String)
            uninstKey.SetValue("UninstallString", UninstallerPath, Microsoft.Win32.RegistryValueKind.String)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Function EstaRegistrado() As Boolean
        Dim sfwKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software")
        If Not sfwKey.GetSubKeyNames.Contains("Bit") Then Return False
        Dim bitKey = sfwKey.OpenSubKey("Bit")
        If Not bitKey.GetSubKeyNames.Contains("SLTA") Then Return False
        Dim sltaKey = bitKey.OpenSubKey("SLTA")
        If Not sltaKey.GetValueNames.Contains("Path") OrElse Not System.IO.Directory.Exists(sltaKey.GetValue("Path")) Then Return False
        Return True
    End Function

    Public Function DesregistrarPrograma() As Boolean
        If Not EstaRegistrado() Then Return False
        Try
            Dim sfwKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software")
            Dim bitKey = sfwKey.OpenSubKey("Bit")
            bitKey.DeleteSubKeyTree("SLTA")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
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
