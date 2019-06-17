Public Class MarcoPuerto
    Private Shared initi As MarcoPuerto
    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Shared Function getInstancia() As MarcoPuerto
        If initi Is Nothing Then
            initi = New MarcoPuerto
        End If
        Return initi
    End Function

    Public Function cargarPanel(Of T As {Form})(obj As T) As T
        Dim f As Form = contenedor.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 

            obj.TopLevel = False
            obj.FormBorderStyle = FormBorderStyle.None

            contenedor.Controls.Add(obj)
            contenedor.Tag = obj
            obj.Show()
            obj.BringToFront()
            Return obj
        Else
            f.BringToFront()
            Return f
        End If

    End Function

    Private Sub MarcoPuerto_Load(sender As Object, e As EventArgs) Handles Me.Load
        inicio.Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.cargarPanel(Of OperarioHome)(New OperarioHome) 'despues se pasa por parametro un operario
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles veiculos.Click, nuevoVehiculo.Click, lotes.Click, ListaZona.Click, inicio.Click
        Dim botones() As Button = {inicio, lotes, veiculos, nuevoVehiculo, ListaZona}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                If botones(i).Equals(nuevoVehiculo) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
                End If

            Else
                If botones(i).Equals(nuevoVehiculo) Then
                    botones(i).Font = New Font("Century Gothic", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Else
                    botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                End If

            End If
        Next

        Select Case selec.Name
            Case "inicio"
                Dim pInicio = cargarPanel(Of OperarioHome)(New OperarioHome)
            Case "veiculos"
                Dim pVeiculos = cargarPanel(Of ListaVehiculos)(New ListaVehiculos)
            Case "lotes"
                cargarPanel(Of ListaLotes)(New ListaLotes)
            Case "nuevoVehiculo"
                cargarPanel(Of nuevoVehiculo)(New nuevoVehiculo)
        End Select

    End Sub

End Class