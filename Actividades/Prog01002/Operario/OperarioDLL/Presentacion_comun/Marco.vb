Imports Controladores
Imports Controladores.Extenciones.Extensiones
Public Class Marco
    Private Shared initi As Marco = Nothing
    Private Shared papa As Panel
    Public Sub New()

        InitializeComponent()
        Select Case Fachada.getInstancia.DevolverUsuarioActual.Rol
            Case Usuario.TIPO_ROL_OPERARIO
                b1.Visible = False
                b4.Visible = False
                b5.Visible = False
                b6.Visible = False
                b7.Visible = False
                b8.Visible = False

            Case Usuario.TIPO_ROL_TRANSPORTISTA
                b2.Visible = False
                b3.Visible = False
                b5.Visible = False
                b6.Visible = False
                b8.Visible = False
                b9.Visible = False
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                b9.Visible = False
        End Select

    End Sub

    Public Shared Sub reiniciarSingleton()
        initi = Nothing
    End Sub

    Public Shared Function getInstancia() As Marco

        Return initi
    End Function

    Public Shared Function CrearInstancia(papa As Panel)
        If initi Is Nothing Then
            initi = New Marco()
            Marco.papa = papa
        End If
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



    Private Sub Marco_Load(sender As Object, e As EventArgs) Handles Me.Load
        b1.Font = New Font("Segoe UI Semilight", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.cargarPanel(Of Home)(New Home)
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles b2.Click, b3.Click, b6.Click, b4.Click, b1.Click, b7.Click, b5.Click, b8.Click
        Dim botones() As Button = {b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, acercaDe, Micuenta}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                botones(i).Font = New Font("Segoe UI Semilight", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Else
                botones(i).Font = New Font("Segoe UI Semilight", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            End If
        Next

        Select Case selec.Name
            Case "b1"
                Dim pInicio = cargarPanel(Of ListaDeTrasportes)(New ListaDeTrasportes)
            Case "b2"
                Dim pVeiculos = cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
            Case "b4"
                cargarPanel(Of ListaLotes)(New ListaLotes)
            Case "b3"
                cargarPanel(Of ListaDeMediosAutorizados)(New ListaDeMediosAutorizados)
            Case "b5"
                cargarPanel(Of ListarUsuario)(New ListarUsuario)
            Case "b6"
                cargarPanel(Of ListarLugares)(New ListarLugares)
            Case "b7"
                cargarPanel(Of Lista_de_trasportes)(New Lista_de_trasportes)
            Case "b8"
                cargarPanel(Of ListarClientes)(New ListarClientes)
            Case "b9"
                cargarPanel(Of ListaZonas)(New ListaZonas)
            Case "b10"
                Me.cargarPanel(Of Home)(New Home)
            Case "acercaDe"
                'AQUI VA EL PANEL DE USUARIO
            Case "Micuenta"
                'AQUI VA EL ACCERCA DEL PROGRAMA

        End Select

    End Sub

    Public Sub Bloquear()
        accion(False)
    End Sub

    Public Sub Desbloquear()
        accion(True)
    End Sub

    Private Sub accion(j As Boolean)

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
        acercaDe.Enabled = j
        Micuenta.Enabled = j
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fachada.getInstancia.CerrarSeccion()
        papa.getInstancia.cargarPanel(Of LoginAdmin)(New LoginAdmin(True))
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) 
        cerrarUltimo()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Micuenta.Click
        MsgBox("¡Sin imploementar!")
    End Sub

    Public Function cargarPanelv2(Of T As {Form})(obj As T) As T ' No hay referencias a la función ni encuentro razón por la cual algún panel no debería ser pusheado al stack
        Return cargarPanel(obj, False)
    End Function

    Public Function cargarPanel(Of T As {Form})(obj As T, Optional pushToStack As Boolean = True) As T
        cerrarPanel(Of T)()
        If pushToStack Then
            stack.Push(obj)
        End If

        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        contenedor.Controls.Add(obj)
        contenedor.Tag = obj
        obj.Show()
        obj.BringToFront()
        Return obj
    End Function
End Class