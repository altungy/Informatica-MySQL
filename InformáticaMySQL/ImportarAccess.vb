#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

Public Class FrmImportarAccess
    Private connMySQL As MySqlConnection
    Private connAccess As OleDbConnection
    Private connInformática As OleDbConnection

    Private Sub FrmImportarAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
        connAccess = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "Tiendas", Nothing).ToString)
        connInformática = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "Informática", Nothing).ToString)
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Dim cSQL As String
        Dim dtDatos, dtLíneas, dtTemporal As DataTable
        Dim cmd As MySqlCommand
        Dim nEmpresa As Integer
        Dim cSubred As String
        Dim nFactura, nCódigo As Integer

        pbPorcentaje.Visible = True
        pbPorcentaje.Step = 1
        pbPorcentaje.Value = 0

        lblTítulo.Text = "Tiendas"
        dtDatos = CargaAccess("SELECT * FROM tiendas", connAccess)
        'pbPorcentaje.Maximum = dtDatos.Rows.Count
        pbPorcentaje.Maximum = 100

        connMySQL.Open()

        For n = 0 To dtDatos.Rows.Count - 1
            If Val(dtDatos.Rows(n)("codigo").ToString) > 0 Then
                cSQL = "SELECT * FROM tiendas WHERE codigo = " + dtDatos.Rows(n)("codigo").ToString
                dtTemporal = CargaTabla(cSQL)

                If dtTemporal.Rows.Count = 0 Then
                    Select Case dtDatos.Rows(n)("empresa").ToString
                        Case "SPORT STREET S.L."
                            Select Case dtDatos.Rows(n)("rotulo").ToString
                                Case "ADIDAS"
                                    nEmpresa = 34
                                Case "DECIMAS"
                                    nEmpresa = 2
                                Case "POLINESIA"
                                    nEmpresa = 35
                                Case Else
                                    nEmpresa = 1
                            End Select

                        Case "SUN STREET,S.L.U."
                            nEmpresa = 34

                        Case "POLINESIA SPORT, S.L."
                            nEmpresa = 35

                        Case "NEWFIN SPORT,SL", "CASUAL STAR, S.A.", "DECIMAS, S.L.", "TOSCARRALES S.L.", "X-ODUS, S.L."
                            nEmpresa = 2

                        Case "CASUAL FRANCE", "DECIMAS FRANCE"
                            nEmpresa = 27

                        Case "CASUAL STAR PORTUGAL, LDA"
                            nEmpresa = 25

                        Case "DECIMAS POLSKA"
                            nEmpresa = 30

                        Case "MOUNTAIN SPORT, S.L.", "NEWFIN SPORT,SL"
                            If dtDatos.Rows(n)("rotulo") = "DECIMAS" Then nEmpresa = 2 Else nEmpresa = 35

                        Case Else
                            nEmpresa = 0
                    End Select


                    cSQL = "INSERT INTO tiendas(codigo, idempresa, rotulo, nombre, direccion1, poblacion, postal, provincia, telefono, email) VALUES("
                    cSQL += dtDatos.Rows(n)("codigo").ToString + ", "
                    cSQL += nEmpresa.ToString + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("rotulo").ToString) + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("nuevo").ToString) + ", "
                    cSQL += GrabaComillas(Microsoft.VisualBasic.Left(dtDatos.Rows(n)("direccion").ToString, 60)) + ","
                    cSQL += GrabaComillas(dtDatos.Rows(n)("poblacion").ToString) + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("cp").ToString) + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("provincia")) + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("telefono").ToString) + ", "
                    cSQL += GrabaComillas(dtDatos.Rows(n)("correoe").ToString) + ")"
                    cmd = New MySqlCommand(cSQL, connMySQL)

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

                cSubred = ""
                If Len(dtDatos.Rows(n)("subred").ToString) > 0 Then cSubred = Microsoft.VisualBasic.Left(dtDatos.Rows(n)("subred").ToString, Len(Trim(dtDatos.Rows(n)("subred").ToString)) - 1)
                If Microsoft.VisualBasic.Right(cSubred, 1) <> "." Then cSubred += "."

                cSQL = "UPDATE tiendas SET "
                cSQL += "extension = " + GrabaComillas(dtDatos.Rows(n)("extension").ToString) + ", "
                cSQL += "estado = " + GrabaComillas(dtDatos.Rows(n)("estado_tienda").ToString) + ", "
                cSQL += "contacto = " + GrabaComillas(dtDatos.Rows(n)("contacto").ToString) + ", "
                cSQL += "telefonocontacto = " + GrabaComillas(dtDatos.Rows(n)("telefono_contacto").ToString) + ", "
                cSQL += "ordenadores = " + dtDatos.Rows(n)("num_ordenadores").ToString + ", "
                cSQL += "so = " + GrabaComillas(dtDatos.Rows(n)("so").ToString) + ", "
                cSQL += "linea = " + GrabaComillas(IIf(Microsoft.VisualBasic.Left(dtDatos.Rows(n)("linea").ToString, 1) = "A", "C", "")) + ", "
                cSQL += "proveedor = " + GrabaComillas(dtDatos.Rows(n)("proveedor_internet").ToString) + ", "
                cSQL += "sedecomunicaciones = " + GrabaComillas(dtDatos.Rows(n)("id_sede_orange").ToString) + ", "
                cSQL += "subred = " + GrabaComillas(cSubred) + ", "
                cSQL += "comunicacion = " + GrabaComillas(dtDatos.Rows(n)("comunicacion").ToString) + ", "
                cSQL += "merchant = " + GrabaComillas(dtDatos.Rows(n)("merchant").ToString) + ", "
                cSQL += "comercio = " + GrabaComillas(dtDatos.Rows(n)("comercio").ToString) + ", "
                cSQL += "observaciones = " + GrabaComillas(dtDatos.Rows(n)("observaciones").ToString)
                cSQL += " WHERE codigo = " + dtDatos.Rows(n)("codigo").ToString
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            'pbPorcentaje.PerformStep()
            pbPorcentaje.Value = n / dtDatos.Rows.Count * 100
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Formas de pago"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        dtDatos = CargaAccess("SELECT * FROM formasdepago", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "SELECT * FROM formasdepago WHERE idformapago = " + dtDatos.Rows(n)("idformapago").ToString
            dtTemporal = CargaTabla(cSQL)

            If dtTemporal.Rows.Count = 0 Then
                cSQL = "INSERT INTO formasdepago(idformapago, nombre, dias, diapago, descuento) VALUES("
                cSQL += dtDatos.Rows(n)("idformapago").ToString + ", "
                cSQL += GrabaComillas(dtDatos.Rows(n)("nombre")) + ", "
                cSQL += dtDatos.Rows(n)("dias").ToString + ", "
                cSQL += dtDatos.Rows(n)("diapago").ToString + ", "
                cSQL += dtDatos.Rows(n)("descuento").ToString + ")"

                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Proveedores"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        cmd = New MySqlCommand("TRUNCATE TABLE contactosproveedor", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE TABLE proveedores", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE TABLE tempinventario", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM proveedores", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "INSERT INTO proveedores(nombre, direccion, postal, poblacion, provincia, cif, diaspago, diapago, descuento, idformapago) VALUES("
            cSQL += GrabaComillas(dtDatos.Rows(n)("nombre")) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("direccion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("postal").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("poblacion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("provincia").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("cif").ToString) + ", "
            cSQL += dtDatos.Rows(n)("diaspago").ToString + ", "
            cSQL += dtDatos.Rows(n)("diapago").ToString + ", "
            cSQL += dtDatos.Rows(n)("descuento").ToString + ", "
            cSQL += dtDatos.Rows(n)("idformapago").ToString + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtTemporal = CargaTabla("SELECT MAX(idproveedor) AS codigo FROM proveedores", connMySQL)
            cSQL = "INSERT INTO tempinventario(antiguo, nuevo) VALUES("
            cSQL += dtDatos.Rows(n)("idproveedor").ToString + ", "
            cSQL += dtTemporal.Rows(0)("codigo").ToString + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtLíneas = CargaAccess("SELECT * FROM contactosproveedor WHERE idproveedor = " + dtDatos.Rows(n)("idproveedor").ToString, connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                cSQL = "INSERT INTO contactosproveedor(idproveedor, nombre, direccion, postal, poblacion, provincia, telefono, email) VALUES("
                cSQL += dtTemporal.Rows(0)("codigo").ToString + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("nombre")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("direccion")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("postal")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("poblacion")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("provincia")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("telefono")) + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("email")) + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Artículos"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        dtDatos = CargaAccess("SELECT * FROM articulos", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count

        cmd = New MySqlCommand("TRUNCATE TABLE articulos", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE TABLE tempinventario", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE TABLE movimientosarticulos", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE TABLE reparacionesarticulos", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "INSERT INTO articulos(serie, nombre, descripcion, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("compra").ToString) Then cSQL += "compra, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("garantia").ToString) Then cSQL += "garantia, "
            cSQL += "idproveedor, factura, precio, retirado) VALUES("
            cSQL += GrabaComillas(dtDatos.Rows(n)("serie")) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("nombre")) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("descripcion")) + ", "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("compra").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("compra"), "yyyy-MM-dd") + "', "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("garantia").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("garantia"), "yyyy-MM-dd") + "', "
            cSQL += dtDatos.Rows(n)("idproveedor").ToString + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("factura")) + ", "
            cSQL += Str(dtDatos.Rows(n)("precio")) + ", "
            cSQL += If(dtDatos.Rows(n)("retirado") = True, "1", "0") + ")"

            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            cSQL = "INSERT INTO tempinventario(antiguo, nuevo) VALUES("
            cSQL += dtDatos.Rows(n)("idarticulo").ToString + ", "
            cSQL += "last_insert_id())"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtTemporal = CargaTabla("SELECT idarticulo FROM articulos ORDER BY idarticulo DESC LIMIT 1", connMySQL)
            nCódigo = dtTemporal.Rows(0)("idarticulo")

            cSQL = "SELECT * FROM movimientosarticulos WHERE idarticulo = " + dtDatos.Rows(n)("idarticulo").ToString
            dtLíneas = CargaTabla(cSQL, connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                cSQL = "SELECT * FROM tiendas WHERE idtienda = " + dtLíneas.Rows(m)("idtienda").ToString
                dtTemporal = CargaTabla(cSQL)
                cSQL = "INSERT INTO movimientosarticulos(idarticulo, idtienda, fecha, usuario) VALUES("
                cSQL += dtTemporal.Rows(0)("codigo").ToString + ", "
                cSQL += nCódigo.ToString + ", "
                cSQL += "'" + Format(dtLíneas.Rows(m)("fecha"), "yyyy-MM-dd") + "', "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("usuario")) + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            cSQL = "SELECT * FROM reparacionesarticulos WHERE idarticulo = " + dtDatos.Rows(n)("idarticulo").ToString
            dtLíneas = CargaTabla(cSQL, connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                cSQL = "INSERT INTO reparacionesarticulos(idarticulo, fecha, idproveedor, averia"
                If Not String.IsNullOrEmpty(dtLíneas.Rows(m)("devolucion").ToString) Then cSQL += ", devolucion"
                cSQL += ") VALUES("
                cSQL += nCódigo.ToString + ", "
                cSQL += "'" + Format(dtLíneas.Rows(m)("fecha"), "yyyy-MM-dd") + "', "
                cSQL += dtDatos.Rows(n)("idproveedor").ToString + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("averia"))
                If Not String.IsNullOrEmpty(dtLíneas.Rows(m)("devolucion").ToString) Then cSQL += ", '" + Format(dtLíneas.Rows(m)("devolucion"), "yyyy-MM-dd") + "'"
                cSQL += ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Inventario"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        cmd = New MySqlCommand("TRUNCATE TABLE inventario", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM inventario", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count

        For n = 0 To dtDatos.Rows.Count - 1
            dtTemporal = CargaAccess("SELECT codigo FROM tiendas WHERE idtienda = " + dtDatos.Rows(n)("idtienda").ToString, connAccess)

            If dtTemporal.Rows.Count > 0 Then
                cSQL = "INSERT INTO inventario(idtienda, usuario, "
                If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fecha").ToString) Then cSQL += "fecha, "
                cSQL += "articulo, serie, cantidad, precio, idproveedor, factura, "
                If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechafactura").ToString) Then cSQL += "fechafactura, "
                cSQL += "facturable) VALUES("
                cSQL += dtTemporal.Rows(0)("codigo").ToString + ", "
                cSQL += GrabaComillas(dtDatos.Rows(n)("usuario").ToString) + ", "
                If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fecha").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fecha"), "yyyy-MM-dd") + "', "
                cSQL += GrabaComillas(dtDatos.Rows(n)("articulo").ToString) + ", "
                cSQL += GrabaComillas(dtDatos.Rows(n)("serie").ToString) + ", "
                cSQL += dtDatos.Rows(n)("cantidad").ToString + ", "
                cSQL += Str(dtDatos.Rows(n)("precio")) + ", "
                cSQL += dtDatos.Rows(n)("idproveedor").ToString + ", "
                cSQL += GrabaComillas(dtDatos.Rows(n)("factura").ToString) + ", "
                If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechafactura").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fechafactura"), "yyyy-MM-dd") + "', "
                cSQL += If(dtDatos.Rows(n)("facturable") = True, "1", "0") + ")"

                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Movimientos artículos"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        dtDatos = CargaAccess("SELECT * FROM movimientosarticulos", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count





        lblTítulo.Text = "Cabecera facturación interna"
        pbPorcentaje.Value = 0
        My.Application.DoEvents()

        cmd = New MySqlCommand("TRUNCATE table cabfacturainterna", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cmd = New MySqlCommand("TRUNCATE table linfacturainterna", connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM cabfacturainterna", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count

        For n = 0 To dtDatos.Rows.Count - 1
            dtTemporal = CargaAccess("SELECT codigo FROM tiendas WHERE idtienda = " + dtDatos.Rows(n)("idtienda").ToString, connAccess)

            If dtTemporal.Rows.Count > 0 Then
                cSQL = "INSERT INTO cabfacturainterna(fecha, idtienda) VALUES("
                cSQL += "'" + Format(dtDatos.Rows(n)("fecha"), "yyyy-MM-dd") + "', "
                cSQL += dtTemporal.Rows(0)("codigo").ToString + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                dtTemporal = CargaTabla("SELECT idfactura FROM cabfacturainterna ORDER BY idfactura DESC LIMIT 1", connMySQL)
                nFactura = dtTemporal.Rows(0)("idfactura")
                dtLíneas = CargaAccess("SELECT * FROM linfacturainterna WHERE idfactura = " + nFactura.ToString, connInformática)

                For m = 0 To dtLíneas.Rows.Count - 1
                    dtTemporal = CargaTabla("SELECT nuevo FROM tempinventario WHERE antiguo = " + dtLíneas.Rows(m)("idarticulo").ToString, connMySQL)

                    If dtTemporal.Rows.Count > 0 Then
                        cSQL = "INSERT INTO linfacturainterna(idfactura, idarticulo, descripcion, precio, idproveedor, factura"
                        If Not String.IsNullOrEmpty(dtLíneas.Rows(m)("fecha").ToString) Then cSQL += ", fecha"
                        cSQL += ") VALUES("
                        cSQL += nFactura.ToString + ", "
                        cSQL += dtTemporal.Rows(0)("nuevo").ToString + ", "
                        cSQL += GrabaComillas(dtLíneas.Rows(m)("descripcion")) + ", "
                        cSQL += Str(dtLíneas.Rows(m)("precio")) + ", "
                        cSQL += dtLíneas.Rows(m)("idproveedor").ToString + ", "
                        cSQL += GrabaComillas(dtLíneas.Rows(m)("factura"))
                        If Not String.IsNullOrEmpty(dtLíneas.Rows(m)("fecha").ToString) Then cSQL += ", '" + Format(dtLíneas.Rows(m)("fecha"), "yyyy-MM-dd") + "'"
                        cSQL += ")"
                        cmd = New MySqlCommand(cSQL, connMySQL)

                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Next
            End If

            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Procedimientos"
        cSQL = "TRUNCATE TABLE linprocedimiento"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cSQL = "TRUNCATE TABLE cabprocedimiento"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM cabprocedimiento", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count
        pbPorcentaje.Value = 1

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "INSERT INTO cabprocedimiento(nombre, descripcion) VALUES("
            cSQL += GrabaComillas(dtDatos.Rows(n)("nombre")) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("descripcion").ToString) + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtTemporal = CargaTabla("SELECT MAX(idprocedimiento) AS codigo FROM cabprocedimiento", connMySQL)
            dtLíneas = CargaAccess("SELECT * FROM linprocedimiento WHERE idprocedimiento = " + dtTemporal.Rows(0)("codigo").ToString + " ORDER BY orden", connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                cSQL = "INSERT INTO linprocedimiento(idprocedimiento, orden, texto) VALUES("
                cSQL += dtTemporal.Rows(0)("codigo").ToString + ", "
                cSQL += dtLíneas.Rows(m)("orden").ToString + ", "
                cSQL += GrabaComillas(dtLíneas.Rows(m)("texto").ToString) + ")"
                cmd = New MySqlCommand(cSQL, connMySQL)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            pbPorcentaje.PerformStep()
            My.Application.DoEvents()
        Next

        lblTítulo.Text = "Pedidos"
        cSQL = "TRUNCATE TABLE linpedido"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cSQL = "TRUNCATE TABLE cabpedido"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM cabpedido", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count
        pbPorcentaje.Value = 1

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "INSERT INTO cabpedido(fecha, idempresa, departamento, peticionario, aprobado, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechaaprobacion").ToString) Then cSQL += "fechaaprobacion, "
            cSQL += "referencia, nombre, direccion, postal, poblacion, provincia, contacto, telefono, observaciones) VALUES("
            cSQL += "'" + Format(dtDatos.Rows(n)("fecha"), "yyyy-MM-dd") + "', "
            cSQL += "0, "
            cSQL += GrabaComillas(dtDatos.Rows(n)("departamento").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("peticionario").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("aprobado").ToString) + ", "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechaaprobacion").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fechaaprobacion"), "yyyy-MM-dd") + "', "
            cSQL += GrabaComillas(dtDatos.Rows(n)("referencia").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("nombre").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("direccion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("postal").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("poblacion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("provincia").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("contacto").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("telefono").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("observaciones").ToString) + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtTemporal = CargaTabla("SELECT numpedido FROM cabpedido ORDER BY numpedido DESC LIMIT 1", connMySQL)
            nFactura = dtTemporal.Rows(0)("numpedido")
            dtLíneas = CargaAccess("SELECT * FROM linpedido WHERE numpedido = " + dtDatos.Rows(n)("numpedido").ToString, connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                If dtTemporal.Rows.Count > 0 Then
                    cSQL = "INSERT INTO linpedido(numpedido, articulo, cantidad, precio, idproveedor, numcompra) VALUES("
                    cSQL += nFactura.ToString + ", "
                    cSQL += GrabaComillas(dtLíneas.Rows(m)("articulo").ToString) + ", "
                    cSQL += Str(dtLíneas.Rows(m)("cantidad")) + ", "
                    cSQL += Str(dtLíneas.Rows(m)("precio")) + ", "
                    cSQL += dtLíneas.Rows(m)("idproveedor").ToString + ", "
                    cSQL += dtLíneas.Rows(m)("numcompra").ToString + ")"
                    cmd = New MySqlCommand(cSQL, connMySQL)

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Next

        lblTítulo.Text = "Compras"
        cSQL = "TRUNCATE TABLE lincompra"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        cSQL = "TRUNCATE TABLE cabcompra"
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dtDatos = CargaAccess("SELECT * FROM cabcompra", connInformática)
        pbPorcentaje.Maximum = dtDatos.Rows.Count
        pbPorcentaje.Value = 1

        For n = 0 To dtDatos.Rows.Count - 1
            cSQL = "INSERT INTO cabcompra(fecha, idempresa, numpedido, idproveedor, descuento, factura, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechafactura").ToString) Then cSQL += "fechafactura, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechavencimiento").ToString) Then cSQL += "fechavencimiento, "
            cSQL += "visado, "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechavisado").ToString) Then cSQL += "fechavisado, "
            cSQL += "observaciones, nombre, direccion, postal, poblacion, provincia, contacto, telefono) VALUES("
            cSQL += "'" + Format(dtDatos.Rows(n)("fecha"), "yyyy-MM-dd") + "', "
            cSQL += "0, "
            cSQL += dtDatos.Rows(n)("numpedido").ToString + ", "
            cSQL += dtDatos.Rows(n)("idproveedor").ToString + ", "
            cSQL += Str(dtDatos.Rows(n)("descuento")) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("factura").ToString) + ", "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechafactura").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fechafactura"), "yyyy-MM-dd") + "', "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechavencimiento").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fechavencimiento"), "yyyy-MM-dd") + "', "
            cSQL += GrabaComillas(dtDatos.Rows(n)("visado").ToString) + ", "
            If Not String.IsNullOrEmpty(dtDatos.Rows(n)("fechavisado").ToString) Then cSQL += "'" + Format(dtDatos.Rows(n)("fechavisado"), "yyyy-MM-dd") + "', "
            cSQL += GrabaComillas(dtDatos.Rows(n)("observaciones").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("nombre").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("direccion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("postal").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("poblacion").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("provincia").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("contacto").ToString) + ", "
            cSQL += GrabaComillas(dtDatos.Rows(n)("telefono").ToString) + ")"
            cmd = New MySqlCommand(cSQL, connMySQL)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dtTemporal = CargaTabla("SELECT numcompra FROM cabcompra ORDER BY numcompra DESC LIMIT 1", connMySQL)
            nFactura = dtTemporal.Rows(0)("numcompra")
            dtLíneas = CargaAccess("SELECT * FROM lincompra WHERE numcompra = " + dtDatos.Rows(0)("numcompra").ToString, connInformática)

            For m = 0 To dtLíneas.Rows.Count - 1
                If dtTemporal.Rows.Count > 0 Then
                    cSQL = "INSERT INTO lincompra(numcompra, articulo, cantidad, precio, descuento) VALUES("
                    cSQL += nFactura.ToString + ", "
                    cSQL += GrabaComillas(dtLíneas.Rows(m)("articulo").ToString) + ", "
                    cSQL += Str(dtLíneas.Rows(m)("cantidad")) + ", "
                    cSQL += Str(dtLíneas.Rows(m)("precio")) + ", "
                    cSQL += Str(dtLíneas.Rows(m)("descuento")) + ")"
                    cmd = New MySqlCommand(cSQL, connMySQL)

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Next
        Next

        connMySQL.Close()
        Me.Close()
    End Sub

    Public Shared Function CargaAccess(cSQL As String, conn As OleDbConnection) As DataTable
        Dim tablaDA As New DataTable()
        Dim cmd As New OleDbDataAdapter(cSQL, conn)

        cmd.Fill(tablaDA)
        Return (tablaDA)
    End Function
End Class