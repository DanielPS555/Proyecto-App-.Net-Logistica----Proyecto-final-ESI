Imports System.Data.Odbc
Imports Controladores.Extenciones.Extensiones

Public Class Persistencia


    Private Shared initi As Persistencia

    Private _con As OdbcConnection
    Public ReadOnly Property Conexcion() As OdbcConnection
        Get
            Return _con
        End Get
    End Property

    Private _UsuarioIngresado As Usuario
    Public Property UsuarioActual() As Usuario
        Get
            Return _UsuarioIngresado
        End Get
        Set(ByVal value As Usuario)
            _UsuarioIngresado = value
        End Set
    End Property

    Private _trabajaEnAlcual As TrabajaEn
    Public Property TrabajaEn() As TrabajaEn
        Get
            Return _trabajaEnAlcual
        End Get
        Set(ByVal value As TrabajaEn)
            _trabajaEnAlcual = value
        End Set
    End Property

    Private _conexcionActualHora As DateTime
    Public Property HoraDeLaConexcionActual() As DateTime
        Get
            Return _conexcionActualHora
        End Get
        Set(ByVal value As DateTime)
            _conexcionActualHora = value
        End Set
    End Property

    Private Sub New()
        _UsuarioIngresado = New Usuario
        _trabajaEnAlcual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Public Shared Function getInstancia() As Persistencia
        If initi Is Nothing Then
            initi = New Persistencia
        End If
        Return initi
    End Function

    Public Function RealizarConexcion(ip As String, port As String, servername As String, uid As String, pwd As String, db As String, prueba As Boolean) As Boolean
        Try
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";Uid=" & uid & "; Pwd=" & pwd & ";"
            Dim con As New OdbcConnection(creacion)
            con.Open()
            If prueba Then
                _con = con
            Else
                con.Close()
            End If
            Return True
        Catch ee As Exception
            Return False

        End Try
    End Function

    Public Function ExsistenciaDeUsuario(nombreDeUsuario, password) As Boolean
        Try
            Dim consulta As New OdbcCommand("select count(idusuario) from usuario where hash_contra=? and nombredeusuario=? group by idusuario", Conexcion)
            consulta.CrearParametro(DbType.String, Funciones_comunes.ContraseñaHash(password))
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Dim t As New DataTable
            t.Load(consulta.ExecuteReader)
            If t.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ExsistenciaDeUsuario(nombreDeUsuario) As Boolean
        Try
            Dim consulta As New OdbcCommand("select count(idusuario) from usuario where nombredeusuario=? group by idusuario", Conexcion)
            consulta.CrearParametro(DbType.String, (nombreDeUsuario))
            Dim t As New DataTable
            t.Load(consulta.ExecuteReader)
            If t.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function



    Public Function PreguntaSecretaUsuario(username As String) As String
        Dim cmd As New OdbcCommand("select preguntasecreta from usuario where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteScalar
    End Function

    Public Function RespuestaSecretaUsuario(username As String) As String
        Dim cmd As New OdbcCommand("select RespuestaSecreta from usuario where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteScalar
    End Function

    Public Function ModificarContraseñaPorDatosDeRecuperacion(username As String, newpass As String) As Boolean
        Dim cmd As New OdbcCommand("update usuario set hash_contra=? where nombredeusuario=?;", Conexcion)
        cmd.CrearParametro(DbType.StringFixedLength, Funciones_comunes.ContraseñaHash(newpass))
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Function TrabajaEnPorusuarioDatosBasicos(username As String) As DataTable 'nos da la fecha, usuario y lugar
        Try
            Dim cmd As New OdbcCommand("select lugar.nombre, trabajaen.fechainicio, trabajaen.fechafin, lugar.nombre, lugar.idlugar, lugar.GeoX , lugar.GeoY, trabajaen.id, lugar.tipo
                                    from lugar,trabajaen,usuario
                                    where lugar.idlugar = trabajaen.idlugar and trabajaen.idusuario=usuario.idusuario 
                                    and usuario.nombredeusuario=?", Conexcion)
            cmd.CrearParametro(DbType.String, username)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function NombreLugarDeTrabajoPorID(id As Integer) As String
        Try
            Dim cmd As New OdbcCommand("select lugar.nombre from lugar where idlugar=?", Conexcion)
            cmd.CrearParametro(DbType.Int32, id)
            Return DirectCast(cmd.ExecuteScalar, String)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ConexcionesTrabaen(id As Integer) As DataTable
        Try
            Dim cmd As New OdbcCommand("select conexion.HoraIngreso ,conexion.HoraSalida from 
                                        trabajaen,conexion where conexion.idtrabajaen = trabajaen.id and trabajaen.id=?", Conexcion)
            cmd.CrearParametro(DbType.Int32, id)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NuevaConext(id As Integer, horaInicio As DateTime)
        Dim com As New OdbcCommand("insert into conexion(IDTrabajaEn, HoraIngreso) values(?, ?);", Conexcion)
        com.CrearParametro(DbType.Int64, id)
        com.CrearParametro(DbType.DateTime, Date.Now)
        Try
            Return com.ExecuteNonQuery() > 0
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Sub Cerrarseccion(id As Integer, horaInico As DateTime)
        Dim com As New OdbcCommand("update conexion set HoraSalida=? where idtrabajaen=? and HoraIngreso=? ;", Conexcion)
        com.CrearParametro(DbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd") & " " &
                                   DateTime.Now.ToString("HH:mm:ss"))
        com.CrearParametro(DbType.Int32, id)
        com.CrearParametro(DbType.DateTime, horaInico.ToString("yyyy-MM-dd") & " " &
                                   horaInico.ToString("HH:mm:ss"))

        borrarDatosLocalesPorSeccion()



    End Sub

    Private Sub borrarDatosLocalesPorSeccion()
        _UsuarioIngresado = New Usuario()
        _trabajaEnAlcual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Public Function DatosBaseUsuario(nom As String) As DataTable
        Dim com As New OdbcCommand("select IDUsuario, Email, FechaNac, Telefono, PrimerNombre, SegundoNombre, PrimerApellido, segundoapellido, PreguntaSecreta, RespuestaSecreta, Sexo, Rol.nombre
                                    from Rol, Usuario Where Rol.idrol = usuario.rol and Usuario.nombreDeUsuario =? ;", Conexcion)
        com.CrearParametro(DbType.String, nom)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt


    End Function

    Public Function NumeroLotesCreadorPorusuario_ID(id As Integer) As Integer
        Dim com As New OdbcCommand("select count(*) from lote where creadorID=? ;", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar
    End Function

    Public Function NumeroVehiculosDatosDeAltaPorUsuario_ID(id As Integer) As Integer
        Dim com As New OdbcCommand("select count(*) from vehiculoIngresa where Usuario=? and TipoIngreso='Alta';", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar
    End Function


End Class
