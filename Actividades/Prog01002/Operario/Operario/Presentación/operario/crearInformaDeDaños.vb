Imports Operario

Public Class crearInformaDeDaños
    Implements IActualizaMessage
    ' hay que crear una lista de registros
    Public nuevo As Boolean
    Public Sub New(VIN As String)
        informe = VRepo.NewInforme("", "Total", VIN)
        Dim m = VehiculoRepo.RegistroTable()(0)
        InitializeComponent()
        tipo.SelectedIndex = 0
        Actualizar()
        nuevo = True
    End Sub

    Private m As DataTable
    Private ReadOnly informe As Integer

    Public Sub New(informe As Integer)
        Me.informe = informe
        InitializeComponent()
        tipo.Enabled = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        tipo.SelectedItem = VRepo.TipoInforme(informe)
        descipt.Text = VRepo.DescripcionInforme(informe)
        descipt.ReadOnly = True
        Actualizar()
        nuevo = False
    End Sub

    Private Sub descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        Dim length As Integer = 255 - descipt.Text.Length
        cp.Text = length
        If length < 0 Then
            cp.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            cp.ForeColor = Color.FromArgb(35, 35, 35)
        End If
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel(informe, Me))
    End Sub

    Private Sub eliminar_Click(sender As Object, e As EventArgs)
        If descipt.ReadOnly Then
            Return
        ElseIf Registros.SelectedIndex > 0 Then
            'Se debe eliminar el elemento de la lista
            Registros.Items.Remove(Registros.SelectedIndex)
        End If
    End Sub

    Private Sub Registros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Registros.SelectedIndexChanged
        If descipt.ReadOnly Then
            descipt.Text = m.ToList.Where(Function(x) x("ID") = Registros.SelectedItem).Select(Of String)(Function(z) z("Descripcion")).Single
            Marco.getInstancia.cargarPanel(New RegistroDeDañoPanel(informe, Integer.Parse(Registros.SelectedItem), False, Me))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If nuevo Then
            For Each i As String In Registros.Items
                SRepo.ConsultarSinRetorno($"delete from imagenregistro where informe={informe} and nrolista={i.Split(":")(0)};")
                SRepo.ConsultarSinRetorno($"delete from registrodanios where informe={informe} and nrolista={i.Split(":")(0)};")
            Next
        End If
        Marco.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
    End Sub

    Private Sub ingresarBtn_Click(sender As Object, e As EventArgs)
        If Not (VRepo.UpdateInformeDesc(informe, descipt.Text) AndAlso VRepo.UpdateInformeTipo(informe, tipo.SelectedItem)) Then
            MsgBox("no se pudo actualizar el informe")
        Else
            Marco.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
        End If
    End Sub

    Public Sub Actualizar() Implements IActualizaMessage.Actualizar
        m = VRepo.Registros(VRepo.VINInforme(informe), informe).Item1
        Registros.Items.Clear()
        Registros.Items.AddRange(m.ToList.Select(Function(x) $"{x("ID")}: {x("Descripcion")}").ToArray)
    End Sub
End Class