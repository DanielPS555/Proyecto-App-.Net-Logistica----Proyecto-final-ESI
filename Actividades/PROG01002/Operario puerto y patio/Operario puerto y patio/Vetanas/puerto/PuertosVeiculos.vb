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
        Dim vehiculo As New Data.Vehiculo(VINTextBox.Text, marcaTextBox.Text, modeloTextBox.Text, clienteImporta.Text, ColorButton.BackColor, resultado, typeComBox.SelectedItem, False, usuario, lugar)
        If Not Data.Login.VehicleAdd(vehiculo) Then
            MsgBox("No se pudo registrar el vehiculo")
        Else
            UpdateTable()
        End If
    End Sub
    Private _usuario As Data.User
    Public Property Usuario As Data.User
        Get
            Return _usuario
        End Get
        Set(value As Data.User)
            _usuario = value
            UpdateTable()
        End Set
    End Property

    Private Sub UpdateTable()
        Dim selcmd = ODBCLogin.Connection.CreateCommand()
        selcmd.CommandText = "select VIN, marca, modelo, lugar.nombre, clientenombre from vehiculo, lugar where vehiculo.puertoarriba=lugar.idlugar and lugar.idlugar=?;"
        selcmd.CrearParametro(Odbc.OdbcType.Int, "lugar", lugar, False)
        Dim dt = New DataTable("veiculos")
        dt.Load(selcmd.ExecuteReader)
        DataGridView1.DataSource = dt
    End Sub

    Public lugar As Integer
End Class