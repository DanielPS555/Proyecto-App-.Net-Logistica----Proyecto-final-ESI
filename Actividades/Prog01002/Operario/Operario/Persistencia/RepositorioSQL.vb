Imports System.Data.Odbc
Imports Operario
Imports Operario.Logica

Public Module SQLUtils
    Delegate Function DTBifunctor(Of T1)(ByVal a As DataRow, ByVal B As DataRow) As T1

    <Runtime.CompilerServices.Extension>
    Public Function CrearParametro([this] As OdbcCommand, type As DbType, value As Object) As OdbcParameter
        Dim par = this.CreateParameter
        par.DbType = type
        par.Value = value
        this.Parameters.Add(par)
        Return par
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function ToList(dt As DataTable) As List(Of DataRow)
        Dim newlist As New List(Of DataRow)
        For Each i In dt.Rows
            newlist.Add(i)
        Next
        Return newlist
    End Function
End Module

Public Class SQLRepo
    Inherits VehiculoRepo
    Implements ISQLRepositorio
    Implements IUsuarioRepositorio
    Implements ILugarRepositorio

    Public Overrides Function Sincronizar() As Boolean Implements IUsuarioRepositorio.Sincronizar

        Return True
    End Function

    Private _conn As OdbcConnection

    Public Sub New(Connection As OdbcConnection)
        _conn = Connection
        Sincronizar()
    End Sub

    Public Overrides ReadOnly Property Vehiculos As List(Of Vehiculo)
        Get
            Dim cmd = New OdbcCommand("select VIN from vehiculo;", _conn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            Return dt.ToList.Select(Function(x) VehiculoIncompleto(x("VIN")))
        End Get
    End Property

    Private usuarioConectado As Usuario = Nothing

    Public Function UsuarioIncompletoPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorID
        Dim cmd = New OdbcCommand("select * from usuario where idusuario=?;", _conn)
        Dim idparam = cmd.CrearParametro(DbType.Int64, id)
        Dim rdr = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(rdr)
        If dt.Rows.Count <> 1 Then
            Return Nothing
        End If
        Return New Usuario(dt.Rows()(0), Nothing)
    End Function

    Public Function UsuarioIncompletoPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorNombre
        Dim cmd = New OdbcCommand("select * from usuario where nombredeusuario=?;", _conn)
        Dim nomparam = cmd.CrearParametro(DbType.String, nombre)
        Dim rdr = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(rdr)
        If dt.Rows.Count <> 1 Then
            Return Nothing
        End If
        Return New Usuario(dt.Rows()(0), Nothing)
    End Function

    Public Function UsuarioPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioPorID
        Dim usr = UsuarioIncompletoPorID(id)
        If usr IsNot Nothing Then
            CompletarUsuario(usr)
        End If
        Return usr
    End Function


    Public Sub CompletarUsuario(usr As Usuario) Implements IUsuarioRepositorio.CompletarUsuario
        Dim cmd = New OdbcCommand("select * from trabajaen where idusuario=?;", _conn)
        Dim uid = cmd.CrearParametro(DbType.Int64, usr.ID)
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Dim _cmd = New OdbcCommand("select idtrabajaen, conexion.horaingreso, conexion.horasalida from conexion inner join trabajaen on trabajaen.id=conexion.idtrabajaen where idusuario=? order by conexion.horaingreso;", _conn)
        _cmd.CrearParametro(DbType.Int64, usr.ID)
        usr.TrabajaEn.Clear()
        For Each i As DataRow In dt.Rows
            Dim tmp = New TrabajaEn(i, usr)
            usr.TrabajaEn.Add(tmp)
        Next
        Dim cdt As New DataTable
        cdt.Load(_cmd.ExecuteReader)
        If cdt.Rows.Count = 0 Then
            Return
        End If
        cdt.ToList.ForEach(Sub(con)
                               Dim te = usr.TrabajaEn.Find(Function(x) x.ID = con(0))
                               Dim entrada As DateTime = con(1)
                               Dim salida = AutoNull(Of DateTime?)(con(2))
                               te.Conexiones.Add(New Conexion(entrada, salida))
                           End Sub)
    End Sub

    Public Function UsuarioPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioPorNombre
        Dim usr = UsuarioIncompletoPorNombre(nombre)
        If usr IsNot Nothing Then
            CompletarUsuario(usr)
        End If
        Return usr
    End Function

    Public Function Login(username As String, password As String) As Usuario Implements IUsuarioRepositorio.Login
        Dim u = UsuarioPorNombre(username)
        If u?.VerificarContraseña(password) Then usuarioConectado = u
        Return usuarioConectado
    End Function

    Public Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean Implements IUsuarioRepositorio.Restablecer
        Dim usuario As Usuario = UsuarioPorNombre(username)
        Dim r = usuario?.RestablecerContraseña(respuesta, newpass)
        If r Then
            Dim cmd As New OdbcCommand("update usuario set hash_contra=? where nombredeusuario=?;", _conn)
            cmd.CrearParametro(DbType.StringFixedLength, usuario._password_hash)
            cmd.CrearParametro(DbType.String, username)
            Return cmd.ExecuteNonQuery > 0
        End If
        Return False
    End Function

    Public Function LugaresTrabaja() As List(Of String) Implements IUsuarioRepositorio.LugaresTrabaja
        Return usuarioConectado?.TrabajaEn.Select(Function(x) x.Lugar.Nombre).ToList
    End Function

    Public Function UltimaConexionEn(lugar As String) As Date? Implements IUsuarioRepositorio.UltimaConexionEn
        If usuarioConectado Is Nothing Then Return Nothing
        If Not LugaresTrabaja.Contains(lugar) Then Return Nothing
        Dim uC = usuarioConectado.TrabajaEn.Where(Function(x) x.Lugar.Nombre = lugar).Single.Conexiones.Select(Of Date)(Function(x) x.FechaInicio).ToList
        If uC.Count = 0 Then Return Nothing
        uC.Sort()
        Return uC.Last
    End Function

    Public Function ConectarEn(lugar As String) As Boolean Implements IUsuarioRepositorio.ConectarEn
        If usuarioConectado Is Nothing Then Return Nothing
        ReloadUsuario(usuarioConectado)
        If usuarioConectado.ConectadoEn IsNot Nothing Then
            Return False
        End If
        If Not LugaresTrabaja.Contains(lugar) Then
            Return False
        End If
        Dim val = usuarioConectado.TrabajaEn.Where(Function(x) x.Lugar.Nombre = lugar).Select(Function(x) usuarioConectado.Conectar(x.Lugar)).Single
        If val Then
            Dim te = usuarioConectado.TrabajaEn.Where(Function(x) x.Lugar.Nombre = lugar).Single
            Dim com As New OdbcCommand("insert into conexion(IDTrabajaEn, HoraIngreso) values(?, ?);", _conn)
            com.CrearParametro(DbType.Int64, te.ID)
            com.CrearParametro(DbType.DateTime, Date.Now)
            Try
                Return com.ExecuteNonQuery() > 0
            Catch e As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Function Desconectar() As Boolean Implements IUsuarioRepositorio.Desconectar
        If usuarioConectado Is Nothing Then Return Nothing
        Dim val = usuarioConectado.Desconectar
        CompletarUsuario(usuarioConectado)
        If val Then
            Dim conexiones = usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas.Where(Function(x) x.FechaFin Is Nothing).ToList
            Dim te = usuarioConectado.TrabajaEn.Where(Function(x) x.Conexiones.Contains(conexiones.Last)).Single
            Dim com As New OdbcCommand("update conexion set HoraSalida=? where IDTrabajaEn=? and HoraIngreso=?;", _conn)
            com.CrearParametro(DbType.DateTime, DateTime.Now)
            com.CrearParametro(DbType.Int64, te.ID)
            com.CrearParametro(DbType.DateTime, conexiones.Last.FechaInicio)
            If com.ExecuteNonQuery < 1 Then
                Return False
            End If
            usuarioConectado = Nothing
            Return True
        Else
            Return False
        End If
    End Function

    Public Function NombreCompleto() As String Implements IUsuarioRepositorio.NombreCompleto
        Return usuarioConectado?.NombreCompleto
    End Function

    Public Function NombreDeUsuario() As String Implements IUsuarioRepositorio.NombreDeUsuario
        Return usuarioConectado?.UserName
    End Function

    Public Function RolDeUsuario() As String Implements IUsuarioRepositorio.RolDeUsuario
        Return usuarioConectado?.Rol.Nombre
    End Function

    Public Function AccesosAlSistema() As Integer Implements IUsuarioRepositorio.AccesosAlSistema
        Return usuarioConectado?.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas.Count
    End Function

    Public Function UltimoAcceso() As Date? Implements IUsuarioRepositorio.UltimoAcceso
        If usuarioConectado Is Nothing Then Return Nothing
        Dim tmp = usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas
        Dim tmp2 = tmp.Select(Function(x) x.FechaInicio).ToList
        tmp2.Sort()
        Return tmp2.Last
    End Function


    Public Function AllLugares(Optional patron As String = "%") As List(Of Lugar) Implements ILugarRepositorio.AllLugares
        Dim cmd As New OdbcCommand("select idlugar from lugar where nombre like ?;", _conn)
        Dim par = cmd.CrearParametro(DbType.String, patron)
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Return dt.ToList.Select(Function(x) LugarPorID(x("idlugar"))).ToList
    End Function

    Public Function LugarPorNombre(nombre As String) As Lugar Implements ILugarRepositorio.LugarPorNombre
        Return AllLugares(nombre).Single
    End Function

    Public Overrides Function VehiculoIncompleto(VIN As String, patron As Predicate(Of DataRow)) As Vehiculo
        Dim cmd As New OdbcCommand("select * from vehiculo where VIN=?;", _conn)
        Dim par = cmd.CrearParametro(DbType.StringFixedLength, VIN)
        Dim dt As New DataTable()
        dt.Load(cmd.ExecuteReader)
        If dt.Rows.Count = 0 OrElse Not patron(dt.Rows()(0)) Then
            Return Nothing
        End If
        Return New Vehiculo(dt.Rows()(0))
    End Function
    Public Overrides Function VehiculoIncompleto(VIN As String) As Vehiculo
        Return VehiculoIncompleto(VIN, Function(x) True)
    End Function

    Public Overrides Sub IngresosVehiculo(V As Vehiculo)
        Dim cmd As New OdbcCommand("select * from vehiculoIngresa where VIN=?;", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, V.VIN)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        For Each i In dt.ToList
            V.Ingresos.Add(New Ingreso(V, UsuarioIncompletoPorID(i("Usuario")), Ingreso.TipoFromString(i("TipoIngreso")), i("Fecha")))
        Next
    End Sub


    Public Overrides Function InformesVehiculo(VIN As String) As Vehiculo
        Dim v = VehiculoIncompleto(VIN)
        If v Is Nothing Then
            Return Nothing
        End If
        Dim cmd = New OdbcCommand("select * from informedanios where VIN=?;", _conn)
        Dim par = cmd.CrearParametro(DbType.StringFixedLength, VIN)
        Dim rdr = cmd.ExecuteReader
        Dim dt = New DataTable
        dt.Load(rdr)
        Dim rcmd = New OdbcCommand("select * from registrodanios;", _conn)
        rdr = rcmd.ExecuteReader
        Dim rdt = New DataTable
        rdt.Load(rdr)
        For Each i As DataRow In dt.Rows
            Dim x = New InformeDaños(i("ID"), i("idusuario"), i("Fecha"), i("Tipo"), i("idlugar"), i("Descripcion"))
            x.Registros.AddRange(rdt.ToList.Where(Function(z) z("informedanios") = x.id).Select(Function(y) New RegistroDaños(y, x)))
            v.Informes.Add(x)
        Next
        Return v
    End Function

    Public Overrides Function ExisteVIN(vin As String) As Boolean
        Dim cmd = New OdbcCommand("select count(*) from vehiculo where vin=?;", _conn)
        Dim p = cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteScalar > 0
    End Function

    Public Overrides Function VehiculosEn(Lugar As String) As List(Of Vehiculo)
        Return Vehiculos.Select(Function(x) InformesVehiculo(x.VIN)).Where(Function(x) x.LugarActual.Nombre = Lugar).ToList
    End Function

    Public Shared DateOrder As Comparison(Of DataRow) = Function(x, y)
                                                            Return CType(x("FechaHoraSalida"), DateTime).CompareTo(y("FechaHoraSalida"))
                                                        End Function

    Private Shared ReadOnly ConnectionComparison As Comparison(Of Conexion) = Function(x, y) x.FechaInicio.CompareTo(y.FechaFin)

    Public Overrides Function AutoComplete(start As String) As List(Of String)
        Dim cmd = New OdbcCommand("select vin from vehiculo where vin like ?;", _conn)
        cmd.CrearParametro(DbType.String, start.Replace("%", "_") + "%")
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Return dt.ToList.Select(Function(x) DirectCast(x(0), String)).ToList
    End Function

    Public Function LugarPorID(id As Integer) As Lugar Implements ILugarRepositorio.LugarPorID
        Dim cmd = New OdbcCommand("select * from lugar where idlugar=?;", _conn)
        Dim par = cmd.CrearParametro(DbType.Int64, id)
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim lugar As New Lugar(dt.Rows()(0))
        cmd = New OdbcCommand("select * from lote where ?=desde;", _conn)
        Dim transportes As New OdbcCommand("select count(*) from transporta where idlote=?;", _conn)
        Dim idlote = transportes.CrearParametro(DbType.Int64, -1)
        par = cmd.CrearParametro(DbType.Int64, id)
        rdr = cmd.ExecuteReader
        Dim loteDt As New DataTable
        loteDt.Load(rdr)
        For Each l As DataRow In loteDt.Rows
            Dim autos = New OdbcCommand("select * from integra where Lote=?;", _conn)
            idlote.Value = l("IDLote")
            Dim Lote As Lote = New Lote(l, lugar.ID, transportes.ExecuteScalar > 0)
            Dim param = autos.CrearParametro(DbType.Int64, l("IDLote"))
            Dim aRdr = autos.ExecuteReader
            Dim auDt = New DataTable
            auDt.Load(aRdr)
            For Each a As DataRow In auDt.Rows
                Dim v = InformesVehiculo(a("VIN"))
                Lote.Integrantes.Add(v)
            Next
            lugar.LotesCreados.Add(Lote)
        Next
        Dim zonasCmd = New OdbcCommand("select * from zona where idlugar=?;", _conn)
        zonasCmd.CrearParametro(DbType.Int64, id)
        Dim zdt = New DataTable
        zdt.Load(zonasCmd.ExecuteReader)
        Dim szonasCmd = New OdbcCommand("select * from subzona where idlugar=? and idzona=?;", _conn)
        szonasCmd.CrearParametro(DbType.Int64, id)
        Dim zpm = szonasCmd.CrearParametro(DbType.Int64, -1)
        Dim posCmd = New OdbcCommand("select * from posicionado where (idlugar=?) and (idzona=?) and (idsub=?);", _conn)
        posCmd.CrearParametro(DbType.Int64, id)
        Dim pzp = posCmd.CrearParametro(DbType.Int64, -1)
        Dim psp = posCmd.CrearParametro(DbType.Int64, -1)
        For Each z As DataRow In zdt.Rows
            Dim zObj = New Zona(z, lugar)
            lugar.Zonas.Add(zObj)
            zpm.Value = z("IDZona")
            Dim szdt = New DataTable
            szdt.Load(szonasCmd.ExecuteReader)
            pzp.Value = z("IDZona")
            For Each sz As DataRow In szdt.Rows
                Dim msz As Subzona = New Subzona(zObj, New List(Of Posicionado), sz("Nombre"), sz("IDSub"), sz("Capacidad"))
                zObj.Subzonas.Add(msz)
                psp.Value = sz("IDSub")
                Dim pdt As New DataTable
                pdt.Load(posCmd.ExecuteReader)
                For Each p As DataRow In pdt.Rows
                    Dim ps = New Posicionado(p, msz)
                    msz._posicionados.Add(ps)
                Next
            Next
        Next
        Return lugar
    End Function

    Public Function ListaVehiculos(dt As DataTable, patron As Predicate(Of DataRow)) As DataTable Implements IUsuarioRepositorio.ListaVehiculos
        If usuarioConectado Is Nothing Then
            Throw New InvalidOperationException("No está conectado")
        End If
        ReloadUsuario(usuarioConectado)
        Dim x = usuarioConectado.ConectadoEn
        Dim _szonasPos As IEnumerable(Of Posicionado) = x.Subzonas.Select(Function(z) z._posicionados).UnionListas
        Dim szonasPos = _szonasPos.GroupBy(Of String)(Function(z) z.Vehiculo.VIN)
        For Each i In szonasPos
            Dim vehiculo = VehiculoIncompleto(i.Key, patron)
            If vehiculo IsNot Nothing Then
                Dim dr = dt.NewRow
                dt.Rows.Add(dr)
                dr("Estado") = If(i.Where(Function(z) z.Hasta Is Nothing And z.Vehiculo.VIN = i.Key).Count > 0, [Enum].GetName(GetType(EstadoVehiculo), vehiculo.Estado), "Fuera del lugar")
                dr("VIN") = vehiculo.VIN
                dr("Marca") = vehiculo.Marca
                dr("Modelo") = vehiculo.Modelo
                dr("VehiculoTipo") = [Enum].GetName(GetType(TipoVehiculo), vehiculo.Tipo)
            End If
        Next
        Return dt
    End Function

    Private Sub ReloadUsuario(usuarioConectado As Usuario)
        CompletarUsuario(usuarioConectado)
    End Sub

    Public Function AltaVehiculo(VIN As String, marca As String, modelo As String, año As Integer, zona As String, subzona As String, posicion As Integer, color As Color, lote As String) As Boolean Implements IUsuarioRepositorio.AltaVehiculo
        If usuarioConectado Is Nothing Then
            Return False
        End If
        Dim checkCommand = New OdbcCommand("select count(*) from vehiculoIngresa where VIN=?;", _conn)
        checkCommand.CrearParametro(DbType.String, VIN)
        If checkCommand.ExecuteScalar <> 1 Then
            Return False
        End If
        If LRepo.PosicionOcupada(subzona, zona, usuarioConectado.ConectadoEn.Nombre, posicion) Then
            Return False
        End If
        Dim insertCommand = New OdbcCommand("insert into vehiculoIngresa(VIN, Fecha, TipoIngreso, Usuario) values(?, ?, 'Alta', ?);", _conn)
        insertCommand.CrearParametro(DbType.String, VIN)
        insertCommand.CrearParametro(DbType.Date, Date.Now)
        insertCommand.CrearParametro(DbType.Int64, usuarioConectado.ID)
        If insertCommand.ExecuteNonQuery <> 1 Then
            Return False
        End If
        Dim updateCommand = New OdbcCommand("update vehiculo set Marca=?, Modelo=?, Anio=?, Color=?, PuertoArriba=? where VIN=?;", _conn)
        updateCommand.CrearParametro(DbType.String, marca)
        updateCommand.CrearParametro(DbType.String, modelo)
        updateCommand.CrearParametro(DbType.Int64, año)
        updateCommand.CrearParametro(DbType.StringFixedLength, color.ToArgb.ToString("X6"))
        updateCommand.CrearParametro(DbType.Int64, usuarioConectado.ConectadoEn.ID)
        updateCommand.CrearParametro(DbType.StringFixedLength, VIN)
        If updateCommand.ExecuteNonQuery <= 0 Then Throw New Exception("No hubieron cambios en el vehículo, por favor informe a su administrador")
        Return Me.Posicion(VIN, zona, subzona, ConectadoEn, posicion)
    End Function

    Public Function ConectadoEn() As String Implements IUsuarioRepositorio.ConectadoEn
        Dim scom = New OdbcCommand("select lugar.nombre from lugar, trabajaen, conexion where lugar.idlugar=trabajaen.idlugar and conexion.idtrabajaen=trabajaen.id and conexion.horasalida is null;", _conn)
        scom.CrearParametro(DbType.Int64, usuarioConectado.ID)
        Return scom.ExecuteScalar
    End Function

    Public Overrides Function Lote(vin As String, nuevolote As String) As Boolean
        Dim ccom = New OdbcCommand("update integra set invalidado='t' where VIN=? and invalidado='f';", _conn)
        ccom.CrearParametro(DbType.StringFixedLength, vin)
        ccom.ExecuteNonQuery()
        Dim ncom = New OdbcCommand("insert into integra(vin, invalidado, fecha, lote, idusuario) values(?, 'f', ?, ?, ?);", _conn)
        ncom.CrearParametro(DbType.StringFixedLength, vin)
        ncom.CrearParametro(DbType.DateTime, Date.Now)
        ncom.CrearParametro(DbType.Int64, LoteID(nuevolote))
        ncom.CrearParametro(DbType.Int64, usuarioConectado.ID)
        Return ncom.ExecuteNonQuery > 0
    End Function

    Public Function LoteID(nombre As String) As Integer
        Dim scom = New OdbcCommand("select idlote from lote where nombre=?;", _conn)
        scom.CrearParametro(DbType.String, nombre)
        Return scom.ExecuteScalar
    End Function

    Public Overrides Function Posicion(vin As String, zona As String, subzona As String, lugar As String, nuevaposicion As Integer) As Boolean
        Dim _lugar = LugarPorNombre(lugar)
        Dim _zona = _lugar.Zonas.Find(Function(x) x.Nombre = zona)
        Dim _subzona = _zona.Subzonas.Find(Function(x) x.Nombre = subzona)
        Dim ocupadoCommand = New OdbcCommand("select count(*) from posicionado where idlugar=? and idzona = ? and idsub = ? and posicion = ? and hasta is null;", _conn)
        ocupadoCommand.CrearParametro(DbType.Int64, _lugar.ID)
        ocupadoCommand.CrearParametro(DbType.Int64, _zona.ID)
        ocupadoCommand.CrearParametro(DbType.Int64, _subzona.ID)
        ocupadoCommand.CrearParametro(DbType.Int64, nuevaposicion)
        If ocupadoCommand.ExecuteScalar > 0 Then
            Return False
        End If
        Dim checkPKCommand = New OdbcCommand("select count(*) from posicionado where vin=? and idlugar=? and idzona=? and idsub=? and desde=?;", _conn)
        checkPKCommand.CrearParametro(DbType.StringFixedLength, vin)
        checkPKCommand.CrearParametro(DbType.Int64, _lugar.ID)
        checkPKCommand.CrearParametro(DbType.Int64, _zona.ID)
        checkPKCommand.CrearParametro(DbType.Int64, _subzona.ID)
        checkPKCommand.CrearParametro(DbType.DateTime, Date.Now)
        If checkPKCommand.ExecuteScalar > 0 Then
            Return False
        End If
        Dim posicionadoCommand = New OdbcCommand("select count(*) from posicionado where vin=? and hasta is null;", _conn)
        posicionadoCommand.CrearParametro(DbType.StringFixedLength, vin)
        If posicionadoCommand.ExecuteScalar > 0 Then
            Dim updateCommand = New OdbcCommand("update posicionado set hasta=? where vin=? and hasta is null;", _conn)
            updateCommand.CrearParametro(DbType.DateTime, Date.Now)
            updateCommand.CrearParametro(DbType.StringFixedLength, vin)
            If updateCommand.ExecuteNonQuery = 0 Then
                Return False
            End If
        End If
        Dim posicionarCommand = New OdbcCommand("insert into posicionado(vin, idlugar, idzona, idsub, desde, posicion, idusuario) values(?,?,?,?,?,?,?);", _conn)
        posicionarCommand.CrearParametro(DbType.StringFixedLength, vin)
        posicionarCommand.CrearParametro(DbType.Int64, _lugar.ID)
        posicionarCommand.CrearParametro(DbType.Int64, _zona.ID)
        posicionarCommand.CrearParametro(DbType.Int64, _subzona.ID)
        posicionarCommand.CrearParametro(DbType.DateTime, Date.Now)
        posicionarCommand.CrearParametro(DbType.Int64, nuevaposicion)
        posicionarCommand.CrearParametro(DbType.Int64, usuarioConectado.ID)
        Try
            Return posicionarCommand.ExecuteNonQuery > 0
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Overrides Function Marca(vin As String) As String
        Return VehiculoIncompleto(vin).Marca
    End Function

    Public Overrides Function Modelo(vin As String) As String
        Return VehiculoIncompleto(vin).Modelo
    End Function

    Public Overrides Function Año(vin As String) As String
        Return VehiculoIncompleto(vin).Año
    End Function

    Public Overrides Function Cliente(vin As String) As String
        Return VehiculoIncompleto(vin)?.ClienteNombre
    End Function

    Public Overrides Function Tipo(vin As String) As String
        If ExisteVIN(vin) Then
            Return [Enum].GetName(GetType(TipoVehiculo), VehiculoIncompleto(vin).Tipo)
        End If
        Return Nothing
    End Function

    Public Overrides Function Color(vin As String) As Color
        Return VehiculoIncompleto(vin)?.Color
    End Function

    Public Overrides Function Lugar(vin As String) As String
        Return VehiculoIncompleto(vin)?.LugarActual?.Nombre
    End Function

    Public Overrides Function Zona(vin As String) As String
        Return VehiculoIncompleto(vin)?.PosicionActual?.Subzona.Padre.Nombre
    End Function

    Public Overrides Function Subzona(vin As String) As String
        Return VehiculoIncompleto(vin)?.PosicionActual?.Subzona.Nombre
    End Function

    Public Overrides Function Posicion(vin As String) As Integer?
        Return VehiculoIncompleto(vin)?.PosicionActual?.Posicion
    End Function

    Public Overrides Function Lote(vin As String) As String
        Dim selcmd = New OdbcCommand("select lote.nombre from lote inner join integra on lote.idlote = integra.lote where integra.VIN=?;", _conn)
        selcmd.CrearParametro(DbType.StringFixedLength, vin)
        Return selcmd.ExecuteScalar
    End Function

    Public Function TipoLugar(lugar As String) As String Implements ILugarRepositorio.TipoLugar
        Dim selcmd = New OdbcCommand("select tipo from lugar where nombre = ?;", _conn)
        selcmd.CrearParametro(DbType.String, lugar)
        Return selcmd.ExecuteScalar
    End Function

    Public Overrides Function Inspecciones(vin As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Lugar", GetType(String))
        dt.Columns.Add("Autor", GetType(String))
        dt.Columns.Add("Fecha", GetType(Date))
        dt.Columns.Add("Numero de Registros", GetType(String))
        For Each i In InformesVehiculo(vin).Informes
            Dim dr = dt.NewRow()
            dt.Rows.Add(dr)
            dr("ID") = i.id
            dr("Lugar") = i.Lugar.Nombre
            dr("Autor") = i.Creador.UserName
            dr("Fecha") = i.Fecha.ToShortDateString
            dr("Numero de Registros") = Registros(vin, i.id).Item6.ToString
        Next
        Return dt
    End Function

    Public Overrides Function Registros(vin As String, inspeccion As Integer) As Tuple(Of DataTable, String, Integer, Date, String, Integer)
        Dim dt = MyBase.RegistroTable()(0)
        Dim informes = InformesVehiculo(vin).Informes
        Dim informe = informes.Where(Function(x) x.id = inspeccion).Single
        For Each i In informe.Registros
            Dim dr = dt.NewRow
            dt.Rows.Add(dr)
            dr("ID") = i.NumeroEnLista
            dr("Descripcion") = i.Descripcion
        Next
        Return New Tuple(Of DataTable, String, Integer, Date, String, Integer)(dt, informe.Tipo, informe.id, informe.Fecha, informe.Descripcion, dt.Rows.Count)
    End Function

    Public Overrides Function PosicionesEn(vin As String, conectadoEn As String) As DataTable
        Dim cmd As New OdbcCommand("select (select nombre from zona where zona.idzona=posicionado.idzona) as zona, (select nombre from subzona where subzona.idsub=posicionado.idsub) as subzona, desde, hasta, posicion, (select nombredeusuario from usuario where idusuario=posicionado.idusuario) as usuario from posicionado where VIN=? and IDLugar=(select IDLugar from lugar where nombre=?);", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        cmd.CrearParametro(DbType.String, conectadoEn)
        Dim dt As New DataTable("Posicionamientos")
        dt.Load(cmd.ExecuteReader)
        Return dt
    End Function

    Public Function CapacidadZonas(lugar As String) As DataTable Implements ILugarRepositorio.CapacidadZonas
        Dim dt As New DataTable("Zonas")
        dt.Columns.Add("Zona", GetType(String))
        dt.Columns.Add("Ocupación", GetType(Integer))
        dt.Columns.Add("Capacidad", GetType(Integer))
        LugarPorNombre(lugar).Zonas.ForEach(Sub(x)
                                                Dim dr = dt.NewRow
                                                dt.Rows.Add(dr)
                                                dr("Zona") = x.Nombre
                                                dr("Ocupación") = x.Ocupacion
                                                dr("Capacidad") = x.Capacidad
                                            End Sub)
        Return dt
    End Function

    Public Overrides Function TipoInforme(informe As Integer) As String
        Dim cmd As New OdbcCommand("select tipo from informedanios where id=?;", _conn)
        cmd.CrearParametro(DbType.Int64, informe)
        Return cmd.ExecuteScalar
    End Function

    Public Overrides Function DescripcionInforme(informe As Integer) As String
        Dim cmd As New OdbcCommand("select descripcion from informedanios where id=?;", _conn)
        cmd.CrearParametro(DbType.Int64, informe)
        Return cmd.ExecuteScalar
    End Function

    Public Overrides Function VINInforme(informe As Integer) As String
        Dim cmd As New OdbcCommand("select VIN from informedanios where id=?;", _conn)
        cmd.CrearParametro(DbType.Int64, informe)
        Return cmd.ExecuteScalar
    End Function

    Public Overrides Function Marca(vin As String, nuevaMarca As String) As Boolean
        Dim cmd As New OdbcCommand("update vehiculo set marca=? where VIN=?;", _conn)
        cmd.CrearParametro(DbType.String, nuevaMarca)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Overrides Function Modelo(vin As String, nuevoModelo As String) As Boolean
        Dim cmd As New OdbcCommand("update vehiculo set modelo=? where VIN=?;", _conn)
        cmd.CrearParametro(DbType.String, nuevoModelo)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Overrides Function Año(vin As String, nuevoAño As String) As Boolean
        Dim cmd As New OdbcCommand("update vehiculo set anio=? where VIN=?;", _conn)
        cmd.CrearParametro(DbType.Int64, Integer.Parse(nuevoAño))
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Overrides Function Cliente(vin As String, nuevoCliente As String) As String
        Dim cmd As New OdbcCommand("update vehiculo set ClienteNombre=? where VIN=?;", _conn)
        cmd.CrearParametro(DbType.String, nuevoCliente)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Overrides Function Tipo(vin As String, nuevoTipo As String) As String
        Dim cmd As New OdbcCommand("update vehiculo set Tipo=? where VIN=?;", _conn)
        cmd.CrearParametro(DbType.String, nuevoTipo)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Public Function PosicionOcupada(subzona As String, zona As String, lugar As String, posicion As Integer) As Boolean Implements ILugarRepositorio.PosicionOcupada
        Dim _lugar = LugarPorNombre(lugar)
        Dim _zona = _lugar.Zonas.Find(Function(x) x.Nombre = zona)
        Dim _subzona = _zona.Subzonas.Find(Function(x) x.Nombre = subzona)
        Dim cmd As New OdbcCommand("select count(*) from posicionado where idlugar=? and idzona=? and idsub=? and posicion=? and hasta is null;", _conn)
        cmd.CrearParametro(DbType.Int64, _lugar.ID)
        cmd.CrearParametro(DbType.Int64, _zona.ID)
        cmd.CrearParametro(DbType.Int64, _subzona.ID)
        cmd.CrearParametro(DbType.Int64, posicion)
        Return cmd.ExecuteScalar > 0
    End Function


    Friend Overrides Function PosicionadoDesde(vin As String) As DateTime
        Dim cmd As New OdbcCommand("select desde from posicionado where vin=? and hasta is null;", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteScalar
    End Function

    Public Function LotesEnLugar(lugar As String) As List(Of String) Implements ILugarRepositorio.LotesEnLugar
        Dim cmd As New OdbcCommand("select lote.nombre from lote inner join lugar on lote.desde = lugar.idlugar where lugar.nombre = ?;", _conn)
        cmd.CrearParametro(DbType.String, lugar)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Return dt.ToList.Select(Function(x) CType(x(0), String)).ToList
    End Function

    Public Function CreadorDe(vin As String) As Boolean Implements IUsuarioRepositorio.CreadorDe
        Dim cmd As New OdbcCommand("select idusuario from posicionado where vin=?;", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return cmd.ExecuteScalar = usuarioConectado.ID
    End Function

    Friend Overrides Function PuertoLlegada(vin As String) As String
        Dim cmd As New OdbcCommand("select puertoarriba from vehiculo where vin=?;", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, vin)
        Return AutoNull(Of String)(cmd.ExecuteScalar)
    End Function

    Friend Overrides Function FechaLlegada(vin As String) As String
        Dim cmd As New OdbcCommand("select fechaarribo from vehiculo where vin=?;", _conn)
        cmd.CrearParametro(DbType.StringFixedLength, vin)

        Dim X = AutoNull(Of Date?)(cmd.ExecuteScalar)
        Return X?.ToShortDateString
    End Function

    Friend Overrides Function NewReg(enInforme As Integer) As Integer
        Dim cmd As New OdbcCommand("insert into registrodanios(informedanios, descripcion) values(?, '');", _conn)
        Dim scmd As New OdbcCommand("select max(nroenlista) from registrodanios where informedanios=?;", _conn)
        cmd.CrearParametro(DbType.Int64, enInforme)
        scmd.CrearParametro(DbType.Int64, enInforme)
        cmd.ExecuteNonQuery()
        Return scmd.ExecuteScalar
    End Function

    Friend Overrides Function NewInforme(descripcion As String, tipo As String, vin As String) As Integer
        Dim cmd As New OdbcCommand("insert into informedanios(id, descripcion, fecha, tipo, vin, idlugar, idusuario) values(0, ?, ?, ?, ?, ?, ?);", _conn)
        cmd.CrearParametro(DbType.String, descripcion)
        cmd.CrearParametro(DbType.DateTime, Date.Now)
        cmd.CrearParametro(DbType.String, tipo)
        cmd.CrearParametro(DbType.String, vin)
        cmd.CrearParametro(DbType.Int64, Me.usuarioConectado.ConectadoEn.ID)
        cmd.CrearParametro(DbType.Int64, Me.usuarioConectado.ID)
        Dim scmd As New OdbcCommand("select max(id) from informedanios;", _conn)
        cmd.ExecuteNonQuery()
        Return scmd.ExecuteScalar
    End Function

    Public Overrides Function Imagenes(inspeccion As Integer, registro As Integer) As DataTable
        Dim cmd As New OdbcCommand("select imagenregistro.nroimagen, imagenregistro.imagen from imagenregistro inner join registrodanios on registrodanios.nroenlista=imagenregistro.nrolista and registrodanios.informedanios=imagenregistro.informe where registrodanios.informedanios = ? and registrodanios.nroenlista=?;", _conn)
        cmd.CrearParametro(DbType.Int64, inspeccion)
        cmd.CrearParametro(DbType.Int64, registro)
        Dim rdr = cmd.ExecuteReader()
        Dim x = MyBase.RegistroTable()(1)
        While (rdr.Read)
            Dim dr = x.NewRow
            dr("ID") = rdr.Item(0)
            dr("Imagen") = rdr.Item(1)
            x.Rows.Add(dr)
        End While
        Return x
    End Function

    Public Function OcupacionSubzona(subzona As String, zona As String, lugar As String) As Integer Implements ILugarRepositorio.OcupacionSubzona
        Dim con As New OdbcCommand("select count(*) from posicionado where idsub=? and idzona=? and idlugar=? and hasta is null", _conn)
        Dim _lugar As Lugar = LugarPorNombre(lugar)
        Dim _zona As Zona = _lugar.Zonas.Find(Function(x) x.Nombre = zona)
        Dim _subzona As Subzona = _zona.Subzonas.Find(Function(x) x.Nombre = subzona)
        con.CrearParametro(DbType.Int64, _subzona.ID)
        con.CrearParametro(DbType.Int64, _zona.ID)
        con.CrearParametro(DbType.Int64, _lugar.ID)
        Return con.ExecuteScalar
    End Function

    Public Function Pregunta(username As String) As String Implements IUsuarioRepositorio.Pregunta
        Dim cmd As New OdbcCommand("select preguntasecreta from usuario where nombredeusuario=?;", _conn)
        cmd.CrearParametro(DbType.String, username)
        Return cmd.ExecuteScalar
    End Function

    Friend Overrides Sub Lugares(dtlugares As DataTable, vin As String)
        Dim trans As New OdbcCommand("select lugar.nombre as nombrelugar, transporte.fechahorasalida as partida, transporte.fechahorallegada as llegada, usuario.nombredeusuario as transportista from transporta, usuario, transporte, lote, integra, lugar where transporta.transporteID=transporte.transporteID and transporta.idlote=lote.idlote and integra.lote=lote.idlote and integra.vin=? and integra.invalidado='f' and lote.hacia=lugar.idlugar and usuario.idusuario=transporte.usuario;", _conn)
        trans.CrearParametro(DbType.StringFixedLength, vin)
        Dim rdr = trans.ExecuteReader
        Dim idr = dtlugares.NewRow
        dtlugares.Rows.Add(idr)
        idr("Nombre de lugar") = LRepo.Nombre(VRepo.PuertoLlegada(vin))
        idr("Fecha de llegada") = VRepo.FechaLlegada(vin)
        idr("Transportado por") = "Ingresa al sistema"
        idr("Fecha de partida") = "Permanece"
        While (rdr.Read)
            idr("Fecha de partida") = rdr.Item(1)
            idr = dtlugares.NewRow
            dtlugares.Rows.Add(idr)
            idr("Nombre de lugar") = rdr.Item(0)
            idr("Fecha de llegada") = rdr.Item(2)
            idr("Transportado por") = rdr.Item(3)
            idr("Fecha de partida") = "Permanece"
        End While
    End Sub

    Public Function Nombre(id As Integer) As String Implements ILugarRepositorio.Nombre
        Dim cmd As New OdbcCommand("select nombre from lugar where idlugar = ?;", _conn)
        cmd.CrearParametro(DbType.Int64, id)
        Return cmd.ExecuteScalar
    End Function

    Public Function VehiculosEnLote(loteid As Integer) As DataTable Implements ILugarRepositorio.VehiculosEnLote
        Dim cmd As New OdbcCommand("select vehiculo.vin, vehiculo.modelo, vehiculo.marca, integra.fecha from vehiculo, integra where integra.lote=? and integra.vin=vehiculo.vin;", _conn)
        cmd.CrearParametro(DbType.Int64, loteid)
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable("vehiculos")
        dt.Load(rdr)
        Return dt
    End Function

    Public Function NewLote(numeroLote As UInteger, nombre As String, lugar As Lugar, destino As Lugar, usuario As Usuario, estado As EstadoLote, prioridad As PrioridadLote) As Lote Implements ILugarRepositorio.NewLote
        Dim cmd As New OdbcCommand("insert into lote(idlote, nombre, desde, hacia, creadorid, prioridad, estado) values(?,?,?,?,?,?,?);", _conn)
        cmd.CrearParametro(DbType.Int64, numeroLote)
        cmd.CrearParametro(DbType.String, nombre)
        cmd.CrearParametro(DbType.Int64, lugar.ID)
        cmd.CrearParametro(DbType.Int64, destino.ID)
        cmd.CrearParametro(DbType.Int64, usuario.ID)
        cmd.CrearParametro(DbType.String, [Enum].GetName(GetType(PrioridadLote), prioridad))
        cmd.CrearParametro(DbType.String, [Enum].GetName(GetType(EstadoLote), estado))
        If cmd.ExecuteNonQuery > 0 Then
            Return New Lote(numeroLote, nombre, lugar.ID, destino.ID, usuario, prioridad, estado)
        End If
        Return Nothing
    End Function

    Friend Overrides Function UpdateInformeDesc(id As Integer, newDesc As String) As Boolean
        Dim cmd As New OdbcCommand("update informedanios set descripcion=? where id=?;", _conn)
        cmd.CrearParametro(DbType.String, newDesc)
        cmd.CrearParametro(DbType.Int64, id)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Friend Overrides Function UpdateInformeTipo(id As Integer, newTipo As String) As Boolean
        Dim cmd As New OdbcCommand("update informedanios set tipo=? where id=?;", _conn)
        cmd.CrearParametro(DbType.String, newTipo)
        cmd.CrearParametro(DbType.Int64, id)
        Return cmd.ExecuteNonQuery > 0
    End Function

    Friend Overrides Function UpdateInformeReg(id As Integer, reg As Integer, newDesc As String) As Boolean
        Dim cmd As New OdbcCommand("select count(*) from registrodanios where informedanios=? and nroenlista=?;", _conn)
        cmd.CrearParametro(DbType.Int64, id)
        cmd.CrearParametro(DbType.Int64, reg)
        If cmd.ExecuteScalar > 0 Then
            Dim ucmd As New OdbcCommand("update registrodanios set descripcion=? where informedanios=? and nroenlista=?;", _conn)
            ucmd.CrearParametro(DbType.String, newDesc)
            ucmd.CrearParametro(DbType.Int64, id)
            ucmd.CrearParametro(DbType.Int64, reg)
            Return ucmd.ExecuteNonQuery > 0
        Else
            Dim icmd As New OdbcCommand("insert into registrodanios(informedanios, nroenlista, descripcion) values(?, ?, ?);", _conn)
            icmd.CrearParametro(DbType.Int64, id)
            icmd.CrearParametro(DbType.Int64, reg)
            icmd.CrearParametro(DbType.String, newDesc)
            Return icmd.ExecuteNonQuery > 0
        End If
    End Function
    Private Shared Function ConvertToByteArray(ByVal value As Bitmap) As Byte()
        Dim bitmapBytes As Byte()
        Using stream As New System.IO.MemoryStream
            value.Save(stream, value.RawFormat)
            bitmapBytes = stream.ToArray
        End Using
        Return bitmapBytes
    End Function
    Friend Overrides Sub UpdateInformeImg(eninforme As Integer, enregistro As Integer, images As List(Of Bitmap))
        Dim cmd As New OdbcCommand("select count(*) from imagenregistro where informe=? and nrolista=?;", _conn)
        cmd.CrearParametro(DbType.Int64, eninforme)
        cmd.CrearParametro(DbType.Int64, enregistro)
        Dim r = cmd.ExecuteScalar
        If r <> images.Count Then
            Dim icmd As New OdbcCommand("insert into imagenregistro(informe, nrolista, nroimagen, imagen) values(?,?,?,?);", _conn)
            icmd.CrearParametro(DbType.Int64, eninforme)
            icmd.CrearParametro(DbType.Int64, enregistro)
            Dim imgc = icmd.CrearParametro(DbType.Int64, -1)
            Dim imagen = icmd.CrearParametro(DbType.Binary, Nothing)
            For i = r To images.Count - 1
                imgc.Value = i + 1
                imagen.Value = ConvertToByteArray(images(i))
                If icmd.ExecuteNonQuery < 1 Then
                    Return
                End If
            Next
        End If
    End Sub

    Public Function CapacidadZona(zona As String, lugar As String) As Integer Implements ILugarRepositorio.CapacidadZona
        Dim cmd As New OdbcCommand("select capacidad from zona where nombre=? and idlugar=(select idlugar from lugar where nombre=?);", _conn)
        cmd.CrearParametro(DbType.String, zona)
        cmd.CrearParametro(DbType.String, lugar)
        Return cmd.ExecuteScalar
    End Function

    Public Function OcupacionZona(zona As String, lugar As String) As Integer Implements ILugarRepositorio.OcupacionZona
        Dim cmd As New OdbcCommand("select count(*) from posicionado where idlugar=? and idzona=? and hasta is null;", _conn)
        Dim sz = LugarPorNombre(ConectadoEn).Zonas.Where(Function(z) z.Nombre = zona).Single
        cmd.CrearParametro(DbType.Int64, sz.Padre.ID)
        cmd.CrearParametro(DbType.Int64, sz.ID)
        Return cmd.ExecuteScalar
    End Function

    Public Function VehiculosEnSubzona(y As String, x As String, conectadoEn As String) As List(Of String) Implements ILugarRepositorio.VehiculosEnSubzona
        Dim cmd As New OdbcCommand("select VIN from posicionado where idlugar=? and idzona=? and idsub=? and hasta is null;", _conn)
        Dim sz = LugarPorNombre(conectadoEn).Subzonas.Where(Function(z) z.Nombre = y AndAlso z.Padre.Nombre = x).Single
        cmd.CrearParametro(DbType.Int64, sz.Padre.Padre.ID)
        cmd.CrearParametro(DbType.Int64, sz.Padre.ID)
        cmd.CrearParametro(DbType.Int64, sz.ID)
        Dim r = cmd.ExecuteReader
        Dim lst As New List(Of String)
        While r.Read
            lst.Add(r.Item(0))
        End While
        Return lst
    End Function

    Public Function LoteAbierto(Lote As String) As Boolean Implements ILugarRepositorio.LoteAbierto
        Dim scmd As New OdbcCommand("select estado from lote where nombre=?;", _conn)
        scmd.CrearParametro(DbType.String, Lote)
        Return scmd.ExecuteScalar = "Abierto"
    End Function

    Public Function NewLote(id As Integer, nombre As String, hacia As String, prioridad As String) As String Implements IUsuarioRepositorio.NewLote
        Return NewLote(id, nombre, usuarioConectado.ConectadoEn, LugarPorNombre(hacia), usuarioConectado, EstadoLote.Abierto, Logica.Lote.PrioridadFromString(prioridad)).Nombre
    End Function

    Public Sub Cerrar(lote As String) Implements ILugarRepositorio.Cerrar
        Dim scmd As New OdbcCommand("update lote set estado='Cerrado' where lote.nombre=? and lote.estado<>'Cerrado';", _conn)
        scmd.CrearParametro(DbType.String, lote)
        scmd.ExecuteNonQuery()
    End Sub

    Public Function Consultar(consulta As String) As DataTable Implements ISQLRepositorio.Consultar
        Try
            Dim ccmd As New OdbcCommand(consulta, _conn)
            Dim dt As New DataTable
            dt.Load(ccmd.ExecuteReader)
            Return dt
        Catch ex As Exception
            Throw New Exception("Sentencia incorrecta")
        End Try
    End Function

    Public Function ConsultarSingle(sql As String) As Object Implements ISQLRepositorio.ConsultarSingle
        Dim ccmd As New OdbcCommand(sql, _conn)
        Return ccmd.ExecuteScalar
    End Function

    Public Function ConsultarSinRetorno(v As String) As Integer Implements ISQLRepositorio.ConsultarSinRetorno
        Dim ccmd As New OdbcCommand(v, _conn)
        Return ccmd.ExecuteNonQuery()
    End Function

    Public Function UsuarioID() As Integer Implements IUsuarioRepositorio.UsuarioID
        Return usuarioConectado?.ID
    End Function

    Public Function CambiarPregunta(nuevapregunta As String, nuevarespuesta As String, contraseña As String) As Boolean Implements IUsuarioRepositorio.CambiarPregunta
        If usuarioConectado?.VerificarContraseña(contraseña) Then
            Return Me.ConsultarSinRetorno($"update usuario set preguntasecreta='{nuevapregunta}', respuestasecreta='{nuevarespuesta}' where idusuario={UsuarioID()}") > 0
        Else
            Return False
        End If
    End Function

    Friend Overrides Function IDInformes(vin As String) As String()
        Dim dt = Me.Consultar($"select id from informedanios where vin='{vin}';")
        Return dt.ToList.Select(Function(x) x(0)).ToArray
    End Function

    Friend Overrides Function IDRegistros(informe As String) As String()
        Dim dt = Me.Consultar($"select id from registrodanios where informedanios={informe};")
        Return dt.ToList.Select(Function(x) x(0)).ToArray
    End Function
End Class