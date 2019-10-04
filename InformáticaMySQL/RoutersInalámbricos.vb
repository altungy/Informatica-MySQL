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

Public Class FrmRoutersInalámbricos
    Private connMySQL As MySqlConnection
    Private dtTiendas As DataTable
    Dim lNuevo As Boolean = False

    Private Sub RoutersInalámbricos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lvwRouters
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .Columns.Add("Subred", 100, HorizontalAlignment.Left)
            .Columns.Add("Tienda", 200, HorizontalAlignment.Left)
        End With

        connMySQL = New MySqlConnection(Conexión())
        dtTiendas = CargaTabla("SELECT codigo, nombre FROM tiendas WHERE estado <> ""CERRADA"" ORDER BY nombre", connMySQL)

        With comboTiendas
            .DataSource = dtTiendas
            .DisplayMember = "nombre"
            .ValueMember = "codigo"
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End With

        CargaRouters()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If btnSalir.Text = "&Salir" Then
            Me.Close()
        Else
            DesactivaEdición()
        End If
    End Sub

    Private Sub CargaRouters()
        Dim dtRouters, dtTienda As DataTable
        Dim cSQL, cTienda As String

        lvwRouters.Items.Clear()
        cSQL = "SELECT * FROM inalambricos ORDER BY subred"
        dtRouters = CargaTabla(cSQL, connMySQL)

        For n = 0 To dtRouters.Rows.Count - 1
            Dim item As New ListViewItem(dtRouters.Rows(n)("subred").ToString)

            cTienda = "Central"

            If dtRouters.Rows(n)("tienda") <> 0 Then
                cSQL = "SELECT nombre FROM tiendas WHERE codigo = " + dtRouters.Rows(n)("tienda").ToString
                dtTienda = CargaTabla(cSQL, connMySQL)

                If dtTienda.Rows.Count > 0 Then cTienda = dtTienda.Rows(0)("nombre")
            End If

            item.SubItems.Add(cTienda)
            lvwRouters.Items.AddRange(New ListViewItem() {item})
        Next
    End Sub

    Private Sub LvwRouters_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwRouters.MouseUp
        If e.Button = MouseButtons.Right Then
            cmRouters.Show(lvwRouters, e.Location)
        End If
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        txtSubred.Text = ""
        comboTiendas.Text = ""
        ActivaEdición()
        lNuevo = True
        txtSubred.Focus()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        ActivaEdición()
        txtSubred.Text = lvwRouters.SelectedItems(0).SubItems(0).Text
        txtSubred.Visible = False
        lNuevo = False
        comboTiendas.Text = If(lvwRouters.SelectedItems(0).SubItems(1).Text = "Central", "", lvwRouters.SelectedItems(0).SubItems(1).Text)
        comboTiendas.Focus()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        If MsgBox("¿Está seguro de eliminar este router?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            Dim cSQL As String = "DELETE FROM inalambricos WHERE subred = " + GrabaComillas(lvwRouters.SelectedItems(0).SubItems(0).Text)
            Dim cmd As MySqlCommand = New MySqlCommand(cSQL, connMySQL)

            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Eliminación router", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connMySQL.Close()
            CargaRouters()
        End If
    End Sub

    Private Sub ActivaEdición()
        txtSubred.Visible = True
        comboTiendas.Visible = True
        btnAceptar.Visible = True
        btnSalir.Text = "&Cancelar"
    End Sub

    Private Sub DesactivaEdición()
        txtSubred.Visible = False
        comboTiendas.Visible = False
        btnAceptar.Visible = False
        btnSalir.Text = "&Salir"
        lNuevo = False
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cmd As MySqlCommand
        Dim cSQL As String

        If lNuevo Then
            cSQL = "INSERT INTO inalambricos(subred, tienda) VALUES("
            cSQL += GrabaComillas(txtSubred.Text) + ", "

            If String.IsNullOrEmpty(comboTiendas.Text) Then
                cSQL += "0"
            Else
                cSQL += comboTiendas.SelectedValue.ToString
            End If

            cSQL += ")"
        Else
            cSQL = "UPDATE inalambricos SET tienda = "
            If String.IsNullOrEmpty(comboTiendas.Text) Then cSQL += "0" Else cSQL += comboTiendas.SelectedValue.ToString
            cSQL += " WHERE subred = " + GrabaComillas(txtSubred.Text)
        End If

        connMySQL.Open()
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Alta/modificación router", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        End Try

        connMySQL.Close()
        DesactivaEdición()
        CargaRouters()
    End Sub


End Class