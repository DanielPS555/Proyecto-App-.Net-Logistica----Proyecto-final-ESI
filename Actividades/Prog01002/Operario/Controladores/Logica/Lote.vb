Imports Controladores

Public Class Lote

    Enum Prioridades
        Alta
        Normal
    End Enum

    Public Sub New(id As Integer, prio As String, ori As Lugar, des As Lugar)
        Me.IDLote = id
        Me.Prioridad = prio
        Me.Origen = ori
        Me.Destino = des

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim lote = TryCast(obj, Lote)
        Return lote IsNot Nothing AndAlso
               IDLote = lote.IDLote
    End Function

    Private _idLote As Integer
    Public Property IDLote() As Integer
        Get
            Return _idLote
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _idLote = value
            Else
                Throw New Exception("LA ID NO PUEDE SER NEGATIVA")
            End If

        End Set
    End Property

    Private _proridad As String
    Public Property Prioridad() As String
        Get
            Return _proridad
        End Get
        Set(ByVal value As String)
            If value = Me.Prioridades.Alta Or value = Me.Prioridades.Normal Then
                _proridad = value
            Else
                Throw New Exception("Las proridades son Alta o Normal, use las constantes estaticas ")
            End If

        End Set
    End Property

    Private _vehiculo As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo))
    Public Property Vehiculos() As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo))
        Get
            Return _vehiculo
        End Get
        Set(ByVal value As List(Of Tuple(Of Tuple(Of DateTime, Usuario), Vehiculo)))
            _vehiculo = value
        End Set
    End Property

    Private _origen As Lugar
    Public Property Origen() As Lugar
        Get
            Return _origen
        End Get
        Set(ByVal value As Lugar)
            _origen = value
        End Set
    End Property

    Private _destino As Lugar
    Public Property Destino() As Lugar
        Get
            Return _destino
        End Get
        Set(ByVal value As Lugar)
            _destino = value
        End Set
    End Property

End Class
