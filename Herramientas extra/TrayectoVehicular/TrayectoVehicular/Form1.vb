Public Class Form1
    Private conn As Odbc.OdbcConnection
    Private Function IDLugar(nombre As String) As Integer
        Dim selcmd As New Odbc.OdbcCommand("select idlugar from lugar where nombre=?", conn)
        Dim par = New Odbc.OdbcParameter()
        par.DbType = DbType.String
        par.Value = nombre
        selcmd.Parameters.Add(par)
        Return selcmd.ExecuteScalar
    End Function
    Private Function SubzonasLugar(lugar As Integer) As List(Of String)
        Dim selcmd As New Odbc.OdbcCommand("select nombre from lugar inner join
            (select menor from incluye
              start with mayor=?
              connect by prior menor=mayor) as cb on lugar.idlugar=cb.menor
              where lugar.tipo='Subzona'", conn)
        Dim par = New Odbc.OdbcParameter()
        par.DbType = DbType.Int32
        par.Value = lugar
        selcmd.Parameters.Add(par)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        Dim lst As New List(Of String)
        For Each i As DataRow In dt.Rows
            lst.Add(i.Item(0))
        Next
        Return lst
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New Odbc.OdbcConnection("FileDsn=C:\Users\alumno\Documents\a.dsn;Pwd=diewithtf;")
        conn.Open()
        Dim selcmd As New Odbc.OdbcCommand("select VIN from vehiculo;", conn)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        For Each i As DataRow In dt.Rows
            ListBox1.Items.Add(i.Item(0))
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim selcmd As New Odbc.OdbcCommand("select l1.nombre, l2.nombre, lote.nombre, mediotransporte.nombre from vehiculo inner join integra on integra.idvehiculo=vehiculo.idvehiculo inner join lote on integra.lote=lote.idlote inner join transporta on transporta.idlote=lote.idlote inner join transporte on transporte.transporteid=transporta.transporteid inner join mediotransporte on mediotransporte.idtipo=transporte.idtipo and mediotransporte.idlegal=transporte.idlegal inner join lugar as l1 on l1.idlugar=lote.origen inner join lugar as l2 on l2.idlugar=lote.destino where vehiculo.vin=? and integra.invalidado='f'", conn)
        Dim p As New Odbc.OdbcParameter()
        p.DbType = DbType.StringFixedLength
        p.Value = ListBox1.SelectedItem
        selcmd.Parameters.Add(p)
        Dim rdr = selcmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(rdr)
        ListBox2.Items.Clear()
        For Each i As DataRow In dt.Rows
            ListBox2.Items.Add(i.Item(0) & " -> " & i.Item(1) & "(" & i.Item(2) & ") a través de " & i.Item(3))
        Next
    End Sub
End Class
