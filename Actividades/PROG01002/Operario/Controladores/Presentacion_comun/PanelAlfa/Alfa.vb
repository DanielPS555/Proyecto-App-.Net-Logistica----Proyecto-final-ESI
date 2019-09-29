Public Class Alfa

    Private lista As New List(Of Form)
    Private _tipo As Integer
    Public Sub New(Optional tipo = 0)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.tipo = tipo
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property Tipo() As Integer
        Get
            Return _tipo
        End Get
        Set(ByVal value As Integer)
            _tipo = value
        End Set
    End Property

    Public Sub devolver(elemento As Object)
        Select Case Tipo 'PARA CADA POSIBLE FUNCIONALIDAD DEL PANEL, SE CREAN LOS LAS RESPECTIVAS OPCIONES AQUI, YA QUE ANTES DE CARGAR EL PANEL SI O SI SE TIENE QUE DECIR SU TIPO 
            ' A MODO DE EJEMPLO, EN LA LISTA DE VEHICULO LOS ITEM VEHICULOS VAN A TENER UNA FUNCION (ACCEDER AL PANEL DE VEHICULO), PERO EN LA LISTA DE NO ASIGNADOS DEBERA LLAMAR
            ' AL Panel ASIGNACION, ES POR ELLO QUE POR CADA FUNCION QUE QUERAMOS QUE CUMPLA SE DEBERA CREAR UNA OPCION AQUI 
            Case 1
                If TypeOf elemento Is Usuario Then
                    Marco.getInstancia.CargarPanel(Of PanelInfoUsuario)(New PanelInfoUsuario(DirectCast(elemento, Usuario).ID_usuario))
                End If

            Case Else
                Throw New Exception("Debe cargar ese tipo")

        End Select
    End Sub

    Public Sub Nuevo(elemento As AlfaInterface, renderAutomatico As Boolean)
        elemento.darAlfa(Me)
        lista.Add(elemento.dameForm)
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
