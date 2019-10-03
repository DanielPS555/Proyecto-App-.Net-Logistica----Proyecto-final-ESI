Public Class Alfa

    Private lista As New List(Of Form)
    Private _tipoObjeto As Type
    Private _tipoPanel As Type
    Public Sub New(tipoObjeto As Type, tipoPanel As Type)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.TipoObjeto = tipoObjeto
        Me.TipoPanel = tipoPanel
        If Not tipoPanel.GetInterfaces().Contains(GetType(AlfaInterface)) Then
            Throw New InvalidCastException("TipoPanel no implementa AlfaInterface")
        End If
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property TipoPanel As Type
        Get
            Return _tipoPanel
        End Get
        Set(value As Type)
            _tipoPanel = value
        End Set
    End Property

    Public Property TipoObjeto() As Type
        Get
            Return _tipoObjeto
        End Get
        Set(ByVal value As Type)
            _tipoObjeto = value
        End Set
    End Property

    Public Delegate Sub LambdaGenerico(O As Object)

    Public Shared LambdaRespuesta As New Dictionary(Of Type, LambdaGenerico) From
        {
         {
            GetType(Usuario),
            Sub(elemento) Marco.getInstancia.CargarPanel(Of PanelInfoUsuario)(New PanelInfoUsuario(DirectCast(elemento, Usuario).ID_usuario))
                }
        }

    Public Sub Devolver(elemento As Object)
        If elemento Is Nothing Then
            Return
        End If
        If elemento.GetType IsNot TipoObjeto Then
            Throw New InvalidCastException("El tipo del objeto no corresponde con el tipo configurado")
        End If

        If Not LambdaRespuesta.ContainsKey(TipoObjeto) Then
            Throw New Exception("No hay implementación para ese tipo")
        End If

        LambdaRespuesta(TipoObjeto)(elemento)
    End Sub

    Public Sub Nuevo(elemento As Object, renderAutomatico As Boolean)
        Dim objetoLista As AlfaInterface = TipoPanel.GetConstructors().Single.Invoke(New Object() {elemento})
        objetoLista.darAlfa(Me)
        lista.Add(objetoLista.dameForm)
        If renderAutomatico Then
            render()
        End If

    End Sub


    Public Function tamaño() As Size
        Return contenedor.Size
    End Function

    Public Sub render()
        contenedor.Controls.Clear()
        Dim tamaño As Integer = 0
        For Each elemento As Form In lista
            tamaño += elemento.Height
        Next
        contenedor.Height = tamaño + 81 'POR LAS DUDAS 
        For Each con As Form In lista
            con.TopLevel = False
            con.Dock = DockStyle.Top
            con.FormBorderStyle = FormBorderStyle.None
            contenedor.Controls.Add(con)
            con.Show()
            con.BringToFront()
        Next
        contenedor.Refresh()
    End Sub

    Private Sub Alfa_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawString("Carge los elementos desde codigo", New Font("Arial", 9), New SolidBrush(Color.Black), New PointF(0, 0))
    End Sub
End Class
