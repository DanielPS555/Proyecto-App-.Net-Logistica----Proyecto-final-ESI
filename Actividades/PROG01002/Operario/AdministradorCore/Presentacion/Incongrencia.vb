Public Class Incongrencia
    Private lugar_antigo As Controladores.Lugar
    Private lugar_nuevo As Controladores.Lugar
    Private posicionesIncongruentes As List(Of Controladores.Posicion)
    Public Sub New(la As Controladores.Lugar, ln As Controladores.Lugar)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub detectarPosicionesIncongruentes()
        Dim posiciones As List(Of Controladores.Posicion) = Controladores.Fachada.getInstancia.PosicionesActualesPorIdlugar(lugar_antigo.IDLugar)
        Dim idsElementosAModificar As List(Of Integer)
        For Each pos As Controladores.Posicion In posiciones
            If lugar_nuevo.Zonas.Select(Function(x) x.Subzonas).ToList.Select(Function(x) x. (pos Then


        Next

        For Each i As Integer In idsElementosAModificar
            posiciones.RemoveAt(i)
        Next

    End Sub




End Class