#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1307
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports System.Data.SqlClient
Imports Microsoft.Exchange.WebServices.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmMenú
    Private nSegundos As Integer = 600

    Private Sub Menú_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtFestivos, dtUsuario As DataTable
        Dim cTexto As String
        Dim iconList As ImageList = New ImageList With {
            .ImageSize = New Size(24, 24),
            .TransparentColor = Color.White
        }

        lblCronómetro.Text = ""
        lblCronómetro.Visible = False
        picBomba.Visible = False

        iconList.Images.Add("bolsa", My.Resources.bolsa)                    ' 0
        iconList.Images.Add("cesta", My.Resources.cesta)
        iconList.Images.Add("procedimiento", My.Resources.procedimiento)
        iconList.Images.Add("incidencia", My.Resources.incidencia)
        iconList.Images.Add("ticket", My.Resources.ticket)
        iconList.Images.Add("inventario", My.Resources.inventario)          ' 5
        iconList.Images.Add("proveedor", My.Resources.proveedor)
        iconList.Images.Add("articulo", My.Resources.articulo)
        iconList.Images.Add("operador", My.Resources.operador)
        iconList.Images.Add("factura", My.Resources.factura)
        iconList.Images.Add("reparacion", My.Resources.reparacion)          ' 10
        iconList.Images.Add("empresas", My.Resources.decimas_peq)
        iconList.Images.Add("pedidos", My.Resources.pedidos)
        iconList.Images.Add("compras", My.Resources.carro)
        iconList.Images.Add("acercade", My.Resources.acercade)
        iconList.Images.Add("albaran", My.Resources.albaran)                ' 15
        iconList.Images.Add("parametros", My.Resources.parametros)
        iconList.Images.Add("money", My.Resources.money)
        iconList.Images.Add("operador", My.Resources.operador)
        iconList.Images.Add("empresa", My.Resources.empresa)
        iconList.Images.Add("merchant", My.Resources.merchant)              ' 20
        iconList.Images.Add("estado", My.Resources.estado)
        iconList.Images.Add("Milenium", My.Resources.Milenium)
        iconList.Images.Add("access", My.Resources.access)
        iconList.Images.Add("procedimiento", My.Resources.procedimiento)
        iconList.Images.Add("proveedor", My.Resources.proveedor)               ' 25
        iconList.Images.Add("pedidos2", My.Resources.pedidos2)
        iconList.Images.Add("carro", My.Resources.carro)
        iconList.Images.Add("incidenciasresueltas", My.Resources.barras)
        iconList.Images.Add("festivos", My.Resources.festivos)
        iconList.Images.Add("spain", My.Resources.spain)                        ' 30
        iconList.Images.Add("routerinalámbrico", My.Resources.routerinalámbrico)
        iconList.Images.Add("incidecia", My.Resources.incidencia)
        iconList.Images.Add("intranet", My.Resources.intranet)
        iconList.Images.Add("telefono", My.Resources.telefono)
        iconList.Images.Add("chat", My.Resources.chat)                          ' 35
        iconList.Images.Add("limpieza", My.Resources.limpieza)

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TeamViewer", Nothing) Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Software\Sport Street\Informática")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TeamViewer", "")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "UVNC", "")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", "")
            frmParámetros.ShowDialog()
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", "")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", "")
            frmParámetros.ShowDialog()
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", "")
            frmParámetros.ShowDialog()
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", "0")
            frmParámetros.ShowDialog()
        End If

        'picUsuario.BackgroundImage = My.Resources.usuario
        picUsuario.Image = My.Resources.operador
        lblUsuario.Text = ""

        dtUsuario = CargaTabla("SELECT nombre, icono FROM operadores WHERE login = " + GrabaComillas(cUsuario))

        If dtUsuario.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(dtUsuario.Rows(0)("icono").ToString) Then
                If System.IO.File.Exists(dtUsuario.Rows(0)("icono")) Then picUsuario.Image = Image.FromFile(dtUsuario.Rows(0)("icono"))
                lblUsuario.Text = dtUsuario.Rows(0)("nombre")
            End If
        End If

        'Select Case cUsuario
        '    Case "rafael"
        '        picUsuario.Image = My.Resources.superman
        '        lblUsuario.Text = "Rafael Altungy"

        '    Case "fernando"
        '        picUsuario.Image = My.Resources.comiendo
        '        lblUsuario.Text = "Fernando García-Monzón"

        '    Case "iker"
        '        picUsuario.Image = My.Resources.iker
        '        lblUsuario.Text = "Iker de Miguel"

        '    Case "juancar"
        '        picUsuario.Image = My.Resources.mazingerZ
        '        lblUsuario.Text = "Juan Carlos Campos"

        '    Case "miguel"
        '        picUsuario.Image = My.Resources.miguel
        '        lblUsuario.Text = "Miguel Juez"

        '    Case "calin"
        '        picUsuario.Image = My.Resources.calin
        '        lblUsuario.Text = "Calin Orasanu"

        '    Case "alberto"
        '        lblUsuario.Text = "Alberto Macho"

        '    Case "Agus"
        '        picUsuario.Image = My.Resources.agustín
        '        lblUsuario.Text = "Agustín Moreno"

        '    Case "ignacio"
        '        lblUsuario.Text = "Ignacio Lancho"

        '    Case "juliam"
        '        lblUsuario.Text = "Julia Molina"

        '    Case Else
        '        lblUsuario.Visible = False
        'End Select

        groupUsuario.Text = lblUsuario.Text

        lblCopy.Text = "© 2012 - 2019" + Chr(10) + Chr(13) + "Sport Street Informática"
        TabControl.ImageList = iconList

        dtFestivos = CargaTabla("SELECT * FROM festivos WHERE fecha = " + DtoSQL(Now))
        cTexto = ""

        If dtFestivos.Rows.Count > 0 Then
            For n = 0 To dtFestivos.Rows.Count - 1
                cTexto += dtFestivos.Rows(n)("poblacion") + " (" + dtFestivos.Rows(n)("tipo") + ")" + vbCrLf
            Next

            txtFestivos.Text = cTexto
        Else
            lblFestivo.Visible = False
            txtFestivos.Visible = False
        End If

        Redimensiona(sender, e)

        IncidenciasPendientes()
        lblCronómetro.Visible = True
        timerPendientes.Start()
        timerCuentaAtrás.Start()
        timerChat.Start()
    End Sub

    Private Sub Redimensiona(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim x, y, nAncho, nAlto As Integer

        For Each frm In My.Application.OpenForms
            If frm.Name = "frmMenú" Then
                Dim Current_Screen As Screen = Screen.FromControl(Me.picCopa)
                Dim nAnchoMenú, nAltoMenú As Integer

                nAltoMenú = Math.Max(Me.Height, panelMenú.Height + chartResueltas.Height + picCopa.Height + txtFestivos.Height + 30 + picUsuario.Height + 300)
                nAnchoMenú = Math.Max(Me.Width, panelMenú.Width + groupUsuario.Width + groupSinAsignar.Width + groupTotal.Width + 400)
                Me.Size = New Size(nAnchoMenú, nAltoMenú)

                If Current_Screen.Primary = False Then
                    x = Current_Screen.Bounds.Left
                    y = Current_Screen.Bounds.Top
                Else
                    x = 0
                    y = 0
                End If

                frm.Location = New Point(x, y)
                Exit For
            End If
        Next

        TabControl.Height = Me.Height - groupSinAsignar.Height - 90
        TabControl.Width = Me.Width - panelMenú.Size.Width - 60
        TabControl.Location = New Point(panelMenú.Size.Width + 30, 34)

        picDécimas.Location = New Point(TabControl.Width / 2 - 350 + panelMenú.Size.Width, TabControl.Height - 100)
        picPolinesia.Location = New Point(TabControl.Width / 2 - 200 + panelMenú.Size.Width, TabControl.Height - 75)
        picInvain.Location = New Point(TabControl.Width / 2 + 50 + panelMenú.Size.Width, TabControl.Height - 75)
        picAdidas.Location = New Point(TabControl.Width / 2 + 300 + panelMenú.Size.Width, TabControl.Height - 100)
        picSport.Location = New Point(35, Me.Height - 135)
        lblCopy.Location = New Point(15, Me.Height - 100)
        chartResueltas.Location = New Point(panelMenú.Location.X, panelMenú.Location.Y + panelMenú.Size.Height + 30)
        picUsuario.Location = New Point(40, chartResueltas.Location.Y + chartResueltas.Size.Height + 30)
        lblUsuario.Location = New Point(0, chartResueltas.Location.Y + chartResueltas.Size.Height + 85)
        picCopa.Location = New Point(chartResueltas.Location.X + chartResueltas.Size.Width - picCopa.Width, chartResueltas.Location.Y + chartResueltas.Size.Height + 30)
        lblFestivo.Location = New Point(15, picCopa.Location.Y + picCopa.Size.Height + 30)
        txtFestivos.Location = New Point(15, lblFestivo.Location.Y + lblFestivo.Size.Height + 5)

        groupSinAsignar.Location = New Point(Me.Width / 2 - groupSinAsignar.Width / 2 + panelMenú.Size.Width / 2, Me.Height - groupSinAsignar.Height - 50)
        groupUsuario.Location = New Point(Me.Width / 2 - groupUsuario.Width - groupSinAsignar.Width / 2 - 40 + panelMenú.Size.Width / 2, Me.Height - groupUsuario.Height - 50)
        groupTotal.Location = New Point(Me.Width / 2 + groupSinAsignar.Width / 2 + 40 + panelMenú.Size.Width / 2, Me.Height - groupTotal.Height - 50)
        picBomba.Location = New Point(groupTotal.Location.X + groupTotal.Width + 20, groupTotal.Location.Y + groupTotal.Height / 2 - 10)
        lblActualización.Location = New Point(groupTotal.Location.X + groupTotal.Width + 60, groupTotal.Location.Y + groupTotal.Height / 2)
        lblCronómetro.Location = New Point(groupTotal.Location.X + groupTotal.Width + 60, groupTotal.Location.Y + groupTotal.Height / 2)
        'lblUsuarioIncidenciasPendientes.Text = ""
        'lblUsuarioCorreosPendientes.Text = ""
        'lblSinAsignarIncidencias.Text = ""
        'lblSinAsignarCorreos.Text = ""
        'lblTotalIncidencias.Text = ""
        'lblTotalCorreos.Text = ""
        btnIncidencias.Location = New Point(TabControl.Location.X, groupTotal.Location.Y + groupTotal.Height / 2 - 10)
        lblIncidencias.Location = New Point(btnIncidencias.Location.X + 30, btnIncidencias.Location.Y + 8)
        btnIntranet.Location = New Point(btnIncidencias.Location.X + 100, btnIncidencias.Location.Y)
        lblIntranet.Location = New Point(lblIncidencias.Location.X + 100, lblIncidencias.Location.Y)
        btnExtensiones.Location = New Point(btnIntranet.Location.X + 80, btnIntranet.Location.Y)
        lblExtensiones.Location = New Point(lblIntranet.Location.X + 80, lblIntranet.Location.Y)

        nAncho = TabControl.Size.Width
        nAlto = TabControl.Size.Height

        For Each frm In My.Application.OpenForms
            If frm.Name <> "frmMenú" Then
                x = (nAncho - frm.Size.Width) / 2
                y = (nAlto - frm.Size.Height) / 2 - 100
            End If

            frm.Location = New Point(x, y)
        Next
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub OperadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperadoresToolStripMenuItem.Click
        MuestraForm(frmOperadores, "Operadores", "tpOperadores", 18)
    End Sub

    Private Sub EmpresasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresasToolStripMenuItem.Click
        MuestraForm(FrmEmpresas, "Empresas", "tpEmpresas", 19)
    End Sub

    Private Sub RótulosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MuestraForm(FrmTablas, "Rótulos", "tpRotulos", "Rótulos", 0)
    End Sub

    Private Sub MerchantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MerchantsToolStripMenuItem.Click
        MuestraForm(FrmTablas, "Merchants", "tpMerchants", "Merchants", 20)
    End Sub

    Private Sub EstadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadosToolStripMenuItem.Click
        MuestraForm(FrmTablas, "Estados", "tpEstados", "Estados", 21)
    End Sub

    Private Sub TPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TPToolStripMenuItem.Click
        MuestraForm(FrmAlbaranes, "TP", "tpAlbaranes", 15)
    End Sub

    Private Sub IntegridadDeLaMonedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntegridadDeLaMonedaToolStripMenuItem.Click
        MuestraForm(FrmIntegridad, "Integridad", "tpIntegridad", 17)
    End Sub

    Private Sub ProcedimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcedimientosToolStripMenuItem.Click
        MuestraForm(FrmProcedimientos, "Procedimientos", "tpProcedimientos", 24)
    End Sub

    Private Sub TiendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiendasToolStripMenuItem.Click
        MuestraForm(FrmTiendas, "Tiendas", "tpTiendas", 0)
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        MuestraForm(FrmProveedores, "Proveedores", "tpProveedores", 25)
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        MuestraForm(FrmArticulos, "Artículos", "tpArtículos", 7)
    End Sub

    Private Sub FacturaciónInternaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónInternaToolStripMenuItem.Click
        MuestraForm(FrmFacturaciónInterna, "Facturación interna", "tpFacturaciónInterna", 9)
    End Sub

    Private Sub RoutersInalámbricosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoutersInalámbricosToolStripMenuItem.Click
        MuestraForm(FrmRoutersInalámbricos, "FRouters inalámbricos", "tpRoutersInalámbricos", 31)
    End Sub

    Private Sub FormasDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormasDePagoToolStripMenuItem.Click
        MuestraForm(frmFormasPago, "Formas de pago", "tpFormasPago", 17)
    End Sub

    Private Sub PedidosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem1.Click
        MuestraForm(FrmPedidos, "Pedidos", "tpPedidos", 26)
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        MuestraForm(FrmCompras, "Compras", "tpCompras", 27)
    End Sub

    Private Sub ImportarMileniumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarMileniumToolStripMenuItem.Click
        MuestraForm(FrmImportarMilenium, "Milenium", "tpImportadMilenium", 22)
    End Sub

    Private Sub ImportarAccessToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MuestraForm(FrmImportarAccess, "Access", "tpImportadAccess", 23)
    End Sub

    Private Sub ParámetrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParámetrosToolStripMenuItem.Click
        MuestraForm(frmParámetros, "Parámetros", "tpParámetros", 16)
    End Sub

    Private Sub MileniumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MileniumToolStripMenuItem.Click
        Process.Start("C:\Milenium\central\bin\central.exe")
    End Sub

    Private Sub TrastiendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrastiendaToolStripMenuItem.Click
        Process.Start("C:\Milenium\central\bin\trastienda.exe")
    End Sub

    Private Sub IncidenciasresueltasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncidenciasresueltasToolStripMenuItem.Click
        MuestraForm(frmIncidenciasPeriodo, "Incidencias resueltas", "tpIncidenciasResueltas", 28)
    End Sub

    Private Sub FestivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FestivosToolStripMenuItem.Click
        MuestraForm(frmFestivos, "Festivos", "tpFestivos", 29)
    End Sub

    Private Sub ImportarFestivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarFestivosToolStripMenuItem.Click
        MuestraForm(FrmImportarFestivos, "Importar festivos", "tpImportarFestivos", 29)
    End Sub

    Private Sub PoblacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PoblacionesToolStripMenuItem.Click
        MuestraForm(FrmPoblaciones, "Poblaciones", "tpPoblaciones", 29)
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        FrmAcercaDe.ShowDialog()
    End Sub

    Private Sub BtnTiendas_Click(sender As Object, e As EventArgs) Handles btnTiendas.Click
        TiendasToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblTiendas_Click(sender As Object, e As EventArgs) Handles lblTiendas.Click
        TiendasToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnTP_Click(sender As Object, e As EventArgs) Handles btnTP.Click
        TPToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblTP_Click(sender As Object, e As EventArgs) Handles lblTP.Click
        TPToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnArtículos_Click(sender As Object, e As EventArgs) Handles btnArtículos.Click
        ArtículosToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblArtículos_Click(sender As Object, e As EventArgs) Handles lblArtículos.Click
        ArtículosToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnFacturaciónInterna_Click(sender As Object, e As EventArgs) Handles btnFacturaciónInterna.Click
        FacturaciónInternaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblFacturaciónInterna_Click(sender As Object, e As EventArgs) Handles lblFacturaciónInterna.Click
        FacturaciónInternaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnMilenium_Click(sender As Object, e As EventArgs) Handles btnMilenium.Click
        MileniumToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblMilenium_Click(sender As Object, e As EventArgs) Handles lblMilenium.Click
        MileniumToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnTrastienda_Click(sender As Object, e As EventArgs) Handles btnTrastienda.Click
        TrastiendaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblTrastienda_Click(sender As Object, e As EventArgs) Handles lblTrastienda.Click
        TrastiendaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub LblSalir_Click(sender As Object, e As EventArgs) Handles lblSalir.Click
        Me.Close()
    End Sub

    Private Delegate Sub IncidenciasPendientesDelegate()

    Private Sub IncidenciasPendientes()
        Dim cSQL As String
        Dim dtOperador, dtIncidencias As DataTable
        Dim connSQL As SqlConnection = New SqlConnection With {
            .ConnectionString = "Server=192.168.1.9;Database=incidencias;User Id=sa;Password=incidencias;"
        }
        Dim nDíasUsuario As Integer = 0
        Dim nDíasSinAsignar As Integer = 0
        Dim nDíasTotal As Integer = 0
        Dim nOperador As Integer
        Dim nMáximo As Integer = 0
        Dim lSalir As Boolean
        Dim nTiempo As Decimal = 0
        Dim dTiempo As DateTime

        lblCronómetro.Visible = False
        picBomba.Visible = False
        Me.Cursor = Cursors.WaitCursor
        lblUsuarioCorreosPendientes.Text = ""
        lblSinAsignarCorreos.Text = ""
        lblTotalCorreos.Text = ""
        lblActualización.Text = "Leyendo incidencias ..."
        My.Application.DoEvents()
        cSQL = "SELECT * FROM operadores WHERE login = " + GrabaComillas(cUsuario)
        dtOperador = CargaTabla(cSQL)

        If dtOperador.Rows.Count > 0 Then
            cSQL = "SELECT * FROM incidencias WHERE incidencias.estado=0 AND incidencias.dpto=1 AND asignado=" + dtOperador.Rows(0)("idincidencias").ToString
            dtIncidencias = CargaTabla(cSQL, connSQL)

            If lblUsuarioIncidenciasPendientes.InvokeRequired Then
                lblUsuarioIncidenciasPendientes.BeginInvoke(New IncidenciasPendientesDelegate(AddressOf IncidenciasPendientes))
            Else
                lblUsuarioIncidenciasPendientes.Text = dtIncidencias.Rows.Count.ToString("#,##0")
            End If


            Select Case dtIncidencias.Rows.Count
                Case 0
                    picUsuarioIncidenciasPendientes.BackgroundImage = My.Resources.caraverde

                Case 1, 2
                    picUsuarioIncidenciasPendientes.BackgroundImage = My.Resources.caraamarilla

                Case Else
                    picUsuarioIncidenciasPendientes.BackgroundImage = My.Resources.cararoja
            End Select

            For n = 0 To dtIncidencias.Rows.Count - 1
                nDíasUsuario = Math.Max(nDíasUsuario, Math.Abs(DateDiff(DateInterval.Day, Now(), dtIncidencias.Rows(n)("fecha"))))
            Next
        End If

        cSQL = "SELECT * FROM incidencias INNER JOIN usuarios ON incidencias.usuario = usuarios.id "
        cSQL += "WHERE incidencias.estado=0 AND incidencias.dpto=1 AND isnumeric(incidencias.asignado)=0"

        dtIncidencias = CargaTabla(cSQL, connSQL)

        lblSinAsignarIncidencias.Text = dtIncidencias.Rows.Count.ToString("#,##0")

        Select Case dtIncidencias.Rows.Count
            Case 0
                picSinAsignarIncidencias.BackgroundImage = My.Resources.caraverde

            Case 1, 2
                picSinAsignarIncidencias.BackgroundImage = My.Resources.caraamarilla

            Case Else
                picSinAsignarIncidencias.BackgroundImage = My.Resources.cararoja
        End Select

        For n = 0 To dtIncidencias.Rows.Count - 1
            nDíasSinAsignar = Math.Max(nDíasSinAsignar, Math.Abs(DateDiff(DateInterval.Day, Now(), dtIncidencias.Rows(n)("fecha"))))
        Next

        cSQL = "SELECT * FROM incidencias WHERE incidencias.estado=0 AND incidencias.dpto=1 ORDER BY fecha DESC"
        dtIncidencias = CargaTabla(cSQL, connSQL)
        lblTotalIncidencias.Text = dtIncidencias.Rows.Count.ToString("#,##0")

        If dtIncidencias.Rows.Count > 0 Then
            If dtIncidencias.Rows(0)("id") > nÚltimaIncidencia Then
                nÚltimaIncidencia = dtIncidencias.Rows(0)("id")
                TimedMsgBox("Han llegado nuevas incidencias", MsgBoxStyle.Information, 10, "Atención")
            End If
        End If

        Select Case dtIncidencias.Rows.Count
            Case 0
                picTotalIncidencias.BackgroundImage = My.Resources.caraverde

            Case 1, 2
                picTotalIncidencias.BackgroundImage = My.Resources.caraamarilla

            Case Else
                picTotalIncidencias.BackgroundImage = My.Resources.cararoja
        End Select

        For n = 0 To dtIncidencias.Rows.Count - 1
            nDíasTotal = Math.Max(nDíasTotal, Math.Abs(DateDiff(DateInterval.Day, Now(), dtIncidencias.Rows(n)("fecha"))))
        Next

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", Nothing) = "1" Then
            lblActualización.Text = "Leyendo correo HelpDesk ..."
            My.Application.DoEvents()

            Dim nMensajesPendientes As Integer = 0
            Dim nMensajesAsignados As Integer = 0
            Dim nMensajesTotales As Integer = 0

            Dim servicio As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010) With {
                .Credentials = New WebCredentials("helpdesk@decimas.local", "deporte"),
                .Url = New Uri("https://correo.decimas.es/ews/exchange.asmx")
            }

            servicio.Timeout = 10000
            dTiempo = Now

            Try
                Dim Carpeta As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio, "\\Bandeja de entrada", "helpdesk@decimas.es")
                Dim view As ItemView = New ItemView(1000, 0, OffsetBasePoint.Beginning) With {
                .PropertySet = New PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, ItemSchema.DateTimeReceived, ItemSchema.Categories)
            }
                view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending)
                Dim Resultados As FindItemsResults(Of Item) = servicio.FindItems(Carpeta.Id, view)

                Try
                    If Resultados.Items.Count > 0 Then
                        lSalir = False

                        For Each itItem As Item In Resultados.Items
                            If itItem.DateTimeReceived > dÚltimoCorreo Then
                                dÚltimoCorreo = itItem.DateTimeReceived
                                TimedMsgBox("Han llegado nuevos correos a HelpDesk", MsgBoxStyle.Information, 10, "Atención")
                            End If

                            nDíasTotal = Math.Max(nDíasTotal, Math.Abs(DateDiff(DateInterval.Day, Now, itItem.DateTimeReceived)))
                            nMensajesTotales += 1

                            If itItem.Categories.Count = 0 Then
                                nMensajesPendientes += 1
                                nDíasSinAsignar = Math.Max(nDíasSinAsignar, Math.Abs(DateDiff(DateInterval.Day, Now, itItem.DateTimeReceived)))
                            Else
                                If dtOperador.Rows.Count > 0 Then
                                    For n = 0 To itItem.Categories.Count - 1
                                        If itItem.Categories(n).ToUpper().Contains(dtOperador.Rows(0)("nombrecategoria").toupper()) Or itItem.Categories(n).ToUpper().Contains(dtOperador.Rows(0)("colorcategoria").toupper()) Then
                                            nDíasUsuario = Math.Max(nDíasUsuario, Math.Abs(DateDiff(DateInterval.Day, Now, itItem.DateTimeReceived)))
                                            nMensajesAsignados += 1
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If

                    lblUsuarioCorreosPendientes.Text = nMensajesAsignados.ToString("#,##0")

                    Select Case nMensajesAsignados
                        Case 0
                            picUsuarioCorreosPendientes.BackgroundImage = My.Resources.sobreverde

                        Case 1, 2
                            picUsuarioCorreosPendientes.BackgroundImage = My.Resources.sobreamarillo

                        Case Else
                            picUsuarioCorreosPendientes.BackgroundImage = My.Resources.sobrerojo
                    End Select

                    lblSinAsignarCorreos.Text = nMensajesPendientes.ToString("#,##0")

                    Select Case nMensajesPendientes
                        Case 0 To 3
                            picSinAsignarCorreos.BackgroundImage = My.Resources.sobreverde

                        Case 4 To 9
                            picSinAsignarCorreos.BackgroundImage = My.Resources.sobreamarillo

                        Case Else
                            picSinAsignarCorreos.BackgroundImage = My.Resources.sobrerojo
                    End Select

                    lblTotalCorreos.Text = nMensajesTotales.ToString("#,##0")

                    Select Case nMensajesTotales
                        Case 0 To 3
                            picTotalCorreos.BackgroundImage = My.Resources.sobreverde

                        Case 4 To 9
                            picTotalCorreos.BackgroundImage = My.Resources.sobreamarillo

                        Case Else
                            picTotalCorreos.BackgroundImage = My.Resources.sobrerojo
                    End Select

                Catch ex As System.Exception
                    'Dim st As StackTrace
                    'st = New StackTrace(ex, True)
                    'Dim obj As New FrmError(ex, "Mail menú principal", st)
                    'Dim nResultado As Integer

                    'nResultado = obj.ShowDialog(Me)
                    'If nResultado = DialogResult.Cancel Then Me.Close()
                End Try
            Catch ex As Exception

            End Try
        End If

        nTiempo = (Now - dTiempo).TotalSeconds

        If nTiempo < 10 Then
            Select Case nDíasUsuario
                Case 0, 1
                    picDíasUsuario.BackgroundImage = My.Resources.semáforoverde

                Case 2, 3
                    picDíasUsuario.BackgroundImage = My.Resources.semáforoamarillo

                Case 4, 5
                    picDíasUsuario.BackgroundImage = My.Resources.semáfororojo

                Case Else
                    picDíasUsuario.BackgroundImage = My.Resources.demonio
            End Select

            Select Case nDíasSinAsignar
                Case 0, 1
                    picDíasSinAsignar.BackgroundImage = My.Resources.semáforoverde

                Case 2, 3
                    picDíasSinAsignar.BackgroundImage = My.Resources.semáforoamarillo

                Case 4, 5
                    picDíasSinAsignar.BackgroundImage = My.Resources.semáfororojo

                Case Else
                    picDíasSinAsignar.BackgroundImage = My.Resources.demonio
            End Select

            Select Case nDíasTotal
                Case 0, 1
                    picDíasTotal.BackgroundImage = My.Resources.semáforoverde

                Case 2, 3
                    picDíasTotal.BackgroundImage = My.Resources.semáforoamarillo

                Case 4, 5
                    picDíasTotal.BackgroundImage = My.Resources.semáfororojo

                Case Else
                    picDíasTotal.BackgroundImage = My.Resources.demonio
            End Select
        End If

        dtOperador = CargaTabla("SELECT * FROM operadores")
        Dim aOperadores(dtOperador.Rows.Count, 3)

        aOperadores(0, 0) = ""
        aOperadores(0, 1) = ""
        aOperadores(0, 2) = 0

        For n = 0 To dtOperador.Rows.Count - 1
            aOperadores(n + 1, 0) = dtOperador.Rows(n)("nombre")
            aOperadores(n + 1, 1) = dtOperador.Rows(n)("colorcategoria")
            aOperadores(n + 1, 2) = 0
        Next

        cSQL = "SELECT * FROM soluciones WHERE soluciones.fecha >= '" + Now().ToString("yyyy-MM-dd")
        cSQL += "T00:00:00.000' AND soluciones.fecha <= '" + Now().ToString("yyyy-MM-dd") + "T23:59:59.999'"
        dtIncidencias = CargaTabla(cSQL, connSQL)

        For n = 0 To dtIncidencias.Rows.Count - 1
            nOperador = 0

            For m = 0 To dtOperador.Rows.Count - 1
                If dtIncidencias.Rows(n)("usuario") = dtOperador.Rows(m)("idincidencias") Then
                    nOperador = dtOperador.Rows(m)("idoperador")
                    Exit For
                End If
            Next

            aOperadores(nOperador, 2) += 1
        Next

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", Nothing) = "1" Then
            Dim servicio2 As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010) With {
                .Credentials = New WebCredentials("helpdesk@decimas.local", "deporte"),
                .Url = New Uri("https://correo.decimas.es/ews/exchange.asmx")
            }
            If nTiempo < 10 Then
                Try
                    Dim Carpeta As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio2, "\\Finalizado", "helpdesk@decimas.es")
                    Dim view As ItemView = New ItemView(1000, 0, OffsetBasePoint.Beginning) With {
                        .PropertySet = New PropertySet(BasePropertySet.IdOnly, ItemSchema.LastModifiedTime, ItemSchema.Categories)
                    }
                    view.OrderBy.Add(ItemSchema.LastModifiedTime, SortDirection.Descending)

                    Try
                        Dim Resultados As FindItemsResults(Of Item) = servicio2.FindItems(Carpeta.Id, view)

                        If Resultados.Items.Count > 0 Then
                            lSalir = False

                            For Each itItem As Item In Resultados.Items
                                If itItem.LastModifiedTime < DateTime.ParseExact(Now().ToString("yyyyMMdd000000"), "yyyyMMddhhmmss", Nothing) Then
                                    lSalir = True
                                    Exit For
                                End If

                                For n = 0 To dtOperador.Rows.Count - 1
                                    For m = 0 To itItem.Categories.Count - 1
                                        If itItem.Categories(m).ToUpper().Contains(dtOperador.Rows(n)("nombrecategoria").toupper()) Or itItem.Categories(m).ToUpper().Contains(dtOperador.Rows(n)("colorcategoria").toupper()) Then
                                            aOperadores(dtOperador.Rows(n)("idoperador"), 2) += 1
                                            Exit For
                                        End If
                                    Next
                                Next
                            Next
                        End If

                    Catch ex As System.Exception
                        'Dim st As StackTrace
                        'st = New StackTrace(ex, True)
                        'Dim obj As New FrmError(ex, "Mail menú principal", st)
                        'Dim nResultado As Integer

                        'nResultado = obj.ShowDialog(Me)
                        'If nResultado = DialogResult.Cancel Then Me.Close()
                    End Try

                Catch ex As Exception
                End Try
            End If
        End If

        Dim nOro As Integer = 0
        Dim nPlata As Integer = 0
        Dim nBronce As Integer = 0

        For n = 0 To dtOperador.Rows.Count - 1
            If aOperadores(n + 1, 2) > nOro Then
                nBronce = nPlata
                nPlata = nOro
                nOro = aOperadores(n + 1, 2)
            Else
                If aOperadores(n + 1, 2) > nPlata And aOperadores(n + 1, 2) <> nOro Then
                    nBronce = nPlata
                    nPlata = aOperadores(n + 1, 2)
                Else
                    If aOperadores(n + 1, 2) > nBronce And aOperadores(n + 1, 2) <> nOro And aOperadores(n + 1, 2) <> nPlata Then
                        nBronce = aOperadores(n + 1, 2)
                    End If
                End If
            End If
        Next

        GeneraGráfico(aOperadores, chartResueltas, "")

        picCopa.BackgroundImage = Nothing

        If aOperadores(nUsuario, 2) > 0 Then
            If aOperadores(nUsuario, 2) = nOro Then
                picCopa.BackgroundImage = My.Resources.oro
            ElseIf aOperadores(nUsuario, 2) = nPlata Then
                picCopa.BackgroundImage = My.Resources.plata
            ElseIf aOperadores(nUsuario, 2) = nBronce Then
                picCopa.BackgroundImage = My.Resources.bronce
            End If
        End If

        lblActualización.Text = ""
        Me.Cursor = Cursors.Arrow
        picBomba.Visible = True
        lblCronómetro.Visible = True
        My.Application.DoEvents()
    End Sub

    Private Sub TimerPendientes_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPendientes.Tick
        IncidenciasPendientes()
        If cUsuario = "rafael" Then PonCorreoMiguel()
        nSegundos = 600
    End Sub

    Private Sub TimerCuentaAtrás_Tick(sender As Object, e As EventArgs) Handles timerCuentaAtrás.Tick
        Dim nMinutos As Integer = nSegundos \ 60

        lblCronómetro.Text = nMinutos.ToString("D2") + ":" + (nSegundos Mod 60).ToString("D2")
        nSegundos -= 1
    End Sub

    Private Sub ChartResueltas_DoubleClick(sender As Object, e As EventArgs) Handles chartResueltas.DoubleClick
        Dim obj As New frmGráficoIncidencias(Now, Now)
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        obj.ShowDialog(Me)
        Me.Cursor = Cursors.Arrow
        My.Application.DoEvents()
    End Sub

    Private Sub PonCorreoMiguel()
        Try
            Dim servicio As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010) With {
                .Credentials = New WebCredentials("helpdesk@decimas.local", "deporte"),
                .Url = New Uri("https://correo.decimas.es/ews/exchange.asmx")
            }

            Try
                Dim Carpeta As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio, "\\Finalizado\Miguel", "helpdesk@decimas.es")
                Dim Destino As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio, "\\Finalizado", "helpdesk@decimas.es")
                Dim view As ItemView = New ItemView(1000, 0, OffsetBasePoint.Beginning) With {
                .PropertySet = New PropertySet(BasePropertySet.IdOnly)
            }
                Dim Resultados As FindItemsResults(Of Item) = servicio.FindItems(Carpeta.Id, view)

                If Resultados.Items.Count > 0 Then
                    For Each itItem As Item In Resultados.Items
                        Dim eMensaje As EmailMessage = EmailMessage.Bind(servicio, itItem.Id, view.PropertySet)
                        eMensaje.Categories.Add("Miguel")
                        eMensaje.Update(ConflictResolutionMode.AlwaysOverwrite)
                        eMensaje.Move(Destino.Id)
                    Next
                End If

            Catch ex As System.Exception
                'Dim st As StackTrace
                'st = New StackTrace(ex, True)
                'Dim obj As New FrmError(ex, "Mover mails Miguel", st)
                'Dim nResultado As Integer

                'nResultado = obj.ShowDialog(Me)
                'If nResultado = DialogResult.Cancel Then Me.Close()
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChartResueltas_MouseDown(sender As Object, e As MouseEventArgs) Handles chartResueltas.MouseDown
        If e.Button = MouseButtons.Right Then IncidenciasPendientes()
    End Sub

    Private Sub GroupUsuario_MouseDown(sender As Object, e As MouseEventArgs) Handles groupUsuario.MouseDown
        If e.Button = MouseButtons.Right Then IncidenciasPendientes()
    End Sub

    Private Sub GroupSinAsignar_MouseDown(sender As Object, e As MouseEventArgs) Handles groupSinAsignar.MouseDown
        If e.Button = MouseButtons.Right Then IncidenciasPendientes()
    End Sub

    Private Sub GroupTotal_MouseDown(sender As Object, e As MouseEventArgs) Handles groupTotal.MouseDown
        If e.Button = MouseButtons.Right Then IncidenciasPendientes()
    End Sub

    Private Sub PicUsuario_MouseHover(sender As Object, e As EventArgs) Handles picUsuario.MouseHover
        FrmFoto.Show()
    End Sub

    Private Sub PicUsuario_MouseLeave(sender As Object, e As EventArgs) Handles picUsuario.MouseLeave
        FrmFoto.Close()
    End Sub

    Private Sub IncidenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncidenciasToolStripMenuItem.Click
        MuestraForm(FrmIncidencias, "Incidencias", "tpIncidencias", 32)
    End Sub

    Private Sub IntranetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntranetToolStripMenuItem.Click
        MuestraForm(FrmIntranet, "Intranet", "tpIntranet", 33)
    End Sub

    Private Sub ExtensionesCentralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtensionesCentralToolStripMenuItem.Click
        MuestraForm(FrmExtensiones, "Extensiones", "tpExtensiones", 34)
    End Sub

    Private Sub BtnIncidencias_Click(sender As Object, e As EventArgs) Handles btnIncidencias.Click
        IncidenciasToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblIncidencias_Click(sender As Object, e As EventArgs) Handles lblIncidencias.Click
        IncidenciasToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnIntranet_Click(sender As Object, e As EventArgs) Handles btnIntranet.Click
        IntranetToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblIntranet_Click(sender As Object, e As EventArgs) Handles lblIntranet.Click
        IntranetToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnExtensiones_Click(sender As Object, e As EventArgs) Handles btnExtensiones.Click
        ExtensionesCentralToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblExtensiones_Click(sender As Object, e As EventArgs) Handles lblExtensiones.Click
        ExtensionesCentralToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatToolStripMenuItem.Click
        'MuestraForm(FrmChat, "Chat", "tpChat", "0", 35)
        Dim obj = New FrmChat(0)
        lChatAbierto = True
        obj.ShowDialog()
        obj.Dispose()
    End Sub

    Private Sub BtnChat_Click(sender As Object, e As EventArgs) Handles btnChat.Click
        ChatToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LblChat_Click(sender As Object, e As EventArgs) Handles lblChat.Click
        ChatToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub TimerChat_Tick(sender As Object, e As EventArgs) Handles timerChat.Tick
        If lChatAbierto Then Return

        Dim cSQL As String
        Dim dtChat As DataTable
        Dim conn As MySql.Data.MySqlClient.MySqlConnection

        conn = New MySqlConnection(Conexión())
        cSQL = "SELECT c.idchat, c.cerrado, l.hora FROM cabchat c, linchat l WHERE "
        cSQL += "c.idchat = l.idchat AND para = " + GrabaComillas(cUsuario) + " AND cerrado = 0"
        dtChat = CargaTabla(cSQL, conn)

        If dtChat.Rows.Count > 0 Then
            Dim obj = New FrmChat(dtChat.Rows(0)("idchat"))
            lChatAbierto = True
            obj.ShowDialog()
            obj.Dispose()
        End If

        dtChat.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cUsuario = "ignacio"
    End Sub

    Private Sub LimpiarChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarChatToolStripMenuItem.Click
        Dim cSQl As String = "DELETE FROM cabchat"
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim connMySQL As MySqlConnection = New MySqlConnection(Conexión())
        Dim nResultado As Integer

        cmd = New MySqlCommand(cSQl, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Limpieza chat", st)

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmd.Dispose()
        End Try

        connMySQL.Close()

    End Sub
End Class
