Imports System.Threading

Public Class Principal
    Private Shared initi As Principal

    Public Sub New()

        'Esta llamada es exigida por el diseñador.
        'Dim U = New SQLRepo()
        'Constantes.URepo = U
        'U.usuarios.Add(New Logica.Usuario(1, New List(Of Logica.TrabajaEn), "Felipe3", "", "Felipe", Nothing, "Camacho", Nothing, "Cual fue su primer juego?", "Lol", Date.Now, Logica.Sexo.Masculino, "felip49@gmail.com", "096515746", Logica.Constantes.RoleFromID(3), Nothing))
        'LRepo.AllLugares.Add(New Logica.Lugar(1, "Puerto de Montevideo", 300, New PointF(0, 0), U.usuarios.Single, Logica.TipoLugar.Puerto, New List(Of Logica.Zona), New List(Of Logica.Lote)))
        'LRepo.AllLugares.Single.Zonas.Add(New Logica.Zona(New List(Of Logica.Subzona), LRepo.AllLugares.Single, "Zona A", 1))
        'LRepo.AllLugares.Single.Zonas.Single.Subzonas.Add(New Logica.Subzona(LRepo.AllLugares.Single.Zonas.Single, New List(Of Logica.Posicionado), "SZona 1", 1))
        'VRepo.Vehiculos.Add(New Logica.Vehiculo("A", Nothing, Nothing, Nothing, Nothing, Logica.TipoVehiculo.Auto, False, "nadie", LRepo.AllLugares.Single.ID, Date.Now, New List(Of Logica.InformeDaños)))
        'U.usuarios.Add(New Logica.Usuario(2, New List(Of Logica.TrabajaEn), "john", Logica.Usuario.ContraseñaHash("abcdef", "john"), "Juan", Nothing, "Talarga", Nothing, "Preguntas", "Sabes", Date.Now, Logica.Sexo.Masculino, "aaa@nada.com", "", Logica.Constantes.RoleFromID(1), U.usuarios.Single))
        'Dim sr = URepo.UsuarioPorNombre("john")
        'sr.TrabajaEn.Add(New Logica.TrabajaEn(1, LRepo.AllLugares.Single, sr, Date.Now, Nothing, New List(Of Logica.Conexion)))
        InitializeComponent()
        StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarPanel(Of Login)(New Login)
        initi = Me
    End Sub

    Public Shared Function getInstancia() As Principal
        If initi Is Nothing Then
            initi = New Principal
        End If
        Return initi
    End Function

    Public Function cerrarPanel(Of T As Form)() As Boolean
        contenedorDePaneles.Controls.OfType(Of T).ForEach(Sub(x As Form)
                                                              x.Close()
                                                              contenedorDePaneles.Controls.Remove(x)
                                                          End Sub)
        Return True
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
            f.Show()
            f.BringToFront()
            Return f
        End If

    End Function

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If URepo IsNot Nothing Then
            URepo.Desconectar()
        End If
    End Sub
End Class
