Imports System.Data.Odbc
Imports Controladores
Imports Controladores.Extenciones.Extensiones
Imports GMap.NET

Public Class Persistencia
    Private Sub New()
        _UsuarioIngresado = New Usuario
        _trabajaEnActual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Private Shared initi As Persistencia

    Friend Function VehiculosConMensaje() As DataTable
        Dim selcmd As New OdbcCommand("select vin, count(datos) from vehiculo left join evento
on vehiculo.idvehiculo=bson_value_int(datos,'idvehiculo')
and nvl(bson_value_boolean(datos, 'leido'), 'f')='f'
and bson_value_varchar(datos, 'tipo')='comentario'
and bson_value_varchar(datos, 'por')='cliente'
group by vin
", _con)
        Dim dt As New DataTable("Vehiculos")
        dt.Load(selcmd.ExecuteReader)
        Return dt
    End Function

    Friend Function MensajesVehiculo(vIN As String) As DataTable
        Dim selcmd As New OdbcCommand("select * from
(select usuario.nombredeusuario, vehiculo.vin,
bson_value_varchar(datos, 'mensaje') as mensaje, nvl(bson_value_boolean(datos, 'leido'), 'f')::boolean as leido from evento
inner join vehiculo on vehiculo.idvehiculo=bson_value_int(datos, 'idvehiculo')
inner join usuario on usuario.idusuario=bson_value_int(datos, 'autor')
where bson_value_varchar(datos, 'tipo')='comentario'
and bson_value_varchar(datos, 'por')='admin'
and vehiculo.vin=?
) as admincomments
union all
(select cliente.nombre, vehiculo.vin,
bson_value_varchar(datos, 'mensaje') as mensaje, nvl(bson_value_boolean(datos, 'leido'), 'f')::boolean as leido from evento
inner join vehiculo on vehiculo.idvehiculo=bson_value_int(datos, 'idvehiculo')
inner join cliente on cliente.idcliente=bson_value_int(datos, 'autor')
where bson_value_varchar(datos, 'tipo')='comentario'
and bson_value_varchar(datos, 'por')='cliente'
and vehiculo.vin=?
)", _con)
        selcmd.CrearParametro(DbType.String, vIN)
        selcmd.CrearParametro(DbType.String, vIN)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Dim updatecmd As New OdbcCommand("update evento set datos=bson_update(datos, '{""$set"":{""leido"":true}}') where bson_value_varchar(datos, 'tipo')='comentario' and bson_value_varchar(datos, 'por')='cliente';", _con)
        updatecmd.ExecuteNonQuery()
        Return dt
    End Function

    Private _con As OdbcConnection
    Public ReadOnly Property Conexcion() As OdbcConnection
        Get
            Return _con
        End Get
    End Property

    Private _UsuarioIngresado As Usuario

    Public Function Consultar(p As String, ParamArray values As Object()) As DataTable
        Dim cmd As New OdbcDataAdapter(p, _con)
        values.ForEach(Sub(x) cmd.SelectCommand.CrearParametro(x))
        Dim ds As New DataSet
        cmd.Fill(ds)
        Return ds.Tables.Item(0)
    End Function

    Public Function InformesDaño(id As Integer) As DataTable
        Dim selcmd As New OdbcCommand(" select informedanios.id,Descripcion,concat(usuario.primernombre, concat(' ', usuario.primerapellido)),
                                        Fecha,lugar.nombre, lugar.idlugar,usuario.idusuario
                                        from Informedanios inner join usuario on informedanios.idusuario=usuario.idusuario
                                        inner join lugar on informedanios.idlugar=lugar.idlugar
                                        where idvehiculo=? order by informedanios.id", _con)
        selcmd.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Return dt
    End Function

    Public Function rolDeUsuario(nombredeUsuario As String) As Char
        Dim com As New OdbcCommand("select rol from usuario where nombredeusuario=?", _con)
        com.CrearParametro(DbType.String, nombredeUsuario)
        Return com.ExecuteScalar
    End Function

    Public Function RegistrosDaño(idvehiculo As Integer, idinforme As Integer) As DataTable
        Dim selcmd As New OdbcCommand("select registrodanios.idregistro,registrodanios.descripcion,
                      nvl(actualiza.tipo, 'No actualiza'), actualiza.informe2, actualiza.registro2
       from informedanios inner join registrodanios on informedanios.ID=registrodanios.informedanios
       left join actualiza on actualiza.registro1=registrodanios.idregistro and actualiza.informe1=informedanios.id
                                    where informedanios.Idvehiculo=? and informedanios.ID=?", _con)
        'Dim selcmd As New OdbcCommand("select registrodanios.informedanios,
        '                                registrodanios.idregistro,
        '                             registrodanios.descripcion,
        '                             count(*) as imagenes from registrodanios
        '                                inner join imagenregistro on
        '                                imagenregistro.informe=registrodanios.informedanios
        '                                inner join vehiculo on
        '                                vehiculo.idvehiculo=registrodanios.idvehiculo and vehiculo.vin=?
        '                                group by registrodanios.informedanios, registrodanios.idregistro,
        '                                registrodanios.descripcion
        '                                having registrodanios.informedanios=?
        '                            ", _con)
        selcmd.CrearParametro(DbType.Int32, idvehiculo)
        selcmd.CrearParametro(DbType.Int32, idinforme)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Return dt
    End Function

    Friend Function MaximoAncestro(idlugar As Integer) As Integer
        Dim selcmd As New OdbcCommand("execute function maximo_ancestro(?)", _con)
        selcmd.CrearParametro(idlugar)
        Return selcmd.ExecuteScalar
    End Function

    Public Function Imagenes(idinforme As Integer, registro As Integer) As DataTable
        Dim selcmd As New OdbcCommand("select nroimagen,imagen from imagenregistro where informe=? and nrolista=?", _con)
        selcmd.CrearParametro(DbType.Int32, idinforme)
        selcmd.CrearParametro(DbType.Int32, registro)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Return dt
    End Function

    Public Function TransportesDeVehiculo(VIN As String) As DataTable
        Dim selcmd As New Odbc.OdbcCommand("select l1.nombre as origen, l2.nombre as destino, lote.nombre as lote, mediotransporte.nombre as medio, transporte.fechahorasalida, l1.geox, l1.geoy, l2.geox, l2.geoy from vehiculo
                                            inner join integra on integra.idvehiculo=vehiculo.idvehiculo and integra.invalidado='f'
                                            inner join lote on integra.lote=lote.idlote
                                            inner join transporta on transporta.idlote=lote.idlote
                                            inner join transporte on transporte.transporteid=transporta.transporteid
                                            inner join mediotransporte on mediotransporte.idtipo=transporte.idtipo and mediotransporte.idlegal=transporte.idlegal
                                            inner join lugar as l1 on l1.idlugar=lote.origen
                                            inner join lugar as l2 on l2.idlugar=lote.destino
                                            where vehiculo.vin=?", _con)
        selcmd.CrearParametro(VIN)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Return dt
    End Function

    Friend Function CerrarLote(idlote As Integer) As Boolean
        Dim selcmd As New OdbcCommand("execute function cerrar_lote(?::integer);", _con)
        selcmd.CrearParametro(idlote)
        Return selcmd.ExecuteScalar
    End Function

    Public Function PosicionesOcupadasEnLugar(idlugar As Integer) As Integer
        Dim selcmd As New OdbcCommand("execute function ocupacion_en_lugar(?::integer);", _con)
        selcmd.CrearParametro(idlugar)
        Return selcmd.ExecuteScalar
    End Function

    Public Function LugaresVehiculo(vin As String) As DataTable
        Dim selcmd As New OdbcCommand("select nombre, tipo, desde, transportista from (select * from (select first 1 vehiculo.vin, lugar.nombre, lugar.tipo, posicionado.desde::datetime year to minute as desde, 'Llegada al país' as transportista from vehiculo
                                        inner join posicionado on posicionado.idvehiculo=vehiculo.idvehiculo
                                        inner join lugar on lugar.idlugar=maximo_ancestro(posicionado.idlugar)
                                        where vin = ?
                                        order by desde)
                                        union all
                                        select vehiculo.vin, lugar.nombre, lugar.tipo, transporta.fechahorallegadareal::datetime year to minute as desde, usuario.nombredeusuario as transportista from vehiculo
                                        inner join integra on vehiculo.idvehiculo=integra.idvehiculo and not integra.invalidado
                                        inner join lote on lote.idlote=integra.lote
                                        inner join transporta on transporta.idlote = lote.idlote and transporta.fechahorallegadareal is not null
                                        inner join transporte on transporte.transporteid=transporta.transporteid
                                        inner join usuario on usuario.idusuario = transporte.usuario
                                        inner join lugar on lote.destino=lugar.idlugar
                                        where vin = ?
                                        ) as cslt
                                        order by desde;", _con)
        selcmd.CrearParametro(vin)
        selcmd.CrearParametro(vin)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Return dt
    End Function

    Public Function CrearZona(lugarID As Integer, nombre As String, capacidad As Integer) As Integer
        Dim inscmd As New OdbcCommand("execute function crear_zona(?::varchar(100), ?::integer, ?::integer);", _con)
        inscmd.CrearParametro(nombre)
        inscmd.CrearParametro(lugarID)
        inscmd.CrearParametro(capacidad)
        Return inscmd.ExecuteScalar
    End Function

    Public Function CrearSubzona(zonaId As Integer, nombre As String, capacidad As Integer) As Integer
        Dim inscmd As New OdbcCommand("execute function crear_subzona(?::varchar(100), ?::integer, ?::integer);", _con)
        inscmd.CrearParametro(nombre)
        inscmd.CrearParametro(zonaId)
        inscmd.CrearParametro(capacidad)
        Return inscmd.ExecuteScalar
    End Function

    Public Function CrearLugar(nombre As String, posicion As PointLatLng, tipo As String, mediosPermitidos() As TipoMedioTransporte, capacidad As Integer, usuario As Integer) As Integer
        Dim inscmd As New OdbcCommand("execute function crear_lugar(?::varchar(100), ?::float, ?::float, ?::varchar(15), ?::integer, ?::integer);", _con)
        inscmd.CrearParametro(nombre)
        inscmd.CrearParametro(posicion.Lat)
        inscmd.CrearParametro(posicion.Lng)
        inscmd.CrearParametro(tipo)
        inscmd.CrearParametro(If(capacidad = 0, DBNull.Value, capacidad))
        inscmd.CrearParametro(usuario)
        Dim lugarid = inscmd.ExecuteScalar
        If lugarid < 0 Then
            Return -1
        End If
        inscmd = New OdbcCommand("insert into habilitado(idlugar, idtipo) values (?::integer, ?::integer);", _con)
        inscmd.CrearParametro(lugarid)
        Dim idtipo = inscmd.CrearParametro(DbType.Int32, -1)
        Try
            For Each m In mediosPermitidos
                idtipo.Value = m.ID
                inscmd.ExecuteNonQuery()
            Next
        Catch e As Exception
            Return -1
        End Try
        Return lugarid
    End Function

    Public Function PadreDeLugar(idlugar As Integer) As DataRow
        Dim selcmd As New OdbcCommand("select nombre, lugar.idlugar from lugar inner join (select mayor as idlugar from incluye start with menor=? connect by mayor=prior menor) as padres on padres.idlugar=lugar.idlugar;", _con)
        selcmd.CrearParametro(idlugar)
        Dim dt As New DataTable
        dt.Load(selcmd.ExecuteReader)
        Return If(dt.Rows.Count > 0, dt.Rows(0), Nothing)
    End Function

    Public Function PosicionesDeVehiculoEnLugar(lugarNombre As String, VIN As String) As DataTable
        Dim selcmd As New OdbcCommand("select subz.unnamed_col_1::integer, subz.unnamed_col_2::varchar(100) as subzona, posicionado.posicion, desde, hasta from table(subzonas_en_lugar_por_nombre(?::varchar(100))) as subz
                                       inner join posicionado
                                       on (subz.unnamed_col_1::integer)=posicionado.idlugar
                                       inner join vehiculo on vehiculo.idvehiculo=posicionado.idvehiculo and vehiculo.vin=?
                                       order by desde", _con)
        selcmd.CrearParametro(lugarNombre)
        selcmd.CrearParametro(VIN)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Return dt
    End Function

    Private Function IDLugar(lugarNombre As String) As Integer
        Dim selcmd As New OdbcCommand("select idlugar from lugar where nombre=?", _con)
        selcmd.CrearParametro(lugarNombre)
        Return selcmd.ExecuteScalar
    End Function

    Public Property UsuarioActual() As Usuario
        Get
            Return _UsuarioIngresado
        End Get
        Set(ByVal value As Usuario)
            _UsuarioIngresado = value
        End Set
    End Property

    Private _trabajaEnActual As TrabajaEn
    Public Property TrabajaEn() As TrabajaEn
        Get
            Return _trabajaEnActual
        End Get
        Set(ByVal value As TrabajaEn)
            _trabajaEnActual = value
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

    Public ExceptionLog As New Queue(Of Exception)

    Public Function RealizarConexcion(ip As String, port As String, servername As String, uid As String, pwd As String, db As String, prueba As Boolean) As Boolean
        Try
            Dim creacion As String = "Driver=IBM INFORMIX ODBC DRIVER (64-bit);Database=" & db & ";Host=" & ip & ";Server=" & servername & ";Service=" &
            port & ";UID=" & uid & ";PWD=" & pwd & ";"
            Dim con As New OdbcConnection(creacion)
            con.Open()
            If prueba Then
                _con = con
            Else
                con.Close()
            End If
            Return True
        Catch ee As Exception
            ExceptionLog.Enqueue(ee)
            Return False
        End Try
    End Function

    Public Function VerificarCredenciales(nombreDeUsuario, password) As Boolean
        Try
            Dim consulta = New OdbcCommand("select hash_contra from usuario where nombredeusuario=?", _con)
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Dim hash = consulta.ExecuteScalar
            Return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, BCrypt.Net.HashType.SHA256)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ExistenciaDeUsuario(nombreDeUsuario) As Boolean
        Try
            Dim consulta As New OdbcCommand("select count(*)=1 from usuario where nombredeusuario=?;", Conexcion)
            consulta.CrearParametro(DbType.String, nombreDeUsuario)
            Return consulta.ExecuteScalar()
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
            Dim cmd As New OdbcDataAdapter("select lugar.nombre, trabajaen.fechainicio, trabajaen.fechafin, lugar.nombre, lugar.idlugar, lugar.GeoX , lugar.GeoY, trabajaen.id, lugar.tipo
                                    from lugar,trabajaen,usuario
                                    where lugar.idlugar = trabajaen.idlugar and trabajaen.idusuario=usuario.idusuario 
                                    and usuario.nombredeusuario=?", Conexcion)
            cmd.SelectCommand.CrearParametro(DbType.String, username)
            Dim TrabajaEn = New DataSet()
            cmd.Fill(TrabajaEn)
            Return TrabajaEn.Tables.Item(0)
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
            Dim cmd As New OdbcDataAdapter("select conexion.HoraIngreso ,conexion.HoraSalida from 
                                        trabajaen,conexion where conexion.idtrabajaen = trabajaen.id and trabajaen.id=?", Conexcion)
            cmd.SelectCommand.CrearParametro(DbType.Int32, id)
            Dim ds As New DataSet
            cmd.Fill(ds)
            Return ds.Tables.Item(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NuevaConext(id As Integer, horaInicio As DateTime) As Boolean
        Dim com As New OdbcCommand("insert into conexion(IDTrabajaEn, HoraIngreso) values(?, ?);", Conexcion)
        com.CrearParametro(DbType.Int64, id)
        com.CrearParametro(DbType.DateTime, Date.Now)
        Try
            Return com.ExecuteNonQuery() > 0
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Sub Cerrarseccion(id As Integer, horaInico As Date)
        Dim com As New OdbcCommand("update conexion set HoraSalida=? where idtrabajaen=? and HoraIngreso=?;", Conexcion)
        com.CrearParametro(DbType.DateTime, Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        com.CrearParametro(DbType.Int32, id)
        com.CrearParametro(DbType.DateTime, horaInico.ToString("yyyy-MM-dd HH:mm:ss"))
        com.ExecuteNonQuery()
        borrarDatosLocalesPorSeccion()
    End Sub

    Private Sub borrarDatosLocalesPorSeccion()
        _UsuarioIngresado = New Usuario()
        _trabajaEnActual = Nothing
        _conexcionActualHora = Nothing
    End Sub

    Public Function DatosBaseVehiculos(ParamArray VIN() As String) As DataTable
        If VIN.Length < 1 Then
            Return Nothing
        End If
        Dim ParamList = "(" + String.Join(", ", "?".Multiply(VIN.Length)) + ")"
        Dim cmd = $"select vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.anio, vehiculo.tipo, vehiculo.color, cliente.IDCliente, cliente.RUT, cliente.Nombre, cliente.fechaRegistro , vehiculo.idvehiculo from vehiculo inner join cliente on vehiculo.Cliente=Cliente.IDCliente where vehiculo.vin in {ParamList};"
        Dim com As New OdbcDataAdapter(cmd, _con)
        For Each i In VIN
            com.SelectCommand.CrearParametro(DbType.AnsiStringFixedLength, i)
        Next
        Dim ds As New DataSet
        com.Fill(ds)
        Return ds.Tables.Item(0)
    End Function

    Public Function VehiculosEnLote(IDLote As Integer) As DataTable
        Dim com As New OdbcCommand("select vin, fecha, idusuario from integra inner join vehiculo on integra.lote=? and integra.invalidado='f' and integra.idvehiculo=vehiculo.idvehiculo;", _con)
        com.CrearParametro(IDLote)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DatosBaseLote(Optional IDLote As Integer? = Nothing, Optional Nombre As String = Nothing) As DataTable
        Dim com As OdbcCommand
        Dim commandStart = "select lote.nombre, l1.nombre, l2.nombre, lote.Origen, lote.Destino, lote.estado, lote.prioridad, lote.idlote, lote.fechacreacion from lote inner join lugar as l1 on l1.idlugar=lote.Destino inner join lugar as l2 on l2.idlugar=lote.Origen"
        Dim prefixes() = {" where lote.idlote=?;", " where lote.nombre=?;"}
        If IDLote IsNot Nothing Then
            com = New OdbcCommand(commandStart + prefixes(0), _con)
            com.CrearParametro(DbType.Int32, IDLote)
        ElseIf Nombre IsNot Nothing Then
            com = New OdbcCommand(commandStart + prefixes(1), _con)
            com.CrearParametro(DbType.String, Nombre)
        Else
            Return Nothing
        End If
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DatosBaseUsuario(nom As String) As DataTable
        Dim com As New OdbcCommand("select IDUsuario, Email, FechaNac, Telefono, PrimerNombre, PrimerNombre, PrimerApellido, PrimerApellido, PreguntaSecreta, RespuestaSecreta, Sexo, rol
                                    from Usuario Where Usuario.nombreDeUsuario=? ;", Conexcion)
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

    Public Function IDLotePor_VINvehiculo_y_NombreLugar(VIN As String, lugar As String) As Integer
        Try
            Dim com As New OdbcCommand("select lote.idlote from vehiculo inner join integra on vehiculo.idvehiculo=integra.idvehiculo and vehiculo.VIN=?
                                     inner join lote on integra.lote=lote.idlote
                                    where invalidado ='f'
                                    and fecha in (select max(fecha) from lote inner join integra on
                                    integra.lote =lote.idlote inner join vehiculo on integra.idvehiculo=vehiculo.idvehiculo and vehiculo.vin=? inner join lugar on lote.Origen=lugar.idlugar and lugar.nombre=?)", Conexcion)
            com.CrearParametro(VIN)
            com.CrearParametro(VIN)
            com.CrearParametro(lugar)
            Return com.ExecuteScalar
        Catch ex As Exception
            Return -1
        End Try

    End Function



    Public Function IDLotePor_IDvehiculo_y_IDLugar(idve As Integer, id As Integer) As Integer
        Try
            Dim com As New OdbcCommand("select lote.idlote from integra, lote where idvehiculo=?
                                    and invalidado ='f' and integra.lote=lote.idlote
                                    and fecha in (select max(fecha) from lote, integra where idvehiculo=? and
                                    integra.lote =lote.idlote and lote.Origen=?)", Conexcion)
            com.CrearParametro(DbType.Int32, idve)
            com.CrearParametro(DbType.Int32, idve)
            com.CrearParametro(DbType.Int32, id)
            Return com.ExecuteScalar
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function IDLotePor_VINvehiculo(vin As String) As Integer
        Try
            Dim com As New OdbcCommand("select first 1 lote.idlote from integra
                                    inner join lote on lote.idlote=integra.lote
                                    inner join vehiculo on vehiculo.idvehiculo=integra.idvehiculo
                                    where vin=?
                                    and invalidado ='f'
                                    order by fecha desc;", Conexcion)
            com.CrearParametro(DbType.StringFixedLength, vin)
            Return com.ExecuteScalar
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function DatosBasicosDelLote_IDvehiculo_y_IDLugar(idve As Integer, id As Integer) As DataTable
        Dim com As New OdbcCommand("select lote.idlote,lote.nombre,lote.creadorid from integra, lote where idvehiculo=?
                                    and invalidado ='f' and integra.lote=lote.idlote
                                    and fecha in (select max(fecha) from lote, integra where idvehiculo=? and
                                    integra.lote =lote.idlote and lote.Origen=?)", Conexcion)
        com.CrearParametro(DbType.Int32, idve)
        com.CrearParametro(DbType.Int32, idve)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt


    End Function

    Public Function DatosBasicosParaListarVehiculosPorLugar(idlugar As Integer) As DataTable

        Dim com As New OdbcCommand($"select distinct vehiculo.idvehiculo, vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.tipo 
                                    from vehiculo, posicionado, vehiculoIngresa
                                    where posicionado.idvehiculo=vehiculo.idvehiculo and vehiculoIngresa.idvehiculo = vehiculo.idvehiculo
                                    and posicionado.idlugar in (select unnamed_col_1 from table(subzonas_en_lugar({idlugar})))",
                                  Conexcion)
        'com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DatosBasicosParaListarVehiculosPorSubzona(idlugar As Integer) As DataTable ' IDVehiculo, VIN, Marca, Modelo, Tipo

        Dim com As New OdbcCommand($"select distinct vehiculo.idvehiculo, vehiculo.vin, vehiculo.marca, vehiculo.modelo, vehiculo.tipo 
                                    from vehiculo, posicionado, vehiculoIngresa
                                    where posicionado.idvehiculo=vehiculo.idvehiculo and vehiculoIngresa.idvehiculo = vehiculo.idvehiculo
                                    and posicionado.idlugar=? and posicionado.hasta is null",
                                  Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function ComprobarLoteTrasladoRealizado(id As Integer) As Boolean
        Dim com As New OdbcCommand("select count(transporta.estado) from lote
                                      inner join transporta on transporta.idlote=lote.idlote
                                    where lote.idlote=? and transporta.estado='Exitoso'", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteScalar > 0
    End Function

    Public Function AutoComplete(start As String) As List(Of String)
        If start.Contains("%") Then Return New List(Of String)
        Dim cmd = New OdbcCommand("select vin from vehiculo where vin like ?;", Conexcion)
        cmd.CrearParametro(DbType.String, start + "%")
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Return dt.ToList.Select(Function(x) DirectCast(x(0), String)).ToList
    End Function


    Public Function DevolverInformacionBasicaDeZonasPorID_lugar(id As Integer) As DataTable
        Dim com As New OdbcCommand($"select unnamed_col_1 as idzona, unnamed_col_2 as nombrezona, unnamed_col_3 as capacidad from table(zonas_en_lugar({id}));", Conexcion)
        'com.SelectCommand.CrearParametro(DbType.Int32, id)
        Dim ds As New DataTable
        ds.Load(com.ExecuteReader)
        Return ds
    End Function

    Public Function DevolverInformacionDeSubzonaPorIdZona(id_z As Integer, id_l As Integer) As DataTable
        Dim com As New OdbcCommand($"select unnamed_col_1 as idzona, unnamed_col_2 as nombrezona, unnamed_col_3 as capacidad from table(subzonas_en_zona({id_l}, {id_z}));", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverTodosLosLotesPor_IdLugar(id As Integer?) As DataTable
        If id Is Nothing Then
            Return Nothing
        End If
        Dim com As New OdbcCommand("select lote.idlote, lote.nombre, lote.estado,
                                  (select count(*) from integra where integra.lote=lote.idlote and integra.invalidado='f' and lote.invalido='f'),
                                  (select count(*) from transporta  where transporta.IDLote=lote.IDLote and transporta.Estado='Exitoso')
                                  from lote inner join lugar on lote.origen = lugar.idlugar where lugar.idlugar = ? and lote.invalido='f';", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        dt.Columns.Item(0).ColumnName = "ID del Lote"
        dt.Columns.Item(1).ColumnName = "Nombre del Lote"
        dt.Columns.Item(2).ColumnName = "Estado del Lote"
        dt.Columns.Item(3).ColumnName = "Autos en Lote"
        dt.Columns.Add("Transportado", GetType(Boolean))
        For Each i As DataRow In dt.Rows
            i.Item(5) = CType(i.Item(4), Integer) > 0
        Next
        dt.Columns.RemoveAt(4)
        Return dt
    End Function

    Public Function DevolverTodosLosLotesPor_IdLugar_COPIA(id As Integer?) As DataTable
        If id Is Nothing Then
            Return Nothing
        End If
        Dim com As New OdbcCommand("select lote.idlote, lote.nombre, lote.estado, lote.invalido from lote inner join lugar on lote.origen = lugar.idlugar where lugar.idlugar = ?;", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function DevolverDatosBasicosDelVehiculoPrecargadoPor_VIN_vehiculo(vin As String) As DataTable
        Try
            Dim com As New OdbcCommand("select VIN,Marca,Modelo,color,tipo,anio,cliente.nombre,cliente.rut,cliente.idcliente,idvehiculo
                                    from vehiculo inner join cliente on cliente.idcliente=vehiculo.cliente
                                    where vin=?;", Conexcion)
            com.CrearParametro(DbType.String, vin)
            Dim dt As New DataTable
            dt.Load(com.ExecuteReader)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ExistenciaDeVehiculoPRecargado(vin As String) As Integer
        Dim com As New OdbcCommand("select count(vehiculo.idvehiculo) from vehiculoIngresa, vehiculo where vehiculo.idvehiculo=vehiculoIngresa.idvehiculo and vin=? and tipoIngreso='Alta'", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar
    End Function

    Public Function PoscionesOcupadasPor_ID_Subzona(id As Integer) As DataTable
        Dim com As New OdbcCommand("select posicion from posicionado where posicionado.idlugar=? and hasta is null", Conexcion)
        com.CrearParametro(DbType.Int32, id)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function clienteDelSistema() As DataTable
        Dim com As New OdbcCommand("select cliente.idcliente,cliente.rut,cliente.nombre from cliente", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function devolverIdDeTodosLosInformesyRegistros(idVehiculo As Integer) As DataTable
        Dim com As New OdbcCommand("select informedanios.ID as idinforme, registrodanios.idregistro,
                      nvl(actualiza.tipo, 'No actualiza'), actualiza.informe2, actualiza.registro2
       from informedanios inner join registrodanios on informedanios.ID=registrodanios.informedanios
       left join actualiza on actualiza.registro1=registrodanios.idregistro and actualiza.informe1=informedanios.id
                                    where informedanios.Idvehiculo=?", Conexcion)
        com.CrearParametro(DbType.Int32, idVehiculo)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function vinPorId(vin As String) As Integer
        Dim com As New OdbcCommand("select IDVehiculo from vehiculo where vin=?", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar
    End Function

    Public Function DevolverTodosLosDestinosPosibles() As DataTable
        Dim com As New OdbcCommand("select lugar.idlugar, nombre, tipo,clienteid
                                    from lugar left join perteneceA on lugar.idlugar = perteneceA.idlugar
                                    where tipo in ('Patio', 'Puerto', 'Establecimiento')", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function InsertLote(nombre As String, idorigen As Integer, destinoId As Integer, prioridad As String, creadorid As Integer, fechacreacion As DateTime, estado As String) As Boolean
        Dim com As New OdbcCommand("insert into lote values (0,?,?,?,?,?,?,?,'f')", Conexcion)
        com.CrearParametro(DbType.String, nombre)
        com.CrearParametro(DbType.Int32, idorigen)
        com.CrearParametro(DbType.Int32, destinoId)
        com.CrearParametro(DbType.Int32, creadorid)
        com.CrearParametro(DbType.DateTime, fechacreacion)
        com.CrearParametro(DbType.String, prioridad)
        com.CrearParametro(DbType.String, estado)
        Return com.ExecuteNonQuery() > 0
    End Function


    Public Function updateVehiculo(idvehiculo As Integer, vin As String, marca As String, modelo As String, color As String, tipo As String, año As Integer, idcliente As Integer)
        Dim com As New OdbcCommand("update vehiculo set
                                    VIN=?,Marca=?,Modelo=?,color=?,tipo=?
                                    ,anio=?,cliente=? where idvehiculo=?", Conexcion)
        com.CrearParametro(DbType.String, vin)
        com.CrearParametro(DbType.String, marca)
        com.CrearParametro(DbType.String, modelo)
        com.CrearParametro(DbType.String, color)
        com.CrearParametro(DbType.String, tipo)
        com.CrearParametro(DbType.Int32, año)
        com.CrearParametro(DbType.Int32, idcliente)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function InsertIntegra(idlote As Integer, idvehiculo As Integer, fechaIntegracion As DateTime, invalido As Boolean, idusuario As Integer) As Boolean
        Dim com As New OdbcCommand("insert into integra values (?,?,?,?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idlote)
        com.CrearParametro(DbType.DateTime, fechaIntegracion)
        com.CrearParametro(DbType.Boolean, invalido)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertVehiculoIngresa(idvehiculo As Integer, fecha As DateTime, tipoIngreso As String, usuario As Integer) As Boolean
        Dim com As New OdbcCommand("insert into vehiculoIngresa values (?,?,?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.DateTime, fecha)
        com.CrearParametro(DbType.String, tipoIngreso)
        com.CrearParametro(DbType.Int32, usuario)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertVehiculo(vin As String, marca As String, modelo As String, color As String, tipo As String, anio As Integer?, idcliente As Integer)
        Dim con As New OdbcCommand("insert into vehiculo values (0,?,?,?,?,?,?,?)", Conexcion)
        con.CrearParametro(DbType.String, vin)
        con.CrearParametro(DbType.String, If(marca, DBNull.Value))
        con.CrearParametro(DbType.String, If(modelo, DBNull.Value))
        con.CrearParametro(DbType.String, If(color, DBNull.Value))
        con.CrearParametro(DbType.String, If(tipo, DBNull.Value))
        con.CrearParametro(DbType.Int32, If(anio, DBNull.Value))
        con.CrearParametro(DbType.Int32, idcliente)
        Return con.ExecuteNonQuery() > 0
    End Function

    Public Function InsertInformedeDaños(descripcion As String, fecha As DateTime, tipo As String, idvehiculo As Integer, idlugar As Integer, idUsuario As Integer)
        Dim com As New OdbcCommand("insert into informedanios(id, descripcion, fecha, tipo, idvehiculo, idlugar, idusuario) 
                                    values(0,?,?,?,?,?,?);", Conexcion)
        com.CrearParametro(DbType.String, descripcion)
        com.CrearParametro(DbType.DateTime, fecha)
        com.CrearParametro(DbType.String, tipo)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idUsuario)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function ultimoIdInforme(idvehiculo As Integer) As Integer
        Dim com As New OdbcCommand("select first 1  informedanios.ID, fecha from informedanios
                                    where IDVehiculo=? order by fecha desc, ID desc
", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Return com.ExecuteScalar
    End Function


    Public Function ultimoIDRegistro(idvehiculo As Integer, idinforme As Integer) As Integer
        Dim com As New OdbcCommand("select first 1 idregistro,informedanios.ID from registrodanios inner join informedanios
                                    on registrodanios.informedanios=informedanios.ID
                                    where  informedanios.IDVehiculo=? and informedanios.ID=? order by fecha desc,idregistro desc", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idinforme)
        Return com.ExecuteScalar
    End Function

    Public Function InsertRegistroDaño(idvehiculo As Integer, idInformedaños As Integer, descripcion As String)
        Dim com As New OdbcCommand("insert into registrodanios(idvehiculo, informedanios, idregistro, descripcion) values(?,?,0,?);", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idInformedaños)
        com.CrearParametro(DbType.String, descripcion)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function eliminarImagenesDeUnInforme(idvehiculo As Integer, idInforme As Integer) As Boolean
        Dim com As New OdbcCommand("delete from imagenregistro where vehiculo=? and informe=? ;", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idInforme)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function ActualizarInformeDaños(id As Integer, descripcion As String, fecha As DateTime, tipo As String, idvehiculo As Integer, idlugar As Integer, idUsuario As Integer)
        Dim com As New OdbcCommand("update informedanios set descripcion=?, fecha=?, tipo=?, idvehiculo=?, idlugar=?, idusuario=? 
                                    where ID=?;", Conexcion)
        com.CrearParametro(DbType.String, descripcion)
        com.CrearParametro(DbType.DateTime, fecha)
        com.CrearParametro(DbType.String, tipo)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idUsuario)
        com.CrearParametro(DbType.Int32, id)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function EliminarRegistrosDeUnInforme(idvehiculo As Integer, idinforme As Integer)
        Dim com As New OdbcCommand("delete from registrodanios where idvehiculo=? and informedanios=? ;", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idinforme)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function EliminarActualizaDeUnRegistro(idvehiculo As Integer, idinforme As Integer)
        Dim com As New OdbcCommand("delete from actualiza where vehiculo1=? and informe1=?;", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idinforme)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertarImagendeUnRegistro(idvehiculo As Integer, idInforme As Integer, idregistro As Integer, img As Byte()) As Boolean
        Dim com As New OdbcCommand("insert into imagenregistro values (?,?,?,0,? );", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idInforme)
        com.CrearParametro(DbType.Int32, idregistro)
        com.CrearParametro(DbType.Binary, img)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertarActualizacion(idvehiculo As Integer, idinforme1 As Integer, idregistro1 As Integer, idinforme2 As Integer, idregistro2 As Integer, tipo As String)
        Dim com As New OdbcCommand("insert into actualiza(vehiculo1, informe1, registro1, vehiculo2, informe2, registro2, tipo) values (?,?,?,?,?,?,?);", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idinforme1)
        com.CrearParametro(DbType.Int32, idregistro1)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, idinforme2)
        com.CrearParametro(DbType.Int32, idregistro2)
        com.CrearParametro(DbType.String, tipo)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function TodasLasPosicionesDeVehiculo(idvehiculo As Integer) As DataTable
        Dim com As New OdbcCommand("select posicion,desde,hasta,idlugar,usuario.idusuario,usuario.nombredeusuario
                                    from posicionado inner join usuario on posicionado.idusuario = usuario.idusuario
                                    where idvehiculo=? order by desde desc", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Dim dt As New DataTable()
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function PosicionActualVehiculo(idvehiculo As Integer) As DataRow
        Dim com As New OdbcCommand("select first 1 posicion,desde,hasta,lugar.idlugar,usuario.idusuario,usuario.nombredeusuario,lugar.nombre
                                     from posicionado inner join usuario
                                     on posicionado.idusuario = usuario.idusuario
                                     inner join lugar on posicionado.idlugar = lugar.idlugar
                                     where idvehiculo=? order by desde desc", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Dim dt As New DataTable()
        dt.Load(com.ExecuteReader)
        If dt.Rows.Count < 1 Then
            Return Nothing
        End If
        Return dt.Rows(0)
    End Function

    Public Function zonaylugarDeUnaSubzona(idsubzona As Integer) As DataTable
        Dim con As New OdbcCommand("select lugar.idlugar, lugar.nombre from lugar inner join 
                                (select mayor as idlugar from incluye start with menor=? connect by menor = prior mayor) as parent 
                                on parent.idlugar = lugar.idlugar", Conexcion)
        con.CrearParametro(DbType.Int32, idsubzona)
        Dim dt As New DataTable
        dt.Load(con.ExecuteReader)
        Return dt

    End Function

    Public Function anularPosicionAnterior(idvehiculo As Integer) As Boolean
        Dim com As New OdbcCommand("update posicionado set hasta=current year to second where idvehiculo=? and hasta is null;", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertPosicion(idusuario As Integer, idsubzona As Integer, idvehiculo As Integer, posicion As Integer) As Boolean
        Dim com As New OdbcCommand("insert into posicionado(idusuario, idlugar, idvehiculo, desde, posicion) values(?,?,?,current year to second, ?);", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        com.CrearParametro(DbType.Int32, idsubzona)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.Int32, posicion)
        Return com.ExecuteNonQuery() > 0
    End Function



    Public Function anularAnteriorIntegra(idvehiculo As Integer)
        Dim consultaPrevia As New OdbcCommand("select first 1 fecha
                                    from integra where idvehiculo=? order by fecha desc", Conexcion)
        consultaPrevia.CrearParametro(DbType.Int32, idvehiculo)

        Dim com As New OdbcCommand("update integra set invalidado=? 
                                    where idvehiculo=? and fecha=?", Conexcion)
        com.CrearParametro(DbType.Boolean, True)
        com.CrearParametro(DbType.Int32, idvehiculo)
        com.CrearParametro(DbType.DateTime, consultaPrevia.ExecuteScalar)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function eliminarlote(idlote As Integer)
        Dim com As New OdbcCommand("update lote set invalido=? where idlote=?", Conexcion)
        com.CrearParametro(DbType.Boolean, True)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function numeroDeVehiculosDeUnLote(idlote As Integer) As Integer
        Dim com As New OdbcCommand("select count(vehiculo.idvehiculo) from
                                    lote inner join integra on idlote = lote
                                     inner join vehiculo on integra.idvehiculo=vehiculo.idvehiculo
                                    where idlote=? and invalidado='f'", Conexcion)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteScalar
    End Function

    Public Function idUltimoLoteDelUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1 idlote from lote where creadorid=? order by fechacreacion desc,idlote desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function LotesDisponiblesATrasportar() As DataTable
        Dim com As New OdbcCommand("select DISTINCT lote.idlote,lote.nombre,Prioridad, l1.idlugar as idlugarOrigen, l1.nombre as nombreorigen, l2.idlugar, l2.nombre, l1.GeoX, L1.GeoY, l2.Geox, l2.GeoY,transporta.estado from
                                    lote left  join (select idlote,max(FechaHoraLlegadaReal) as ccc from transporta group by idlote) as maxi on maxi.idlote=lote.idlote
                                    left  join transporta on maxi.idlote=transporta.idlote and maxi.ccc=transporta.FechaHoraLlegadaReal
                                    inner  join lugar as l1 on origen=l1.idlugar inner join lugar as l2 on destino=l2.idlugar
                                    where (transporta.estado is null or  transporta.estado='Fallo' or transporta.estado='Cancelado') and lote.invalido='f' and lote.estado='Cerrado'", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function HabilitacionPorIdlugar(idlugar As Integer) As DataTable
        Dim com As New OdbcCommand("select TipoTransporte.idtipo , TipoTransporte.nombre
                                    from lugar inner join habilitado on lugar.idlugar = habilitado.idlugar
                                    inner join TipoTransporte on habilitado.idtipo = TipoTransporte.idtipo
                                    where lugar.idlugar=?", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function vehiculosSemiCompletoPorLote(idlote As Integer) As DataTable
        Dim com As New OdbcCommand("select vehiculo.idvehiculo,tipo,vin,modelo,marca from
                                    vehiculo inner join integra on vehiculo.idvehiculo = integra.idvehiculo
                                    inner join lote on integra.lote=lote.idlote
                                    where integra.invalidado='f' and idlote=?", Conexcion)
        com.CrearParametro(DbType.Int32, idlote)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function listaDeMediosPorIdUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select  MedioTransporte.idlegal, MedioTransporte.nombre, TipoTransporte.nombre, fechacreacion
                                    ,CantAutos,CantCamiones,CantSUV,CantVan,CantMinivan, MedioTransporte.IDTipo
                                    from TipoTransporte inner join MedioTransporte on TipoTransporte.idtipo=MedioTransporte.idtipo
                                    inner join permite on MedioTransporte.idtipo=permite.idtipo and MedioTransporte.idlegal= permite.idlegal
                                    where usuario=? and invalido='f'", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function ListarTodosLosTiposDeMedioDeVehiculo() As DataTable
        Dim com As New OdbcCommand("select * from TipoTransporte", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Friend Function ConexionesEntreLugares() As HashSet(Of Tuple(Of Integer, HashSet(Of String)))
        Dim com As New OdbcCommand("select h1.idtipo, l1.nombre, l2.nombre from lugar as l1 inner join habilitado as h1 on l1.idlugar = h1.idlugar inner join habilitado as h2 on h1.idtipo=h2.idtipo and h1.idlugar <> h2.idlugar inner join lugar as l2 on h2.idlugar=l2.idlugar", _con)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Dim hss As New HashSet(Of Tuple(Of Integer, HashSet(Of String)))
        For Each r In dt.Rows.Cast(Of DataRow)
            hss.Add(New Tuple(Of Integer, HashSet(Of String))(r(0), New HashSet(Of String)(r.ItemArray.SubArray(1, r.ItemArray.Length - 1).Cast(Of String))))
        Next
        Return hss
    End Function

    Public Function MediosDisponibles() As DataTable
        Dim com As New OdbcCommand("select MedioTransporte.idlegal as Identificador, MedioTransporte.nombre as Nombre, TipoTransporte.nombre as Tipo, fechacreacion
                                    from TipoTransporte inner join MedioTransporte on TipoTransporte.idtipo=MedioTransporte.idtipo", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function MediosDisponiblesPorUsuario(idusuario As Integer) As DataTable
        Dim com As New OdbcCommand("select MedioTransporte.idlegal as Identificador, MedioTransporte.nombre as Nombre, TipoTransporte.nombre as Tipo, fechacreacion
                                    from TipoTransporte inner join MedioTransporte on TipoTransporte.idtipo=MedioTransporte.idtipo
                                    inner join permite on MedioTransporte.idtipo=permite.idtipo and MedioTransporte.idlegal= permite.idlegal
                                    where usuario=? and invalido='f'", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function InfoMedioDeTrasporte(idlegal As String) As DataRow
        Dim com As New OdbcCommand("select MedioTransporte.nombre,idlegal,TipoTransporte.nombre,MedioTransporte.FechaCreacion, usuario.nombredeusuario
                                    ,CantAutos,CantCamiones,CantSUV,CantVan,CantMinivan
                                    from MedioTransporte inner join TipoTransporte on MedioTransporte.idtipo=TipoTransporte.idtipo
                                    inner join usuario on MedioTransporte.Creador=usuario.idusuario where idlegal=?", Conexcion)
        com.CrearParametro(DbType.String, idlegal)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt.Rows(0)
    End Function

    Public Function UltimoEstadoDelTrasporteDeUnMedio(idlegal As String) As String
        Dim com As New OdbcCommand("select first 1 count(estado), FechaHoraCreacion
                                    from transporte left join transporta on transporta.transporteID=transporte.transporteID
                                     where idlegal=?  and estado='Proceso'
                                    group by FechaHoraCreacion
                                    order by FechaHoraCreacion desc", Conexcion)
        com.CrearParametro(DbType.String, idlegal)
        Return com.ExecuteScalar
    End Function

    Public Function EstadosDeUnTrasporte(trasporteid As Integer) As DataTable
        Dim com As New OdbcCommand("select count(*),transporta.estado
                                    from transporta inner join transporte on transporta.transporteID = transporte.transporteID
                                    where transporte.transporteID=?
                                    group by transporta.estado
                                    order by transporta.estado desc", Conexcion)
        com.CrearParametro(DbType.Int32, trasporteid)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function UsuariosHabilitadosAUsarUnMedioDeTrasporte(idlegal As String) As DataTable
        Dim com As New OdbcCommand("select idusuario, usuario.nombredeusuario
                                    from permite inner join usuario on usuario.idusuario = permite.usuario
                                    where permite.invalido='f' and permite.idlegal=?", Conexcion)
        com.CrearParametro(DbType.String, idlegal)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function TrasportesRealizadosPorIdUsuario(idusuario As Integer) As DataTable
        Dim com As New OdbcCommand("select transporte.transporteID, IDLegal,FechaHoraCreacion,FechaHoraLlegadaReal, lote.origen, count(transporte.transporteID) as Numero_Lotes
                                    from transporte inner join transporta on transporte.transporteID = transporta.transporteID
                                    inner join lote on transporta.idlote = lote.idlote
                                    where usuario=?
                                    group by transporte.transporteID, IDLegal,FechaHoraCreacion,FechaHoraLlegadaReal, lote.origen", Conexcion)
        com.CrearParametro(DbType.String, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function InformacionBasicaDelTrasporte(idtrasporte As Integer) As DataRow
        Dim com As New OdbcCommand("select transporte.transporteid,Usuario.nombredeusuario, transporte.idlegal, TipoTransporte.nombre,
                                    FechaHoraCreacion,FechaHoraSalida from
                                    transporte inner join usuario on transporte.usuario= usuario.idusuario
                                    inner join TipoTransporte on TipoTransporte.idtipo=transporte.idtipo
                                    where transporteid=?", Conexcion)
        com.CrearParametro(DbType.String, idtrasporte)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt.Rows(0)
    End Function

    Public Function LotesEnUnTransporte(idtrasporte As Integer) As DataTable
        Dim com As New OdbcCommand("select lote.nombre, l1.nombre, l2.nombre, lote.Prioridad, transporta.estado,transporta.FechaHoraLlegadaEstm ,transporta.FechaHoraLlegadaReal from
                                    lote inner join lugar as l1 on lote.origen=l1.idlugar
                                    inner join lugar as l2 on lote.destino=l2.idlugar
                                    inner join transporta on lote.idlote = transporta.idlote
                                    inner join transporte on transporta.transporteID=transporte.transporteID
                                    where transporte.transporteID=?", Conexcion)
        com.CrearParametro(DbType.String, idtrasporte)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function Inserttransporte(idusuario As Integer, idtipotransporte As Integer, idlegal As String, fechaCreacion As DateTime)
        Dim com As New OdbcCommand("insert into transporte(transporteID, Usuario, IDTipo, IDLegal, FechaHoraCreacion) values (0,?,?,?,?);", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        com.CrearParametro(DbType.Int32, idtipotransporte)
        com.CrearParametro(DbType.String, idlegal)
        com.CrearParametro(DbType.DateTime, fechaCreacion)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function devolverUltimoidTransportaPorIdUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1 transporteid
                                    from transporte
                                    where usuario=?
                                    order by FechaHoraCreacion desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function UpdateHoraSalidaDelTransporte(idtransporte As Integer, horaSalida As DateTime)
        Dim com As New OdbcCommand("update transporte set FechaHoraSalida=? where transporteid=?", Conexcion)
        com.CrearParametro(DbType.DateTime, horaSalida)
        com.CrearParametro(DbType.Int32, idtransporte)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function InsertTransportaParaUnLote(idtransporte As Integer, idlote As Integer, estado As String)
        Dim com As New OdbcCommand("insert into transporta(transporteID,IDLote,Estado) values (?,?,?);", Conexcion)
        com.CrearParametro(DbType.Int32, idtransporte)
        com.CrearParametro(DbType.Int32, idlote)
        com.CrearParametro(DbType.String, estado)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function updatefechallegadarealAlTransportaDeUnLote(idtransporte As Integer, idlote As Integer, llegada As DateTime)
        Dim com As New OdbcCommand("update transporta set FechaHoraLlegadaReal=? where transporteID=? and idlote=?", Conexcion)
        com.CrearParametro(DbType.DateTime, llegada)
        com.CrearParametro(DbType.Int32, idtransporte)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function updatefechallegadaEstimadaAlTransportaDeUnLote(idtransporte As Integer, idlote As Integer, llegada As DateTime)
        Dim com As New OdbcCommand("update transporta set FechaHoraLlegadaEstm=? where transporteID=? and idlote=?", Conexcion)
        com.CrearParametro(DbType.DateTime, llegada)
        com.CrearParametro(DbType.Int32, idtransporte)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function updateEstadoDeUnTransporta(idtransporte As Integer, idlote As Integer, estado As String)
        Dim com As New OdbcCommand("update transporta set Estado=? where transporteID=? and idlote=?", Conexcion)
        com.CrearParametro(DbType.String, estado)
        com.CrearParametro(DbType.Int32, idtransporte)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function updatePrioridadlote(idlote As Integer, prio As String)
        Dim com As New OdbcCommand("update lote set Prioridad=? where idlote=?", Conexcion)
        com.CrearParametro(DbType.String, prio)
        com.CrearParametro(DbType.Int32, idlote)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function lotesCuyoDestinoEs(idlugar As Integer)
        Dim com As New OdbcCommand("select vehiculo.idvehiculo, vin, marca, modelo, Lote.IDLote, Lote.Nombre, FechaHoraLlegadaReal
                                    From vehiculo inner Join integra On vehiculo.idvehiculo=integra.idvehiculo
                                    inner Join transporta on integra.lote = transporta.idlote
                                    inner Join lote on lote.idlote = integra.lote
                                    where integra.invalidado ='f' and transporta.estado='Exitoso' and lote.destino=?", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function precargasActuales()
        Dim com As New OdbcCommand("select vehiculo.IDVehiculo, vin, modelo, tipo, Fecha as Fecha_creacion_precarga   from
                                    vehiculoIngresa inner join vehiculo on vehiculoingresa.idvehiculo=vehiculo.idvehiculo
                                     where not vehiculoingresa.idvehiculo in
                                    (select idvehiculo from vehiculoingresa where TipoIngreso='Alta' )", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function UltimoPosicionadoPorIdlugaryIdvehiculo(idlugar As Integer, idvehiculo As Integer)
        Dim com As New OdbcCommand($"select first 1 desde from posicionado
                                    where idlugar in (select unnamed_col_1 from table(subzonas_en_lugar({idlugar})))
                                    and idvehiculo=? order by desde desc", Conexcion)
        com.CrearParametro(DbType.Int32, idvehiculo)
        Return com.ExecuteScalar
    End Function

    Public Function existenciaDel(vin As String)
        Dim com As New OdbcCommand("select count(*) from vehiculo where vin=?", Conexcion)
        com.CrearParametro(DbType.String, vin)
        Return com.ExecuteScalar > 0
    End Function

    Public Function ListaLugares()
        Dim com As New OdbcCommand("select lugar.idlugar,lugar.nombre,tipo,cliente.nombre
                                    from lugar left join perteneceA on lugar.idlugar=perteneceA.idlugar
                                    left  join cliente on perteneceA.clienteid=cliente.idcliente
                                    where  not tipo in ('Zona', 'Subzona')", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function ListaPuertos()
        Dim com As New OdbcCommand("select lugar.idlugar,lugar.nombre,tipo,cliente.nombre
                                    from lugar left join perteneceA on lugar.idlugar=perteneceA.idlugar
                                               left join cliente on perteneceA.clienteid=cliente.idcliente
                                    where tipo ='Puerto'", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function infoLugar(nombre As String) As DataRow
        Dim com As New OdbcCommand("select lugar.idlugar, lugar.nombre, capacidad, geox, geoy,lugar.tipo, usuario.nombredeusuario, cliente.nombre,lugar.fechaRegistro
                                    from lugar inner join usuario on lugar.UsuarioCreador = usuario.idusuario
                                    left join perteneceA on lugar.idlugar=perteneceA.idlugar
                                    left  join cliente on perteneceA.clienteid=cliente.idcliente
                                    where lugar.nombre=?", Conexcion)
        com.CrearParametro(DbType.String, nombre)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt(0)
    End Function

    Public Function infoLugar(idlugar As Integer) As DataRow
        Dim com As New OdbcCommand("select lugar.idlugar, lugar.nombre, capacidad, geox, geoy,lugar.tipo, usuario.nombredeusuario, cliente.nombre,lugar.fechaRegistro
                                    from lugar inner join usuario on lugar.UsuarioCreador = usuario.idusuario
                                    left join perteneceA on lugar.idlugar=perteneceA.idlugar
                                    left  join cliente on perteneceA.clienteid=cliente.idcliente
                                    where lugar.idlugar=?", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt(0)
    End Function

    Public Function infoCliente(idcliente As Integer) As DataRow
        Dim com As New OdbcCommand("select IDCliente,RUT,nombre,usuario.nombredeusuario,fechaRegistro
                                    from cliente inner join usuario on cliente.UsuarioRegistro = usuario.idusuario
                                    where idcliente=?", Conexcion)
        com.CrearParametro(DbType.Int32, idcliente)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt(0)
    End Function

    Public Function TodosLostrabajaEnPorIdLugares(idlugar As Integer) As DataTable
        Dim com As New OdbcCommand("select usuario.nombredeusuario, FechaInicio, count(HoraIngreso) as numeroDeIngresos from
                                    trabajaen inner join lugar on trabajaen.idlugar =lugar.idlugar
                                    inner join usuario on trabajaen.idusuario = usuario.idusuario
                                    left join conexion on trabajaen.id = conexion.IDTrabajaEn
                                    where lugar.idlugar=?
                                    group by usuario.nombredeusuario, FechaInicio", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function


    Public Function TodosLosVehiculosEntregadosEnIdLugar(idlugar As Integer) As DataTable
        Dim com As New OdbcCommand("select vehiculo.vin, lote.nombre, transporta.FechaHoraLlegadaReal as fecha_de_llegada
                                    from lugar inner join lote on lugar.idlugar = lote.Destino
                                    inner join transporta on transporta.idlote = lote.idlote
                                    inner join integra on integra.lote=lote.idlote
                                    inner join vehiculo on integra.idvehiculo = vehiculo.idvehiculo
                                    where lugar.idlugar=? and lote.invalido = 'f' and
                                    integra.invalidado='f' and transporta.Estado='Exitoso'", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function insertLugar(nombre As String, capasidad As String, x As Integer, y As Integer, usercreador As String, tipo As String)
        Dim com As New OdbcCommand("insert into lugar values (0,?,?,?,?,?,?)", Conexcion)
        com.CrearParametro(DbType.String, nombre)
        com.CrearParametro(DbType.Int32, capasidad)
        com.CrearParametro(DbType.Double, x)
        com.CrearParametro(DbType.Int32, y)
        com.CrearParametro(DbType.Int32, usercreador)
        com.CrearParametro(DbType.String, tipo)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertIncluye(idlugarHijo As Integer, idlugarPapa As Integer)
        Dim com As New OdbcCommand("insert into incluye values (?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idlugarHijo)
        com.CrearParametro(DbType.Int32, idlugarPapa)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertHabilitado(idlugar As Integer, idtipoMedio As Integer)
        Dim com As New OdbcCommand("insert into Habilitado values (?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idtipoMedio)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertPerteneceA(idlugar As Integer, idcliente As Integer)
        Dim com As New OdbcCommand("insert into perteneceA values (?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idcliente)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function insertCliente(rut As String, nombre As String, fecha As DateTime, invalido As Boolean, user As Integer)
        Dim com As New OdbcCommand("insert into cliente values (?,?,0,?,?,?)", Conexcion)
        com.CrearParametro(DbType.String, rut)
        com.CrearParametro(DbType.String, nombre)
        com.CrearParametro(DbType.DateTime, fecha)
        com.CrearParametro(DbType.Boolean, invalido)
        com.CrearParametro(DbType.Int32, user)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function listaClienteActuales()
        Dim com As New OdbcCommand("select idcliente, rut, nombre from cliente where invalido='f'", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function listaDeLugaresPorIdcliente(idcliente As Integer)
        Dim com As New OdbcCommand("select lugar.idlugar,lugar.nombre from
                                    cliente inner join perteneceA on cliente.idcliente = perteneceA.clienteid
                                    inner join lugar on perteneceA.idlugar=lugar.idlugar
                                    where idcliente=?", Conexcion)
        com.CrearParametro(DbType.Int32, idcliente)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function ultimoVehiculoIngresadoPorIdUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1 idvehiculo, Fecha from vehiculoIngresa
                                    where usuario=? and TipoIngreso='Precarga'
                                    order by fecha desc, idvehiculo desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function ultimoClienteIngresadoPorIdUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1  idcliente, fechaRegistro from cliente
                                    where UsuarioRegistro=?
                                    order by fechaRegistro desc, idcliente desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function ultimoLugarIngresadoPorIdusuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1 idlugar, fechaRegistro from lugar
                                    where UsuarioCreador=?
                                    order by fechaRegistro desc, idlugar desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function ListarTodosLosUsuariosDelSistema() As DataTable
        Dim com As New OdbcCommand("select idusuario, nombredeusuario, PrimerNombre as nombre,PrimerApellido as apelido, Rol from usuario", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function infobasicaUsuario(idusuario As Integer) As DataRow
        Dim com As New OdbcCommand("select nombredeusuario, idusuario, rol, PrimerNombre,PrimerApellido,FechaNac, email, telefono,sexo,
                                    Creador,FechaCreacion, link from usuario left join link on usuario.idusuario = link.transportista
                                    where idusuario=?", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt(0)
    End Function

    Public Function trabajaenPorIdusuario(idusuario As Integer) As DataTable
        Dim com As New OdbcCommand("select trabajaen.id, lugar.nombre, FechaInicio,FechaFin, count(HoraIngreso) as numeroDeConexciones from
                                    trabajaen inner join lugar on lugar.idlugar=trabajaen.idlugar
                                    left join conexion on conexion.IDTrabajaEn=trabajaen.id
                                    where trabajaen.idusuario=?
                                    group by trabajaen.id,lugar.nombre, FechaInicio,FechaFin
                                    order by trabajaen.id desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function vehiculosDatosDeAltaPorIsUsuario(idusuario As Integer) As DataTable
        Dim com As New OdbcCommand("select vehiculo.IDVehiculo,vin, Fecha from vehiculoingresa inner join vehiculo on vehiculo.idvehiculo=vehiculoingresa.idvehiculo
                                    where usuario=? and TipoIngreso='Alta'", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function InformesDeDañosPorIdusuario(idusuario As Integer) As DataTable
        Dim com As New OdbcCommand("select vin, informedanios.id, Fecha, lugar.nombre , count(idregistro) as NumeroDeRegistros from
                                    usuario inner join informedanios on usuario.idusuario=informedanios.idusuario
                                    inner join lugar on lugar.idlugar = informedanios.idlugar
                                    inner join vehiculo on vehiculo.idvehiculo = informedanios.idvehiculo
                                    left join registrodanios on informedanios.id=registrodanios.informedanios
                                    where usuario.idusuario=?
                                    group by informedanios.id, Fecha, lugar.nombre,vin", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function existenciaDeTrabajaEnActualPorIdusuarioyIdLugar(idusuario As Integer, idlugar As Integer)
        Dim com As New OdbcCommand("select count(trabajaen.id) from usuario inner join trabajaen on usuario.idusuario=trabajaen.idusuario
                                    where idlugar=? and trabajaen.idusuario=? and FechaFin is null", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idusuario)

        Return com.ExecuteScalar
    End Function

    Public Function insertTrabajaEn(idlugar As Integer, idusuario As Integer, horaIngreso As DateTime)
        Dim com As New OdbcCommand("insert into trabajaen (id,idlugar,idusuario,FechaInicio) values (0,?,?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idlugar)
        com.CrearParametro(DbType.Int32, idusuario)
        com.CrearParametro(DbType.DateTime, horaIngreso)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function NombreDeUsuarioPorIdUsuario(idusuario As Integer) As String
        Dim com As New OdbcCommand("select nombredeusuario from usuario where idusuario=?", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function TodosLosPatiosYPuertos() As DataTable
        Dim com As New OdbcCommand("select idlugar, nombre, tipo from lugar
                                    where not tipo in ('Establecimiento', 'Zona', 'Subzona')", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function updateTrabajaEnConFechaFinalizacion(idtrabajaen As Integer, fin As DateTime)
        Dim com As New OdbcCommand("update trabajaen set FechaFin=? where ID=?", Conexcion)
        com.CrearParametro(DbType.DateTime, fin)
        com.CrearParametro(DbType.Int32, idtrabajaen)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function todosLosMediosDelSistemaInfoBasica()
        Dim com As New OdbcCommand("select IDLegal,MedioTransporte.Nombre, TipoTransporte.idtipo, TipoTransporte.nombre 
                                    from MedioTransporte inner join TipoTransporte on  MedioTransporte.idTipo=TipoTransporte.idtipo", Conexcion)
        Dim dt As New DataTable
        dt.Load(com.ExecuteReader)
        Return dt
    End Function

    Public Function existenciaDelPermite(idusuario As Integer, idlegal As String, j As Boolean) As Boolean
        Dim com As New OdbcCommand("select count(*) from permite where usuario=? and idlegal=? and invalido=?", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        com.CrearParametro(DbType.String, idlegal)
        com.CrearParametro(DbType.Boolean, j)
        Return com.ExecuteScalar > 0
    End Function

    Public Function actualizarInvalidoDeUnPermite(idusuario As Integer, idlegal As String, j As Boolean)
        Dim com As New OdbcCommand("update permite set invalido=? where IDLegal=? and usuario=?", Conexcion)
        com.CrearParametro(DbType.Boolean, j)
        com.CrearParametro(DbType.String, idlegal)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function InsertPermite(idusuario As Integer, idtipo As Integer, idlegal As String, invalido As Boolean)
        Dim com As New OdbcCommand("insert into permite values (?,?,?,?)", Conexcion)
        com.CrearParametro(DbType.Int32, idtipo)
        com.CrearParametro(DbType.String, idlegal)
        com.CrearParametro(DbType.Int32, idusuario)
        com.CrearParametro(DbType.Boolean, invalido)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function ExistenciaDeNombreDeUsuario(nombre As String)
        Dim com As New OdbcCommand("select count(*) from usuario where UPPER(nombredeusuario)=?", Conexcion)
        com.CrearParametro(DbType.String, nombre.ToUpper)
        Return com.ExecuteScalar > 0
    End Function

    Public Function insertUsuario(nombreDeUsuario As String, contra As String, email As String, fechanac As DateTime, telefono As String, nombre As String, apelido As String, sexo As Char, rol As Char, creador As Integer, fechaCreacion As DateTime)
        Dim com As New OdbcCommand("insert into usuario(IDUsuario,NombreDeUsuario,Hash_Contra,Email,FechaNac,Telefono,PrimerNombre,PrimerApellido,Sexo,Rol,Creador,FechaCreacion)
                                    values (0,?,?,?,?,?,?,?,?,?,?,?)", Conexcion)
        com.CrearParametro(DbType.String, nombreDeUsuario)
        com.CrearParametro(DbType.String, contra)
        com.CrearParametro(DbType.String, email)
        com.CrearParametro(DbType.DateTime, fechanac)
        com.CrearParametro(DbType.String, telefono)
        com.CrearParametro(DbType.String, nombre)
        com.CrearParametro(DbType.String, apelido)
        com.CrearParametro(DbType.String, sexo)
        com.CrearParametro(DbType.String, rol)
        com.CrearParametro(DbType.Int32, creador)
        com.CrearParametro(DbType.DateTime, fechaCreacion)
        Return com.ExecuteNonQuery() > 0
    End Function

    Public Function UltimoIdUsuarioAgregadoPorIdUsuario(idusuario As Integer)
        Dim com As New OdbcCommand("select first 1  idusuario,fechaCreacion from usuario where creador=? order by fechacreacion desc,idusuario desc", Conexcion)
        com.CrearParametro(DbType.Int32, idusuario)
        Return com.ExecuteScalar
    End Function

    Public Function NumeroDeLugaresNoZonaOSubzonaConEseNombre(nombre As String)
        Dim com As New OdbcCommand("select count(nombre) from lugar where nombre=? and tipo in ('Patio','Puerto','Establecimiento')", Conexcion)
        com.CrearParametro(DbType.String, nombre)
        Return com.ExecuteScalar
    End Function

    Public Function UltimoClienteAgregadoPorIDUsuario(usuario As Integer)
        Dim com As New OdbcCommand("select first 1 idcliente from cliente where UsuarioRegistro=? order by fechaRegistro desc, idcliente desc", Conexcion)
        com.CrearParametro(DbType.Int32, usuario)
        Return com.ExecuteScalar
    End Function

    Public Function NumeroDeClienesConUnNombre(nombre As String) 'Ignoramos mayusculas
        Dim com As New OdbcCommand("select count(*) from cliente where UPPER(nombre)=UPPER(?)", Conexcion)
        com.CrearParametro(DbType.String, nombre)
        Return com.ExecuteScalar
    End Function



End Class