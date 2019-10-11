Imports Controladores

Public Class SUB_Notificacion
    Implements IAlfaInterface
    Private notifi As Notificacion

    Public Sub New(n As Notificacion)
        InitializeComponent()
        notifi = n
        Select Case n.Tipo
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_USUARIO
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref1))
                nom.Text = $"Nuevo usuario: {user.NombreDeUsuario}"
                sec.Text = $"Creado por {user.Creador.Nombre}"
        End Select


        fecha.Text = n.Fecha.ToString("HH:mm:ss dd-MMMM-yyyy")
    End Sub

    Public Sub darAncho(x As Integer) Implements IAlfaInterface.darAncho
        Me.Width = x
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements IAlfaInterface.darAlfa
        'NO
    End Sub

    Public Function dameForm() As Form Implements IAlfaInterface.dameForm
        Return Me
    End Function

    Public Function dameContenido() As Object Implements IAlfaInterface.dameContenido
        Return notifi
    End Function
End Class