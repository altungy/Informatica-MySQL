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

Public Class FrmProveedores
    Private connMySQL As MySqlConnection
    Private dtProveedores, dtPagos As DataTable
    Private nProveedor As Integer = 0
    Private lModificando As Boolean = False

    Private Sub FrmProveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        CargaProveedores()

        With dvProveedores
            .ReadOnly = True
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray


            With .Columns(0)
                .HeaderText = "Código"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(1)
                .HeaderText = "Nombre"
                .Width = 330
            End With

            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End With

        With lvwContactos
            '.Font = New System.Drawing.Font("Microsoft Sans Serif", 6, FontStyle.Regular)
            .Columns.Add("Código", 0, HorizontalAlignment.Left)
            .Columns.Add("Nombre", 200, HorizontalAlignment.Left)
            .Columns.Add("Teléfono", 100, HorizontalAlignment.Left)
            .Columns.Add("Correo", 230, HorizontalAlignment.Left)
        End With

        dtPagos = CargaTabla("SELECT * FROM formasdepago ORDER BY nombre", connMySQL)

        With comboFormaPago
            .DataSource = dtPagos
            .ValueMember = dtPagos.Columns(0).Caption.ToString
            .DisplayMember = dtPagos.Columns(1).Caption.ToString
        End With
    End Sub

    Private Sub CargaProveedores()
        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)

        With dvProveedores
            .DataSource = dtProveedores
            .DataMember = dtProveedores.TableName
        End With
    End Sub

    Private Sub PosicionaProveedores()
        Dim n As Integer

        For n = 0 To dvProveedores.Rows.Count - 1
            If dvProveedores.Rows.Item(n).Cells(0).Value = nProveedor Then Exit For
        Next

        dvProveedores.Rows(n).Selected = True
    End Sub

    Private Sub ActivaBotones()
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"
        btnEliminar.Enabled = True
        btnSalir.Enabled = True
        btnAgregarContacto.Enabled = True
        btnModificarContacto.Enabled = True
        btnEliminarContacto.Enabled = True
        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
        btnAgregarContacto.Enabled = False
        btnModificarContacto.Enabled = False
        btnEliminarContacto.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub DvProveedores_Click(sender As Object, e As System.EventArgs) Handles dvProveedores.Click
        nProveedor = Val(dvProveedores.SelectedRows.Item(0).Cells(0).Value.ToString)
        Cargadatos()
    End Sub

    Private Sub DvProveedores_DoubleClick(sender As Object, e As System.EventArgs) Handles dvProveedores.DoubleClick
        nProveedor = Val(dvProveedores.SelectedRows.Item(0).Cells(0).Value.ToString)
        btnModificar_Click(sender, e)
    End Sub

    Private Sub Cargadatos()
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM proveedores WHERE idproveedor = " + nProveedor.ToString, connMySQL)

        txtCódigo.Text = dtTemporal.Rows(0)("idproveedor").ToString
        txtCIF.Text = dtTemporal.Rows(0)("cif").ToString
        txtNombre.Text = dtTemporal.Rows(0)("nombre").ToString
        txtDirección.Text = dtTemporal.Rows(0)("direccion").ToString
        txtPostal.Text = dtTemporal.Rows(0)("postal").ToString
        txtPoblación.Text = dtTemporal.Rows(0)("poblacion").ToString
        txtProvincia.Text = dtTemporal.Rows(0)("provincia").ToString
        comboFormaPago.SelectedValue = dtTemporal.Rows(0)("idformapago")
        comboFormaPago.Text = NombrePago(dtTemporal.Rows(0)("idformapago"))
        txtDíasPago.Text = dtTemporal.Rows(0)("diaspago").ToString
        txtDíaPago.Text = dtTemporal.Rows(0)("diapago").ToString
        txtDescuento.Text = Str(dtTemporal.Rows(0)("descuento"))

        CargaContactos()
    End Sub

    Private Sub CargaContactos()
        Dim dtContactos As DataTable = CargaTabla("SELECT * FROM contactosproveedor WHERE idproveedor = " + txtCódigo.Text, connMySQL)

        lvwContactos.Items.Clear()

        For n = 0 To dtContactos.Rows.Count - 1
            Dim item As New ListViewItem(dtContactos.Rows(n)("idcontacto").ToString)

            item.SubItems.Add(dtContactos.Rows(n)("nombre"))
            item.SubItems.Add(dtContactos.Rows(n)("telefono"))
            item.SubItems.Add(dtContactos.Rows(n)("email"))

            lvwContactos.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtTemporal As DataTable

        If lModificando Then
            If nProveedor = 0 Then
                cSQL = "INSERT INTO proveedores(cif, nombre, direccion, postal, poblacion, provincia, diaspago, diapago, descuento, idformapago) VALUES("
                cSQL += GrabaComillas(txtCIF.Text) + ", "
                cSQL += GrabaComillas(txtNombre.Text) + ", "
                cSQL += GrabaComillas(txtDirección.Text) + ", "
                cSQL += GrabaComillas(txtPostal.Text) + ", "
                cSQL += GrabaComillas(txtPoblación.Text) + ", "
                cSQL += GrabaComillas(txtProvincia.Text) + ", "
                cSQL += txtDíasPago.Text + ", "
                cSQL += txtDíaPago.Text + ", "
                cSQL += txtDescuento.Text + ", "
                cSQL += comboFormaPago.SelectedValue.ToString + ")"
            Else
                cSQL = "UPDATE proveedores SET cif = " + GrabaComillas(txtCIF.Text) + ", "
                cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
                cSQL += "direccion = " + GrabaComillas(txtDirección.Text) + ", "
                cSQL += "postal = " + GrabaComillas(txtPostal.Text) + ", "
                cSQL += "poblacion = " + GrabaComillas(txtPoblación.Text) + ", "
                cSQL += "provincia = " + GrabaComillas(txtProvincia.Text) + ", "
                cSQL += "diaspago = " + txtDíasPago.Text + ", "
                cSQL += "diapago = " + txtDíaPago.Text + ", "
                cSQL += "descuento = " + txtDescuento.Text + ", "
                cSQL += "idformapago = " + comboFormaPago.SelectedValue.ToString
                cSQL += " WHERE idproveedor = " + nProveedor.ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
            CargaProveedores()

            If nProveedor = 0 Then
                dtTemporal = CargaTabla("SELECT idproveedor FROM proveedores ORDER BY idproveedor DESC LIMIT 1", connMySQL)
                nProveedor = dtTemporal.Rows(0)("idproveedor")
            End If

            PosicionaProveedores()
            lModificando = False
            DesactivaCampos()
            ActivaBotones()
            Cargadatos()
            Return
        End If

        nProveedor = 0
        BorraCampos()
        ActivaCampos()
        DesactivaBotones()
        lModificando = True
        txtCIF.Focus()
    End Sub

    Private Sub BorraCampos()
        txtCódigo.Text = ""
        txtCIF.Text = ""
        txtNombre.Text = ""
        txtDirección.Text = ""
        txtPostal.Text = ""
        txtPoblación.Text = ""
        txtProvincia.Text = ""
        comboFormaPago.Text = ""
        txtDíasPago.Text = "0"
        txtDíaPago.Text = "0"
        txtDescuento.Text = "0.00"

        lvwContactos.Items.Clear()
    End Sub

    Private Sub ActivaCampos()
        txtCIF.ReadOnly = False
        txtNombre.ReadOnly = False
        txtDirección.ReadOnly = False
        txtPostal.ReadOnly = False
        txtPoblación.ReadOnly = False
        txtProvincia.ReadOnly = False
        txtDíasPago.ReadOnly = False
        txtDíaPago.ReadOnly = False
        txtDescuento.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtCIF.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDirección.ReadOnly = True
        txtPostal.ReadOnly = True
        txtPoblación.ReadOnly = True
        txtProvincia.ReadOnly = True
        txtDíasPago.ReadOnly = True
        txtDíaPago.ReadOnly = True
        txtDescuento.ReadOnly = True
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If lModificando Then
            DesactivaCampos()
            ActivaBotones()
            lModificando = False
            Cargadatos()
            Return
        End If

        lModificando = True
        DesactivaBotones()
        ActivaCampos()
        txtCIF.Focus()
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar este proveedor?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM proveedores WHERE idproveedor = " + nProveedor.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
            CargaProveedores()
            txtNombre.Text = ""
            nProveedor = 0
        End If
    End Sub

    Private Sub TxtPostal_Leave(sender As Object, e As EventArgs) Handles txtPostal.Leave
        txtProvincia.Text = Provincia(txtPostal.Text)
    End Sub

    Private Sub BtnAgregarContacto_Click(sender As Object, e As EventArgs) Handles btnAgregarContacto.Click
        Dim cTexto As String
        Dim oVentana As New frmContactoProveedor

        cTexto = "-" + txtCódigo.Text
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        CargaContactos()
    End Sub

    Private Sub BtnModificarContacto_Click(sender As Object, e As EventArgs) Handles btnModificarContacto.Click
        Dim cTexto As String
        Dim oVentana As New frmContactoProveedor

        If lvwContactos.SelectedItems.Count = 0 Then Return

        cTexto = lvwContactos.SelectedItems(0).SubItems(0).Text
        oVentana.PassedText = cTexto
        oVentana.ShowDialog()
        CargaContactos()
    End Sub

    Private Sub LvwContactos_DoubleClick(sender As Object, e As EventArgs) Handles lvwContactos.DoubleClick
        BtnModificarContacto_Click(sender, e)
    End Sub

    Private Sub BtnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lvwContactos.SelectedItems.Count = 0 Then Return

        If MsgBox("¿Está seguro de eliminar este contacto?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM contactosproveedor WHERE idcontacto = " + lvwContactos.SelectedItems(0).SubItems(0).Text
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
            CargaContactos()
        End If
    End Sub

    Private Sub ComboFormaPago_LostFocus(sender As Object, e As EventArgs) Handles comboFormaPago.LostFocus
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM formasdepago WHERE idformapago = " + comboFormaPago.SelectedValue.ToString, connMySQL)

        If String.IsNullOrEmpty(txtDíasPago.Text) Then txtDíasPago.Text = dtTemporal.Rows(0)("dias").ToString
        If String.IsNullOrEmpty(txtDíaPago.Text) Then txtDíaPago.Text = dtTemporal.Rows(0)("diapago").ToString
        If String.IsNullOrEmpty(txtDescuento.Text) Then txtDescuento.Text = dtTemporal.Rows(0)("descuento").ToString
    End Sub
End Class