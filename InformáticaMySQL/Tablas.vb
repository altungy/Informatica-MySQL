#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1307
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2211
#Disable Warning CA2213
#Disable Warning CA5301

Imports MySql.Data.MySqlClient

Public Class FrmTablas
    Private _passedText As String
    Private dtTabla As DataTable
    Private cTabla As String
    Private cNombreAnterior As String

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmTablas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case _passedText
            Case "Empresas"
                cTabla = "empresas"

            Case "Rótulos"
                cTabla = "rotulos"

            Case "Estados"
                cTabla = "estados"

            Case "Merchants"
                cTabla = "merchants"
        End Select

        Me.Text = _passedText + " V06/17"
        CargaTablas()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaTablas()
        Dim cSQL As String = "SELECT * FROM " + cTabla + " ORDER BY nombre"
        dtTabla = CargaTabla(cSQL)

        With dvTabla
            .ReadOnly = True
            .DataSource = dtTabla
            .DataMember = dtTabla.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray

            With .Columns(0)
                .HeaderText = "Nombre"
                .Width = 300
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            .Sort(.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            .BringToFront()
        End With
    End Sub

    Private Sub ActivaBotones()
        btnAgregar.Text = "&Agregar"
        btnEliminar.Text = "&Eliminar"
        btnSalir.Visible = True
    End Sub

    Private Sub DesactivaBotones()
        btnAgregar.Text = "&Aceptar"
        btnEliminar.Text = "&Cancelar"
        btnSalir.Visible = False
    End Sub

    Private Sub DvTabla_DoubleClick(sender As Object, e As EventArgs) Handles dvTabla.DoubleClick
        dvTabla.Visible = False
        txtNombre.Text = dvTabla.SelectedRows.Item(0).Cells(0).Value.ToString()
        txtNombre.Focus()
        DesactivaBotones()
        cNombreAnterior = dvTabla.SelectedRows.Item(0).Cells(0).Value.ToString()
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If btnAgregar.Text = "&Aceptar" Then
            Dim cSQL As String
            Dim dtTemporal As DataTable
            Dim cmd As MySqlCommand
            Dim conn = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = Conexión()}

            dtTemporal = CargaTabla("SELECT * FROM " + cTabla + " WHERE nombre = " + GrabaComillas(cNombreAnterior))

            If dtTemporal.Rows.Count = 0 Or String.IsNullOrEmpty(cNombreAnterior) Then
                cSQL = "INSERT INTO " + cTabla + "(nombre) VALUES("
                cSQL += GrabaComillas(txtNombre.Text) + ")"
            Else
                cSQL = "UPDATE " + cTabla + " SET "
                cSQL += "nombre = " + GrabaComillas(txtNombre.Text)
                cSQL += " WHERE nombre = " + GrabaComillas(cNombreAnterior)
            End If

            cmd = New MySqlCommand(cSQL, conn)
            conn.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            conn.Close()

            ActivaBotones()
            dvTabla.Visible = True
            CargaTablas()
        Else
            txtNombre.Text = ""
            cNombreAnterior = ""
            dvTabla.Visible = False
            DesactivaBotones()
            txtNombre.Focus()
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If btnAgregar.Text = "&Aceptar" Then
            ActivaBotones()
            dvTabla.Visible = True
        Else
            If dvTabla.SelectedRows.Count = 0 Then Return
            If MsgBox("¿Está seguro de eliminar a este registro?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.SystemModal, "Atención") = MsgBoxResult.No Then Return

            Dim cSQL As String
            Dim cmd As MySqlCommand
            Dim conn = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = Conexión()}

            cSQL = "DELETE FROM " + cTabla + " WHERE nombre = " + GrabaComillas(dvTabla.SelectedRows.Item(0).Cells(0).Value.ToString())
            cmd = New MySqlCommand(cSQL, conn)
            conn.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            conn.Close()
            CargaTablas()
        End If
    End Sub
End Class