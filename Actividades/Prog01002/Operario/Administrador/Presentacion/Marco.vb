Imports Controladores
Imports Controladores.Extenciones.Extensiones
Public Class Marco
    Private Shared initi As Marco = Nothing
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

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
        b1.Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.cargarPanel(Of AdministradorHome)(New AdministradorHome) 'despues se pasa por parametro un operario
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles b1.Click, b2.Click, b3.Click, b4.Click, b5.Click, b6.Click, b7.Click, b8.Click, b9.Click, b10.Click, b11.Click, b12.Click, b13.Click, b14.Click, b15.Click
        Dim botones() As Button = {b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                If botones(i).Equals(b3) Or botones(i).Equals(b6) Or botones(i).Equals(b8) Or botones(i).Equals(b12) Or botones(i).Equals(b14) Or botones(i).Equals(b15) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                End If

            Else
                If botones(i).Equals(b3) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                End If

            End If
        Next

        Select Case selec.Name
            Case "b1"
                Dim pInicio = cargarPanel(Of AdministradorHome)(New AdministradorHome)
            Case "b2"
                Dim pVeiculos = cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
            Case "b4"
                cargarPanel(Of ListaLotes)(New ListaLotes)
            Case "b3"
                cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
            Case "b5"
                cargarPanel(Of ListarLugares)(New ListarLugares)
            Case "b6"
                'NUEVO LUGAR
            Case "b7"
                'LISTA DE MEDIOS
            Case "b8"
                ' NUEVO MEDIO
            Case "b9"
                ' LISTA DE TRANSPORTES 
            Case "b10"
                ' LOTES DISPONIBES A TRANSPORTAR 
            Case "b11"
                ' LISTA DE USUARIOS
            Case "b12"
                ' NUEVO USUARIO 
            Case "b13"
                ' LISTA DE CLIENTES
            Case "b14"
                ' NUEVO CLIENTE 
            Case "b15"
                cargarPanel(Of NuevaPrecarga)(New NuevaPrecarga)
        End Select

    End Sub

    Public Sub Bloquear()
        accion(False)
    End Sub

    Public Sub Desbloquear()
        accion(True)
    End Sub

    Private Sub accion(j As Boolean)
        Label1.Enabled = j
        b1.Enabled = j
        b2.Enabled = j
        b3.Enabled = j
        b4.Enabled = j
        b5.Enabled = j
        b6.Enabled = j
        b7.Enabled = j
        b8.Enabled = j
        b9.Enabled = j
        b10.Enabled = j
        b11.Enabled = j
        b12.Enabled = j
        b13.Enabled = j
        b14.Enabled = j
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

    Public Function cargarPanelv2(Of T As {Form})(obj As T) As T
        cerrarPanel(Of T)()

        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        contenedor.Controls.Add(obj)
        contenedor.Tag = obj
        obj.Show()
        obj.BringToFront()
        Return obj
    End Function
End Class