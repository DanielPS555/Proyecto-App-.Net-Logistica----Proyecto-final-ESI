Public Class Alfa

    Private lista As New List(Of IAlfaInterface)
    Private listaDeNotificacionesParaRecontrucion As New List(Of Object)
    Private _tipoObjeto As Type
    Private _tipoPanel As Type
    Private accion As LambdaGenerico
    Public Sub New(Optional tipoObjeto As Type = Nothing, Optional tipoPanel As Type = Nothing, Optional accion As LambdaGenerico = Nothing)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.TipoObjeto = tipoObjeto
        Me.TipoPanel = tipoPanel
        Me.accion = accion
        If Not tipoPanel.GetInterfaces().Contains(GetType(IAlfaInterface)) Then
            Throw New InvalidCastException("TipoPanel no implementa AlfaInterface")
        End If
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Public Function GetObjects() As IEnumerable(Of Object)
        Return lista.Cast(Of IAlfaInterface).Select(Function(x) x.dameContenido).ToList
    End Function

    Public Sub EliminarLista()
        lista.Clear()
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

    Public Sub Limpiar(j As Boolean)
        Me.lista.ForEach(Sub(x) x.dameForm.Close())
        Me.lista.Clear()
        If j Then
            listaDeNotificacionesParaRecontrucion.Clear()
        End If
    End Sub

    Public Delegate Sub LambdaGenerico(O As Object)

    Public Sub Devolver(elemento As Object)
        If elemento Is Nothing Then
            Return
        End If
        If elemento.GetType IsNot TipoObjeto Then
            Throw New InvalidCastException("El tipo del objeto no corresponde con el tipo configurado")
        End If

        If accion Is Nothing Then
            Throw New InvalidCastException("No hay accion para este tipo de elemento")
        End If

        accion(elemento)
    End Sub

    Public Sub Nuevo(elemento As Object, renderAutomatico As Boolean, Optional jj As Boolean = False)
        If jj Then
            listaDeNotificacionesParaRecontrucion.Add(elemento)
        End If
        Dim objetoLista As IAlfaInterface = TipoPanel.GetConstructors().Single.Invoke(New Object() {elemento})
        objetoLista.darAlfa(Me)
        lista.Add(objetoLista)
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
        For Each elemento As IAlfaInterface In lista
            Dim ele = elemento.dameForm
            tamaño += ele.Height + 12
        Next
        contenedor.Height = tamaño
        For Each epe As IAlfaInterface In lista
            epe.darAncho(Me.Width)
            Dim con As Form = epe.dameForm
            con.TopLevel = False
            con.Dock = DockStyle.Top
            con.FormBorderStyle = FormBorderStyle.None
            contenedor.Controls.Add(con)
            con.Show()
            con.BringToFront()
            epe.Reacomodarpropiedades()
        Next
        contenedor.Refresh()
    End Sub

    Public Sub Fastrender() 'SOLO LOS NUEVOS, NO SE PUEDE HACER RENDER SI SE ELIMINA ALGO 

        If contenedor.Controls.Count = 0 Then
            render()
            Return
        End If

        Dim ultimo As Integer = contenedor.Controls.Count - 1

        If contenedor.Controls.Count = lista.Count Then
            Return
        End If

        Dim tamaño As Integer = 0
        For i As Integer = ultimo To lista.Count - 1
            tamaño += lista(i).dameForm.Height
        Next
        contenedor.Height += tamaño + 81 'POR LAS DUDAS 
        For i As Integer = ultimo To lista.Count - 1
            Dim con As Form = lista(i).dameForm
            con.TopLevel = False
            con.Dock = DockStyle.Top
            con.FormBorderStyle = FormBorderStyle.None
            contenedor.Controls.Add(con)
            con.Show()
            con.BringToFront()
            lista(i).Reacomodarpropiedades()
        Next
        contenedor.Refresh()
    End Sub

    Private Sub Alfa_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawString("Carge los elementos desde codigo", New Font("Arial", 9), New SolidBrush(Color.Black), New PointF(0, 0))
    End Sub

    Private Sub Alfa_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.Limpiar(False)

        For Each i As Object In listaDeNotificacionesParaRecontrucion
            Me.Nuevo(i, False)
        Next
        render()
    End Sub
End Class
