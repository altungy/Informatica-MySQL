#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213
#Disable Warning IDE0069

Imports Microsoft.Data.Odbc
Public Class FrmAlbaranes
    Private lBuscando As Boolean = False
    Private conn As OdbcConnection
    Private dtAlbarán, dtRC As DataTable

    Private Sub Albaranes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New OdbcConnection
        'conn.ConnectionString = "DSN=deodbc;UID=rafael;Pwd=altungy;"""
        BorraCampos()
        ActivaBotones()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BorraCampos()
        txtAlbarán.Text = ""
        txtPacking.Text = ""
        lblFecha.Text = ""
        lblTipo.Text = ""
        lblEspera.Text = ""
        lblOrigen.Text = ""
        lblDestino.Text = ""
        lblValor.Text = ""
        lblValorFacturación.Text = ""
        dvRC.DataSource = Nothing
    End Sub

    Private Sub ActivaBotones()
        btnBuscar.Text = "&Buscar"
        btnEspera.Text = "&Espera"
        btnSalir.Enabled = True
        txtAlbarán.ReadOnly = True
        txtPacking.ReadOnly = True
        Me.CancelButton = btnSalir

        btnEspera.Enabled = (dvRC.Rows.Count = 0 And Not String.IsNullOrWhiteSpace(txtAlbarán.Text))
        btnEliminar.Enabled = (dvRC.Rows.Count > 0 And Not String.IsNullOrWhiteSpace(txtAlbarán.Text))
    End Sub

    Private Sub DesactivaBotones()
        btnEspera.Enabled = True
        btnEliminar.Enabled = False
        btnBuscar.Text = "&Aceptar"
        btnEspera.Text = "&Cancelar"
        btnEspera.Visible = True
        btnSalir.Enabled = False
        txtAlbarán.ReadOnly = False
        txtPacking.ReadOnly = False
        Me.CancelButton = btnEspera
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim cSQL As String

        If lBuscando Then
            lblAlbarán.Text = "Albarán"
            txtAlbarán.ReadOnly = True
            lblPacking.Visible = True
            txtPacking.Visible = True

            If String.IsNullOrEmpty(txtAlbarán.Text) And String.IsNullOrEmpty(txtPacking.Text) Then
                lBuscando = False
                ActivaBotones()
                Return
            End If

            If radioDécimas.Checked Then
                conn.ConnectionString = "DSN=deodbc"
            End If

            If radioPolinesia.Checked Then
                conn.ConnectionString = "DSN=polodbc"
            End If

            If radioAdidas.Checked Then
                conn.ConnectionString = "DSN=adodbc"
            End If

            conn.ConnectionString += ";UID=rafael;Pwd=altungy;"""

            cSQL = "SELECT albaran, albaran_prov, datos_almacen.tipo, procesado, fecha, text_origen, text_dest, valor, val_fact, nombre "
            cSQL += "FROM datos_almacen, tipos_movimientos WHERE datos_almacen.tipo = tipos_movimientos.tipo AND "

            Me.Cursor = Cursors.WaitCursor
            My.Application.DoEvents()
            dtAlbarán = CargaTabla(cSQL + "albaran_prov = " + GrabaComillas(txtAlbarán.Text) + "AND albaran LIKE ""TP%""", conn) ' Packing list

            If dtAlbarán.Rows.Count = 0 Then
                dtAlbarán = CargaTabla(cSQL + "albaran = " + GrabaComillas(txtAlbarán.Text), conn) ' TP
            End If

            Me.Cursor = Cursors.Arrow
            My.Application.DoEvents()

            If dtAlbarán.Rows.Count = 0 Then
                MsgBox("Albarán no encontrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                BorraCampos()
                lBuscando = False
                ActivaBotones()
                Return
            End If

            CargaDatos()
            ActivaBotones()
            lBuscando = False
        Else
            lblAlbarán.Text = "Número"
            txtAlbarán.ReadOnly = False
            lblPacking.Visible = False
            txtPacking.Visible = False
            lBuscando = True
            DesactivaBotones()
            BorraCampos()
            txtAlbarán.Focus()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim cSQL As String

        txtAlbarán.Text = dtAlbarán.Rows(0)("albaran").ToString
        txtPacking.Text = dtAlbarán.Rows(0)("albaran_prov").ToString
        lblTipo.Text = "(" + dtAlbarán.Rows(0)("tipo").ToString + ") " + dtAlbarán.Rows(0)("nombre").ToString
        lblEspera.Text = If(dtAlbarán.Rows(0)("procesado") = 0, "En espera", "Finalizado")
        lblFecha.Text = Format(dtAlbarán.Rows(0)("fecha"), "d")
        lblOrigen.Text = dtAlbarán.Rows(0)("text_origen").ToString
        lblDestino.Text = dtAlbarán.Rows(0)("text_dest").ToString
        lblValor.Text = FormatNumber(dtAlbarán.Rows(0)("valor"), 2, TriState.True, TriState.False, TriState.True)
        lblValorFacturación.Text = FormatNumber(dtAlbarán.Rows(0)("val_fact"), 2, TriState.True, TriState.False, TriState.True)

        cSQL = "SELECT albaran, fecha FROM traspasos WHERE pedido = " + GrabaComillas(txtAlbarán.Text)
        dtRC = CargaTabla(cSQL, conn)

        With dvRC
            .DataSource = dtRC
            .DataMember = dtRC.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            With .Columns(0)
                .HeaderText = "Albarán"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(1)
                .HeaderText = "Fecha"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End With
    End Sub

    Private Sub BtnEspera_Click(sender As Object, e As EventArgs) Handles btnEspera.Click
        Dim cSQL As String
        Dim cmd As OdbcCommand

        If lBuscando Then
            BorraCampos()
            lBuscando = False
            lblAlbarán.Text = "Albarán"
            txtAlbarán.Text = ""
            lblPacking.Visible = True
            txtPacking.Visible = True
            txtPacking.Text = ""
            ActivaBotones()
        Else
            If dvRC.Rows.Count = 0 Then
                If MsgBox("¿Está seguro de poner en espera este albarán?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

                Me.Cursor = Cursors.WaitCursor
                My.Application.DoEvents()
                cSQL = "UPDATE datos_almacen SET procesado = 0 WHERE albaran = " + GrabaComillas(Trim(txtAlbarán.Text))
                cmd = New OdbcCommand(cSQL, conn)
                conn.Open()

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Poner en espera albarán", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    If nResultado = DialogResult.Cancel Then Me.Close()
                End Try

                conn.Close()
                lBuscando = True
                BtnBuscar_Click(sender, e)
            Else
                MsgBox("Hay RCs", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As OdbcCommand
        Dim nTraspaso As Integer
        Dim dtTemp As DataTable

        If dvRC.SelectedRows.Count = 0 Then Return
        If MsgBox("¿Está seguro de borrar este RC?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        cSQL = "SELECT * FROM traspasos WHERE albaran = """ + dvRC.SelectedRows.Item(0).Cells(0).Value.ToString + """"
        dtTemp = CargaTabla(cSQL, conn)
        nTraspaso = dtTemp.Rows(0)("traspaso")

        cSQL = "DELETE FROM traspasos WHERE albaran = """ + dvRC.SelectedRows.Item(0).Cells(0).Value.ToString + """"
        cmd = New OdbcCommand(cSQL, conn)
        conn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Borrado albarán de traspasos", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        End Try

        cSQL = "DELETE FROM info_traspasos WHERE traspaso = " + nTraspaso.ToString
        cmd = New OdbcCommand(cSQL, conn)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Borrado de traspaso de info_traspasos", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        Finally
            cmd.Dispose()
        End Try

        conn.Close()
        CargaDatos()
        ActivaBotones()
        Me.Cursor = Cursors.Arrow
        My.Application.DoEvents()
    End Sub
End Class