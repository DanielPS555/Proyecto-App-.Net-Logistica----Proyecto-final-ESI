Namespace Logica
    Public Class Zona
        Private _subzonas As List(Of Subzona)
        Public ReadOnly Padre As Lugar
        Public ReadOnly Nombre As String
        Public ReadOnly Capacidad As Integer
        Public ReadOnly ID As Integer
        Public ReadOnly Property Ocupacion As Integer
            Get
                Return _subzonas.Select(Function(x) x.Posicionados.Count).Sum
            End Get
        End Property
        Public ReadOnly Property Subzonas As List(Of Subzona)
            Get
                Return _subzonas
            End Get
        End Property

        Public Sub New(dt As DataRow, padre As Lugar)
            Me.New(New List(Of Subzona), padre, dt("Nombre"), dt("IDZona"), dt("Capacidad"))
        End Sub

        Public Sub New(subzonas As List(Of Subzona), padre As Lugar, nombre As String, id As Integer, capacidad As Integer)
            _subzonas = subzonas
            Me.Padre = padre
            Me.Nombre = nombre
            Me.ID = id
            Me.Capacidad = capacidad
        End Sub
    End Class
End Namespace