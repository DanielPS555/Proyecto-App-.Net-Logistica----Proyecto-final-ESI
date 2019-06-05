Imports System.Windows.Forms

Public Class ODBCLogin
    Implements ILogin
    Private Shared _connection As Odbc.OdbcConnection = Nothing
    Public Shared Property Connection As Odbc.OdbcConnection
        Get
            If _connection Is Nothing Then
                Dim ofd As New OpenFileDialog With {
                    .Filter = "Archivos ODBC|*.dsn",
                    .Multiselect = False
                }
                If ofd.ShowDialog = DialogResult.OK Then
                    _connection = New Odbc.OdbcConnection()
                    Dim usr = InputBox("Usuario")
                    Dim pwd = InputBox("Contraseña")
                    _connection.ConnectionString = $"FileDsn={ofd.FileName};Uid={usr};Pwd={pwd}"
                    _connection.Open()
                    Return _connection
                Else
                    Return Nothing
                End If
            Else
                Return _connection
            End If
        End Get
        Set(value As Odbc.OdbcConnection)
            _connection = value
        End Set
    End Property

    Public Function UserRegister(user As User) As Boolean Implements ILogin.UserRegister
        Dim InsertCommand = New Odbc.OdbcCommand("insert into usuario(nombredeusuario, hash_contra, salt, ")
    End Function

    Public Function UserLogin(uname As String, pwd As String) As User Implements ILogin.UserLogin
        Dim SaltGetCommand = New Odbc.OdbcCommand("select Salt from usuario where NombreDeUsuario=?;") With {
            .Connection = Connection
        }
        SaltGetCommand.Parameters.Add(uname)
        Dim salt As String = SaltGetCommand.ExecuteScalar
        Dim crypto = BCrypt.Net.BCrypt.HashPassword(pwd, salt) 'hashear la contraseña del lado de la aplicación ya que informix no soporta bcrypt
        Dim UserGetCommand = New Odbc.OdbcCommand("select rol.nombre from usuario, rol where NombreDeUsuario=? and Hash_pwd=? and usuario.rol = rol.nombre;") With { 'verificar del lado del servidor
            .Connection = Connection
        }
        UserGetCommand.Parameters.Add(uname)
        UserGetCommand.Parameters.Add(crypto)
        Dim userdata = UserGetCommand.ExecuteReader
        Dim dt As New DataTable
        dt.Load(userdata)
        If dt.Rows.Count > 0 Then
            Return New User(uname, pwd, dt.Rows(0)(0))
        Else
            Return Nothing
        End If
    End Function
End Class
