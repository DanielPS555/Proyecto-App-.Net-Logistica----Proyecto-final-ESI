Public Class crearInformaDeDaños
    ' hay que crear una lista de registros
    Public Sub New()
        InitializeComponent()
        tipo.SelectedIndex = 0
    End Sub

    Private m As DataTable

    Public Sub New(informe As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        tipo.Enabled = False
        Dim List = Me.components.Components.OfType(Of Button).ToList
        List.Where(Function(x) x.Name = "ingresarBtn").Single.Visible = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        tipo.SelectedItem = VRepo.TipoInforme(informe)
        descipt.Text = VRepo.DescripcionInforme(informe)
        descipt.ReadOnly = True
        m = VRepo.Registros(VRepo.VINInforme(informe), informe).Item1
        Registros.Items.AddRange(m.ToList.Select(Function(x) x("ID")).ToArray)
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
        MarcoPuerto.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel)
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
            descipt.Text = m.ToList.Where(Function(x) x("ID") = Registros.SelectedIndex).Select(Of String)(Function(z) z("Descripcion")).Single
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MarcoPuerto.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
    End Sub
End Class