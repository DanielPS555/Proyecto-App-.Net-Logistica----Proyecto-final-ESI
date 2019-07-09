Imports Controladores

Public Class Trasporte

    Enum Estados
        Proseso
        Fallo
        Existoso
    End Enum

    Public Sub New(iD As Integer, fechaLLegadaEstimada As Date, fechaLLegadaReal As Date, estado As String, trass As Usuario)
        Me.ID = iD
        Me.FechaLLegadaEstimada = fechaLLegadaEstimada
        Me.FechaLLegadaReal = fechaLLegadaReal
        Me.Estado = estado
        Me.Lotes = New List(Of Lote)
        Me.Trasportista = trass
    End Sub

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)

            If value >= 0 Then
                _id = value
            Else
                Throw New Exception("El id no puede ser negativo")
            End If
        End Set
    End Property

    Private _fechaLlegadaE As DateTime
    Public Property FechaLLegadaEstimada() As DateTime
        Get
            Return _fechaLlegadaE
        End Get
        Set(ByVal value As DateTime)
            _fechaLlegadaE = value
        End Set
    End Property

    Private _fechaLlegadaR As DateTime
    Public Property FechaLLegadaReal() As DateTime
        Get
            Return _fechaLlegadaR
        End Get
        Set(ByVal value As DateTime)
            _fechaLlegadaR = value
        End Set
    End Property

    Private _estado As String
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            If value = Me.Estados.Existoso Or Me.Estados.Proseso Or Me.Estados.Fallo Then
                _estado = value
            Else
                Throw New Exception("Valor de estado incorrecto")
            End If

        End Set
    End Property

    Private _lotes As List(Of Lote)
    Public Property Lotes() As List(Of Lote)
        Get
            Return _lotes
        End Get
        Set(ByVal value As List(Of Lote))
            _lotes = value
        End Set
    End Property

    Private _trasportista As Usuario
    Public Property Trasportista() As Usuario
        Get
            Return _trasportista
        End Get
        Set(ByVal value As Usuario)
            If value.Rol = value.Roles.Transportista Then
                _trasportista = value
            Else
                Throw New Exception("El usuario debe ser trasportista")
            End If

        End Set
    End Property
End Class
