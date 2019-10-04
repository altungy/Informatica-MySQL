#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class FrmCompras
    Private _passedText As String
    Private connMySQL As MySqlConnection
    Private dtEmpresas As DataTable
    Private dtProveedores As DataTable
    Private nCompra As Integer = 0
    Private cFiltro As String = ""
    Private lModificando As Boolean = False
    Private lfiltrando As Boolean = False
    Private lGrabado As Boolean = True
    Private lBuscando As Boolean = False
    Private aLíneas() As String = New String() {}

    Private leftMargin As Single = 50
    Private topMargin As Single = 50
    Private rightMargin As Single
    Private bottomMargin As Single
    Private pageWidth As Double
    Private pageCenter As Double
    Private nPágina As Integer

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If Not lGrabado Then
            If MsgBox("Compra sin grabar. ¿Desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return
        End If

        Me.Close()
    End Sub

    Private Sub FrmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCabecera As DataTable
        'Dim cTexto As String = _passedText
        Dim nNúmero As Integer = Val(_passedText)

        connMySQL = New MySqlConnection(Conexión())
        dtEmpresas = CargaTabla("SELECT * FROM empresas ORDER BY nombre", connMySQL)

        With comboEmpresa
            .DataSource = dtEmpresas
            .ValueMember = dtEmpresas.Columns(0).Caption.ToString
            .DisplayMember = dtEmpresas.Columns(1).Caption.ToString
        End With

        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)

        With comboProveedor
            .DataSource = dtProveedores
            .ValueMember = dtProveedores.Columns(0).Caption.ToString
            .DisplayMember = dtProveedores.Columns(1).Caption.ToString
        End With

        With lvwLíneas
            .Columns.Add("Línea", 0, HorizontalAlignment.Right)
            .Columns.Add("Artículo", 295, HorizontalAlignment.Left)
            .Columns.Add("Cant.", 50, HorizontalAlignment.Right)
            .Columns.Add("Precio", 100, HorizontalAlignment.Right)
            .Columns.Add("Desc.", 60, HorizontalAlignment.Right)
        End With

        BorraCampos()
        ActivaBotones()
        DesactivaCampos()

        If nNúmero <> 0 Then
            dtCabecera = CargaTabla("SELECT TOP 1 numcompra FROM cabcompra WHERE numcompra >= " + Str(nNúmero) + " ORDER BY numcompra DESC", connMySQL)

            If dtCabecera.Rows.Count = 0 Then
                btnÚltimo_Click(sender, e)
            Else
                nNúmero = dtCabecera.Rows(0)("numcompra")
            End If

            nCompra = nNúmero
            CargaDatos()
        End If
    End Sub

    Private Sub BorraCampos()
        txtNúmero.Text = ""
        txtFecha.Text = ""
        comboEmpresa.Text = ""
        txtPedido.Text = ""
        txtFechaPedido.Text = ""
        comboProveedor.Text = ""
        txtDescuento.Text = ""
        txtFactura.Text = ""
        txtFechaFactura.Text = ""
        txtFechaVencimiento.Text = ""
        txtVisado.Text = ""
        txtFecha.Text = ""
        txtObservaciones.Text = ""
        txtNombre.Text = ""
        txtDirección.Text = ""
        txtPostal.Text = ""
        txtPoblación.Text = ""
        txtProvincia.Text = ""
        txtContacto.Text = ""
        txtTeléfono.Text = ""
        lvwLíneas.Items.Clear()
        Dim aLíneas(0)
    End Sub

    Private Sub ActivaBotones()
        btnFecha.Enabled = lModificando
        btnFechaVisado.Enabled = lModificando
        btnFechaFactura.Enabled = lModificando
        btnFechaVencimiento.Enabled = lModificando
        btnPrimero.Enabled = lGrabado
        btnAnterior.Enabled = lGrabado
        btnSiguiente.Enabled = lGrabado
        btnÚltimo.Enabled = lGrabado
        btnNuevo.Text = "&Nuevo"
        btnModificar.Text = "&Modificar"
        btnGrabar.Enabled = Not lGrabado
        btnEliminar.Enabled = lGrabado
        btnFiltrar.Enabled = lGrabado
        btnImprimir.Enabled = lGrabado
        btnAgregarLínea.Enabled = True
        btnInsertarLínea.Enabled = True
        btnModificarLínea.Enabled = True
        btnEliminarLínea.Enabled = True
        btnSalir.Enabled = True
        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        btnFecha.Enabled = True
        btnFechaVisado.Enabled = True
        btnFechaFactura.Enabled = True
        btnFechaVencimiento.Enabled = True
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        btnSiguiente.Enabled = False
        btnÚltimo.Enabled = False
        btnNuevo.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnGrabar.Enabled = False
        btnEliminar.Enabled = False
        btnFiltrar.Enabled = False
        btnImprimir.Enabled = False
        btnAgregarLínea.Enabled = False
        btnInsertarLínea.Enabled = False
        btnModificarLínea.Enabled = False
        btnEliminarLínea.Enabled = False
        btnSalir.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub ActivaCampos()
        txtFecha.ReadOnly = False
        txtPedido.ReadOnly = False
        txtFechaPedido.ReadOnly = False
        txtDescuento.ReadOnly = False
        txtFactura.ReadOnly = False
        txtFechaFactura.ReadOnly = False
        txtFechaVencimiento.ReadOnly = False
        txtVisado.ReadOnly = False
        txtFecha.ReadOnly = False
        txtObservaciones.ReadOnly = False
        txtNombre.ReadOnly = False
        txtDirección.ReadOnly = False
        txtPostal.ReadOnly = False
        txtPoblación.ReadOnly = False
        txtProvincia.ReadOnly = False
        txtContacto.ReadOnly = False
        txtTeléfono.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtNúmero.ReadOnly = True
        txtFecha.ReadOnly = True
        txtPedido.ReadOnly = True
        txtFechaPedido.ReadOnly = True
        txtDescuento.ReadOnly = True
        txtFactura.ReadOnly = True
        txtFechaFactura.ReadOnly = True
        txtFechaVencimiento.ReadOnly = True
        txtVisado.ReadOnly = True
        txtFecha.ReadOnly = True
        txtObservaciones.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDirección.ReadOnly = True
        txtPostal.ReadOnly = True
        txtPoblación.ReadOnly = True
        txtProvincia.ReadOnly = True
        txtContacto.ReadOnly = True
        txtTeléfono.ReadOnly = True
    End Sub

    Private Sub CargaDatos()
        BorraCampos()
        If nCompra = 0 Then Return

        Dim dtCabecera As DataTable = CargaTabla("SELECT * FROM cabcompra WHERE numcompra = " + nCompra.ToString, connMySQL)
        Dim dtLíneas As DataTable = CargaTabla("SELECT * FROM lincompra WHERE numcompra = " + nCompra.ToString + " ORDER BY idlinea", connMySQL)
        Dim dtPedido As DataTable = CargaTabla("SELECT * FROM cabpedido WHERE numpedido = " + dtCabecera.Rows(0)("numpedido").ToString, connMySQL)

        ReDim aLíneas(dtLíneas.Rows.Count - 1)

        If dtCabecera.Rows.Count = 0 Then Return

        nCompra = dtCabecera.Rows(0)("numcompra")
        txtNúmero.Text = dtCabecera.Rows(0)("numcompra").ToString
        txtFecha.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fecha").ToString, 10)
        comboEmpresa.SelectedValue = dtCabecera.Rows(0)("idempresa")
        comboEmpresa.Text = NombreEmpresa(dtCabecera.Rows(0)("idempresa"))
        txtPedido.Text = dtPedido.Rows(0)("numpedido").ToString
        If dtPedido.Rows.Count > 0 Then txtFechaPedido.Text = Microsoft.VisualBasic.Left(dtPedido.Rows(0)("fecha").ToString, 10)
        comboProveedor.SelectedValue = dtCabecera.Rows(0)("idproveedor")
        comboProveedor.Text = NombreProveedor(dtCabecera.Rows(0)("idproveedor"))
        txtDescuento.Text = Str(dtCabecera.Rows(0)("descuento"))
        txtFactura.Text = dtCabecera.Rows(0)("factura").ToString
        txtFechaFactura.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fechafactura").ToString, 10)
        txtFechaVencimiento.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fechavencimiento").ToString, 10)
        txtVisado.Text = dtCabecera.Rows(0)("visado").ToString
        txtFechaVisado.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fechavisado").ToString, 10)
        txtObservaciones.Text = dtCabecera.Rows(0)("observaciones").ToString
        txtNombre.Text = dtCabecera.Rows(0)("nombre")
        txtDirección.Text = dtCabecera.Rows(0)("direccion")
        txtPostal.Text = dtCabecera.Rows(0)("postal")
        txtPoblación.Text = dtCabecera.Rows(0)("poblacion")
        txtProvincia.Text = dtCabecera.Rows(0)("provincia")
        txtContacto.Text = dtCabecera.Rows(0)("contacto")
        txtTeléfono.Text = dtCabecera.Rows(0)("telefono")

        For n = 0 To dtLíneas.Rows.Count - 1
            aLíneas(n) = dtLíneas.Rows(n)("articulo") + Chr(255) +
                dtLíneas.Rows(n)("cantidad").ToString + Chr(255) +
                Str(dtLíneas.Rows(n)("precio")) + Chr(255) +
                Str(dtLíneas.Rows(n)("descuento")) + Chr(255)
        Next

        CargaLíneas()
    End Sub

    Private Sub CargaLíneas()
        lvwLíneas.Items.Clear()

        For n = 0 To aLíneas.GetLength(0) - 1
            Dim cLínea As String = aLíneas(n)
            If cLínea = Nothing Then Return

            Dim item As New ListViewItem(n.ToString)

            item.SubItems.Add(SacaDato(cLínea))
            cLínea = CortaDato(cLínea)
            item.SubItems.Add(FormatNumber(Val(SacaDato(cLínea)), 0, TriState.True, TriState.False, TriState.True))
            cLínea = CortaDato(cLínea)
            item.SubItems.Add(FormatNumber(Val(SacaDato(cLínea)), 2, TriState.True, TriState.False, TriState.True))
            cLínea = CortaDato(cLínea)
            item.SubItems.Add(FormatNumber(Val(SacaDato(cLínea)), 2, TriState.True, TriState.False, TriState.True))

            lvwLíneas.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub BtnPrimero_Click(sender As System.Object, e As System.EventArgs) Handles btnPrimero.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numcompra FROM cabcompra"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY numcompra ASC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        nCompra = dtCabecera.Rows(0)("numcompra")
        CargaDatos()
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numcompra FROM cabcompra WHERE numcompra < " + nCompra.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY numcompra DESC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            btnÚltimo_Click(sender, e)
        Else
            nCompra = dtCabecera.Rows(0)("numcompra")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numcompra FROM cabcompra WHERE numcompra > " + nCompra.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY numcompra ASC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            BtnPrimero_Click(sender, e)
        Else
            nCompra = dtCabecera.Rows(0)("numcompra")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnÚltimo_Click(sender As System.Object, e As System.EventArgs) Handles btnÚltimo.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numcompra FROM cabcompra"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY numcompra DESC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        nCompra = dtCabecera.Rows(0)("numcompra")
        CargaDatos()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim cSQL As String
        Dim dtTemporal As DataTable

        If lfiltrando Then
            cFiltro = ""

            If Not String.IsNullOrWhiteSpace(txtNúmero.Text) Then cFiltro += "numcompra = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cFiltro += "fecha = " + CtoD(txtFecha.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(comboEmpresa.Text) Then cFiltro += "idempresa = " + comboEmpresa.SelectedValue.ToString + " AND "
            If Not String.IsNullOrWhiteSpace(txtPedido.Text) Then cFiltro += "numpedido = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then cFiltro += "idproveedor = " + comboProveedor.SelectedValue.ToString + " AND "
            If Not String.IsNullOrWhiteSpace(txtDescuento.Text) Then cFiltro += "descuento = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtFactura.Text) Then cFiltro += "factura LIKE ""%" + StrConv(Trim(txtFactura.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtFechaFactura.Text) Then cFiltro += "fechafactura = " + CtoD(txtFechaFactura.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(txtFechaVencimiento.Text) Then cFiltro += "fechavencimiento = " + CtoD(txtFechaVencimiento.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(txtVisado.Text) Then cFiltro += "visado LIKE ""%" + StrConv(Trim(txtVisado.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtFechaVisado.Text) Then cFiltro += "fechavisado = " + CtoD(txtFechaVisado.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then cFiltro += "observaciones LIKE ""%" + StrConv(Trim(txtObservaciones.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtNombre.Text) Then cFiltro += "nombre LIKE ""%" + StrConv(Trim(txtNombre.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtDirección.Text) Then cFiltro += "direccion LIKE ""%" + StrConv(Trim(txtDirección.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtPostal.Text) Then cFiltro += "postal LIKE ""%" + StrConv(Trim(txtPostal.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtPoblación.Text) Then cFiltro += "poblacion LIKE ""%" + StrConv(Trim(txtPoblación.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtProvincia.Text) Then cFiltro += "provincia LIKE ""%" + StrConv(Trim(txtProvincia.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtContacto.Text) Then cFiltro += "contacto LIKE ""%" + StrConv(Trim(txtContacto.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtTeléfono.Text) Then cFiltro += "telefono LIKE ""%" + StrConv(Trim(txtTeléfono.Text), VbStrConv.Uppercase) + "%"" AND "

            If Not String.IsNullOrWhiteSpace(cFiltro) Then cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)

            cSQL = "SELECT * FROM cabcompra "
            If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += "WHERE " + cFiltro + " "
            cSQL += "ORDER BY numcompra"
            dtTemporal = CargaTabla(cSQL, connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("No hay registros en esas condiciones", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "")
                cFiltro = ""
                BorraCampos()
                Me.Text = "Compras V03/18"
            Else
                nCompra = dtTemporal.Rows(0)("numcompra")
                CargaDatos()
                Me.Text = "Compras V03/18 - Filtro[" + Trim(dtTemporal.Rows.Count.ToString) + "]"
            End If

            ActivaBotones()
            DesactivaCampos()
            lfiltrando = False
            Return
        End If

        If lModificando Then
            lGrabado = False
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
        Else
            If Not lGrabado Then
                If MsgBox("Compra sin grabar. ¿Desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return
            End If

            If MsgBox("¿Borrar datos?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
                BorraCampos()
                Dim aLíneas(0)
            Else
                txtNúmero.Text = ""
            End If

            txtFecha.Text = Format(Now, "d")
            lGrabado = False
            lModificando = True
            nCompra = 0
            ActivaCampos()
            DesactivaBotones()
            comboEmpresa.Focus()
        End If
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If lModificando Then
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
        Else
            lModificando = True
            ActivaCampos()
            DesactivaBotones()
            comboEmpresa.Focus()
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If String.IsNullOrWhiteSpace(txtNúmero.Text) Then Return

        Dim document As PdfDocument = New PdfDocument
        Dim page As PdfPage = document.AddPage
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, FontStyle.Bold)
        Dim cTexto As String
        Dim stringsize As XSize
        Dim aTexto() As String = New String() {}
        Dim aFacturar() As String
        Dim aEnviar() As String
        Dim nLínea, n, nLíneasDirección, nInicio As Integer
        Dim cDocumentos As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
        Dim cLínea As String
        Dim nCantidad As Integer
        Dim nPrecio, nDescuento As Decimal
        Dim nTotal As Decimal = 0
        Dim dtTemporal As DataTable
        Dim cSQL As string

        Dim dtEmpresa As DataTable = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + comboEmpresa.SelectedValue.ToString, connMySQL)

        page.Size = PageSize.A4
        pageCenter = page.Width.Point / 2
        topMargin = 25
        leftMargin = 25
        bottomMargin = page.Height.Point - 25
        rightMargin = page.Width.Point - 25
        pageCenter = page.Width.Point / 2

        nPágina = 1
        Cabecera(gfx, dtEmpresa)

        nLínea = topMargin + 50
        gfx.DrawRectangle(Pens.Black, leftMargin, nLínea - 10, rightMargin - leftMargin, 30)
        gfx.DrawLine(Pens.Black, leftMargin, nLínea + 5, rightMargin, nLínea + 5)
        gfx.DrawLine(Pens.Black, leftMargin + 43, nLínea - 10, leftMargin + 43, nLínea + 20)
        gfx.DrawLine(Pens.Black, leftMargin + 90, nLínea - 10, leftMargin + 90, nLínea + 20)
        cTexto = "Número"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 38 - stringsize.Width, nLínea))
        cTexto = "Fecha"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 65 - stringsize.Width / 2, nLínea))
        gfx.DrawString("Proveedor", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 95, nLínea))
        nLínea += 15
        cTexto = Trim(txtNúmero.Text)
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 38 - stringsize.Width, nLínea))
        cTexto = txtFecha.Text
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 65 - stringsize.Width / 2, nLínea))
        gfx.DrawString(comboProveedor.Text, fontTexto, XBrushes.Black, New XPoint(leftMargin + 95, nLínea))
        nLínea += 20

        cSQL = "SELECT proveedores.idformapago, formasdepago.nombre FROM proveedores, formasdepago "
        cSQL += "WHERE proveedores.idproveedor = " + comboProveedor.SelectedValue.ToString
        cSQL += " AND proveedores.idformapago = formasdepago.idformapago"
        dtTemporal = CargaTabla(cSQL, connMySQL)
        gfx.DrawRectangle(Pens.Black, leftMargin, nLínea - 10, rightMargin - leftMargin, 15)
        gfx.DrawLine(Pens.Black, leftMargin + 60, nLínea - 10, leftMargin + 60, nLínea + 5)
        gfx.DrawString("Forma de pago", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        gfx.DrawString(dtTemporal.Rows(0)("nombre"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 65, nLínea))
        nLínea += 15

        If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then
            nInicio = nLínea
            aTexto = Memo2Array(txtObservaciones.Text, 80)
            gfx.DrawString("Observaciones:", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))

            For n = 0 To aTexto.GetLength(0) - 1
                gfx.DrawString(aTexto(n), fontTexto, XBrushes.Black, New XPoint(leftMargin + 60, nLínea))
                nLínea += 10
            Next

            gfx.DrawRectangle(Pens.Black, leftMargin, nInicio - 10, rightMargin - leftMargin, aTexto.GetLength(0) * 10 + 5)
        End If

        nLínea += 10
        gfx.DrawString("Facturar a:", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        gfx.DrawString("Enviar a:", fontNegrita, XBrushes.Black, New XPoint(pageCenter + 10, nLínea))
        nInicio = nLínea - 10
        nLínea += 10

        aTexto = Memo2Array(dtEmpresa.Rows(0)("direccion").ToString, 60)
        ReDim aFacturar(1)
        aFacturar(0) = dtEmpresa.Rows(0)("nombre")
        'aFacturar(1) = "Att. " + Trim(dtEmpresa.Rows(0)("contacto")) + " (" + Trim(dtEmpresa.Rows(0)("telefono")) + ")"

        For n = 0 To aTexto.GetLength(0) - 1
            ReDim Preserve aFacturar(n + 1)
            aFacturar(n + 1) = aTexto(n)
        Next

        ReDim Preserve aFacturar(n + 4)
        aFacturar(n + 1) = Trim(dtEmpresa.Rows(0)("postal") + " " + Trim(dtEmpresa.Rows(0)("poblacion")))
        aFacturar(n + 2) = "(" + Trim(dtEmpresa.Rows(0)("provincia")) + ")"
        aFacturar(n + 3) = "CIF: " + dtEmpresa.Rows(0)("cif")

        aTexto = Memo2Array(txtDirección.Text, 60)
        ReDim aEnviar(1)
        aEnviar(0) = txtNombre.Text
        aEnviar(1) = "Att. " + Trim(txtContacto.Text) + " (" + Trim(txtTeléfono.Text) + ")"

        For n = 0 To aTexto.GetLength(0) - 1
            ReDim Preserve aEnviar(n + 2)
            aEnviar(n + 2) = aTexto(n)
        Next

        ReDim Preserve aEnviar(n + 3)
        aEnviar(n + 2) = Trim(txtPostal.Text + " " + Trim(txtPoblación.Text))
        aEnviar(n + 3) = "(" + Trim(txtProvincia.Text) + ")"

        nLíneasDirección = Math.Max(aFacturar.GetLength(0), aEnviar.GetLength(0)) - 1
        ReDim Preserve aFacturar(nLíneasDirección)
        ReDim Preserve aEnviar(nLíneasDirección)

        For n = 0 To nLíneasDirección
            If aFacturar(n) <> Nothing Then gfx.DrawString(aFacturar(n), fontTexto, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
            If aEnviar(n) <> Nothing Then gfx.DrawString(aEnviar(n), fontTexto, XBrushes.Black, New XPoint(pageCenter + 10, nLínea))
            nLínea += 10
        Next

        gfx.DrawRectangle(Pens.Black, leftMargin, nInicio, pageCenter - leftMargin - 5, nLíneasDirección * 10 + 25)
        gfx.DrawRectangle(Pens.Black, pageCenter + 5, nInicio, rightMargin - pageCenter - 5, nLíneasDirección * 10 + 25)

        nLínea += 10
        CabeceraLíneas(gfx, nLínea)
        nLínea += 15

        For n = 0 To aLíneas.GetLength(0) - 1
            cLínea = aLíneas(n)
            aTexto = Memo2Array(SacaDato(cLínea), 60)
            cLínea = CortaDato(cLínea)
            nCantidad = Val(SacaDato(cLínea))
            cLínea = CortaDato(cLínea)
            nPrecio = Val(SacaDato(cLínea))
            cLínea = CortaDato(cLínea)
            nDescuento = Val(SacaDato(cLínea))

            If nLínea + aTexto.GetLength(0) * 10 + 90 > bottomMargin Then
                nPágina += 1
                Cabecera(gfx, dtEmpresa)
                CabeceraLíneas(gfx, topMargin + 50)
                nLínea = topMargin + 65
            End If

            gfx.DrawString(aTexto(0), fontTexto, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
            cTexto = FormatNumber(nCantidad, 0, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 160 - stringsize.Width, nLínea))
            cTexto = FormatNumber(nPrecio, 2, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea))
            cTexto = FormatNumber(nDescuento, 2, TriState.True, TriState.False, TriState.True) + "%"
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea))
            cTexto = FormatNumber(nCantidad * nPrecio * (1 - nDescuento / 100), 2, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
            nLínea += 10

            For m = 1 To aTexto.GetLength(0) - 1
                gfx.DrawString(aTexto(m), fontTexto, XBrushes.Black, New XPoint(leftMargin + 10, nLínea))
                nLínea += 10
            Next

            nTotal += nCantidad * nPrecio * (1 - nDescuento / 100)
        Next

        nLínea += 10

        cTexto = FormatNumber(nTotal, 2, TriState.True, TriState.False, TriState.True)
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        gfx.DrawString("Total pedido bruto", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        nLínea += 10
        cTexto = FormatNumber(nTotal * Val(txtDescuento.Text) / 100, 2, TriState.True, TriState.False, TriState.True)
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        gfx.DrawString("Descuento " + FormatNumber(Val(txtDescuento.Text), 2, TriState.True, TriState.False, TriState.True) + "%", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        nLínea += 10
        cTexto = FormatNumber(nTotal * (1 - Val(txtDescuento.Text) / 100), 2, TriState.True, TriState.False, TriState.True)
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        gfx.DrawString("Total pedido neto", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))

        document.Save(cDocumentos + "Compra.pdf")
        Process.Start(cDocumentos + "Compra.pdf")
    End Sub

    Private Sub Cabecera(gfx As XGraphics, dtEmpresa As DataTable)
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTítulo As XFont = New XFont("Calibri", 12, XFontStyle.Bold)
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, XFontStyle.Bold)
        Dim lb() As Byte

        If IsDBNull(dtEmpresa.Rows(0)("logo")) Then
            lb = Nothing
        Else
            lb = dtEmpresa.Rows(0)("logo")
            Dim lstr As New System.IO.MemoryStream(lb)
            Dim imagen As Bitmap = Image.FromStream(lstr)

            gfx.DrawImage(imagen, leftMargin, topMargin, 100, 16)
            lstr.Close()
        End If

        cTexto = "Orden de compra"
        stringsize = gfx.MeasureString(cTexto, fontTítulo)
        gfx.DrawString(cTexto, fontTítulo, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + 12))
        cTexto = "Pág: " + Trim(Str(nPágina))
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - stringsize.Width, topMargin + 12))
    End Sub

    Private Sub CabeceraLíneas(gfx As XGraphics, nLínea As Integer)
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 7)
        Dim fontNegrita As XFont = New XFont("Calibri", 7, XFontStyle.Bold)


        gfx.DrawString("Artículo", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        cTexto = "Total"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        cTexto = "Descuento"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea))
        cTexto = "Precio"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea))
        cTexto = "Cantidad"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 160 - stringsize.Width, nLínea))

        'gfx.DrawString("ArtículoArtículoArtículoArtículoArtículoArtículoArtículoArtí", fontTexto, XBrushes.Black, New XPoint(leftMargin + 5, nLínea + 10))
        'cTexto = "999.999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 160 - stringsize.Width, nLínea + 10))
        'cTexto = "99,99%"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea + 10))
        'cTexto = "9.999.999,99"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea + 10))
        'cTexto = "9.999.999,99"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea + 10))
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtCabecera As DataTable
        Dim cLínea As String

        If nCompra = 0 Then
            cSQL = "INSERT INTO cabcompra(fecha, idempresa, numpedido, idproveedor, descuento, factura, "
            If Not String.IsNullOrEmpty(txtFechaFactura.Text) Then cSQL += "fechafactura, "
            If Not String.IsNullOrEmpty(txtFechaVencimiento.Text) Then cSQL += "fechavencimiento, "
            cSQL += "visado, "
            If Not String.IsNullOrEmpty(txtFechaVisado.Text) Then cSQL += "fechavisado, "
            cSQL += "observaciones, nombre, direccion, postal, poblacion, provincia, contacto, telefono) VALUES ("
            cSQL += CtoD(txtFecha.Text) + ", "
            cSQL += comboEmpresa.SelectedValue.ToString + ", "
            cSQL += txtPedido.Text + ", "
            cSQL += comboProveedor.SelectedValue.ToString + ", "
            cSQL += txtDescuento.Text + ", "
            cSQL += GrabaComillas(txtFactura.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaFactura.Text) Then cSQL += CtoD(txtFechaFactura.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaVencimiento.Text) Then cSQL += CtoD(txtFechaVencimiento.Text) + ", "
            cSQL += GrabaComillas(txtVisado.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaVisado.Text) Then cSQL += CtoD(txtFechaVisado.Text) + ", "
            cSQL += GrabaComillas(txtObservaciones.Text) + ", "
            cSQL += GrabaComillas(txtNombre.Text) + ", "
            cSQL += GrabaComillas(txtDirección.Text) + ", "
            cSQL += GrabaComillas(txtPostal.Text) + ", "
            cSQL += GrabaComillas(txtPoblación.Text) + ", "
            cSQL += GrabaComillas(txtProvincia.Text) + ", "
            cSQL += GrabaComillas(txtContacto.Text) + ", "
            cSQL += GrabaComillas(txtTeléfono.Text) + ")"
        Else
            cSQL = "UPDATE cabcompra SET "
            cSQL += "fecha = " + CtoD(txtFecha.Text) + ", "
            cSQL += "idempresa = " + comboEmpresa.SelectedValue.ToString + ", "
            cSQL += "numpedido = " + txtPedido.Text + ", "
            cSQL += "idproveedor = " + comboProveedor.SelectedValue.ToString + ", "
            cSQL += "descuento = " + txtDescuento.Text + ", "
            cSQL += "factura = " + GrabaComillas(txtFactura.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaFactura.Text) Then cSQL += "fechafactura = " + CtoD(txtFechaFactura.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaVencimiento.Text) Then cSQL += "fechavencimiento = " + CtoD(txtFechaVencimiento.Text) + ", "
            cSQL += "visado = " + GrabaComillas(txtVisado.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaVisado.Text) Then cSQL += "fechavisado = " + CtoD(txtFechaVisado.Text) + ", "
            cSQL += "observaciones = " + GrabaComillas(txtObservaciones.Text) + ", "
            cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
            cSQL += "direccion = " + GrabaComillas(txtDirección.Text) + ", "
            cSQL += "postal = " + GrabaComillas(txtPostal.Text) + ", "
            cSQL += "poblacion = " + GrabaComillas(txtPoblación.Text) + ", "
            cSQL += "provincia = " + GrabaComillas(txtProvincia.Text) + ", "
            cSQL += "contacto = " + GrabaComillas(txtContacto.Text) + ", "
            cSQL += "telefono = " + GrabaComillas(txtTeléfono.Text)
            cSQL += " WHERE numcompra = " + nCompra.ToString
        End If

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        If nCompra = 0 Then
            dtCabecera = CargaTabla("SELECT numcompra FROM cabcompra ORDER BY numcompra DESC LIMIT 1", connMySQL)
            nCompra = dtCabecera.Rows(0)("numcompra")
        Else
            cSQL = "DELETE FROM lincompra WHERE numcompra = " + nCompra.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try
        End If

        For n = 0 To aLíneas.GetLength(0) - 1
            If aLíneas(n) <> Nothing Then
                cLínea = aLíneas(n)
                cSQL = "INSERT INTO lincompra(numcompra, articulo, cantidad, precio, descuento) VALUES("
                cSQL += nCompra.ToString + ", "
                cSQL += GrabaComillas(SacaDato(cLínea)) + ", "
                cLínea = CortaDato(cLínea)
                cSQL += Str(Val(SacaDato(cLínea))) + ", "
                cLínea = CortaDato(cLínea)
                cSQL += Str(Val(SacaDato(cLínea))) + ", "
                cLínea = CortaDato(cLínea)
                cSQL += Str(Val(SacaDato(cLínea))) + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return
                End Try
            End If
        Next

        connMySQL.Close()
        lGrabado = True
        ActivaBotones()
        CargaDatos()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If String.IsNullOrWhiteSpace(txtNúmero.Text) Then Return
        If MsgBox("¿Está seguro de eliminar esta compra?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        cSQL = "DELETE FROM lincompra WHERE numcompra = " + txtNúmero.Text
        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        cSQL = "DELETE FROM cabcompra WHERE numcompra = " + txtNúmero.Text
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        connMySQL.Close()
        BorraCampos()
        nCompra = 0
    End Sub
End Class