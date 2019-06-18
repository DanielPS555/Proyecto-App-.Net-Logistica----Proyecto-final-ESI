Imports Operario
Imports Operario.Logica

Public Class FLugarRepo
    Implements ILugarRepositorio
    Private lugares As New List(Of Lugar)
    Public Function AllLugares() As List(Of Lugar) Implements ILugarRepositorio.AllLugares
        Return lugares
    End Function

    Public Function LugarPorNombre(nombre As String) As Lugar Implements ILugarRepositorio.LugarPorNombre
        Try
            Return lugares.Where(Function(x) x.Nombre = nombre).Single
        Catch e As InvalidOperationException
            Return Nothing
        End Try
    End Function
End Class

Public Class FVehiculoRepo
    Inherits VehiculoRepo

    Private _vehiculos As New List(Of Vehiculo)

    Public Overrides ReadOnly Property Vehiculos As List(Of Vehiculo)
        Get
            Return _vehiculos
        End Get
    End Property

    Public Overrides Function VehiculoPorVIN(VIN As String) As Vehiculo
        Dim find = _vehiculos.Where(Function(x) x.VIN = VIN)
        If find.Count = 0 Then
            Return Nothing
        End If
        Return find.Single
    End Function

    Public Overrides Function Sincronizar() As Boolean
        Return True
    End Function

    Public Overrides Function ExisteVIN(vin As String) As Boolean
        Return _vehiculos.Where(Function(x) x.VIN = vin).Count <> 0
    End Function

    Public Overrides Function VehiculosEn(Lugar As String) As List(Of Vehiculo)
        Return _vehiculos.Where(Function(x) )
    End Function
End Class

Public Class FUsuarioRepo
    Implements IUsuarioRepositorio

    Private usuarios As New List(Of Usuario)

    Public Function UsuarioPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioPorID
        Return usuarios.Find(Function(x) x.ID = id)
    End Function

    Public Function UsuarioPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioPorNombre
        Return usuarios.Find(Function(x) x.UserName = nombre)
    End Function

    Public Function Sincronizar() As Boolean Implements IUsuarioRepositorio.Sincronizar
        Return True
    End Function

    Private usuarioConectado As Usuario = Nothing

    Public Function Login(username As String, password As String) As Usuario Implements IUsuarioRepositorio.Login
        Try
            Dim f = usuarios.Where(Function(x) x.UserName = username).Single
            If f.VerificarContraseña(password) Then
                usuarioConectado = f
                Return f
            Else
                Return Nothing
            End If
        Catch e As InvalidOperationException
            Return Nothing
        End Try
    End Function

    Public Function Restablecer(usuario As String, respuesta As String, newpass As String) As Boolean Implements IUsuarioRepositorio.Restablecer
        Dim findUsuario = usuarios.Where(Function(x) x.UserName = usuario)
        If findUsuario.Count = 0 Then
            Return False
        End If
        Dim userObj = findUsuario.Single
        Return userObj.RestablecerContraseña(respuesta, newpass)
    End Function

    Public Function Registrar(username As String, password As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta As String, respuesta As String, sexo As Sexo, email As String, telefono As String, rol As Role) As Usuario Implements IUsuarioRepositorio.Registrar
        If usuarios.Where(Function(x) x.UserName = username).Count <> 0 Then
            Return Nothing
        End If
        Dim newUser As Usuario = New Usuario(usuarios.Count + 1, New List(Of TrabajaEn), username, Usuario.ContraseñaHash(password, username), primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, pregunta, respuesta, Nothing, sexo, email, telefono, rol)
        usuarios.Add(newUser)
        Return newUser
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
        If usuarioConectado Is Nothing Then Return Nothing
        Dim str = usuarioConectado.PrimerNombre
        If usuarioConectado.SegundoNombre IsNot Nothing Then
            str += $" {usuarioConectado.SegundoNombre}"
        End If
        str += $" {usuarioConectado.PrimerApellido}"
        If usuarioConectado.SegundoApellido IsNot Nothing Then
            str += $" {usuarioConectado.SegundoApellido}"
        End If
        Return str
    End Function

    Public Function NombreDeUsuario() As String Implements IUsuarioRepositorio.NombreDeUsuario
        If usuarioConectado Is Nothing Then Return Nothing
        Return usuarioConectado.UserName
    End Function

    Public Function RolDeUsuario() As String Implements IUsuarioRepositorio.RolDeUsuario
        If usuarioConectado Is Nothing Then Return Nothing
        Return usuarioConectado.Rol.Nombre
    End Function

    Public Function AccesosAlSistema() As Integer Implements IUsuarioRepositorio.AccesosAlSistema
        If usuarioConectado Is Nothing Then Return Nothing
        Return usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas.Count
    End Function

    Public Function UltimoAcceso() As Date? Implements IUsuarioRepositorio.UltimoAcceso
        If usuarioConectado Is Nothing Then Return Nothing
        Dim tmp = usuarioConectado.TrabajaEn.Select(Function(x) x.Conexiones).UnionListas
        Dim tmp2 = tmp.Select(Function(x) x.FechaInicio).ToList
        tmp2.Sort()
        Return tmp2.Last
    End Function
End Class