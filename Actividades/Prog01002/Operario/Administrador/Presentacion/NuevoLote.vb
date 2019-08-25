Imports Operario.Logica

Public Class NuevoLote
    Private padre As NotificacionDeLote
    Private destinosPosibles As List(Of Controladores.Lugar)
    Private origen As Controladores.Lugar
    Public Sub New(padre As NotificacionDeLote, lugar As Controladores.Lugar)
        ' Esta llamada es exigida por el diseñador.
        Me.origen = lugar
        Me.padre = padre
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Controladores.Fachada.getInstancia.devolverPosiblesDestinos(lugar, padre.dameVehiculoalLote)
        For Each l As Controladores.Lugar In destinosPosibles
            destino.Items.Add($"{l.Nombre}/{l.Tipo}")
        Next
        destino.SelectedIndex = 0
    End Sub
    Public Sub New(padre As NotificacionDeLote)
        Me.padre = padre
        Me.origen = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Controladores.Fachada.getInstancia.devolverPosiblesDestinos(Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar, padre.dameVehiculoalLote)
        For Each l As Controladores.Lugar In destinosPosibles
            destino.Items.Add($"{l.Nombre}/{l.Tipo}")
        Next
        destino.SelectedIndex = 0
    End Sub

    Public Sub New(padre As NotificacionDeLote, oldlote As Controladores.Lote)
        Me.padre = padre
        Me.origen = Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Controladores.Fachada.getInstancia.devolverPosiblesDestinos(Controladores.Fachada.getInstancia.TrabajaEnAcutual.Lugar, padre.dameVehiculoalLote)
        Dim c As Integer = 0
        For Each l As Controladores.Lugar In destinosPosibles
            destino.Items.Add($"{l.Nombre}/{l.Tipo}")
            If l.IDLugar = oldlote.Destino.IDLugar Then
                destino.SelectedIndex = c
            End If
            c += 1
        Next
        nom.Text = oldlote.Nombre
    End Sub

    Private Sub ingresar_Click(sender As Object, e As EventArgs)
        Dim verif As Integer = 1

        If nom.Text.Length = 0 Then
            verif = 0
            l_nom.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            l_nom.ForeColor = Color.FromArgb(35, 35, 35)
        End If

        If nom.Text.Length > 0 Then
            If nom.Text.Chars(0).Equals(" ") Then
                verif = 0
                l_nom.ForeColor = Color.FromArgb(180, 20, 20)
            End If
            l_nom.ForeColor = Color.FromArgb(35, 35, 35)
        End If



        If verif = 1 Then
            Dim lo As New Controladores.Lote With {.Nombre = nom.Text.Trim,
                                                    .Destino = destinosPosibles(destino.SelectedIndex),
                                                    .Estado = Controladores.Lote.TIPO_ESTADO_ABIERTO,
                                                    .Prioridad = Controladores.Lote.TIPO_PRIORIDAD_NORMAL,
                                                    .Origen = Me.origen,
                                                    .Creador = Controladores.Fachada.getInstancia.DevolverUsuarioActual,
                                                    .FechaCreacion = DateTime.Now}
            padre.NotificarLote(lo)
            Me.Dispose()
        Else
            MsgBox("Error en la informacion ingresada", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


End Class