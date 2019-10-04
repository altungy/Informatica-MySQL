#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmFacturaciónInterna
    Private connMySQL As MySqlConnection
    Private lModificando As Boolean = False
    Private lBuscando As Boolean = False
    Private dtCabecera, dtLíneas, dtArtículos, dtTiendas As DataTable
    Private nFactura As Integer = 0
    Private cFiltro As String

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmFacturaciónInterna_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        dtTiendas = CargaTabla("SELECT idtienda, nombre FROM tiendas WHERE estado = ""ABIERTA"" ORDER BY nombre", connMySQL)

        With comboTienda
            .DataSource = dtTiendas
            .DisplayMember = "nombre"
            .ValueMember = "idtienda"
        End With

        BorraCampos()
        CargaLíneas()
    End Sub

    Private Sub CargaLíneas()
        Dim cSQL As String = "SELECT idlinea, idfactura, linfacturainterna.idarticulo AS codigo, nombre, linfacturainterna.precio AS precio" +
            " FROM linfacturainterna, articulos WHERE  linfacturainterna.idarticulo = articulos.idarticulo AND idfactura = " + Trim(Str(Val(txtNúmero.Text)))

        dtLíneas = CargaTabla(cSQL, connMySQL)

        With dvLíneas
            .ReadOnly = True
            .DataSource = dtLíneas
            .DataMember = dtLíneas.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray

            For n = 0 To 2
                .Columns(n).Visible = False
            Next

            With .Columns(3)
                .HeaderText = "Artículo"
                .Width = 380
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(4)
                .HeaderText = "Precio"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With
    End Sub

    Private Sub MuestraDatos()
        Dim dtTemporal As DataTable
        Dim cSQL As String = "SELECT COUNT(*) AS registros FROM cabfacturainterna"

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        dtTemporal = CargaTabla(cSQL, connMySQL)

        If String.IsNullOrWhiteSpace(cFiltro) Then
            Me.Text = "Facturación interna V03/18 - " + dtTemporal.Rows(0)("registros").ToString
        Else
            Me.Text = "Facturación interna V03/18 [Filtro] - " + dtTemporal.Rows(0)("registros").ToString
        End If

        BorraCampos()
        dtCabecera = CargaTabla("SELECT * FROM cabfacturainterna WHERE idfactura = " + nFactura.ToString, connMySQL)

        If dtCabecera.Rows.Count > 0 Then
            txtNúmero.Text = dtCabecera.Rows(0)("idfactura")
            txtFecha.Text = Format(dtCabecera.Rows(0)("fecha"), "d")
            comboTienda.Text = NombreTienda(dtCabecera.Rows(0)("idtienda"))
        End If

        CargaLíneas()
    End Sub

    Private Sub BorraCampos()
        txtNúmero.Text = ""
        txtFecha.Text = ""
        comboTienda.Text = ""
    End Sub

    Private Sub ActivaBotones()
        btnPrimero.Enabled = True
        btnAnterior.Enabled = True
        btnSiguiente.Enabled = True
        btnÚltimo.Enabled = True
        btnNueva.Text = "&Nueva"
        btnModificar.Text = "&Modificar"
        btnBuscar.Enabled = True
        btnEliminar.Enabled = True
        btnListar.Enabled = True
        btnSalir.Enabled = True
        Me.ControlBox = True
        btnAgregar.Enabled = True
        btnModificarLínea.Enabled = True
        btnEliminarLínea.Enabled = True
    End Sub

    Private Sub DesactivaBotones()
        btnPrimero.Enabled = False
        btnAnterior.Enabled = False
        btnSiguiente.Enabled = False
        btnÚltimo.Enabled = False
        btnNueva.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnBuscar.Enabled = False
        btnEliminar.Enabled = False
        btnListar.Enabled = False
        btnSalir.Enabled = False
        Me.ControlBox = False
        btnAgregar.Enabled = False
        btnModificarLínea.Enabled = False
        btnEliminarLínea.Enabled = False
    End Sub

    Private Sub ActivaCampos()
        txtFecha.ReadOnly = False
        btnFecha.Enabled = True
    End Sub
    Private Sub DesactivaCampos()
        txtNúmero.ReadOnly = True
        txtFecha.ReadOnly = True
        btnFecha.Enabled = False
    End Sub

    Private Sub BtnPrimero_Click(sender As System.Object, e As System.EventArgs) Handles btnPrimero.Click
        Dim cSQL As String = "SELECT idfactura FROM cabfacturainterna ORDER BY idfactura ASC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)
        nFactura = dtCabecera.Rows(0)("idfactura")
        MuestraDatos()
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        Dim cSQL As String = "SELECT idfactura FROM cabfacturainterna WHERE idfactura < " + nFactura.ToString + " ORDER BY idfactura DESC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            BtnÚltimo_Click(sender, e)
        Else
            nFactura = dtCabecera.Rows(0)("idfactura")
            MuestraDatos()
        End If
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim cSQL As String = "SELECT idfactura FROM cabfacturainterna WHERE idfactura > " + nFactura.ToString + " ORDER BY idfactura ASC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            BtnPrimero_Click(sender, e)
        Else
            nFactura = dtCabecera.Rows(0)("idfactura")
            MuestraDatos()
        End If
    End Sub

    Private Sub BtnÚltimo_Click(sender As System.Object, e As System.EventArgs) Handles btnÚltimo.Click
        Dim cSQL As String = "SELECT idfactura FROM cabfacturainterna ORDER BY idfactura DESC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)
        nFactura = dtCabecera.Rows(0)("idfactura")
        MuestraDatos()
    End Sub

    Private Sub BtnFecha_Click(sender As System.Object, e As System.EventArgs) Handles btnFecha.Click
        Dim obj As New frmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFecha.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNueva.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtTemporal As DataTable

        If lBuscando Then
            cFiltro = ""
            If Not String.IsNullOrWhiteSpace(txtNúmero.Text) Then cFiltro += "idfactura = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtFecha.Text) Then cFiltro += "fecha = " + CtoD(txtFecha.Text) + " AND "
            If Not String.IsNullOrWhiteSpace(comboTienda.Text) Then cFiltro += "idtienda = " + comboTienda.SelectedValue.ToString + " AND "

            If Not String.IsNullOrWhiteSpace(cFiltro) Then cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
            cSQL = "SELECT * FROM cabfacturainterna"
            If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
            cSQL += " ORDER BY idfactura"
            dtTemporal = CargaTabla(cSQL, connMySQL)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("No hay registros en esas condiciones", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
                cFiltro = ""
                nFactura = 0
            Else
                nFactura = dtTemporal.Rows(0)("idfactura")
            End If

            MuestraDatos()
            DesactivaCampos()
            ActivaBotones()
            lBuscando = False
            Return
        End If

        If lModificando Then
            If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
                cSQL = "INSERT INTO cabfacturainterna(fecha, idtienda) VALUES("
                cSQL += CtoD(txtFecha.Text) + ", "
                cSQL += comboTienda.SelectedValue.ToString
                cSQL += ")"
            Else
                dtLíneas = CargaTabla("SELECT * FROM linfacturainterna WHERE idfactura = " + txtNúmero.Text, connMySQL)

                connMySQL.Open()

                For n = 0 To dtLíneas.Rows.Count - 1
                    If Not String.IsNullOrWhiteSpace(dtLíneas.Rows(n)("idarticulo")) Then
                        cSQL = "SELECT idmovimiento FROM movimientosarticulos WHERE idarticulo = " + dtLíneas.Rows(n)("idarticulo").ToString +
                            " AND idtienda = " + dtCabecera.Rows(0)("idtienda").ToString + " AND fecha = " + CtoD(dtCabecera.Rows(0)("fecha"))
                        dtTemporal = CargaTabla(cSQL, connMySQL)

                        If dtTemporal.Rows.Count > 0 Then
                            cSQL = "UPDATE movimientosarticulos SET "
                            cSQL += "idtienda = " + comboTienda.SelectedValue.ToString + ", "
                            cSQL += "fecha = " + CtoD(dtCabecera.Rows(0)("fecha"))
                            cSQL += " WHERE idmovimiento = " + dtTemporal.Rows(0)("idmovimiento")
                            cmd = New MySqlCommand(cSQL, connMySQL)

                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If
                    End If
                Next

                connMySQL.Close()

                cSQL = "UPDATE cabfacturainterna SET "
                cSQL += "fecha = " + CtoD(txtFecha.Text) + ", "
                cSQL += "idtienda = " + comboTienda.SelectedValue.ToString
                cSQL += " WHERE idfactura = " + txtNúmero.Text
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()

            If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
                BtnÚltimo_Click(sender, e)
            End If

            DesactivaCampos()
            ActivaBotones()
            lModificando = False
            Return
        End If

        lModificando = True
        BorraCampos()
        ActivaCampos()
        DesactivaBotones()
        txtFecha.Text = Format(Now, "d")
        txtFecha.Focus()
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If lBuscando Then
            BorraCampos()
            ActivaBotones()
            DesactivaCampos()
            lBuscando = False
            Return
        End If

        If lModificando Then
            ActivaBotones()
            DesactivaCampos()
            lModificando = False
            MuestraDatos()
            Return
        End If

        lModificando = True
        ActivaCampos()
        DesactivaBotones()
        txtFecha.Focus()
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lBuscando = True
        BorraCampos()
        ActivaCampos()
        txtNúmero.ReadOnly = False
        DesactivaBotones()
        txtNúmero.Focus()
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar esta factura?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM cabfacturainterna WHERE idfactura = " + txtNúmero.Text
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
            MuestraDatos()
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
            MsgBox("Debe tener una factura en pantalla", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        Dim obj As New frmLíneaFacturaInterna
        Dim nResultado As Integer

        obj.PassedText = ""
        nResultado = obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            CargaLíneas()
        End If

        obj.Dispose()
    End Sub

    Private Sub BtnModificarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarLínea.Click
        If dvLíneas.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una línea", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atención")
            Return
        End If

        Dim obj As New frmLíneaFacturaInterna
        Dim nResultado As Integer

        obj.PassedText = dvLíneas.SelectedRows.Item(0).Cells(0).Value.ToString
        nResultado = obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            CargaLíneas()
        End If

        obj.Dispose()
    End Sub

    Private Sub DvLíneas_DoubleClick(sender As Object, e As System.EventArgs) Handles dvLíneas.DoubleClick
        BtnModificarLínea_Click(sender, e)
    End Sub

    Private Sub BtnEliminarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarLínea.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar esta línea?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            connMySQL.Open()

            If dvLíneas.SelectedRows.Item(0).Cells(2).Value <> 0 Then
                cSQL = "DELETE FROM movimientosarticulos WHERE idarticulo = " + dvLíneas.SelectedRows.Item(0).Cells(2).Value.ToString +
                    " AND idtienda = " + comboTienda.SelectedValue.ToString + " AND fecha = " + CtoD(txtFecha.Text)
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            cSQL = "DELETE FROM linfacturainterna WHERE idlinea = " + dvLíneas.SelectedRows.Item(0).Cells(0).Value.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
            CargaLíneas()
        End If
    End Sub

    Private Sub BtnListar_Click(sender As System.Object, e As System.EventArgs) Handles btnListar.Click
        Dim obj As New frmRangoFechas
        Dim nResultado As Integer
        Dim cFiltro As String = ""
        Dim cSQL As String
        Dim dtTemporal As DataTable

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        If Not String.IsNullOrWhiteSpace(obj.txtInicio.Text) Then cFiltro += "fecha >= " + CtoD(obj.txtInicio.Text) + " AND "
        If Not String.IsNullOrWhiteSpace(obj.txtFin.Text) Then cFiltro += "fecha <= " + CtoD(obj.txtFin.Text) + " AND "

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
        cSQL = "SELECT COUNT(*) AS registros FROM cabfacturainterna"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        dtTemporal = CargaTabla(cSQL, connMySQL)

        If dtTemporal.Rows(0)("registros") = 0 Then
            MsgBox("No hay registros en este rango", MsgBoxStyle.Information, "Atención")
            Return
        End If

        ListadoFacturaciónInterna(obj.txtInicio.Text, obj.txtFin.Text)
    End Sub
End Class