Imports Controladores
Public Class ListaZonas
    Private estadoCom As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()


        cargarZonas()
        cargarDatosPorDefectos()
        estadoCom = False
    End Sub

    Private Sub cargarDatosPorDefectos()
        zonas.SelectedIndex = 0
    End Sub

    Public zkvs As New Dictionary(Of String, Tuple(Of Integer, Integer)) ' zonas keyvalue store
    Private Sub cargarZonas()
        Dim r As DataTable = Persistencia.getInstancia.DevolverInformacionBasicaDeZonasPorID_lugar(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
        zonas.Items.Clear()
        zkvs.Clear()
        For i As Integer = 0 To r.Rows.Count - 1
            zkvs.Add(r.Rows(i).Item(1), New Tuple(Of Integer, Integer)(r.Rows(i).Item(0), r.Rows(i).Item(2)))
            zonas.Items.Add(r.Rows(i).Item(1))
        Next
    End Sub

    Private szkvs As New Dictionary(Of String, Tuple(Of Integer, Integer))
    Private Sub CargarSubzonas(zona As String)
        Dim r As DataTable = Persistencia.getInstancia.DevolverInformacionDeSubzonaPorIdZona(zkvs(zona).Item1, Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
        subzonas.Items.Clear()
        szkvs.Clear()

        For i As Integer = 0 To r.Rows.Count - 1
            szkvs.Add(r.Rows(i).Item(1), New Tuple(Of Integer, Integer)(r.Rows(i).Item(0), r.Rows(i).Item(2)))
            subzonas.Items.Add(r.Rows(i).Item(1))
        Next
    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged

        CargarSubzonas(zonas.SelectedItem)
        subzonas.SelectedIndex = 0
        zonaNombre.Text = zonas.SelectedItem
        zonaCapasidad.Text = zkvs(zonas.SelectedItem).Item2
        Try
            zonaUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(zkvs(zonas.SelectedItem).Item1)
        Catch ex As Exception
            zonaUso.Text = "0"
        End Try

    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        subnombre.Text = subzonas.SelectedItem
        subcapasidad.Text = szkvs(subzonas.SelectedItem).Item2
        Try
            subUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(szkvs(subzonas.SelectedItem).Item1)
        Catch ex As Exception
            subUso.Text = "0"
        End Try
        cargarTablaVehiculos(subzonas.SelectedItem)
    End Sub

    Private Sub cargarTablaVehiculos(subzona As String)

        Dim r As DataTable = Persistencia.getInstancia.DatosBasicosParaListarVehiculosPorSubzona(szkvs(subzona).Item1)

        vehi.DataSource = r
    End Sub

    Private Sub vehi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles vehi.CellContentClick
        'HACEMOS UN LLAMADO AL PANEL DE INFO DEL VEHICULO 
    End Sub
End Class