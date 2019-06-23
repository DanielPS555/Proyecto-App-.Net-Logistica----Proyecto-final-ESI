Namespace Logica
    Public Class Usuario
        Private _trabajaen As List(Of TrabajaEn)
        Public _dirty As Boolean

        Public ReadOnly creador As Usuario
        Public ReadOnly ID As Integer

        Public ReadOnly Property TrabajaEn As List(Of TrabajaEn)
            Get
                Return _trabajaen
            End Get
        End Property

        Public Sub New(from As DataRow, creador As Usuario)
            Me.New(from("IDUsuario"), New List(Of TrabajaEn), from("NombreDeUsuario"), from("hash_contra"), from("primernombre"), from("segundonombre"), from("primerapellido"), from("segundoapellido"), from("preguntasecreta"), from("respuestasecreta"), from("fechanac"), SexoFromString(from("sexo")), from("email"), from("telefono"), RoleFromID(from("rol")), creador)
        End Sub

        Public ReadOnly Property ConectadoEn As Lugar
            Get
                URepo.CompletarUsuario(Me)
                Dim _t_e = _trabajaen.Where(Function(x)
                                                Return x.Conexiones.Where(Function(y) As Boolean
                                                                              Return y.FechaFin Is Nothing
                                                                          End Function).Count <> 0
                                            End Function)
                Try
                    Return _t_e.Single.Lugar
                Catch ex As InvalidOperationException
                    If _t_e.Count = 0 Then
                        Return Nothing
                    Else
                        Throw New InvalidOperationException("Está conectado en más de un mismo lugar. Por favor informe a su administrador de este suceso.")
                    End If
                End Try
            End Get
        End Property

        Public Function CrearLote(NumeroLote As Integer, nombre As String, Destino As Lugar) As Lote
            Dim lotes = LRepo.AllLugares.Select(Of List(Of Lote))(Function(x) x.LotesCreados).UnionListas
            If lotes.Where(Function(x) x.ID = NumeroLote OrElse x.Nombre = nombre).Count <> 0 Then
                Throw New InvalidOperationException("Ya existe un lote con esa numeración")
            End If
            Return LRepo.NewLote(NumeroLote, nombre, Me.ConectadoEn, Destino, Me, EstadoLote.Abierto, PrioridadLote.Normal)
        End Function

        Public Function Conectar(En As Lugar) As Boolean
            Dim trabajaEnFind = _trabajaen.Where(Function(x) x.Lugar Is En)
            If Not trabajaEnFind.Any Then
                Return False
            End If
            Dim trabajaEn = trabajaEnFind.First
            If trabajaEn.Conexiones.Any(Function(x) x.FechaFin Is Nothing) Then
                Return False
            End If
            trabajaEn.Conexiones.Add(New Conexion(Date.Now, Nothing))
            _dirty = True
            Return True
        End Function

        Public Function Desconectar() As Boolean
            Dim conexiones = _trabajaen.Select(Of List(Of Conexion))(Function(x) x.Conexiones).UnionListas
            Dim findDesconectado = conexiones.Where(Function(x) x.FechaFin Is Nothing)
            If Not findDesconectado.Any Then
                Return False
            End If
            If findDesconectado.Count <> 1 Then
                MsgBox("Existe más de una conexión simultánea, por favor informe a su administrador de este suceso.")
            End If
            For Each i In findDesconectado
                i.FechaFin = Date.Now
            Next
            _dirty = True
            Return True
        End Function

        Private _username As String
        Public ReadOnly Property UserName As String
            Get
                Return _username
            End Get
        End Property

        Public _password_hash As String
        Public Function VerificarContraseña(password As String) As Boolean
            Return ContraseñaHash(password.Trim, UserName).Equals(_password_hash)
        End Function

        Public Function RestablecerContraseña(Respuesta As String, NewPass As String) As Boolean
            If Respuesta <> Me.RespuestaSecreta Then
                Return False
            End If
            Me._password_hash = ContraseñaHash(NewPass, UserName)
            _dirty = True
            Return True
        End Function

        Public Shared Function SelfPad(data As String, toLen As UInteger) As String
            If String.IsNullOrEmpty(data) Then
                Throw New InvalidOperationException("Cannot selfpad an empty string")
            End If
            Dim returnString(toLen - 1) As Char
            For i As UInteger = 0 To toLen - 1
                returnString(i) = data(i Mod data.Length)
            Next
            Return returnString
        End Function

        Public Shared Function ContraseñaHash(password As String, usuario As String) As String
            Dim data = SelfPad(password, 60)
            Dim nkey = SelfPad(usuario, 60)
            Return data.Select(Of Char)(Function(x As Char, i As Integer) ChrW(AscW(x) Xor AscW(nkey(i)))).ToArray
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

        Public ReadOnly PreguntaSecreta As String
        Private RespuestaSecreta As String

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

        Public sexo As Sexo

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

        Public ReadOnly Property NombreCompleto As String
            Get
                Dim str = PrimerNombre
                If SegundoNombre IsNot Nothing Then
                    str += $" {SegundoNombre}"
                End If
                str += $" {PrimerApellido}"
                If SegundoApellido IsNot Nothing Then
                    str += $" {SegundoApellido}"
                End If
                Return str
            End Get
        End Property

        Public Sub New(ID As Integer, trabajaen As List(Of TrabajaEn), username As String, password_hash As String, primer_nombre As String, segundo_nombre As String, primer_apellido As String, segundo_apellido As String, pregunta_secreta As String, respuesta_secreta As String, fecha_nacimiento As DateTime, sexo As Sexo, email As String, telefono As String, rol As Role, creador As Usuario)
            Me.ID = ID
            _trabajaen = trabajaen
            _username = username
            _password_hash = password_hash
            _primer_nombre = primer_nombre
            _segundo_nombre = segundo_nombre
            _primer_apellido = primer_apellido
            _segundo_apellido = segundo_apellido
            PreguntaSecreta = pregunta_secreta
            _fecha_nacimiento = fecha_nacimiento
            Me.sexo = sexo
            _email = email
            _telefono = telefono
            _rol = rol
            Me.RespuestaSecreta = respuesta_secreta
            Me.creador = creador
        End Sub
    End Class
    Public Enum Sexo
        Masculino
        Femenino
        Otro
    End Enum
End Namespace