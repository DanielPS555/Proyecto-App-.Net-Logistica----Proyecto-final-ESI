Imports Operario.Logica

Public Interface IUsuarioRepositorio
    Function UsuarioIncompletoPorID(id As Integer) As Logica.Usuario 'Devuelve el usuario, pero si no ha sido buscado antes no busca sus lugares de trabajo. Se usa para llenar los lugares antes de hacer búsqueda completa de usuarios
    Function UsuarioPorID(id As Integer) As Logica.Usuario 'Devuelve el usuario si existe
    Function UsuarioPorNombre(nombre As String) As Logica.Usuario 'Idem
    Function Sincronizar() As Boolean 'Sincroniza entre el estado local y el estado en el servidor

    Function Login(username As String, password As String) As Logica.Usuario
    Function Restablecer(username As String, respuesta As String, newpass As String) As Boolean
    Function Pregunta(username As String) As String
    Function LugaresTrabaja() As List(Of String)
    Function UltimaConexionEn(lugar As String) As Date?

    Function AltaVehiculo(VIN As String, marca As String, modelo As String, año As Integer, zona As String, subzona As String, posicion As Integer, color As Color, loteInicial As String) As Boolean
    Sub CompletarUsuario(usuario As Usuario)
    Function ConectarEn(lugar As String) As Boolean
    Function Desconectar() As Boolean
    Function ConectadoEn() As String

    Function NombreCompleto() As String
    Function NombreDeUsuario() As String
    Function RolDeUsuario() As String

    Function ListaVehiculos(dt As DataTable, patron As Predicate(Of DataRow)) As DataTable

    Function AccesosAlSistema() As Integer

    Function UltimoAcceso() As Date?
    Function UsuarioIncompletoPorNombre(nombre As String) As Usuario
    Function CreadorDe(vin As String) As Boolean
    Function NewLote(id As Integer, nombre As String, hacia As String, prioridad As String) As String
End Interface

Public Module RepoUtils
    <System.Runtime.CompilerServices.Extension>
    Function ZonasEnLugar([this] As ILugarRepositorio, lugar As String) As List(Of String)
        Return this.LugarPorNombre(lugar)?.Zonas.Select(Function(x) x.Nombre).ToList
    End Function

    <System.Runtime.CompilerServices.Extension>
    Function SubzonasEnLugar([this] As ILugarRepositorio, zona As String, lugar As String) As List(Of String)
        Dim _lugar = this.LugarPorNombre(lugar)
        Dim _subzonas = _lugar?.Subzonas.Where(Function(x)
                                                   Return x.Padre.Nombre = zona
                                               End Function)
        Return _subzonas.Select(Function(x) x.Nombre).ToList
    End Function

    <System.Runtime.CompilerServices.Extension>
    Function CapacidadSubzona([this] As ILugarRepositorio, subzona As String, zona As String, lugar As String) As Integer
        Dim _lugar = this.LugarPorNombre(lugar)
        Dim _zona = _lugar?.Zonas.Where(Function(x) x.Nombre = zona).SingleOrDefault
        Dim _subzona = _zona?.Subzonas.Where(Function(x) x.Nombre = subzona).SingleOrDefault
        Return _subzona?.Capacidad
    End Function

    <System.Runtime.CompilerServices.Extension>
    Function LotesEnLugar([this] As ILugarRepositorio, lugar As String) As List(Of String)
        Return this.LugarPorNombre(lugar)?.LotesPorPartir.Select(Function(x) x.ID.ToString).ToList
    End Function
End Module

Public Interface ILugarRepositorio
    Function AllLugares(Optional patron As String = "%") As List(Of Logica.Lugar)
    Function LugarPorNombre(nombre As String) As Logica.Lugar
    Function LugarPorID(id As Integer) As Logica.Lugar
    Function LotesEnLugar(lugar As String) As List(Of String)
    Function TipoLugar(selectedItem As String) As String
    Function CapacidadZonas(lugar As String) As DataTable
    Function PosicionOcupada(subzona As String, zona As String, nombre As String, posicion As Integer) As Boolean
    Function OcupacionSubzona(subzona As String, zona As String, lugar As String) As Integer
    Function Nombre(id As Integer) As String
    Function VehiculosEnLote(value As Integer) As DataTable
    Function NewLote(numeroLote As UInteger, nombre As String, conectadoEn As Lugar, destino As Lugar, usuario As Usuario, estado As EstadoLote, prioridad As PrioridadLote) As Lote
    Function CapacidadZona(zona As String, lugar As String) As Integer
    Function OcupacionZona(zona As String, lugar As String) As Integer
    Function VehiculosEnSubzona(y As String, x As String, conectadoEn As String) As List(Of String)
    Function LoteAbierto(Lote As String) As Boolean
End Interface

Public Module Constantes
    Public URepo As IUsuarioRepositorio = Nothing
    Public LRepo As ILugarRepositorio = Nothing
    Public VRepo As VehiculoRepo = Nothing
End Module

