Public Class panelInfoVehiculo
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        regularTamañoColumnas()



    End Sub



    Public Sub regularTamañoColumnas()
        informes.Columns(0).Width = 60
        informes.Columns(1).Width = 200
        informes.Columns(2).Width = 200
        informes.Columns(3).Width = 150
        informes.Columns(4).Width = 150
        informes.Columns(5).Width = 60
        Me.Height = 3000

        'DATOS PRUEBA
        informes.Rows.Add("Juana", "pep", 3, 4, 5)
        informes.Rows.Add("Juana", "pep", 3, 4, 5)
        informes.Rows.Add("Juana", "pep", 3, 4, 5)

        traslados.Columns(0).Width = 200
        traslados.Columns(1).Width = 200
        traslados.Columns(2).Width = 175
        traslados.Columns(3).Width = 175
        traslados.Columns(4).Width = 175
        traslados.Columns(5).Width = 225

        lugares.Columns(0).Width = 225
        lugares.Columns(1).Width = 225
        lugares.Columns(2).Width = 225
        lugares.Columns(3).Width = 225
        lugares.Columns(4).Width = 225
        lugares.Columns(5).Width = 225

    End Sub

    Private Sub panelInfoVehiculo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        g.DrawRectangle(New Pen(Color.FromArgb(15, 139, 196), 2), New Rectangle(informes.Location, informes.Size))
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' nos lleva a la ventana nuevovehiculo pero ya con la infocargada 
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MarcoPuerto.getInstancia.cargarPanel(Of trasladoInterno)(New trasladoInterno)
    End Sub
End Class