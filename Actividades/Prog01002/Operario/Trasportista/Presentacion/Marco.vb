Imports Controladores
Imports Controladores.Extenciones.Extensiones
Public Class Marco
    Private Shared initi As Marco = Nothing
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Controladores.Fachada.getInstancia.CargarDataBaseDelUsuario()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Shared Sub reiniciarSingleton()
        initi = Nothing
    End Sub

    Public Shared Function getInstancia() As Marco
        If initi Is Nothing Then
            initi = New Marco()
        End If
        Return initi
    End Function

    Public Sub cerrarPanel(Of T As {Form})()
        contenedor.Controls.OfType(Of T).ForEach(Sub(x)
                                                     x.Close()
                                                     contenedor.Controls.Remove(x)
                                                 End Sub)
    End Sub

    Public Function InstanciaDe(Of T As {Form})() As T
        Return contenedor.Controls.OfType(Of T).FirstOrDefault
    End Function



    Private Sub cerrarUltimo()
        If stack.Count = 0 Then
            Return
        End If
        Dim x = stack.Pop
        contenedor.Controls.Remove(x)
        x.Close()
    End Sub

    Public stack As New Stack(Of Form)

    Public Function cargarPanel(Of T As {Form})(obj As T) As T
        cerrarPanel(Of T)()
        stack.Push(obj)

        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        contenedor.Controls.Add(obj)
        contenedor.Tag = obj
        obj.Show()
        obj.BringToFront()
        Return obj
    End Function

    Private Sub Marco_Load(sender As Object, e As EventArgs) Handles Me.Load
        inicio.Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.cargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles veiculos.Click, lotes.Click, inicio.Click
        Dim botones() As Button = {inicio, lotes, veiculos}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Else
                botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            End If
        Next

        Select Case selec.Name
            Case "inicio"
                Dim pInicio = cargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
            Case "veiculos"
                Dim pVeiculos = cargarPanel(Of ListaDeTrasportes)(New ListaDeTrasportes)
            Case "lotes"
                cargarPanel(Of ListaDeMediosAutorizados)(New ListaDeMediosAutorizados)
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fachada.getInstancia.CerrarSeccion()
        Principal.getInstancia.cargarPanel(Of Login)(New Login(True))
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        cerrarUltimo()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        MsgBox("¡Sin imploementar!")
    End Sub
End Class