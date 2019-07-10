
Public Class RegistroDaños

    Public Shared ReadOnly TIPO_ACTUALIZACION_CORRECION As String = "Correccion"
    Public Shared ReadOnly TIPO_ACTUALIZACION_REGULAR As String = Nothing
    Public Shared ReadOnly TIPO_ACTUALIZACION_ANULACION As String = "Anulacion"

    Public Shared ReadOnly Property TIPOS_ACTUALIZACIONES() As String()
        Get
            Return {TIPO_ACTUALIZACION_CORRECION, TIPO_ACTUALIZACION_REGULAR, TIPO_ACTUALIZACION_ANULACION}
        End Get
    End Property

    Public Sub New(id As Integer, des As String, tipoA As String, act As RegistroDaños, infoP As InformeDeDaños)
        Me.ID = id
        Me.Descripcion = des
        Me.TipoActualizacion = tipoA
        Me.Actualiza = act
        Me.InformePadre = infoP
        Me._imagenes = New List(Of Image)
    End Sub

    Public Sub New(infoP As InformeDeDaños)
        Me.InformePadre = infoP
        Me._imagenes = New List(Of Image)
    End Sub

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            If ID >= 0 Then
                _id = value
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

    Private _Actualiza As RegistroDaños
    Public Property Actualiza() As RegistroDaños
        Get
            Return _Actualiza
        End Get
        Set(ByVal value As RegistroDaños)
            _Actualiza = value
        End Set
    End Property

    Private _TipoActualizacion As String
    Public Property TipoActualizacion() As String
        Get
            Return _TipoActualizacion
        End Get
        Set(ByVal value As String)
            If Not Actualiza Is Nothing Then
                If value Is Nothing Then
                    _TipoActualizacion = value
                Else
                    If TIPOS_ACTUALIZACIONES.Contains(value) Then
                        _TipoActualizacion = value
                    Else
                        Throw New Exception("Valor del tipo de actualiza incorrecto")
                    End If
                End If
                    Else
                Throw New Exception("Antes de Establecer el tipo de actualizacion debe espesificar cual es el registro del que actualiza")
            End If

        End Set
    End Property

    Private _inforPadre As InformeDeDaños
    Public Property InformePadre() As InformeDeDaños
        Get
            Return _inforPadre
            Dim i As Drawing.Image
        End Get
        Set(ByVal value As InformeDeDaños)
            _inforPadre = value
        End Set
    End Property

    Private _imagenes As List(Of Image)
    Public Property NewProperty() As List(Of Image)
        Get
            Return _imagenes
        End Get
        Set(ByVal value As List(Of Image))
            _imagenes = value
        End Set
    End Property
End Class
