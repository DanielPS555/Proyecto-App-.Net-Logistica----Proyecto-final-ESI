Namespace Logica
    Public Class Subzona
        Public ReadOnly _posicionados As List(Of Posicionado)
        Public ReadOnly Padre As Zona
        Public ReadOnly Nombre As String
        Public ReadOnly ID As Integer
        Public ReadOnly Capacidad As Integer

        Public ReadOnly Property Posicionados As List(Of Posicionado)
            Get
                Return _posicionados.Where(Function(x) x.Hasta Is Nothing).ToList
            End Get
        End Property

        Public Sub New(padre As Zona, posicionados As List(Of Posicionado), nombre As String, id As Integer, capacidad As Integer)
            Me.Padre = padre
            _posicionados = posicionados
            Me.Nombre = nombre
            Me.Capacidad = capacidad
            Me.ID = id
        End Sub

        Protected Friend Function Posicionar(v As Vehiculo, Posicion As Integer) As Boolean
            If _posicionados.Where(Function(x) x.Posicion = Posicion And x.Hasta Is Nothing).Count <> 0 Then
                Return False
            End If
            If _posicionados.Where(Function(x) x.Vehiculo Is v And x.Hasta Is Nothing).Count <> 0 Then
                Return False
            End If
            _posicionados.Add(New Posicionado(v, Me, Posicion, Date.Now, Nothing))
            Return True
        End Function
    End Class

    Public Class Posicionado
        Public ReadOnly Vehiculo As Vehiculo
        Public ReadOnly Subzona As Subzona
        Public ReadOnly Posicion As Integer
        Public ReadOnly Desde As Date
        Public Hasta As Date?

        Public Sub New(dt As DataRow, enSub As Subzona)
            Me.New(VRepo.VehiculoIncompleto(dt("VIN")),
                   enSub, dt("posicion"), dt("desde"), AutoNull(Of DateTime?)(dt("hasta")))
        End Sub

        Public Sub New(vehiculo As Vehiculo, subzona As Subzona, posicion As Integer, desde As Date, hasta As Date?)
            Me.Vehiculo = vehiculo
            Me.Subzona = subzona
            Me.Posicion = posicion
            Me.Desde = desde
            Me.Hasta = hasta
        End Sub
    End Class
End Namespace