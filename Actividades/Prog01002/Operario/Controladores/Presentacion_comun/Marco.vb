Imports Controladores
Imports Controladores.Extenciones.Extensiones
Public Class Marco
    Private Shared initi As Marco = Nothing
    Public Shared Language As String = Funciones_comunes.Languages(0)

    Public Sub New()
        If paneles Is Nothing Then
            Throw New Exception("No se configuraron paneles para los botones")
        End If
        InitializeComponent()
        For Each key As String In paneles.Keys
            Dim btn As New Button With {
                .Text = Funciones_comunes.I18N(key, Language),
                .BackColor = b10.BackColor,
                .Dock = DockStyle.Top,
                .Font = b10.Font,
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
                                                  Marco.getInstancia.cargarPanel(newForm)
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


    Private Sub cerrarUltimo()
        If stack.Count = 0 Then
            Return
        End If
        Dim x = stack.Pop
        contenedor.Controls.Remove(x)
        x.Close()
    End Sub

    Public stack As New Stack(Of Form)

    Private Sub Marco_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.cargarPanel(Of Home)(New Home)
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
        cerrarUltimo()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Micuenta.Click
        MsgBox("¡Sin imploementar!")
    End Sub

    Public Function cargarPanelv2(Of T As {Form})(obj As T) As T ' No hay referencias a la función ni encuentro razón por la cual algún panel no debería ser pusheado al stack
        Return cargarPanel(obj, False)
    End Function

    Public Function cargarPanel(Of T As {Form})(obj As T, Optional pushToStack As Boolean = True) As T
        cerrarPanel(Of T)()
        If pushToStack Then
            stack.Push(obj)
        End If

        obj.TopLevel = False
        obj.FormBorderStyle = FormBorderStyle.None

        contenedor.Controls.Add(obj)
        contenedor.Tag = obj
        obj.Show()
        obj.BringToFront()
        Return obj
    End Function

    Private Sub b10_Click(sender As Object, e As EventArgs) Handles b10.Click
        Me.cargarPanel(New Home)
    End Sub
End Class