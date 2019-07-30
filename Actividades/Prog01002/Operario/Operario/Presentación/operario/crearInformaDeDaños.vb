Imports Operario

Public Class crearInformaDeDaños
    Private idvehiculo As Integer
    Private _listaDeTodosLosinformes As List(Of Controladores.InformeDeDaños)
    Public Property ListaDeTodosLosInformes() As List(Of Controladores.InformeDeDaños)
        Get
            Return _listaDeTodosLosinformes
        End Get
        Set(ByVal value As List(Of Controladores.InformeDeDaños))
            _listaDeTodosLosinformes = value
        End Set
    End Property

    Private Info As Controladores.InformeDeDaños
    Public Sub New(id As Integer)
        idvehiculo = id
        InitializeComponent()
        tipo.SelectedIndex = 0
        TodosLosInformesYRegistros()
    End Sub

    Private Sub TodosLosInformesYRegistros()
        _listaDeTodosLosinformes = Controladores.Fachada.getInstancia.devolverInformesSoloConRegistros_IdYIdPropio(idvehiculo)
    End Sub

    Public ReadOnly Property InformeDeDaños() As Controladores.InformeDeDaños
        Get
            Return Info
        End Get
    End Property

    Private m As DataTable
    Private ReadOnly informe As Integer



    Private Sub descipt_TextChanged(sender As Object, e As EventArgs) Handles descipt.TextChanged
        Dim length As Integer = 255 - descipt.Text.Length
        cp.Text = length
        If length < 0 Then
            cp.ForeColor = Color.FromArgb(180, 20, 20)
        Else
            cp.ForeColor = Color.FromArgb(35, 35, 35)
        End If
    End Sub

    Private Sub nuevo_Click(sender As Object, e As EventArgs)
        Marco.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel(Me, Info.Registros.Count + 1, False))
    End Sub

    Private Sub eliminar_Click(sender As Object, e As EventArgs)
        If descipt.ReadOnly Then
            Return
        ElseIf Registros.SelectedIndex > 0 Then
            'Se debe eliminar el elemento de la lista
            Dim i As String = Registros.SelectedItem.split(":")(0)
            SRepo.ConsultarSinRetorno($"delete from imagenregistro where informe={informe} and nrolista={i};")
            SRepo.ConsultarSinRetorno($"delete from registrodanios where informe={informe} and nrolista={i};")
        End If
    End Sub

    Private Sub Registros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Registros.SelectedIndexChanged
        Dim reg As String = Registros.SelectedItem.Split(":")(0)
        descipt.Text = m.ToList.Where(Function(x) x("ID") = reg).Select(Of String)(Function(z) z("Descripcion")).Single
        Marco.getInstancia.cargarPanel(Of RegistroDeDañoPanel)(New RegistroDeDañoPanel(informe, Integer.Parse(reg), nuevo, Me))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If nuevo Then
            For Each i As String In Registros.Items
                SRepo.ConsultarSinRetorno($"delete from imagenregistro where informe={informe} and nrolista={i.Split(":")(0)};")
                SRepo.ConsultarSinRetorno($"delete from registrodanios where informe={informe} and nrolista={i.Split(":")(0)};")
            Next
        End If
        Marco.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
    End Sub

    Private Sub ingresarBtn_Click(sender As Object, e As EventArgs)
        If Not (VRepo.UpdateInformeDesc(informe, descipt.Text) AndAlso VRepo.UpdateInformeTipo(informe, tipo.SelectedItem)) Then
            MsgBox("no se pudo actualizar el informe")
        Else
            Marco.getInstancia.cerrarPanel(Of crearInformaDeDaños)()
        End If
    End Sub

    Public Sub Actualizar() Implements IActualizaMessage.Actualizar
        m = VRepo.Registros(VRepo.VINInforme(informe), informe).Item1
        Registros.Items.Clear()
        Registros.Items.AddRange(m.ToList.Select(Function(x) $"{x("ID")}: {x("Descripcion")}").ToArray)
    End Sub

    Public Sub devolverRegistro(r As Controladores.RegistroDaños)

    End Sub

    Private Sub Tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipo.SelectedIndexChanged

    End Sub
End Class