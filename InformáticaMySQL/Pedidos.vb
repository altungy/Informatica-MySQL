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

Imports MySql.Data.MySqlClient
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class FrmPedidos
    Private connMySQL As MySqlConnection
    Private dtEmpresas As DataTable
    Private nPedido As Integer = 0
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

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If Not lGrabado Then
            If MsgBox("Pedido sin grabar. ¿Desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return
        End If

        Me.Close()
    End Sub

    Private Sub FrmPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        dtEmpresas = CargaTabla("SELECT * FROM empresas ORDER BY nombre", connMySQL)

        With comboEmpresa
            .DataSource = dtEmpresas
            .ValueMember = dtEmpresas.Columns(0).Caption.ToString
            .DisplayMember = dtEmpresas.Columns(1).Caption.ToString
        End With

        With lvwLíneas
            .Columns.Add("Línea", 0, HorizontalAlignment.Right)
            .Columns.Add("Artículo", 215, HorizontalAlignment.Left)
            .Columns.Add("Cant.", 50, HorizontalAlignment.Right)
            .Columns.Add("Precio", 100, HorizontalAlignment.Right)
        End With

        With lvwCompras
            .Columns.Add("Número", 70, HorizontalAlignment.Right)
            .Columns.Add("Fecha", 80, HorizontalAlignment.Center)
            .Columns.Add("Proveedor", 215, HorizontalAlignment.Left)
        End With

        BorraCampos()
        ActivaBotones()
        DesactivaCampos()
    End Sub

    Private Sub BorraCampos()
        txtNúmero.Text = ""
        txtFecha.Text = ""
        comboEmpresa.Text = ""
        txtDepartamento.Text = ""
        txtPeticionario.Text = ""
        txtAprobado.Text = ""
        txtFechaAprobación.Text = ""
        txtReferencia.Text = ""
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
        btnFechaAprobación.Enabled = lModificando
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
        btnComprar.Enabled = lGrabado
        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        btnFecha.Enabled = True
        btnFechaAprobación.Enabled = True
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
        btnComprar.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub ActivaCampos()
        txtFecha.ReadOnly = False
        txtDepartamento.ReadOnly = False
        txtPeticionario.ReadOnly = False
        txtAprobado.ReadOnly = False
        txtFechaAprobación.ReadOnly = False
        txtReferencia.ReadOnly = False
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
        txtFecha.ReadOnly = True
        txtDepartamento.ReadOnly = True
        txtPeticionario.ReadOnly = True
        txtAprobado.ReadOnly = True
        txtFechaAprobación.ReadOnly = True
        txtReferencia.ReadOnly = True
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
        If nPedido = 0 Then Return

        Dim dtCabecera As DataTable = CargaTabla("SELECT * FROM cabpedido WHERE numpedido = " + nPedido.ToString, connMySQL)
        Dim dtLíneas As DataTable = CargaTabla("SELECT * FROM linpedido WHERE numpedido = " + nPedido.ToString + " ORDER BY idlinea", connMySQL)

        ReDim aLíneas(dtLíneas.Rows.Count - 1)

        If dtCabecera.Rows.Count = 0 Then Return

        nPedido = dtCabecera.Rows(0)("numpedido")
        txtNúmero.Text = dtCabecera.Rows(0)("numpedido").ToString
        txtFecha.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fecha").ToString, 10)
        comboEmpresa.SelectedValue = dtCabecera.Rows(0)("idempresa")
        comboEmpresa.Text = NombreEmpresa(dtCabecera.Rows(0)("idempresa"))
        txtDepartamento.Text = dtCabecera.Rows(0)("departamento").ToString
        txtPeticionario.Text = dtCabecera.Rows(0)("peticionario").ToString
        txtAprobado.Text = dtCabecera.Rows(0)("aprobado").ToString
        txtFechaAprobación.Text = Microsoft.VisualBasic.Left(dtCabecera.Rows(0)("fechaaprobacion").ToString, 10)
        txtReferencia.Text = dtCabecera.Rows(0)("referencia")
        txtObservaciones.Text = dtCabecera.Rows(0)("observaciones")
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
                Str(dtLíneas.Rows(n)("idproveedor")) + Chr(255)
        Next

        CargaLíneas()
        CargaCompras()
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

            lvwLíneas.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub CargaCompras()
        Dim dtCompras As DataTable = CargaTabla("SELECT * FROM cabcompra WHERE numpedido = " + nPedido.ToString, connMySQL)

        lvwCompras.Items.Clear()

        For n = 0 To dtCompras.Rows.Count - 1
            Dim item As New ListViewItem(dtCompras.Rows(n)("numcompra").ToString)

            item.SubItems.Add(Microsoft.VisualBasic.Left(dtCompras.Rows(n)("fecha").ToString, 10))
            item.SubItems.Add(NombreProveedor(dtCompras.Rows(n)("idproveedor")))

            lvwCompras.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub BtnPrimero_Click(sender As System.Object, e As System.EventArgs) Handles btnPrimero.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numpedido FROM cabpedido"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY numpedido ASC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        nPedido = dtCabecera.Rows(0)("numpedido")
        CargaDatos()
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numpedido FROM cabpedido WHERE numpedido < " + nPedido.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY numpedido DESC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            btnÚltimo_Click(sender, e)
        Else
            nPedido = dtCabecera.Rows(0)("numpedido")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numpedido FROM cabpedido WHERE numpedido > " + nPedido.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY numpedido ASC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            BtnPrimero_Click(sender, e)
        Else
            nPedido = dtCabecera.Rows(0)("numpedido")
            CargaDatos()
        End If
    End Sub

    Private Sub BtnÚltimo_Click(sender As System.Object, e As System.EventArgs) Handles btnÚltimo.Click
        Dim dtCabecera As DataTable
        Dim cSQL As String

        cSQL = "SELECT numpedido FROM cabpedido"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY numpedido DESC LIMIT 1"
        dtCabecera = CargaTabla(cSQL, connMySQL)

        nPedido = dtCabecera.Rows(0)("numpedido")
        CargaDatos()
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim cSQL As String
        Dim dtTemporal As DataTable

        If lfiltrando Then
            cFiltro = ""

            If Not String.IsNullOrWhiteSpace(txtNúmero.Text) Then cFiltro += "numpedido = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cFiltro += "fecha = " + CtoD(txtFecha.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(comboEmpresa.Text) Then cFiltro += "idempresa = " + comboEmpresa.SelectedValue.ToString + " AND "
            If Not String.IsNullOrWhiteSpace(txtDepartamento.Text) Then cFiltro += "departamento LIKE ""%" + StrConv(Trim(txtDepartamento.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtPeticionario.Text) Then cFiltro += "peticionario LIKE ""%" + StrConv(Trim(txtPeticionario.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtAprobado.Text) Then cFiltro += "aprobado LIKE ""%" + StrConv(Trim(txtAprobado.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtFechaAprobación.Text) Then cFiltro += "fechaaprobacion = " + CtoD(txtFechaAprobación.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(txtReferencia.Text) Then cFiltro += "referencia LIKE ""%" + StrConv(Trim(txtReferencia.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then cFiltro += "observaciones LIKE ""%" + StrConv(Trim(txtObservaciones.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtNombre.Text) Then cFiltro += "nombre LIKE ""%" + StrConv(Trim(txtNombre.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtDirección.Text) Then cFiltro += "direccion LIKE ""%" + StrConv(Trim(txtDirección.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtPostal.Text) Then cFiltro += "postal LIKE ""%" + StrConv(Trim(txtPostal.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtPoblación.Text) Then cFiltro += "poblacion LIKE ""%" + StrConv(Trim(txtPoblación.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtProvincia.Text) Then cFiltro += "provincia LIKE ""%" + StrConv(Trim(txtProvincia.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtContacto.Text) Then cFiltro += "contacto LIKE ""%" + StrConv(Trim(txtContacto.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtTeléfono.Text) Then cFiltro += "telefono LIKE ""%" + StrConv(Trim(txtTeléfono.Text), VbStrConv.Uppercase) + "%"" AND "

            If Not String.IsNullOrWhiteSpace(cFiltro) Then cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)

            cSQL = "SELECT * FROM cabpedido "
            If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += "WHERE " + cFiltro + " "
            cSQL += "ORDER BY numpedido"
            dtTemporal = CargaTabla(cSQL, connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("No hay registros en esas condiciones", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "")
                cFiltro = ""
                BorraCampos()
                Me.Text = "Pedidos V02/17"
            Else
                nPedido = dtTemporal.Rows(0)("numpedido")
                CargaDatos()
                Me.Text = "Pedidos V02/17 - Filtro[" + Trim(dtTemporal.Rows.Count.ToString) + "]"
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
                If MsgBox("Pedido sin grabar. ¿Desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return
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
            nPedido = 0
            ActivaCampos()
            DesactivaBotones()
            comboEmpresa.Focus()
        End If
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
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

    Private Sub ComboEmpresa_Leave(sender As Object, e As System.EventArgs) Handles comboEmpresa.Leave
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + comboEmpresa.SelectedValue.ToString, connMySQL)

            txtNombre.Text = dtTemporal.Rows(0)("nombre")
            txtDirección.Text = dtTemporal.Rows(0)("direccion")
            txtPostal.Text = dtTemporal.Rows(0)("postal")
            txtPoblación.Text = dtTemporal.Rows(0)("poblacion")
            txtProvincia.Text = dtTemporal.Rows(0)("provincia")
            txtContacto.Text = dtTemporal.Rows(0)("contacto")
            txtTeléfono.Text = dtTemporal.Rows(0)("telefono")
        End If
    End Sub

    Private Sub BtnAgregarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarLínea.Click
        Dim Obj As New FrmLíneaPedido
        Dim nResultado As Integer
        Dim n As Integer

        Obj.PassedText = "A"
        nResultado = Obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            n = aLíneas.GetLength(0)
            ReDim Preserve aLíneas(aLíneas.GetLength(0))

            aLíneas(n) = Obj.txtArtículo.Text + Chr(255) +
                Obj.txtCantidad.Text + Chr(255) +
                Obj.txtPrecio.Text + Chr(255) +
                Obj.comboProveedor.SelectedValue.ToString + Chr(255)
            lGrabado = False
            ActivaBotones()
        End If

        Obj.Dispose()
        CargaLíneas()
    End Sub

    Private Sub BtnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertarLínea.Click
        If lvwLíneas.SelectedItems.Count = 0 Then
            MsgBox("Debe seleccionar la línea sobre la que quiere insertar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        Dim nPosición As Integer = Val(lvwLíneas.SelectedItems(0).Text)
        Dim Obj As New FrmLíneaPedido
        Dim nResultado As Integer
        Dim n As Integer

        Obj.PassedText = "A"
        nResultado = Obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            n = aLíneas.GetLength(0)
            ReDim Preserve aLíneas(n)

            For m = n To nPosición + 1 Step -1
                aLíneas(m) = aLíneas(m - 1)
            Next

            aLíneas(nPosición) = Obj.txtArtículo.Text + Chr(255) +
                Obj.txtCantidad.Text + Chr(255) +
                Obj.txtPrecio.Text + Chr(255) +
                Obj.comboProveedor.SelectedValue.ToString + Chr(255)
            lGrabado = False
            ActivaBotones()
        End If

        Obj.Dispose()
        CargaLíneas()
    End Sub

    Private Sub BtnModificarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarLínea.Click
        If lvwLíneas.SelectedItems.Count = 0 Then
            MsgBox("Debe seleccionar la línea que quiere modificar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        Dim nPosición As Integer = Val(lvwLíneas.SelectedItems(0).Text)
        Dim Obj As New FrmLíneaPedido
        Dim nResultado As Integer

        Obj.PassedText = "M" + Chr(255) + aLíneas(Val(lvwLíneas.SelectedItems(0).Text))
        nResultado = Obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            aLíneas(nPosición) = Obj.txtArtículo.Text + Chr(255) +
                Obj.txtCantidad.Text + Chr(255) +
                Obj.txtPrecio.Text + Chr(255) +
                Obj.comboProveedor.SelectedValue.ToString() + Chr(255)
            lGrabado = False
            ActivaBotones()
        End If

        Obj.Dispose()
        CargaLíneas()
    End Sub

    Private Sub LvwLíneas_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwLíneas.DoubleClick
        If Not lModificando Then BtnModificarLínea_Click(sender, e)
    End Sub

    Private Sub BtnEliminarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarLínea.Click
        Dim nPosición, n As Integer

        If lvwLíneas.SelectedItems.Count = 0 Then
            MsgBox("Debe seleccionar la línea que quiere eliminar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If MsgBox("¿Está seguro de eliminar esta línea?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        If aLíneas.GetLength(0) = 1 Then
            ReDim aLíneas(0)
        Else
            nPosición = Val(lvwLíneas.SelectedItems(0).Text)

            For n = nPosición To aLíneas.GetLength(0) - 2
                aLíneas(n) = aLíneas(n + 1)
            Next

            n = Math.Max(aLíneas.GetLength(0) - 2, 0)
            ReDim Preserve aLíneas(n)
        End If

        lGrabado = False
        ActivaBotones()
        CargaLíneas()
    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtCabecera As DataTable
        Dim cLínea As String

        If nPedido = 0 Then
            cSQL = "INSERT INTO cabpedido(fecha, idempresa, departamento, peticionario, aprobado, "
            If Not String.IsNullOrEmpty(txtFechaAprobación.Text) Then cSQL += "fechaaprobacion, "
            cSQL += "referencia, nombre, direccion, postal, poblacion, provincia, contacto, telefono, observaciones) VALUES ("
            cSQL += CtoD(txtFecha.Text) + ", "
            cSQL += comboEmpresa.SelectedValue.ToString + ", "
            cSQL += GrabaComillas(txtDepartamento.Text) + ", "
            cSQL += GrabaComillas(txtPeticionario.Text) + ", "
            cSQL += GrabaComillas(txtAprobado.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaAprobación.Text) Then cSQL += CtoD(txtFechaAprobación.Text) + ", "
            cSQL += GrabaComillas(txtReferencia.Text) + ", "
            cSQL += GrabaComillas(txtNombre.Text) + ", "
            cSQL += GrabaComillas(txtDirección.Text) + ", "
            cSQL += GrabaComillas(txtPostal.Text) + ", "
            cSQL += GrabaComillas(txtPoblación.Text) + ", "
            cSQL += GrabaComillas(txtProvincia.Text) + ", "
            cSQL += GrabaComillas(txtContacto.Text) + ", "
            cSQL += GrabaComillas(txtTeléfono.Text) + ", "
            cSQL += GrabaComillas(txtObservaciones.Text) + ")"
        Else
            cSQL = "UPDATE cabpedido SET "
            cSQL += "fecha = " + CtoD(txtFecha.Text) + ", "
            cSQL += "idempresa = " + comboEmpresa.SelectedValue.ToString + ", "
            cSQL += "departamento = " + GrabaComillas(txtDepartamento.Text) + ", "
            cSQL += "peticionario = " + GrabaComillas(txtPeticionario.Text) + ", "
            cSQL += "aprobado = " + GrabaComillas(txtAprobado.Text) + ", "
            If Not String.IsNullOrEmpty(txtFechaAprobación.Text) Then cSQL += "fechaaprobacion= " + CtoD(txtFechaAprobación.Text) + ", "
            cSQL += "referencia = " + GrabaComillas(txtReferencia.Text) + ", "
            cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
            cSQL += "direccion = " + GrabaComillas(txtDirección.Text) + ", "
            cSQL += "postal = " + GrabaComillas(txtPostal.Text) + ", "
            cSQL += "poblacion = " + GrabaComillas(txtPoblación.Text) + ", "
            cSQL += "provincia = " + GrabaComillas(txtProvincia.Text) + ", "
            cSQL += "contacto = " + GrabaComillas(txtContacto.Text) + ", "
            cSQL += "telefono = " + GrabaComillas(txtTeléfono.Text) + ", "
            cSQL += "observaciones = " + GrabaComillas(txtObservaciones.Text)
            cSQL += " WHERE numpedido = " + nPedido.ToString
        End If

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        If nPedido = 0 Then
            dtCabecera = CargaTabla("SELECT numpedido FROM cabpedido ORDER BY numpedido DESC LIMIT 1", connMySQL)
            nPedido = dtCabecera.Rows(0)("numpedido")
        Else
            cSQL = "DELETE FROM linpedido WHERE numpedido = " + nPedido.ToString
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
                cSQL = "INSERT INTO linpedido(numpedido, articulo, cantidad, precio, idproveedor) VALUES("
                cSQL += nPedido.ToString + ", "
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

    Private Sub BtnFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnFecha.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFecha.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFechaAprobación_Click(sender As System.Object, e As System.EventArgs) Handles btnFechaAprobación.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFechaAprobación.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If String.IsNullOrWhiteSpace(txtNúmero.Text) Then Return
        If MsgBox("¿Está seguro de eliminar este pedido?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        cSQL = "DELETE FROM cabpedido WHERE numpedido = " + txtNúmero.Text
        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        connMySQL.Close()
        BorraCampos()
        nPedido = 0
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
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
        Dim nCantidad, nProveedor As Integer
        Dim nPrecio As Decimal
        Dim nTotal As Decimal = 0

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
        cTexto = "Nº pedido"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 38 - stringsize.Width, nLínea))
        cTexto = "Fecha"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 65 - stringsize.Width / 2, nLínea))
        gfx.DrawString("Referencia", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 95, nLínea))
        nLínea += 15
        cTexto = Trim(txtNúmero.Text)
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 38 - stringsize.Width, nLínea))
        cTexto = txtFecha.Text
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 65 - stringsize.Width / 2, nLínea))
        gfx.DrawString(txtReferencia.Text, fontTexto, XBrushes.Black, New XPoint(leftMargin + 95, nLínea))
        nLínea += 20

        gfx.DrawRectangle(Pens.Black, leftMargin, nLínea - 10, rightMargin - leftMargin, 15)
        gfx.DrawLine(Pens.Black, leftMargin + 60, nLínea - 10, leftMargin + 60, nLínea + 5)
        gfx.DrawString("Departamento", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        gfx.DrawString(txtDepartamento.Text, fontTexto, XBrushes.Black, New XPoint(leftMargin + 65, nLínea))
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
            nProveedor = Val(SacaDato(cLínea))

            If nLínea + aTexto.GetLength(0) * 10 + 90 > bottomMargin Then
                nPágina += 1
                Cabecera(gfx, dtEmpresa)
                CabeceraLíneas(gfx, topMargin + 50)
                nLínea = topMargin + 65
            End If

            gfx.DrawString(NombreProveedor(nProveedor), fontTexto, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
            gfx.DrawString(aTexto(0), fontTexto, XBrushes.Black, New XPoint(leftMargin + 200, nLínea))
            cTexto = FormatNumber(nCantidad, 0, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea))
            cTexto = FormatNumber(nPrecio, 2, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea))
            cTexto = FormatNumber(nCantidad * nPrecio, 2, TriState.True, TriState.False, TriState.True)
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
            nLínea += 10

            For m = 1 To aTexto.GetLength(0) - 1
                gfx.DrawString(aTexto(m), fontTexto, XBrushes.Black, New XPoint(leftMargin + 200, nLínea))
                nLínea += 10
            Next

            nTotal += nCantidad * nPrecio
        Next

        nLínea += 10

        cTexto = FormatNumber(nTotal, 2, TriState.True, TriState.False, TriState.True)
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        nLínea += 10
        gfx.DrawString("Total pedido", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))

        PiéPedido(gfx)

        document.Save(cDocumentos + "Pedido.pdf")
        Process.Start(cDocumentos + "Pedido.pdf")
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

        cTexto = "Pedido"
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

        gfx.DrawString("Proveedor", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        gfx.DrawString("Artículo", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 200, nLínea))
        cTexto = "Total"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea))
        cTexto = "Precio"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea))
        cTexto = "Cantidad"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea))

        'gfx.DrawString("ProveedorProveedorProveedorProveedorProveedorProve", fontTexto, XBrushes.Black, New XPoint(leftMargin + 5, nLínea + 10))
        'gfx.DrawString("ArtículoArtículoArtículoArtículoArtículoArtículoArtículoArtí", fontTexto, XBrushes.Black, New XPoint(leftMargin + 200, nLínea + 10))
        'cTexto = "999.999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 110 - stringsize.Width, nLínea + 10))
        'cTexto = "9.999.999,99"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 60 - stringsize.Width, nLínea + 10))
        'cTexto = "9.999.999,99"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea + 10))
    End Sub

    Private Sub PiéPedido(gfx As XGraphics)
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, XFontStyle.Bold)
        Dim nLínea As Integer

        nLínea = bottomMargin - 60
        gfx.DrawRectangle(Pens.Black, leftMargin, nLínea - 10, rightMargin - leftMargin, 70)
        gfx.DrawLine(Pens.Black, leftMargin + (rightMargin - leftMargin) / 2, nLínea - 10, leftMargin + (rightMargin - leftMargin) / 2, nLínea + 60)
        gfx.DrawString("Solicitado por " + txtPeticionario.Text, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 5, nLínea))
        gfx.DrawString("Aprobado por " + txtAprobado.Text, fontNegrita, XBrushes.Black, New XPoint(leftMargin + (rightMargin - leftMargin) / 2 + 5, nLínea))

        If Not String.IsNullOrEmpty(txtFechaAprobación.Text) Then
            stringsize = gfx.MeasureString(txtFechaAprobación.Text, fontTexto)
            gfx.DrawString(txtFechaAprobación.Text, fontTexto, XBrushes.Black, New XPoint(rightMargin - 5 - stringsize.Width, nLínea + 50))
        End If
    End Sub

    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        BorraCampos()
        ActivaCampos()
        txtNúmero.ReadOnly = False
        DesactivaBotones()
        lfiltrando = True
        txtNúmero.Focus()
    End Sub

    Private Sub BtnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        Dim dtCompras As DataTable = CargaTabla("SELECT * FROM cabcompra WHERE numpedido = " + txtNúmero.Text, connMySQL)
        Dim dtLíneas As DataTable = CargaTabla("SELECT * FROM linpedido WHERE numpedido = " + txtNúmero.Text + " AND idproveedor <> 0 ORDER BY idproveedor, idlinea", connMySQL)
        Dim dtProveedor, dtCabecera As DataTable
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nProveedor As Integer = 0
        Dim nCompra As Integer
        Dim nDescuento As Decimal = 0.0
        Dim nInicial As Integer = 0

        If dtCompras.Rows.Count > 0 Then
            MsgBox("Este pedido ya tiene órdenes de compra", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        If dtLíneas.Rows.Count = 0 Then
            MsgBox("Este pedido no tiene líneas asignadas a proveedor", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        connMySQL.Open()

        For n = 0 To dtLíneas.Rows.Count - 1
            If dtLíneas.Rows(n)("idproveedor") <> nProveedor Then
                dtProveedor = CargaTabla("SELECT * FROM proveedores WHERE idproveedor = " + dtLíneas.Rows(n)("idproveedor").ToString, connMySQL)
                nDescuento = dtProveedor.Rows(0)("descuento")

                cSQL = "INSERT INTO cabcompra(fecha, idempresa, numpedido, idproveedor, descuento, nombre, direccion, postal, poblacion, provincia, contacto, telefono) VALUES("
                cSQL += CtoD(Now) + ", "
                cSQL += comboEmpresa.SelectedValue.ToString + ", "
                cSQL += txtNúmero.Text + ", "
                cSQL += dtLíneas.Rows(n)("idproveedor").ToString + ", "
                cSQL += Str(nDescuento) + ", "
                cSQL += GrabaComillas(txtNombre.Text) + ", "
                cSQL += GrabaComillas(txtDirección.Text) + ", "
                cSQL += GrabaComillas(txtPostal.Text) + ", "
                cSQL += GrabaComillas(txtPoblación.Text) + ", "
                cSQL += GrabaComillas(txtProvincia.Text) + ", "
                cSQL += GrabaComillas(txtContacto.Text) + ", "
                cSQL += GrabaComillas(txtTeléfono.Text) + ")"

                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return
                End Try

                dtCabecera = CargaTabla("SELECT numcompra FROM cabcompra ORDER BY numcompra DESC LIMIT 1", connMySQL)
                nCompra = dtCabecera.Rows(0)("numcompra")
                nProveedor = dtLíneas.Rows(n)("idproveedor")

                If nInicial = 0 Then nInicial = nCompra
            End If

            cSQL = "INSERT INTO lincompra(numcompra, articulo, cantidad, precio, descuento) VALUES("
            cSQL += nCompra.ToString + ", "
            cSQL += GrabaComillas(dtLíneas.Rows(n)("articulo")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("cantidad")) + ", "
            cSQL += Str(dtLíneas.Rows(n)("precio")) + ", "
            cSQL += Str(nDescuento) + ")"

            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try

            cSQL = "UPDATE linpedido SET numcompra = " + nCompra.ToString + " WHERE idlinea = " + dtLíneas.Rows(n)("idlinea").ToString
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try
        Next

        MuestraForm(frmCompras, "Compras", "tpCompras", Str(nInicial), 13)
    End Sub


    Private Sub LvwCompras_DoubleClick(sender As Object, e As EventArgs) Handles lvwCompras.DoubleClick
        MuestraForm(frmCompras, "Compras", "tpCompras", Str(lvwCompras.SelectedItems(0).SubItems(0).Text), 13)
    End Sub
End Class