Imports Controladores
Imports System.Drawing
Imports System.Windows.Forms
Public Class ListaVehiculos
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Fachada.getInstancia.TrabajaEnAcutual IsNot Nothing AndAlso Fachada.getInstancia.TrabajaEnAcutual.Lugar.Tipo = Lugar.TIPO_LUGAR_PUERTO Then
            nuevo.Visible = True
        Else
            nuevo.Visible = False
        End If

        If Fachada.getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            LugaresBox.Items.Add(Fachada.getInstancia.TrabajaEnAcutual.Lugar)
            LugaresBox.Enabled = False
            tiposListas.Items.Remove("Entregados")
        Else
            LugaresBox.Items.AddRange(Fachada.getInstancia.LugaresObjetos)
        End If
        LugaresBox.SelectedIndex = 0
        Asignados()
        DataGridView1.MultiSelect = False
        criterios.SelectedIndex = 0
        tiposListas.SelectedIndex = 0
        buscar.Text = Controladores.Funciones_comunes.I18N("Buscar", Marco.Language)
        nuevo.Text = Controladores.Funciones_comunes.I18N("Nuevo vehiculo", Marco.Language)

    End Sub

    Private lugar As Lugar

    Dim t As DataTable

    Public Sub UpdateVehicles()
        Select Case tiposListas.SelectedItem
            Case "Asignados"
                Asignados()
            Case "No asignados"
                NoAsignados()
            Case "Entregados"
                Entregados()
        End Select
    End Sub

    Public Sub Entregados()
        DataGridView1.DataSource = Fachada.getInstancia.VehiculosEntregados()
    End Sub

    Public Sub Asignados()
        If lugar IsNot Nothing Then
            DataGridView1.DataSource = Fachada.getInstancia.ListaVehiculos(lugar)
        End If
    End Sub

    Public Sub NoAsignados()
        If lugar IsNot Nothing Then
            DataGridView1.DataSource = Controladores.Fachada.getInstancia.listaDeVehiculosSinLoteNiPosicion(lugar.IDLugar)
        End If
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs) Handles nuevo.Click
        Marco.getInstancia.CargarPanel(Of NuevoVehiculo)(New NuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        '            
        Select Case tiposListas.SelectedItem
            Case "No asignados"
                Dim eleme As New Asignacion(DataGridView1.Rows(e.RowIndex).Cells(1).Value, lugar)
                eleme.ShowDialog()
            Case Else
                Dim row = DataGridView1.Rows()(e.RowIndex)
                Marco.getInstancia.CargarPanel(New panelInfoVehiculo(row.Cells(1).Value)).Show()
        End Select
        '

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs) Handles buscar.Click
        'CargarDatos(DataGridView1.Columns)
    End Sub

    Private Sub LugaresBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LugaresBox.SelectedIndexChanged
        lugar = LugaresBox.SelectedItem
        UpdateVehicles()
    End Sub

    Private Sub tiposListas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposListas.SelectedIndexChanged
        UpdateVehicles()
    End Sub
End Class

