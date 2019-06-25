Public Class ListaZonas
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()


        cargarZonas()
        cargarDatosPorDefectos()
    End Sub

    Private Sub cargarDatosPorDefectos()
        zonas.SelectedIndex = 0
    End Sub

    Private Sub cargarZonas()
        Dim r As DataTable = SRepo.Consultar("select zona.nombre, zona.IDZona from zona, lugar where 
                                              zona.idlugar=lugar.idlugar and lugar.nombre='" & URepo.ConectadoEn & "'")
        zonas.Items.Clear()

        For i As Integer = 0 To r.Rows.Count - 1
            zonas.Items.Add(r.Rows(i).Item(0))
        Next
    End Sub

    Private Sub CargarSubzonas(zona As String)
        Dim r As DataTable = SRepo.Consultar("select subzona.nombre from subzona,zona,lugar where 
                                              subzona.idzona=zona.idzona and zona.idlugar=lugar.idlugar and 
                                              lugar.nombre='" & URepo.ConectadoEn & "' and zona.nombre='" & zona & "'")
        subzonas.Items.Clear()

        For i As Integer = 0 To r.Rows.Count - 1
            subzonas.Items.Add(r.Rows(i).Item(0))
        Next
    End Sub



    Private Sub zonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles zonas.SelectedIndexChanged

        CargarSubzonas(zonas.SelectedItem)
        zonaNombre.Text = zonas.SelectedItem
        zonaCapasidad.Text = SRepo.Consultar("select zona.capacidad from zona, lugar where zona.nombre='" & zonas.SelectedItem & "'
                                  And zona.IDLugar = Lugar.idLugar and Lugar.Nombre ='" & URepo.ConectadoEn & "'").Rows(0).Item(0)
        Try
            zonaUso.Text = SRepo.Consultar("select zona.nombre, count(vin) from subzona,zona,lugar,posicionado where
                                        subzona.idzona=zona.idzona and zona.idlugar=lugar.idlugar and
                                        lugar.nombre='" & URepo.ConectadoEn & "' and zona.nombre='" & zonas.SelectedItem & "'
                                        and subzona.idSub = posicionado.idsub
                                        group by zona.nombre").Rows(0).Item(1)
        Catch ex As Exception
            zonaUso.Text = "0"
        End Try

    End Sub


End Class