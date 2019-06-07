Imports System.Windows.Forms
Imports Operario_puerto_y_patio.Data

Public Module ODBCStuff
    <Runtime.CompilerServices.Extension()>
    Public Function CrearParametro(comando As Odbc.OdbcCommand, tipo As Odbc.OdbcType, nombre As String, valor As Object, nullable As Boolean) As Odbc.OdbcParameter
        Dim param = New Odbc.OdbcParameter With {
            .OdbcType = tipo,
            .Value = If(IsNothing(valor), DBNull.Value, valor),
            .IsNullable = nullable
        }
        comando.Parameters.Add(param)
        Return param
    End Function
    <Runtime.CompilerServices.Extension()>
    Public Function ToInformix(bool As Boolean) As String
        Return If(bool, "'t'", "'f'")
    End Function
End Module

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

    Public Sub New()
        Dim c = Connection ' forzar a que se abra la conexión cuando se crea el primer ODBCLogin
    End Sub

    Public Function VehicleAdd(vehicle As Data.Vehiculo) As Boolean Implements ILogin.VehicleAdd
        Dim insCommand = Connection.CreateCommand()
        insCommand.CommandText = "insert into vehiculo(vin, marca, modelo, color, tipo, anio, fueradesistema, clientenombre, usuarioingresa, puertoarriba) values(?, ?, ?, ?, ?, ?, 'f', ?, (select idusuario from usuario where nombredeusuario=?), ?);"
        insCommand.CrearParametro(Odbc.OdbcType.Char, "VIN", vehicle.VIN, False)
        insCommand.CrearParametro(Odbc.OdbcType.VarChar, "Marca", vehicle.marca, False)
        insCommand.CrearParametro(Odbc.OdbcType.VarChar, "Modelo", vehicle.modelo, False)
        insCommand.CrearParametro(Odbc.OdbcType.Int, "color", vehicle.color.ToArgb, False)
        insCommand.CrearParametro(Odbc.OdbcType.VarChar, "tipo", vehicle.tipo, False)
        insCommand.CrearParametro(Odbc.OdbcType.Int, "anio", vehicle.año, False)
        insCommand.CrearParametro(Odbc.OdbcType.VarChar, "cliente", vehicle.comprador, False)
        insCommand.CrearParametro(Odbc.OdbcType.VarChar, "Usuario", vehicle.usuarioIngresa.Nombre, False)
        insCommand.CrearParametro(Odbc.OdbcType.Int, "lugar", vehicle.lugar, False)
        Return insCommand.ExecuteNonQuery = 1
    End Function

    Public Function UserRegister(user As User, pregunta As String, respuesta As String, listaLugares As List(Of Integer)) As Boolean Implements ILogin.UserRegister
        Dim InsertCommand = New Odbc.OdbcCommand($"insert into usuario(nombredeusuario, hash_contra, email, fechanac, telefono, primernombre, segundonombre, primerapellido, segundoapellido, preguntasecreta, respuestasecreta, sexo, rol) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, (select idrol from rol where nombre='{User.StringFromRol(user.Rol)}'));") With {
            .Connection = Connection,
            .CommandType = CommandType.Text
        }
        Dim pwdHash = BCrypt.Net.BCrypt.HashPassword(user.Contra)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "nombredeusuario", user.Nombre, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.Char, "hash_contra", pwdHash, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "email", user.email, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.Date, "fechanac", user.fechanac, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "telefono", user.telefono, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "primernombre", user.primernombre, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "segundonombre", user.segundonombre, True)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "primerapellido", user.primerapellido, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "segundoapellido", user.segundoapellido, True)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "preguntasecreta", pregunta, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "respuestasecreta", respuesta, False)
        InsertCommand.CrearParametro(Odbc.OdbcType.VarChar, "sexo", user.sexo, False)
        If InsertCommand.ExecuteNonQuery <> 1 Then
            Return False
        End If
        Dim trabajaCommand = New Odbc.OdbcCommand($"insert into trabajaen(lugar, usuario, desde) values(?, (select idusuario from usuario where nombredeusuario=?), ?);", ODBCLogin.Connection)
        Dim lParam = trabajaCommand.CrearParametro(Odbc.OdbcType.Int, "lugar", 0, False)
        trabajaCommand.CrearParametro(Odbc.OdbcType.VarChar, "nombre", user.Nombre, False)
        trabajaCommand.CrearParametro(Odbc.OdbcType.Date, "desde", New Date(), False)
        For Each i In listaLugares
            lParam.Value = i
            If trabajaCommand.ExecuteNonQuery() <> 1 Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function UserLogin(uname As String, pwd As String) As User Implements ILogin.UserLogin
        Dim HashGetCommand = New Odbc.OdbcCommand("select hash_contra from usuario where NombreDeUsuario=?;") With {
            .Connection = Connection
        }
        HashGetCommand.CrearParametro(Odbc.OdbcType.VarChar, "nombre", uname, False)
        Dim hash As String = HashGetCommand.ExecuteScalar
        If hash Is Nothing Then
            MsgBox("No existe el usuario en la base de datos")
            Return Nothing
        End If
        Dim crypto = BCrypt.Net.BCrypt.Verify(pwd, hash) 'verificar la contraseña del lado de la aplicación ya que informix no soporta bcrypt
        Dim UserGetCommand = New Odbc.OdbcCommand($"select nombre, email, fechanac, telefono, primernombre, segundonombre, primerapellido, segundoapellido, sexo from usuario, rol where NombreDeUsuario=? and {crypto.ToInformix}='t' and usuario.rol = rol.idrol;") With { 'verificar del lado del servidor
            .Connection = Connection
        }
        UserGetCommand.CrearParametro(Odbc.OdbcType.VarChar, "nombre", uname, False)
        Dim userdata = UserGetCommand.ExecuteReader
        Dim dt As New DataTable
        dt.Load(userdata)
        If dt.Rows.Count > 0 Then
            Dim sn As String = If(IsDBNull(dt.Rows(0)("segundonombre")), Nothing, dt.Rows(0)("segundonombre"))
            Dim sa As String = If(IsDBNull(dt.Rows(0)("segundoapellido")), Nothing, dt.Rows(0)("segundoapellido"))
            Return New User(uname, pwd, User.RolFromString(dt.Rows(0)("nombre")), dt.Rows(0)("email"), dt.Rows(0)("fechanac"), dt.Rows(0)("telefono"), dt.Rows(0)("primernombre"), sn, dt.Rows(0)("primerapellido"), sa, dt.Rows(0)("sexo"))
        Else
            Return Nothing
        End If
    End Function
End Class
