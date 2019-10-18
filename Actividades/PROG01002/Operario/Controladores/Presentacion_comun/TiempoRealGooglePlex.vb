Public Class TiempoRealGooglePlex
    Public Sub New(link As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        WebBrowser1.Url = New Uri(link)

    End Sub
End Class