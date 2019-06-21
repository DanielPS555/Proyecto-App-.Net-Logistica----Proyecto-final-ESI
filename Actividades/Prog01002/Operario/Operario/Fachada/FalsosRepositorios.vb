Imports Operario
Imports Operario.Logica

Public Class FLugarRepo
    Implements ILugarRepositorio
    Private lugares As New List(Of Lugar)
    Public Function AllLugares(Optional patron As String = "%") As List(Of Lugar) Implements ILugarRepositorio.AllLugares
        If patron = "%" Then
            Return lugares
        End If

        Return New List(Of Lugar) From {
            LugarPorNombre(patron)
        }
    End Function

    Public Function LugarPorNombre(nombre As String) As Lugar Implements ILugarRepositorio.LugarPorNombre
        Return lugares.Where(Function(x) x.Nombre = nombre).SingleOrDefault
    End Function

    Public Function LugarPorID(id As Integer) As Lugar Implements ILugarRepositorio.LugarPorID
        Return lugares.Where(Function(x) x.ID = id).SingleOrDefault
    End Function

    Public Function TipoLugar(selectedItem As String) As String Implements ILugarRepositorio.TipoLugar
        Throw New NotImplementedException()
    End Function

    Public Function CapacidadZonas(lugar As String) As DataTable Implements ILugarRepositorio.CapacidadZonas
        Throw New NotImplementedException()
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

    Public Overrides Function VehiculoIncompleto(VIN As String) As Vehiculo
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
        Return _vehiculos.Where(Function(x) x.LugarActual.Nombre = Lugar)
    End Function

    Public Overrides Function InformesVehiculo(VIN As String) As Vehiculo
        Return VehiculoIncompleto(VIN)
    End Function

    Public Overrides Function Marca(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Modelo(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Año(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Cliente(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Tipo(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Color(vin As String) As Color
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Lugar(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Zona(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Subzona(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Posicion(vin As String) As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Lote(vin As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function TipoInforme(informe As Integer) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function DescripcionInforme(informe As Integer) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function VINInforme(informe As Integer) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Inspecciones(vin As String) As DataTable
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Registros(vin As String, inspeccion As Integer) As Tuple(Of DataTable, String, Integer, Date, String, Integer)
        Throw New NotImplementedException()
    End Function

    Public Overrides Function PosicionesEn(vin As String, conectadoEn As String) As DataTable
        Throw New NotImplementedException()
    End Function
End Class

Public Class FUsuarioRepo
    Implements IUsuarioRepositorio

    Public usuarios As New List(Of Usuario)

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
        Return usuarioConectado?.Desconectar
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

    Public Function UsuarioIncompletoPorID(id As Integer) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorID
        Return UsuarioPorID(id)
    End Function

    Public Function UsuarioIncompletoPorNombre(nombre As String) As Usuario Implements IUsuarioRepositorio.UsuarioIncompletoPorNombre
        Return UsuarioPorNombre(nombre)
    End Function

    Public Function ListaVehiculos(dt As DataTable) As DataTable Implements IUsuarioRepositorio.ListaVehiculos
        If usuarioConectado Is Nothing Then
            Throw New InvalidOperationException("No está conectado")
        End If
        usuarioConectado.ConectadoEn.Subzonas.Select(Function(x) x.Posicionados).UnionListas.ForEach(
            Sub(posicionado As Posicionado)
                Dim dr = dt.NewRow
                dt.ImportRow(dr)
                dr("Estado") = [Enum].GetName(GetType(EstadoVehiculo), posicionado.Vehiculo.Estado)
                dr("VIN") = posicionado.Vehiculo.VIN
                dr("Marca") = posicionado.Vehiculo.Marca
                dr("Modelo") = posicionado.Vehiculo.Modelo
                dr("VehiculoTipo") = [Enum].GetName(GetType(TipoVehiculo), posicionado.Vehiculo.Tipo)
            End Sub
            )
        Return dt
    End Function

    Public Function ConectadoEn() As String Implements IUsuarioRepositorio.ConectadoEn
        Return usuarioConectado?.ConectadoEn?.Nombre
    End Function

    Public Function AltaVehiculo(VIN As String, marca As String, modelo As String, año As Integer, zona As String, subzona As String, posicion As Integer, color As Color) As Boolean Implements IUsuarioRepositorio.AltaVehiculo
        Dim ret = VRepo.VehiculoIncompleto(VIN)?.Alta(marca, modelo, año, color, usuarioConectado)
        If ret Is Nothing Then
            Return False
        Else
            Return ret
        End If
    End Function
End Class