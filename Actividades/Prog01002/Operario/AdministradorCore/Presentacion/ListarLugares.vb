Imports System.Windows.Forms
Imports Controladores.Extenciones.Extensiones
Public Class ListarLugares
    Private lugaresTabla As DataTable
    Private alfa As Controladores.Alfa
    Public Sub New()
        InitializeComponent()
        Label2.Traducir
        Button2.Traducir
        Button1.Traducir

        alfa = New Controladores.Alfa(GetType(Controladores.Lugar), GetType(Controladores.SUB_lugar), Sub(x) Controladores.Marco.getInstancia.CargarPanel(Of PanelLugar)(New PanelLugar(DirectCast(x, Controladores.Lugar).IDLugar)))
        Me.Controls.Add(alfa)
        alfa.Size = New Drawing.Size(855, 570)
        alfa.Location = New Drawing.Point(13, 68)
        cargarDatos()

    End Sub

    Private Sub cargarDatos()
        lugaresTabla = Controladores.Fachada.getInstancia.listarTodosLosLugares
        For Each r As DataRow In lugaresTabla.Rows
            alfa.Nuevo(New Controladores.Lugar() With {.IDLugar = r.Item(0), .Nombre = r.Item(1), .Tipo = r.Item(2)}, False)
        Next
        alfa.render()
    End Sub

    Private Sub Lugares_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Controladores.Marco.getInstancia.CargarPanel(Of PanelLugar)(New PanelLugar(lugaresTabla.Rows(e.RowIndex).Item(0)))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Controladores.Marco.getInstancia.CargarPanel(New Conectividad)
    End Sub

End Class