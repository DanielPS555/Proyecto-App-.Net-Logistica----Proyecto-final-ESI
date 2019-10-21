Public Class PanelDeFalloEstatus

    Private lotes As List(Of Controladores.Lote)
    Private listos As List(Of Integer)
    Private transporte As Controladores.Trasporte
    Private sec As Integer

    Public Sub New(lotes As List(Of Controladores.Lote), tran As Controladores.Trasporte)

        Me.lotes = lotes
        transporte = tran
        listos = New List(Of Integer)
        sec = 0
        InitializeComponent()
        cargarDatos()
        Timer1.Start()
        MsgBox("El transporte ha fallado el transporte, ahora estarán disponibles los lotes para todos los transportistas. Por favor no se retire de su ubicación hasta que hayan retirado todos los lotes, ya que se utilizará su ubicación para informar a los otros transportistas de la ubicación del lote", MsgBoxStyle.Exclamation)
    End Sub


    Private Sub cargarDatos()
        For Each l As Controladores.Lote In lotes
            Dim r As Integer = tabla.Rows.Add
            tabla.Rows(r).Cells(0).Value = l.Nombre
            tabla.Rows(r).Cells(1).Value = "Esperando"
        Next
    End Sub

    Private Function verificarDatos() As Boolean
        For i As Integer = 0 To lotes.Count - 1
            If Not listos.Contains(i) Then
                If Controladores.Fachada.getInstancia.UltimoTransportePorIdLote(lotes(i)) <> transporte.ID Then
                    listos.Add(i)
                    tabla.Rows(i).Cells(1).Value = "Recogido"
                End If
            End If
        Next

        If listos.Count = lotes.Count Then
            Timer1.Stop()
            estado.Text = $"Todos los lotes han sido recogido, por favor salga del transporte"
            aceptar.Enabled = True
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sec = 10 Then
            sec = 0
            Timer1.Stop()
            estado.Text = $"Verificacion en proseso......"
            verificarDatos()
            If Not verificarDatos() Then
                Timer1.Start()
            End If
        Else
            sec += 1
            estado.Text = $"Verificado en {10 - sec} segundos"
        End If
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles aceptar.Click
        Controladores.Marco.getInstancia.Desbloquear()
        Controladores.Marco.getInstancia.cerrarPanel(Of PanelTrasporteEnAccion)()
        Me.Close()
    End Sub

    Private Sub PanelDeFalloEstatus_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Not aceptar.Enabled
    End Sub
End Class