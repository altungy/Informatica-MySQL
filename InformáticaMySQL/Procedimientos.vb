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

'Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class FrmProcedimientos
    Private connMySQL As MySqlConnection
    Private dtCabecera, dtLíneas As DataTable
    Private nRegistro As Integer
    Private cFiltro As String = ""
    Private lModificando As Boolean = False
    Private lBuscando As Boolean = False

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

    Private Sub FrmProcedimientos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ls1.Y1 = btnAgregar.Location.Y + 34
        ls1.Y2 = btnAgregar.Location.Y + 34
        ls1.X2 = Me.Size.Width
        ls2.Y1 = btnAgregar.Location.Y + 39
        ls2.Y2 = btnAgregar.Location.Y + 39
        ls2.X2 = Me.Size.Width
        connMySQL = New MySqlConnection(Conexión())
        BorraCampos()
    End Sub

    Private Sub BorraCampos()
        txtNúmero.Text = ""
        txtNombre.Text = ""
        txtDescripción.Text = ""
    End Sub

    Private Sub ActivaCampos()
        txtNombre.ReadOnly = False
        txtDescripción.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtNúmero.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDescripción.ReadOnly = True
    End Sub

    Private Sub ActivaBotones()
        btnPrimero.Enabled = True
        btnSiguiente.Enabled = True
        btnAnterior.Enabled = True
        btnÚltimo.Enabled = True
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"
        btnBuscar.Enabled = True
        btnEliminar.Enabled = True
        btnImprimir.Enabled = True
        btnSalir.Enabled = True
        btnAgregarLínea.Enabled = True
        btnInsertarLínea.Enabled = True
        btnModificarLínea.Enabled = True
        btnEliminarLínea.Enabled = True
        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = False
        btnAnterior.Enabled = False
        btnÚltimo.Enabled = False
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnBuscar.Enabled = False
        btnEliminar.Enabled = False
        btnImprimir.Enabled = False
        btnSalir.Enabled = False
        btnAgregarLínea.Enabled = False
        btnInsertarLínea.Enabled = False
        btnModificarLínea.Enabled = False
        btnEliminarLínea.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub CargaLíneas()
        dtLíneas = CargaTabla("SELECT * FROM linprocedimiento WHERE idprocedimiento = " + Val(txtNúmero.Text).ToString + " ORDER BY orden", connMySQL)

        With dvLíneas
            .ReadOnly = True
            .DataSource = dtLíneas
            .DataMember = dtLíneas.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersVisible = False

            For n = 0 To 2
                .Columns(n).Visible = False
            Next

            With .Columns(3)
                .HeaderText = "Texto"
                .Width = 740
            End With
        End With
    End Sub

    Private Sub MuestraDatos()
        If String.IsNullOrWhiteSpace(cFiltro) Then
            Me.Text = "Procedimientos V07/12"
        Else
            Me.Text = "Procedimientos V07/12 [Filtro]"
        End If

        BorraCampos()

        txtNúmero.Text = dtCabecera.Rows(0)("idprocedimiento").ToString
        txtNombre.Text = dtCabecera.Rows(0)("nombre").ToString
        txtDescripción.Text = dtCabecera.Rows(0)("descripcion").ToString

        CargaLíneas()
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnPrimero_Click(sender As System.Object, e As System.EventArgs) Handles btnPrimero.Click
        Dim cSQL As String

        cSQL = "SELECT * FROM cabprocedimiento"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY idprocedimiento ASC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)
        nRegistro = dtCabecera.Rows(0)("idprocedimiento")
        MuestraDatos()
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        Dim cSQL As String

        cSQL = "SELECT * FROM cabprocedimiento WHERE idprocedimiento < " + nRegistro.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY idprocedimiento DESC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            cSQL = "SELECT * FROM cabprocedimiento"
            If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
            cSQL += " ORDER BY idprocedimiento DESC LIMIT 1"
            dtCabecera = CargaTabla(cSQL, connMySQL)
        End If

        nRegistro = dtCabecera.Rows(0)("idprocedimiento")
        MuestraDatos()
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim cSQL As String

        cSQL = "SELECT * FROM cabprocedimiento WHERE idprocedimiento > " + nRegistro.ToString
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " AND " + cFiltro
        cSQL += " ORDER BY idprocedimiento ASC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)

        If dtCabecera.Rows.Count = 0 Then
            cSQL = "SELECT * FROM cabprocedimiento"
            If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
            cSQL += " ORDER BY idprocedimiento ASC LIMIT 1"
            dtCabecera = CargaTabla(cSQL, connMySQL)
        End If

        nRegistro = dtCabecera.Rows(0)("idprocedimiento")
        MuestraDatos()
    End Sub

    Private Sub BtnÚltimo_Click(sender As System.Object, e As System.EventArgs) Handles btnÚltimo.Click
        Dim cSQL As String

        cSQL = "SELECT * FROM cabprocedimiento"
        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + cFiltro
        cSQL += " ORDER BY idprocedimiento DESC LIMIT 1"

        dtCabecera = CargaTabla(cSQL, connMySQL)
        nRegistro = dtCabecera.Rows(0)("idprocedimiento")
        MuestraDatos()
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If lModificando Then
            If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
                cSQL = "INSERT INTO cabprocedimiento(nombre, descripcion) VALUES("
                cSQL += GrabaComillas(txtNombre.Text) + ", "
                cSQL += GrabaComillas(txtDescripción.Text) + ")"
            Else
                cSQL = "UPDATE cabprocedimiento SET "
                cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
                cSQL += "descripcion = " + GrabaComillas(txtDescripción.Text)
                cSQL += "WHERE idprocedimiento = " + Trim(txtNúmero.Text)
            End If

            connMySQL.Open()

            Try
                cmd = New MySqlCommand(cSQL, connMySQL)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()

            ActivaBotones()
            DesactivaCampos()

            If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
                cSQL = "SELECT * from cabprocedimiento ORDER BY idprocedimiento DESC LIMIT 1"
            Else
                cSQL = "SELECT * FROM cabprocedimiento WHERE idprocedimiento = " + Trim(txtNúmero.Text)
            End If

            dtCabecera = CargaTabla(cSQL, connMySQL)
            nRegistro = dtCabecera.Rows(0)("idprocedimiento")
            MuestraDatos()
            lModificando = False
            Return
        End If

        If lBuscando Then
            cFiltro = ""
            If Not String.IsNullOrWhiteSpace(txtNúmero.Text) Then cFiltro += "idprocedimiento = " + txtNúmero.Text + " AND "
            If Not String.IsNullOrWhiteSpace(txtNombre.Text) Then cFiltro += "UCASE(nombre) LIKE ""%" + StrConv(Trim(txtNombre.Text), VbStrConv.Uppercase) + "%"" AND "
            If Not String.IsNullOrWhiteSpace(txtDescripción.Text) Then cFiltro += "UCASE(descripcion) LIKE ""%" + StrConv(Trim(txtDescripción.Text), VbStrConv.Uppercase) + "%"" AND "

            If String.IsNullOrWhiteSpace(cFiltro) Then
                dtCabecera = CargaTabla("SELECT * FROM cabprocedimiento ORDER BY idprocedimiento", connMySQL)
            Else
                cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
                cSQL = "SELECT * FROM cabprocedimiento WHERE " + cFiltro + " ORDER BY idprocedimiento ASC LIMIT 1"
                dtCabecera = CargaTabla(cSQL, connMySQL)

                If dtCabecera.Rows.Count = 0 Then
                    MsgBox("No hay registros en esas condiciones")
                    cFiltro = ""
                    dtCabecera = CargaTabla("SELECT * FROM cabprocedimiento ORDER BY idprocedimiento ASC LIMIT 1", connMySQL)
                End If
            End If

            nRegistro = dtCabecera.Rows(0)("idprocedimiento")
            lBuscando = False
            ActivaBotones()
            DesactivaCampos()
            MuestraDatos()
            Return
        End If

        BorraCampos()
        lModificando = True
        ActivaCampos()
        DesactivaBotones()
        txtNombre.Focus()
    End Sub

    Private Sub BtnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        If lModificando Then
            If String.IsNullOrWhiteSpace(txtNúmero.Text) Then
                BorraCampos()
            Else
                MuestraDatos()
            End If

            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        If lBuscando Then
            lBuscando = False
            BorraCampos()
            nRegistro = 0
            CargaLíneas()
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        lModificando = True
        ActivaCampos()
        DesactivaBotones()
        txtNombre.Focus()
    End Sub

    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lBuscando = True
        ActivaCampos()
        txtNúmero.ReadOnly = False
        DesactivaBotones()
        BorraCampos()
        CargaLíneas()
        Me.AcceptButton = btnAgregar
        Me.CancelButton = btnModificar
        txtNúmero.Focus()
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar este procedimiento?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "") = MsgBoxResult.Yes Then
            connMySQL.Open()
            cSQL = "DELETE FROM cabprocedimiento WHERE idprocedimiento = " + txtNúmero.Text
            cmd = New MySqlCommand(cSQL, connMySQL)
            cmd.ExecuteNonQuery()
            connMySQL.Close()
            BorraCampos()
        End If
    End Sub

    Private Sub BtnAgregarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarLínea.Click
        Dim obj As New FrmLínea
        Dim nResultado As Integer

        obj.PassedText = "A" + txtNúmero.Text.PadLeft(6) + Space(12)
        nResultado = obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            CargaLíneas()
        End If

        obj.Dispose()
    End Sub

    Private Sub BtnInsertarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertarLínea.Click
        If dvLíneas.SelectedRows.Count = 0 Then Return

        Dim obj As New FrmLínea
        Dim nResultado As Integer

        obj.PassedText = "I" + txtNúmero.Text.PadLeft(6) + Space(6) + dvLíneas.SelectedRows.Item(0).Cells(2).Value.ToString.PadLeft(6)
        nResultado = obj.ShowDialog(Me)

        If nResultado = DialogResult.OK Then
            CargaLíneas()
        End If

        obj.Dispose()
    End Sub

    Private Sub BtnModificarLínea_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarLínea.Click
        Dim obj As New FrmLínea
        Dim nResultado As Integer

        If dvLíneas.SelectedRows.Count = 0 Then Return

        obj.PassedText = "M" + txtNúmero.Text.PadLeft(6) + dvLíneas.SelectedRows.Item(0).Cells(0).Value.ToString.PadLeft(6) + Space(6)
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
        Dim nOrden As Integer = 1

        If dvLíneas.SelectedRows.Count = 0 Then Return

        If MsgBox("¿Está seguro de eliminar esta línea?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM linprocedimiento WHERE idlinea = " + dvLíneas.SelectedRows.Item(0).Cells(0).Value.ToString

            connMySQL.Open()
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtLíneas = CargaTabla("SELECT * FROM linprocedimiento WHERE idprocedimiento = " + txtNúmero.Text + " ORDER BY orden", connMySQL)

            For n = 0 To dtLíneas.Rows.Count - 1
                cSQL = "UPDATE linprocedimiento SET " +
                    "orden = " + nOrden.ToString +
                    " WHERE idlinea = " + dtLíneas.Rows(n)("idlinea").ToString
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                nOrden += 1
            Next

            connMySQL.Close()
            CargaLíneas()
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim document As PdfDocument = New PdfDocument
        Dim page As PdfPage = document.AddPage
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 11)
        Dim fontNegrita As XFont = New XFont("Calibri", 11, FontStyle.Bold)
        Dim cTexto As String
        Dim aTexto() As String = New String() {}
        Dim nLínea As Integer
        Dim cDocumentos As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"

        page.Size = PageSize.A4
        page.Orientation = PageOrientation.Portrait
        pageCenter = page.Width.Point / 2
        topMargin = 25
        leftMargin = 25
        bottomMargin = page.Height.Point - 25
        rightMargin = page.Width.Point - 25
        pageWidth = page.Width.Point / 2

        nPágina = 1
        Cabecera(gfx)
        gfx.DrawString("Descripción", fontNegrita, XBrushes.Black, New XPoint(leftMargin, topMargin + 70))
        aTexto = Memo2Array(txtDescripción.Text, 100)
        nLínea = 70

        For n = 0 To aTexto.GetLength(0) - 1
            gfx.DrawString(aTexto(n), fontTexto, XBrushes.Black, New XPoint(leftMargin + 60, topMargin + nLínea))
            nLínea += 12
        Next

        nLínea += 24
        cTexto = "Pasos"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + nLínea))
        nLínea += 20

        For n = 0 To dvLíneas.Rows.Count - 2
            aTexto = Memo2Array(dvLíneas.Rows(n).Cells(3).Value.ToString, 100)

            If aTexto.GetLength(0) * 12 + topMargin + nLínea > bottomMargin - 40 Then
                page = document.AddPage
                page.Size = PageSize.A4
                page.Orientation = PageOrientation.Portrait
                gfx = XGraphics.FromPdfPage(page)
                nPágina += 1
                Cabecera(gfx)
                nLínea = 70
            End If

            cTexto = Trim((n + 1).ToString) + ".-"
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 20 - stringsize.Width, topMargin + nLínea))
            aTexto = Memo2Array(dvLíneas.Rows(n).Cells(3).Value.ToString, 110)

            For m = 0 To aTexto.GetLength(0) - 1
                gfx.DrawString(aTexto(m), fontTexto, XBrushes.Black, New XPoint(leftMargin + 25, topMargin + nLínea))
                nLínea += 12
            Next

            nLínea += 3
        Next

        document.Save(cDocumentos + "Procedimiento.pdf")
        Process.Start(cDocumentos + "Procedimiento.pdf")
    End Sub

    Private Sub Cabecera(gfx As XGraphics)
        Dim imagen As Bitmap = Image.FromFile("\\decimas2018\Departamentos\Informatica\Software\Recursos\SportStreet.jpg")
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTítulo As XFont = New XFont("Calibri", 14, XFontStyle.Bold)
        Dim fontTexto As XFont = New XFont("Calibri", 11)

        gfx.DrawImage(imagen, leftMargin, topMargin, 100, 16)
        cTexto = txtNombre.Text
        stringsize = gfx.MeasureString(cTexto, fontTítulo)
        gfx.DrawString(cTexto, fontTítulo, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + 40))

        cTexto = "- " + Trim(nPágina.ToString) + " -"
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, bottomMargin - 10))
    End Sub

    Private Sub DvLíneas_Click(sender As Object, e As EventArgs) Handles dvLíneas.Click
        txtLínea.Text = dvLíneas.SelectedRows.Item(0).Cells(3).Value.ToString
    End Sub
End Class
