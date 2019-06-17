Namespace Logica
    Public Enum TipoVehiculo
        Auto
        Camioneta
        MiniVan
        SUV
    End Enum
    Public Enum TipoIngreso
        Precarga
        Alta
        Baja
    End Enum
    Public Class Ingresos
        Public ReadOnly Vehiculo As Vehiculo
        Public ReadOnly Usuario As Usuario
        Public ReadOnly Tipo As TipoIngreso
        Public ReadOnly Fecha As Date
    End Class
    Public Class Vehiculo
        Public ReadOnly VIN As String

        Public ReadOnly Marca As String
        Public ReadOnly Modelo As String
        Public ReadOnly Año As Integer
        Public ReadOnly Color As Color
        Public ReadOnly Tipo As TipoVehiculo
        Public ReadOnly FueraDeSistema As Boolean
        Public ReadOnly ClienteNombre As String
        Public ReadOnly PuertoArriba As Lugar
        Public ReadOnly FechaArribo As DateTime?

        Public ReadOnly Informes As List(Of InformeDaños)
        Public Shared Function AñadirVehiculo(NuevoVehiculo As Vehiculo, LoteInicial As Lote, Subzona As Subzona, Posicion As Integer, Creador As Usuario) As Boolean
            If Not Constantes.VRepo.ExisteVIN(NuevoVehiculo.VIN) Then Return Nothing
            'If NuevoVehiculo Then

            If Subzona.Padre.Padre IsNot Creador.ConectadoEn Then
                Throw New InvalidOperationException("Intentando agregar vehículo en lugar donde no está conectado")
            End If
            Dim sz_serch = Constantes.LRepo.AllLugares.Select(Of List(Of Subzona))(Function(sz) sz.Subzonas)
            Dim p_search = Constantes.UnionListas(Of Subzona)(sz_serch).Select(Of List(Of Posicionado))(Function(x) x.Posicionados)
            If Constantes.UnionListas(Of Posicionado)(p_search).Where(Function(p) p.Vehiculo Is NuevoVehiculo AndAlso p.Hasta Is Nothing).Count <> 0 Then
                Throw New InvalidOperationException("El lugar ya está posicionado")
            End If
            Return Subzona.Posicionar(NuevoVehiculo, Posicion)
        End Function

        Public Sub New(vIN As String, marca As String, modelo As String, año As Integer, color As Color, tipo As TipoVehiculo, fueraDeSistema As Boolean, clienteNombre As String, puertoArriba As Lugar, fechaArribo As Date?, informes As List(Of InformeDaños))
            Me.VIN = vIN
            Me.Marca = marca
            Me.Modelo = modelo
            Me.Año = año
            Me.Color = color
            Me.Tipo = tipo
            Me.FueraDeSistema = fueraDeSistema
            Me.ClienteNombre = clienteNombre
            Me.PuertoArriba = puertoArriba
            Me.FechaArribo = fechaArribo
            Me.Informes = informes
        End Sub
    End Class
End Namespace