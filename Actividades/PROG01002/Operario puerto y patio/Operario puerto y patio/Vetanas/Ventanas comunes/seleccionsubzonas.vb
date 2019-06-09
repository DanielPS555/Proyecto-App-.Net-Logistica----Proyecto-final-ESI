Imports Operario_puerto_y_patio

Public Class seleccionsubzonas
    Implements IHandlesUsers

    Private usr As Data.User
    Private cap As Integer
    Public Property Usuario As Data.User Implements IHandlesUsers.Usuario
        Get
            Return usr
        End Get
        Set(value As Data.User)
            usr = value
            Dim zonas = ODBCLogin.Connection.CreateCommand
            zonas.CommandText = "select idzona, zona.nombre from zona, lugar where lugar.idlugar = ? and lugar.idlugar = zona.lugar;"
            zonas.CrearParametro(Odbc.OdbcType.Int, "lugar", value.lugaractual, False)
            Dim subzonas = ODBCLogin.Connection.CreateCommand
            subzonas.CommandText = "select idsub, nombre, capacidad from subzona where zona = ?;"
            Dim sz = subzonas.CrearParametro(Odbc.OdbcType.Int, "zona", value.lugaractual, False)
            Dim er = zonas.ExecuteReader
            Dim datatable As New DataTable
            datatable.Load(er)
            Dim d As New DataTable
            For Each i As DataRow In datatable.Rows
                d.Load(subzonas.ExecuteReader)
                Dim nd As TreeNode = TreeView1.Nodes.Add(i.Item(1))
                nd.Name = "Zona"
                For Each si As DataRow In d.Rows
                    Dim capcount = ODBCLogin.Connection.CreateCommand()
                    capcount.CommandText = "select count(*) from posicionado, subzona where posicionado.subzona=subzona.idsub and posicionado.desde <= current and posicionado.hasta is null"
                    Dim n As TreeNode = nd.Nodes.Add(si.Item(1) & ": " & capcount.ExecuteScalar & "/" & d.Rows.Item(0).Item(2))
                    n.Name = "Subzona"
                    n.Tag = si
                Next
            Next
        End Set
    End Property

    Public papi As MarcoPuerto


    Private Sub seleccionsubzonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If TreeView1.SelectedNode.Name.Equals("Zona") Then
            Return
        End If
        Dim f_ = DirectCast(TreeView1.SelectedNode.Tag, DataRow)
        Dim f As Integer = f_.Item(0)
        Dim cmd = ODBCLogin.Connection.CreateCommand
        cmd.CommandText = "select count(*) from posicionado where hasta is null and posicion=? and subzona=?;"
        Dim pos = cmd.CrearParametro(Odbc.OdbcType.Int, "posicion", 0, False)
        cmd.CrearParametro(Odbc.OdbcType.Int, "subzona", f, False)
        Dim dt As New DataTable("lugares")
        dt.Columns.Add("posicion", GetType(Integer))
        dt.Columns.Add("ocupado", GetType(Boolean))
        For i As Integer = 0 To f_.Item(2) - 1
            pos.Value = i
            dt.Rows.Add({i, cmd.ExecuteScalar <> 0})
        Next
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not DirectCast(DataGridView1.SelectedRows(0).Cells(1).Value, Boolean) Then
            Dim f = papi.cargarPanel(Of PuertosVeiculos)
            f.zone = DirectCast(TreeView1.SelectedNode.Tag, DataRow).Item(0)
            f.pos = DataGridView1.SelectedRows(0).Cells(0).Value
            f.Button1.Enabled = True
        End If
    End Sub
End Class