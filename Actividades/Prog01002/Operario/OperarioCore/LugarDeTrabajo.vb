Imports System.Drawing
Imports System.Windows.Forms
Imports Controladores


Public Class LugarDeTrabajo
    Dim ListaTrabajaEn As List(Of TrabajaEn)

    Private Sub LugarDeTrabajo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(lugares.Location, lugares.Size))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Fachada.getInstancia.NuevaConexcion(ListaTrabajaEn(lugares.SelectedIndex))
        Marco.reiniciarSingleton()
        Principal.getInstancia.cargarPanel(Marco.getInstancia)


    End Sub

    Private Sub lugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugares.SelectedIndexChanged
        Dim i As Integer = lugares.SelectedIndex
        If i < 0 Then
            Button2.Enabled = False
            Return
        End If
        Button2.Enabled = True
        nom.Text = ListaTrabajaEn(i).Lugar.Nombre
        ubi.Text = $"{ListaTrabajaEn(i).Lugar.PosicionX:F1}, {ListaTrabajaEn(i).Lugar.PosicionY:F1}"
        tipo.Text = ListaTrabajaEn(i).Lugar.Tipo
        Dim ulti As Tuple(Of DateTime, DateTime?) = Fachada.getInstancia.CargarConexcionEnTrabajaEn(ListaTrabajaEn(i)).ultimaConexcion
        inicioUconex.Text = If(ulti Is Nothing, "Nunca", Funciones_comunes.DarFormato(ulti.Item1))
        finalUconex.Text = If(ulti Is Nothing, "Nunca", Funciones_comunes.DarFormato(ulti.Item2))
    End Sub

    Private Sub LugarDeTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lugares.Items.Clear()
        ListaTrabajaEn = Fachada.getInstancia.devolverTrabajaEnBasicosActuales(Fachada.getInstancia.NombreUsuarioActual)
        If ListaTrabajaEn.Count = 0 Then
            Principal.getInstancia.cargarPanel(Of Login)(New Login(True))
            MsgBox("Usted no tiene ningun lugar de trabajo vijente")
            Return

        End If
        For Each t As TrabajaEn In ListaTrabajaEn
            lugares.Items.Add(t.Lugar.Nombre)
        Next
        lugares.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Principal.getInstancia.cargarPanel(Of Login)(New Login(True))
        Me.Close()
    End Sub
End Class