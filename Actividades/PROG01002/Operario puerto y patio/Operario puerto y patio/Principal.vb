Public Class Principal
    Private Shared initi As Principal

    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarPanel(Of Login)()
    End Sub

    Public Shared Function getInstancia() As Principal
        If initi Is Nothing Then
            initi = New Principal()
        End If
        Return initi
    End Function

    Public Sub cargarPanel(Of T As {Form, New})()

        Dim f As Form = contenedorDePaneles.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 
            f = New T()
            f.TopLevel = False
            f.FormBorderStyle = FormBorderStyle.None
            contenedorDePaneles.Controls.Add(f)
            contenedorDePaneles.Tag = f
            f.Show()
            f.BringToFront()
        Else
            f.BringToFront()
        End If

    End Sub


End Class
