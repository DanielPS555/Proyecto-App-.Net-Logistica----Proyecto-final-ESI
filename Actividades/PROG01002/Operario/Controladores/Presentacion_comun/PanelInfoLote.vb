Imports System.Drawing
Imports Controladores
Imports System.Windows.Forms
Imports Controladores.Extenciones.Extensiones
Public Class PanelInfoLote
    Private idlote As Integer
    Private milote As Controladores.Lote
    Public Sub New(nombrelote As String)
        Me.New(Fachada.getInstancia.InfoLote(Nombre:=nombrelote))
    End Sub

    Public Sub New(lote As Lote)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Traducir
        Label1.Text = $"{Label1.Text}: {lote.Nombre}"
        If lote.Destino Is Nothing Then
            lote = Fachada.getInstancia.InfoLote(ID:=lote.IDLote)
        End If
        'Label2.Traducir
        Label2.Text = $"{Label2.Text}: {lote.Destino.Nombre}"
        'Label3.Traducir
        Label3.Text = $"{Label3.Text}: {lote.Estado}"

        'Label4.Traducir
        Label4.Text = $"{Label4.Text}: {lote.Prioridad}"
        'Label5.Traducir
        Label5.Text = $"{Label5.Text}: {lote.FechaCreacion}"
        idlote = lote.IDLote
        Label7.Text = $"{Label7.Text}: {lote.Destino.Nombre}"
        Label6.Text = $"{Label6.Text}: {lote.IDLote}"
        Dim vehiculos = Fachada.getInstancia.VehiculosEnLote(idlote)
        For Each i In vehiculos
            Dim colorColumn = New Bitmap(50, 50)
            For x = 0 To 49
                For y = 0 To 49
                    colorColumn.SetPixel(x, y, i.Color)
                Next
            Next
            DataGridView1.Rows.Add(i.VIN, i.Marca, i.Modelo, i.Tipo, colorColumn, i.Cliente.Nombre)
        Next
        Me.milote = lote
        cargarestado()
    End Sub

    Private Sub cargarestado()
        If milote.Estado.Equals(Controladores.Lote.TIPO_ESTADO_ABIERTO) Then
            Button1.Visible = True
            Button1.Text = "Cerrar lote"
        Else
            Dim estate = Controladores.Fachada.getInstancia.UltimoEstadoLote(milote.IDLote)
            If estate Is Nothing OrElse estate.Equals(Controladores.Trasporte.TIPO_ESTADO_CANCELADO) Then
                Button1.Visible = True
                Button1.Text = "Abrir lote"
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If milote.Estado.Equals(Controladores.Lote.TIPO_ESTADO_ABIERTO) Then
            CType(sender, Button).Visible = Not (Fachada.getInstancia.CerrarLote(idlote))
            If CType(sender, Button).Visible Then
                MsgBox("El lote no fue cerrado porque uno o más vehículos no han sido inspeccionados")
            Else
                Label3.Text = $"Fase: Cerrado"
                milote.Estado = Controladores.Lote.TIPO_ESTADO_CERRADO
            End If
        Else
            Fachada.getInstancia.abirlote(milote.IDLote)
            Label3.Text = $"Fase: Abierto"
            milote.Estado = Controladores.Lote.TIPO_ESTADO_ABIERTO
        End If

        cargarestado()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub PanelInfoLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class