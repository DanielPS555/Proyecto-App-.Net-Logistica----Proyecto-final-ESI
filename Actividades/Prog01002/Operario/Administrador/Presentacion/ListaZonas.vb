Imports Controladores
Imports Controladores.Extenciones

Public Class ListaZonas
    Private lugar As Lugar

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(lugar As Lugar)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        cargarZonas(lugar)
    End Sub

    Private Sub cargarZonas(lugar As Lugar)
        Dim zonaslist = Fachada.getInstancia.LugarZonasySubzonas(-1, lugar).Zonas
        zonas.Items.Clear()
        zonas.Items.AddRange(zonaslist.ToArray)
    End Sub

    Private subzonaslist As List(Of Subzona)

    Private Sub CargarSubzonas(zona As Zona)
        subzonas.Items.Clear()
        subzonaslist = zona.Subzonas
        subzonas.Items.AddRange(subzonaslist.ToArray)
    End Sub

    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged
        CargarSubzonas(zonas.SelectedItem)
        subzonas.SelectedIndex = 0
        zonaNombre.Text = zonas.SelectedItem.ToString
        zonaCapasidad.Text = CType(zonas.SelectedItem, Zona).Capacidad
        Try
            zonaUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(CType(zonas.SelectedItem, Zona).IDZona)
        Catch ex As Exception
            zonaUso.Text = "0"
        End Try

    End Sub

    Private Sub subzonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subzonas.SelectedIndexChanged
        subnombre.Text = subzonas.SelectedItem.ToString
        subcapasidad.Text = CType(subzonas.SelectedItem, Subzona).Capasidad
        Try
            subUso.Text = Persistencia.getInstancia.PosicionesOcupadasEnLugar(CType(subzonas.SelectedItem, Subzona).IDSubzona)
        Catch ex As Exception
            subUso.Text = "0"
        End Try
        cargarTablaVehiculos(subzonas.SelectedItem)
    End Sub

    Private Sub cargarTablaVehiculos(subzona As Subzona)

        Dim r As DataTable = Persistencia.getInstancia.DatosBasicosParaListarVehiculosPorSubzona(subzona.IDSubzona)

        vehi.DataSource = r
    End Sub

    Private Sub vehi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles vehi.CellContentClick
        'HACEMOS UN LLAMADO AL PANEL DE INFO DEL VEHICULO 
    End Sub
End Class