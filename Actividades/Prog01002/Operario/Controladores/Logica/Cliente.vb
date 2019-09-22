Public Class Cliente
    Private _IDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return _IDCliente
        End Get
        Set(ByVal value As Integer)
            If value >= 0 Then
                _IDCliente = value
            Else
                Throw New Exception("NO SE PERMITEN ID NEGATIVOS")
            End If

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

    Private _rut As String
    Public Property RUT() As String
        Get
            Return _rut
        End Get
        Set(ByVal value As String)
            If value.Length = 12 Then
                Dim j As Boolean = True
                For Each i As Char In value
                    If Not Char.IsNumber(i) Then
                        j = False
                        Exit For
                    End If
                Next
                If j Then
                    _rut = value
                Else
                    Throw New Exception("El RUT debe ser puramente numerico")
                End If
            Else
                Throw New Exception("El RUT esta compuesto de 12 Dijitos")
            End If

        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Private _fechaRegistro As DateTime
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property

    Private _lugares As List(Of Lugar)
    Public Property Lugares() As List(Of Lugar)
        Get
            Return _lugares
        End Get
        Set(ByVal value As List(Of Lugar))
            _lugares = value
        End Set
    End Property

    Public Sub New(iDCliente As Integer, rUT As String, nombre As String, fechaRegistro As Date)
        Me.IDCliente = iDCliente
        Me.RUT = rUT
        Me.Nombre = nombre
        Me.FechaRegistro = fechaRegistro
        Me.Lugares = New List(Of Lugar)
    End Sub

    Public Sub New()
        Me.Lugares = New List(Of Lugar)
    End Sub

    Public Overrides Function ToString() As String
        Return "Nom: " & Me.Nombre & " RUT: " & Me.RUT
    End Function
End Class
