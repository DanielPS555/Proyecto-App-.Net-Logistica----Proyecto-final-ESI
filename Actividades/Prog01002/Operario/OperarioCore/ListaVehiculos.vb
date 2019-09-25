Imports Controladores
Imports Controladores.Fachada
Imports System.Drawing
Imports System.Windows.Forms
Public Class ListaVehiculos
    Private tipolista As Boolean = True
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If getInstancia.DevolverUsuarioActual.Rol <> Usuario.TIPO_ROL_ADMINISTRADOR Then
            LugaresBox.Items.Add(getInstancia.TrabajaEnAcutual.Lugar)
            LugaresBox.Enabled = False
        Else
            LugaresBox.Items.AddRange(getInstancia.LugaresObjetos)
        End If
        LugaresBox.SelectedIndex = 0
        asignados()
        DataGridView1.MultiSelect = False
        criterios.SelectedIndex = 0
        tiposListas.SelectedIndex = 0
    End Sub



    Private lugar As Lugar

    Dim t As DataTable

    Public Sub asignados()
        If lugar IsNot Nothing Then
            DataGridView1.DataSource = getInstancia.ListaVehiculos(lugar)
        End If
    End Sub

    Public Sub Noasignados()
        If lugar IsNot Nothing Then
            DataGridView1.DataSource = Controladores.Fachada.getInstancia.listaDeVehiculosSinLoteNiPosicion(lugar.IDLugar)
        End If
    End Sub

    Private Sub ListaVehiculos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(35, 35, 35), 2), New Rectangle(criterios.Location, criterios.Size)) 'para dibujarle un rectangulo al combobox
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.CargarPanel(Of NuevoVehiculo)(New NuevoVehiculo)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If tipolista Then
            Dim row = DataGridView1.Rows()(e.RowIndex)
            Marco.getInstancia.CargarPanel(New panelInfoVehiculo(row.Cells(1).Value)).Show()
        Else
            Dim eleme As New Asignacion(DataGridView1.Rows(e.RowIndex).Cells(1).Value)
            eleme.ShowDialog()
        End If

    End Sub

    Private Sub buscar_Click(sender As Object, e As EventArgs)
        'CargarDatos(DataGridView1.Columns)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Noasignados()
        tipolista = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        asignados()
        tipolista = True
    End Sub

    Private Sub tiposListas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tiposListas.SelectedIndexChanged

    End Sub

    Private Sub LugaresBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LugaresBox.SelectedIndexChanged
        lugar = LugaresBox.Items(LugaresBox.SelectedIndex)
    End Sub
End Class

