Imports Operario.Logica

Public Interface IUsuarioRepositorio
    Function UsuarioIncompletoPorID(id As Integer) As Logica.Usuario 'Devuelve el usuario, pero si no ha sido buscado antes no busca sus lugares de trabajo. Se usa para llenar los lugares antes de hacer búsqueda completa de usuarios
    Function UsuarioPorID(id As Integer) As Logica.Usuario 'Devuelve el usuario si existe
    Function UsuarioPorNombre(nombre As String) As Logica.Usuario 'Idem
    Function Sincronizar() As Boolean 'Sincroniza entre el estado local y el estado en el servidor

    Function Login(username As String, password As String) As Logica.Usuario
    Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean

    Function LugaresTrabaja() As List(Of String)
    Function UltimaConexionEn(lugar As String) As Date?

    Function ConectarEn(lugar As String) As Boolean
    Function Desconectar() As Boolean

    Function NombreCompleto() As String
    Function NombreDeUsuario() As String
    Function RolDeUsuario() As String

    Function AccesosAlSistema() As Integer

    Function UltimoAcceso() As Date?
    Function UsuarioIncompletoPorNombre(nombre As String) As Usuario
End Interface

Public Interface ILugarRepositorio
    Function AllLugares() As List(Of Logica.Lugar)
    Function LugarPorNombre(nombre As String) As Logica.Lugar
    Function LugarPorID(id As Integer) As Logica.Lugar
End Interface

Public Module Constantes
    Public URepo As IUsuarioRepositorio = Nothing
    Public LRepo As ILugarRepositorio = Nothing
    Public VRepo As VehiculoRepo = Nothing
End Module

Public MustInherit Class VehiculoRepo
    Public MustOverride Function VehiculoPorVIN(VIN As String) As Logica.Vehiculo

    Public MustOverride Function Sincronizar() As Boolean
    Public MustOverride Function ExisteVIN(vin As String) As Boolean

    Public MustOverride ReadOnly Property Vehiculos As List(Of Logica.Vehiculo)

    Public MustOverride Function VehiculosEn(Lugar As String) As List(Of Logica.Vehiculo)

    Public Function IngresarVehiculo(VIN As String, Marca As String, Modelo As String, Año As Integer, Color As Color, Cliente As String, Tipo As Logica.TipoVehiculo, PuertoLlegada As Logica.Lugar) As Logica.Vehiculo
        If PuertoLlegada.Tipo <> Logica.TipoLugar.Puerto Then
            Throw New InvalidOperationException("Sólo se pueden añadir vehículos en el puerto")
        End If
        If ExisteVIN(VIN) Then
            Throw New InvalidOperationException("El vehículo con ese VIN ya existe en el sistema")
        End If
        Dim v = New Logica.Vehiculo(VIN, Marca, Modelo, Año, Color, Tipo, False, Cliente, PuertoLlegada, Nothing, New List(Of Logica.InformeDaños))
        Vehiculos.Add(v)
        Return v
    End Function
End Class