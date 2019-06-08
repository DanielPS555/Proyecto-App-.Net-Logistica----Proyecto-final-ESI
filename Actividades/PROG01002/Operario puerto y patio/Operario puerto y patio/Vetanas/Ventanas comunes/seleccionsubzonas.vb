Imports Operario_puerto_y_patio

Public Class seleccionsubzonas
    Implements IHandlesUsers

    Private usr As Data.User
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
                For Each si As DataRow In d.Rows
                    Dim capcount = ODBCLogin.Connection.CreateCommand()
                    capcount.CommandText = "select count(*) from posicionado, subzona where posicionado.subzona=subzona.idsub and posicionado.desde <= current and posicionado.hasta is null"
                    Dim n As TreeNode = nd.Nodes.Add(si.Item(1) & capcount.ExecuteScalar & "/" & d.Rows.Item(0).Item(2))
                    n.Tag = 
                Next
            Next
        End Set
    End Property


    Private Sub seleccionsubzonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class