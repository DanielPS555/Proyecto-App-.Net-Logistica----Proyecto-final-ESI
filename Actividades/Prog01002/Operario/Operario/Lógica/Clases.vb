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
        Private _fecha_partida As DateTime
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
        Private _fechaarribo As DateTime?
        Private _posicionactual As Tuple(Of Subzona, DateTime, DateTime?, UInteger)

        Private _informes As List(Of InformeDaños)
    End Class

    Public Class InformeDaños
        Private _dirty As Boolean
        Public ReadOnly id As Integer
        Private _descripcion As String
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(value As String)
                Dim TimeDif As TimeSpan = (Date.Now - Fecha).Duration
                If TimeDif.TotalHours > 4 Then
                    Throw New InvalidOperationException($"Sólo puede modificar un informe 4 horas o menos antes de ser creado. Han pasado: {TimeDif.TotalHours:00}h:{TimeDif.Minutes:00}:{TimeDif.Seconds:00}")
                End If
                _descripcion = value
            End Set
        End Property
        Public ReadOnly Property Fecha As DateTime
        Public ReadOnly Tipo As String
        Private _registros As List(Of RegistroDaños)
        Private ReadOnly Property Registros As List(Of RegistroDaños)
            Get
                Return _registros
            End Get
        End Property
    End Class

    Public Class RegistroDaños
        Private _dirty As Boolean
        Private _descripcion As String
        Public ReadOnly EnInforme As InformeDaños
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(value As String)
                Dim TimeDif As TimeSpan = (Date.Now - EnInforme.Fecha).Duration
                If TimeDif.TotalHours > 4 Then
                    Throw New InvalidOperationException($"Sólo puede modificar un registro de informe 4 horas o menos antes de ser creado. Han pasado: {TimeDif.TotalHours:00}h:{TimeDif.Minutes:00}:{TimeDif.Seconds:00}")
                End If
                _descripcion = value
                _dirty = _descripcion
            End Set
        End Property
        Private _numeroenlista As UInteger
        Public ReadOnly Property NumeroEnLista As UInteger
            Get
                Return _numeroenlista
            End Get
        End Property

        Public ReadOnly Property Actualiza As RegistroDaños
            Get
                Return _actualiza
            End Get
        End Property

        Private _actualiza As RegistroDaños
        Private _imagenes As List(Of System.Drawing.Bitmap)
        Public Sub AgregarImagen(imagen As System.Drawing.Bitmap)
            Dim TimeDif As TimeSpan = (Date.Now - EnInforme.Fecha).Duration

            If TimeDif.CompareTo(New TimeSpan(4, 0, 0)) < 0 Then
                _imagenes.Add(imagen)
            Else
                Throw New InvalidOperationException($"Solo puede añadir imagenes si han pasado menos de 4 horas. Han pasado: {TimeDif.TotalHours}h:{TimeDif.Minutes:03}:{TimeDif.Seconds}")
            End If
        End Sub
    End Class

    Public Class Usuario
        Private _trabajaen As List(Of Tuple(Of Lugar, DateTime, DateTime?))
        Private _dirty As Boolean

        Private ReadOnly Property TrabajaEn As IReadOnlyList(Of Tuple(Of Lugar, DateTime, DateTime?))
            Get
                Return _trabajaen
            End Get
        End Property

        Public Function Conectar(En As Lugar) As Boolean
            If _trabajaen.Where(Function(x) x.Item3 Is Nothing).Any Then
                Return False
            Else
                _trabajaen.Add(New Tuple(Of Lugar, Date, Date?)(En, DateTime.Now, Nothing))
                Return True
            End If
        End Function

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

        Public Shared Function SelfPad(data As String, toLen As UInteger) As String
            Dim returnString(toLen) As Char
            For i As UInteger = 1 To toLen
                returnString(i) = data(((i - 1) Mod data.Length) + 1)
            Next
            Return returnString
        End Function

        Public Shared Function ContraseñaHash(password As String, usuario As String) As String
            Dim data = SelfPad(password, 60)
            Dim nkey = SelfPad(usuario, 60)
            Return data.Select(Of Char)(Function(x As Char, i As Integer) ChrW(AscW(x) Xor AscW(nkey(i))))
        End Function

        Private _primer_nombre As String
        Public Property PrimerNombre As String
            Get
                Return _primer_nombre
            End Get
            Set(value As String)
                _primer_nombre = value
            End Set
        End Property

        Private _segundo_nombre As String
        Public Property SegundoNombre As String
            Get
                Return _segundo_nombre
            End Get
            Set(value As String)
                _segundo_nombre = value
                _dirty = True
            End Set
        End Property

        Private _primer_apellido As String
        Public Property PrimerApellido As String
            Get
                Return _primer_apellido
            End Get
            Set(value As String)
                _primer_apellido = value
                _dirty = True
            End Set
        End Property

        Private _segundo_apellido As String
        Public Property SegundoApellido As String
            Get
                Return _segundo_apellido
            End Get
            Set(value As String)
                _segundo_apellido = value
                _dirty = True
            End Set
        End Property

        Private _pregunta_secreta As String

        Public ReadOnly Property PreguntaSecreta As String
            Get
                Return _pregunta_secreta
            End Get
        End Property

        Public Function VerificarPregunta(respuesta As String) As Boolean
            Return True
        End Function

        Private _fecha_nacimiento As DateTime?
        Public Property FechaNacimiento As DateTime?
            Get
                Return _fecha_nacimiento
            End Get
            Set(value As DateTime?)
                _fecha_nacimiento = value
                _dirty = True
            End Set
        End Property

        Private _sexo As Char
        Public Property Sexo As Char
            Get
                Return _sexo
            End Get
            Set(value As Char)
                _sexo = value
            End Set
        End Property

        Private _email As String
        Public Property Email As String
            Get
                Return _email
            End Get
            Set(value As String)
                _email = value
                _dirty = True
            End Set
        End Property

        Private _telefono As String
        Public Property Telefono As String
            Get
                Return _telefono
            End Get
            Set(value As String)
                _telefono = value
                _dirty = True
            End Set
        End Property

        Private _rol As Role
        Public ReadOnly Property Rol As Role
            Get
                Return _rol
            End Get
        End Property

        Public Sub New(trabajaen As List(Of Tuple(Of Lugar, DateTime, DateTime?)), username As String, password_hash As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta_secreta As String, fecha_nacimiento As DateTime, sexo As Char, email As String, telefono As String, rol As Role)
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