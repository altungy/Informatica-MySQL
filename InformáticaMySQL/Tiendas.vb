#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1307
#Disable Warning CA1401
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2211
#Disable Warning CA2213
#Disable Warning CA5301
#Disable Warning IDE0067
#Disable Warning IDE0068

Imports MySql.Data.MySqlClient
Imports Microsoft.Data.Odbc
Imports System.Data.SqlClient
Imports System.Net
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmTiendas
    Private connMySQL As MySqlConnection
    Private connInformix As OdbcConnection
    Private connTienda As MySqlConnection
    Private connSQL As SqlConnection
    Private dtTiendas As DataTable
    Private cFiltro As String = ""
    Private nTienda As Integer
    Private lPuedeModificar As Boolean
    Private nInventario As Integer = 0
    Private lFiltrando As Boolean = False
    Private lModificando As Boolean = False
    Private lAgregando As Boolean = False
    Private lModificandoApertura As Boolean = False
    Private lBuscandoTicket As Boolean = False
    Private lBuscandoVale As Boolean = False
    Private lBuscandoValeCentral As Boolean = False
    Private lModificandoInventario As Boolean = False
    Private lModificandoVendedor As Boolean = False
    Private dtVendedores As DataTable
    Private dtCaja As DataTable
    Private dtLíneas As DataTable
    Private dtPagos As DataTable
    Private dtEfectivo As DataTable
    Private dtProveedores As DataTable
    Private cODBCInformix As String
    Private nCódigoVendedor As Integer = 0
    Private dtTipos As DataTable
    'Private comboSourceTipos As Dictionary(Of Integer, String)
    Private ReadOnly lvwVendedoresSorter As ListViewColumnSorter
    Private lMailTicket As Boolean = False
    Private cVersión As String = "Tiendas V08/19"

    Private Const SW_SHOWDEFAULT As System.Int32 = 10
    Private Const SW_MAXIMIZE As System.Int32 = 3

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function ShowWindow(<System.Runtime.InteropServices.In()> ByVal hWnd As System.IntPtr, <System.Runtime.InteropServices.In()> ByVal nCmdShow As System.Int32) As System.Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SetForegroundWindow(<System.Runtime.InteropServices.In()> ByVal hWnd As System.IntPtr) As System.Boolean
    End Function

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' Create an instance of a ListView column sorter and assign it 
        ' to the ListView control.
        lvwVendedoresSorter = New ListViewColumnSorter()
        Me.lvwVendedores.ListViewItemSorter = lvwVendedoresSorter
    End Sub

    Private Sub TabTiendas_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles tabTiendas.DrawItem
        Dim g As Graphics = e.Graphics
        Dim _TextBrush As Brush

        ' Get the item from the collection. 
        Dim _TabPage As TabPage = tabTiendas.TabPages(e.Index)

        ' Get the real bounds for the tab rectangle. 
        Dim _TabBounds As Rectangle = tabTiendas.GetTabRect(e.Index)

        If (e.State = DrawItemState.Selected) Then
            ' Draw a different background color, and don't paint a focus rectangle.
            _TextBrush = New SolidBrush(Color.Black)
            g.FillRectangle(Brushes.White, e.Bounds)
        Else
            '_TextBrush = New System.Drawing.SolidBrush(e.ForeColor)
            'e.DrawBackground()
            _TextBrush = New SolidBrush(Color.Black)
            g.FillRectangle(Brushes.LightGray, e.Bounds)
        End If

        ' Use our own font. 
        Dim _TabFont As New Font("Microsoft Sans Serif", 11, FontStyle.Regular, GraphicsUnit.Pixel)

        ' Draw string. Center the text. 
        Dim _StringFlags As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
        }
        g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBounds, New StringFormat(_StringFlags))
    End Sub

    Private Sub FrmTiendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemporal As DataTable
        Dim nSize As System.Drawing.Size

        nSize.Width = lvwInventario.Size.Width + 40
        nSize.Height = lvwInventario.Size.Height + 145
        lvwInventario.Size = nSize

        connMySQL = New MySqlConnection(Conexión())
        CargaTiendas()

        dtTemporal = CargaTabla("SELECT * FROM empresas ORDER BY nombre")
        comboEmpresa.Items.Clear()
        comboEmpresa.Items.Add("")

        For n = 0 To dtTemporal.Rows.Count - 1
            comboEmpresa.Items.Add(dtTemporal.Rows(n)("nombre"))
        Next

        dtTemporal = CargaTabla("SELECT * FROM rotulos ORDER BY nombre")

        comboRótulo.Items.Clear()
        comboRótulo.Items.Add("")

        For n = 0 To dtTemporal.Rows.Count - 1
            comboRótulo.Items.Add(dtTemporal.Rows(n)("nombre"))
        Next

        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)

        With comboProveedorInventario
            .DataSource = dtProveedores
            .DisplayMember = "nombre"
            .ValueMember = "idproveedor"
        End With

        'Me.Height -= 30

        With lvwPagos
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 6, FontStyle.Regular)
            .Columns.Add("Moviemiento", 0, HorizontalAlignment.Left)
            .Columns.Add("Tipo", 100, HorizontalAlignment.Left)
            .Columns.Add("Pago", 100, HorizontalAlignment.Left)
            .Columns.Add("Importe", 80, HorizontalAlignment.Right)
        End With

        With lvwLíneasTicket
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 6, FontStyle.Regular)
            .Columns.Add("Moviemiento", 0, HorizontalAlignment.Left)
            .Columns.Add("Código", 80, HorizontalAlignment.Left)
            .Columns.Add("Descripción", 230, HorizontalAlignment.Left)
            .Columns.Add("Cant.", 40, HorizontalAlignment.Right)
            .Columns.Add("Precio", 60, HorizontalAlignment.Right)
            .Columns.Add("Total", 65, HorizontalAlignment.Right)
        End With

        With lvwTickets
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .Columns.Add("Ticket", 60, HorizontalAlignment.Left)
            .Columns.Add("Fecha", 80, HorizontalAlignment.Left)
            .Columns.Add("Importe", 80, HorizontalAlignment.Left)
        End With

        With lvwInventario.Columns
            .Add("Número", 0)
            .Add("Fecha", 80, HorizontalAlignment.Center)
            .Add("Artículo", 270, HorizontalAlignment.Left)
            .Add("Nº serie", 150, HorizontalAlignment.Left)
            .Add("Cant.", 50, HorizontalAlignment.Right)
            .Add("Precio", 80, HorizontalAlignment.Right)
        End With

        With lvwEfectivo.Columns
            .Add("Número", 0)
            .Add("Tipo", 80)
            .Add("Valor", 80, HorizontalAlignment.Right)
            .Add("Observaciones", 325)
        End With

        With lvwCobros.Columns
            .Add("Ticket", 50, HorizontalAlignment.Right)
            .Add("Líneas", 80, HorizontalAlignment.Right)
            .Add("Pagos", 80, HorizontalAlignment.Right)
        End With

        With lvwMissingKey.Columns
            .Add("Ticket", 50, HorizontalAlignment.Right)
            .Add("Código", 80, HorizontalAlignment.Left)
            .Add("Descripción", 190, HorizontalAlignment.Left)
            .Add("Ref. externa", 80, HorizontalAlignment.Left)
            .Add("Propuesto", 80, HorizontalAlignment.Left)
        End With

        With lvwVendedores.Columns
            .Add("Código", 60)
            .Add("Nombre", 200)
            .Add("Activo", 60, HorizontalAlignment.Center)
        End With

        lPuedeModificar = (Environment.UserName = "rafael")
        ActivaBotones()

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "SQL", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "SQL", "")
        End If

        txtSQL.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "SQL", Nothing).ToString

        ssProgreso.Visible = False
        Me.Height -= 30
        lblProcesado.Text = ""
        lblInformación.Text = ""
        CreaToolTips()

        Dim procesos() As Process = Process.GetProcessesByName("communicatork9")

        If procesos.GetLength(0) = 0 Then
            btnLlamarContacto.Visible = False
            btnLlamarExtensión.Visible = False
            btnLlamarFijo.Visible = False
        End If

        connSQL = New SqlConnection("Server=192.168.1.9;Database=incidencias;User Id=sa;Password=incidencias;")

        Dim tControl, pControl, oControl As Control

        For Each tControl In Me.Controls
            If tControl.GetType.ToString().IndexOf("TabControl") > 0 Then
                For Each pControl In tControl.Controls
                    If pControl.GetType.ToString().IndexOf("TabPage") > 0 Then
                        For Each oControl In pControl.Controls
                            If oControl.GetType.ToString().IndexOf("TextBox") > 0 Then
                                AddHandler oControl.DoubleClick, AddressOf TextBoxDoubleClick
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub TextBoxDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        sender.SelectAll()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ActivaBotones()
        btnModificar.Enabled = lPuedeModificar
        btnAbrirCaja.Enabled = True
        btnAgregar.Visible = False
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"

        btnFiltrar.Enabled = True
        btnPing.Enabled = True
        btnSalir.Enabled = True
        Me.AcceptButton = Nothing
        Me.CancelButton = Nothing

        btnAbrirCaja.Enabled = True
        btnModificarApertura.Enabled = True
        btnBorrarDía.Enabled = True

        btnCambiarVendedor.Enabled = True
        btnBuscarTicket.Enabled = True
        btnEliminarTicket.Enabled = True
        btnAgregarPago.Enabled = True
        btnEliminarPago.Enabled = True
        btnAgregarLínea.Enabled = True
        btnEliminarLínea.Enabled = True

        btnBuscarVale.Enabled = True

        btnAgregarInventario.Enabled = True
        btnModificarInventario.Enabled = True
        btnEliminarInventario.Enabled = True
        btnFacturar.Enabled = True

        btnAgregarVendedor.Enabled = True
        btnModificarVendedor.Enabled = True
        btnEliminarVendedor.Enabled = True
        btnMoverVendedor.Enabled = True

        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        lPuedeModificar = True
        btnAbrirCaja.Enabled = True
        btnAgregar.Visible = True
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnFiltrar.Enabled = False
        btnPing.Enabled = False
        btnSalir.Enabled = False

        btnAbrirCaja.Enabled = False
        btnModificarApertura.Enabled = False
        btnBorrarDía.Enabled = False

        btnCambiarVendedor.Enabled = False
        btnBuscarTicket.Enabled = False
        btnEliminarTicket.Enabled = False
        btnAgregarPago.Enabled = False
        btnEliminarPago.Enabled = False
        btnAgregarLínea.Enabled = False
        btnEliminarLínea.Enabled = False

        btnBuscarVale.Enabled = False

        btnAgregarInventario.Enabled = False
        btnModificarInventario.Enabled = False
        btnEliminarInventario.Enabled = False
        btnFacturar.Enabled = False

        btnAgregarVendedor.Enabled = False
        btnModificarVendedor.Enabled = False
        btnEliminarVendedor.Enabled = False
        btnMoverVendedor.Enabled = False

        Me.ControlBox = False
    End Sub

    Private Sub CargaTiendas()
        Dim cSQL As String
        Dim cTemp As String = "WHERE "

        cSQL = "SELECT * FROM tiendas "
        If Not String.IsNullOrWhiteSpace(cfiltro) Then cTemp += cfiltro

        If Not chkCerradas.Checked Then
            If Len(cTemp) > 6 Then cTemp += " AND "
            'cTemp += " estado <> ""CERRADA"" AND estado IS NOT NULL AND estado <> "" """
            cTemp += " estado <> ""CERRADA"""
        End If

        If Len(cTemp) > 6 Then cSQL += cTemp
        cSQL += " ORDER BY nombre"
        dtTiendas = CargaTabla(cSQL)

        With dvTiendas
            .ReadOnly = True
            .DataSource = dtTiendas
            .DataMember = dtTiendas.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Font = New Font(dvTiendas.Font, FontStyle.Bold)

            .Columns(0).Visible = False

            With .Columns(1)
                .HeaderText = "Código"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            .Columns(2).Visible = False
            .Columns(3).Visible = False

            With .Columns(4)
                .HeaderText = "Nombre"
                .Width = 409
            End With

            For n = 5 To .Columns.Count - 1
                .Columns(n).Visible = False
            Next

            .Sort(.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
        End With
    End Sub

    Private Sub CargaInventario()
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM inventario WHERE idtienda = " + nTienda.ToString + " ORDER BY fecha DESC")

        CambiaCursor("Leyendo inventario ...")
        lvwInventario.Items.Clear()

        For n = 0 To dtTemporal.Rows.Count - 1
            Dim item As New ListViewItem(dtTemporal.Rows(n)("idinventario").ToString)

            item.SubItems.Add(Format(dtTemporal.Rows(n)("fecha"), "d"))
            item.SubItems.Add(Memo2Array(dtTemporal.Rows(n)("articulo"), 60)(0))
            item.SubItems.Add(dtTemporal.Rows(n)("serie"))
            item.SubItems.Add(FormatNumber(dtTemporal.Rows(n)("cantidad"), 0, TriState.True, TriState.False, TriState.True))
            item.SubItems.Add(FormatNumber(dtTemporal.Rows(n)("precio"), 2, TriState.True, TriState.False, TriState.True))
            lvwInventario.Items.AddRange(New ListViewItem() {item})
        Next

        CambiaCursor("")
    End Sub

    Private Sub CargaVendedores()
        Dim cSQL As String
        Dim dtTemporal As DataTable

        CambiaCursor("Leyendo vendedores ...")

        If Not String.IsNullOrEmpty(cODBCInformix) Then
            connInformix = ConexiónCentral(cODBCInformix)
            cSQL = "SELECT * FROM vendedores WHERE cod_cli = " + txtCódigo.Text + " ORDER BY nombre"
            dtTemporal = CargaTabla(cSQL, connInformix)

            lvwVendedores.Items.Clear()

            For n = 0 To dtTemporal.Rows.Count - 1
                Dim item As New ListViewItem(dtTemporal.Rows(n)("id").ToString)

                item.SubItems.Add(dtTemporal.Rows(n)("nombre"))
                item.SubItems.Add(If(dtTemporal.Rows(n)("estado") = "ACTIVO", "√", "X"))
                lvwVendedores.Items.AddRange(New ListViewItem() {item})
            Next

            dtTemporal.Dispose()
        End If

        CambiaCursor("")
    End Sub

    Private Sub DvTiendas_Click(sender As Object, e As System.EventArgs) Handles dvTiendas.Click
        nTienda = Val(dvTiendas.SelectedRows.Item(0).Cells(1).Value.ToString)
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim cSQL As String
        Dim dtTienda, dtInformix, dtFestivos, dtRouters, dtIncidencias As DataTable
        Dim lProcesado As Boolean = False

        BorraCampos()

        cSQL = "SELECT * FROM tiendas WHERE codigo = " + nTienda.ToString
        dtTienda = CargaTabla(cSQL)

        cSQL = "SELECT * FROM festivos WHERE fecha = " + DtoSQL(Now.ToString("dd/MM/yyyy")) + " AND poblacion = " + GrabaComillas(dtTienda.Rows(0)("poblacion"))
        dtFestivos = CargaTabla(cSQL)

        If dtFestivos.Rows.Count = 0 Then
            lblFestivo.Visible = False
        Else
            lblFestivo.Text = "Hoy es festivo " + dtFestivos.Rows(0)("tipo").ToLower
            lblFestivo.Visible = True
        End If

        comboEmpresa.Text = NombreEmpresa(dtTienda.Rows(0)("idempresa"))
        comboRótulo.Text = dtTienda.Rows(0)("rotulo").ToString
        comboEstado.Text = dtTienda.Rows(0)("estado").ToString
        txtTeléfonoContacto.Text = dtTienda.Rows(0)("telefonocontacto").ToString
        nudOrdenadores.Value = dtTienda.Rows(0)("ordenadores")
        txtSO.Text = dtTienda.Rows(0)("so").ToString
        comboTipoLínea.Text = dtTienda.Rows(0)("linea").ToString

        Select Case dtTienda.Rows(0)("linea")
            Case "C"
                comboTipoLínea.Text = "COBRE"

            Case "F"
                comboTipoLínea.Text = "FIBRA"

            Case "3"
                comboTipoLínea.Text = "3G"

            Case "4"
                comboTipoLínea.Text = "4G"

            Case "R"
                comboTipoLínea.Text = "RADIOENLACE"

            Case "S"
                comboTipoLínea.Text = "SATÉLITE"

            Case Else
                comboTipoLínea.Text = ""
        End Select

        comboProveedor.Text = dtTienda.Rows(0)("proveedor").ToString
        txtSedeComunicaciones.Text = dtTienda.Rows(0)("sedecomunicaciones").ToString
        txtComunicación.Text = dtTienda.Rows(0)("comunicacion").ToString
        comboMerchant.Text = dtTienda.Rows(0)("merchant").ToString
        txtObservaciones.Text = dtTienda.Rows(0)("observaciones").ToString

        cODBCInformix = ODBC(dtTienda.Rows(0)("idempresa"))

        If Not String.IsNullOrEmpty(cODBCInformix) Then
            CambiaCursor("Cargando Milenium ...")
            connInformix = ConexiónCentral(cODBCInformix)
            cSQL = "SELECT dir_comerciales.*, clientes_comercial.tienda AS tienda, clientes_aux.*, conexiones.*, coordinadores.coordinador AS nombrecoordinador, paises.nombre AS nombrepais, provincias.nombre AS nombreprovincia FROM dir_comerciales "
            cSQL += "LEFT JOIN clientes_comercial ON dir_comerciales.cliente = clientes_comercial.codigo "
            cSQL += "LEFT JOIN clientes_aux ON dir_comerciales.cliente = clientes_aux.codigo "
            cSQL += "LEFT JOIN conexiones ON dir_comerciales.cliente = conexiones.cod_cli "
            cSQL += "LEFT JOIN coordinadores ON clientes_aux.coordinador = coordinadores.codigo "
            cSQL += "LEFT JOIN paises ON dir_comerciales.pais = paises.codigo "
            cSQL += "LEFT JOIN provincias ON dir_comerciales.provincia = provincias.codigo AND dir_comerciales.pais = provincias.pais "
            cSQL += "WHERE dir_comerciales.cliente = " + nTienda.ToString
            'Dim dInicio As Date = Now()
            dtInformix = CargaTabla(cSQL, connInformix)
            'Dim cTiempo As String = Microsoft.VisualBasic.Right("0" + Trim((Now() - dInicio).Seconds.ToString), 2)
            'cTiempo = Microsoft.VisualBasic.Right("0" + Trim((Now() - dInicio).Minutes.ToString), 2) + ":" + cTiempo
            'cTiempo = Microsoft.VisualBasic.Right("0" + Trim((Now() - dInicio).Hours.ToString), 2) + ":" + cTiempo
            'MsgBox("Tiempo: " + cTiempo, MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            'dtInformix = CargaInformix(cSQL)

            If dtInformix.Rows.Count > 0 Then
                txtCódigo.Text = dtInformix.Rows(0)("cliente").ToString
                txtNombre.Text = dtInformix.Rows(0)("tienda").ToString
                txtDirección1.Text = dtInformix.Rows(0)("dir1").ToString
                txtDirección2.Text = dtInformix.Rows(0)("dir2").ToString
                txtPostal.Text = dtInformix.Rows(0)("cod_postal").ToString
                txtPoblación.Text = dtInformix.Rows(0)("poblacion").ToString
                txtProvincia.Text = dtInformix.Rows(0)("nombreprovincia").ToString
                txtPaís.Text = dtInformix.Rows(0)("nombrepais").ToString
                txtTeléfono.Text = dtInformix.Rows(0)("telefono").ToString
                txtNúmeroTeléfono.Text = dtInformix.Rows(0)("telefono").ToString
                txtCorreo.Text = dtInformix.Rows(0)("correo_e").ToString
                txtContacto.Text = dtInformix.Rows(0)("contacto").ToString
                txtExtensión.Text = dtInformix.Rows(0)("extension").ToString
                txtComunicación.Text = dtInformix.Rows(0)("clave").ToString
                txtCoordinador.Text = dtInformix.Rows(0)("nombrecoordinador").ToString
                txtComercio.Text = dtInformix.Rows(0)("codfuc").ToString
                lProcesado = True
            End If

            dtInformix.Dispose()
        End If

        If Not lProcesado Then
            txtCódigo.Text = dtTienda.Rows(0)("codigo").ToString
            txtNombre.Text = dtTienda.Rows(0)("nombre").ToString
            txtDirección1.Text = dtTienda.Rows(0)("direccion1").ToString
            txtDirección2.Text = dtTienda.Rows(0)("direccion2").ToString
            txtPostal.Text = dtTienda.Rows(0)("postal").ToString
            txtPoblación.Text = dtTienda.Rows(0)("poblacion").ToString
            txtProvincia.Text = dtTienda.Rows(0)("provincia")
            txtPaís.Text = dtTienda.Rows(0)("pais")
            txtTeléfono.Text = dtTienda.Rows(0)("telefono").ToString
            txtNúmeroTeléfono.Text = dtTienda.Rows(0)("telefono").ToString
            txtCorreo.Text = dtTienda.Rows(0)("email").ToString
            txtExtensión.Text = dtTiendas.Rows(0)("extension").ToString
            txtContacto.Text = dtTienda.Rows(0)("contacto").ToString
            txtComercio.Text = dtTienda.Rows(0)("comercio").ToString
        End If

        If lProcesado Then
            lblOrigen.Text = "Milenium"
            lblOrigen.ForeColor = Color.Blue
        Else
            lblOrigen.Text = "Local"
            lblOrigen.ForeColor = Color.Red
        End If

        lblTiendaComunicaciones.Text = txtNombre.Text
        lblTiendaEconómicos.Text = txtNombre.Text
        lblTiendaObservaciones.Text = txtNombre.Text
        lblTiendaCobroMal.Text = txtNombre.Text
        lblTiendaApertura.Text = txtNombre.Text
        lblTiendaTicket.Text = txtNombre.Text
        lblTiendaVale.Text = txtNombre.Text
        lblTiendaInventario.Text = txtNombre.Text
        lblTiendaEfectivo.Text = txtNombre.Text

        dtRouters = CargaTabla("SELECT subred FROM inalambricos WHERE tienda = " + txtCódigo.Text)

        If dtRouters.Rows.Count = 0 Then
            txtSubred.Text = dtTienda.Rows(0)("subred").ToString
            lblInalámbrico.Visible = False
            lblIPDefinitiva.Visible = False
        Else
            txtSubred.Text = dtRouters.Rows(0)("subred").ToString
            lblInalámbrico.Visible = True
            lblIPDefinitiva.Text = "Subred definitiva " + dtTienda.Rows(0)("subred").ToString
            lblIPDefinitiva.Visible = True
        End If

        If String.IsNullOrEmpty(txtSubred.Text) Then
            txtRouter.Text = ""
            txtIPTPV.Text = ""
            txtIPTeléfono1.Text = ""
        Else
            txtRouter.Text = txtSubred.Text + "1"
            txtIPTPV.Text = txtSubred.Text + "6"
            txtIPTeléfono1.Text = txtSubred.Text + "5"
        End If

        dtIncidencias = CargaTabla("SELECT COUNT(*) AS numero FROM usuarios WHERE mail = '" + txtCorreo.Text + "'", connSQL)

        If dtIncidencias.Rows(0)("numero") = 0 Then
            lblIncidencias.ForeColor = Color.Red
        Else
            lblIncidencias.ForeColor = Color.Green
        End If

        dtIncidencias.Dispose()

        'CargaInventario()
        'CambiaCursor("Cargando vendedores ...")
        'CargaVendedores()
        CambiaCursor("")
    End Sub

    Private Sub CargaFormasPago()
        CambiaCursor("Leyendo vendedores ...")

        If Not String.IsNullOrEmpty(txtIPTPV.Text) Then
            Dim eco As New System.Net.NetworkInformation.Ping
            Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
            Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

            If res.Status = NetworkInformation.IPStatus.Success Then
                connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
                dtTipos = CargaTabla("SELECT id, nombre FROM tipos_mov_caja ORDER BY id", connTienda)
                comboTipoPago.DataSource = Nothing
                comboTipoPago.Items.Clear()
                Dim _Tipos As New List(Of Tipos) From {
                    New Tipos With {.Id = 0, .Nombre = ""}
                }

                For n = 0 To dtTipos.Rows.Count - 1
                    _Tipos.Add(New Tipos With {.Id = dtTipos.Rows(n)("id"), .Nombre = dtTipos.Rows(n)("nombre")})
                Next

                With comboTipoPago
                    .DataSource = _Tipos
                    .DisplayMember = "nombre"
                    .ValueMember = "id"
                End With

                dtPagos = CargaTabla("SELECT id, nombre FROM fpago WHERE activo = 1 ORDER BY nombre", connTienda)
                comboFormaPago.DataSource = Nothing
                comboFormaPago.Items.Clear()
                Dim _Formas As New List(Of Tipos) From {
                    New Tipos With {.Id = 0, .Nombre = ""}
                }

                For n = 0 To dtPagos.Rows.Count - 1
                    _Formas.Add(New Tipos With {.Id = dtPagos.Rows(n)("id"), .Nombre = dtPagos.Rows(n)("nombre")})
                Next

                With comboFormaPago
                    .DataSource = _Formas
                    .DisplayMember = "nombre"
                    .ValueMember = "id"
                End With
            End If
        End If

        CambiaCursor("")
    End Sub

    Private Sub BorraCampos()
        txtCódigo.Text = ""
        comboEmpresa.Text = ""
        txtNombre.Text = ""
        comboRótulo.Text = ""
        txtDirección1.Text = ""
        txtDirección2.Text = ""
        txtPostal.Text = ""
        txtPoblación.Text = ""
        txtProvincia.Text = ""
        txtPaís.Text = ""
        txtTeléfono.Text = ""
        txtExtensión.Text = ""
        txtCorreo.Text = ""
        comboEstado.Text = ""
        txtContacto.Text = ""
        txtTeléfonoContacto.Text = ""
        txtCoordinador.Text = ""
        nudOrdenadores.Value = 0
        txtSO.Text = ""
        lblIncidencias.ForeColor = Color.Black

        lblTiendaComunicaciones.Text = ""
        comboTipoLínea.Text = ""
        txtNúmeroTeléfono.Text = ""
        comboProveedor.Text = ""
        txtSedeComunicaciones.Text = ""
        txtSubred.Text = ""
        txtRouter.Text = ""
        txtIPTPV.Text = ""
        txtIPTeléfono1.Text = ""
        txtComunicación.Text = ""
        lblPingRouter.Visible = False
        lblPingServidor.Visible = False
        lblPingTeléfono.Visible = False
        lblInalámbrico.Visible = False
        lblIPDefinitiva.Visible = False

        lblTiendaEconómicos.Text = ""
        comboMerchant.Text = ""
        txtComercio.Text = ""

        lblTiendaObservaciones.Text = ""
        txtObservaciones.Text = ""

        BorraCamposApertura()
        BorraCamposInventario()
        BorraCamposTickets()
        BorraCamposVales()
        BorraCamposValesCentral()
        lvwInventario.Items.Clear()
        lblTiendaVale.Text = ""

        lblTiendaEconómicos.Text = ""
        txtFechaEfectivo.Text = ""
        lvwEfectivo.Items.Clear()

        lblTiendaVendedores.Text = ""
        lvwVendedores.Items.Clear()

        txtFechaCobro.Text = ""
        lvwCobros.Items.Clear()

        tabTickets.SelectedIndex = 0
    End Sub

    Private Sub BorraCamposTickets()
        txtTicket.Text = ""
        txtFechaTicket.Text = ""
        txtHoraTicket.Text = ""
        comboVendedor.Text = ""
        txtImporte.Text = ""
        txtTotalPagos.Text = ""
        txtTotalLíneas.Text = ""
        lvwPagos.Items.Clear()
        lvwLíneasTicket.Items.Clear()
        txtFechaBuscaTicket.Text = ""
        comboTipoPago.Text = ""
        comboFormaPago.Text = ""
        txtImporteBuscaTicket.Text = ""
        lvwTickets.Items.Clear()
    End Sub

    Private Sub BorraCamposVales()
        txtVale.Text = ""
        txtTicketVale.Text = ""
        txtFechaVale.Text = ""
        txtImporteVale.Text = ""
        txtImporteValeCentral.Text = ""
        chkLiquidadoTienda.Checked = False
        chkLiquidadoCentral.Checked = False
        chkLiquidadoTienda.Text = "Tienda"
        chkLiquidadoCentral.Text = "Central"
    End Sub

    Private Sub BorraCamposValesCentral()
        txtValeCentral.Text = ""
        txtFechaInicioValeCentral.Text = ""
        txtFechaFinValeCentral.Text = ""
        txtEmisorValeCentral.Text = ""
        txtNombreEmisorValeCentral.Text = ""
        txtImporteCentralVale.Text = ""
        txtTicketValeCentral.Text = ""
        txtValeCentral.Text = ""
        chkLiquidadoValeCentral.Checked = False
        txtLiquidadorValeCentral.Text = ""
        txtNombreLiquidadorValeCentral.Text = ""
        txtFechaLiquidadoValeCentral.Text = ""
        txtTicketLiquidadoValeCentral.Text = ""
        radioPolinesia.Checked = False
        radioDécimas.Checked = False
        radioAdidas.Checked = False
        radioInvain.Checked = False
    End Sub

    Private Sub BorraCamposInventario()
        txtArtículo.Text = ""
        txtUsuario.Text = ""
        txtSerie.Text = ""
        txtEnvío.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = ""
        comboProveedorInventario.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        nInventario = 0
    End Sub

    Private Sub BorraCamposApertura(Optional ByVal lBorraFecha As Boolean = True)
        lblProcesado.Text = ""
        lblFestivoApertura.Visible = False
        If lBorraFecha Then txtFechaApertura.Text = ""
        lblEstadoCaja.Text = ""
        txtApertura.Text = ""
        txtCierre.Text = ""
        txtIngresos.Text = ""
        txtBanco.Text = ""
        txtCódigoBanco.Text = ""
        txtCCC.Text = ""
    End Sub

    Private Sub ActivaCampos()
        txtCódigo.ReadOnly = False
        txtNombre.ReadOnly = False
        txtDirección1.ReadOnly = False
        txtPostal.ReadOnly = False
        txtPoblación.ReadOnly = False
        txtProvincia.ReadOnly = False
        txtTeléfono.ReadOnly = False
        txtExtensión.ReadOnly = False
        txtCorreo.ReadOnly = False
        txtContacto.ReadOnly = False
        txtTeléfonoContacto.ReadOnly = False
        nudOrdenadores.ReadOnly = False
        txtSO.ReadOnly = False

        txtSedeComunicaciones.ReadOnly = False
        txtNúmeroTeléfono.ReadOnly = False
        txtSubred.ReadOnly = False
        txtRouter.ReadOnly = False
        txtIPTPV.ReadOnly = False
        txtIPTeléfono1.ReadOnly = False
        txtComunicación.ReadOnly = False

        txtComercio.ReadOnly = False

        txtObservaciones.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtCódigo.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDirección1.ReadOnly = True
        txtPostal.ReadOnly = True
        txtPoblación.ReadOnly = True
        txtProvincia.ReadOnly = True
        txtTeléfono.ReadOnly = True
        txtExtensión.ReadOnly = True
        txtCorreo.ReadOnly = True
        txtContacto.ReadOnly = True
        txtTeléfonoContacto.ReadOnly = True
        nudOrdenadores.ReadOnly = True
        txtSO.ReadOnly = True

        txtSedeComunicaciones.ReadOnly = False
        txtNúmeroTeléfono.ReadOnly = True
        txtSubred.ReadOnly = True
        txtComunicación.ReadOnly = True

        txtComercio.ReadOnly = True

        txtArtículo.ReadOnly = True
        txtUsuario.ReadOnly = True
        txtSerie.ReadOnly = True
        txtEnvío.ReadOnly = True
        txtCantidad.ReadOnly = True
        txtPrecio.ReadOnly = True
        txtFactura.ReadOnly = True
        txtFechaFactura.ReadOnly = True

        txtObservaciones.ReadOnly = True
    End Sub

    Private Sub ActivaCamposInventario()
        txtArtículo.ReadOnly = False
        txtUsuario.ReadOnly = False
        txtSerie.ReadOnly = False
        txtEnvío.ReadOnly = False
        txtCantidad.ReadOnly = False
        txtPrecio.ReadOnly = False
        txtFactura.ReadOnly = False
        txtFechaFactura.ReadOnly = False
    End Sub

    Private Sub ActivaCamposValeCentral()
        txtValeCentral.ReadOnly = False
        txtFechaInicioValeCentral.ReadOnly = False
        txtFechaFinValeCentral.ReadOnly = False
        txtEmisorValeCentral.ReadOnly = False
        txtImporteCentralVale.ReadOnly = False
        txtTicketValeCentral.ReadOnly = False
    End Sub

    Private Sub DesactivaCamposValeCentral()
        txtValeCentral.ReadOnly = True
        txtFechaInicioValeCentral.ReadOnly = True
        txtFechaFinValeCentral.ReadOnly = True
        txtEmisorValeCentral.ReadOnly = True
        txtImporteCentralVale.ReadOnly = True
        txtTicketValeCentral.ReadOnly = True
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        tabTiendas.SelectedIndex = 0
        BorraCampos()
        ActivaCampos()
        DesactivaBotones()
        lFiltrando = True
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtNombre.Focus()
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cCampos As String = ""
        Dim cDatos As String = ""
        Dim dtVenta As DataTable
        Dim dtTemporal As DataTable
        Dim cmdMySQL As MySqlCommand
        Dim nSize As System.Drawing.Size
        'Dim connInformix As New OdbcConnection
        Dim cmdInformix As OdbcCommand
        Dim lEncontrado As Boolean
        Dim cConexión As String = ""

        If lFiltrando Then
            If chkCerradas.Checked Then cfiltro = "" Else cfiltro = "estado <> ""CERRADA"" And "

            If Not String.IsNullOrWhiteSpace(txtCódigo.Text) Then cfiltro += "codigo = " + txtCódigo.Text + " And "
            If Not String.IsNullOrWhiteSpace(comboEmpresa.Text) Then cfiltro += "idempresa = " + CódigoEmpresa(comboEmpresa.Text).ToString + " And "
            If Not String.IsNullOrWhiteSpace(txtNombre.Text) Then cfiltro += "nombre Like ""%" + Trim(txtNombre.Text) + "%"" And "
            If Not String.IsNullOrWhiteSpace(comboRótulo.Text) Then cfiltro += "rotulo = " + GrabaComillas(comboRótulo.Text) + " And "
            If Not String.IsNullOrWhiteSpace(txtDirección1.Text) Then cfiltro += "direccion1 Like ""%" + StrConv(Trim(txtDirección1.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtPostal.Text) Then cfiltro = "cp Like ""%" + Trim(txtPostal.Text) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtPoblación.Text) Then cfiltro += "poblacion Like ""%" + StrConv(Trim(txtPoblación.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtProvincia.Text) Then cfiltro += "provincia Like ""%" + StrConv(Trim(txtProvincia.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtTeléfono.Text) Then cfiltro += "telefono Like ""%" + StrConv(Trim(txtTeléfono.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtExtensión.Text) Then cfiltro += "extension Like ""%" + StrConv(Trim(txtExtensión.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtCorreo.Text) Then cfiltro += "correoe Like ""%" + StrConv(Trim(txtCorreo.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(comboEstado.Text) Then cfiltro += "estado = " + GrabaComillas(comboEstado.Text) + " And "
            If Not String.IsNullOrWhiteSpace(txtContacto.Text) Then cfiltro += "contacto Like ""%" + StrConv(Trim(txtContacto.Text), VbStrConv.Uppercase) + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtTeléfonoContacto.Text) Then cfiltro += "telefonocontacto Like ""%" + StrConv(Trim(txtTeléfonoContacto.Text), VbStrConv.Uppercase) + "%"" And "
            If nudOrdenadores.Value > 0 Then cfiltro += "ordenadores >= " + nudOrdenadores.Value.ToString + " And "
            If Not String.IsNullOrWhiteSpace(txtSO.Text) Then cfiltro += "so Like ""%" + StrConv(Trim(txtSO.Text), VbStrConv.Uppercase) + "%"" And "

            If Not String.IsNullOrWhiteSpace(comboTipoLínea.Text) Then cfiltro += "linea = " + GrabaComillas(comboTipoLínea.Text) + " And "
            If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then cfiltro += "proveedor = " + GrabaComillas(comboProveedor.Text) + " And "
            If Not String.IsNullOrWhiteSpace(txtSubred.Text) Then cfiltro += "subred Like ""%" + txtSubred.Text + "%"" And "
            If Not String.IsNullOrWhiteSpace(txtComunicación.Text) Then cfiltro += "comunicacion Like ""%" + StrConv(Trim(txtComunicación.Text), VbStrConv.Uppercase) + "%"" And "

            If Not String.IsNullOrWhiteSpace(comboMerchant.Text) Then cfiltro += "merchant = " + GrabaComillas(comboMerchant.Text) + " And "
            If Not String.IsNullOrWhiteSpace(txtComercio.Text) Then cfiltro += "comercio = " + GrabaComillas(txtComercio.Text) + " And "

            If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then cfiltro += "observaciones Like ""%" + StrConv(Trim(txtObservaciones.Text), VbStrConv.Uppercase) + "%"" And "

            If Not String.IsNullOrWhiteSpace(cfiltro) Then cfiltro = Microsoft.VisualBasic.Left(cfiltro, Len(cfiltro) - 5)

            cSQL = "SELECT * FROM tiendas "
            If Not String.IsNullOrWhiteSpace(cfiltro) Then cSQL += "WHERE " + cfiltro + " "
            cSQL += "ORDER BY nombre"
            dtTemporal = CargaTabla(cSQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("No hay registros en esas condiciones", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "")
                cfiltro = ""
                BorraCampos()
                Me.Text = cVersión
            Else
                CargaTiendas()
                Me.Text = cVersión + " - Filtro[" + Trim(dtTiendas.Rows.Count.ToString) + "]"

                If dtTiendas.Rows.Count = 1 Then
                    nTienda = Val(dtTiendas.Rows(0)("codigo").ToString)
                    CargaDatos()
                Else
                    BorraCampos()
                End If
            End If

            ActivaBotones()
            DesactivaCampos()
            lFiltrando = False
            CargaTiendas()
            Return
        End If

        If lModificandoApertura Then
            If String.IsNullOrEmpty(txtCódigoBanco.Text) Then
                If MsgBox("No hay cuenta bancaria por defecto." + Chr(13) + Chr(10) + "¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then
                    lModificandoApertura = False
                    ActivaBotones()
                    txtApertura.ReadOnly = True
                    txtCierre.ReadOnly = True
                    txtBanco.ReadOnly = True
                    TxtFechaApertura_Leave(sender, e)
                    Return
                End If
            End If

            cSQL = "UPDATE cierre SET "
            cSQL += "total_apertura = " + Str(Val(txtApertura.Text)) + ", "
            cSQL += "caja_real = " + Str(Val(txtCierre.Text)) + ", "
            cSQL += "ingreso_banco = " + Str(Val(txtBanco.Text)) + ", "

            If Val(txtBanco.Text) = 0 Then
                cSQL += "cuenta_corriente = null, ingreso = 0"
            Else
                cSQL += "cuenta_corriente = " + txtCódigoBanco.Text + ", ingreso = 1"
            End If

            cSQL += " WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

            connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
            cmdMySQL = New MySqlCommand(cSQL, connTienda)
            connTienda.Open()

            Try
                cmdMySQL.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Modificar apertura", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connTienda.Close()

            lModificandoApertura = False
            ActivaBotones()
            txtApertura.ReadOnly = True
            txtCierre.ReadOnly = True
            txtBanco.ReadOnly = True
            TxtFechaApertura_Leave(sender, e)
            Return
        End If

        If lBuscandoTicket Then
            If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then Return

            Me.Height += 30
            ssProgreso.Visible = True
            lblMensaje.Text = "Abriendo tienda ..."
            My.Application.DoEvents()

            Dim eco As New System.Net.NetworkInformation.Ping
            Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
            Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

            If Not (res.Status = NetworkInformation.IPStatus.Success) Then
                MsgBox("No se puede conectar al servidor", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                lBuscandoTicket = False
                BorraCamposTickets()
                ActivaBotones()
                Me.Height -= 30
                ssProgreso.Visible = False
                Return
            End If

            connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}

            lblMensaje.Text = "Leyendo vendedores ..."
            My.Application.DoEvents()

            dtVendedores = CargaTabla("SELECT id, nombre FROM vendedores WHERE activo = 1 ORDER BY nombre", connTienda)
            comboVendedor.DataSource = dtVendedores
            comboVendedor.DisplayMember = dtVendedores.Columns(1).Caption.ToString
            comboVendedor.ValueMember = dtVendedores.Columns(0).Caption.ToString

            lblMensaje.Text = "Leyendo formas de pago ..."
            My.Application.DoEvents()

            lblMensaje.Text = "Leyendo cabecera ticket ..."
            My.Application.DoEvents()

            dtVenta = CargaTabla("SELECT * FROM venta WHERE num_doc = " + txtTicket.Text, connTienda)

            If dtVenta.Rows.Count = 0 Then
                MsgBox("Ticket no encontrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                lBuscandoTicket = False
                BorraCamposTickets()
                ActivaBotones()
                Me.Height -= 30
                ssProgreso.Visible = False
                Return
            End If


            dtTemporal = CargaTabla("SELECT nombre FROM vendedores WHERE id = " + dtVenta.Rows(0)("vendedor").ToString, connTienda)
            txtFechaTicket.Text = dtVenta.Rows(0)("fecha")
            txtHoraTicket.Text = dtVenta.Rows(0)("hora").ToString
            If dtTemporal.Rows.Count > 0 Then comboVendedor.Text = dtTemporal.Rows(0)("nombre").ToString
            txtImporte.Text = FormatCurrency(dtVenta.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)

            lblMensaje.Text = "Leyendo líneas ticket ..."
            My.Application.DoEvents()
            CargaPagos()
            CargaLíneasTicket()

            txtTicket.ReadOnly = True
            lBuscandoTicket = False
            ActivaBotones()
            Me.Height -= 30
            ssProgreso.Visible = False
            Return
        End If

        If lBuscandoVale Then
            If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then
                MsgBox("No hay conexión con tienda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                txtVale.ReadOnly = True
                txtTicketVale.ReadOnly = True
                lBuscandoVale = False
                ActivaBotones()
                Return
            End If

            lEncontrado = False

            Me.Height += 30
            ssProgreso.Visible = True
            lblMensaje.Text = "Abriendo tienda ..."
            My.Application.DoEvents()

            Dim eco As New System.Net.NetworkInformation.Ping
            Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
            Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

            If res.Status = NetworkInformation.IPStatus.Success Then
                connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}

                lblMensaje.Text = "Leyendo vale ..."
                My.Application.DoEvents()

                Try
                    cSQL = "SELECT * FROM vales WHERE "

                    If String.IsNullOrEmpty(txtVale.Text) Then
                        cSQL += "num_doc = " + txtTicketVale.Text
                    Else
                        cSQL += "num_vale = " + GrabaComillas(txtVale.Text)
                    End If

                    cSQL += " And cod_cli = " + txtCódigo.Text
                    dtTemporal = CargaTabla(cSQL, connTienda)

                    If dtTemporal.Rows.Count > 0 Then
                        lEncontrado = True
                        chkLiquidadoTienda.Text = "Tienda"
                        txtTicketVale.Text = Trim(dtTemporal.Rows(0)("num_doc").ToString)
                        txtFechaVale.Text = dtTemporal.Rows(0)("fecha")
                        txtImporteVale.Text = FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)
                        chkLiquidadoTienda.Checked = (dtTemporal.Rows(0)("liquidado") = 1)
                        txtVale.Text = Trim(dtTemporal.Rows(0)("num_vale").ToString)
                    Else
                        chkLiquidadoTienda.Text = "No encontrado en tienda"
                    End If
                Catch ex As Exception
                    chkLiquidadoTienda.Text = "Tienda sin MySQL"
                End Try
            Else
                chkLiquidadoTienda.Text = "Sin conexión a tienda"
            End If

            If Not String.IsNullOrEmpty(txtVale.Text) And Not String.IsNullOrEmpty(comboRótulo.Text) Then
                connInformix = New OdbcConnection With {.ConnectionString = "DSN="}

                Select Case comboRótulo.Text
                    Case "ADIDAS"
                        connInformix.ConnectionString += "adodbc"
                    Case "DECIMAS"
                        connInformix.ConnectionString += "deodbc"
                    Case "POLINESIA"
                        connInformix.ConnectionString += "polodbc"
                End Select

                connInformix.ConnectionString += ";UID=rafael;Pwd=altungy;"""
                cSQL = "SELECT * FROM vales WHERE num_vale = " + GrabaComillas(txtVale.Text)
                dtTemporal = CargaTabla(cSQL, connInformix)

                If dtTemporal.Rows.Count = 0 Then
                    chkLiquidadoCentral.Text = "No registrado en Central"
                Else
                    If Not lEncontrado Then
                        txtFechaVale.Text = dtTemporal.Rows(0)("fecha")
                        txtImporteVale.Text = FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)
                    End If

                    lEncontrado = True
                    chkLiquidadoCentral.Text = "Central"
                    chkLiquidadoCentral.Checked = (dtTemporal.Rows(0)("liquidado") = 1)
                    txtImporteValeCentral.Text = FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)
                End If
            End If

            If Not lEncontrado Then
                MsgBox("Vale no encontrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                lBuscandoVale = False
                BorraCamposVales()
                ActivaBotones()
                Me.Height -= 30
                ssProgreso.Visible = False
                Return
            End If

            If chkLiquidadoTienda.Checked = False Or chkLiquidadoCentral.Checked = False Then btnLiquidarVale.Visible = True

            txtVale.ReadOnly = True
            txtTicketVale.ReadOnly = True
            lBuscandoVale = False
            ActivaBotones()
            Me.Height -= 30
            ssProgreso.Visible = False
            Return
        End If

        If lBuscandoValeCentral Then
            If radioDécimas.Checked = False And radioPolinesia.Checked = False And radioAdidas.Checked = False And radioInvain.Checked = False Then
                MsgBox("Debe seleccionar una empresa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                Return
            End If

            cSQL = "SELECT vales.fecha, vales.num_vale, clientes_comercial.tienda, vales.valor, vales.liquidado, vales.cod_cli FROM vales, clientes_comercial WHERE "

            If Not String.IsNullOrEmpty(txtValeCentral.Text) Then
                cSQL += "vales.num_vale = " + txtValeCentral.Text + " And "
            Else
                If Not String.IsNullOrEmpty(txtFechaInicioValeCentral.Text) Then
                    If String.IsNullOrEmpty(txtFechaFinValeCentral.Text) Then
                        cSQL += "vales.fecha = " + FechaInformix(txtFechaInicioValeCentral.Text) + " And "
                    Else
                        cSQL += "vales.fecha >= " + FechaInformix(txtFechaInicioValeCentral.Text) + " And "
                        cSQL += "vales.fecha <= " + FechaInformix(txtFechaFinValeCentral.Text) + " And "
                    End If
                End If

                If Not String.IsNullOrEmpty(txtEmisorValeCentral.Text) Then cSQL += "vales.cod_cli = " + txtEmisorValeCentral.Text + " And "
                If Not String.IsNullOrEmpty(txtImporteCentralVale.Text) Then cSQL += "vales.valor = " + txtImporteCentralVale.Text + " And "
                If Not String.IsNullOrEmpty(txtEmisorValeCentral.Text) Then cSQL += "vales.cod_cli = " + txtEmisorValeCentral.Text + " And "
                If Not String.IsNullOrEmpty(txtTicketValeCentral.Text) Then cSQL += "vales.num_doc = " + txtTicketValeCentral.Text + " And "
            End If

            If Microsoft.VisualBasic.Right(cSQL, 6) = "WHERE " Then
                MsgBox("Debe seleccionar un criterio de búsqueda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                Return
            End If

            cSQL += "vales.cod_cli = clientes_comercial.codigo ORDER BY vales.fecha"
            If radioDécimas.Checked Then cConexión = ConexiónInformix("DECIMAS")
            If radioAdidas.Checked Then cConexión = ConexiónInformix("ADIDAS")
            If radioPolinesia.Checked Then cConexión = ConexiónInformix("POLINESIA")
            If radioInvain.Checked Then cConexión = ConexiónInformix("INVAIN")

            connInformix = New OdbcConnection With {.ConnectionString = cConexión}
            dtTemporal = CargaTabla(cSQL, connInformix)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("No hay vales con esas condiciones", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Else
                With dvValesCentral
                    .ReadOnly = True
                    .DataSource = dtTemporal
                    .DataMember = dtTemporal.TableName
                    .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
                    '.MultiSelect = False
                    .RowHeadersVisible = False
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    .GridColor = Color.LightGray
                    .ColumnHeadersDefaultCellStyle.Font = New Font(dvValesCentral.Font, FontStyle.Bold)

                    With .Columns(0)
                        .HeaderText = "Fecha"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With .Columns(1)
                        .HeaderText = "Número"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With

                    With .Columns(2)
                        .HeaderText = "Tienda"
                        .Width = 200
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End With

                    With .Columns(3)
                        .HeaderText = "Importe"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "N2"
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End With

                    With .Columns(4)
                        .HeaderText = "Liq."
                        .Width = 30
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With

                    With .Columns(5)
                        .Visible = False
                    End With

                    .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                End With
            End If

            DesactivaCamposValeCentral()
            ActivaBotones()
            lBuscandoValeCentral = False
            Return
        End If

        If lModificandoInventario Then
            dtTemporal = CargaTabla("SELECT * FROM articulos WHERE serie = " + GrabaComillas(txtSerie.Text), connMySQL)
            connMySQL.Open()

            If dtTemporal.Rows.Count > 0 Then
                cSQL = "DELETE FROM movimientosarticulos WHERE idarticulo = "
                cSQL += dtTemporal.Rows(0)("idarticulo").ToString + " And "
                cSQL += "idtienda = " + nTienda.ToString

                cmdMySQL = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmdMySQL.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Borrado movimientos artículo", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    If nResultado = DialogResult.Cancel Then Me.Close()
                End Try
            End If

            If nInventario = 0 Then
                cSQL = "INSERT INTO inventario(idtienda, usuario, fecha, articulo, serie, cantidad, precio, idproveedor, factura, "
                If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then cSQL += "fechafactura, "
                cSQL += "facturable) VALUES("
                cSQL += nTienda.ToString + ", "
                cSQL += GrabaComillas(txtUsuario.Text) + ", "
                cSQL += DtoSQL(txtEnvío.Text) + ", "
                cSQL += GrabaComillas(txtArtículo.Text) + ", "
                cSQL += GrabaComillas(txtSerie.Text) + ", "
                cSQL += Str(Val(txtCantidad.Text)) + ", "
                cSQL += Str(Val(txtPrecio.Text)) + ", "
                cSQL += If(String.IsNullOrWhiteSpace(comboProveedorInventario.Text), "0", comboProveedorInventario.SelectedValue.ToString) + ", "
                cSQL += GrabaComillas(txtFactura.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then cSQL += DtoSQL(txtFechaFactura.Text) + ", "
                cSQL += If(chkFacturable.Checked, "1", "0") + ")"
            Else
                cSQL = "UPDATE inventario SET "
                cSQL += "idtienda = " + nTienda.ToString + ", "
                cSQL += "usuario = " + GrabaComillas(txtUsuario.Text) + ", "
                cSQL += "fecha = " + DtoSQL(txtEnvío.Text) + ", "
                cSQL += "articulo = " + GrabaComillas(txtArtículo.Text) + ", "
                cSQL += "serie = " + GrabaComillas(txtSerie.Text) + ", "
                cSQL += "cantidad = " + Str(Val(txtCantidad.Text)) + ", "
                cSQL += "precio = " + Str(Val(txtPrecio.Text)) + ", "
                cSQL += "idproveedor = " + If(String.IsNullOrWhiteSpace(comboProveedorInventario.Text), "0", comboProveedorInventario.SelectedValue.ToString) + ", "
                cSQL += "factura = " + GrabaComillas(txtFactura.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then cSQL += "fechafactura = " + DtoSQL(txtFechaFactura.Text) + ", "
                cSQL += "facturable = " + If(chkFacturable.Checked, "1", "0")
                cSQL += " WHERE idinventario = " + nInventario.ToString
            End If

            cmdMySQL = New MySqlCommand(cSQL, connMySQL)

            Try
                cmdMySQL.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Alta/modificación inventario", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            cSQL = "INSERT INTO movimientosarticulos(idarticulo, idtienda, fecha, usuario) VALUES("
            cSQL += dtTemporal.Rows(0)("idarticulo").ToString + ", "
            cSQL += nTienda.ToString + ", "
            cSQL += DtoSQL(txtEnvío.Text) + ", "
            cSQL += GrabaComillas(txtUsuario.Text) + ")"

            cmdMySQL = New MySqlCommand(cSQL, connMySQL)

            Try
                cmdMySQL.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Inserción de movimiento de artículo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connMySQL.Close()

            lModificandoInventario = False
            nSize.Width = lvwInventario.Size.Width
            nSize.Height = lvwInventario.Size.Height + 150
            lvwInventario.Size = nSize
            DesactivaCampos()
            ActivaBotones()
            CargaInventario()
            Return
        End If

        If lModificandoVendedor Then
            If nCódigoVendedor = 0 Then
                cSQL = "SELECT MAX(id) AS codigo FROM vendedores"
                dtTemporal = CargaTabla(cSQL, connInformix)
                nCódigoVendedor = dtTemporal.Rows(0)("codigo") + 1

                cSQL = "INSERT INTO vendedores(cod_cli, id, nombre, estado) VALUES("
                cSQL += txtCódigo.Text + ", "
                cSQL += Str(nCódigoVendedor + 1) + ", "
                cSQL += GrabaComillas(txtNombreVendedor.Text) + ", "
                cSQL += If(chkVendedorActivo.Checked, """ACTIVO""", """NO ACTIVO""") + ")"
            Else
                cSQL = "UPDATE vendedores SET "
                cSQL += "nombre = " + GrabaComillas(txtNombreVendedor.Text) + ", "
                cSQL += "estado = " + If(chkVendedorActivo.Checked, """ACTIVO""", """NO ACTIVO""")
                cSQL += " WHERE cod_cli = " + txtCódigo.Text + " And id = " + Str(nCódigoVendedor)
            End If

            CambiaCursor("Grabando datos ...")
            connInformix = ConexiónCentral(cODBCInformix)
            cmdInformix = New OdbcCommand(cSQL, connInformix)
            connInformix.Open()

            Try
                cmdInformix.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Alta/modificación vendedores", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connInformix.Close()

            ActivaBotones()
            txtNombreVendedor.Visible = False
            chkVendedorActivo.Visible = False
            lModificandoVendedor = False
            CargaVendedores()
            CambiaCursor("")
            Return
        End If

        If lModificando Then
            If lAgregando Then
                If Not String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                    cCampos += "codigo, "
                    cDatos += GrabaComillas(txtCódigo.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(comboEmpresa.Text) Then
                    cCampos += "empresa, "
                    cDatos += GrabaComillas(comboEmpresa.Text) + ", "
                End If

                cCampos += "nombre, "
                cDatos += GrabaComillas(txtNombre.Text) + ", "

                If Not String.IsNullOrWhiteSpace(comboRótulo.Text) Then
                    cCampos += "rotulo, "
                    cDatos += GrabaComillas(comboRótulo.Text) + ", "
                End If

                cCampos += "direccion1, "
                cDatos += GrabaComillas(txtDirección1.Text) + ", "
                cCampos += "direccion2, "
                cDatos += GrabaComillas(txtDirección2.Text) + ", "
                cCampos += "cp, "
                cDatos += GrabaComillas(txtPostal.Text) + ", "
                cCampos += "poblacion, "
                cDatos += GrabaComillas(txtPoblación.Text) + ", "
                cCampos += "provincia, "
                cDatos += GrabaComillas(txtProvincia.Text) + ", "

                If Not String.IsNullOrWhiteSpace(txtTeléfono.Text) Then
                    cCampos += "telefono, "
                    cDatos += GrabaComillas(txtTeléfono.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtExtensión.Text) Then
                    cCampos += "extension, "
                    cDatos += GrabaComillas(txtExtensión.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtCorreo.Text) Then
                    cCampos += "correoe, "
                    cDatos += GrabaComillas(txtCorreo.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(comboEstado.Text) Then
                    cDatos += "estado_tienda, "
                    cCampos += GrabaComillas(comboEstado.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtContacto.Text) Then
                    cCampos += "contacto, "
                    cDatos += GrabaComillas(txtContacto.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtTeléfonoContacto.Text) Then
                    cCampos += "telefono_contacto, "
                    cDatos += GrabaComillas(txtTeléfonoContacto.Text) + ", "
                End If

                cCampos += "num_ordenadores, "
                cDatos += Trim(nudOrdenadores.Value.ToString) + ", "

                If Not String.IsNullOrWhiteSpace(txtSO.Text) Then
                    cCampos += "so, "
                    cDatos += GrabaComillas(txtSO.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(comboTipoLínea.Text) Then
                    cCampos += "linea, "
                    cDatos += GrabaComillas(comboTipoLínea.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then
                    cCampos += "proveedor_internet, "
                    cDatos += GrabaComillas(comboProveedor.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtSedeComunicaciones.Text) Then
                    cCampos += "sedecomunicaciones, "
                    cDatos += GrabaComillas(txtSedeComunicaciones.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtComunicación.Text) Then
                    cCampos += "comunicacion, "
                    cDatos += GrabaComillas(txtComunicación.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(comboMerchant.Text) Then
                    cCampos += "merchant, "
                    cDatos += GrabaComillas(comboMerchant.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtComercio.Text) Then
                    cCampos += "comercio, "
                    cDatos += GrabaComillas(txtComercio.Text) + ", "
                End If

                If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then
                    cCampos += "observaciones, "
                    cDatos += GrabaComillas(txtObservaciones.Text) + ", "
                End If

                cSQL = "INSERT INTO tiendas(" + Microsoft.VisualBasic.Left(cCampos, Len(cCampos) - 2) + ") VALUES(" +
                    Microsoft.VisualBasic.Left(cDatos, Len(cDatos) - 2) + ")"
            Else
                cSQL = "UPDATE tiendas SET "
                If Not String.IsNullOrWhiteSpace(txtCódigo.Text) Then cSQL += "codigo = " + GrabaComillas(txtCódigo.Text) + ", "
                If Not String.IsNullOrWhiteSpace(comboEmpresa.Text) Then cSQL += "idempresa = " + CódigoEmpresa(comboEmpresa.Text).ToString + ", "
                cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
                If Not String.IsNullOrWhiteSpace(comboRótulo.Text) Then cSQL += "rotulo = " + GrabaComillas(comboRótulo.Text) + ", "
                cSQL += "direccion1 = " + GrabaComillas(txtDirección1.Text) + ", "
                cSQL += "direccion2 = " + GrabaComillas(txtDirección2.Text) + ", "
                cSQL += "postal = " + GrabaComillas(txtPostal.Text) + ", "
                cSQL += "poblacion = " + GrabaComillas(txtPoblación.Text) + ", "
                cSQL += "provincia = " + GrabaComillas(txtProvincia.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtTeléfono.Text) Then cSQL += "telefono = " + GrabaComillas(txtTeléfono.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtExtensión.Text) Then cSQL += "extension = " + GrabaComillas(txtExtensión.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtCorreo.Text) Then cSQL += "email = " + GrabaComillas(txtCorreo.Text) + ", "
                If Not String.IsNullOrWhiteSpace(comboEstado.Text) Then cSQL += "estado = " + GrabaComillas(comboEstado.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtContacto.Text) Then cSQL += "contacto = " + GrabaComillas(txtContacto.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtTeléfonoContacto.Text) Then cSQL += "telefonocontacto = " + GrabaComillas(txtTeléfonoContacto.Text) + ", "
                cSQL += "ordenadores = " + nudOrdenadores.Value.ToString + ", "
                If Not String.IsNullOrWhiteSpace(txtSO.Text) Then cSQL += "so = " + GrabaComillas(txtSO.Text) + ", "
                If Not String.IsNullOrWhiteSpace(comboTipoLínea.Text) Then cSQL += "linea = " + GrabaComillas(Microsoft.VisualBasic.Left(comboTipoLínea.Text, 1)) + ", "
                If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then cSQL += "proveedor = " + GrabaComillas(comboProveedor.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtSedeComunicaciones.Text) Then cSQL += "sedecomunicaciones = " + GrabaComillas(txtSedeComunicaciones.Text) + ", "

                If Not String.IsNullOrWhiteSpace(txtSubred.Text) Then cSQL += "subred = " + GrabaComillas(txtSubred.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtComunicación.Text) Then cSQL += "comunicacion = " + GrabaComillas(txtComunicación.Text) + ", "
                If Not String.IsNullOrWhiteSpace(comboMerchant.Text) Then cSQL += "merchant = " + GrabaComillas(comboMerchant.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtComercio.Text) Then cSQL += "comercio = " + GrabaComillas(txtComercio.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then cSQL += "observaciones = " + GrabaComillas(txtObservaciones.Text) + ", "
                cSQL = Microsoft.VisualBasic.Left(cSQL, Len(cSQL) - 2)
                cSQL += " WHERE codigo = " + nTienda.ToString
            End If

            connMySQL.Open()
            cmdMySQL = New MySqlCommand(cSQL, connMySQL)

            Try
                cmdMySQL.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Alta/modificación de tienda", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connMySQL.Close()

            If nTienda = 0 Then
                cSQL = "SELECT idtienda FROM tiendas ORDER BY idtienda DESC LIMIT 1"
                dtTemporal = CargaTabla(cSQL)
                nTienda = dtTemporal.Rows(0)("idtienda")
            End If

            lAgregando = False
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            CargaTiendas()
            Return
        End If

        BorraCampos()
        lAgregando = True
        lModificando = True
        tabTiendas.SelectedTab = pageDirección
        DesactivaBotones()
        ActivaCampos()
        txtCódigo.Focus()
    End Sub

    Private Sub CargaPagos()
        Dim cCódigo As String
        Dim dtTemporal As DataTable
        Dim nTotal As Decimal = 0

        lvwPagos.Items.Clear()
        dtCaja = CargaTabla("SELECT caja.num_mov, caja.tipo, caja.fpago, caja.valor, tipo.nombre AS nombretipo FROM mov_caja AS caja, tipos_mov_caja AS tipo WHERE caja.tipo = tipo.id And num_doc = " + txtTicket.Text + " ORDER BY num_mov", connTienda)

        For n = 0 To dtCaja.Rows.Count - 1
            nTotal += dtCaja.Rows(n)("valor")
            cCódigo = dtCaja.Rows(n)("num_mov").ToString
            Dim item As New ListViewItem(cCódigo)

            If String.IsNullOrEmpty(dtCaja.Rows(n)("tipo").ToString) Then
                item.SubItems.Add("")
            Else
                item.SubItems.Add(dtCaja.Rows(n)("nombretipo"))
            End If

            If String.IsNullOrEmpty(dtCaja.Rows(n)("fpago").ToString) Then
                item.SubItems.Add("")
            Else
                dtTemporal = CargaTabla("SELECT * FROM fpago WHERE id = " + dtCaja.Rows(n)("fpago").ToString, connTienda)
                item.SubItems.Add(dtTemporal.Rows(0)("nombre"))
            End If

            item.SubItems.Add(FormatNumber(dtCaja.Rows(n)("valor"), 2, TriState.True, TriState.False, TriState.True))
            lvwPagos.Items.AddRange(New ListViewItem() {item})

            txtTotalPagos.Text = FormatNumber(nTotal, 2, TriState.True, TriState.False, TriState.True)
        Next

        dtTemporal = CargaTabla("SELECT * FROM venta WHERE num_doc = " + txtTicket.Text, connTienda)
        txtImporte.Text = FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)
        dtTemporal.Dispose()
    End Sub

    Private Sub CargaLíneasTicket()
        Dim nTotal As Decimal = 0
        Dim cCódigo As String
        Dim dtArtículo As DataTable
        Dim dtTemporal As DataTable

        lvwLíneasTicket.Items.Clear()
        dtLíneas = CargaTabla("SELECT linea, codigo, cantidad, pventa FROM lineas_venta WHERE num_doc = " + txtTicket.Text + " ORDER BY linea", connTienda)

        If dtLíneas.Rows.Count = 0 Then
            dtTemporal = CargaTabla("SELECT * FROM venta WHERE num_doc = " + txtTicket.Text, connTienda)

            If dtTemporal.Rows(0)("prepago") = 1 Then
                Dim item As New ListViewItem("")
                item.SubItems.Add("")
                item.SubItems.Add("Recarga tarjeta")
                item.SubItems.Add("1")
                item.SubItems.Add(FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(dtTemporal.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True))
                lvwLíneasTicket.Items.AddRange(New ListViewItem() {item})
            End If
        Else
            For n = 0 To dtLíneas.Rows.Count - 1
                cCódigo = dtLíneas.Rows(n)("linea").ToString
                Dim item As New ListViewItem(cCódigo)
                item.SubItems.Add(dtLíneas.Rows(n)("codigo").ToString)

                dtArtículo = CargaTabla("SELECT descripcion FROM art_index WHERE codigo = " + GrabaComillas(Microsoft.VisualBasic.Left(dtLíneas.Rows(n)("codigo").ToString, 10)), connTienda)

                If dtArtículo.Rows.Count = 0 Then
                    item.SubItems.Add("")
                Else
                    item.SubItems.Add(dtArtículo.Rows(0)("descripcion").ToString)
                End If

                nTotal += dtLíneas.Rows(n)("cantidad") * dtLíneas.Rows(n)("pventa")

                item.SubItems.Add(FormatNumber(dtLíneas.Rows(n)("cantidad"), 0, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(dtLíneas.Rows(n)("pventa"), 2, TriState.True, TriState.False, TriState.True))
                item.SubItems.Add(FormatCurrency(dtLíneas.Rows(n)("cantidad") * dtLíneas.Rows(n)("pventa"), 2, TriState.True, TriState.False, TriState.True))
                lvwLíneasTicket.Items.AddRange(New ListViewItem() {item})

                My.Application.DoEvents()
            Next
        End If

        txtTotalLíneas.Text = FormatNumber(nTotal, 2, TriState.True, TriState.False, TriState.True)
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Dim nSize As System.Drawing.Size

        If lFiltrando Then
            BorraCampos()
            ActivaBotones()
            DesactivaCampos()
            lFiltrando = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        If lModificando Then
            ActivaBotones()
            DesactivaCampos()
            CargaDatos()
            lModificando = False
            Return
        End If

        If lBuscandoTicket Then
            ActivaBotones()
            DesactivaCampos()
            CargaDatos()
            lBuscandoTicket = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        If lModificandoApertura Then
            txtApertura.ReadOnly = True
            txtCierre.ReadOnly = True
            txtBanco.ReadOnly = True
            lModificandoApertura = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        If lModificandoInventario Then
            lModificandoInventario = False
            nSize.Width = lvwInventario.Size.Width
            nSize.Height = lvwInventario.Size.Height + 150
            lvwInventario.Size = nSize
            lModificandoInventario = False
            CargaInventario()
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        If lModificandoVendedor Then
            lModificandoVendedor = False
            txtNombreVendedor.Visible = False
            chkVendedorActivo.Visible = False
        End If

        lModificando = True
        DesactivaBotones()
        ActivaCampos()
        txtNombre.Focus()
    End Sub

    Private Sub DvTiendas_DoubleClick(sender As Object, e As System.EventArgs) Handles dvTiendas.DoubleClick
        BtnModificar_Click(sender, e)
    End Sub

    Private Sub ChkCerradas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerradas.CheckedChanged
        CargaTiendas()
    End Sub

    Private Sub BtnUVNC_Click(sender As Object, e As EventArgs) Handles btnUVNC.Click
        ConexiónRemota("UVNC")
    End Sub

    Private Sub BtnTeamViewer_Click(sender As Object, e As EventArgs) Handles btnTeamViewer.Click
        ConexiónRemota("TeamViewer")
    End Sub

    Private Sub BtnTightVNC_Click(sender As Object, e As EventArgs) Handles btnTightVNC.Click
        ConexiónRemota("TightVNC")
    End Sub

    Private Sub ConexiónRemota(ByVal cPrograma As String)
        Dim cIP As String

        If nudOrdenadores.Value = 1 Then
            cIP = txtIPTPV.Text
        Else
            Dim obj As New FrmEscogerOrdenador(nudOrdenadores.Value, txtSubred.Text)
            Dim nResultado As Integer = obj.ShowDialog(Me)

            If nResultado <> DialogResult.OK Then Return

            cIP = obj.txtIP.Text
        End If

        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(cIP)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

        If Not (res.Status = NetworkInformation.IPStatus.Success) Then
            MsgBox("No se puede conectar al ordenador")
            Return
        End If

        Select Case cPrograma
            Case "TeamViewer"
                Process.Start(Chr(34) + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TeamViewer", Nothing).ToString + "teamviewer.exe""", " -i " + cIP + " --Password sistemas")

            Case "UVNC"
                Process.Start(Chr(34) + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "UVNC", Nothing).ToString + "vncviewer.exe""", " -connect " + cIP + " -password sistemas")

            Case "TightVNC"
                Process.Start(Chr(34) + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", Nothing).ToString + "tvnviewer.exe""", " -host=" + cIP + " -password=sistemas")

            Case Else
                MsgBox("Programa de conexión remota inexistente", MsgBoxStyle.Critical, "Atención")
        End Select
    End Sub

    Private Sub BtnPing_Click(sender As Object, e As EventArgs) Handles btnPing.Click
        Dim cSubRed As String = txtSubred.Text

        If String.IsNullOrEmpty(txtSubred.Text) Then Return

        btnPing.Visible = False
        lblPing.Visible = True
        lblRouter.ForeColor = Color.Black
        lblServidor.ForeColor = Color.Black
        lblTeléfono.ForeColor = Color.Black
        lblPingRouter.Visible = False
        lblPingServidor.Visible = False
        lblPingTeléfono.Visible = False
        My.Application.DoEvents()

        If Not String.IsNullOrWhiteSpace(cSubRed) Then
            If comboEstado.Text <> "CERRADA" Then
                Dim eco As New System.Net.NetworkInformation.Ping
                Dim ip As IPAddress = IPAddress.Parse(txtRouter.Text)
                Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

                If res.Status = NetworkInformation.IPStatus.Success Then
                    lblRouter.ForeColor = Color.Green
                    lblPingRouter.Text = res.RoundtripTime.ToString + " ms"
                    lblPingRouter.Visible = True
                Else
                    lblRouter.ForeColor = Color.Red
                End If

                My.Application.DoEvents()

                If Not String.IsNullOrWhiteSpace(txtIPTPV.Text) Then
                    ip = IPAddress.Parse(txtIPTPV.Text)
                    res = eco.Send(ip)

                    If res.Status = NetworkInformation.IPStatus.Success Then
                        lblServidor.ForeColor = Color.Green
                        lblPingServidor.Text = res.RoundtripTime.ToString + " ms"
                        lblPingServidor.Visible = True
                    Else
                        lblServidor.ForeColor = Color.Red
                    End If

                    My.Application.DoEvents()
                End If

                If Not String.IsNullOrWhiteSpace(txtIPTeléfono1.Text) Then
                    ip = IPAddress.Parse(txtIPTeléfono1.Text)
                    res = eco.Send(ip)

                    If res.Status = NetworkInformation.IPStatus.Success Then
                        lblTeléfono.ForeColor = Color.Green
                        lblPingTeléfono.Text = res.RoundtripTime.ToString + " ms"
                        lblPingTeléfono.Visible = True
                    Else
                        lblTeléfono.ForeColor = Color.Red
                    End If

                    My.Application.DoEvents()
                End If

            End If
        End If

        btnPing.Visible = True
        lblPing.Visible = False
    End Sub

    Private Sub BtnMySQL_Click(sender As Object, e As EventArgs) Handles btnMySQL.Click
        If String.IsNullOrEmpty(txtIPTPV.Text) Then
            MsgBox("No hay IP para esta tienda",, "Error")
            Return
        End If

        Dim cIP As String = txtIPTPV.Text
        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(cIP)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)
        Dim cComando As String
        Dim cParámetros As String

        If Not (res.Status = NetworkInformation.IPStatus.Success) Then
            MsgBox("No se puede conectar al ordenador")
            Return
        End If

        cComando = Chr(34) + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", Nothing).ToString + "MySQLWorkbench.exe"""
        cParámetros = " --query root@" + cIP
        Process.Start(cComando, cParámetros)
    End Sub

    Private Sub BtnFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnFecha.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaApertura.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtFechaApertura_Leave(sender, e)
    End Sub

    Private Sub TxtFechaApertura_Leave(sender As Object, e As System.EventArgs) Handles txtFechaApertura.Leave
        Dim cSQL As String
        Dim dtApertura, dtCuenta, dtTienda, dtCierre, dtFestivos As DataTable

        If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then
            MsgBox("Debe seleccionar una tienda o IP de tienda no definida", MsgBoxStyle.Critical, "Atención")
            Return
        End If

        BorraCamposApertura(False)

        If String.IsNullOrWhiteSpace(txtFechaApertura.Text) Then
            MsgBox("Debe seleccionar una fecha", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        CambiaCursor("Leyendo datos ...")

        cSQL = "SELECT * FROM festivos WHERE fecha = " + DtoSQL(txtFechaApertura.Text) + " AND poblacion = " + GrabaComillas(txtPoblación.Text)
        dtFestivos = CargaTabla(cSQL)

        If dtFestivos.Rows.Count = 0 Then
            lblFestivoApertura.Visible = False
        Else
            lblFestivoApertura.Text = "Festivo " + dtFestivos.Rows(0)("tipo").ToLower
            lblFestivoApertura.Visible = True
        End If

        My.Application.DoEvents()

        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

        If Not (res.Status = NetworkInformation.IPStatus.Success) Then
            MsgBox("No se puede conectar con la tienda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            CambiaCursor("")
            Return
        End If

        connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
        cSQL = "SELECT total_apertura, caja_real, total_ingresos, ingreso_banco, cerrado FROM cierre WHERE fecha = " + DtoSQL(txtFechaApertura.Text)
        dtApertura = CargaTabla(cSQL, connTienda)

        If dtApertura.Rows.Count = 0 Then
            MsgBox("No hay apertura en esa fecha", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            CambiaCursor("")
            Return
        End If

        If dtApertura.Rows(0)("cerrado") = 0 Then
            lblEstadoCaja.Text = "Abierta"
            lblEstadoCaja.ForeColor = Color.Green
        Else
            lblEstadoCaja.Text = "Cerrada"
            lblEstadoCaja.ForeColor = Color.Red
        End If

        txtApertura.Text = Str(dtApertura.Rows(0)("total_apertura"))
        txtCierre.Text = Str(dtApertura.Rows(0)("caja_real"))
        txtIngresos.Text = Str(dtApertura.Rows(0)("total_ingresos"))
        txtBanco.Text = Str(dtApertura.Rows(0)("ingreso_banco"))

        cSQL = "SELECT * from cuentas_corrientes WHERE defecto = 1"
        dtCuenta = CargaTabla(cSQL, connTienda)

        If dtCuenta.Rows.Count > 0 Then
            txtCódigoBanco.Text = dtCuenta.Rows(0)("id").ToString
            txtCCC.Text = dtCuenta.Rows(0)("entidad") + " " + dtCuenta.Rows(0)("sucursal") + " " + dtCuenta.Rows(0)("dc") + " " + dtCuenta.Rows(0)("cuenta")
        End If

        cSQL = "SELECT idempresa FROM tiendas WHERE codigo = " + txtCódigo.Text
        dtTienda = CargaTabla(cSQL)
        cODBCInformix = ODBC(dtTienda.Rows(0)("idempresa"))

        If Not String.IsNullOrEmpty(cODBCInformix) Then
            cSQL = "SELECT * FROM cierre WHERE fecha = " + FechaInformix(txtFechaApertura.Text) + " AND cod_cli = " + txtCódigo.Text
            connInformix = ConexiónCentral(cODBCInformix)
            dtCierre = CargaTabla(cSQL, connInformix)

            If dtCierre.Rows.Count > 0 Then
                lblProcesado.Text = "Venta procesada"
                lblProcesado.ForeColor = Color.Green
            Else
                lblProcesado.Text = "Venta no procesada"
                lblProcesado.ForeColor = Color.Red
            End If
        End If

        CambiaCursor("")
    End Sub

    Private Sub BtnAbrirCaja_Click(sender As Object, e As EventArgs) Handles btnAbrirCaja.Click
        If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then Return

        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de abrir la caja?",
                  MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
            cSQL = "UPDATE cierre SET cerrado = 0 WHERE fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)
            connTienda.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Apertura Decimal caja", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connTienda.Close()

            MsgBox("Caja abierta", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Operación realizada")
            lblEstadoCaja.Text = "Abierta"
            lblEstadoCaja.ForeColor = Color.Green
        End If
    End Sub

    Private Sub BtnModificarApertura_Click(sender As Object, e As EventArgs) Handles btnModificarApertura.Click
        txtFechaApertura.ReadOnly = True
        txtApertura.ReadOnly = False
        txtCierre.ReadOnly = False
        txtBanco.ReadOnly = False
        lModificandoApertura = True
        DesactivaBotones()
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtApertura.SelectAll()
        txtApertura.Focus()
    End Sub

    Private Sub BtnBorrarDía_Click(sender As Object, e As EventArgs) Handles btnBorrarDía.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then Return
        If String.IsNullOrWhiteSpace(txtFechaApertura.Text) Then Return

        If MsgBox("¿Está seguro de borrar las ventas del " + txtFechaApertura.Text + " en el TPV de la tienda?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            If MsgBox("Esta operación es irreversible, confirme el borrado.", MsgBoxStyle.Critical + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Cancel Then Return

            Me.Height += 30
            ssProgreso.Visible = True
            pbProgreso.Minimum = 0
            pbProgreso.Maximum = 8
            pbProgreso.Value = 0
            pbProgreso.Visible = True
            lblMensaje.Text = "Líneas de venta"
            My.Application.DoEvents()

            cSQL = "delete from lineas_venta where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            connTienda.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de líneas de venta", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 1
            lblMensaje.Text = "Movimientos de caja"
            My.Application.DoEvents()

            cSQL = "delete from mov_caja where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de movimientos de caja", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 2
            lblMensaje.Text = "Ventas promociones"
            My.Application.DoEvents()

            cSQL = "delete from vent_promo where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado Ventas promoción", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Devoluciones"
            pbProgreso.Value = 3
            My.Application.DoEvents()
            cSQL = "delete from devoluciones where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado devoluciones", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 4
            lblMensaje.Text = "Facturas"
            My.Application.DoEvents()
            cSQL = "delete from facturas where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de facturas", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 5
            lblMensaje.Text = "Devoluciones"
            My.Application.DoEvents()
            cSQL = "delete from devoluciones where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de devoluciones", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 6
            lblMensaje.Text = "Ventas"
            My.Application.DoEvents()
            cSQL = "delete from venta where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de Venta", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 7
            lblMensaje.Text = "Movimientos de efectivo"
            My.Application.DoEvents()

            cSQL = "delete from mov_efectivo where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado Decimal movimientos Decimal efectivo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            pbProgreso.Value = 8
            lblMensaje.Text = "Cierre"
            My.Application.DoEvents()

            cSQL = "delete from cierre where fecha = " + DtoSQL(txtFechaApertura.Text)
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de cierre", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connTienda.Close()
            lblMensaje.Text = ""
            pbProgreso.Value = 0
            pbProgreso.Visible = False
            BorraCampos()
            ssProgreso.Visible = False
            Me.Height -= 30
            MsgBox("Día borrado", MsgBoxStyle.Information, "Proceso correcto")
            BorraCamposApertura()
        End If
    End Sub

    Private Sub BtnAlejandro_Click(sender As Object, e As EventArgs) Handles btnAlejandro.Click
        Dim oOutlook As Outlook.Application
        Dim olNs As Outlook.NameSpace
        Dim oMail As Outlook.MailItem
        Dim cTexto As String

        oOutlook = CreateObject("Outlook.Application")
        olNs = oOutlook.GetNamespace("MAPI")
        olNs.Logon()
        oMail = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
        oMail.Subject = "Borrado cierre " + lblTiendaApertura.Text + " del " + txtFechaApertura.Text

        cTexto = CabeceraMail() + "Hola chic@s:"
        cTexto += "<o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal>"
        cTexto += "He borrado el cierre de esta tienda por"
        If lMailTicket Then cTexto += " cambio en forma de pago de un ticket (de "

        cTexto += "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>"

        Select Case Environment.UserName
            Case "rafael"
                cTexto += "Rafael Altungy"

            Case "miguel"
                cTexto += "Miguel Juez"

            Case "juancar"
                cTexto += "Juan Carlos Campos"

            Case "fernando"
                cTexto += "Fernando García-Monzón"

            Case "calin"
                cTexto += "Calin Orasanu"

            Case "agus"
                cTexto += "Agustín Moreno"

            Case Else
                cTexto += "Help Desk"
        End Select

        cTexto += "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><img width=341 height=33 id=""Imagen_x0020_1"" src=""\\decimas2018\Departamentos\Informatica\Software\Recursos\LogoPie.jpg"" alt=""Descripción: DecimasPolinesia peq""><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Campus Empresarial Tribeca</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Ctra. Fuencarral, 44</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Edificio 9, L-18<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>28108 - Alcobendas (Madrid)</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Dto. De Informática y Comunicaciones<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Tfno. 913295488 - Ext. "

        Select Case Environment.UserName
            Case "rafael"
                cTexto += "2053"

            Case "miguel"
                cTexto += "2012"

            Case "juancar"
                cTexto += "2037"

            Case "fernando"
                cTexto += "2040"

            Case "calin"
                cTexto += "2125"

            Case "agus"
                cTexto += "2236"

            Case Else
                cTexto += "2300"
        End Select

        cTexto += "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='font-size:7.5pt;color:#A6A6A6;mso-fareast-language:ES'>Este correo electrónico, así como cualquiera de sus anexos, puede contener información confidencial. Su contenido es para uso exclusivo de sus destinatarios, por lo que queda prohibida la difusión, copia o utilización de dicha información por terceros. Si usted lo recibiera por error, por favor, notifíquelo al remitente y elimine el mensaje con todas sus copias.</span><span style='color:#A6A6A6;mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>"

        oMail.HTMLBody = cTexto

        oMail.To = "contabilidadtiendas@decimas.es"
        oMail.Save()
        lMailTicket = False
    End Sub

    Private Sub BtnBuscarTicket_Click(sender As Object, e As EventArgs) Handles btnBuscarTicket.Click
        lBuscandoTicket = True
        BorraCamposTickets()
        DesactivaBotones()
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtTicket.ReadOnly = False
        txtTicket.Focus()
    End Sub

    Private Sub BtnCambiarVendedor_Click(sender As Object, e As EventArgs) Handles btnCambiarVendedor.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        cSQL = "UPDATE venta SET vendedor = " + comboVendedor.SelectedValue.ToString + " WHERE num_doc = " + txtTicket.Text
        cmd = New MySqlCommand(cSQL, connTienda)
        connTienda.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Cambio de vendedor en cabecera", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmd.Dispose()
        End Try

        cSQL = "UPDATE lineas_venta SET vendedor = " + comboVendedor.SelectedValue.ToString + " WHERE num_doc = " + txtTicket.Text
        cmd = New MySqlCommand(cSQL, connTienda)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Cambio de vendedor en líneas", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmd.Dispose()
        End Try

        connTienda.Close()

        MsgBox("Vendedor cambiado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Operación realizada")
    End Sub

    Private Sub BtnEliminarTicket_Click(sender As Object, e As EventArgs) Handles btnEliminarTicket.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then Return

        If MsgBox("¿Está seguro de eliminar este ticket?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            If MsgBox("Esta operación es irreversible, confirme el borrado.", MsgBoxStyle.Critical + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Cancel Then Return

            Me.Height += 30
            ssProgreso.Visible = True
            pbProgreso.Minimum = 0
            pbProgreso.Maximum = 4
            pbProgreso.Value = 0
            pbProgreso.Visible = True
            lblMensaje.Text = "Movimientos caja"
            My.Application.DoEvents()

            cSQL = "delete from mov_caja where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            connTienda.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de movimiento de caja en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Factura"
            pbProgreso.Value = 1
            My.Application.DoEvents()
            cSQL = "delete from facturas where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de factura en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Devoluciones"
            pbProgreso.Value = 2
            My.Application.DoEvents()
            cSQL = "delete from devoluciones where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de devoluciones en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Líneas venta"
            pbProgreso.Value = 2
            My.Application.DoEvents()
            cSQL = "delete from lineas_venta where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de líneas de venta en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Ventas promoción"
            pbProgreso.Value = 3
            My.Application.DoEvents()
            cSQL = "delete from vent_promo where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de ventas promoción en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            lblMensaje.Text = "Ventas"
            pbProgreso.Value = 4
            My.Application.DoEvents()
            cSQL = "delete from venta where num_doc = " + txtTicket.Text
            cmd = New MySqlCommand(cSQL, connTienda)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de cabecera de ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connTienda.Close()
            lblMensaje.Text = ""
            pbProgreso.Value = 0
            pbProgreso.Visible = False
            ssProgreso.Visible = False
            Me.Height -= 30
            MsgBox("Ticket borrado", MsgBoxStyle.Information, "Proceso correcto")
            BorraCamposTickets()
        End If
    End Sub

    Private Sub BtnAgregarPago_Click(sender As Object, e As EventArgs) Handles btnAgregarPago.Click
        Dim cTexto As String = connTienda.ConnectionString
        Dim oVentana As New FrmPagoTicket

        cTexto += ";password=root" + Chr(255) + txtTicket.Text
        cTexto += Chr(255) + "0"
        cTexto += Chr(255) + txtFechaTicket.Text
        cTexto += Chr(255)
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        oVentana.Dispose()
        CargaPagos()
    End Sub

    Private Sub BtnEliminarPago_Click(sender As Object, e As EventArgs) Handles btnEliminarPago.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lvwPagos.SelectedItems.Count = 0 Then
            MsgBox("No ha seleccionado ninguna línea de pago", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar esta forma de pago?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM mov_caja WHERE num_doc = " + txtTicket.Text + " AND num_mov = " + lvwPagos.SelectedItems(0).SubItems(0).Text

            connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
            cmd = New MySqlCommand(cSQL, connTienda)
            connTienda.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de forma de pago en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            dtPagos = CargaTabla("SELECT * FROM mov_caja WHERE num_doc = " + txtTicket.Text + " ORDER BY num_mov", connTienda)

            For n = 0 To dtPagos.Rows.Count - 1
                cSQL = "UPDATE mov_caja SET num_mov = " + (n + 1).ToString + " WHERE num_doc = " + txtTicket.Text + " AND num_mov = " + dtPagos.Rows(n)("num_mov").ToString
                cmd = New MySqlCommand(cSQL, connTienda)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Actulización de movimientos de caja", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    obj.Dispose()
                    If nResultado = DialogResult.Cancel Then Me.Close()
                Finally
                    cmd.Dispose()
                End Try
            Next

            connTienda.Close()

            MsgBox("Línea Borrada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Operación realizada")
            CargaPagos()
        End If
    End Sub

    Private Sub LvwPagos_DoubleClickChanged(sender As Object, e As EventArgs) Handles lvwPagos.DoubleClick
        Dim cTexto As String = connTienda.ConnectionString
        Dim oVentana As New FrmPagoTicket

        If lvwPagos.SelectedItems.Count = 0 Then
            oVentana.Dispose()
            Return
        End If

        cTexto += ";password=root" + Chr(255) + txtTicket.Text
        cTexto += Chr(255) + lvwPagos.SelectedItems(0).SubItems(0).Text
        cTexto += Chr(255) + txtFechaTicket.Text
        cTexto += Chr(255)
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        oVentana.Dispose()
        CargaPagos()
    End Sub

    Private Sub BtnAgregarLínea_Click(sender As Object, e As EventArgs) Handles btnAgregarLínea.Click
        Dim cTexto As String = connTienda.ConnectionString
        Dim oVentana As New FrmLíneaTicket

        cTexto += ";password=root" + Chr(255) + txtTicket.Text
        cTexto += Chr(255) + "0"
        cTexto += Chr(255) + txtFechaTicket.Text
        cTexto += Chr(255)
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        oVentana.Dispose()
        CargaLíneasTicket()
    End Sub

    Private Sub BtnEliminarLínea_Click(sender As Object, e As EventArgs) Handles btnEliminarLínea.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lvwLíneasTicket.SelectedItems.Count = 0 Then
            MsgBox("No ha seleccionado ninguna línea de ticket", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar esta línea?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM lineas_venta WHERE num_doc = " + txtTicket.Text + " AND linea = " + lvwLíneasTicket.SelectedItems(0).SubItems(0).Text

            connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
            cmd = New MySqlCommand(cSQL, connTienda)
            connTienda.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Borrado de línea de venta en ticket", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            dtLíneas = CargaTabla("SELECT * FROM lineas_venta WHERE num_doc = " + txtTicket.Text + " ORDER BY linea", connTienda)

            For n = 0 To dtLíneas.Rows.Count - 1
                cSQL = "UPDATE lineas_venta SET linea = " + (n + 1).ToString + " WHERE num_doc = " + txtTicket.Text + " AND linea = " + dtLíneas.Rows(n)("linea").ToString
                cmd = New MySqlCommand(cSQL, connTienda)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Actualización  de líneas de venta en ticket", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    obj.Dispose()
                    If nResultado = DialogResult.Cancel Then Me.Close()
                Finally
                    cmd.Dispose()
                End Try
            Next

            connTienda.Close()

            MsgBox("Línea Borrada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Operación realizada")
            CargaLíneasTicket()
        End If
    End Sub

    Private Sub LvwLíneasTicket_DoubleClick(sender As Object, e As EventArgs) Handles lvwLíneasTicket.DoubleClick
        Dim cTexto As String = connTienda.ConnectionString
        Dim oVentana As New FrmLíneaTicket

        If lvwLíneasTicket.SelectedItems.Count = 0 Then
            oVentana.Dispose()
            Return
        End If

        cTexto += ";password=root" + Chr(255) + txtTicket.Text
        cTexto += Chr(255) + lvwLíneasTicket.SelectedItems(0).SubItems(0).Text
        cTexto += Chr(255) + txtFechaTicket.Text
        cTexto += Chr(255)
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        oVentana.Dispose()
        CargaLíneasTicket()
    End Sub

    Private Sub BtnBuscarVale_Click(sender As Object, e As EventArgs) Handles btnBuscarVale.Click
        lBuscandoVale = True
        BorraCamposVales()
        DesactivaBotones()
        txtVale.ReadOnly = False
        txtTicketVale.ReadOnly = False
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtVale.Focus()
    End Sub

    Private Sub BtnFechaVale_Click(sender As Object, e As EventArgs) Handles btnFechaVale.Click
        Dim obj As New FrmValesPorFecha
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        obj.Dispose()
        If nResultado = DialogResult.Cancel Then Return
        BorraCamposVales()
        txtVale.Text = obj.lvwVales.SelectedItems.Item(0).SubItems(0).Text
        lBuscandoVale = True
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub BtnLiquidarVale_Click(sender As Object, e As EventArgs) Handles btnLiquidarVale.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim cmdInformix As OdbcCommand
        'Dim connInformix As New OdbcConnection

        If String.IsNullOrWhiteSpace(txtIPTPV.Text) Then Return

        If MsgBox("¿Está seguro de liquidar este vale?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            If chkLiquidadoTienda.Text = "Tienda" Then
                cSQL = "update vales set liquidado = 1 where num_vale = " + GrabaComillas(txtVale.Text)
                cmd = New MySqlCommand(cSQL, connTienda)

                connTienda.Open()

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Liquidar vale en tienda", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    obj.Dispose()
                    If nResultado = DialogResult.Cancel Then Me.Close()
                Finally
                    cmd.Dispose()
                End Try

                connTienda.Close()
                chkLiquidadoTienda.Checked = True
            End If

            If chkLiquidadoCentral.Text = "Central" Then
                connInformix = ConexiónCentral(cODBCInformix)
                cSQL = "UPDATE vales SET liquidado = 1 WHERE num_vale = " + GrabaComillas(txtVale.Text)
                cmdInformix = New OdbcCommand(cSQL, connInformix)
                connInformix.Open()

                Try
                    cmdInformix.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Liquidar vale en Central", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    obj.Dispose()
                    If nResultado = DialogResult.Cancel Then Me.Close()
                Finally
                    cmdInformix.Dispose()
                End Try

                connInformix.Close()
                chkLiquidadoCentral.Checked = True
            End If

            btnLiquidarVale.Visible = False
        End If
    End Sub

    Private Sub BtnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click
        Dim cSQL As String = "UPDATE vales SET impreso = 0 WHERE num_vale = " + GrabaComillas(txtVale.Text)
        Dim cmd As MySqlCommand

        If String.IsNullOrEmpty(txtVale.Text) Then Return

        cmd = New MySqlCommand(cSQL, connTienda)
        connTienda.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Reimprimir vale", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmd.Dispose()
        End Try

        connTienda.Close()
    End Sub

    Private Sub BtnBuscarValeCentral_Click(sender As Object, e As EventArgs) Handles btnBuscarValeCentral.Click
        lBuscandoValeCentral = True
        BorraCamposValesCentral()
        DesactivaBotones()
        ActivaCamposValeCentral()
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtValeCentral.Focus()
    End Sub

    Private Sub BtnFechaInicioValeCentral_Click(sender As Object, e As EventArgs) Handles btnFechaInicioValeCentral.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaInicioValeCentral.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFechaFinValeCentral_Click(sender As Object, e As EventArgs) Handles btnFechaFinValeCentral.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaFinValeCentral.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub DvValesCentral_Click(sender As Object, e As EventArgs) Handles dvValesCentral.Click
        CargaValeCentral()
    End Sub

    Private Sub CargaValeCentral()
        Dim cSQL As String
        Dim cConexión As String
        'Dim connInformix As New OdbcConnection
        Dim dtTemporal As DataTable
        Dim cEmpresa As String

        cSQL = "SELECT v.num_vale, v.cod_cli AS cliente_emisor, v.fecha, v.num_doc, cc.tienda, v.valor, v.liquidado, clientemc, mc.nombre_tienda AS tienda_liq, mc.fecha_liq AS fecha_liq, mc.num_doc AS ticket_liq "
        cSQL += "FROM vales v INNER JOIN clientes_comercial cc on v.cod_cli=cc.codigo "
        cSQL += "LEFT JOIN (SELECT cc.tienda AS nombre_tienda, mc.cod_cli AS clientemc, mc.fecha AS fecha_liq, mc.num_doc AS num_doc, mc.num_vale AS num_vale FROM clientes_comercial cc, mov_caja mc "
        cSQL += "WHERE cc.codigo=mc.cod_cli AND mc.valor>0  AND mc.num_vale = '" + dvValesCentral.SelectedRows.Item(0).Cells(1).Value.ToString + "' AND mc.tipo=3) mc ON v.num_vale=mc.num_vale"
        cSQL += " WHERE v.num_vale = '" + dvValesCentral.SelectedRows.Item(0).Cells(1).Value.ToString + "'"

        cEmpresa = GuardaEmpresaValeCentral()
        cConexión = ConexiónInformix(cEmpresa)
        connInformix = New OdbcConnection With {.ConnectionString = cConexión}
        dtTemporal = CargaTabla(cSQL, connInformix)


        BorraCamposValesCentral()
        txtValeCentral.Text = dtTemporal.Rows(0)(0)
        txtFechaInicioValeCentral.Text = FormatDateTime(dtTemporal.Rows(0)(2), DateFormat.GeneralDate)
        txtEmisorValeCentral.Text = dtTemporal.Rows(0)(1)
        txtNombreEmisorValeCentral.Text = dvValesCentral.SelectedRows.Item(0).Cells(2).Value.ToString
        txtImporteCentralVale.Text = FormatNumber(Val(dvValesCentral.SelectedRows.Item(0).Cells(3).Value), 2, TriState.True, TriState.False, TriState.True)
        txtTicketValeCentral.Text = dtTemporal.Rows(0)(3).ToString
        chkLiquidadoValeCentral.Checked = dtTemporal.Rows(0)(6)

        If chkLiquidadoValeCentral.Checked Then
            txtLiquidadorValeCentral.Text = dtTemporal.Rows(0)(7).ToString
            txtNombreLiquidadorValeCentral.Text = dtTemporal.Rows(0)(8).ToString
            If Not IsDBNull(dtTemporal.Rows(0)(9)) Then txtFechaLiquidadoValeCentral.Text = FormatDateTime(dtTemporal.Rows(0)(9), DateFormat.GeneralDate)
            txtTicketLiquidadoValeCentral.Text = dtTemporal.Rows(0)(10).ToString
        End If

        dtTemporal.Dispose()
        PonEmpresaValeCentral(cEmpresa)
    End Sub

    Private Function GuardaEmpresaValeCentral() As String
        Dim cEmpresa As String = ""

        If radioDécimas.Checked Then cEmpresa = "DECIMAS"
        If radioAdidas.Checked Then cEmpresa = "ADIDAS"
        If radioPolinesia.Checked Then cEmpresa = "POLINESIA"
        If radioInvain.Checked Then cEmpresa = "INVAIN"

        Return (cEmpresa)
    End Function

    Private Sub PonEmpresaValeCentral(ByVal cEmpresa As String)
        Select Case cEmpresa
            Case "ADIDAS"
                radioAdidas.Checked = True
            Case "DECIMAS"
                radioDécimas.Checked = True
            Case "INVAIN"
                radioInvain.Checked = True
            Case "POLINESIA"
                radioPolinesia.Checked = True
        End Select
    End Sub

    Private Sub DvValesCentral_DoubleClick(sender As Object, e As EventArgs) Handles dvValesCentral.DoubleClick
        Dim cSQL As String = "SELECT * FROM tiendas WHERE codigo = " + txtEmisorValeCentral.Text
        Dim dtTemporal As DataTable = CargaTabla(cSQL, connMySQL)
        Dim cEmpresa As String = GuardaEmpresaValeCentral()

        nTienda = dtTemporal.Rows(0)("codigo")
        CargaDatos()
        PonEmpresaValeCentral(cEmpresa)
        CargaValeCentral()
        tabTiendas.SelectedIndex = 6
        txtVale.Text = txtValeCentral.Text
        lBuscandoVale = True
        dtTemporal.Dispose()
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub BtnAgregarInventario_Click(sender As Object, e As EventArgs) Handles btnAgregarInventario.Click
        Dim nSize As System.Drawing.Size

        If String.IsNullOrWhiteSpace(txtCódigo.Text) Then Return

        BorraCamposInventario()
        nSize.Width = lvwInventario.Size.Width
        nSize.Height = lvwInventario.Size.Height - 150
        lvwInventario.Size = nSize

        lModificandoInventario = True
        txtEnvío.Text = Format(Now, "d")
        txtCantidad.Text = "1"
        ActivaCamposInventario()
        DesactivaBotones()
        txtSerie.Focus()
    End Sub

    Private Sub BtnModificarInventario_Click(sender As Object, e As EventArgs) Handles btnModificarInventario.Click
        Dim nSize As System.Drawing.Size

        nSize.Width = lvwInventario.Size.Width
        nSize.Height = lvwInventario.Size.Height - 150
        lvwInventario.Size = nSize

        lModificandoInventario = True
        ActivaCamposInventario()
        DesactivaBotones()
        txtArtículo.Focus()
    End Sub

    Private Sub BtnEliminarInventario_Click(sender As Object, e As EventArgs) Handles btnEliminarInventario.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lvwInventario.SelectedItems.Count = 0 Then Return

        If MsgBox("¿Está seguro de eliminar esta línea?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM inventario WHERE idinventario = " + lvwInventario.SelectedItems(0).Text
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Eliminar línea de inventario", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()
            CargaInventario()
        End If
    End Sub

    Private Sub BtnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nCódigo As Integer
        Dim dtTemporal As DataTable
        Dim nFactura As Integer
        Dim nArtículo As Integer

        If chkFacturable.Checked = False Then
            MsgBox("Artículo no facturable", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtSerie.Text) Then
            MsgBox("No se puede facturar sin número de serie", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
            Return
        End If

        nCódigo = ChequeaFacturado(nTienda)

        If nCódigo <> 0 Then
            If MsgBox("Artículo facturado a " + NombreTienda(nCódigo) + Chr(13) +
                          "¿Desea continuar?",
                          MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then
                Return
            End If
        End If

        If MsgBox("¿Está seguro de facturar esta línea?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        cSQL = "INSERT INTO cabfacturainterna(fecha, idtienda) VALUES("
        cSQL += DtoSQL(Format(Now, "d")) + ", "
        cSQL += nTienda.ToString + ")"
        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Facturar línea de inventario", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
            connMySQL.Close()
            Return
        Finally
            cmd.Dispose()
        End Try

        cSQL = "SELECT idfactura FROM cabfacturainterna ORDER BY idfactura DESC LIMIT 1"
        dtTemporal = CargaTabla(cSQL, connMySQL)
        nFactura = dtTemporal.Rows(0)("idfactura")

        cSQL = "SELECT idarticulo FROM articulos WHERE serie = " + GrabaComillas(txtSerie.Text)
        dtTemporal = CargaTabla(cSQL, connMySQL)

        If dtTemporal.Rows.Count = 0 Then
            cSQL = "INSERT INTO articulos(serie, nombre, descripcion, "
            If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then cSQL += "compra, garantia, "
            cSQL += "idproveedor, factura, precio) VALUES("
            cSQL += GrabaComillas(txtSerie.Text) + ", "
            cSQL += GrabaComillas(Memo2Array(txtArtículo.Text, 40)(0)) + ", "
            cSQL += GrabaComillas(txtArtículo.Text) + ", "

            If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then
                cSQL += FechaInformix(txtFechaFactura.Text) + ", "
                cSQL += FechaInformix(DateAdd(DateInterval.Year, 2, Convert.ToDateTime(txtFechaFactura.Text))) + ", "
            End If

            cSQL += If(String.IsNullOrWhiteSpace(comboProveedorInventario.Text), "0", comboProveedorInventario.SelectedValue.ToString) + ", "
            cSQL += GrabaComillas(txtFactura.Text) + ", "
            cSQL += Str(Val(txtPrecio.Text)) + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Agregar artículo inventario al facturar", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()

                cSQL = "DELETE FROM cabfacturainterna WHERE idfactura = " + nFactura.ToString
                cmd = New MySqlCommand(cSQL, connMySQL)
                cmd.ExecuteNonQuery()
                connMySQL.Close()
                Return
            Finally
                cmd.Dispose()
            End Try

            cSQL = "SELECT idarticulo FROM articulos ORDER BY idarticulo DESC LIMIT 1"
            dtTemporal = CargaTabla(cSQL, connMySQL)
            nArtículo = dtTemporal.Rows(0)("idarticulo")
        Else
            nArtículo = dtTemporal.Rows(0)("idarticulo")
        End If

        cSQL = "INSERT INTO linfacturainterna(idfactura, idarticulo, descripcion, precio, idproveedor, factura, fecha) VALUES("
        cSQL += nFactura.ToString + ", "
        cSQL += nArtículo.ToString + ", "
        cSQL += GrabaComillas(txtArtículo.Text) + ", "
        cSQL += Str(Val(txtPrecio.Text)) + ", "
        cSQL += If(String.IsNullOrWhiteSpace(comboProveedorInventario.Text), "0", comboProveedorInventario.SelectedValue.ToString) + ", "
        cSQL += DtoSQL(txtFactura.Text) + ", "
        cSQL += DtoSQL(txtEnvío.Text) + ")"

        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Agregar línea de factura interna", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()

            cSQL = "DELETE FROM cabfacturainterna WHERE idfactura = " + nFactura.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            cmd.ExecuteNonQuery()
        Finally
            cmd.Dispose()
        End Try

        connMySQL.Close()
        dtTemporal.Dispose()
        btnFacturar.Visible = False
    End Sub

    Private Function ChequeaFacturado(ByVal nCódigo As Integer) As Integer
        Dim cSQL As String
        Dim dtTemporal As DataTable
        Dim nFacturado As Integer = 0

        cSQL = "SELECT idarticulo FROM articulos WHERE serie = " + GrabaComillas(txtSerie.Text)
        dtTemporal = CargaTabla(cSQL, connMySQL)

        If dtTemporal.Rows.Count > 0 Then
            cSQL = "SELECT linfacturainterna.idfactura, idarticulo, idtienda FROM linfacturainterna, cabfacturainterna "
            cSQL += "WHERE linfacturainterna.idfactura = cabfacturainterna.idfactura AND "
            cSQL += "idarticulo = " + dtTemporal.Rows(0)("idarticulo").ToString
            dtTemporal = CargaTabla(cSQL, connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                nFacturado = 0
            Else
                If nCódigo = 0 Then
                    nFacturado = dtTemporal.Rows(0)("idtienda")
                End If

                For n = 0 To dtTemporal.Rows.Count - 1
                    If dtTemporal.Rows(n)("idtienda") = nCódigo Then
                        nFacturado = nCódigo
                        Exit For
                    End If
                Next
            End If
        End If

        dtTemporal.Dispose()
        Return (nFacturado)
    End Function

    Private Sub LvwInventario_Click(sender As Object, e As EventArgs) Handles lvwInventario.Click
        Dim dtInventario As DataTable

        nInventario = Val(lvwInventario.SelectedItems(0).Text)
        dtInventario = CargaTabla("SELECT * FROM inventario WHERE idinventario = " + nInventario.ToString, connMySQL)

        If dtInventario.Rows.Count > 0 Then
            txtArtículo.Text = dtInventario.Rows(0)("articulo")
            txtUsuario.Text = dtInventario.Rows(0)("usuario")
            txtSerie.Text = dtInventario.Rows(0)("serie")
            txtEnvío.Text = Format(dtInventario.Rows(0)("fecha"), "d")
            chkFacturable.Checked = dtInventario.Rows(0)("facturable")
            txtCantidad.Text = FormatNumber(dtInventario.Rows(0)("cantidad"), 0, TriState.True, TriState.False, TriState.True)
            txtPrecio.Text = Str(dtInventario.Rows(0)("precio"))
            comboProveedor.SelectedValue = dtInventario.Rows(0)("idproveedor")
            comboProveedorInventario.Text = NombreProveedor(dtInventario.Rows(0)("idproveedor"))
            txtFactura.Text = dtInventario.Rows(0)("factura")
            If Not String.IsNullOrWhiteSpace(dtInventario.Rows(0)("fechafactura").ToString) Then txtFechaFactura.Text = Format(dtInventario.Rows(0)("fechafactura"), "d")

            If dtInventario.Rows(0)("facturable") Then
                If ChequeaFacturado(nTienda) = nTienda Then
                    btnFacturar.Visible = False
                Else
                    btnFacturar.Visible = True
                End If
            Else
                btnFacturar.Visible = False
            End If
        End If

        dtInventario.Dispose()
    End Sub

    Private Sub LvwInventario_DoubleClick(sender As Object, e As EventArgs) Handles lvwInventario.DoubleClick
        BtnModificarInventario_Click(sender, e)
    End Sub

    Private Sub TxtSerie_Leave(sender As Object, e As EventArgs) Handles txtSerie.Leave
        If String.IsNullOrWhiteSpace(txtArtículo.Text) Then
            Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM articulos WHERE serie = " + GrabaComillas(txtSerie.Text), connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("Nº de serie no registrado en artículos", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Else
                dtTemporal = CargaTabla("SELECT * FROM articulos WHERE idarticulo = " + dtTemporal.Rows(0)("idarticulo").ToString, connMySQL)

                If dtTemporal.Rows.Count > 0 Then
                    txtArtículo.Text = dtTemporal.Rows(0)("descripcion")
                    chkFacturable.Checked = 1
                    If String.IsNullOrWhiteSpace(txtPrecio.Text) Then txtPrecio.Text = Str(dtTemporal.Rows(0)("precio"))
                    comboProveedorInventario.SelectedValue = dtTemporal.Rows(0)("idproveedor")
                    comboProveedorInventario.Text = NombreProveedor(dtTemporal.Rows(0)("idproveedor"))
                    txtFactura.Text = dtTemporal.Rows(0)("factura")
                    If Not String.IsNullOrWhiteSpace(dtTemporal.Rows(0)("compra").ToString) Then txtFechaFactura.Text = Format(dtTemporal.Rows(0)("compra"), "d")
                End If
            End If

            dtTemporal.Dispose()
        End If
    End Sub

    Private Sub BtnFechaCobro_Click(sender As Object, e As EventArgs) Handles btnFechaCobro.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaCobro.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtFechaCobro_Leave(sender, e)
    End Sub

    Private Sub TxtFechaCobro_Leave(sender As Object, e As EventArgs) Handles txtFechaCobro.Leave
        Dim dtTemporal As DataTable
        Dim lProcesado As Boolean

        If String.IsNullOrEmpty(txtIPTPV.Text) Then
            MsgBox("No hay IP definida para la tienda", MsgBoxStyle.Critical, "Atención")
            Return
        End If

        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

        If Not (res.Status = NetworkInformation.IPStatus.Success) Then
            MsgBox("El servidor no responde", MsgBoxStyle.Critical, "Error")
            Return
        End If

        pbCobros.Minimum = 0
        pbCobros.Value = 0
        pbCobros.Step = 1
        pbCobros.Visible = True
        lblCobros.Text = "Procesando pagos ..."
        lblCobros.Visible = True
        My.Application.DoEvents()

        connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
        dtTemporal = CargaTabla("SELECT num_doc, SUM(valor) AS importe FROM mov_caja WHERE fecha = " + DtoSQL(txtFechaCobro.Text) + " GROUP BY num_doc ORDER BY num_doc", connTienda)
        lvwCobros.Items.Clear()

        Dim aPagos(2, dtTemporal.Rows.Count - 1)

        pbCobros.Value = 0
        pbCobros.Maximum = dtTemporal.Rows.Count

        For n = 0 To dtTemporal.Rows.Count - 1
            aPagos(0, n) = dtTemporal.Rows(n)("num_doc")
            aPagos(1, n) = dtTemporal.Rows(n)("importe")
            pbCobros.PerformStep()
            My.Application.DoEvents()
        Next

        lblCobros.Text = "Procesando líneas ..."
        pbCobros.Value = 0
        My.Application.DoEvents()
        dtTemporal = CargaTabla("SELECT num_doc, SUM(cantidad * pventa) AS importe FROM lineas_venta WHERE fecha = " + DtoSQL(txtFechaCobro.Text) + " GROUP BY num_doc ORDER BY num_doc", connTienda)
        pbCobros.Maximum = dtTemporal.Rows.Count

        For n = 0 To dtTemporal.Rows.Count - 1
            lProcesado = False

            For m = 0 To (aPagos.Length - 1) / 3
                If aPagos(0, m) = dtTemporal.Rows(n)("num_doc") Then
                    aPagos(2, m) = dtTemporal.Rows(n)("importe")
                    lProcesado = True
                    Exit For
                End If
            Next

            If Not lProcesado Then
                ReDim Preserve aPagos(2, aPagos.Length / 3)
                aPagos(0, aPagos.Length / 3 - 1) = dtTemporal.Rows(n)("num_doc")
                aPagos(2, aPagos.Length / 3 - 1) = dtTemporal.Rows(n)("importe")
            End If

            pbCobros.PerformStep()
            My.Application.DoEvents()
        Next

        For n = 0 To (aPagos.Length - 1) / 3
            If aPagos(1, n) <> aPagos(2, n) Then
                dtTemporal = CargaTabla("SELECT prepago FROM venta WHERE num_doc = " + aPagos(0, n).ToString, connTienda)

                If dtTemporal.Rows.Count = 0 Or dtTemporal.Rows(0)("prepago") = 0 Then
                    Dim item As New ListViewItem(aPagos(0, n).ToString)

                    item.SubItems.Add(FormatNumber(aPagos(1, n), 2, TriState.True, TriState.False, TriState.True))
                    item.SubItems.Add(FormatNumber(aPagos(2, n), 2, TriState.True, TriState.False, TriState.True))

                    lvwCobros.Items.AddRange(New ListViewItem() {item})
                End If
            End If
        Next

        lblCobros.Visible = False
        pbCobros.Visible = False
    End Sub

    Private Sub LvwCobros_DoubleClick(sender As Object, e As EventArgs) Handles lvwCobros.DoubleClick
        If lvwCobros.SelectedItems.Count = 0 Then Return

        tabTiendas.SelectedIndex = 5
        BtnBuscarTicket_Click(sender, e)
        txtTicket.Text = lvwCobros.SelectedItems(0).SubItems(0).Text
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim nTicket As Integer = Val(txtTicket.Text) + 1

        If String.IsNullOrWhiteSpace(txtTicket.Text) Then Return
        lBuscandoTicket = True
        BorraCamposTickets()
        txtTicket.Text = nTicket.ToString
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim nTicket As Integer = Val(txtTicket.Text) - 1

        If String.IsNullOrWhiteSpace(txtTicket.Text) Then Return

        lBuscandoTicket = True
        BorraCamposTickets()
        txtTicket.Text = nTicket.ToString
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub BtnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim cResultado, cCódigo, cIP, cTienda As String
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtTemporal As DataTable

        If String.IsNullOrEmpty(txtSQL.Text) Then
            MsgBox("Debe escribir la sentencia SQL a ejecutar")
            Return
        End If

        If dvTiendas.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar al menos una tienda")
            Return
        End If

        If MsgBox("¿Está seguro de ejecutar la sentencia SQL en las tiendas seleccionadas?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Return

        pbSQL.Minimum = 0
        pbSQL.Maximum = dvTiendas.SelectedRows.Count
        pbSQL.Value = 0
        pbSQL.Step = 1
        txtTiendaSQL.Text = ""
        pbSQL.Visible = True
        txtTiendaSQL.Visible = True
        btnEjecutar.Visible = False

        Dim oExcel As Excel.Application
        Dim oBook

        oExcel = CreateObject("Excel.Application")
        oExcel.Visible = False
        oBook = oExcel.Workbooks.Add()

        With oExcel
            .Sheets(1).Select()
            .Range("A1").Value = txtSQL.Text
            .Range("A3").Value = "Código"
            .Range("B3").Value = "IP"
            .Range("C3").Value = "Tienda"
            .Range("D3").Value = "Resultado"
            .Range("A3:D3").Font.Bold = True

            .Range("A3").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            .Columns("B").columnwidth = 14
            .Columns("C").columnwidth = 50
        End With

        For n = 0 To dvTiendas.SelectedRows.Count - 1
            cResultado = ""
            cIP = dvTiendas.SelectedRows(n).Cells(22).Value.ToString + "6"
            cCódigo = dvTiendas.SelectedRows(n).Cells(1).Value.ToString
            cTienda = dvTiendas.SelectedRows(n).Cells(4).Value.ToString
            txtTiendaSQL.Text = cTienda
            pbSQL.PerformStep()
            My.Application.DoEvents()

            If String.IsNullOrEmpty(dvTiendas.SelectedRows(n).Cells(22).Value.ToString) Then
                cResultado = "IP no grabada en ficha de tienda"
            End If

            If String.IsNullOrEmpty(cResultado) Then
                Dim eco As New System.Net.NetworkInformation.Ping
                Dim ip As IPAddress = IPAddress.Parse(cIP)
                Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

                If Not (res.Status = NetworkInformation.IPStatus.Success) Then
                    cResultado = "No hay conexión"
                End If
            End If

            If String.IsNullOrEmpty(cResultado) Then   'Ejecutar sentencia SQL
                connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + cIP + "; Database=tpv; User=root; Password=root"}
                cSQL = txtSQL.Text
                cmd = New MySqlCommand(cSQL, connTienda)

                Try
                    connTienda.Open()
                    cmd.ExecuteNonQuery()
                    cResultado = "Correcto"
                Catch ex As Exception
                    cResultado = ex.Message
                End Try

                connTienda.Close()
            End If


            With oExcel
                .Range("A" + Trim((n + 5).ToString)).Value = cCódigo
                .Range("B" + Trim((n + 5).ToString)).Value = cIP
                .Range("C" + Trim((n + 5).ToString)).Value = cTienda
                .Range("D" + Trim((n + 5).ToString)).Value = cResultado

                Select Case cResultado
                    Case "Correcto"
                        .Range("D" + Trim((n + 5).ToString)).Font.Color = -11489280

                    Case "No hay conexión"
                        .Range("D" + Trim((n + 5).ToString)).Font.Color = -16750849

                    Case Else
                        .Range("D" + Trim((n + 5).ToString)).Font.Color = -11489280
                End Select
            End With
        Next

        pbSQL.Visible = False
        txtTiendaSQL.Visible = False
        btnEjecutar.Visible = True

        If txtSQL.Text <> My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "SQL", Nothing).ToString Then
            cSQL = "SELECT * FROM historicosql WHERE sentencia = " + GrabaComillas(txtSQL.Text)
            dtTemporal = CargaTabla(cSQL, connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                cSQL = "INSERT INTO historicosql(sentencia) VALUES (" + GrabaComillas(txtSQL.Text) + ")"

                cmd = New MySqlCommand(cSQL, connMySQL)
                connMySQL.Open()

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Grabar sentencia SQL", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    If nResultado = DialogResult.Cancel Then Me.Close()
                End Try

                connMySQL.Close()
                PageMySQL_Enter(sender, e)
            End If

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "SQL", txtSQL.Text)
        End If

        oExcel.WindowState = Excel.XlWindowState.xlMaximized
        oExcel.Visible = True
    End Sub

    Private Sub TxtFechaCobro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaCobro.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaCobro_LostFocus(sender As Object, e As EventArgs) Handles txtFechaCobro.LostFocus
        If Not String.IsNullOrEmpty(txtFechaCobro.Text) Then txtFechaCobro.Text = PonSiglo(txtFechaCobro.Text)
    End Sub

    Private Sub TxtFechaApertura_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaApertura.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaApertura_LostFocus(sender As Object, e As EventArgs) Handles txtFechaApertura.LostFocus
        If Not String.IsNullOrEmpty(txtFechaApertura.Text) Then txtFechaApertura.Text = PonSiglo(txtFechaApertura.Text)
    End Sub

    Private Sub TxtFechaEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaEfectivo.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaEfectivo_LostFocus(sender As Object, e As EventArgs) Handles txtFechaEfectivo.LostFocus
        If Not String.IsNullOrEmpty(txtFechaEfectivo.Text) Then txtFechaEfectivo.Text = PonSiglo(txtFechaEfectivo.Text)
    End Sub

    Private Sub TxtFechaFactura_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaFactura.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaFactura_LostFocus(sender As Object, e As EventArgs) Handles txtFechaFactura.LostFocus
        If Not String.IsNullOrEmpty(txtFechaFactura.Text) Then txtFechaFactura.Text = PonSiglo(txtFechaFactura.Text)
    End Sub

    Private Sub TxtFechaFinValeCentral_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaFinValeCentral.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaFinValeCentral_LostFocus(sender As Object, e As EventArgs) Handles txtFechaFinValeCentral.LostFocus
        If Not String.IsNullOrEmpty(txtFechaFinValeCentral.Text) Then txtFechaFinValeCentral.Text = PonSiglo(txtFechaFinValeCentral.Text)
    End Sub

    Private Sub TxtFechaInicioValeCentral_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaInicioValeCentral.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaInicioValeCentral_LostFocus(sender As Object, e As EventArgs) Handles txtFechaInicioValeCentral.LostFocus
        If Not String.IsNullOrEmpty(txtFechaInicioValeCentral.Text) Then txtFechaInicioValeCentral.Text = PonSiglo(txtFechaInicioValeCentral.Text)
    End Sub

    Private Sub TxtFechaLiquidadoValeCentral_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaLiquidadoValeCentral.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaLiquidadoValeCentral_LostFocus(sender As Object, e As EventArgs) Handles txtFechaLiquidadoValeCentral.LostFocus
        If Not String.IsNullOrEmpty(txtFechaLiquidadoValeCentral.Text) Then txtFechaLiquidadoValeCentral.Text = PonSiglo(txtFechaLiquidadoValeCentral.Text)
    End Sub

    Private Sub TxtFechaTicket_KeyUp(sender As Object, e As KeyEventArgs)
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaTicket_LostFocus(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(txtFechaTicket.Text) Then txtFechaTicket.Text = PonSiglo(txtFechaTicket.Text)
    End Sub

    Private Sub TxtFechaVale_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaVale.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaVale_LostFocus(sender As Object, e As EventArgs) Handles txtFechaVale.LostFocus
        If Not String.IsNullOrEmpty(txtFechaVale.Text) Then txtFechaVale.Text = PonSiglo(txtFechaVale.Text)
    End Sub

    Private Sub BtnModificarVendedor_Click(sender As Object, e As EventArgs) Handles btnModificarVendedor.Click
        If lvwVendedores.SelectedItems.Count = 0 Then Return

        nCódigoVendedor = lvwVendedores.SelectedItems(0).SubItems(0).Text
        txtNombreVendedor.Text = lvwVendedores.SelectedItems(0).SubItems(1).Text
        chkVendedorActivo.Checked = (lvwVendedores.SelectedItems(0).SubItems(2).Text = "√")
        txtNombreVendedor.Visible = True
        chkVendedorActivo.Visible = True
        lModificandoVendedor = True
        DesactivaBotones()
        txtNombreVendedor.Focus()
    End Sub

    Private Sub LvwVendedores_DoubleClick(sender As Object, e As EventArgs) Handles lvwVendedores.DoubleClick
        BtnModificarVendedor_Click(sender, e)
    End Sub

    Private Sub BtnAgregarVendedor_Click(sender As Object, e As EventArgs) Handles btnAgregarVendedor.Click
        nCódigoVendedor = 0
        txtNombreVendedor.Text = ""
        chkVendedorActivo.Checked = True
        txtNombreVendedor.Visible = True
        chkVendedorActivo.Visible = True
        lModificandoVendedor = True
        DesactivaBotones()
        txtNombreVendedor.Focus()
    End Sub

    Private Sub BtnEliminarVendedor_Click(sender As Object, e As EventArgs) Handles btnEliminarVendedor.Click
        If lvwVendedores.SelectedItems.Count = 0 Then Return
        If MsgBox("¿Está seguro de eliminar este vendedor?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Critical, "Atención") = MsgBoxResult.No Then Return

        Dim cSQL As String = "DELETE FROM vendedores WHERE cod_cli = " + txtCódigo.Text + " AND id = " + lvwVendedores.SelectedItems(0).SubItems(0).Text.ToString
        'Dim connInformix As New OdbcConnection
        Dim cmdInformix As OdbcCommand

        connInformix = ConexiónCentral(cODBCInformix)
        cmdInformix = New OdbcCommand(cSQL, connInformix)
        connInformix.Open()

        Try
            cmdInformix.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Eliminar vendedor", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            obj.Dispose()
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmdInformix.Dispose()
        End Try

        connInformix.Close()
        CargaVendedores()
    End Sub

    Private Sub BtnFechaEfectivo_Click(sender As Object, e As EventArgs) Handles btnFechaEfectivo.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaEfectivo.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtFechaEfectivo_Leave(sender, e)
    End Sub

    Private Sub TxtFechaEfectivo_Leave(sender As Object, e As EventArgs) Handles txtFechaEfectivo.Leave
        CargaEfectivo()
    End Sub

    Private Sub CargaEfectivo()
        connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}
        dtEfectivo = CargaTabla("SELECT * FROM mov_efectivo WHERE fecha = " + DtoSQL(txtFechaEfectivo.Text) + " ORDER BY num_mov", connTienda)
        lvwEfectivo.Items.Clear()

        For n = 0 To dtEfectivo.Rows.Count - 1
            Dim item As New ListViewItem(dtEfectivo.Rows(n)("num_mov").ToString)

            item.SubItems.Add(If(dtEfectivo.Rows(n)("tipo") = 2, "Entrada", "Salida"))
            item.SubItems.Add(FormatNumber(dtEfectivo.Rows(n)("valor"), 2, TriState.True, TriState.False, TriState.True))
            item.SubItems.Add(Memo2Array(dtEfectivo.Rows(n)("obs").ToString, 60)(0))

            lvwEfectivo.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub LvwEfectivo_DoubleClick(sender As Object, e As EventArgs) Handles lvwEfectivo.DoubleClick
        Dim cTexto As String = connTienda.ConnectionString
        Dim oVentana As New FrmEfectivo

        If lvwEfectivo.SelectedItems.Count = 0 Then
            oVentana.Dispose()
            Return
        Else
            cTexto += ";password=root"
            cTexto += Chr(255) + lvwEfectivo.SelectedItems(0).SubItems(0).Text
            cTexto += Chr(255)
            oVentana.PassedText = cTexto
            oVentana.ShowDialog()
            oVentana.Dispose()
            CargaEfectivo()
        End If
    End Sub

    Private Sub BtnLimpiarTickets_Click(sender As Object, e As EventArgs) Handles btnLimpiarTickets.Click
        BorraCamposTickets()
    End Sub

    Private Sub BtnBuscarTickets_Click(sender As Object, e As EventArgs) Handles btnBuscarTickets.Click
        If String.IsNullOrEmpty(txtFechaBuscaTicket.Text) And String.IsNullOrEmpty(comboTipoPago.Text) And String.IsNullOrEmpty(txtImporteBuscaTicket.Text) Then
            MsgBox("Debe seleccionar algún criterio", MsgBoxStyle.Critical, "Error")
            Return
        End If

        Dim cSQL As String
        Dim dtTickets As DataTable

        cSQL = "SELECT DISTINCT lineas_venta.fecha, lineas_venta.num_doc, tipo, fpago, valor FROM lineas_venta, mov_caja WHERE "
        If Not String.IsNullOrEmpty(txtFechaBuscaTicket.Text) Then cSQL += "lineas_venta.fecha = " + DtoSQL(txtFechaBuscaTicket.Text) + " AND "
        If Not String.IsNullOrEmpty(comboTipoPago.Text) Then cSQL += "tipo = " + comboTipoPago.SelectedValue.ToString + " AND "
        If comboFormaPago.Visible Then cSQL += "fpago = " + comboFormaPago.SelectedValue.ToString + " AND "
        If Not String.IsNullOrEmpty(txtImporteBuscaTicket.Text) Then cSQL += "valor = " + txtImporteBuscaTicket.Text + " AND "
        cSQL += "lineas_venta.num_doc = mov_caja.num_doc ORDER BY lineas_venta.num_doc"
        dtTickets = CargaTabla(cSQL, connTienda)

        lvwTickets.Items.Clear()

        For n = 0 To dtTickets.Rows.Count - 1
            Dim item As New ListViewItem(dtTickets.Rows(n)("num_doc").ToString)

            item.SubItems.Add(Format(dtTickets.Rows(n)("fecha"), "d"))
            item.SubItems.Add(FormatNumber(dtTickets.Rows(n)("valor"), 2, TriState.True, TriState.False, TriState.True))
            lvwTickets.Items.AddRange(New ListViewItem() {item})
        Next

        dtTickets.Dispose()
    End Sub

    Private Sub ComboTipoPago_Leave(sender As Object, e As EventArgs) Handles comboTipoPago.Leave
        If comboTipoPago.SelectedValue = 2 Then
            comboFormaPago.Visible = True
        Else
            comboFormaPago.Visible = False
        End If
    End Sub

    Private Sub TxtFechaBuscaTicket_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaBuscaTicket.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaBuscaTicket_LostFocus(sender As Object, e As EventArgs) Handles txtFechaBuscaTicket.LostFocus
        If Not String.IsNullOrEmpty(txtFechaBuscaTicket.Text) Then txtFechaBuscaTicket.Text = PonSiglo(txtFechaBuscaTicket.Text)
    End Sub

    Private Sub LvwTickets_DoubleClick(sender As Object, e As EventArgs) Handles lvwTickets.DoubleClick
        txtTicket.Text = lvwTickets.SelectedItems(0).SubItems(0).Text
        tabTickets.SelectedIndex = 0
        lBuscandoTicket = True
        BtnAgregar_Click(sender, e)
    End Sub

    Private Sub TabBuscar_GotFocus(sender As Object, e As EventArgs) Handles tabBuscar.Enter
        CargaFormasPago()
    End Sub

    Private Sub PageInventario_Enter(sender As Object, e As EventArgs) Handles pageInventario.Enter
        CargaInventario()
    End Sub

    Private Sub CambiaCursor(ByVal cTexto As String)
        If String.IsNullOrEmpty(cTexto) Then
            Me.Cursor = Cursors.Arrow
            Me.Height -= 30
            pbProgreso.Visible = True
            ssProgreso.Visible = False
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.Height += 30
            pbProgreso.Visible = False
            ssProgreso.Visible = True
            lblMensaje.Text = cTexto
        End If

        My.Application.DoEvents()
    End Sub

    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        CambiaCursor("Cargando vendedores ...")
        CargaVendedores()
        CambiaCursor("")
    End Sub

    Private Sub LvwPagos_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwPagos.MouseUp
        If e.Button = MouseButtons.Right Then
            cmFormasPago.Show(lvwPagos, e.Location)
        End If
    End Sub

    Private Sub MiAgregarPago_Click(sender As Object, e As EventArgs) Handles miAgregarPago.Click
        BtnAgregarPago_Click(sender, e)
    End Sub

    Private Sub MiModificarPago_Click(sender As Object, e As EventArgs) Handles miModificarPago.Click
        LvwPagos_DoubleClickChanged(sender, e)
    End Sub

    Private Sub MiEliminarPago_Click(sender As Object, e As EventArgs) Handles miEliminarPago.Click
        BtnEliminarPago_Click(sender, e)
    End Sub

    Private Sub LvwLíneasTicket_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwLíneasTicket.MouseUp
        If e.Button = MouseButtons.Right Then
            cmLíneasTicket.Show(lvwPagos, e.Location)
        End If
    End Sub

    Private Sub MiAgregarLíneaTicket_Click(sender As Object, e As EventArgs) Handles miAgregarLíneaTicket.Click
        BtnAgregarLínea_Click(sender, e)
    End Sub

    Private Sub MiModificarLíneaTicket_Click(sender As Object, e As EventArgs) Handles miModificarLíneaTicket.Click
        LvwLíneasTicket_DoubleClick(sender, e)
    End Sub

    Private Sub MiEliminarLíneaTicket_Click(sender As Object, e As EventArgs) Handles miEliminarLíneaTicket.Click
        BtnEliminarLínea_Click(sender, e)
    End Sub

    'Private Function CargaInformix(cSQL As String) As DataTable
    '    Dim tablaDA As New DataTable()
    '    Dim conn As IfxConnection = New IfxConnection With {
    '        .ConnectionString = "Database=decimas;Host=192.168.1.28;Server=ol_srvdec;Service=1526;Protocol=onsoctcp;DB_LOCALE=en_US.57372;UID=rafael;Password=altungy;"
    '    }
    '    Dim cmd As New IfxDataAdapter(cSQL, conn)

    '    cmd.Fill(tablaDA)
    '    Return (tablaDA)
    'End Function

    Private Sub LvwVendedores_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvwVendedores.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwVendedoresSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwVendedoresSorter.Order = SortOrder.Ascending) Then
                lvwVendedoresSorter.Order = SortOrder.Descending
            Else
                lvwVendedoresSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwVendedoresSorter.SortColumn = e.Column
            lvwVendedoresSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvwVendedores.Sort()
    End Sub

    Private Sub BtnPing2_Click(sender As Object, e As EventArgs) Handles btnPing2.Click
        If nTienda > 0 Then
            tabTiendas.SelectedTab = pageComunicaciones
            BtnPing_Click(sender, e)
        End If
    End Sub

    Private Sub BtnContabilidadTicket_Click(sender As Object, e As EventArgs) Handles btnContabilidadTicket.Click
        lMailTicket = True
        tabTiendas.SelectedTab = pageApertura
        txtFechaApertura.Text = txtFechaTicket.Text
        TxtFechaApertura_Leave(sender, e)
        btnAlejandro.Focus()
        BtnAlejandro_Click(sender, e)
    End Sub

    Private Sub BtnFechaMissingKey_Click(sender As Object, e As EventArgs) Handles btnFechaMissingKey.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaMissingKey.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtFechaMissingKey_Leave(sender, e)
    End Sub

    Private Sub TxtFechaMissingKey_Leave(sender As Object, e As EventArgs) Handles txtFechaMissingKey.Leave
        Dim dtLíneas, dtArtículos As DataTable
        Dim cSQL As String

        If Not String.IsNullOrEmpty(cODBCInformix) Then
            connInformix = ConexiónCentral(cODBCInformix)
        Else
            MsgBox("Debe seleccionar una tienda tienda", MsgBoxStyle.Critical, "Atención")
            Return
        End If

        If String.IsNullOrEmpty(txtIPTPV.Text) Then
            MsgBox("No hay IP definida para la tienda", MsgBoxStyle.Critical, "Atención")
            Return
        End If

        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(txtIPTPV.Text)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

        If Not (res.Status = NetworkInformation.IPStatus.Success) Then
            MsgBox("El servidor no responde", MsgBoxStyle.Critical, "Error")
            Return
        End If

        connTienda = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}

        cSQL = "SELECT * FROM rx_lineas_venta WHERE fecha = " + FechaInformix(txtFechaMissingKey.Text) + " AND cod_cli = " + txtCódigo.Text
        cSQL += " AND codigo NOT IN (SELECT codigo FROM prod_pren)"

        lblInformación.Text = "Leyendo datos ..."
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        dtLíneas = CargaTabla(cSQL, connInformix)
        lvwMissingKey.Items.Clear()

        If dtLíneas.Rows.Count = 0 Then
            MsgBox("No hay referencias inexistentes", MsgBoxStyle.Information, "Atención")
            Me.Cursor = Cursors.Default
            Return
        Else
            For n = 0 To dtLíneas.Rows.Count - 1
                cSQL = "SELECT ref_prenda, descripcion FROM art_index WHERE codigo = " + GrabaComillas(Microsoft.VisualBasic.Left(dtLíneas.Rows(n)("codigo"), 10))
                dtArtículos = CargaTabla(cSQL, connTienda)

                Dim item As New ListViewItem(dtLíneas.Rows(n)("num_doc").ToString)

                item.SubItems.Add(dtLíneas.Rows(n)("codigo").ToString)
                item.SubItems.Add(dtArtículos.Rows(0)("descripcion"))

                cSQL = "SELECT ref_ext FROM prod_pren WHERE codigo = " + GrabaComillas(dtLíneas.Rows(n)("codigo"))
                dtArtículos = CargaTabla(cSQL, connTienda)

                If dtArtículos.Rows.Count = 0 Then
                    item.SubItems.Add("No prod_pren")
                Else
                    If String.IsNullOrEmpty(dtArtículos.Rows(0)("ref_ext")) Then
                        item.SubItems.Add("Sin ref_ext")
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(dtArtículos.Rows(0)("ref_ext"))

                        cSQL = "SELECT codigo FROM prod_pren WHERE ref_ext = " + GrabaComillas(dtArtículos.Rows(0)("ref_ext"))
                        dtArtículos = CargaTabla(cSQL, connInformix)

                        If dtArtículos.Rows.Count = 0 Then
                            item.SubItems.Add("Ref_ext Not existe")
                        Else
                            item.SubItems.Add(dtArtículos.Rows(0)("codigo").ToString)
                        End If
                    End If

                End If

                lvwMissingKey.Items.AddRange(New ListViewItem() {item})
            Next

            lblInformación.Text = ""
            Me.Cursor = Cursors.Default
            My.Application.DoEvents()
        End If
    End Sub

    Private Sub BtnEnviarVentas_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnEnviarVentas.MouseDown
        If Not e.Button = MouseButtons.Right Then
            Return
        End If

        If String.IsNullOrEmpty(lblTiendaApertura.Text) Then
            MsgBox("Debe seleccionar una tienda", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If String.IsNullOrEmpty(txtFechaApertura.Text) Then
            MsgBox("Debe seleccionar una fecha", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If lblEstadoCaja.Text <> "Cerrada" Then
            MsgBox("La caja no está cerrada", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If String.IsNullOrEmpty(txtIPTPV.Text) Then
            MsgBox("Not está definida la IP del servidor", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If comboEstado.Text <> "ABIERTA" Then
            MsgBox("La tienda no está en estado ABIERTA", MsgBoxStyle.Critical, "Error")
            Return
        End If

        If MsgBox("¿Está seguro de enviar las ventas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        CambiaCursor("Conectando a tienda ...")

        Dim cSubRed As String = txtSubred.Text

        If String.IsNullOrEmpty(txtSubred.Text) Then Return

        btnPing.Visible = False
        lblPing.Visible = True
        lblRouter.ForeColor = Color.Black
        lblServidor.ForeColor = Color.Black
        lblTeléfono.ForeColor = Color.Black
        lblPingRouter.Visible = False
        lblPingServidor.Visible = False
        lblPingTeléfono.Visible = False
        My.Application.DoEvents()

        Dim eco As New System.Net.NetworkInformation.Ping
        Dim ip As IPAddress = IPAddress.Parse(txtRouter.Text)
        Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

        If res.Status <> NetworkInformation.IPStatus.Success Then
            MsgBox("No se puede conectar al servidor TPV", MsgBoxStyle.Critical, "Error")
            Return
        End If

        'Dim nImportarOnline As Integer
        Dim cSQL As String
        Dim dtCierre, dtCabecerasTickets As DataTable
        Dim cmd As OdbcCommand
        Dim nCierres As Integer
        Dim nMovientosEfectivo As Integer
        Dim nVentas As Integer
        Dim nMovCaja As Integer
        Dim nVentasPromo As Integer
        Dim nLíneasVenta As Integer
        Dim nDevoluciones As Integer
        Dim nTotal As Integer

        connInformix = ConexiónCentral(cODBCInformix)
        'connInformix = ConexiónCentral("prodbc")

        lblMensaje.Text = "Leyendo parámetros ..."
        'cSQL = "SELECT valor FROM parametros WHERE nombre = " + GrabaComillas("importar_online")
        'dtTemporal = CargaTabla(cSQL, connTienda)

        'If dtTemporal.Rows.Count > 0 Then
        '    nImportarOnline = Val(dtTemporal.Rows(0)("valor"))
        'Else
        '    nImportarOnline = 0
        'End If

        lblMensaje.Text = "Comprobando tickets ..."
        My.Application.DoEvents()

        cSQL = "SELECT fecha, num_doc, vendedor, hora, valor, moneda, valor_div, empleado, tarjeta_amigo ,regalo, prepago "
        cSQL += "FROM venta WHERE fecha = " + DtoSQL(txtFechaApertura.Text)
        dtCabecerasTickets = CargaTabla(cSQL, connTienda)

        pbProgreso.Visible = True
        pbProgreso.Minimum = 0
        pbProgreso.Maximum = dtCabecerasTickets.Rows.Count - 1
        pbProgreso.Step = 1
        pbProgreso.Value = 0

        For n = 0 To dtCabecerasTickets.Rows.Count - 1
            pbProgreso.PerformStep()
            My.Application.DoEvents()

            If dtCabecerasTickets.Rows(n)("prepago") = 0 Then
                cSQL = "SELECT SUM(cantidad * pventa) AS importe FROM lineas_venta WHERE num_doc = " + dtCabecerasTickets.Rows(n)("num_doc").ToString
                dtLíneas = CargaTabla(cSQL, connTienda)

                If dtLíneas.Rows.Count = 0 Then
                    MsgBox("No hay líneas del ticket " + dtCabecerasTickets.Rows(n)("num_doc").ToString, MsgBoxStyle.Critical, "Error")
                    Me.Close()
                End If

                If dtCabecerasTickets.Rows(n)("valor") <> dtLíneas.Rows(0)("importe") Then
                    MsgBox("Los importes del ticket " + dtCabecerasTickets.Rows(n)("num_doc").ToString + " no coinciden", MsgBoxStyle.Critical, "Error")
                    Me.Close()
                End If
            End If
        Next

        cSQL = "BEGIN WORK"
        cmd = New OdbcCommand(cSQL, connInformix)
        connInformix.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "BEGIN WORK", st)
            obj.ShowDialog(Me)
            RollBack()
            Me.Close()
        End Try

        cSQL = "DELETE FROM rx_cierre WHERE fecha = " + FechaInformix(txtFechaApertura.Text) + " And cod_cli = " + txtCódigo.Text
        cmd = New OdbcCommand(cSQL, connInformix)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Borrar venta en rx_cierre", st)
            obj.ShowDialog(Me)
            RollBack()
            Me.Close()
        End Try

        nCierres = LeeNumRegistros("cierre")
        nMovientosEfectivo = LeeNumRegistros("mov_efectivo")
        nVentas = LeeNumRegistros("venta")
        nMovCaja = LeeNumRegistros("mov_caja")
        nVentasPromo = LeeNumRegistros("vent_promo")
        nLíneasVenta = LeeNumRegistros("lineas_venta")
        nDevoluciones = LeeNumRegistros("devoluciones")
        nTotal = nCierres + nMovientosEfectivo + nVentas + nMovCaja + nVentasPromo + nLíneasVenta + nDevoluciones

        cSQL = "SELECT fecha, total_venta, total_apertura, total_ingresos, tickets_dia, articulos_dia, venta_media, num_ventas_dcto, total_dcto, "
        cSQL += "num_dev, total_dev, creditos_emi, creditos_liq, tickets_prepago, total_prepago, caja_real, obs, vendedor, moneda, cerrado, ingreso, "
        cSQL += "cuenta_corriente, ingreso_banco, caja_acumulada, dias_acumulados "
        cSQL += "from cierre WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtCierre = CargaTabla(cSQL, connTienda)

        pbProgreso.Visible = True
        pbProgreso.Value = 1
        pbProgreso.Minimum = 0
        pbProgreso.Maximum = nTotal
        lblMensaje.Text = "Enviando cabecera (1/7)"
        My.Application.DoEvents()

        cSQL = "INSERT INTO rx_cierre(cod_cli, fecha, total_venta, total_apertura, total_ingresos, tickets_dia, articulos_dia, venta_media, "
        cSQL += "num_ventas_dcto, total_dcto, num_dev, total_dev, creditos_emi, creditos_liq, tickets_prepago, total_prepago, caja_real, obs, "
        cSQL += "vendedor, moneda, cerrado, ingreso, cuenta_corriente, ingreso_banco, caja_acumulada, dias_acumulados) VALUES("
        cSQL += txtCódigo.Text + ", "
        cSQL += FechaInformix(dtCierre.Rows(0)("fecha")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_venta")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_apertura")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_ingresos")) + ", "
        cSQL += Str(dtCierre.Rows(0)("tickets_dia")) + ", "
        cSQL += Str(dtCierre.Rows(0)("articulos_dia")) + ", "
        cSQL += Str(dtCierre.Rows(0)("venta_media")) + ", "
        cSQL += Str(dtCierre.Rows(0)("num_ventas_dcto")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_dcto")) + ", "
        cSQL += Str(dtCierre.Rows(0)("num_dev")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_dev")) + ", "
        cSQL += Str(dtCierre.Rows(0)("creditos_emi")) + ", "
        cSQL += Str(dtCierre.Rows(0)("creditos_liq")) + ", "
        cSQL += Str(dtCierre.Rows(0)("tickets_prepago")) + ", "
        cSQL += Str(dtCierre.Rows(0)("total_prepago")) + ", "
        cSQL += Str(dtCierre.Rows(0)("caja_real")) + ", "
        cSQL += GrabaComillas(dtCierre.Rows(0)("obs")) + ", "
        cSQL += Str(dtCierre.Rows(0)("vendedor")) + ", "
        cSQL += Str(dtCierre.Rows(0)("moneda")) + ", "
        cSQL += Str(dtCierre.Rows(0)("cerrado")) + ", "
        cSQL += Str(dtCierre.Rows(0)("ingreso")) + ", "
        cSQL += Str(dtCierre.Rows(0)("cuenta_corriente")) + ", "
        cSQL += Str(dtCierre.Rows(0)("ingreso_banco")) + ", "
        cSQL += Str(dtCierre.Rows(0)("caja_acumulada")) + ", "
        cSQL += Str(dtCierre.Rows(0)("dias_acumulados")) + ")"

        cmd = New OdbcCommand(cSQL, connInformix)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Insertar registro en rx_cierre", st)
            obj.ShowDialog(Me)
            RollBack()
            Me.Close()
        End Try

        lblMensaje.Text = "Enviando movimiento efectivo (2/7) ..."
        cSQL = "SELECT fecha, num_mov, tipo, gtienda, num_vale, factura, fecha_factura, cif, razon_social, "
        cSQL += "tipo_iva, base, porciva, iva, tipo_iva2, base2, porciva2, iva2, tipo_iva3, base3, porciva3, iva3,"
        cSQL += "valor, vendedor, moneda, valor_div, obs "
        cSQL += "FROM mov_efectivo WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtLíneas = CargaTabla(cSQL, connTienda)

        For n = 0 To dtLíneas.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_mov_efectivo(cod_cli, fecha, num_mov, tipo, gtienda, num_vale, factura, fecha_factura, cif, razon_social, "
            cSQL += "tipo_iva, base, porciva, iva, tipo_iva2, base2, porciva2, iva2, tipo_iva3, base3, porciva3, iva3, "
            cSQL += "valor, vendedor, moneda, valor_div, obs) VALUES("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_mov")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tipo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("gtienda")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("num_vale").ToString) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("factura").ToString) + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha_factura")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("cif").ToString) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("razon_social").ToString) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tipo_iva")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("base")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("porciva")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("iva")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tipo_iva2")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("base2")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("porciva2")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("iva2")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tipo_iva3")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("base3")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("porciva3")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("iva3")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("vendedor")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("moneda")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor_div")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("obs").ToString) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Insertar movimiento efectivo", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        lblMensaje.Text = "Enviando cabeceras ticket (3/7) ..."
        'cSQL = "SELECT fecha, num_doc, vendedor, hora, valor, moneda, valor_div, empleado, tarjeta_amigo ,regalo, prepago "
        'cSQL += "FROM venta WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        'dtCabecerasTickets = CargaTabla(cSQL, connTienda)

        For n = 0 To dtCabecerasTickets.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_venta(cod_cli, fecha, num_doc, vendedor, hora, valor, moneda, valor_div, empleado, tarjeta_amigo, regalo, prepago) VALUES("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtCabecerasTickets.Rows(n)("fecha")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("num_doc")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("vendedor")) + ", "
            cSQL += "'" + dtCabecerasTickets.Rows(n)("hora").ToString + "', "
            cSQL += Str(dtCabecerasTickets.Rows(n)("valor")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("moneda")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("valor_div")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("empleado")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("tarjeta_amigo")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("regalo")) + ", "
            cSQL += Str(dtCabecerasTickets.Rows(n)("prepago")) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Cabecera ticket", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        lblMensaje.Text = "Enviando movimiento caja (4/7) ..."
        cSQL = "SELECT fecha ,num_doc, num_mov, tipo, valor, cambio, fpago, num_vale, moneda, valor_div, liquidado "
        cSQL += "FROM mov_caja  WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtLíneas = CargaTabla(cSQL, connTienda)

        For n = 0 To dtLíneas.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_mov_caja(cod_cli, fecha,num_doc, num_mov, tipo, valor, cambio, fpago, num_vale, moneda, valor_div, liquidado) VALUES("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_doc")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_mov")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tipo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("cambio")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("fpago")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("num_vale")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("moneda")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor_div")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("liquidado")) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Línea ticket", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        lblMensaje.Text = "Enviando ventas promoción (5/7) ..."
        cSQL = "SELECT fecha, num_doc, num_pro, promocion, tarjeta, dcto,valor, valor_div, obs "
        cSQL += "FROM mov_caja WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtLíneas = CargaTabla(cSQL, connTienda)

        For n = 0 To dtLíneas.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_vent_promo(cod_cli, fecha, num_doc, num_pro, promocion, tarjeta, dcto, valor, valor_div, obs) VALUES("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_doc")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_pro")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("promocion")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("tarjeta")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("dcto")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("valor_div")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("obs")) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Venta promoción", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        lblMensaje.Text = "Enviando devoluciones (6/7) ..."
        cSQL = "SELECT fecha, num_doc, linea, cod_cliente_orig, num_doc_orig, num_doc_orig_fran, fecha_orig, codigo, cantidad, pventa, conexion, tara "
        cSQL += "FROM devoluciones WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtLíneas = CargaTabla(cSQL, connTienda)

        For n = 0 To dtLíneas.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_devoluciones(cod_cli, fecha, num_doc, linea, cod_cliente_orig, num_doc_orig, num_doc_orig_fran, fecha_orig, codigo, "
            cSQL += "cantidad, pventa, conexion, tara) VALUES("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_doc")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("linea")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("cod_cliente_orig")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_doc_orig")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("num_doc_orig_fran")) + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha_orig")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("codigo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("cantidad")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pventa")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("conexion")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("tara")) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Devoluciones", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        lblMensaje.Text = "Enviando líneas tickets (7/7) ..."
        cSQL = "SELECT fecha, num_doc, linea, vendedor, codigo, cantidad, pvp, pvp_div, dcto, pventa, pventa_div, dcto_vr, pventa_promo, pventa_promo_div "
        cSQL += "FROM lineas_venta WHERE fecha = " + DtoSQL(txtFechaApertura.Text)

        dtLíneas = CargaTabla(cSQL, connTienda)

        For n = 0 To dtLíneas.Rows.Count - 1
            pbProgreso.Value += 1
            My.Application.DoEvents()

            cSQL = "INSERT INTO rx_lineas_venta(cod_cli, fecha, num_doc, linea, vendedor, codigo, cantidad, pvp, pvp_div, dcto, pventa, pventa_div, dcto_vr, "
            cSQL += "pventa_promo, pventa_promo_div) VALUES ("
            cSQL += txtCódigo.Text + ", "
            cSQL += FechaInformix(dtLíneas.Rows(n)("fecha")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("num_doc")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("linea")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("vendedor")) + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("codigo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("cantidad")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pvp")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pvp_div")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("dcto")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pventa")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pventa_div")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("dcto_vr")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pventa_promo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("pventa_promo_div")) + ")"

            cmd = New OdbcCommand(cSQL, connInformix)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Devoluciones", st)
                obj.ShowDialog(Me)
                RollBack()
                Me.Close()
            End Try
        Next

        cSQL = "COMMIT WORK"
        cmd = New OdbcCommand(cSQL, connInformix)
        cmd.ExecuteNonQuery()

        connInformix.Close()
        CambiaCursor("")

        lblInformación.Text = "Terminado"

        If lblProcesado.Text = "Venta procesada" Then
            MsgBox("Recuerde borrar las ventas actuales en Milenium", MsgBoxStyle.Information, "Atención")
        End If

        MsgBox("Recuerde importar las ventas en Milenium", MsgBoxStyle.Information, "Atención")
    End Sub

    Private Function LeeNumRegistros(ByVal cTabla As String) As Integer
        Dim nValor As Integer = 0
        Dim cSQL As String
        Dim dtTemporal As DataTable

        cSQL = "SELECT COUNT(*) AS numero FROM " + cTabla + " WHERE fecha = " + DtoSQL(txtFechaApertura.Text)
        dtTemporal = CargaTabla(cSQL, connTienda)

        If dtTemporal.Rows.Count > 0 Then
            nValor = Val(dtTemporal.Rows(0)("numero"))
        End If

        dtTemporal.Dispose()
        Return (nValor)
    End Function

    Private Sub CreaToolTips()
        Dim ToolTipEnviarVentas As ToolTip = New ToolTip
        Dim ToolTiplvwPagos As ToolTip = New ToolTip
        Dim ToolTiplvwLíneasTicket As ToolTip = New ToolTip
        Dim ToolTipbtnTeamViewer As ToolTip = New ToolTip
        Dim ToolTipbtnUVNC As ToolTip = New ToolTip
        Dim ToolTipbtnTightVNC As ToolTip = New ToolTip
        Dim ToolTipbtnMySQL As ToolTip = New ToolTip
        Dim ToolTipbtnPing2 As ToolTip = New ToolTip

        ToolTipEnviarVentas.SetToolTip(btnEnviarVentas, "Enviar ventas de la tienda a Milenium")
        ToolTiplvwPagos.SetToolTip(lvwPagos, "Haga click derecho para acceder a más opciones")
        ToolTiplvwLíneasTicket.SetToolTip(lvwLíneasTicket, "Haga click derecho para acceder a más opciones")
        ToolTipbtnTeamViewer.SetToolTip(btnTeamViewer, "Conectar a tienda vía TeamViewer")
        ToolTipbtnUVNC.SetToolTip(btnUVNC, "Conectar a tienda vía VNC")
        ToolTipbtnTightVNC.SetToolTip(btnTightVNC, "Conectar a tienda vía TightVNC")
        ToolTipbtnMySQL.SetToolTip(btnMySQL, "Conectar a la base de datos de la tienda")
        ToolTipbtnPing2.SetToolTip(btnPing2, "Hacer ping a la tienda")
    End Sub

    Private Sub BtnMaps_Click(sender As Object, e As EventArgs) Handles btnMaps.Click
        Process.Start("http://maps.google.com/maps?q=" + Trim(txtDirección1.Text) + " " + Trim(txtDirección2.Text) + " " + txtPostal.Text + " " + txtPoblación.Text + "&hl=es&t=h&zoom=17")
    End Sub

    Private Sub BtnLlamarExtensión_Click(sender As Object, e As EventArgs) Handles btnLlamarExtensión.Click
        Llamar(txtExtensión.Text)
    End Sub

    Private Sub BtnLlamarFijo_Click(sender As Object, e As EventArgs) Handles btnLlamarFijo.Click
        Llamar("0" + txtTeléfono.Text)
    End Sub

    Private Sub BtnLlamarContacto_Click(sender As Object, e As EventArgs) Handles btnLlamarContacto.Click
        Llamar("0" + txtTeléfonoContacto.Text)
    End Sub

    Private Sub Llamar(ByVal cTeléfono As String)
        If String.IsNullOrEmpty(cTeléfono) Then Return

        Dim procesos() As Process = Process.GetProcessesByName("communicatork9")

        If procesos.GetLength(0) > 0 Then
            ShowWindow(procesos(0).MainWindowHandle, SW_SHOWDEFAULT)
            SetForegroundWindow(procesos(0).MainWindowHandle)
            System.Threading.Thread.Sleep(1000)
            'AppActivate(procesos(0).Id)
            SendKeys.SendWait(cTeléfono + vbCr)
        End If
    End Sub

    Private Sub PageMySQL_Enter(sender As Object, e As EventArgs) Handles pageMySQL.Enter
        Dim dtHistórico As DataTable = CargaTabla("SELECT * FROM historicosql ORDER BY fecha DESC", connMySQL)

        With dvHistóricoSQL
            .ReadOnly = True
            .DataSource = dtHistórico
            .DataMember = dtHistórico.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Font = New Font(dvTiendas.Font, FontStyle.Bold)

            With .Columns(0)
                .HeaderText = "Fecha"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            With .Columns(1)
                .HeaderText = "Sentencia"
                .Width = 389
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
        End With
    End Sub

    Private Sub DvHistóricoSQL_MouseUp(sender As Object, e As MouseEventArgs) Handles dvHistóricoSQL.MouseUp
        If e.Button = MouseButtons.Right Then
            cmHistóricoSQL.Show(dvHistóricoSQL, e.Location)
        End If
    End Sub

    Private Sub MiEliminarHistóricoSQL_Click(sender As Object, e As EventArgs) Handles miEliminarHistóricoSQL.Click
        If MsgBox("¿Está seguro de eliminar esta sentencia?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, "Atención") = MsgBoxResult.Yes Then
            Dim cSQL As String
            Dim cmd As MySqlCommand
            Dim dFecha As DateTime = dvHistóricoSQL.SelectedRows(0).Cells(0).Value

            cSQL = "DELETE FROM historicosql WHERE fecha = '" + dFecha.ToString("yyyy/MM/dd HH:mm:ss") + "'"
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Eliminar sentencia SQL", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                obj.Dispose()
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()
            PageMySQL_Enter(sender, e)
        End If
    End Sub

    Private Sub MiSeleccionarHistóricoSQL_Click(sender As Object, e As EventArgs) Handles miSeleccionarHistóricoSQL.Click
        txtSQL.Text = dvHistóricoSQL.SelectedRows(0).Cells(1).Value
    End Sub

    Private Sub BtnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Dim procesos() As Process = Process.GetProcessesByName("outlook")

        If procesos.GetLength(0) > 0 Then
            ShowWindow(procesos(0).MainWindowHandle, SW_MAXIMIZE)
            SetForegroundWindow(procesos(0).MainWindowHandle)
            System.Threading.Thread.Sleep(1000)
            SendKeys.SendWait("^u")
            SendKeys.SendWait(txtCorreo.Text)
        End If
    End Sub

    Private Sub BtnConexflow_Click(sender As Object, e As EventArgs) Handles btnConexflow.Click
        Dim oOutlook As Outlook.Application
        Dim olNs As Outlook.NameSpace
        Dim oMail As Outlook.MailItem
        Dim cTexto As String
        Dim CR As String = "<br>"

        oOutlook = CreateObject("Outlook.Application")
        olNs = oOutlook.GetNamespace("MAPI")
        olNs.Logon()
        oMail = oOutlook.CreateItem(Outlook.OlItemType.olMailItem)
        oMail.Subject = "Alta sede " + txtNombre.Text

        cTexto = CabeceraMail() + "Muy señores nuestros:"
        cTexto += "<o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal>"
        cTexto += "Les rogamos que den de alta la siguiente sede:"
        cTexto += "<o:p></o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal>"
        cTexto += txtNombre.Text + CR
        cTexto += txtDirección1.Text + CR
        If Not String.IsNullOrEmpty(txtDirección2.Text) Then cTexto += txtDirección2.Text + CR
        cTexto += txtPostal.Text + " " + txtPoblación.Text + CR
        cTexto += "(" + txtProvincia.Text + ")" + CR
        cTexto += "Tfno.: " + txtTeléfono.Text + CR
        cTexto += "Nº comercio RedSYS: " + txtComercio.Text + CR
        cTexto += "Código tienda: " + If(txtCódigo.Text.Length > 4, Microsoft.VisualBasic.Right(txtCódigo.Text, 4), txtCódigo.Text) + CR
        cTexto += "Empresa: " + comboEmpresa.Text + CR
        cTexto += "Banco: " + comboMerchant.Text + CR
        cTexto += "Terminal lógico: 00000001" + CR
        cTexto += CR + CR + CR + CR + "Un saludo" + CR
        cTexto += PiéMail()

        oMail.HTMLBody = cTexto

        oMail.To = "Conexflow@ingenico.com"
        oMail.CC = "paula.b.guerrero-laverat@aexp.com; mjuez@decimas.es"
        oMail.Save()

        MsgBox("Recuerde revisar y enviar el correo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
    End Sub

    Private Sub RollBack()
        Dim cSQL As String = "ROLLBACK WORK"
        Dim cmd As OdbcCommand = New OdbcCommand(cSQL, connInformix)

        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub

    Private Sub CmdCambiar_Click(sender As Object, e As EventArgs) Handles cmdCambiar.Click

    End Sub

    Private Sub LblIncidencias_DoubleClick(sender As Object, e As EventArgs) Handles lblIncidencias.DoubleClick
        Dim cSQL As String
        Dim cmd As SqlCommand
        Dim lCorrecto As Boolean = True
        Dim cErrores As String = "Faltan los siguientes datos:" + vbCrLf + vbCrLf

        If lblIncidencias.ForeColor = Color.Green Then Return

        If String.IsNullOrEmpty(txtNombre.Text) Then
            lCorrecto = False
            cErrores += "Nombre tienda" + vbCrLf
        End If

        If String.IsNullOrEmpty(txtExtensión.Text) Then
            lCorrecto = False
            cErrores += "Extensión" + vbCrLf
        End If

        If String.IsNullOrEmpty(txtCorreo.Text) Then
            lCorrecto = False
            cErrores += "eMail" + vbCrLf
        End If

        If String.IsNullOrEmpty(txtCódigo.Text) Then
            lCorrecto = False
            cErrores += "Código" + vbCrLf
        End If

        If lCorrecto Then
            cSQL = "INSERT INTO usuarios(nombre, password, ext, dpto, mail,codigo) VALUES("
            cSQL += "'" + txtNombre.Text + "', "
            cSQL += "' ', "
            cSQL += txtExtensión.Text + ", "
            cSQL += "5, "
            cSQL += "'" + txtCorreo.Text + "', "
            cSQL += txtCódigo.Text + ")"

            cmd = New SqlCommand(cSQL, connSQL)

            connSQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
            End Try

            connSQL.Close()
            lblIncidencias.ForeColor = Color.Lime
        Else
            MsgBox(cErrores, MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class

Class Tipos
    Property Nombre As String
    Property Id As Integer
End Class

