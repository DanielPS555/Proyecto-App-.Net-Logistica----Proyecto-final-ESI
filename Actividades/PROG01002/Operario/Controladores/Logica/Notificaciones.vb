Public Class Notificaciones
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_USUARIO = "NU"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_LUGAR = "NL"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_MEDIO = "NM"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_ALTA = "NA"
    Public Shared ReadOnly TIPO_NOTIFICACION_INTENTO_ALTA_CON_MAL_VIN = "IA"
    Public Shared ReadOnly TIPO_NOTIFICACION_CAMBIO_DISTIBUCION_LUGAR = "NU"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVA_ENTREGA = "NE"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_PERDIDA = "NP"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_TRABAJAEN = "NTE"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVA_ANULACION = "AID"
    Public Shared ReadOnly TIPO_NOTIFICACION_NUEVO_PERMITE = "AM"
    Public Shared ReadOnly TIPO_NOTIFICACION_TRANSPORTE_FALLIDO = "TF"
    Public Shared ReadOnly TIPO_NOTIFICACION_GENERICO = "GEN"


    Private tipo As String
    Private _ref1 As Object
    Private _ref2 As Object
    Private _ref3 As Object

    Public Sub New(tipo As String)
        InitializeComponent()
        Me.tipo = tipo
    End Sub

    Public Property Ref1() As Object
        Get
            Return _ref1
        End Get
        Set(ByVal value As Object)
            _ref1 = value
        End Set
    End Property

    Public Property Ref2() As Object
        Get
            Return _ref2
        End Get
        Set(ByVal value As Object)
            _ref2 = value
        End Set
    End Property

    Public Property Ref3() As Object
        Get
            Return _ref3
        End Get
        Set(ByVal value As Object)
            _ref3 = value
        End Set
    End Property


End Class
