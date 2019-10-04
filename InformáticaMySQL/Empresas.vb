#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmEmpresas
    Private connMySQL As MySqlConnection
    Private dtEmpresas As DataTable
    Private lModificando As Boolean = False
    Private nEmpresa As Integer

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Empresas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        CargaEmpresas()
    End Sub

    Private Sub BorraCampos()
        txtCódigo.Text = ""
        txtCIF.Text = ""
        txtNombre.Text = ""
        txtDirección.Text = ""
        txtPostal.Text = ""
        txtPoblación.Text = ""
        txtProvincia.Text = ""
        txtContacto.Text = ""
        txtTeléfono.Text = ""
        txtODBC.Text = ""
    End Sub

    Private Sub ActivaCampos()
        txtCIF.ReadOnly = False
        txtNombre.ReadOnly = False
        txtDirección.ReadOnly = False
        txtPostal.ReadOnly = False
        txtPoblación.ReadOnly = False
        txtProvincia.ReadOnly = False
        txtContacto.ReadOnly = False
        txtTeléfono.ReadOnly = False
        txtODBC.ReadOnly = False
    End Sub

    Private Sub DesactivaCampos()
        txtCódigo.ReadOnly = True
        txtCIF.ReadOnly = True
        txtNombre.ReadOnly = True
        txtDirección.ReadOnly = True
        txtPostal.ReadOnly = True
        txtPoblación.ReadOnly = True
        txtProvincia.ReadOnly = True
        txtContacto.ReadOnly = True
        txtTeléfono.ReadOnly = True
        txtODBC.ReadOnly = True
    End Sub

    Private Sub ActivaBotones()
        btnAgregar.Text = "&Agregar"
        btnModificar.Text = "&Modificar"
        btnSalir.Enabled = True
        Me.ControlBox = True
    End Sub

    Private Sub DesactivaBotones()
        btnAgregar.Text = "&Aceptar"
        btnModificar.Text = "&Cancelar"
        btnSalir.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub CargaEmpresas()
        dtEmpresas = CargaTabla("SELECT idempresa, nombre FROM empresas ORDER BY nombre", connMySQL)

        With dvEmpresas
            .ReadOnly = True
            .DataSource = dtEmpresas
            .DataMember = dtEmpresas.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray

            With .Columns(0)
                .HeaderText = "Código"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(1)
                .HeaderText = "Nombre"
                .Width = 200
            End With

            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End With
    End Sub

    Private Sub DvEmpresas_Click(sender As Object, e As System.EventArgs) Handles dvEmpresas.Click
        If lModificando Then Return

        nEmpresa = Val(dvEmpresas.SelectedRows.Item(0).Cells(0).Value.ToString)
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + nEmpresa.ToString, connMySQL)

        BorraCampos()

        If dtTemporal.Rows.Count > 0 Then
            txtCódigo.Text = dtTemporal.Rows(0)("idempresa").ToString
            txtCIF.Text = dtTemporal.Rows(0)("cif")
            txtNombre.Text = dtTemporal.Rows(0)("nombre")
            txtDirección.Text = dtTemporal.Rows(0)("direccion").ToString
            txtPostal.Text = dtTemporal.Rows(0)("postal")
            txtPoblación.Text = dtTemporal.Rows(0)("poblacion")
            txtProvincia.Text = dtTemporal.Rows(0)("provincia")
            txtContacto.Text = dtTemporal.Rows(0)("contacto")
            txtTeléfono.Text = dtTemporal.Rows(0)("telefono")
            txtODBC.Text = dtTemporal.Rows(0)("odbc")

            If IsDBNull(dtTemporal.Rows(0)("logo")) Then
                picLogo.Image = Nothing
            Else
                Dim lb() As Byte = dtTemporal.Rows(0)("logo")
                Dim lstr As New System.IO.MemoryStream(lb)
                picLogo.Image = Image.FromStream(lstr)
                lstr.Close()
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtTemporal As DataTable

        If lModificando Then
            If String.IsNullOrWhiteSpace(txtCódigo.Text) Then
                cSQL = "INSERT INTO empresas(nombre, direccion, postal, poblacion, provincia, cif, contacto, telefono, odbc) VALUES(" +
                       GrabaComillas(txtNombre.Text) + ", " +
                       GrabaComillas(txtDirección.Text) + ", " +
                       GrabaComillas(txtPostal.Text) + ", " +
                       GrabaComillas(txtPoblación.Text) + ", " +
                       GrabaComillas(txtProvincia.Text) + ", " +
                       GrabaComillas(txtCIF.Text) + ", " +
                       GrabaComillas(txtContacto.Text) + ", " +
                       GrabaComillas(txtODBC.Text) + ", " +
                       GrabaComillas(txtTeléfono.Text) + ")"
            Else
                cSQL = "UPDATE empresas SET " +
                       "nombre = " + GrabaComillas(txtNombre.Text) + ", " +
                       "direccion = " + GrabaComillas(txtDirección.Text) + ", " +
                       "postal = " + GrabaComillas(txtPostal.Text) + ", " +
                       "poblacion = " + GrabaComillas(txtPoblación.Text) + ", " +
                       "provincia = " + GrabaComillas(txtProvincia.Text) + ", " +
                       "cif = " + GrabaComillas(txtCIF.Text) + ", " +
                       "contacto = " + GrabaComillas(txtContacto.Text) + ", " +
                       "telefono = " + GrabaComillas(txtTeléfono.Text) + ", " +
                       "odbc = " + GrabaComillas(txtODBC.Text) +
                       "WHERE idempresa = " + nEmpresa.ToString
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
                cSQL = "SELECT TOP 1 idempresa FROM empresas ORDER BY idempresa DESC"
                dtTemporal = CargaTabla(cSQL, connMySQL)
                nEmpresa = dtTemporal.Rows(0)("idempresa")
            End If

            CargaEmpresas()
            CargaDatos()
            lModificando = False
            ActivaBotones()
            DesactivaCampos()
            Return
        End If

        lModificando = True
        nEmpresa = 0
        ActivaCampos()
        DesactivaBotones()
        BorraCampos()
        txtCIF.Focus()
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
            txtCIF.Focus()
        End If
    End Sub

    Private Sub TxtPostal_Leave(sender As Object, e As System.EventArgs) Handles txtPostal.Leave
        If String.IsNullOrWhiteSpace(txtProvincia.Text) Then
            txtProvincia.Text = Provincia(txtPostal.Text)
        End If
    End Sub

    Private Sub DvEmpresas_DoubleClick(sender As Object, e As System.EventArgs) Handles dvEmpresas.DoubleClick
        If Not lModificando Then BtnModificar_Click(sender, e)
    End Sub

    Private Sub PicLogo_DoubleClick(sender As Object, e As EventArgs) Handles picLogo.DoubleClick
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim bytImage() As Byte

        fd.Title = "Seleccionar logotipo"
        fd.InitialDirectory = "C:\"
        fd.Filter = "JPG (*.jpg)|*.jpg|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|Todoso los ficheros (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = False

        If fd.ShowDialog() = DialogResult.OK Then
            picLogo.Image = Image.FromFile(fd.FileName)
            Dim ms As New System.IO.MemoryStream
            Dim bmpImage As New Bitmap(picLogo.Image)

            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            bytImage = ms.ToArray()
            ms.Close()

            'cSQL = "UPDATE empresas SET  logo=@emPic WHERE idempresa = " + nEmpresa.ToString
            'cmd = New MySqlCommand(cSQL, connMySQL)
            'cmd.Parameters.AddWithValue("@emPic", bytImage)

            cSQL = "UPDATE empresas SET logo = ?foto WHERE idempresa = " + nEmpresa.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            cmd.Parameters.AddWithValue("?foto", bytImage)

            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
        End If
    End Sub
End Class