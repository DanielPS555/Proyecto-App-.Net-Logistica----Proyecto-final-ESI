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

    Public Function LugaresTrabaja() As List(Of Lugar) Implements IUsuarioRepositorio.LugaresTrabaja
        Return usuarioConectado?.TrabajaEn.Select(Function(x) x.Lugar).ToList
    End Function
End Class