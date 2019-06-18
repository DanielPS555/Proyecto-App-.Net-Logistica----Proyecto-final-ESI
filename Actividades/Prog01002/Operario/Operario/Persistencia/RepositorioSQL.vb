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
            Throw New NotImplementedException()
        End Get
    End Property

    Public Function UsuarioIncompletoPorID(id As Integer) As Usuario
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
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim usr = New Usuario(dt.Rows()(0))
        _users.Add(usr)
        Return usr
    End Function

    Public Function UsuarioPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioPorID
        Dim usr = UsuarioIncompletoPorID(id)
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
        Return usr
    End Function

    Public Function UsuarioPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioPorNombre
        Throw New NotImplementedException()
    End Function



    Public Function Login(username As String, password As String) As Usuario Implements IUsuarioRepositorio.Login
        Throw New NotImplementedException()
    End Function

    Public Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean Implements IUsuarioRepositorio.Restablecer
        Throw New NotImplementedException()
    End Function

    Public Function Registrar(username As String, password As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta As String, respuesta As String, sexo As Sexo, email As String, telefono As String, rol As Role) As Usuario Implements IUsuarioRepositorio.Registrar
        Throw New NotImplementedException()
    End Function

    Public Function LugaresTrabaja() As List(Of String) Implements IUsuarioRepositorio.LugaresTrabaja
        Throw New NotImplementedException()
    End Function

    Public Function UltimaConexionEn(lugar As String) As Date? Implements IUsuarioRepositorio.UltimaConexionEn
        Throw New NotImplementedException()
    End Function

    Public Function ConectarEn(lugar As String) As Boolean Implements IUsuarioRepositorio.ConectarEn
        Throw New NotImplementedException()
    End Function

    Public Function Desconectar() As Boolean Implements IUsuarioRepositorio.Desconectar
        Throw New NotImplementedException()
    End Function

    Public Function NombreCompleto() As String Implements IUsuarioRepositorio.NombreCompleto
        Throw New NotImplementedException()
    End Function

    Public Function NombreDeUsuario() As String Implements IUsuarioRepositorio.NombreDeUsuario
        Throw New NotImplementedException()
    End Function

    Public Function RolDeUsuario() As String Implements IUsuarioRepositorio.RolDeUsuario
        Throw New NotImplementedException()
    End Function

    Public Function AccesosAlSistema() As Integer Implements IUsuarioRepositorio.AccesosAlSistema
        Throw New NotImplementedException()
    End Function

    Public Function UltimoAcceso() As Date? Implements IUsuarioRepositorio.UltimoAcceso
        Throw New NotImplementedException()
    End Function

    Public Function AllLugares() As List(Of Lugar) Implements ILugarRepositorio.AllLugares
        Throw New NotImplementedException()
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