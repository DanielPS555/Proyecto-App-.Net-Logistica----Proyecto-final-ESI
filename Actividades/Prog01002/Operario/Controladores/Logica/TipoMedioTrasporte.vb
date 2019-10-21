Imports Controladores

Public Class TipoMedioTransporte

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _nom
    End Function

    Private _nom As String
    Public Property Nombre() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub

    Public Sub New(iD As Integer, nombre As String)
        Me.ID = iD
        Me.Nombre = nombre
    End Sub
    Public Sub New(nombre As String, iD As Integer)
        Me.Nombre = nombre
        Me.ID = iD
    End Sub
    Private Shared Medios As TipoMedioTransporte() = {New TipoMedioTransporte("Camión", 1), New TipoMedioTransporte("Maritimo", 2), New TipoMedioTransporte("Trenvía", 3)}
    Public Shared Function ByName(tipo As String) As TipoMedioTransporte
        Return Medios.Where(Function(x) x.Nombre = tipo).SingleOrDefault
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim transporte = TryCast(obj, TipoMedioTransporte)
        Return transporte IsNot Nothing AndAlso
               ID = transporte.ID
    End Function
End Class
