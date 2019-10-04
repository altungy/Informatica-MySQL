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

Public Class frmOperadores
    Private dtOperadores

    Private Sub Operadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaOperadores()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CargaOperadores()
        Dim cSQL As String = "SELECT * FROM operadores ORDER BY nombre"
        dtOperadores = CargaTabla(cSQL)

        With dvOperadores
            .ReadOnly = True
            .DataSource = dtOperadores
            .DataMember = dtOperadores.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
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
                .Width = 300
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With .Columns(2)
                .HeaderText = "Ext."
                .Width = 45
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(3)
                .HeaderText = "e-mail"
                .Width = 300
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            For n = 4 To 11
                .Columns(n).Visible = False
            Next

            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End With
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim oVentana As New frmOperador With {.PassedText = "0"}
        oVentana.ShowDialog()
        CargaOperadores()
    End Sub

    Private Sub DvOperadores_DoubleClick(sender As Object, e As EventArgs) Handles dvOperadores.DoubleClick
        Dim oVentana As New frmOperador

        If dvOperadores.SelectedRows.Count = 0 Then Return
        oVentana.PassedText = dvOperadores.SelectedRows.Item(0).Cells(0).Value.ToString()
        oVentana.ShowDialog()
        CargaOperadores()
        oVentana.Dispose()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dvOperadores.SelectedRows.Count = 0 Then Return
        If MsgBox("¿Está seguro de eliminar a este operador", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.SystemModal, "Atención") = MsgBoxResult.No Then Return

        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim conn = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = Conexión()}

        cSQL = "DELETE FROM operadores WHERE idoperador = " + dvOperadores.SelectedRows.Item(0).Cells(0).Value.ToString()
        cmd = New MySqlCommand(cSQL, conn)
        conn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()
        CargaOperadores()
    End Sub
End Class