Public MustInherit Class VehiculoRepo
    Public MustOverride Function VehiculoIncompleto(VIN As String) As Logica.Vehiculo
    Public MustOverride Function VehiculoIncompleto(VIN As String, patron As Predicate(Of DataRow)) As Logica.Vehiculo
    Public MustOverride Sub IngresosVehiculo(V As Logica.Vehiculo)
    Public MustOverride Function InformesVehiculo(VIN As String) As Logica.Vehiculo

    Public MustOverride Function Sincronizar() As Boolean
    Public MustOverride Function ExisteVIN(vin As String) As Boolean

    Public MustOverride Function Marca(vin As String) As String
    Public MustOverride Function Marca(vin As String, nuevaMarca As String) As Boolean
    Public MustOverride Function Modelo(vin As String) As String
    Public MustOverride Function Modelo(vin As String, nuevoModelo As String) As Boolean
    Public MustOverride Function Año(vin As String) As String
    Public MustOverride Function Año(vin As String, nuevoAño As String) As Boolean
    Public MustOverride Function Cliente(vin As String) As String
    Public MustOverride Function Cliente(vin As String, nuevoCliente As String) As String
    Public MustOverride Function Tipo(vin As String) As String
    Public MustOverride Function Tipo(vin As String, nuevoTipo As String) As String
    Public MustOverride Function Color(vin As String) As Color
    Public MustOverride Function Lugar(vin As String) As String
    Public MustOverride Function AutoComplete(start As String) As List(Of String)
    Public MustOverride Function Zona(vin As String) As String
    Public MustOverride Function Subzona(vin As String) As String
    Public MustOverride Function Posicion(vin As String) As Integer
    Public MustOverride Function Posicion(vin As String, zona As String, subzona As String, lugar As String, nuevaPosicion As Integer) As Boolean
    Public MustOverride Function Lote(vin As String) As String
    Public MustOverride Function Lote(vin As String, nuevolote As String) As Boolean

    Public MustOverride ReadOnly Property Vehiculos As List(Of Logica.Vehiculo)

    Public MustOverride Function VehiculosEn(Lugar As String) As List(Of Logica.Vehiculo)

    Public Function IngresarVehiculo(VIN As String, Marca As String, Modelo As String, Año As Integer, Color As Color, Cliente As String, Tipo As Logica.TipoVehiculo, PuertoLlegada As Logica.Lugar) As Logica.Vehiculo
        If PuertoLlegada.Tipo <> Logica.TipoLugar.Puerto Then
            Throw New InvalidOperationException("Sólo se pueden añadir vehículos en el puerto")
        End If
        If ExisteVIN(VIN) Then
            Throw New InvalidOperationException("El vehículo con ese VIN ya existe en el sistema")
        End If
        Dim v = New Logica.Vehiculo(VIN, Marca, Modelo, Año, Color, Tipo, False, Cliente, PuertoLlegada.ID, Nothing, New List(Of Logica.InformeDaños))
        Vehiculos.Add(v)
        Return v
    End Function

    Public MustOverride Function Inspecciones(vin As String) As DataTable
    Public MustOverride Function Registros(vin As String, inspeccion As Integer) As Tuple(Of DataTable, String, Integer, Date, String, Integer)
    Public MustOverride Function Imagenes(inspeccion As Integer, registro As Integer) As DataTable
    Public MustOverride Function PosicionesEn(vin As String, conectadoEn As String) As DataTable

    Public MustOverride Function TipoInforme(informe As Integer) As String
    Public MustOverride Function DescripcionInforme(informe As Integer) As String
    Public MustOverride Function VINInforme(informe As Integer) As String
    Friend MustOverride Function PosicionadoDesde(vin As String) As DateTime
    Friend MustOverride Function PuertoLlegada(vin As String) As String
    Friend MustOverride Function FechaLlegada(vin As String) As String
    Friend MustOverride Function NewReg(enInforme As Integer) As Integer
    Friend MustOverride Function NewInforme(desc As String, tipo As String, vin As String) As Integer
    Friend MustOverride Function UpdateInformeDesc(id As Integer, newDesc As String) As Boolean
    Friend MustOverride Function UpdateInformeTipo(id As Integer, newTipo As String) As Boolean
    Friend MustOverride Function UpdateInformeReg(id As Integer, reg As Integer, newDesc As String) As Boolean
    Friend Shared Function RegistroTable() As DataTable()
        Dim rdt As New DataTable("Registros")
        rdt.Columns.Add("ID", GetType(Integer))
        rdt.Columns.Add("Descripcion", GetType(String))
        Dim idt As New DataTable("Imagenes")
        idt.Columns.Add("ID", GetType(Integer))
        idt.Columns.Add("Imagen", GetType(Bitmap))
        Return {rdt, idt}
    End Function

    Friend MustOverride Sub Lugares(dtlugares As DataTable, vin As String)
    Friend MustOverride Sub UpdateInformeImg(eninforme As Integer, enregistro As Integer, images As List(Of Bitmap))
End Class