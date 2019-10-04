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
Imports System.IO
Imports System.Text

Public Class FrmPoblaciones
    Private connMySQL As MySqlConnection
    Private dtPoblaciones, dtProvincias As DataTable
    Private cFiltro As String = ""

    Private Sub FrmPoblaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        Carga()
        dtProvincias = CargaTabla("SELECT idprovincia, nombre FROM provincias ORDER BY nombre", connMySQL)

        With comboProvincia
            .DataSource = dtProvincias
            .ValueMember = "idprovincia"
            .DisplayMember = "nombre"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        ActivaBotones()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If btnSalir.Text = "&Salir" Then
            Me.Close()
        Else
            ActivaBotones()
        End If
    End Sub

    Private Sub Carga()
        Dim cSQL As String

        cSQL = "SELECT CONCAT(poblaciones.provincia, poblaciones.codigo) as ine, poblaciones.postal, "
        cSQL += "provincias.nombre AS nom_provincia, poblaciones.nombre AS poblacion, poblaciones.latitud, poblaciones.longitud "
        cSQL += "FROM poblaciones, provincias WHERE provincias.idprovincia = poblaciones.provincia "
        If Not String.IsNullOrWhiteSpace(cfiltro) Then csql += " AND " + cFiltro
        cSQL += " ORDER BY poblaciones.nombre"
        dtPoblaciones = CargaTabla(cSQL, connMySQL)

        If dtPoblaciones.Rows.Count = 0 Then
            MsgBox("No hay registros en esas condiciones", MsgBoxStyle.Critical, "Error")
            cFiltro = ""
            cSQL = "SELECT CONCAT(poblaciones.provincia, poblaciones.codigo) as ine, poblaciones.postal, "
            cSQL += "provincias.nombre AS nom_provincia, poblaciones.nombre, poblaciones.latitud, poblaciones.longitud "
            cSQL += "FROM poblaciones, provincias WHERE provincias.idprovincia = poblaciones.provincia ORDER BY nombre"
            dtPoblaciones = CargaTabla(cSQL, connMySQL)
        End If

        With dvPoblaciones
            .ReadOnly = True
            .DataSource = dtPoblaciones
            .DataMember = dtPoblaciones.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Font = New Font(dvPoblaciones.Font, FontStyle.Bold)
            .AllowUserToAddRows = False

            With .Columns(0)
                .HeaderText = "INE"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(1)
                .HeaderText = "Postal"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(2)
                .HeaderText = "Provincia"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(3)
                .HeaderText = "Población"
                .Width = 300
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Sort(.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
        End With
    End Sub

    Private Sub ActivaBotones()
        btnFiltrar.Text = "&Filtrar"
        btnSalir.Text = "&Salir"
        lblCP.Visible = False
        txtCP.Visible = False
        lblProvincia.Visible = False
        comboProvincia.Visible = False
        lblPoblación.Visible = False
        txtPoblación.Visible = False
    End Sub

    Private Sub DesactivaBotones()
        btnFiltrar.Text = "&Aceptar"
        btnSalir.Text = "&Cancelar"
        lblCP.Visible = True
        txtCP.Visible = True
        txtCP.Text = ""
        lblProvincia.Visible = True
        comboProvincia.Visible = True
        comboProvincia.Text = ""
        lblPoblación.Visible = True
        txtPoblación.Visible = True
        txtPoblación.Text = ""
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If btnFiltrar.Text = "&Filtrar" Then
            DesactivaBotones()
            txtCP.Focus()
        Else
            cFiltro = ""

            If Not String.IsNullOrEmpty(txtCP.Text) Then cFiltro = "postal LIKE " + GrabaComillas(Trim(txtCP.Text) + "%") + " AND "
            If Not String.IsNullOrEmpty(comboProvincia.Text) Then cFiltro += "provincia = " + GrabaComillas(comboProvincia.SelectedValue) + " AND "
            If Not String.IsNullOrEmpty(txtPoblación.Text) Then cFiltro += "poblaciones.nombre LIKE " + GrabaComillas("%" + Trim(txtPoblación.Text) + "%") + " AND "
            If Len(cFiltro) > 0 Then cFiltro = Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
            Carga()
            ActivaBotones()
        End If
    End Sub

    Private Sub TxtCP_Leave(sender As Object, e As EventArgs) Handles txtCP.Leave
        If Len(Trim(txtCP.Text)) > 1 Then
            For n = 0 To comboProvincia.Items.Count - 1
                comboProvincia.SelectedIndex = n
                If comboProvincia.SelectedValue = Microsoft.VisualBasic.Left(txtCP.Text, 2) Then Exit For
            Next
        Else
            comboProvincia.SelectedIndex = -1
        End If
    End Sub

    Private Sub TxtCP_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCP.KeyUp
        TxtCP_Leave(sender, e)
    End Sub

    Private Sub DvPoblaciones_DoubleClick(sender As Object, e As EventArgs) Handles dvPoblaciones.DoubleClick
        'Process.Start("http://maps.google.com/maps?q=" + Str(dvPoblaciones.SelectedRows(0).Cells(4).Value) + " " + Str(dvPoblaciones.SelectedRows(0).Cells(5).Value) + "&hl=es&t=h&z=17")
        Process.Start("http://maps.google.com/maps?q=" + dvPoblaciones.SelectedRows(0).Cells(1).Value + " " + dvPoblaciones.SelectedRows(0).Cells(3).Value + "&hl=es&t=h&z=17")
    End Sub
End Class