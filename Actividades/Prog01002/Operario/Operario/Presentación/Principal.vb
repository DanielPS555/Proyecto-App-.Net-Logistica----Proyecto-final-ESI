Public Class Principal
    Private Shared initi As Principal

    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        Constantes.LRepo = New FLugarRepo
        Constantes.URepo = New FUsuarioRepo
        Constantes.URepo.Registrar("superadmin", "aaaxd",
                                          "a", "b", "c", "d",
                                          "no", "tampoco",
                                          Logica.Sexo.Otro, "admin@sgla.com.uy",
                                          "*911", Logica.Constantes.Roles.Where(Function(x) x.Nombre = "Admin").Single)
        Constantes.LRepo.AllLugares.Add(New Logica.Lugar("Puerto de montevideo", 200, New PointF(-35, -35), Constantes.URepo.UsuarioPorNombre("superadmin"), Logica.TipoLugar.Puerto, New List(Of Logica.Zona), New List(Of Logica.Lote)))
        Constantes.LRepo.AllLugares.First.Zonas.Add(New Logica.Zona(New List(Of Logica.Subzona), Constantes.LRepo.AllLugares.First))
        Constantes.LRepo.AllLugares.First.Zonas.First.Subzonas.Add(New Logica.Subzona(Constantes.LRepo.AllLugares.First.Zonas.First, New List(Of Logica.Posicionado)))
        Constantes.URepo.Registrar("usuarioprueba", "usrprueba", "Juan", "Ito", "Cho", "Talarga", "Si?", "Si", Logica.Sexo.Masculino, "darkfm@vera.com.uy", "N/A", Logica.Constantes.Roles.Where(Function(x) x.Nombre = "Operario").Single)
        Logica.TrabajaEn.AgregarALugar(Constantes.URepo.UsuarioPorNombre("usuarioprueba"), LRepo.AllLugares.First)
        Constantes.VRepo = New FVehiculoRepo
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarPanel(Of Login)(New Login)
    End Sub

    Public Shared Function getInstancia() As Principal
        If initi Is Nothing Then
            initi = New Principal
        End If
        Return initi
    End Function

    Public Function cargarPanel(Of T As Form)(obj As T) As T

        Dim f As Form = contenedorDePaneles.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 

            obj.TopLevel = False
            obj.FormBorderStyle = FormBorderStyle.None
            obj.Dock = DockStyle.Fill
            contenedorDePaneles.Controls.Add(obj)
            contenedorDePaneles.Tag = obj
            obj.Show()
            obj.BringToFront()
            Return obj
        Else
            f.BringToFront()
            Return f
        End If

    End Function

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End Sub

    Private Sub contenedorDePaneles_Paint(sender As Object, e As PaintEventArgs) Handles contenedorDePaneles.Paint

    End Sub
End Class
