﻿Public Interface IUsuarioRepositorio
    Function UsuarioPorID(id As Integer) As Logica.Usuario
    Function UsuarioPorNombre(nombre As String) As Logica.Usuario
    Function Sincronizar() As Boolean

    Function Login(username As String, password As String) As Logica.Usuario
    Function Restablecer(respuesta As String, newpass As String) As Boolean
    Function Registrar(username As String, password As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta As String, respuesta As String) As Logica.Usuario

End Interface

Public Interface ILugarRepositorio
    Function AllLugares() As List(Of Logica.Lugar)
End Interface

Public MustInherit Class VehiculoRepo
    Public MustOverride Function VehiculoPorVIN(VIN As String) As Logica.Vehiculo

    Public MustOverride Function Sincronizar() As Boolean
    Public MustOverride Function ExisteVIN(vin As String)

    Public MustOverride ReadOnly Property Vehiculos As List(Of Logica.Vehiculo)

    Public Function IngresarVehiculo(VIN As String, Marca As String, Modelo As String, Año As Integer, Color As Color, Cliente As String, Tipo As Logica.TipoVehiculo, PuertoLlegada As Logica.Lugar)
        If PuertoLlegada.Tipo <> Logica.TipoLugar.Puerto Then
            Throw New InvalidOperationException("Sólo se pueden añadir vehículos en el puerto")
        End If
        If ExisteVIN(VIN) Then
            Throw New InvalidOperationException("El vehículo con ese VIN ya existe en el sistema")
        End If
        Dim v = New Logica.Vehiculo(VIN, Marca, Modelo, Año, Color, Tipo, False, Cliente, )
    End Function
End Class