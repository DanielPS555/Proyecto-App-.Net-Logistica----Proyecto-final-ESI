Imports System.Data.Odbc
Imports Operario
Imports Operario.Logica

Public Class SQLRepo
    Inherits VehiculoRepo
    Implements IUsuarioRepositorio
    Implements ILugarRepositorio

    Private _users As New List(Of Usuario)
    Private _lugares As List(Of Lugar)
    Private _zonas As List(Of Zona)
    Private _subzonas As List(Of Subzona)
    Private _vehiculos As List(Of Vehiculo)
    Private _lotes As List(Of Lote)
    Public Overrides Function Sincronizar() As Boolean Implements IUsuarioRepositorio.Sincronizar
    End Function

    Private _conn As OdbcConnection

    Public Sub New(Connection As OdbcConnection)
        _conn = Connection
        Sincronizar()
    End Sub

    Public Overrides ReadOnly Property Vehiculos As List(Of Vehiculo)
        Get
            Sincronizar()
            Return _vehiculos
        End Get
    End Property

    Private usuarioConectado As Usuario = Nothing

    Public Function UsuarioIncompletoPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorID
        Dim find = _users.Where(Function(x) x.ID = id)
        If find.Count <> 0 Then
            Return find.Single
        End If
        Dim cmd = New OdbcCommand("select * from usuario where idusuario=?;", _conn)
        Dim idparam = cmd.CreateParameter
        idparam.DbType = DbType.Int64
        idparam.Value = id
        Dim rdr = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(rdr)
        If dt.Rows.Count <> 1 Then
            Return Nothing
        End If
        Dim usr = New Usuario(dt.Rows()(0))
        _users.Add(usr)
        Return usr
    End Function

    Public Function UsuarioIncompletoPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorNombre
        Dim find = _users.Where(Function(x) x.UserName = nombre)
        If find.Count <> 0 Then
            Return find.Single
        End If
        Dim cmd = New OdbcCommand("select * from usuario where nombredeusuario=?;", _conn)
        Dim nomparam = cmd.CreateParameter
        nomparam.DbType = DbType.String
        nomparam.Value = nombre
        Dim rdr = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(rdr)
        If dt.Rows.Count <> 1 Then
            Return Nothing
        End If
        Dim usr = New Usuario(dt.Rows()(0))
        _users.Add(usr)
        Return usr
    End Function

    Public Function UsuarioPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioPorID
        Dim usr = UsuarioIncompletoPorID(id)
        CompletarUsuario(usr)
        Return usr
    End Function

    Private Sub CompletarUsuario(usr As Usuario)
        Dim cmd = New OdbcCommand("select * from trabajaen where idusuario=?;", _conn)
        Dim uid = cmd.CreateParameter
        uid.DbType = DbType.Int64
        uid.Value = usr.ID
        Dim rdr = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Dim _cmd = New OdbcCommand("select * from conexion where idtrabajaen=?;", _conn)
        Dim teid = _cmd.CreateParameter
        teid.DbType = DbType.Int64
        For Each i As DataRow In dt.Rows
            Dim tmp = New TrabajaEn(i, usr)
            usr.TrabajaEn.Add(tmp)
            teid.Value = tmp.ID
            rdr = _cmd.ExecuteReader
            Dim ct As New DataTable
            ct.Load(rdr)
            For Each _i As DataRow In ct.Rows
                tmp.Conexiones.Add(New Conexion(_i("HoraIngreso"), _i("HoraSalida")))
            Next
        Next
    End Sub

    Public Function UsuarioPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioPorNombre
        Dim usr = UsuarioIncompletoPorNombre(nombre)
        CompletarUsuario(usr)
        Return usr
    End Function

    Public Function Login(username As String, password As String) As Usuario Implements IUsuarioRepositorio.Login
        _users.Where(Function(x) x.UserName = username).Where(Function(x) x.VerificarContraseña(password)).ForEach(Sub(x)
                                                                                                                       usuarioConectado = x
                                                                                                                   End Sub)
        Return usuarioConectado
    End Function

    Public Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean Implements IUsuarioRepositorio.Restablecer
        Dim r = _users.Where(Function(x) x.UserName = username).Select(Function(x) x.RestablecerContraseña(respuesta, newpass))
        If r.Count <> 0 Then
            Return r.Single
        Else
            Return False
        End If
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
        Return usuarioConectado.TrabajaEn.Where(Function(x) x.Lugar.Nombre = lugar).Select(Function(x) usuarioConectado.Conectar(x.Lugar)).Single
    End Function

    Public Function Desconectar() As Boolean Implements IUsuarioRepositorio.Desconectar
        If usuarioConectado Is Nothing Then Return Nothing
        Return usuarioConectado.Desconectar
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

    Public Function AllLugares() As List(Of Lugar) Implements ILugarRepositorio.AllLugares
        If _lugares Is Nothing Then
            _lugares = New List(Of Lugar)
            Dim cmd = New OdbcCommand("select * from lugar;", _conn)
            Dim rdr = cmd.ExecuteReader
            Dim dt As New DataTable
            dt.Load(rdr)
            For Each i As DataRow In dt.Rows
                Dim lugar As New Lugar(i)
                _lugares.Add(lugar)
            Next
            Dim loteCmd = New OdbcCommand("select * from lote;", _conn)
            Dim loteRdr = loteCmd.ExecuteReader
            Dim loteDt As New DataTable
            loteDt.Load(loteRdr)
            For Each l As DataRow In loteDt.Rows
                Dim autos = New OdbcCommand("select * from integra where Lote=?;")
                Dim lote = New Lote(l)
                Dim param = autos.CreateParameter
                param.DbType = DbType.Int64
                param.Value = l("IDLote")
                Dim aRdr = autos.ExecuteReader
                Dim auDt = New DataTable
                auDt.Load(aRdr)
                For Each a As DataRow In auDt.Rows
                    Dim v = VehiculoPorVIN(a("VIN"))
                    lote.Integrantes.Add(v)
                    v.Informes.Where(Function(x) x.Fecha)
                Next
            Next
        End If
        Sincronizar()
        Return _lugares
    End Function

    Public Function LugarPorNombre(nombre As String) As Lugar Implements ILugarRepositorio.LugarPorNombre
        Throw New NotImplementedException()
    End Function

    Public Overrides Function VehiculoPorVIN(VIN As String) As Vehiculo
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExisteVIN(vin As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function VehiculosEn(Lugar As String) As List(Of Vehiculo)
        Throw New NotImplementedException()
    End Function

    Public Function LugarPorID(id As Integer) As Lugar Implements ILugarRepositorio.LugarPorID
        Throw New NotImplementedException()
    End Function
End Class