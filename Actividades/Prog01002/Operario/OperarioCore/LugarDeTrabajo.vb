Imports System.Drawing
Imports System.Windows.Forms
Imports Controladores


Public Class LugarDeTrabajo
    Private Sub LugarDeTrabajo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(lugares.Location, lugares.Size))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Fachada.getInstancia.asignarTrabajaEn(lugares.SelectedItem)
        Fachada.getInstancia.CargarDataBaseDelUsuario()
        Fachada.getInstancia.NuevaConexcion(DirectCast(lugares.SelectedItem, TrabajaEn))
        Dim paneles As New Dictionary(Of String, Type) From {
            {"Lista zonas", GetType(ListaZonas)},
            {"Lista vehiculos", GetType(ListaVehiculos)},
            {"Nuevo vehiculo", GetType(NuevoVehiculo)},
            {"Lista lotes", GetType(ListaLotes)}
        }
        If Fachada.getInstancia.LugarZonasySubzonas(-1, CType(DirectCast(lugares.SelectedItem, TrabajaEn), TrabajaEn).Lugar).Tipo <> Lugar.TIPO_LUGAR_PUERTO Then
            paneles.Remove("Nuevo vehiculo")
        End If
        Marco.SetButtons(paneles)
        Marco.ReiniciarSingleton()
        Principal.getInstancia.cargarPanel(Marco.getInstancia)
    End Sub

    Private Sub lugares_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lugares.SelectedIndexChanged
        Dim i As Integer = lugares.SelectedIndex
        If i < 0 Then
            Button2.Enabled = False
            Return
        End If
        Button2.Enabled = True
        nom.Text = lugares.SelectedItem.Lugar.Nombre
        ubi.Text = $"{lugares.SelectedItem.Lugar.PosicionX:F1}, {lugares.SelectedItem.Lugar.PosicionY:F1}"
        tipo.Text = lugares.SelectedItem.Lugar.Tipo
        Dim ulti As Tuple(Of Date, Date?) = Fachada.getInstancia.CargarConexcionEnTrabajaEn(lugares.SelectedItem).ultimaConexcion
        inicioUconex.Text = If(ulti Is Nothing, Funciones_comunes.I18N("Nunca", Marco.Language), Funciones_comunes.DarFormato(ulti.Item1))
        finalUconex.Text = If(ulti Is Nothing, Funciones_comunes.I18N("Nunca", Marco.Language), Funciones_comunes.DarFormato(ulti.Item2))
    End Sub

    Private Sub LugarDeTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lugares.Items.Clear()
        Dim ListaTrabajaEn = Fachada.getInstancia.devolverTrabajaEnBasicosActuales(Fachada.getInstancia.NombreUsuarioActual)
        If ListaTrabajaEn.Count = 0 Then
            Me.Close()
            MsgBox("Usted no tiene ningun lugar de trabajo vijente")
            Return
        End If
        For Each t As TrabajaEn In ListaTrabajaEn
            lugares.Items.Add(t)
        Next
        lugares.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class