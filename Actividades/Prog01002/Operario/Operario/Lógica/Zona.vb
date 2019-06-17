Namespace Logica
    Public Class Zona
        Private _subzonas As List(Of Subzona)
        Public ReadOnly Padre As Lugar
        Public ReadOnly Property Subzonas As List(Of Subzona)
            Get
                Return _subzonas
            End Get
        End Property
    End Class
End Namespace