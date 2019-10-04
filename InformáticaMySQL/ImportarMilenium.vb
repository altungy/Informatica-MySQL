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
Imports System.Data.OleDb
Imports Microsoft.Data.Odbc

Public Class FrmImportarMilenium
    Private connMySQL As MySqlConnection
    Private connInformix As OdbcConnection

    Private Sub FrmImportarMilenium_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Dim dtTabla, dtTemporal As DataTable
        Dim cSQL As String
        Dim cmd As MySqlCommand

        lblEmpresa.Text = "Datos generales"
        lblEmpresa.Visible = True
        lblTabla.Text = "Empresas"
        lblTabla.Visible = True

        lblPorcentaje.Visible = True
        pbPorcentaje.Visible = True
        pbPorcentaje.Step = 1
        lblTotal.Visible = True
        pbTotal.Visible = True
        pbTotal.Maximum = 10
        pbTotal.Step = 1

        connInformix = ConexiónCentral("deodbc")
        connMySQL.Open()
        dtTabla = CargaTabla("SELECT * FROM empresas", connInformix)
        pbPorcentaje.Maximum = dtTabla.Rows.Count
        pbPorcentaje.Value = 0

        For n = 0 To dtTabla.Rows.Count - 1
            dtTemporal = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + dtTabla.Rows(n)("empr").ToString)

            If dtTemporal.Rows.Count = 0 Then
                cSQL = "INSERT INTO empresas(idempresa, nombre) VALUES("
                cSQL += dtTabla.Rows(n)("empr").ToString + ", "
                cSQL += GrabaComillas(dtTabla.Rows(n)("nombre")) + ")"
            Else
                cSQL = "UPDATE empresas SET nombre = " + GrabaComillas(dtTabla.Rows(n)("nombre").ToString) + " WHERE idempresa = " + dtTabla.Rows(n)("empr").ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        pbTotal.PerformStep()

        lblTabla.Text = "Rótulos"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        cSQL = "DELETE FROM rotulos"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cSQL = "SELECT * FROM rotulos"
        dtTabla = CargaTabla(cSQL, connInformix)
        pbPorcentaje.Maximum = dtTabla.Rows.Count
        pbPorcentaje.Value = 0

        For n = 0 To dtTabla.Rows.Count - 1
            cSQL = "INSERT INTO rotulos(nombre) VALUES("
            cSQL += GrabaComillas(dtTabla.Rows(n)("nombre").ToString) + ")"

            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        pbTotal.PerformStep()

        Importa("Décimas", "deodbc")
        Importa("Polinesia", "polodbc")
        Importa("Adidas", "adodbc")
        Importa("Invain", "invodbc")
        connMySQL.Close()
        Me.Close()
    End Sub

    Private Sub Importa(cEmpresa As String, cODBC As String)
        Dim cSQL As String
        Dim dtTabla, dtTemporal, dtPaíses As DataTable
        Dim cmd As MySqlCommand
        Dim cProvincia As String

        connInformix = ConexiónCentral(cODBC)
        lblEmpresa.Text = cEmpresa
        lblTabla.Text = "Empresas"

        My.Application.DoEvents()

        dtPaíses = CargaTabla("SELECT * FROM paises", connInformix)

        pbPorcentaje.Value = 0
        lblTabla.Text = "Tiendas"
        My.Application.DoEvents()

        cSQL = "SELECT dir_comerciales.cliente, dir_comerciales.dir1, dir_comerciales.dir2, "
        cSQL += "dir_comerciales.poblacion, dir_comerciales.cod_postal, dir_comerciales.provincia, dir_comerciales.pais, dir_comerciales.telefono, dir_comerciales.correo_e, "
        cSQL += "clientes_comercial.codigo, clientes_comercial.tienda AS nombretienda, clientes_comercial.empr, "
        cSQL += "clientes_aux.codigo AS codigoaux, clientes_aux.rotulo, "
        cSQL += "rotulos.nombre AS nombrerotulo "
        cSQL += "FROM dir_comerciales, clientes_comercial, clientes_aux, rotulos"
        cSQL += " WHERE dir_comerciales.cliente = clientes_aux.codigo AND dir_comerciales.cliente = clientes_comercial.codigo AND rotulos.codigo = clientes_aux.rotulo"
        cSQL += " AND (dir_comerciales.nombre LIKE 'ADI%' OR "
        cSQL += "dir_comerciales.nombre LIKE 'DEC%' OR "
        cSQL += "dir_comerciales.nombre LIKE 'POL%' OR "
        cSQL += "dir_comerciales.nombre LIKE 'INV%')"
        dtTabla = CargaTabla(cSQL, connInformix)
        pbPorcentaje.Maximum = dtTabla.Rows.Count
        pbPorcentaje.Value = 0

        For n = 0 To dtTabla.Rows.Count - 1
            dtTemporal = CargaTabla("SELECT * FROM tiendas WHERE codigo = " + dtTabla.Rows(n)("cliente").ToString)

            If dtTemporal.Rows.Count = 0 Then
                cSQL = "INSERT INTO tiendas(codigo) VALUES("
                cSQL += dtTabla.Rows(n)("cliente").ToString + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            cProvincia = Provincia(dtTabla.Rows(n)("provincia"))

            If String.IsNullOrEmpty(cProvincia) Then
                For m = 0 To dtPaíses.Rows.Count - 1
                    If dtPaíses.Rows(m)("codigo") = dtTabla.Rows(n)("pais") Then
                        cProvincia = dtPaíses.Rows(m)("nombre")
                        Exit For
                    End If
                Next
            End If

            cSQL = "UPDATE tiendas SET nombre = " + GrabaComillas(dtTabla.Rows(n)("nombretienda").ToString) + ","
            cSQL += "idempresa = " + dtTabla.Rows(n)("empr").ToString + ", "
            cSQL += "rotulo = " + GrabaComillas(dtTabla.Rows(n)("nombrerotulo").ToString) + ", "
            cSQL += "direccion1 = " + GrabaComillas(dtTabla.Rows(n)("dir1").ToString) + ","
            cSQL += "direccion2 = " + GrabaComillas(dtTabla.Rows(n)("dir2").ToString) + ", "
            cSQL += "poblacion = " + GrabaComillas(dtTabla.Rows(n)("poblacion").ToString) + ", "
            cSQL += "postal = " + GrabaComillas(dtTabla.Rows(n)("cod_postal").ToString) + ", "
            cSQL += "provincia = " + GrabaComillas(cProvincia) + ", "
            cSQL += "telefono = " + GrabaComillas(dtTabla.Rows(n)("telefono").ToString) + ", "
            cSQL += "email = " + GrabaComillas(dtTabla.Rows(n)("correo_e").ToString)
            cSQL += " WHERE codigo = " + dtTabla.Rows(n)("cliente").ToString
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        pbTotal.PerformStep()
        pbPorcentaje.Value = 0
        lblTabla.Text = "Conexiones"
        My.Application.DoEvents()

        cSQL = "SELECT * FROM conexiones"
        dtTabla = CargaTabla(cSQL, connInformix)
        pbPorcentaje.Maximum = dtTabla.Rows.Count
        pbPorcentaje.Value = 0

        For n = 0 To dtTabla.Rows.Count - 1
            cSQL = "UPDATE tiendas SET comunicacion = " + GrabaComillas(dtTabla.Rows(n)("clave")) + " WHERE codigo = " + dtTabla.Rows(n)("cod_cli").ToString
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next
    End Sub
End Class