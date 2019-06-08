Public Class ListarInspecciones
    Private _vin As String
    Public Property vin As String
        Get
            Return _vin
        End Get
        Set(value As String)
            _vin = value
            Dim selcmd = ODBCLogin.Connection.CreateCommand
            selcmd.CommandText = "select informedanios.id, vehiculo.vin, informedanios.fecha, informedanios.tipo from vehiculo, informedanios where vehiculo.vin=informedanios.vehiculosobre and vehiculo.vin=?;"
            selcmd.CrearParametro(Odbc.OdbcType.VarChar, "vin", vin, False)
            Dim dt As New DataTable("Informes")
            dt.Load(selcmd.ExecuteReader)
            Me.Informes.DataSource = dt
        End Set
    End Property

    Private Sub ListarInspecciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private imgs As New List(Of Bitmap)

    Private Sub UpdateRegistros() Handles Button1.Click
        If Informes.Rows.Count <= 0 Then
            Return
        End If
        Dim selcmd = ODBCLogin.Connection.CreateCommand
        selcmd.CommandText = "select rd, descripcion, imagen from registrodanios, imagenregistro where informedanios=? and rdid=rd;"
        selcmd.CrearParametro(Odbc.OdbcType.Int, "informe", Informes.SelectedRows.Item(0).Cells.Item(0).Value, True)
        Dim rgdt = New DataTable("Registros")
        rgdt.Load(selcmd.ExecuteReader)
        Registros.Items.Clear()
        For Each i As DataRow In rgdt.Rows
            Registros.Items.Add(i.Item(1))
            Dim img() As Byte = i.Item(2)
            Dim bmap As New Bitmap(New IO.MemoryStream(img))
            imgs.Add(bmap)
        Next
    End Sub

    Private Sub Registros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Registros.SelectedIndexChanged
        PictureBox1.Image = imgs(Registros.SelectedIndex)
    End Sub
End Class