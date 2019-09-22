

Public Class TrabajaEn

    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            If value.Rol = Usuario.TIPO_ROL_OPERARIO Then
                _usuario = value
            Else
                Throw New Exception("Tipo de usuario incorrecto")
            End If

        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.Lugar.Nombre
    End Function

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

    Private _fechaI As DateTime
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaI
        End Get
        Set(ByVal value As DateTime)
            _fechaI = value
        End Set
    End Property

    Private _fechaF As DateTime?
    Public Property FechaFinalizacion() As DateTime?
        Get
            Return _fechaF
        End Get
        Set(ByVal value As DateTime?)
            If value IsNot Nothing And value <> DateTime.MinValue Then
                If DateTime.Compare(FechaInicio, value) <= 0 Then
                    _fechaF = value
                Else
                    Throw New Exception("La fecha de salida no puede ser menor a la de ingreso ")
                End If
            End If
        End Set
    End Property



    Public Sub New(id As Integer, usuario As Usuario, lugar As Lugar, fechaInicio As Date, fechaFinalizacion As Date?)
        Me.Usuario = usuario
        Me.Lugar = lugar
        Me.FechaInicio = fechaInicio
        Me.FechaFinalizacion = fechaFinalizacion
        Me.Conexiones = New List(Of Tuple(Of Date, Date?))
        Me.Id = id
    End Sub

    Public Sub New()
        Me.Conexiones = New List(Of Tuple(Of Date, Date?))
    End Sub

    Private _conex As List(Of Tuple(Of DateTime, DateTime?))
    Public Property Conexiones() As List(Of Tuple(Of DateTime, DateTime?))
        Get
            Return _conex
        End Get
        Set(ByVal value As List(Of Tuple(Of DateTime, DateTime?)))
            _conex = value
        End Set
    End Property

    Public Function ultimaConexcion() As Tuple(Of DateTime, DateTime?)
        Dim se As Integer = 0
        For i As Integer = 1 To Conexiones.Count - 1
            If Conexiones(se).Item1.CompareTo(Conexiones(i).Item1) < 0 Then
                se = i
            End If
        Next
        If Conexiones.Count = 0 Then
            Return Nothing
        Else
            Return Conexiones(se)
        End If

    End Function

End Class
