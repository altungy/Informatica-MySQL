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

Public Class FrmLíneaFacturaInterna
    Private _passedText As String
    Private connMySQL As MySqlConnection
    Private nLínea As Integer = 0
    Private dtLínea As DataTable

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub LíneaFacturaInterna_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cTexto As String = _passedText
        Dim dtProveedores, dtArtículos As DataTable

        connMySQL = New MySqlConnection(Conexión())
        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)
        dtArtículos = CargaTabla("SELECT * FROM articulos WHERE retirado = 0 ORDER BY nombre", connMySQL)

        With comboProveedor
            .DataSource = dtProveedores
            .DisplayMember = "nombre"
            .ValueMember = "idproveedor"
        End With

        With dvArtículos
            .ReadOnly = True
            .DataSource = dtArtículos
            .DataMember = dtArtículos.TableName
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
                .HeaderText = "Nº serie"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(2)
                .HeaderText = "Artículo"
                .Width = 380
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            For n = 3 To 9
                .Columns(n).Visible = False
            Next
        End With

        If String.IsNullOrWhiteSpace(cTexto) Then
            comboProveedor.Text = ""
        Else
            dtLínea = CargaTabla("SELECT * FROM linfacturainterna WHERE idlinea = " + cTexto, connMySQL)
            dtArtículos = CargaTabla("SELECT * FROM articulos WHERE idarticulo = " + dtLínea.Rows(0)("idarticulo").ToString, connMySQL)
            txtArtículo.Text = dtLínea.Rows(0)("idarticulo").ToString
            If dtArtículos.Rows.Count > 0 Then txtSerie.Text = dtArtículos.Rows(0)("serie")
            txtDescripción.Text = dtLínea.Rows(0)("descripcion")
            txtPrecio.Text = dtLínea.Rows(0)("precio").ToString
            comboProveedor.SelectedValue = dtLínea.Rows(0)("idproveedor")
            comboProveedor.Text = NombreProveedor(dtLínea.Rows(0)("idproveedor"))
            txtFactura.Text = dtLínea.Rows(0)("factura")
            If Not String.IsNullOrWhiteSpace(dtLínea.Rows(0)("fecha").ToString) Then txtFecha.Text = Format(dtLínea.Rows(0)("fecha"), "d")
            nLínea = Val(cTexto)
        End If

        txtArtículo.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nProveedor As Integer = 0

        If Not String.IsNullOrWhiteSpace(comboProveedor.Text) Then nProveedor = comboProveedor.SelectedValue

        connMySQL.Open()

        If nLínea = 0 Then
            cSQL = "INSERT INTO linfacturainterna(idfactura, idarticulo, descripcion, precio, idproveedor, factura"
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cSQL += ", fecha"
            cSQL += ") VALUES("
            cSQL += FrmFacturaciónInterna.txtNúmero.Text + ", "
            cSQL += Str(Val(txtArtículo.Text)) + ", "
            cSQL += GrabaComillas(txtDescripción.Text) + ", "
            cSQL += Str(Val(txtPrecio.Text)) + ", "
            cSQL += nProveedor.ToString + ", "
            cSQL += GrabaComillas(txtFactura.Text)
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cSQL += ", " + CtoD(txtFecha.Text)
            cSQL += ")"
        Else
            If dtLínea.Rows(0)("idarticulo") <> 0 Then
                cSQL = "DELETE FROM movimientosarticulos WHERE idarticulo = " + dtLínea.Rows(0)("idarticulo").ToString +
                    " AND idtienda = " + FrmFacturaciónInterna.comboTienda.SelectedValue.ToString + " AND fecha = " + CtoD(FrmFacturaciónInterna.txtFecha.Text)
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            cSQL = "UPDATE linfacturainterna SET "
            cSQL += "idfactura = " + FrmFacturaciónInterna.txtNúmero.Text + ", "
            cSQL += "idarticulo = " + Str(Val(txtArtículo.Text)) + ", "
            cSQL += "descripcion = " + GrabaComillas(txtDescripción.Text) + ", "
            cSQL += "precio = " + Str(Val(txtPrecio.Text)) + ", "
            cSQL += "idproveedor = " + nProveedor.ToString + ", "
            cSQL += "factura = " + GrabaComillas(txtFactura.Text)
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cSQL += ", fecha = " + CtoD(txtFecha.Text)
            cSQL += " WHERE idlinea = " + nLínea.ToString
        End If

        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not String.IsNullOrWhiteSpace(txtArtículo.Text) Then
            cSQL = "INSERT INTO movimientosarticulos(idarticulo, idtienda, fecha, usuario) VALUES(" +
                Str(Val(txtArtículo.Text)) + ", " +
                FrmFacturaciónInterna.comboTienda.SelectedValue.ToString + ", " +
                CtoD(FrmFacturaciónInterna.txtFecha.Text) + ", "" "")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        connMySQL.Close()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtArtículo_Leave(sender As Object, e As System.EventArgs) Handles txtArtículo.Leave
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM articulos WHERE idarticulo = " + Val(txtArtículo.Text).ToString, connMySQL)

        If dtTemporal.Rows.Count > 0 Then
            txtSerie.Text = dtTemporal.Rows(0)("serie")
            txtDescripción.Text = dtTemporal.Rows(0)("descripcion")
            If String.IsNullOrWhiteSpace(txtPrecio.Text) Then txtPrecio.Text = Str(dtTemporal.Rows(0)("precio"))
            comboProveedor.SelectedValue = dtTemporal.Rows(0)("idproveedor")
            comboProveedor.Text = NombreProveedor(dtTemporal.Rows(0)("idproveedor"))
            txtFactura.Text = dtTemporal.Rows(0)("factura")
            If Not String.IsNullOrWhiteSpace(dtTemporal.Rows(0)("compra").ToString) Then txtFecha.Text = Format(dtTemporal.Rows(0)("compra"), "d")
        End If
    End Sub

    Private Sub DvArtículos_DoubleClick(sender As Object, e As System.EventArgs) Handles dvArtículos.DoubleClick
        txtArtículo.Text = dvArtículos.SelectedRows.Item(0).Cells(0).Value.ToString
        TxtArtículo_Leave(sender, e)
    End Sub

    Private Sub TxtSerie_Leave(sender As Object, e As System.EventArgs) Handles txtSerie.Leave
        If String.IsNullOrWhiteSpace(txtArtículo.Text) Then
            Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM articulos WHERE serie = " + GrabaComillas(txtSerie.Text), connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("Nº de serie no registrado en artículos", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
            Else
                txtArtículo.Text = dtTemporal.Rows(0)("idarticulo")
                TxtArtículo_Leave(sender, e)
            End If
        End If
    End Sub
End Class