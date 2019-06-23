Imports Operario.Logica

Public Interface LoteReceiver
    WriteOnly Property Lote As String
End Interface

Public Class NuevoLote
    Private parentLote As LoteReceiver
    Public Sub New(parent As LoteReceiver)
        Me.parentLote = parent
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        destino.Items.Clear()
        destino.Items.AddRange(LRepo.AllLugares.Select(Function(x) x.Nombre).ToArray)
        Prioridad.Items.Clear()
        Prioridad.Items.AddRange([Enum].GetNames(GetType(PrioridadLote)))
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
            parentLote.Lote = URepo.NewLote(0, nom.Text, destino.SelectedItem, Prioridad.SelectedItem)
            Me.Close()
        Else
            MsgBox("Error en la informacion ingresada", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class