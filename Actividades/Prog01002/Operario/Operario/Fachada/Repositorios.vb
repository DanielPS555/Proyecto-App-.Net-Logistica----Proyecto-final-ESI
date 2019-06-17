Public Interface IUsuarioRepositorio
    Function UsuarioPorID(id As Integer) As Logica.Usuario
    Function UsuarioPorNombre(nombre As String) As Logica.Usuario
    Function Sincronizar() As Boolean

    Function Login(username As String, password As String) As Logica.Usuario
    Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean
    Function Registrar(username As String, password As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta As String, respuesta As String, sexo As Logica.Sexo, email As String, telefono As String, rol As Logica.Role) As Logica.Usuario

    Function LugaresTrabaja() As List(Of Logica.Lugar)
End Interface

Public Interface ILugarRepositorio
    Function AllLugares() As List(Of Logica.Lugar)
    Function LugarPorNombre(nombre As String) As Logica.Lugar
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