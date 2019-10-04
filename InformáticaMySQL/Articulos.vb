#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213
#Disable Warning IDE0067
#Disable Warning IDE0068

Imports MySql.Data.MySqlClient

Public Class FrmArticulos
    Private connMySQL As MySqlConnection
    Private dtArtículo, dtTiendas, dtMovimientos, dtProveedores, dtReparaciones As DataTable
    Private lModificando As Boolean = False
    Private lBuscando As Boolean = False
    Private nCódigo As Integer = 0
    Private nMovimiento As Integer = 0
    Private nReparación As Integer = 0
    Private cFiltro As String = ""
    Private aPáginas(3) As TabPage

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmArticulos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim nSize As System.Drawing.Size

        connMySQL = New MySqlConnection(Conexión())

        For n = 0 To 2
            aPáginas(n) = tabArtículos.TabPages(n)
        Next

        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)
        dtTiendas = CargaTabla("SELECT idtienda, nombre FROM tiendas ORDER BY nombre", connMySQL)

        'comboProveedor.DataSource = CargaProveedores()
        'comboProveedor.DisplayMember = "name"
        'comboProveedor.ValueMember = "id"
        'comboProveedorReparación.DataSource = CargaProveedores()
        'comboProveedorReparación.DisplayMember = "name"
        'comboProveedorReparación.ValueMember = "id"
        CargaProveedores(comboProveedor)
        CargaProveedores(comboProveedorReparación)
        comboTiendaMovimiento.DataSource = dtTiendas
        comboTiendaMovimiento.DisplayMember = "nombre"
        comboTiendaMovimiento.ValueMember = "idtienda"
        comboTiendaMovimiento.SelectedValue = 317

        With lvwMovimientos
            .Columns.Add("idmovimiento", 0, HorizontalAlignment.Right)
            .Columns.Add("Ubicación", 300, HorizontalAlignment.Left)
            .Columns.Add("Fecha", 80, HorizontalAlignment.Center)
            .Columns.Add("Usuario", 300, HorizontalAlignment.Left)
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height + 60
            .Size = nSize
        End With

        With lvwReparaciones
            .Columns.Add("idreparacion", 0, HorizontalAlignment.Right)
            .Columns.Add("Fecha", 80, HorizontalAlignment.Center)
            .Columns.Add("Proveedor", 100, HorizontalAlignment.Left)
            .Columns.Add("Avería", 300, HorizontalAlignment.Left)
            .Columns.Add("Reparación", 90, HorizontalAlignment.Center)
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height + 130
            .Size = nSize
        End With

    End Sub

    'Private Function CargaProveedores() As List(Of comboitem)
    '    Dim provItems = New List(Of ComboItem)

    '    provItems.Add(New ComboItem(0, ""))

    '    For n = 0 To dtProveedores.Rows.Count - 1
    '        provItems.Add(New ComboItem(dtProveedores.Rows(n)("idproveedor"), dtProveedores.Rows(n)("nombre")))
    '    Next

    '    Return provItems
    'End Function

    Private Sub CargaProveedores(combo As ComboBox)
        combo.DisplayMember = "name"
        combo.ValueMember = "id"

        Dim tb As New DataTable

        tb.Columns.Add("id", GetType(Integer))
        tb.Columns.Add("name", GetType(String))

        tb.Rows.Add(0, "")

        For n = 0 To dtProveedores.Rows.Count - 1
            tb.Rows.Add(dtProveedores.Rows(n)("idproveedor"), dtProveedores.Rows(n)("nombre"))
        Next
        combo.DataSource = tb
    End Sub

    Class MyItem
        Public Sub New(ByVal text As String, ByVal value As Integer)
            t = text
            v = value
        End Sub

        Private t As String
        Private v As Integer
        Public Property Text() As String
            Get
                Return t
            End Get
            Set(ByVal value As String)
                t = value
            End Set
        End Property
        Public Property Value() As Integer
            Get
                Return v
            End Get
            Set(ByVal value As Integer)
                v = value
            End Set
        End Property
    End Class

    Private Sub CargaDatos()
        Dim dtTemporal As DataTable

        If String.IsNullOrWhiteSpace(cFiltro) Then
            Me.Text = "Artículos V07/12"
        Else
            Me.Text = "Artículos V07/12 [Filtro]"
        End If

        dtArtículo = CargaTabla("SELECT * FROM articulos WHERE idarticulo = " + nCódigo.ToString, connMySQL)
        txtCódigo.Text = dtArtículo.Rows(0)("idarticulo")
        txtSerie.Text = dtArtículo.Rows(0)("serie")
        txtNombre.Text = dtArtículo.Rows(0)("nombre")
        txtDescripción.Text = dtArtículo.Rows(0)("descripcion")
        txtCompra.Text = Microsoft.VisualBasic.Left(dtArtículo.Rows(0)("compra").ToString, 10)
        txtGarantía.Text = Microsoft.VisualBasic.Left(dtArtículo.Rows(0)("garantia").ToString, 10)
        chkRetirado.Checked = dtArtículo.Rows(0)("retirado")
        comboProveedor.SelectedValue = dtArtículo.Rows(0)("idproveedor")
        txtFactura.Text = dtArtículo.Rows(0)("factura")
        txtPrecio.Text = Trim(Str(dtArtículo.Rows(0)("precio")))

        lvwMovimientos.Items.Clear()
        dtMovimientos = CargaTabla("SELECT * FROM movimientosarticulos WHERE idarticulo = " + nCódigo.ToString + " ORDER BY idmovimiento", connMySQL)

        For n = 0 To dtMovimientos.Rows.Count - 1
            dtTemporal = CargaTabla("SELECT nombre FROM tiendas WHERE idtienda = " + dtMovimientos.Rows(n)("idtienda").ToString, connMySQL)

            Dim item As New ListViewItem(dtMovimientos.Rows(n)("idmovimiento").ToString)

            If dtTemporal.Rows.Count = 0 Then
                item.SubItems.Add("")
            Else
                item.SubItems.Add(dtTemporal.Rows(0)("nombre").ToString)
            End If

            item.SubItems.Add(Microsoft.VisualBasic.Left(dtMovimientos.Rows(n)("fecha").ToString, 10))
            item.SubItems.Add(dtMovimientos.Rows(n)("usuario").ToString)
            lvwMovimientos.Items.AddRange(New ListViewItem() {item})
        Next

        lvwReparaciones.Items.Clear()
        dtReparaciones = CargaTabla("SELECT * FROM reparacionesarticulos WHERE idarticulo = " + nCódigo.ToString + " ORDER BY idreparacion", connMySQL)

        For n = 0 To dtReparaciones.Rows.Count - 1
            dtTemporal = CargaTabla("SELECT nombre FROM proveedores WHERE idproveedor = " + dtReparaciones.Rows(n)("idproveedor").ToString, connMySQL)

            Dim item As New ListViewItem(dtReparaciones.Rows(n)("idreparacion").ToString)

            item.SubItems.Add(Microsoft.VisualBasic.Left(dtReparaciones.Rows(n)("fecha").ToString, 10))

            If dtTemporal.Rows.Count = 0 Then
                item.SubItems.Add("")
            Else
                item.SubItems.Add(dtTemporal.Rows(0)("nombre").ToString)
            End If

            item.SubItems.Add(dtReparaciones.Rows(n)("averia").ToString)
            item.SubItems.Add(Microsoft.VisualBasic.Left(dtReparaciones.Rows(n)("devolucion").ToString, 10))
            lvwReparaciones.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub RestauraPáginas()
        tabArtículos.Controls.Remove(tabArtículos.TabPages(0))

        For n = 0 To 2
            tabArtículos.Controls.Add(aPáginas(n))
        Next
    End Sub

    Private Sub BorraCampos()
        txtCódigo.Text = ""
        txtSerie.Text = ""
        txtNombre.Text = ""
        txtDescripción.Text = ""
        txtCompra.Text = ""
        txtGarantía.Text = ""
        chkRetirado.Checked = False
        comboProveedor.Text = ""
        txtFactura.Text = ""
        txtPrecio.Text = ""

        BorraCamposMovimientos()
        BorraCamposReparaciones()
        lvwMovimientos.Items.Clear()
        lvwReparaciones.Items.Clear()
    End Sub

    Private Sub BorraCamposMovimientos()
        txtFechaMovimiento.Text = ""
        comboTiendaMovimiento.Text = ""
        txtUsuarioMovimiento.Text = ""
    End Sub

    Private Sub BorraCamposReparaciones()
        txtFechaReparación.Text = ""
        txtDevolución.Text = ""
        comboProveedorReparación.Text = ""
        txtAvería.Text = ""
    End Sub

    Private Sub ActivaCampos()
        txtSerie.ReadOnly = False
        txtNombre.ReadOnly = False
        txtDescripción.ReadOnly = False
        txtCompra.ReadOnly = False
        txtGarantía.ReadOnly = False
        txtFactura.ReadOnly = False
        txtPrecio.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtCódigo.ReadOnly = True
        txtSerie.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDescripción.ReadOnly = True
        txtCompra.ReadOnly = True
        txtGarantía.ReadOnly = True
        txtFactura.ReadOnly = True
        txtPrecio.ReadOnly = True
    End Sub

    Private Sub ActivaCamposMovimientos()
        Dim nSize As System.Drawing.Size

        txtFechaMovimiento.ReadOnly = False
        txtUsuarioMovimiento.ReadOnly = False

        With lvwMovimientos
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height - 60
            .Size = nSize
        End With
    End Sub

    Private Sub DesactivaCamposMovimientos()
        Dim nSize As System.Drawing.Size

        txtFechaMovimiento.ReadOnly = True
        txtUsuarioMovimiento.ReadOnly = True

        With lvwMovimientos
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height + 60
            .Size = nSize
        End With
    End Sub

    Private Sub ActivaCamposReparaciones()
        Dim nSize As System.Drawing.Size

        txtFechaReparación.ReadOnly = False
        txtDevolución.ReadOnly = False
        txtAvería.ReadOnly = False

        With lvwReparaciones
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height - 130
            .Size = nSize
        End With
    End Sub

    Private Sub DesactivaCamposReparaciones()
        Dim nSize As System.Drawing.Size

        txtFechaReparación.ReadOnly = True
        txtDevolución.ReadOnly = True
        txtAvería.ReadOnly = True

        With lvwReparaciones
            nSize.Width = .Size.Width
            nSize.Height = .Size.Height + 130
            .Size = nSize
        End With
    End Sub

    Private Sub ActivaBotones()
        btnCompra.Enabled = False
        btnGarantía.Enabled = False
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
        btnSiguiente.Enabled = True
        btnÚltimo.Enabled = True
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"
        btnBuscar.Enabled = True
        btnEliminar.Enabled = True
        btnListar.Enabled = True
        btnSalir.Enabled = True
        Me.ControlBox = True
        Me.AcceptButton = Nothing
        Me.CancelButton = Nothing
    End Sub

    Private Sub DesactivaBotones()
        btnCompra.Enabled = True
        btnGarantía.Enabled = True
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        btnSiguiente.Enabled = False
        btnÚltimo.Enabled = False
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnBuscar.Enabled = False
        btnEliminar.Enabled = False
        btnListar.Enabled = False
        btnSalir.Enabled = False
        Me.ControlBox = False
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
    End Sub

    Private Sub ActivaBotonesMovimientos()
        btnFechaMovimiento.Enabled = False
        btnAgregarMovimiento.Text = "&Agregar"
        btnModificarMovimiento.Text = "&Modificar"
        btnEliminarMovimiento.Enabled = True
        Me.ControlBox = True
        Me.AcceptButton = Nothing
        Me.CancelButton = Nothing
    End Sub

    Private Sub DesactivaBotonesMovimientos()
        btnFechaMovimiento.Enabled = True
        btnAgregarMovimiento.Text = "&Aceptar"
        btnModificarMovimiento.Text = "&Cancelar"
        btnEliminarMovimiento.Enabled = False
        Me.ControlBox = False
        Me.AcceptButton = btnAgregarMovimiento
        Me.CancelButton = btnModificarMovimiento
    End Sub

    Private Sub ActivaBotonesReparaciones()
        btnFechaReparación.Enabled = False
        btnFechaDevolución.Enabled = False
        btnAgregarReparación.Text = "&Agregar"
        btnModificarReparación.Text = "&Modificar"
        btnEliminarReparación.Enabled = True
        Me.ControlBox = True
        Me.AcceptButton = Nothing
        Me.CancelButton = Nothing
    End Sub

    Private Sub DesactivaBotonesReparaciones()
        btnFechaReparación.Enabled = True
        btnFechaDevolución.Enabled = True
        btnAgregarReparación.Text = "&Aceptar"
        btnModificarReparación.Text = "&Cancelar"
        btnEliminarReparación.Enabled = False
        Me.ControlBox = False
        Me.AcceptButton = btnAgregarReparación
        Me.CancelButton = btnModificarReparación
    End Sub

    Private Sub BtnPrimero_Click(sender As System.Object, e As System.EventArgs) Handles btnPrimero.Click
        Dim cSQL As String = "SELECT idarticulo FROM articulos "

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY idarticulo ASC LIMIT 1"
        dtArtículo = CargaTabla(cSQL, connMySQL)
        nCódigo = dtArtículo.Rows(0)("idarticulo")
        CargaDatos()
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        Dim cSQL As String = "SELECT idarticulo FROM articulos WHERE idarticulo < " + nCódigo.ToString

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY idarticulo DESC LIMIT 1"
        dtArtículo = CargaTabla(cSQL, connMySQL)

        If dtArtículo.Rows.Count = 0 Then
            btnÚltimo_Click(sender, e)
        Else
            nCódigo = dtArtículo.Rows(0)("idarticulo")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim cSQL As String = "SELECT Idarticulo FROM articulos WHERE idarticulo > " + nCódigo.ToString

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY idarticulo ASC LIMIT 1"
        dtArtículo = CargaTabla(cSQL, connMySQL)

        If dtArtículo.Rows.Count = 0 Then
            BtnPrimero_Click(sender, e)
        Else
            nCódigo = dtArtículo.Rows(0)("idarticulo")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnÚltimo_Click(sender As System.Object, e As System.EventArgs) Handles btnÚltimo.Click
        Dim cSQL As String = "SELECT idarticulo FROM articulos "

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY idarticulo DESC LIMIT 1"
        dtArtículo = CargaTabla(cSQL, connMySQL)
        nCódigo = dtArtículo.Rows(0)("idarticulo")
        CargaDatos()
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        If lBuscando Then
            lBuscando = False
            DesactivaCampos()
            ActivaBotones()
            RestauraPáginas()

            cFiltro = ""
            If Not String.IsNullOrWhiteSpace(txtCódigo.Text) Then cFiltro += "idarticulo = " + txtCódigo.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtSerie.Text) Then cFiltro += "UCASE(serie) LIKE ""%" + StrConv(Trim(txtSerie.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtNombre.Text) Then cFiltro += "UCASE(nombre) LIKE ""%" + StrConv(Trim(txtNombre.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtDescripción.Text) Then cFiltro += "UCASE(descripcion) LIKE ""%" + StrConv(Trim(txtDescripción.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtCompra.Text) Then cFiltro += "compra = " + CtoD(txtCompra.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then cFiltro += "idproveedor = " + comboProveedor.SelectedValue.ToString + " AND "
            If Not String.IsNullOrWhiteSpace(txtFactura.Text) Then cFiltro += "factura = " + GrabaComillas(txtFactura.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(txtPrecio.Text) Then cFiltro += "precio = " + txtPrecio.Text + " AND "

            If String.IsNullOrWhiteSpace(cFiltro) Then
                dtArtículo = CargaTabla("SELECT * FROM articulos ORDER BY idarticulo ASC LIMIT 1", connMySQL)
            Else
                cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
                cSQL = "SELECT * FROM articulos WHERE " + cFiltro + " ORDER BY idarticulo ASC LIMIT 1"
                dtArtículo = CargaTabla(cSQL, connMySQL)

                If dtArtículo.Rows.Count = 0 Then
                    MsgBox("No hay registros en esas condiciones")
                    cFiltro = ""
                    dtArtículo = CargaTabla("SELECT * FROM articulos ORDER BY idarticulo ASC LIMIT 1", connMySQL)
                End If
            End If

            nCódigo = dtArtículo.Rows(0)("idarticulo")
            CargaDatos()
            Return
        End If

        If lModificando Then
            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                cSQL = "INSERT INTO articulos(serie, nombre, descripcion, "
                If Not String.IsNullOrWhiteSpace(txtCompra.Text) Then cSQL += "compra, "
                If Not String.IsNullOrWhiteSpace(txtGarantía.Text) Then cSQL += "garantia, "
                cSQL += "idproveedor, factura, precio, retirado) VALUES ("
                cSQL += GrabaComillas(txtSerie.Text) + ", "
                cSQL += GrabaComillas(txtNombre.Text) + ", "
                cSQL += GrabaComillas(txtDescripción.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtCompra.Text) Then cSQL += CtoD(txtCompra.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtGarantía.Text) Then cSQL += CtoD(txtGarantía.Text) + ", "
                cSQL += comboProveedor.SelectedValue.ToString + ", "
                cSQL += GrabaComillas(txtFactura.Text) + ", "
                cSQL += Str(Val(txtPrecio.Text)) + ", "
                cSQL += If(chkRetirado.Checked, "1", "0") + ")"
            Else
                cSQL = "UPDATE articulos SET "
                cSQL += "serie = " + GrabaComillas(txtSerie.Text) + ", "
                cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
                cSQL += "descripcion = " + GrabaComillas(txtDescripción.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtCompra.Text) Then cSQL += "compra = " + CtoD(txtCompra.Text) + ", "
                If Not String.IsNullOrWhiteSpace(txtGarantía.Text) Then cSQL += "garantia = " + CtoD(txtGarantía.Text) + ", "
                cSQL += "idproveedor = " + comboProveedor.SelectedValue.ToString + ", "
                cSQL += "factura = " + GrabaComillas(txtFactura.Text) + ", "
                cSQL += "precio = " + Str(Val(txtPrecio.Text)) + ", "
                cSQL += "retirado = " + If(chkRetirado.Checked, "1", "0")
                cSQL += " WHERE idarticulo = " + txtCódigo.Text
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Alta/actualización de artículo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connMySQL.Close()

            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                dtArtículo = CargaTabla("SELECT * FROM articulos ORDER BY idarticulo DESC LIMIT 1", connMySQL)
                nCódigo = dtArtículo.Rows(0)("idarticulo")
                txtCódigo.Text = nCódigo.ToString

                If Not String.IsNullOrWhiteSpace(txtCompra.Text) Then
                    cSQL = "INSERT INTO movimientosarticulos(idarticulo, idtienda, fecha, usuario) VALUES("
                    cSQL += nCódigo.ToString + ", "
                    cSQL += "317, "
                    cSQL += CtoD(txtCompra.Text) + ", "
                    cSQL += GrabaComillas("Almacén") + ")"
                    cmd = New MySqlCommand(cSQL, connMySQL)
                    connMySQL.Open()

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Dim st As StackTrace
                        st = New StackTrace(ex, True)
                        Dim obj As New FrmError(ex, "Inserción de movimientos de artículos", st)
                        Dim nResultado As Integer

                        nResultado = obj.ShowDialog(Me)
                        If nResultado = DialogResult.Cancel Then Me.Close()
                    Finally
                        cmd.Dispose()
                    End Try

                    connMySQL.Close()
                End If
            End If

            DesactivaCampos()
            ActivaBotones()
            lModificando = False
            RestauraPáginas()
            CargaDatos()
            Return
        End If

        If MsgBox("¿Borrar campos?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            BorraCampos()
        Else
            txtCódigo.Text = ""
            txtSerie.Text = ""
            BorraCamposMovimientos()
            BorraCamposReparaciones()
            lvwMovimientos.Items.Clear()
            lvwReparaciones.Items.Clear()
        End If

        lModificando = True
        ActivaCampos()
        DesactivaBotones()

        For n = 1 To 2
            tabArtículos.Controls.Remove(tabArtículos.TabPages(1))
        Next

        txtSerie.Focus()
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If lModificando Then
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            RestauraPáginas()
            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then BorraCampos() Else CargaDatos()
            Return
        End If

        lModificando = True
        ActivaCampos()
        DesactivaBotones()

        For n = 1 To 2
            tabArtículos.Controls.Remove(tabArtículos.TabPages(1))
        Next

        txtSerie.Focus()
    End Sub

    Private Sub TxtNombre_Leave(sender As Object, e As System.EventArgs) Handles txtNombre.Leave
        If lModificando And String.IsNullOrWhiteSpace(txtDescripción.Text) Then txtDescripción.Text = txtNombre.Text
    End Sub

    Private Sub TxtCompra_Leave(sender As Object, e As System.EventArgs) Handles txtCompra.Leave
        If lModificando And String.IsNullOrWhiteSpace(txtGarantía.Text) And Not String.IsNullOrWhiteSpace(txtCompra.Text) Then
            txtGarantía.Text = Microsoft.VisualBasic.Left(DateTime.Parse(txtCompra.Text).AddYears(2).ToString, 10)
            txtGarantía.Text = Microsoft.VisualBasic.Left(DateTime.Parse(txtGarantía.Text).AddDays(-1).ToString, 10)
        End If
    End Sub

    Private Sub BtnCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnCompra.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtCompra.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtCompra_Leave(sender, e)
    End Sub

    Private Sub BtnGarantía_Click(sender As System.Object, e As System.EventArgs) Handles btnGarantía.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtGarantía.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lBuscando = True
        ActivaCampos()
        DesactivaBotones()
        BorraCampos()
        txtCódigo.ReadOnly = False

        For n = 1 To 2
            tabArtículos.Controls.Remove(tabArtículos.TabPages(1))
        Next

        txtSerie.Focus()
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar este artículo?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM articulos WHERE idarticulo = " + txtCódigo.Text
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Eliminar artículo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()

            BorraCampos()
            nCódigo = 0
        End If
    End Sub

    Private Sub BtnAgregarMovimiento_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarMovimiento.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lModificando Then
            If nMovimiento = 0 Then
                cSQL = "INSERT INTO movimientosarticulos(idarticulo, idtienda, fecha, usuario) VALUES("
                cSQL += txtCódigo.Text + ", "
                cSQL += comboTiendaMovimiento.SelectedValue.ToString + ", "
                cSQL += CtoD(txtFechaMovimiento.Text) + ", "
                cSQL += GrabaComillas(txtUsuarioMovimiento.Text) + ")"
            Else
                cSQL = "UPDATE movimientosarticulos SET "
                cSQL += "idtienda = " + comboTiendaMovimiento.SelectedValue.ToString + ", "
                cSQL += "fecha = " + CtoD(txtFechaMovimiento.Text) + ", "
                cSQL += "usuario = " + GrabaComillas(txtUsuarioMovimiento.Text)
                cSQL += " WHERE idmovimiento = " + nMovimiento.ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Agregar movimiento de artículo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()

            lModificando = False
            RestauraPáginas()
            tabArtículos.SelectedTab = pageMovimientos
            ActivaBotonesMovimientos()
            DesactivaCamposMovimientos()
            CargaDatos()
            Return
        End If

        lModificando = True
        nMovimiento = 0
        tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
        tabArtículos.Controls.Remove(tabArtículos.TabPages(1))
        ActivaCamposMovimientos()
        DesactivaBotonesMovimientos()
        txtFechaMovimiento.Focus()
    End Sub

    Private Sub BtnModificarMovimiento_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarMovimiento.Click
        If lModificando Then
            lModificando = False
            BorraCamposMovimientos()
            ActivaBotonesMovimientos()
            DesactivaCamposMovimientos()

            RestauraPáginas()
            tabArtículos.SelectedTab = pageMovimientos
        Else
            If nMovimiento = 0 Then
                MsgBox("Debe seleccionar un movimiento", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
                Return
            End If

            lModificando = True
            tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
            tabArtículos.Controls.Remove(tabArtículos.TabPages(1))
            ActivaCamposMovimientos()
            DesactivaBotonesMovimientos()
            txtFechaMovimiento.Focus()
        End If
    End Sub

    Private Sub LvwMovimientos_Click(sender As Object, e As System.EventArgs) Handles lvwMovimientos.Click
        Dim dtTemporal As DataTable

        nMovimiento = Val(lvwMovimientos.SelectedItems(0).Text)

        dtTemporal = CargaTabla("SELECT * FROM movimientosarticulos WHERE idmovimiento = " + nMovimiento.ToString, connMySQL)
        txtFechaMovimiento.Text = Microsoft.VisualBasic.Left(dtTemporal.Rows(0)("fecha").ToString, 10)
        comboTiendaMovimiento.SelectedValue = dtTemporal.Rows(0)("idtienda")
        txtUsuarioMovimiento.Text = dtTemporal.Rows(0)("usuario")
    End Sub

    Private Sub LvwMovimientos_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwMovimientos.DoubleClick
        BtnModificarMovimiento_Click(sender, e)
    End Sub

    Private Sub BtnEliminarMovimiento_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarMovimiento.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If nMovimiento = 0 Then
            MsgBox("Debe seleccionar un movimiento", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If MsgBox("¿Está seguro de elimianr este movimiento?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM movimientosarticulos WHERE idmovimiento = " + nMovimiento.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Eliminar movimiento de artículo", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()
            nMovimiento = 0
            CargaDatos()
        End If
    End Sub

    Private Sub BtnAgregarReparación_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarReparación.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lModificando Then
            If nReparación = 0 Then
                cSQL = "INSERT INTO reparacionesarticulos(idarticulo, fecha, idproveedor, averia"
                If Not String.IsNullOrWhiteSpace(txtDevolución.Text) Then cSQL += ", devolucion"
                cSQL += ") VALUES("
                cSQL += txtCódigo.Text + ", "
                cSQL += CtoD(txtFechaReparación.Text) + ", "
                cSQL += comboProveedorReparación.SelectedValue.ToString + ", "
                cSQL += GrabaComillas(txtAvería.Text)
                If Not String.IsNullOrWhiteSpace(txtDevolución.Text) Then cSQL += ", " + CtoD(txtDevolución.Text)
                cSQL += ")"
            Else
                cSQL = "UPDATE reparacionesarticulos SET "
                cSQL += "fecha = " + CtoD(txtFechaReparación.Text) + ", "
                cSQL += "idproveedor = " + comboProveedorReparación.SelectedValue.ToString + ", "
                cSQL += "averia = " + GrabaComillas(txtAvería.Text)
                If Not String.IsNullOrWhiteSpace(txtDevolución.Text) Then cSQL += ", devolucion = " + CtoD(txtDevolución.Text)
                cSQL += " WHERE idreparacion = " + nReparación.ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()

            lModificando = False
            RestauraPáginas()
            tabArtículos.SelectedTab = pageReparaciones
            ActivaBotonesReparaciones()
            DesactivaCamposReparaciones()
            CargaDatos()
            Return
        End If

        lModificando = True
        nReparación = 0
        tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
        tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
        ActivaCamposReparaciones()
        DesactivaBotonesReparaciones()
        txtFechaReparación.Focus()
    End Sub

    Private Sub BtnModificarReparación_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarReparación.Click
        If lModificando Then
            lModificando = False
            BorraCamposReparaciones()
            ActivaBotonesReparaciones()
            DesactivaCamposReparaciones()

            RestauraPáginas()
            tabArtículos.SelectedTab = pageReparaciones
        Else
            If nReparación = 0 Then
                MsgBox("Debe seleccionar una reparación", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
                Return
            End If

            lModificando = True
            tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
            tabArtículos.Controls.Remove(tabArtículos.TabPages(0))
            ActivaCamposReparaciones()
            DesactivaBotonesReparaciones()
            txtFechaReparación.Focus()
        End If
    End Sub

    Private Sub LvwReparaciones_Click(sender As Object, e As System.EventArgs) Handles lvwReparaciones.Click
        Dim dtTemporal As DataTable

        nReparación = Val(lvwReparaciones.SelectedItems(0).Text)

        dtTemporal = CargaTabla("SELECT * FROM reparacionesarticulos WHERE idreparacion = " + nReparación.ToString, connMySQL)
        txtFechaReparación.Text = Microsoft.VisualBasic.Left(dtTemporal.Rows(0)("fecha").ToString, 10)
        txtDevolución.Text = Microsoft.VisualBasic.Left(dtTemporal.Rows(0)("devolucion").ToString, 10)
        comboProveedorReparación.SelectedValue = dtTemporal.Rows(0)("idproveedor")
        txtAvería.Text = dtTemporal.Rows(0)("averia")
    End Sub

    Private Sub LvwReparaciones_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwReparaciones.DoubleClick
        BtnModificarReparación_Click(sender, e)
    End Sub

    Private Sub BtnEliminarReparación_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarReparación.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If nReparación = 0 Then
            MsgBox("Debe seleccionar una reparación", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If MsgBox("¿Está seguro de elimianr esta reparación?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM reparacionesarticulos WHERE idreparacion = " + nReparación.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
            End Try

            connMySQL.Close()
            nReparación = 0
            CargaDatos()
        End If
    End Sub

    Private Sub BtnFechaReparación_Click(sender As System.Object, e As System.EventArgs) Handles btnFechaReparación.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaReparación.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFechaDevolución_Click(sender As System.Object, e As System.EventArgs) Handles btnFechaDevolución.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtDevolución.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFechaMovimiento_Click(sender As System.Object, e As System.EventArgs) Handles btnFechaMovimiento.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaMovimiento.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub


    Private Sub BtnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Dim obj As New FrmRangoListadoArtículos
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        ListadoArtículos(obj.nudInicio.Value, obj.nudFin.Value)
    End Sub
End Class