Public Class TipoMedioTrasporte

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nom As String
    Public Property Nombre() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(iD As Integer, nombre As String)
        Me.ID = iD
        Me.Nombre = nombre
    End Sub
End Class
