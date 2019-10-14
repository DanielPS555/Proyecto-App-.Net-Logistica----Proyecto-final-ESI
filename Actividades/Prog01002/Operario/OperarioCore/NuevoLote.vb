Imports Controladores
Imports System.Drawing
Imports System.Windows.Forms

Public Class NuevoLote

    Private padre As NotificacionLote
    Private destinosPosibles As List(Of Lugar)
    Private origen As Lugar

    Public Sub New(padre As NotificacionLote, lugar As Lugar)
        ' Esta llamada es exigida por el diseñador.
        Me.origen = lugar
        Me.padre = padre
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destinosPosibles = Fachada.getInstancia.devolverPosiblesDestinos(lugar, padre.dameVehiculoalLote)
        For Each l As Lugar In destinosPosibles
            destino.Items.Add(l)
        Next
        destino.SelectedIndex = 0
    End Sub



    Public Sub New(padre As NotificacionLote, oldlote As Lote)
        Me.origen = oldlote.Origen
        Me.padre = padre
        Me.nom.Text = oldlote.Nombre
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        destino.Items.Clear()
        destinosPosibles = Fachada.getInstancia.devolverPosiblesDestinos(oldlote.Origen, padre.dameVehiculoalLote)
        For Each l As Lugar In destinosPosibles
            destino.Items.Add(l)
        Next
        destino.SelectedItem = oldlote.Destino
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
            Dim lo As New Lote With {.Nombre = nom.Text.Trim,
                                                    .Destino = destino.SelectedItem,
                                                    .Estado = Lote.TIPO_ESTADO_ABIERTO,
                                                    .Prioridad = Lote.TIPO_PRIORIDAD_NORMAL,
                                                    .Origen = origen,
                                                    .Creador = Fachada.getInstancia.DevolverUsuarioActual,
                                                    .FechaCreacion = Date.Now}
            padre.NotificarLote(lo)
            Dispose()
        Else
            Extenciones.MsgBoxI18N("Error en la informacion ingresada", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
End Class