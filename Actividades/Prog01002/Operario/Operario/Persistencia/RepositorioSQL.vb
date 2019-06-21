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
        CompletarUsuario(usr)
        Return usr
    End Function


    Private Sub CompletarUsuario(usr As Usuario)
        Dim cmd = New OdbcCommand("select * from trabajaen where idusuario=?;", _conn)
        Dim uid = cmd.CrearParametro(DbType.Int64, usr.ID)
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Dim _cmd = New OdbcCommand("select * from conexion where horasalida is null;", _conn)
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
        Dim con = cdt.ToList.Single
        Dim te = usr.TrabajaEn.Find(Function(x) x.ID = con("IDTrabajaEn"))
        Dim entrada = con("HoraIngreso")
        Dim salida = AutoNull(Of DateTime?)(con("HoraSalida"))
        te.Conexiones.Add(New Conexion(entrada, salida))
    End Sub

    Public Function UsuarioPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioPorNombre
        Dim usr = UsuarioIncompletoPorNombre(nombre)
        CompletarUsuario(usr)
        Return usr
    End Function

    Public Function Login(username As String, password As String) As Usuario Implements IUsuarioRepositorio.Login
        Dim u = UsuarioPorNombre(username)
        If u.VerificarContraseña(password) Then usuarioConectado = u
        Return usuarioConectado
    End Function

    Public Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean Implements IUsuarioRepositorio.Restablecer
        Dim r = UsuarioPorNombre(username)?.RestablecerContraseña(respuesta, newpass)
        Return r
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
        If usuarioConectado.ConectadoEn IsNot Nothing Then
            Return False
        End If
        If Not LugaresTrabaja.Contains(lugar) Then
            Return False
        End If
        Dim val = usuarioConectado.TrabajaEn.Where(Function(x) x.Lugar.Nombre = lugar).Select(Function(x) usuarioConectado.Conectar(x.Lugar)).Single
        If val Then
            Dim conexiones = usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas.ToList
            conexiones.Sort(ConnectionComparison)
            Dim te = usuarioConectado.TrabajaEn.Where(Function(x) x.Conexiones.Contains(conexiones.Last)).Single
            Dim com As New OdbcCommand("insert into conexion(IDTrabajaEn, HoraIngreso) values(?, ?);", _conn)
            com.CrearParametro(DbType.Int64, te.ID)
            com.CrearParametro(DbType.DateTime, Date.Now)
            Return com.ExecuteNonQuery() > 0
            'TODO:       Informix se queja de tuplas duplicadas; arreglar para la segunda
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Desconectar() As Boolean Implements IUsuarioRepositorio.Desconectar
        If usuarioConectado Is Nothing Then Return Nothing
        Dim val = usuarioConectado.Desconectar
        If val Then
            Dim conexiones = usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas.ToList
            conexiones.Sort(ConnectionComparison)
            Dim te = usuarioConectado.TrabajaEn.Where(Function(x) x.Conexiones.Contains(conexiones.Last)).Single
            Dim com As New OdbcCommand("update conexion set HoraSalida=? where IDTrabajaEn=? and HoraIngreso=?;", _conn)
            com.CrearParametro(DbType.DateTime, DateTime.Now)
            com.CrearParametro(DbType.Int64, te.ID)
            com.CrearParametro(DbType.DateTime, conexiones.Last.FechaInicio)
            Return com.ExecuteNonQuery > 0
            'Informix se queja de tuplas duplicadas
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

    Public Overrides Function VehiculoIncompleto(VIN As String) As Vehiculo
        Dim cmd As New OdbcCommand("select * from vehiculo where VIN=?;", _conn)
        Dim par = cmd.CrearParametro(DbType.StringFixedLength, VIN)
        Dim dt As New DataTable()
        dt.Load(cmd.ExecuteReader)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Return New Vehiculo(dt.Rows()(0))
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
        par = cmd.CrearParametro(DbType.Int64, id)
        rdr = cmd.ExecuteReader
        Dim loteDt As New DataTable
        loteDt.Load(rdr)
        Dim lotes As New List(Of Lote)
        Dim tpr = New OdbcCommand("select * from transporta, transporte where transporta.idlote=? and transporta.transporteID=transporte.transporteID;", _conn)
        Dim tpp = tpr.CrearParametro(DbType.Int64, -1)
        For Each l As DataRow In loteDt.Rows
            Dim autos = New OdbcCommand("select * from integra where Lote=?;")
            tpp.Value = l("IDLote")
            Dim ex = tpr.ExecuteReader
            Dim tdt As New DataTable
            tdt.Load(ex)
            Dim rows = tdt.ToList()
            rows.Sort(DateOrder)
            Dim Lote As Lote = New Lote(l, lugar, If(rows.Count > 0, rows.Last()("FechaHoraSalida"), Nothing))
            Dim param = autos.CrearParametro(DbType.Int64, l("IDLote"))
            Dim aRdr = autos.ExecuteReader
            Dim auDt = New DataTable
            auDt.Load(aRdr)
            For Each a As DataRow In auDt.Rows
                Dim v = InformesVehiculo(a("VIN"))
                Lote.Integrantes.Add(v)
            Next
            lotes.Add(Lote)
            lugar.LotesCreados.Add(Lote)
        Next
        Dim zonasCmd = New OdbcCommand("select * from zona where idlugar=?;", _conn)
        zonasCmd.CrearParametro(DbType.Int64, id)
        Dim zdt = New DataTable
        zdt.Load(zonasCmd.ExecuteReader)
        Dim szonasCmd = New OdbcCommand("select * from subzona where idlugar=? and idzona=?;", _conn)
        szonasCmd.CrearParametro(DbType.Int64, id)
        Dim zpm = szonasCmd.CrearParametro(DbType.Int64, -1)
        Dim posCmd = New OdbcCommand("select * from posicionado where (idlugar=?) and (idzona=?) and (idsub=?) and (hasta is null);", _conn)
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

    Public Function ListaVehiculos(dt As DataTable) As DataTable Implements IUsuarioRepositorio.ListaVehiculos
        If usuarioConectado Is Nothing Then
            Throw New InvalidOperationException("No está conectado")
        End If
        ReloadUsuario(usuarioConectado)
        Dim x = usuarioConectado.ConectadoEn
        Dim szonasPos As IEnumerable(Of List(Of Posicionado)) = x.Subzonas.Select(Function(z) z.Posicionados)
        For Each i In szonasPos.UnionListas
            Dim dr = dt.NewRow
            dt.Rows.Add(dr)
            dr("Estado") = [Enum].GetName(GetType(EstadoVehiculo), i.Vehiculo.Estado)
            dr("VIN") = i.Vehiculo.VIN
            dr("Marca") = i.Vehiculo.Marca
            dr("Modelo") = i.Vehiculo.Modelo
            dr("VehiculoTipo") = [Enum].GetName(GetType(TipoVehiculo), i.Vehiculo.Tipo)
        Next
        Return dt
    End Function

    Private Sub ReloadUsuario(usuarioConectado As Usuario)
        CompletarUsuario(usuarioConectado)
    End Sub

    Public Function AltaVehiculo(VIN As String, marca As String, modelo As String, año As Integer, zona As String, subzona As String, posicion As Integer, color As Color) As Boolean Implements IUsuarioRepositorio.AltaVehiculo
        If usuarioConectado Is Nothing Then
            Return False
        End If
        Dim checkCommand = New OdbcCommand("select count(*) from vehiculoIngresa where VIN=?;", _conn)
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
        Dim updateCommand = New OdbcCommand("update vehiculo set Marca=?, Modelo=?, Anio=?, Color=? where VIN=?;", _conn)
        updateCommand.CrearParametro(DbType.String, marca)
        updateCommand.CrearParametro(DbType.String, modelo)
        updateCommand.CrearParametro(DbType.Int64, año)
        updateCommand.CrearParametro(DbType.StringFixedLength, color.ToArgb.ToString("X6"))
        updateCommand.CrearParametro(DbType.StringFixedLength, VIN)
        If updateCommand.ExecuteNonQuery > 0 Then Return True
        Throw New Exception("No hubieron cambios en el vehículo, por favor informe a su administrador")
    End Function

    Public Function ConectadoEn() As String Implements IUsuarioRepositorio.ConectadoEn
        Return usuarioConectado?.ConectadoEn.Nombre
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
        Return VehiculoIncompleto(vin).ClienteNombre
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
        Return VehiculoIncompleto(vin)?.LugarActual.Nombre
    End Function

    Public Overrides Function Zona(vin As String) As String
        Return VehiculoIncompleto(vin)?.PosicionActual.Subzona.Padre.Nombre
    End Function

    Public Overrides Function Subzona(vin As String) As String
        Return VehiculoIncompleto(vin)?.PosicionActual.Subzona.Nombre
    End Function

    Public Overrides Function Posicion(vin As String) As Integer
        Return VehiculoIncompleto(vin)?.PosicionActual.Posicion
    End Function

    Public Overrides Function Lote(vin As String) As String
        Return AllLugares.Select(Function(x) x.LotesCreados).UnionListas.Where(Function(x) x.Integrantes.Where(Function(z) z.VIN = vin).Count > 0 AndAlso x.FechaPartida Is Nothing).SingleOrDefault?.ID.ToString
    End Function

    Public Function TipoLugar(lugar As String) As String Implements ILugarRepositorio.TipoLugar
        Return [Enum].GetName(GetType(TipoLugar), LugarPorNombre(lugar).Tipo)
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
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Descripcion", GetType(String))
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
End Class