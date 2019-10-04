#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmFormasPago
    Private connMySQL As MySqlConnection
    Private dtPagos As DataTable
    Private lModificando As Boolean = False
    Private nPago As Integer

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Empresas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        CargaPagos()
    End Sub

    Private Sub BorraCampos()
        txtCódigo.Text = ""
        txtNombre.Text = ""
        txtDíasPago.Text = "0"
        txtDíaPago.Text = "0"
        txtDescuento.Text = "0"
    End Sub

    Private Sub ActivaCampos()
        txtNombre.ReadOnly = False
        txtDíasPago.ReadOnly = False
        txtDíaPago.ReadOnly = False
        txtDescuento.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtNombre.ReadOnly = True
        txtDíasPago.ReadOnly = True
        txtDíaPago.ReadOnly = True
        txtDescuento.ReadOnly = True
    End Sub

    Private Sub ActivaBotones()
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"
        btnEliminar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Private Sub DesactivaBotones()
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnEliminar.Enabled = False
        btnSalir.Enabled = False
    End Sub

    Private Sub CargaPagos()
        dtPagos = CargaTabla("SELECT idformapago, nombre FROM formasdepago ORDER BY nombre", connMySQL)

        With dvPagos
            .ReadOnly = True
            .DataSource = dtPagos
            .DataMember = dtPagos.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersVisible = False

            With .Columns(0)
                .HeaderText = "Código"
                .Width = 0
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(1)
                .HeaderText = "Nombre"
                .Width = 200
            End With

            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End With
    End Sub

    Private Sub DvPagos_Click(sender As Object, e As System.EventArgs) Handles dvPagos.Click
        If lModificando Then Return

        nPago = Val(dvPagos.SelectedRows.Item(0).Cells(0).Value.ToString)
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM formasdepago WHERE idformapago = " + nPago.ToString, connMySQL)

        BorraCampos()

        If dtTemporal.Rows.Count > 0 Then
            txtCódigo.Text = dtTemporal.Rows(0)("idformapago").ToString
            txtNombre.Text = dtTemporal.Rows(0)("nombre")
            txtDíasPago.Text = dtTemporal.Rows(0)("dias")
            txtDíaPago.Text = dtTemporal.Rows(0)("diapago")
            txtDescuento.Text = Str(dtTemporal.Rows(0)("descuento"))
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtTemporal As DataTable

        If lModificando Then
            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                cSQL = "INSERT INTO formasdepago(nombre, dias, diapago, descuento) VALUES(" +
                       GrabaComillas(txtNombre.Text) + ", " +
                       txtDíasPago.Text + ", " +
                       txtDíaPago.Text + ", " +
                       txtDescuento.Text + ")"
            Else
                cSQL = "UPDATE formasdepago SET " +
                       "nombre = " + GrabaComillas(txtNombre.Text) + ", " +
                       "dias = " + txtDíasPago.Text + ", " +
                       "diapago = " + txtDíaPago.Text + ", " +
                       "descuento = " + txtDescuento.Text +
                       " WHERE idformapago = " + nPago.ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()

            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                cSQL = "SELECT idformapago FROM formasdepago ORDER BY idformapago DESC LIMIT 1"
                dtTemporal = CargaTabla(cSQL, connMySQL)
                nPago = dtTemporal.Rows(0)("idformapago")
            End If

            CargaPagos()
            CargaDatos()
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        lModificando = True
        nPago = 0
        ActivaCampos()
        DesactivaBotones()
        BorraCampos()
        txtNombre.Focus()
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If lModificando Then
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            CargaDatos()
        Else
            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then Return

            lModificando = True
            ActivaCampos()
            DesactivaBotones()
            txtNombre.Focus()
        End If
    End Sub

    Private Sub DvPagos_DoubleClick(sender As Object, e As System.EventArgs) Handles dvPagos.DoubleClick
        If Not lModificando Then BtnModificar_Click(sender, e)
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If String.IsNullOrWhiteSpace(txtCódigo.Text) Then Return
        If MsgBox("¿Está seguro de eliminar esta forma de pago?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        cSQL = "DELETE FROM formasdepago WHERE numpedido = " + txtCódigo.Text
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
        nPago = 0
    End Sub
End Class