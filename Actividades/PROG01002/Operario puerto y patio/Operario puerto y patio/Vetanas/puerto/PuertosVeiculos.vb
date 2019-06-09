Public Class PuertosVeiculos

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        AddHandler añoTextBox.KeyPress, AddressOf Data.HandleNum
        AddHandler VINTextBox.KeyPress, AddressOf Data.HandleAlphaNum
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        Dim cd As New ColorDialog()
        cd.ShowDialog()
        ChromaPicture1.ChromaColor = cd.Color
        ColorButton.BackColor = cd.Color
        ChromaPicture1.Invalidate()
    End Sub

    Private Sub type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeComBox.SelectedIndexChanged
        Select Case typeComBox.Text
            Case "SUV"
                Me.ChromaPicture1.Image = My.Resources.SUV
            Case "Auto"
                Me.ChromaPicture1.Image = My.Resources.car
            Case Else
                Me.ChromaPicture1.Image = Nothing
        End Select
        Me.ChromaPicture1.Invalidate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim resultado As Integer
        Dim tryParse As Boolean = Integer.TryParse(añoTextBox.Text, resultado)
        If Not tryParse Then
            MsgBox("El año debe ser numérico")
            Return
        End If
        Dim vehiculo As New Data.Vehiculo(VINTextBox.Text, marcaTextBox.Text, modeloTextBox.Text, clienteImporta.Text, ColorButton.BackColor, resultado, typeComBox.SelectedItem, False, Usuario, lugar)
        If Not Data.Login.VehicleAdd(vehiculo) Then
            MsgBox("No se pudo registrar el vehiculo")
        Else
            Dim posCom = ODBCLogin.Connection.CreateCommand
            posCom.CommandText = "insert into posicionado(vin, subzona, desde, posicion) values(?, ?, ?, ?);"
            posCom.CrearParametro(Odbc.OdbcType.Char, "vin", VINTextBox.Text, False)
            posCom.CrearParametro(Odbc.OdbcType.Int, "zona", Me.zone, False)
            posCom.CrearParametro(Odbc.OdbcType.DateTime, "desde", DateTime.Now, False)
            posCom.CrearParametro(Odbc.OdbcType.Int, "pos", Me.pos, False)
            If posCom.ExecuteNonQuery = 1 Then
                UpdateTables()
            Else
                MsgBox("No se pudo posicionar el auto por algún error, informe al DBA de lo mismo.")
            End If
        End If
    End Sub
    Private _usuario As Data.User
    Public Property Usuario As Data.User
        Get
            Return _usuario
        End Get
        Set(value As Data.User)
            _usuario = value
            UpdateTables()
        End Set
    End Property

    Private Sub UpdateTables()
        Dim selcmd = ODBCLogin.Connection.CreateCommand()
        selcmd.CommandText = "select VIN, marca, modelo, lugar.nombre, clientenombre from vehiculo, lugar where vehiculo.puertoarriba=lugar.idlugar and lugar.idlugar=?;"
        selcmd.CrearParametro(Odbc.OdbcType.Int, "lugar", lugar, False)
        Dim dt = New DataTable("veiculos")
        dt.Load(selcmd.ExecuteReader)
        DataGridView1.DataSource = dt
        selcmd = ODBCLogin.Connection.CreateCommand()
        selcmd.CommandText = "select posicionado.vin as vehiculo, posicionado.posicion as posicion, subzona.nombre as EnSubzona, zona.nombre as EnZona, posicionado.desde as Desde from posicionado, subzona, zona where posicionado.subzona=subzona.idsub and subzona.zona=zona.idzona and zona.lugar=? and posicionado.hasta is null;"
        selcmd.CrearParametro(Odbc.OdbcType.Int, "lugar", lugar, False)
        Dim dt2 As New DataTable("vehiculosactuales")
        dt2.Load(selcmd.ExecuteReader)
        DataGridView2.DataSource = dt2
    End Sub

    Public padre As MarcoPuerto

    Public lugar As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ai = padre.cargarPanel(Of AgregarInspección)()
        Dim row = DataGridView1.SelectedRows.Item(0)
        Dim vin = row.Cells.Item(0).Value
        ai.vehiculo = vin
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        padre.cargarPanel(Of ListarInspecciones)().vin = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
    End Sub

    Public zone As Integer = -1
    Public pos As Integer = -1

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim p = padre.cargarPanel(Of seleccionsubzonas)()
        p.Usuario = Usuario
        p.papi = padre
    End Sub
End Class