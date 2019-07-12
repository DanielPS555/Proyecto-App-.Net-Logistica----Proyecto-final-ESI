Imports System.Data.Odbc
Imports Controladores.Extenciones.Extensiones

Public Class Persistencia
    Private Sub New()
        _UsuarioIngresado = New Usuario
        _trabajaEnAlcual = Nothing
        _conexcionActualHora = Nothing
    End Sub

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

    Public Function VerificarCredenciales(nombreDeUsuario, password) As Boolean
        Try
            Dim consulta As New OdbcCommand("select hash_contra from usuario where nombredeusuario=?;", Conexcion)
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Dim hash = consulta.ExecuteScalar
            Return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, BCrypt.Net.HashType.SHA256)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ExistenciaDeUsuario(nombreDeUsuario) As Boolean
        Try
            Dim consulta As New OdbcCommand("select count(*) from usuario where nombredeusuario=?;", Conexcion)
            consulta.CrearParametro(DbType.String, (nombreDeUsuario))
            Return consulta.ExecuteScalar() > 0
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
            Return cmd.ExecuteScalar()
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
        com.CrearParametro(DbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        com.CrearParametro(DbType.Int32, id)
        com.CrearParametro(DbType.DateTime, horaInico.ToString("yyyy-MM-dd HH:mm:ss"))
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

    Public Function IDLotePor_Vin_y_IDLugar(vin As String, id As Integer) As Integer
        Try
            Dim com As New OdbcCommand("select lote.idlote from integra, lote where vin=?
                                    and invalidado ='f' and integra.lote=lote.idlote
                                    and fecha in (select max(fecha) from lote, integra where vin=? and
                                    integra.lote =lote.idlote and lote.desde=? )", Conexcion)
            com.CrearParametro(DbType.String, vin)
            com.CrearParametro(DbType.String, vin)
            com.CrearParametro(DbType.Int32, id)
            Return com.ExecuteScalar
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function DatosBasicosParaListarVehiculos(id As Integer) As DataTable
        Dim com As New OdbcCommand("select vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.tipo , (select count(*) from vehiculoIngresa where vehiculoIngresa.VIN=Vehiculo.VIN and tipoingreso='Baja')
                                    from vehiculo, posicionado
                                    where posicionado.idlugar=? and vehiculo.vin = posicionado.vin
                                    group by vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.tipo,posicionado.idlugar", Conexcion)
        com.CrearParametro(DbType.String, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        dt.Columns.Add("Estado", GetType(String))
        For Each dr As DataRow In dt.Rows
            Dim count As Integer = dr.Item(4)
            If count <> 0 Then
                dr.Item(5) = "Fuera del sistema"
            Else
                dr.Item(5) = "Activo"
            End If
        Next
        dt.Columns.RemoveAt(4)
        Return dt
    End Function

    Public Function ComprobarLoteTrasladoRealizado(id As Integer) As Boolean
        Dim com As New OdbcCommand("select count(transporte.estado) from lote,transporte,transporta
                                    where lote.idlote=? and lote.idlote=transporta.idlote
                                    and transporta.transporteID = transporte.transporteID
                                    and transporte.estado='Exitoso' ", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar > 0
    End Function

    Public Function AutoComplete(start As String) As List(Of String)
        Dim cmd = New OdbcCommand("select vin from vehiculo where vin like ?;", Conexcion)
        cmd.CrearParametro(DbType.String, start.Replace("%", "_") + "%")
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Return dt.ToList.Select(Function(x) DirectCast(x(0), String)).ToList
    End Function


    Public Function DevolverInformacionBasicaDeZonasPorID_lugar(id As Integer) As DataTable
        Dim com As New OdbcCommand("select idzona, nombre, capacidad from zona where idlugar=? ", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverInformacionDeSubzonaPorId_zona_y_IdLugar(id_z As Integer, id_l As Integer) As DataTable
        Dim com As New OdbcCommand("select idsub, nombre, capacidad from subzona where idzona=? and idlugar=?", Conexcion)
        com.CrearParametro(DbType.Int32, id_z)
        com.CrearParametro(DbType.Int32, id_l)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverTodosLosLotesPor_IdLugar(id As Integer)
        Dim com As New OdbcCommand("select lote.idlote, lote.nombre, lote.estado from lote inner join lugar on lote.desde = lugar.idlugar where lugar.nombre = ?;", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverDatosBasicosDelVehiculoPrecargadoPor_VIN_vehiculo(vin As String)
        Try
            Dim com As New OdbcCommand("select VIN,Marca,Modelo,color,tipo,anio,cliente.nombre,cliente.rut,cliente.idcliente
                                    from vehiculo, cliente
                                    where vin=? and cliente.idcliente = vehiculo.cliente;", Conexcion)
            com.CrearParametro(DbType.String, vin)
            Dim dt As New DataTable
            dt.Load(com.ExecuteReader)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ExistenciaDeVehiculoPRecargado(vin As String)
        Dim com As New OdbcCommand("select count(vin) from vehiculoIngresa where vin=? and tipoIngreso='Precarga'", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar > 0
    End Function

    Public Function ListaVehiculos(patron As Predicate(Of DataRow)) As DataTable
        Dim scmd As New OdbcCommand("select VIN from posicionado where idlugar=? and hasta is null;", _con)
        scmd.CrearParametro(DbType.AnsiString, Me.TrabajaEn.Lugar.IDLugar)
        Dim _dt As New DataTable
        _dt.Load(scmd.ExecuteReader)
        Dim paramStr = String.Join(",", "?".Multiply(_dt.Rows.Count)) ' 3 autos => ?,?,? => where VIN in (?,?,?)
        Dim cmd As New OdbcCommand($"select Vehiculo.VIN, Marca, Modelo, Tipo,  from vehiculo where Vehiculo.VIN in ({paramStr});", _con)
        For Each v As DataRow In _dt.Rows
            cmd.CrearParametro(DbType.AnsiStringFixedLength, v.Item(0))
        Next
        Dim vehicles As New DataTable
        vehicles.Load(cmd.ExecuteReader)
        Dim dt As New DataTable
        dt.Columns.Add("Estado", GetType(String))
        dt.Columns.Add("VIN", GetType(String))
        dt.Columns.Add("Marca", GetType(String))
        dt.Columns.Add("Modelo", GetType(String))
        dt.Columns.Add("VehiculoTipo", GetType(String))
        For Each i As DataRow In vehicles.Rows
            If Not patron(i) Then
                Continue For
            End If
            Dim dr = dt.NewRow
            dt.Rows.Add(dr)
            dr("Estado") = If(i.Item(4) = 0, "Activo", "Fuera del sistema")
            dr("VIN") = i.Item(0)
            dr("Marca") = i.Item(1)
            dr("Modelo") = i.Item(2)
            dr("VehiculoTipo") = i.Item(3)
        Next
        Return dt
    End Function
End Class


