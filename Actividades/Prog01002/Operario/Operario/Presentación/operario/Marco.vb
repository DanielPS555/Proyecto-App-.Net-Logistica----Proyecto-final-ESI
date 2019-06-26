Public Class Marco
    Private Shared initi As Marco = Nothing
    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Shared Function getInstancia() As Marco
        If initi Is Nothing Then
            initi = New Marco
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

    Public Sub cerrarTodos()
        While stack.Count > 0
            cerrarUltimo()
        End While
    End Sub

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
        If LRepo.TipoLugar(URepo.ConectadoEn) = "Patio" Then
            nuevoVehiculo.Visible = False
            nuevoVehiculo.Enabled = False
        End If
        Me.cargarPanel(Of OperarioHome)(New OperarioHome) 'despues se pasa por parametro un operario
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles veiculos.Click, nuevoVehiculo.Click, lotes.Click, ListaZona.Click, inicio.Click
        Dim botones() As Button = {inicio, lotes, veiculos, nuevoVehiculo, ListaZona}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                If botones(i).Equals(nuevoVehiculo) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                End If

            Else
                If botones(i).Equals(nuevoVehiculo) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                End If

            End If
        Next

        Select Case selec.Name
            Case "inicio"
                Dim pInicio = cargarPanel(Of OperarioHome)(New OperarioHome)
            Case "veiculos"
                Dim pVeiculos = cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
            Case "lotes"
                cargarPanel(Of ListaLotes)(New ListaLotes)
            Case "nuevoVehiculo"
                cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
            Case "ListaZona"
                cargarPanel(Of ListaZonas)(New ListaZonas)
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not URepo.Desconectar Then
            MsgBox("Hubo un error desconectando. Por favor informe a su admin")
        End If
        initi = Nothing
        cerrarTodos()
        Principal.getInstancia.cerrarPanel(Of Marco)()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        cerrarUltimo()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        MsgBox("¡Sin imploementar!")
    End Sub
End Class