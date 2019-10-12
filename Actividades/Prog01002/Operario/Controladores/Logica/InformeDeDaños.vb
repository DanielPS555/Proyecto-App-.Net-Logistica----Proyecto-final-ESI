Imports Controladores

Public Class InformeDeDaños

    Public Shared ReadOnly TIPO_INFORME_TOTAL As String = "Total"
    Public Shared ReadOnly TIPO_INFORME_PARCIAL As String = "Parcial"

    Public Shared ReadOnly Property TIPOS_INFORMES() As String()
        Get
            Return {TIPO_INFORME_TOTAL, TIPO_INFORME_PARCIAL}
        End Get
    End Property

    Private _vehiculo As Vehiculo
    Public Property VehiculoPadre() As Vehiculo
        Get
            Return _vehiculo
        End Get
        Set(ByVal value As Vehiculo)
            _vehiculo = value
        End Set
    End Property

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

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _lugar As Lugar
    Public Property Lugar() As Lugar
        Get
            Return _lugar
        End Get
        Set(ByVal value As Lugar)
            _lugar = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            If TIPOS_INFORMES.Contains(value) Then
                _tipo = value
            Else
                Throw New Exception("El tipo de informe es invalido, revise el enum TipoDeInforme")
            End If

        End Set
    End Property

    Private _registros As List(Of RegistroDaños)
    Public Property Registros() As List(Of RegistroDaños)
        Get
            Return _registros
        End Get
        Set(ByVal value As List(Of RegistroDaños))
            _registros = value
        End Set
    End Property

    Private _creador As Usuario
    Public Property Creador() As Usuario
        Get
            Return _creador
        End Get
        Set(ByVal value As Usuario)
            _creador = value
        End Set
    End Property

    Public Sub New(iD As Integer, descripcion As String, fecha As Date, tipo As String, lug As Lugar, vehi As Vehiculo, padre As Vehiculo, creador As Usuario)
        Me.ID = iD
        Me.Descripcion = descripcion
        Me.Fecha = fecha
        Me.Tipo = tipo
        Me.Registros = New List(Of RegistroDaños)
        Me.Lugar = lug
        Me.VehiculoPadre = vehi
        Me.Creador = creador
    End Sub

    Public Sub New(vehi As Vehiculo)
        Me.VehiculoPadre = vehi
        Me.Registros = New List(Of RegistroDaños)
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim daños = TryCast(obj, InformeDeDaños)
        Return daños IsNot Nothing AndAlso
               ID = daños.ID
    End Function

    Public Overrides Function ToString() As String
        Return $"Id Informe: {ID}"
    End Function
End Class
