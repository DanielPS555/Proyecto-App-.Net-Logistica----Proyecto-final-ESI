
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

        Public Sub New(vehiculo As Vehiculo, usuario As Usuario, tipo As TipoIngreso, fecha As Date)
            Me.Vehiculo = vehiculo
            Me.Usuario = usuario
            Me.Tipo = tipo
            Me.Fecha = fecha
        End Sub
    End Class
    Public Class Vehiculo
        Private ReadOnly _puertoArriba As Integer
        Public ReadOnly VIN As String
        Public Marca As String
        Public Modelo As String
        Public Año? As Integer
        Public Color As Color
        Public ReadOnly Tipo As TipoVehiculo
        Public ReadOnly FueraDeSistema As Boolean
        Public ReadOnly ClienteNombre As String
        Public ReadOnly Property PuertoArriba As Lugar
            Get
                Return LRepo.LugarPorID(_puertoArriba)
            End Get
        End Property
        Public ReadOnly FechaArribo As DateTime?
        Public ReadOnly Ingresos As List(Of Ingresos)

        Public ReadOnly Property PosicionActual As Posicionado
            Get
                Try
                    Dim allz = LRepo.AllLugares.Select(Function(x) x.Zonas).UnionListas
                    Dim alls = allz.Select(Function(x) x.Subzonas).UnionListas
                    Dim allp = alls.Select(Function(x) x.Posicionados).UnionListas
                    Return allp.Where(Function(x) x.Vehiculo.VIN = Me.VIN AndAlso x.Hasta Is Nothing).Single
                Catch ex As InvalidOperationException
                    Return Nothing
                End Try
            End Get
        End Property

        Public Shared ReadOnly DateOrder As Comparison(Of Lote) = Function(x, y) x.FechaPartida?.CompareTo(y.FechaPartida)

        Public ReadOnly Property LugarActual As Lugar
            Get
                Dim lotes = LRepo.AllLugares.Select(Function(x) x.LotesCreados).UnionListas.Where(Function(x) x.Estado = EstadoLote.Transportado And x.Integrantes.Contains(Me)).ToList
                If lotes.Count = 0 Then
                    Return PuertoArriba
                End If
                lotes.Sort(DateOrder)
                Return lotes.Last.Hacia
            End Get
        End Property

        Public ReadOnly Property Estado As EstadoVehiculo
            Get
                Dim dateComparison As Comparison(Of Lote) = Function(x, y) x.FechaPartida?.CompareTo(y.FechaPartida)
                Dim lotes = LRepo.AllLugares.Select(Function(x) x.LotesCreados).UnionListas.Where(Function(x) x.Integrantes.Contains(Me)).ToList
                If lotes.Count = 0 Then
                    Return Informes.Count > 0
                End If
                lotes.Sort(dateComparison)
                Select Case (Informes.Select(Function(x) x.Fecha).Where(Function(x) x > lotes.Last.FechaPartida).Count > 0)
                    Case True
                        Return EstadoVehiculo.Listo
                    Case Else
                        Return EstadoVehiculo.Esperando
                End Select
            End Get
        End Property
        Public ReadOnly Informes As List(Of InformeDaños)
        Public Function Alta(marca As String, modelo As String, año As Integer, color As Color, usuario As Usuario) As Boolean
            If Ingresos.Where(Function(x) x.Tipo = TipoIngreso.Alta).Count > 0 Then
                Return False
            End If
            Me.Marca = marca
            Me.Modelo = modelo
            Me.Año = año
            Me.Color = color
            Ingresos.Add(New Logica.Ingresos(Me, usuario, TipoIngreso.Alta, Date.Now))
            Return True
        End Function

        Public Sub New(vIN As String, marca As String, modelo As String, año As Integer, color As Color, tipo As TipoVehiculo, fueraDeSistema As Boolean, clienteNombre As String, PuertoArriba As Integer, fechaArribo As Date?, informes As List(Of InformeDaños))
            Me.VIN = vIN
            Me.Marca = marca
            Me.Modelo = modelo
            Me.Año = año
            Me.Color = color
            Me.Tipo = tipo
            Me.FueraDeSistema = fueraDeSistema
            Me.ClienteNombre = clienteNombre
            Me._puertoArriba = PuertoArriba
            Me.FechaArribo = fechaArribo
            Me.Informes = informes
        End Sub

        Public Sub New(dataRow As DataRow)
            Me.New(dataRow("VIN"), dataRow("Marca"), dataRow("Modelo"), dataRow("anio"), Color.FromArgb(Integer.Parse(dataRow("Color"), Globalization.NumberStyles.HexNumber)), TipoFromString(dataRow("Tipo")), False, dataRow("ClienteNombre"), dataRow("PuertoArriba"), dataRow("FechaArribo"), New List(Of InformeDaños))
        End Sub
    End Class
    Public Enum EstadoVehiculo
        Esperando
        Listo
    End Enum
End Namespace
