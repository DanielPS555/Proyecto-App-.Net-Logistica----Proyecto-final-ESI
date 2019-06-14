Namespace Logica
    ' Funcionamiento a desarrollar:
    ' Clases "repositorio" desde donde se cargan y donde se guardan las entidades
    ' los "repositorios" tendrán métodos de actualización que guardarán los cambios
    Public Class Lugar
        Private _nombre As String
        Private _capacidad As UInteger
        Private _posicion As PointF
        Private _creador As Usuario
        Private _tipo As String
        Private _zonas As List(Of Zona)
    End Class

    Public Class Zona
        Private _subzonas As List(Of Subzona)
    End Class
    Public Class Subzona
    End Class

    Public Class Lote
        Private _id As UInteger
        Private _fecha_partida As Date
        Private _desde As Lugar
        Private _hacia As Lugar
        Private _creador As Usuario
        Private _prioridad As String
        Private _integrantes As List(Of Vehiculo)
    End Class

    Public Class Vehiculo
        Private _vin As String
        Private _marca As String
        Private _modelo As String
        Private _año As Integer
        Private _color As Color
        Private _tipo As String
        Private _fueradesistema As Boolean
        Private _clientenombre As String
        Private _puertoarriba As Lugar
        Private _fechaarribo As Date
        Private _posicionactual As Tuple(Of Subzona, Date, Date, UInteger)

        Private _informes As List(Of InformeDaños)
    End Class

    Public Class InformeDaños
        Private _descripcion As String
        Private _fecha As Date
        Private _tipo As String
        Private _registros As List(Of RegistroDaños)
    End Class

    Public Class RegistroDaños
        Private _descripcion As String
        Private _numeroenlista As UInteger
        Private _actualiza As RegistroDaños
    End Class

    Public Class Usuario
        Private _trabajaen As List(Of Tuple(Of Lugar, Date, Date))

        Private ReadOnly Property TrabajaEn As IReadOnlyList(Of Tuple(Of Lugar, Date, Date))
            Get
                Return _trabajaen
            End Get
        End Property

        Private _username As String
        Public ReadOnly Property UserName As String
            Get
                Return _username
            End Get
        End Property

        Private _password_hash As String
        Public Function VerificarContraseña(password As String) As Boolean
            Return True
        End Function

        Private _primer_nombre As String
        Public ReadOnly Property PrimerNombre As String
            Get
                Return _primer_nombre
            End Get
        End Property

        Private _segundo_nombre As String
        Public ReadOnly Property SegundoNombre As String
            Get
                Return _segundo_nombre
            End Get
        End Property

        Private _primer_apellido As String
        Public ReadOnly Property PrimerApellido As String
            Get
                Return _primer_apellido
            End Get
        End Property

        Private _segundo_apellido As String
        Public ReadOnly Property SegundoApellido As String
            Get
                Return _segundo_apellido
            End Get
        End Property

        Private _pregunta_secreta As String

        Public ReadOnly Property PreguntaSecreta As String
            Get
                Return _pregunta_secreta
            End Get
        End Property

        Public Function VerificarPregunta(pregunta As String) As Boolean
            Return True
        End Function

        Private _fecha_nacimiento As Date
        Public ReadOnly Property FechaNacimiento As Date
            Get
                Return _fecha_nacimiento
            End Get
        End Property

        Private _sexo As Char
        Public ReadOnly Property Sexo As Char
            Get
                Return _sexo
            End Get
        End Property

        Private _email As String
        Public ReadOnly Property Email As String
            Get
                Return _email
            End Get
        End Property

        Private _telefono As String
        Public ReadOnly Property Telefono As String
            Get
                Return _telefono
            End Get
        End Property

        Private _rol As Role
        Public ReadOnly Property Rol As Role
            Get
                Return _rol
            End Get
        End Property

        Public Sub New(trabajaen As List(Of Lugar), username As String, password_hash As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta_secreta As String, fecha_nacimiento As Date, sexo As Char, email As String, telefono As String, rol As Role)
            _trabajaen = trabajaen
            _username = username
            _password_hash = password_hash
            _primer_nombre = primer_nombre
            _segundo_nombre = segundo_nombre
            _primer_apellido = primer_apellido
            _segundo_apellido = segundo_apellido
            _pregunta_secreta = pregunta_secreta
            _fecha_nacimiento = fecha_nacimiento
            _sexo = sexo
            _email = email
            _telefono = telefono
            _rol = rol
        End Sub
    End Class
    Public Class Role
        Public ReadOnly Nombre As String
        Protected Friend Sub New(Nombre As String)
            Me.Nombre = Nombre
        End Sub
    End Class
    Public Module Constantes
        Public Roles() As Role = {New Role("Operario")}
    End Module
End Namespace