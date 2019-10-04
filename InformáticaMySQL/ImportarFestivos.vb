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

Imports System.Net
Imports MySql.Data.MySqlClient

Public Class FrmImportarFestivos
    ' http://www.calendarios-laborales.es/calendario-laboral-conquista_de_la_sierra-2019-cc
    ' https://calendarios.ideal.es/laboral/comunidad-de-madrid/madrid/alcala-de-henares/2019

    Private conn As MySqlConnection = New MySqlConnection(Conexión())

    Private Sub Festivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAño.Text = Year(Now()).ToString
        lblTienda.Text = ""
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtPoblaciones As DataTable
        Dim cURL As String = "https://calendarios.ideal.es/laboral/comunidad-de-madrid/madrid/alcala-de-henares/2019"
        Dim instance As WebClient
        Dim returnValue As Byte()
        Dim cTexto, cSQL As String
        'Dim lProcesar As Boolean = False
        Dim nPosición, nFin, nProcesados As Integer
        Dim cmdMySQL As MySqlCommand
        Dim cProvincia, cPoblación As String

        pbProgreso.Visible = False
        lblTienda.Text = ""

        conn.Open()
        cSQL = "TRUNCATE TABLE tempfestivos"
        cmdMySQL = New MySqlCommand(cSQL, conn)

        Try
            cmdMySQL.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Borrar tabla temporal festivos", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        End Try

        cProvincia = ""
        instance = New WebClient()
        ReDim returnValue(0)
        returnValue = instance.DownloadData(cURL)
        Dim enc As New System.Text.UTF8Encoding()
        cTexto = enc.GetString(returnValue)
        nFin = cTexto.IndexOf("<a class=""dropdown-toggle disabled"" data-toggle=""dropdown"" href=""/calendario-lunar")
        nPosición = cTexto.IndexOf("<a class=""dropdown-toggle disabled"" data-toggle=""dropdown") + 20
        nProcesados = nPosición
        cTexto = Mid(cTexto, nPosición)
        nPosición = cTexto.IndexOf("<a class=""dropdown-toggle disabled"" data-toggle=""dropdown") + 20
        nProcesados += nPosición
        cTexto = Mid(cTexto, nPosición)
        nPosición = cTexto.IndexOf("href") + 7
        nProcesados += nPosición
        cTexto = Mid(cTexto, nPosición)

        While nProcesados < nFin
            nPosición = cTexto.IndexOf(""">")

            If Microsoft.VisualBasic.Left(cTexto, nPosición).Split("/").Length - 1 = 2 Then
                nPosición = cTexto.IndexOf("href") + 7
                nProcesados += nPosición
                cTexto = Mid(cTexto, nPosición)
                nPosición = cTexto.IndexOf(""">")
            End If

            If Microsoft.VisualBasic.Left(cTexto, nPosición).Split("/").Length - 1 = 3 Then
                nPosición = cTexto.IndexOf("<span>") + 7
                nProcesados += nPosición
                cTexto = Mid(cTexto, nPosición)
                nPosición = cTexto.IndexOf("</span>")
                cProvincia = Microsoft.VisualBasic.Left(cTexto, nPosición)
                nPosición = cTexto.IndexOf("href") + 7
                nProcesados += nPosición
                cTexto = Mid(cTexto, nPosición)

            End If

            nPosición = cTexto.IndexOf(Chr(34))
            cURL = Microsoft.VisualBasic.Left(cTexto, nPosición)
            nProcesados += nPosición + 2
            cTexto = Mid(cTexto, nPosición + 3)
            nPosición = cTexto.IndexOf("<")
            cPoblación = Microsoft.VisualBasic.Left(cTexto, nPosición - 1).Trim()
            nProcesados += nPosición
            nPosición = cTexto.IndexOf("href") + 7
            nProcesados += nPosición
            cTexto = Mid(cTexto, nPosición)

            lblTienda.Text = cProvincia + "- " + cPoblación
            My.Application.DoEvents()

            cSQL = "INSERT INTO tempfestivos(poblacion, url) VALUES ("
            cSQL += GrabaComillas(cPoblación.ToUpper) + ", "
            cSQL += GrabaComillas(cURL) + ")"
            cmdMySQL = New MySqlCommand(cSQL, conn)

            Try
                cmdMySQL.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Insertar poblaciones festivos", st)
                Dim nResultado As Integer

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try
        End While

        dtPoblaciones = CargaTabla("SELECT * FROM tempfestivos ORDER BY poblacion", conn)
        pbProgreso.Minimum = 0
        pbProgreso.Maximum = dtPoblaciones.Rows.Count - 1
        pbProgreso.Value = 0
        pbProgreso.Visible = True

        For n = 0 To dtPoblaciones.Rows.Count - 1
            pbProgreso.Value = n
            lblTienda.Text = dtPoblaciones.Rows(n)("poblacion")
            My.Application.DoEvents()

            cURL = "https://calendarios.ideal.es" + dtPoblaciones.Rows(n)("url")
            instance = New WebClient()
            ReDim returnValue(0)
            returnValue = instance.DownloadData(cURL)
            enc = New System.Text.UTF8Encoding()
            cTexto = enc.GetString(returnValue)

            Procesar(cTexto, dtPoblaciones.Rows(n)("poblacion"))
        Next

        conn.Close()
        Me.Close()
    End Sub

    Private Sub Procesar(ByVal cTexto As String, ByVal cPoblación As String)
        Dim cLínea As String
        Dim nPosición As Integer
        Dim nDía As Integer
        Dim nMes As Integer
        Dim cTipo As String = ""
        Dim dFecha As Date
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim aMeses() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

        For n = 0 To 11
            nMes = n + 1
            nPosición = cTexto.IndexOf(aMeses(n))
            cLínea = Mid(cTexto, nPosición)
            nPosición = cLínea.IndexOf("</div>")
            cLínea = Microsoft.VisualBasic.Left(cLínea, nPosición)

            While True
                nPosición = cLínea.IndexOf("bm-calendar-state")

                If nPosición < 0 Then Exit While

                cLínea = Mid(cLínea, nPosición + 19)

                Select Case Microsoft.VisualBasic.Left(cLínea, 1)
                    Case "n"
                        cTipo = "Nacional"

                    Case "a"
                        cTipo = "Autonómico"

                    Case "l"
                        cTipo = "Local"
                End Select

                nPosición = cLínea.IndexOf(""">")
                cLínea = Mid(cLínea, nPosición + 3)

                If Microsoft.VisualBasic.Left(cLínea, 2) = "<a" Then
                    nPosición = cLínea.IndexOf(""">")
                    cLínea = Mid(cLínea, nPosición + 3)
                End If

                nPosición = cLínea.IndexOf("<")
                nDía = Val(Microsoft.VisualBasic.Left(cLínea, nPosición))
                cLínea = Mid(cLínea, nPosición)
                dFecha = New DateTime(Val(txtAño.Text), nMes, nDía, 0, 0, 0)

                cSQL = "INSERT INTO festivos (fecha, poblacion, tipo) VALUES("
                cSQL += DtoSQL(dFecha) + ", "
                cSQL += GrabaComillas(cPoblación) + ", "
                cSQL += GrabaComillas(cTipo) + ")"
                cmd = New MySqlCommand(cSQL, conn)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj As New FrmError(ex, "Insertar festivos", st)
                    Dim nResultado As Integer

                    nResultado = obj.ShowDialog(Me)
                    If nResultado = DialogResult.Cancel Then Me.Close()
                End Try
            End While
        Next
    End Sub
    '
    ' www.calendarios-laborales.es
    '
    'Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
    '    Dim dtTiendas, dtTemporal As DataTable
    '    Dim cURL As String = "http://www.calendarios-laborales.es/calendario-laboral-"
    '    Dim instance As WebClient
    '    Dim returnValue As Byte()
    '    Dim aLíneas As String()
    '    Dim cLínea, cTipo, cSQL As String
    '    Dim dFecha As Date
    '    Dim lProcesar As Boolean = False
    '    Dim nÍndice, nDía, nMes As Integer
    '    Dim cmdMySQL As MySqlCommand
    '    Dim conn As MySqlConnection = New MySqlConnection(Conexión())
    '    Dim cProvincia, cEnlace As String

    '    conn.Open()

    '    dtTiendas = CargaTabla("SELECT nombre, poblacion, postal FROM tiendas ORDER BY nombre")
    '    pbProgreso.Minimum = 0
    '    pbProgreso.Maximum = dtTiendas.Rows.Count - 1
    '    pbProgreso.Value = 0

    '    For n = 0 To dtTiendas.Rows.Count - 1
    '        pbProgreso.Value = n
    '        lblTienda.Text = dtTiendas.Rows(n)("nombre")
    '        My.Application.DoEvents()

    '        cProvincia = Matrícula(dtTiendas.Rows(n)("postal"))

    '        If cProvincia <> String.Empty Then
    '            cEnlace = cURL + dtTiendas.Rows(n)("poblacion").ToLower.Replace(" ", "-")
    '            cEnlace += "-" + txtAño.Text + "-" + cProvincia
    '            cTipo = ""
    '            lProcesar = False

    '            instance = New WebClient()
    '            ReDim returnValue(0)
    '            returnValue = instance.DownloadData(cEnlace)
    '            Dim enc As New System.Text.ASCIIEncoding()
    '            cLínea = enc.GetString(returnValue)
    '            aLíneas = Split(cLínea, Chr(10))

    '            For m = 0 To aLíneas.Length - 1
    '                If aLíneas(m).Contains("itemprop=""startDate""") Then
    '                    cLínea = Mid(aLíneas(m), aLíneas(m).IndexOf(Chr(34)) + 1)

    '                    Select Case Microsoft.VisualBasic.Left(cLínea, 1)
    '                        Case "n"
    '                            cTipo = "Nacional"

    '                        Case "a"
    '                            cTipo = "Autonómico"

    '                        Case "l"
    '                            cTipo = "Local"

    '                        Case Else
    '                            cTipo = ""
    '                    End Select

    '                    cLínea = Mid(cLínea, cLínea.IndexOf("content") + 9)
    '                    dFecha = DateTime.ParseExact(Microsoft.VisualBasic.Left(cLínea, 10), "yyyy-MM-dd", Nothing)

    '                    cSQL = "SELECT * FROM festivos WHERE fecha = " + DtoSQL(dFecha) + " AND poblacion = " + GrabaComillas(dtTiendas.Rows(n)("poblacion"))
    '                    dtTemporal = CargaTabla(cSQL)

    '                    If dtTemporal.Rows.Count = 0 Then
    '                        cSQL = "INSERT INTO festivos (fecha, poblacion, tipo) VALUES("
    '                        cSQL += DtoSQL(dFecha) + ", "
    '                        cSQL += GrabaComillas(dtTiendas.Rows(n)("poblacion")) + ", "
    '                        cSQL += GrabaComillas(cTipo) + ")"

    '                        cmdMySQL = New MySqlCommand(cSQL, conn)

    '                        Try
    '                            cmdMySQL.ExecuteNonQuery()
    '                        Catch ex As Exception
    '                            Dim st As StackTrace
    '                            st = New StackTrace(ex, True)
    '                            Dim obj As New FrmError(ex, "Insertar festivos", st)
    '                            Dim nResultado As Integer

    '                            nResultado = obj.ShowDialog(Me)
    '                            If nResultado = DialogResult.Cancel Then Me.Close()
    '                        End Try
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Next

    '    conn.Close()
    '    Me.Close()
    'End Sub

    'Private Function Matrícula(cPostal) As String
    '    Dim nProvincia As String = Val(Microsoft.VisualBasic.Left(cPostal, 2))
    '    Dim cMatrícula As String = ""
    '    Dim aMatrículas() As String = {"vi", "ab", "a", "al", "av", "ba", "pm", "b", "bu", "cc", "ca", "cs", "cr", "co", "c", "cu",
    '                                   "gi", "gr", "gu", "ss", "h", "hu", "j", "le", "l", "lo", "lu", "m", "ma", "mu", "na", "or",
    '                                   "0", "p", "gc", "po", "sa", "tf", "s", "sg", "se", "so", "t", "te", "to", "v", "va", "bi",
    '                                   "za", "z", "ce", "me"}

    '    If nProvincia > 0 And nProvincia < 53 Then
    '        cMatrícula = aMatrículas(nProvincia - 1)
    '    End If

    '    Return (cMatrícula)
    'End Function
    '
    ' www.tramitapp
    '
    'Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
    '    Dim dtTiendas, dtTemporal As DataTable
    '    Dim cURL As String = "https://www.tramitapp.com/calendario-laboral-"
    '    Dim instance As WebClient
    '    Dim returnValue As Byte()
    '    Dim aLíneas As String()
    '    Dim cLínea, cTipo, cSQL As String
    '    Dim dFecha As Date
    '    Dim lProcesar As Boolean = False
    '    Dim nÍndice, nDía, nMes As Integer
    '    Dim cmdMySQL As MySqlCommand
    '    Dim conn As MySqlConnection = New MySqlConnection(Conexión())

    '    conn.Open()

    '    dtTiendas = CargaTabla("SELECT * FROM tiendas ORDER BY nombre")
    '    pbProgreso.Minimum = 0
    '    pbProgreso.Maximum = dtTiendas.Rows.Count - 1
    '    pbProgreso.Value = 0

    '    For n = 0 To dtTiendas.Rows.Count - 1
    '        pbProgreso.Value = n
    '        lblTienda.Text = dtTiendas.Rows(n)("nombre")
    '        My.Application.DoEvents()

    '        cURL = "https://www.tramitapp.com/calendario-laboral-"
    '        cURL += dtTiendas.Rows(n)("poblacion").ToLower.Replace(" ", "-")
    '        cURL += "-" + txtAño.Text + "/"
    '        cTipo = ""
    '        lProcesar = False

    '        instance = New WebClient()
    '        ReDim returnValue(0)
    '        returnValue = instance.DownloadData(cURL)
    '        'returnValue = instance.DownloadData("https://www.tramitapp.com/calendario-laboral-conquista-de-la-sierra-2018/")
    '        Dim enc As New System.Text.ASCIIEncoding()
    '        cLínea = enc.GetString(returnValue)
    '        aLíneas = Split(cLínea, Chr(10))

    '        For m = 0 To aLíneas.Length - 1
    '            If aLíneas(m).Contains(cURL) Then
    '                lProcesar = True
    '            End If

    '            If aLíneas(m).Contains("</thead>") Then
    '                nÍndice = m + 2
    '                Exit For
    '            End If
    '        Next

    '        If lProcesar Then
    '            While True
    '                cLínea = Mid(aLíneas(nÍndice), 12)
    '                cLínea = Microsoft.VisualBasic.Left(cLínea, cLínea.IndexOf(Chr(34)))

    '                Select Case cLínea
    '                    Case "national"
    '                        cTipo = "Nacional"

    '                    Case "local"
    '                        cTipo = "Local"

    '                    Case "regional"
    '                        cTipo = "Autonómico"
    '                End Select

    '                cLínea = Mid(aLíneas(nÍndice + 1), 28)
    '                nDía = Val(Microsoft.VisualBasic.Left(cLínea, 2))
    '                cLínea = Mid(cLínea, cLínea.IndexOf("de ") + 4)

    '                Select Case Microsoft.VisualBasic.Left(cLínea, cLínea.IndexOf("</td>"))
    '                    Case "enero"
    '                        nMes = 1

    '                    Case "febrero"
    '                        nMes = 2

    '                    Case "marzo"
    '                        nMes = 3

    '                    Case "abril"
    '                        nMes = 4

    '                    Case "mayo"
    '                        nMes = 5

    '                    Case "junio"
    '                        nMes = 6

    '                    Case "julio"
    '                        nMes = 7

    '                    Case "agosto"
    '                        nMes = 8

    '                    Case "septiembre"
    '                        nMes = 9

    '                    Case "octubre"
    '                        nMes = 10

    '                    Case "noviembre"
    '                        nMes = 11

    '                    Case "diciembre"
    '                        nMes = 12
    '                End Select

    '                dFecha = New Date(Val(txtAño.Text), nMes, nDía)

    '                cSQL = "SELECT * FROM festivos WHERE fecha = " + DtoSQL(dFecha) + " AND poblacion = " + GrabaComillas(dtTiendas.Rows(n)("poblacion"))
    '                dtTemporal = CargaTabla(cSQL)

    '                If dtTemporal.Rows.Count = 0 Then
    '                    cSQL = "INSERT INTO festivos (fecha, poblacion, tipo) VALUES("
    '                    cSQL += DtoSQL(dFecha) + ", "
    '                    cSQL += GrabaComillas(dtTiendas.Rows(n)("poblacion")) + ", "
    '                    cSQL += GrabaComillas(cTipo) + ")"

    '                    cmdMySQL = New MySqlCommand(cSQL, conn)

    '                    Try
    '                        cmdMySQL.ExecuteNonQuery()
    '                    Catch ex As Exception
    '                        Dim st As StackTrace
    '                        st = New StackTrace(ex, True)
    '                        Dim obj As New FrmError(ex, "Modificar apertura", st)
    '                        Dim nResultado As Integer

    '                        nResultado = obj.ShowDialog(Me)
    '                        If nResultado = DialogResult.Cancel Then Me.Close()
    '                    End Try
    '                End If

    '                nÍndice += 6
    '                If aLíneas(nÍndice) = "</tbody>" Then Exit While
    '            End While
    '        End If
    '    Next

    '    conn.Close()
    '    Me.Close()
    'End Sub
End Class