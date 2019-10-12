Imports Controladores
Imports Controladores.Extenciones.Extensiones
Public Class Marco
    Private Shared initi As Marco = Nothing
    Public Shared Language As String = Funciones_comunes.Languages(0)
    Public CurrentPanel As ScreenNode = Nothing
    Public Shared Imagenes As Dictionary(Of String, Bitmap)

    Public Sub New()
        If paneles Is Nothing Then
            Throw New Exception("No se configuraron paneles para los botones")
        End If

        InitializeComponent()
        b10.Text = Funciones_comunes.I18N("Inicio", Language)
        acercaDe.Text = Funciones_comunes.I18N("Acerca de", Language)
        Micuenta.Text = Funciones_comunes.I18N("Mi cuenta", Language)
        Button1.Text = Funciones_comunes.I18N("Cerrar sesión", Language)
        Controladores.Fachada.getInstancia.CargarDataBaseDelUsuario()

        Controladores.Fachada.getInstancia.NuevaConexcion(Nothing) 'SI ES UN OPERARIO NO PASA NADA PORQUE YA FUE CREADA LA CONEXCION    
        For Each key As String In paneles.Keys
            If Not paneles(key).IsSubclassOf(GetType(Form)) Then
                Continue For
            End If
            Dim img As Image = Nothing
            If Imagenes.ContainsKey(key) Then img = New Bitmap(Imagenes(key), 48, 48)
            Dim btn As New Button With {
                .Text = Funciones_comunes.I18N(key, Language),
                .BackColor = b10.BackColor,
                .Dock = DockStyle.Top,
                .Font = b10.Font,
                .ImageAlign = ContentAlignment.MiddleRight,
                .Image = img,
                .TextAlign = b10.TextAlign,
                .FlatStyle = b10.FlatStyle,
                .UseVisualStyleBackColor = False,
                .Size = b10.Size,
                .ForeColor = b10.ForeColor
            }
            CopyFlat(b10, btn)
            AddHandler btn.Click, Sub()
                                      Dim constructores = paneles(key).GetConstructors() ' listar los constructores del tipo
                                      For Each k In constructores
                                          If k.GetParameters.Length < 1 Then
                                              Try
                                                  Dim newForm As Form = k.Invoke(Nothing)
                                                  Marco.getInstancia.CargarPanel(newForm)
                                                  Return
                                              Catch e As Exception
                                                  Console.WriteLine(e.ToString)
                                              End Try
                                          End If
                                      Next
                                      MsgBox("ERROR FATAL: No se encontraron constructores sin parámetros para el panel " + key)
                                  End Sub
            Panel5.Controls.Add(btn)

        Next
        If Not Fachada.getInstancia.Existenciadatosderecuperacion(Fachada.getInstancia.DevolverUsuarioActual.NombreDeUsuario) Then
            Dim e As New CredencialesUsuario(True)
            e.ShowDialog()
        End If
    End Sub

    Private Shared Sub CopyFlat(src As Button, dst As Button)
        dst.FlatAppearance.BorderColor = src.FlatAppearance.BorderColor
        dst.FlatAppearance.BorderSize = src.FlatAppearance.BorderSize
        dst.FlatAppearance.CheckedBackColor = src.FlatAppearance.CheckedBackColor
        dst.FlatAppearance.MouseDownBackColor = src.FlatAppearance.MouseDownBackColor
        dst.FlatAppearance.MouseOverBackColor = src.FlatAppearance.MouseOverBackColor
    End Sub

    Public Shared Sub ReiniciarSingleton()
        initi = Nothing
    End Sub

    Public Shared Function getInstancia() As Marco
        If initi Is Nothing Then
            CrearInstancia()
        End If
        Return initi
    End Function

    Public Shared Function CrearInstancia()
        If initi Is Nothing Then
            initi = New Marco()
        End If
        Return initi
    End Function

    Public Sub cerrarPanel(Of T As {Form})()
        contenedor.Controls.OfType(Of T).ForEach(Sub(x)
                                                     x.Close()
                                                     contenedor.Controls.Remove(x)
                                                 End Sub)
    End Sub

    Public Function InstanciaDe(Of T As {Form})() As T
        Return contenedor.Controls.OfType(Of T).FirstOrDefault
    End Function


    Private Sub CerrarUltimo()
        If CurrentPanel IsNot Nothing Then
            CurrentPanel.Close()
        End If
    End Sub

    Private Sub Marco_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Shared paneles As Dictionary(Of String, Type)

    Public Shared Sub SetButtons(paneles As Dictionary(Of String, Type))
        Marco.paneles = paneles
    End Sub


    Public Sub Bloquear()
        accion(False)
    End Sub

    Public Sub Desbloquear()
        accion(True)
    End Sub

    Private Sub accion(j As Boolean)
        b10.Enabled = j
        acercaDe.Enabled = j
        Micuenta.Enabled = j
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fachada.getInstancia.CerrarSeccion()
        Principal.getInstancia.cargarPanel(New Login)
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        CerrarUltimo()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Micuenta.Click
        Me.CargarPanel(Of PanelInfoUsuario)(New PanelInfoUsuario(Fachada.getInstancia.DevolverUsuarioActual.ID_usuario))
    End Sub

    Public Sub CargarPanel(sn As ScreenNode)
        Dim obj = sn.Panel
        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        If contenedor.Controls.Contains(obj) Then
            contenedor.Controls.Remove(obj)
        End If

        contenedor.Controls.Add(obj)
        obj.Show()
        obj.BringToFront()

        CurrentPanel = sn
    End Sub

    Public Function CargarPanel(Of T As {Form})(obj As T) As T
        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        contenedor.Controls.Add(obj)
        obj.Show()
        obj.BringToFront()

        Dim parent = If(Me.CurrentPanel Is Nothing, New Result(Of ScreenNode, Marco)(False, Me), New Result(Of ScreenNode, Marco)(True, CurrentPanel))
        Dim panelNode = New ScreenNode(parent, obj)
        CurrentPanel = panelNode
        Return obj
    End Function

    Private Sub b10_Click(sender As Object, e As EventArgs) Handles b10.Click
        Me.CargarPanel(New Home)
    End Sub

    Private Sub atras_Click(sender As Object, e As EventArgs) Handles atras.Click
        If CurrentPanel IsNot Nothing AndAlso CurrentPanel.Parent.Type Then
            Me.CargarPanel(CurrentPanel.Parent.A)
        End If
    End Sub

    Private Sub sigiente_Click(sender As Object, e As EventArgs) Handles sigiente.Click
        If CurrentPanel IsNot Nothing Then
            If CurrentPanel.Children.Count = 1 Then
                CargarPanel(CurrentPanel.Children.Single)
            ElseIf CurrentPanel.Children.Count > 1 Then
                Dim sn = ChildrenPane.GetChild(CurrentPanel)
                CargarPanel(sn)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CurrentPanel IsNot Nothing Then
            CurrentPanel.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Marco.getInstancia.CargarPanel(Of Notificaciones)(New Notificaciones())
    End Sub
End Class