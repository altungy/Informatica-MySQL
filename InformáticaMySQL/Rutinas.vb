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
#Disable Warning CA5351
#Disable Warning IDE0067
#Disable Warning IDE0068

Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Microsoft.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Exchange.WebServices.Data
Imports System.ComponentModel

Public Module Rutinas
    Public cUsuario As String
    Public nUsuario As String
    Public nÚltimaIncidencia As Integer
    Public dÚltimoCorreo As DateTime = #01/01/1900#
    Public lChatAbierto As Boolean = False

    Public Sub MuestraForm(ByVal oForm As Form, ByVal cTítulo As String, ByVal cNombre As String, ByVal nIcono As Integer)
        Dim oControl As Control

        For Each oControl In frmMenú.TabControl.Controls
            If oControl.Name = cNombre Then
                frmMenú.TabControl.SelectedTab = oControl
                Return
            End If
        Next

        Dim tp As New TabPage

        oForm.TopLevel = False
        oForm.Location = New Point((frmMenú.TabControl.Width - oForm.Width) / 2, (frmMenú.TabControl.Height - oForm.Height) / 2)
        frmMenú.TabControl.TabPages.Add(tp)
        tp.Text = cTítulo
        tp.Name = cNombre
        frmMenú.TabControl.SelectedTab = tp
        tp.Controls.Add(oForm)
        tp.ImageIndex = nIcono
        tp.BackColor = System.Drawing.Color.White

        oForm.Show()
        oForm.Location = New Point(oForm.Location.X, oForm.Location.Y - 100)
    End Sub

    Public Sub MuestraForm(ByVal oForm, ByVal cTítulo, ByVal cNombre, ByVal cParámetro, ByVal nIcono)
        Dim oControl As Control

        For Each oControl In frmMenú.TabControl.Controls
            If oControl.Name = cNombre Then
                frmMenú.TabControl.SelectedTab = oControl
                Return
            End If
        Next

        Dim tp As New TabPage

        oForm.TopLevel = False
        oForm.Location = New Point((frmMenú.TabControl.Width - oForm.Width) / 2, (frmMenú.TabControl.Height - oForm.Height) / 2)
        frmMenú.TabControl.TabPages.Add(tp)
        tp.Text = cTítulo
        tp.Name = cNombre
        frmMenú.TabControl.SelectedTab = tp
        tp.Controls.Add(oForm)
        oForm.PassedText = cParámetro
        tp.ImageIndex = nIcono
        oForm.Show()
    End Sub

    Public Function FormVisible(ByVal cTítulo As String, Optional ByVal lMensaje As Boolean = True) As Boolean
        Dim oControl As Control

        For Each oControl In frmMenú.TabControl.Controls
            If oControl.Text = cTítulo Then
                If lMensaje Then MsgBox("Por favor cierre " + StrConv(cTítulo, VbStrConv.Lowercase))
                Return (True)
            End If
        Next

        Return (False)
    End Function

    Public Sub HideTabPage(ByVal tc As TabControl, ByVal tp As TabPage)
        If tc.TabPages.Contains(tp) Then tc.TabPages.Remove(tp)
    End Sub

    Public Sub ShowTabPage(ByVal tc As TabControl, ByVal tp As TabPage)
        ShowTabPage(tc, tp, tc.TabPages.Count)
    End Sub

    Public Sub ShowTabPage(ByVal tc As TabControl, ByVal tp As TabPage, ByVal index As Integer)
        If tc.TabPages.Contains(tp) Then Return
        InsertTabPage(tc, tp, index)
    End Sub

    Public Sub InsertTabPage(ByVal tc As TabControl, ByVal [tabpage] As TabPage, ByVal [index] As Integer)
        If [index] < 0 Or [index] > tc.TabCount Then
            Throw New ArgumentException("Index out of Range.")
        End If
        tc.TabPages.Add([tabpage])
        If [index] < tc.TabCount - 1 Then
            Do While tc.TabPages.IndexOf([tabpage]) <> [index]
                SwapTabPages(tc, [tabpage], (tc.TabPages(tc.TabPages.IndexOf([tabpage]) - 1)))
            Loop
        End If
        tc.SelectedTab = [tabpage]
    End Sub

    Public Sub SwapTabPages(ByVal tc As TabControl, ByVal tp1 As TabPage, ByVal tp2 As TabPage)
        If tc.TabPages.Contains(tp1) = False Or tc.TabPages.Contains(tp2) = False Then
            Throw New ArgumentException("TabPages must be in the TabCotrols TabPageCollection.")
        End If
        Dim Index1 As Integer = tc.TabPages.IndexOf(tp1)
        Dim Index2 As Integer = tc.TabPages.IndexOf(tp2)
        tc.TabPages(Index1) = tp2
        tc.TabPages(Index2) = tp1

        'Uncomment the following section to overcome bugs in the Compact Framework
        'TabControl1.SelectedIndex = TabControl1.SelectedIndex 
        'Dim tp1Text, tp2Text As String
        'tp1Text = tp1.Text
        'tp2Text = tp2.Text
        'tp1.Text=tp2Text
        'tp2.Text=tp1Text
    End Sub

    Public Function CargaTabla(cSQL As String) As DataTable
        Dim tablaDA As New DataTable()
        Dim conn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=192.168.1.9; Database=decimas; User=usuario; Password=usuario"}
        Dim cmd As New MySqlClient.MySqlDataAdapter(cSQL, conn)

        cmd.Fill(tablaDA)
        cmd.Dispose()
        Return (tablaDA)
    End Function

    Public Function CargaTabla(cSQL As String, conn As MySqlClient.MySqlConnection) As DataTable
        Dim tablaDA As New DataTable()
        Dim cmd As New MySqlClient.MySqlDataAdapter(cSQL, conn)

        Try
            cmd.Fill(tablaDA)
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return (tablaDA)
    End Function

    Public Function CargaTabla(cSQL As String, conn As OdbcConnection) As DataTable
        Dim tablaDA As New DataTable()
        Dim cmd As New OdbcDataAdapter(cSQL, conn)

        Try
            cmd.Fill(tablaDA)
        Catch ex As Exception
            MsgBox(cSQL + vbCrLf + vbCrLf + ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return (tablaDA)
    End Function

    Public Function CargaTabla(cSQL As String, conn As OleDbConnection) As DataTable
        Dim tablaDA As New DataTable()
        Dim cmd As New OleDbDataAdapter(cSQL, conn)

        cmd.Fill(tablaDA)
        Return (tablaDA)
    End Function

    Public Function CargaTabla(cSQL As String, conn As SqlConnection) As DataTable
        Dim tablaDA As New DataTable()
        Dim cmd As New SqlDataAdapter(cSQL, conn)

        Try
            cmd.Fill(tablaDA)
        Catch ex As Exception
            MsgBox(cSQL + vbCrLf + vbCrLf + ex.Message)
        End Try

        Return (tablaDA)
    End Function

    ' Hash an input string and return the hash as
    ' a 32 character hexadecimal string.
    Function GetMd5Hash(ByVal input As Byte()) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(input)

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()
    End Function

    Public Function Cifra(ByVal cPlain As String) As String
        Dim bClave As Byte() = System.Text.Encoding.Unicode.GetBytes(cPlain)

        Return (GetMd5Hash(bClave))
    End Function

    Public Function GrabaComillas(ByVal cTexto As String, Optional ByVal cSufijo As String = "") As String
        If String.IsNullOrEmpty(Trim(cTexto)) Then Return (Chr(34) + Chr(34) + cSufijo)

        Return Chr(34) + Replace(cTexto, Chr(34), Chr(34) + Chr(34)) + Chr(34) + cSufijo
    End Function

    Public Function Conexión() As String
        Return ("Server=192.168.1.9; Database=decimas; User=usuario; Password=usuario")
    End Function

    'Public Function ConexiónInformática() As OleDbConnection
    '    Dim connTemp = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "Informática", Nothing).ToString)
    '    Return (connTemp)
    'End Function

    Public Function ODBC(ByVal nEmpresa As Integer) As String
        Dim cODBC As String = ""
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + nEmpresa.ToString)

        If dtTemporal.Rows.Count > 0 Then cODBC = dtTemporal.Rows(0)("odbc")

        Return cODBC
    End Function

    Public Function ConexiónCentral(ByVal cODBC As String) As OdbcConnection
        Dim conn As New OdbcConnection With {.ConnectionString = "DSN=" + cODBC + ";UID=rafael;Pwd=altungy;"}
        Return conn
    End Function

    Public Function ConexiónInformix(ByVal cEmpresa As String) As String
        Dim cCadena As String = "DSN="

        Select Case cEmpresa
            Case "ADIDAS"
                cCadena += "adodbc"
            Case "DECIMAS"
                cCadena += "deodbc"
            Case "INVAIN"
                cCadena += "invodbc"
            Case "POLINESIA"
                cCadena += "polodbc"
        End Select

        cCadena += ";UID=rafael;Pwd=altungy;"""
        Return (cCadena)
    End Function

    Public Function Provincia(ByVal xProvincia) As String
        Dim aProvincias As String() = New String() {"ÁLAVA", "ALBACETE", "ALACANT", "ALMERÍA",
         "ÁVILA", "BADAJOZ", "ILLES BALEARS", "BARCELONA", "BURGOS", "CÁCERES", "CÁDIZ",
         "CASTELLÓ", "CIUDAD REAL", "CÓRDOBA", "A CORUÑA", "CUENCA", "GIRONA", "GRANADA",
         "GUADALAJARA", "GUIPUZCOA", "HUELVA", "HUESCA", "JAÉN", "LEÓN", "LLEIDA", "LA RIOJA",
         "LUGO", "MADRID", "MÁLAGA", "MURCIA", "NAVARRA", "OURENSE", "ASTURIAS", "PALENCIA",
         "LAS PALMAS", "PONTEVEDRA", "SALAMANCA", "TENERIFE", "CANTABRIA", "SEGOVIA", "SEVILLA",
         "SORIA", "TARRAGONA", "TERUEL", "TOLEDO", "VALÈNCIA", "VALLADOLID", "VIZCAYA",
         "ZAMORA", "ZARAGOZA", "CEUTA", "MELILLA"}
        Dim nProvincia As Integer

        xProvincia = LTrim(CStr(xProvincia))
        nProvincia = Val(Left(xProvincia, 2))

        If nProvincia > 0 And nProvincia < 53 Then Return (aProvincias(nProvincia - 1))

        Return ("")
    End Function

    'Public Function País(ByVal nPaís As Integer) As String
    '    Dim conn As OdbcConnection = ConexiónCentral("deodbc")
    '    Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM paises WHERE codigo = " + nPaís.ToString, conn)
    '    Dim cPaís As String = ""

    '    If dtTemporal.Rows.Count > 0 Then cPaís = dtTemporal.Rows(0)("nombre").ToString
    '    Return cPaís
    'End Function

    Public Function País(ByVal nPaís As Integer) As String
        Dim cPaís As String = ""

        Select Case nPaís
            Case 1
                cPaís = "España"

            Case 2
                cPaís = "Portugal"

            Case 3
                cPaís = "Francia"

            Case 27
                cPaís = "Rumanía"

            Case 28
                cPaís = "Polonia"
        End Select

        Return cPaís
    End Function

    Public Function NombreEmpresa(ByVal nEmpresa As Integer) As String
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM empresas WHERE idempresa = " + nEmpresa.ToString)
        Dim cNombre As String = ""

        If dtTemporal.Rows.Count > 0 Then cNombre = dtTemporal.Rows(0)("nombre")
        Return cNombre
    End Function

    Public Function CódigoEmpresa(ByVal cEmpresa As String) As Integer
        Dim dtTemporal As DataTable = CargaTabla("SELECT * FROM empresas WHERE nombre = " + GrabaComillas(cEmpresa))
        Dim nCódigo As Integer = 0

        If dtTemporal.Rows.Count > 0 Then nCódigo = dtTemporal.Rows(0)("idempresa")
        Return nCódigo
    End Function

    Public Function Memo2Array(ByVal cTexto As String, ByVal nAncho As Short) As Array
        Dim aLíneas() As String = New String() {}
        Dim n, nRetorno, nÍndice As Integer

        If String.IsNullOrEmpty(cTexto) Then
            ReDim aLíneas(0)
            aLíneas(0) = ""
        Else
            nÍndice = 0

            While Len(cTexto) > 0
                nRetorno = InStr(cTexto, Chr(13) + Chr(10), CompareMethod.Binary)
                ReDim Preserve aLíneas(nÍndice)

                If nRetorno > 0 And nRetorno <= nAncho + 1 Then
                    aLíneas(nÍndice) = Microsoft.VisualBasic.Left(cTexto, nRetorno - 1)
                    cTexto = Microsoft.VisualBasic.Mid(cTexto, nRetorno + 2)
                Else
                    If Len(cTexto) <= nAncho Then
                        aLíneas(nÍndice) = cTexto
                        Exit While
                    End If

                    n = nAncho

                    While Microsoft.VisualBasic.Mid(cTexto, n, 1) <> " "
                        n -= 1
                    End While

                    aLíneas(nÍndice) = Microsoft.VisualBasic.Left(cTexto, n - 1)
                    cTexto = Microsoft.VisualBasic.Mid(cTexto, n + 1)
                End If

                nÍndice += 1
            End While
        End If

        Return (aLíneas)
    End Function

    Public Function DtoSQL(ByVal cFecha As String) As String
        Return (Chr(34) + Microsoft.VisualBasic.Right(cFecha, 4) + "-" + Microsoft.VisualBasic.Mid(cFecha, 4, 2) + "-" + Microsoft.VisualBasic.Left(cFecha, 2) + Chr(34))
    End Function

    Public Function DtoSQL(ByVal dFecha As Date) As String
        Return (DtoSQL(dFecha.ToString("dd/MM/yyyy")))
    End Function

    Public Function SacaDato(ByVal cTexto As String) As String
        Return (Microsoft.VisualBasic.Left(cTexto, InStr(cTexto, Chr(255)) - 1))
    End Function

    Public Function CortaDato(ByVal cTexto As String) As String
        Return (Microsoft.VisualBasic.Mid(cTexto, InStr(cTexto, Chr(255)) + 1))
    End Function

    Public Function DevuelveFecha(ByVal cFecha As String) As String
        Dim nDía, nMes, nAño, n As Integer
        Dim nMáximo As Integer
        Dim lCorrecto As Boolean = True
        Dim nLetras As Integer = 0

        If Len(cFecha) < 5 Then lCorrecto = False

        For n = 1 To Len(cFecha)
            If Not EsCifra(Mid(cFecha, n, 1)) Then nLetras += 1
        Next

        If nLetras <> 2 Then lCorrecto = False

        If lCorrecto Then
            For n = 1 To Len(cFecha)
                If Not EsCifra(Mid(cFecha, n, 1)) Then Exit For
            Next

            nDía = Val(Microsoft.VisualBasic.Left(cFecha, n - 1))
            cFecha = Mid(cFecha, n + 1)

            For n = 1 To Len(cFecha)
                If Not EsCifra(Mid(cFecha, n, 1)) Then Exit For
            Next

            nMes = Val(Microsoft.VisualBasic.Left(cFecha, n - 1))
            nAño = Val(Mid(cFecha, n + 1))

            If nAño < 100 Then
                If nAño < 0 Then lCorrecto = False
                If nAño < 50 Then nAño += 2000 Else nAño += 1900
            End If

            If nMes < 1 Or nMes > 12 Then
                lCorrecto = False
            Else
                nMáximo = System.DateTime.DaysInMonth(nAño, nMes)
                If nDía < 1 Or nDía > nMáximo Then lCorrecto = False
            End If

            If lCorrecto Then
                cFecha = Trim(Str(nDía)).PadLeft(2, "0") + "/" + Trim(Str(nMes)).PadLeft(2, "0") + "/" + Trim(Str(nAño)).PadLeft(4, "0")
            Else
                cFecha = ""
            End If
        Else
            cFecha = ""
        End If

        Return (cFecha)
    End Function

    Public Function VerificaFecha(ByVal cFecha As String, ByVal lObligatoria As Boolean, Optional ByVal cMensaje As String = "") As Boolean
        Dim lCorrecto As Boolean = True

        If String.IsNullOrWhiteSpace(cFecha) Then
            If lObligatoria Then
                MsgBox(If(String.IsNullOrWhiteSpace(cMensaje), "Fecha obligatoria", cMensaje), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                Return (False)
            Else
                Return (True)
            End If
        End If

        cFecha = DevuelveFecha(cFecha)

        If Len(cFecha) = 0 Then lCorrecto = False

        If Not lCorrecto Then
            MsgBox("Fecha incorrecta", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
        End If

        Return (lCorrecto)
    End Function

    Public Function EsCifra(ByVal cLetra As Char) As Boolean
        Dim lCifra As Boolean = False

        If cLetra >= "0" And cLetra <= "9" Then lCifra = True

        Return (lCifra)
    End Function

    Public Function FechaInformix(cFecha As String) As String
        Return ("'" + Mid(cFecha, 4, 2) + "/" + Left(cFecha, 2) + Right(cFecha, 5) + "'")
    End Function

    Public Function CtoD(ByVal cFecha As String) As String
        Dim dFecha As Date = Convert.ToDateTime(cFecha)

        Return ("""" + Format(dFecha, "yyyy-MM-dd") + """")
    End Function

    Public Function NombreTienda(ByVal nTienda As Integer) As String
        Dim conn As MySqlConnection = New MySqlConnection(Conexión())
        Dim cNombre As String = ""
        Dim cSQL As String = "SELECT nombre FROM tiendas WHERE codigo = " + nTienda.ToString
        Dim dtTemporal As DataTable = CargaTabla(cSQL, conn)

        If dtTemporal.Rows.Count > 0 Then cNombre = dtTemporal.Rows(0)("nombre")

        Return (cNombre)
    End Function

    Public Function NombreProveedor(ByVal nProveedor As Integer) As String
        Dim conn As MySqlConnection = New MySqlConnection(Conexión())
        Dim cNombre As String = ""
        Dim cSQL As String = "SELECT nombre FROM proveedores WHERE idproveedor = " + nProveedor.ToString
        Dim dtTemporal As DataTable = CargaTabla(cSQL, conn)

        If dtTemporal.Rows.Count > 0 Then cNombre = dtTemporal.Rows(0)("nombre")

        Return (cNombre)
    End Function

    'Public Function CódigoProveedor(ByVal cProveedor As String) As String
    '    Dim conn As MySqlConnection = New MySqlConnection(Conexión())
    '    Dim nCódigo As Integer = 0
    '    Dim cSQL As String = "SELECT codigo FROM proveedores WHERE nombre = " + GrabaComillas(cProveedor)
    '    Dim dtTemporal As DataTable = CargaTabla(cSQL, conn)

    '    If dtTemporal.Rows.Count > 0 Then nCódigo = dtTemporal.Rows(0)("nCódigo")

    '    Return (nCódigo)
    'End Function

    Public Sub DateBox(sender As Object, e As KeyEventArgs)
        If e.KeyValue >= 96 And e.KeyValue <= 105 Then
            If sender.text.Split("/").Length - 1 = 2 Then Return

            Dim nPosición As Integer = sender.Text.IndexOf("/")

            If nPosición = -1 Then
                If Len(sender.Text) = 2 Then
                    sender.Text += "/"
                End If
            Else
                If Len(sender.Text) - Len(Replace(sender.Text, "/", "")) = 1 Then
                    If Len(sender.Text) = 5 Then
                        sender.Text += "/"
                    End If
                End If
            End If

            sender.SelectionStart = sender.Text.Length + 1
        End If
    End Sub

    Public Function PonSiglo(ByVal cFecha As String) As String
        Dim cSiglo As String = Trim(Year(Now))

        If Len(cFecha) = 6 Then
            cFecha += cSiglo
        Else
            cSiglo = Left(cSiglo, 2)

            If Len(cFecha) = 8 Then
                cFecha = Left(cFecha, 6) + cSiglo + Right(cFecha, 2)
            End If
        End If

        Return (cFecha)
    End Function

    Public Function NombrePago(ByVal nPago As Integer) As String
        Dim cNombre As String = ""
        Dim cSQL As String = "SELECT nombre FROM formasdepago WHERE idformapago = " + nPago.ToString
        Dim dtTemporal As DataTable = CargaTabla(cSQL)

        If dtTemporal.Rows.Count > 0 Then cNombre = dtTemporal.Rows(0)("nombre")

        Return (cNombre)
    End Function

    Public Function ColorBarra(ByVal sColor As String) As Color
        Dim cColor As Color = Color.White

        Select Case sColor
            Case "Verde"
                cColor = Color.Green

            Case "Rojo"
                cColor = Color.Red

            Case "Amarillo"
                cColor = Color.Yellow

            Case "Melocotón oscuro"
                cColor = Color.Brown

            Case "Azul"
                cColor = Color.Blue

            Case "Naranja"
                cColor = Color.Orange

            Case "Verde azulado"
                cColor = Color.MediumSeaGreen

            Case "Negro"
                cColor = Color.Black

            Case "Oliva oscuro"
                cColor = Color.DarkOliveGreen

            Case "Acero"
                cColor = Color.Gray
        End Select

        Return (cColor)
    End Function

    Public Function TimedMsgBox(ByVal cTexto As String, Optional ByVal nTipo As Integer = 0, Optional ByVal nTiempo As Integer = 0, Optional ByVal cTítulo As String = "") As Integer
        Dim oMensaje As New TimedMessage
        Dim nBotones As Integer
        Dim nIcono As Integer
        Dim nBotón As Integer
        Dim nResultado As Integer

        Dim nNumBotones As Integer

        nBotones = nTipo And 7

        Select Case nBotones
            Case MsgBoxStyle.OkOnly
                oMensaje.cmd1.Text = "&Aceptar"
                nNumBotones = 1

            Case MsgBoxStyle.OkCancel
                oMensaje.cmd1.Text = "&Aceptar"
                oMensaje.cmd2.Text = "&Cancelar"
                nNumBotones = 2

            Case MsgBoxStyle.AbortRetryIgnore
                oMensaje.cmd1.Text = "&Abortar"
                oMensaje.cmd2.Text = "&Reintentar"
                oMensaje.cmd3.Text = "&Ignorar"
                nNumBotones = 3

            Case MsgBoxStyle.YesNoCancel
                oMensaje.cmd1.Text = "&Si"
                oMensaje.cmd2.Text = "&No"
                oMensaje.cmd3.Text = "&Cancelar"
                nNumBotones = 3

            Case MsgBoxStyle.YesNo
                oMensaje.cmd1.Text = "&Si"
                oMensaje.cmd2.Text = "&No"
                nNumBotones = 2

            Case MsgBoxStyle.RetryCancel
                oMensaje.cmd1.Text = "&Reintentar"
                oMensaje.cmd2.Text = "&Cancelar"
                nNumBotones = 2
        End Select

        Select Case nNumBotones
            Case 1
                oMensaje.cmd2.Visible = False
                oMensaje.cmd3.Visible = False
                oMensaje.cmd1.Location = New Point(153, 106)

            Case 2
                oMensaje.cmd3.Visible = False
                oMensaje.cmd1.Location = New Point(110, 106)
                oMensaje.cmd2.Location = New Point(200, 106)

            Case 3
                oMensaje.cmd1.Location = New Point(63, 106)
                oMensaje.cmd2.Location = New Point(153, 106)
                oMensaje.cmd3.Location = New Point(243, 106)
        End Select

        nIcono = nTipo And 112

        Select Case nIcono
            Case MsgBoxStyle.Critical
                oMensaje.picCritical.Visible = True

            Case MsgBoxStyle.Exclamation
                oMensaje.picExclamation.Visible = True

            Case MsgBoxStyle.Information
                oMensaje.picInformation.Visible = True

            Case MsgBoxStyle.Question
                oMensaje.picQuestion.Visible = True
        End Select


        nBotón = nTipo And 768

        Select Case nBotón
            Case 0
                oMensaje.AcceptButton = oMensaje.cmd1

            Case 256
                oMensaje.AcceptButton = oMensaje.cmd2

            Case 512
                oMensaje.AcceptButton = oMensaje.cmd3
        End Select

        nBotón = Int(nBotón / 256) + 1

        oMensaje.lblMensaje.Text = cTexto
        oMensaje.Text = cTítulo
        oMensaje.txtResultado.Text = Trim(Str(nBotón)) + Trim(Str(nTiempo))

        oMensaje.ShowDialog()
        nResultado = Val(oMensaje.txtResultado.Text)
        oMensaje.Dispose()

        Select Case nBotones
            Case MsgBoxStyle.OkOnly
                nResultado = MsgBoxResult.Ok

            Case MsgBoxStyle.OkCancel
                If nResultado = 1 Then nResultado = MsgBoxResult.Ok Else nResultado = MsgBoxResult.Cancel

            Case MsgBoxStyle.AbortRetryIgnore
                If nResultado = 1 Then
                    nResultado = MsgBoxResult.Abort
                ElseIf nResultado = 2 Then
                    nResultado = MsgBoxResult.Retry
                Else
                    nResultado = MsgBoxResult.Ignore
                End If

            Case MsgBoxStyle.YesNoCancel
                If nResultado = 1 Then
                    nResultado = MsgBoxResult.Yes
                ElseIf nResultado = 2 Then
                    nResultado = MsgBoxResult.No
                Else
                    nResultado = MsgBoxResult.Cancel
                End If

            Case MsgBoxStyle.YesNo
                If nResultado = 1 Then nResultado = MsgBoxResult.Yes Else nResultado = MsgBoxResult.No

            Case MsgBoxStyle.RetryCancel
                If nResultado = 1 Then nResultado = MsgBoxResult.Retry Else nResultado = MsgBoxResult.Cancel
        End Select

        Return nResultado
    End Function

    Public Function FolderFromPath(ByVal servicio As ExchangeService, cPath As String, cBuzón As String) As Folder
        Try
            Dim RootFolderId As FolderId = New FolderId(WellKnownFolderName.MsgFolderRoot, cBuzón)
            Dim RootFolder As Folder = Folder.Bind(servicio, RootFolderId)
            Dim faFldArray() As String = cPath.Split("\\")
            Dim tfTargetFolder As Folder = RootFolder

            For n = 0 To faFldArray.Length - 1
                If faFldArray(n).Length <> 0 Then
                    Dim fview As FolderView = New FolderView(1)
                    Dim sf As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, faFldArray(n))
                    Dim ffResult As FindFoldersResults = servicio.FindFolders(tfTargetFolder.Id, sf, fview)

                    If ffResult.TotalCount = 0 Then
                        Throw New Exception("Folder Not Found")
                    Else
                        tfTargetFolder = ffResult.Folders(0)
                    End If
                End If
            Next

            Return tfTargetFolder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub GeneraGráfico(ByVal aDatos, ByVal oChart, ByVal cTítulo)
        Dim nMáximo As Integer = 0

        With oChart
            .Series.Clear()
            .ResetAutoValues()
            My.Application.DoEvents()

            If cTítulo <> String.Empty Then
                .Titles.Add("Título")
                .Titles(0).Font = New System.Drawing.Font("Arial", 16, FontStyle.Bold)
                .Titles(0).Text = cTítulo
            End If

            For n = 0 To aDatos.getlength(0) - 1
                .Series.Add(n * 2)
                .Series(n * 2).CustomProperties = "PointWidth = 2"
                .Series.Add(n * 2 + 1)
                .Series(n * 2).Points.AddY(aDatos(n, 2))
                .Series(n * 2).Color = ColorBarra(aDatos(n, 1))
                .Series(n * 2 + 1).Points.AddY(0)
                .Series(n * 2 + 1).IsVisibleInLegend = False

                If cTítulo <> String.Empty Then
                    .Series(n * 2).Name = aDatos(n, 0)
                End If

                nMáximo = Math.Max(nMáximo, aDatos(n, 2))
            Next

            .ChartAreas(0).AxisY.Minimum = 0
            .ChartAreas(0).AxisY.Maximum = nMáximo + 1

            If nMáximo < 5 Then
                .ChartAreas(0).AxisY.Interval = 1
            Else
                .ChartAreas(0).AxisY.Interval = Math.Ceiling(nMáximo \ 5)
            End If

            .ChartAreas(0).RecalculateAxesScale()
        End With
    End Sub

    Public Function CabeceraMail() As String
        Dim cTexto As String
        Dim CR As String = Chr(13)

        cTexto = "<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40""><head><meta http-equiv=Content-Type content=""text/html; charset=iso-8859-1""><meta name=Generator content=""Microsoft Word 14 (filtered medium)""><!--[if !mso]><style>v\:* {behavior:url(#default#VML);}"
        cTexto += CR + "o\:* {behavior:url(#default#VML);}"
        cTexto += CR + "w\:* {behavior:url(#default#VML);}"
        cTexto += CR + ".shape {behavior:url(#default#VML);}"
        cTexto += CR + "</style><![endif]--><style><!--"
        cTexto += CR + "/* Font Definitions */"
        cTexto += CR + "@font-face"
        cTexto += CR + "{font-family:Calibri;"
        cTexto += CR + "panose-1:2 15 5 2 2 2 4 3 2 4;}"
        cTexto += CR + "@font-face"
        cTexto += CR + "{font-family:Tahoma;"
        cTexto += CR + "panose-1:2 11 6 4 3 5 4 4 2 4;}"
        cTexto += CR + "/* Style Definitions */"
        cTexto += CR + "p.MsoNormal, li.MsoNormal, div.MsoNormal"
        cTexto += CR + "{margin:0cm;"
        cTexto += CR + "margin-bottom:.0001pt;"
        cTexto += CR + "font-size:11.0pt;"
        cTexto += CR + "font-family:""Calibri"",""sans-serif"";"
        cTexto += CR + "mso-fareast-language:EN-US;}"
        cTexto += CR + "a:      link, span.MsoHyperlink"
        cTexto += CR + "{mso-style-priority:99;"
        cTexto += CR + "color:blue;"
        cTexto += CR + "text-decoration:underline;}"
        cTexto += CR + "a:      visited, span.MsoHyperlinkFollowed"
        cTexto += CR + "{mso-style-priority:99;"
        cTexto += CR + "color:purple;"
        cTexto += CR + "text-decoration:underline;}"
        cTexto += CR + "p.MsoAcetate, li.MsoAcetate, div.MsoAcetate"
        cTexto += CR + "{mso-style-priority:99;"
        cTexto += CR + "mso-style-link:""Texto de globo Car"";"
        cTexto += CR + "margin:0cm;"
        cTexto += CR + "margin-bottom:.0001pt;"
        cTexto += CR + "font-size:8.0pt;"
        cTexto += CR + "font-family:""Tahoma"",""sans-serif"";"
        cTexto += CR + "mso-fareast-language:EN-US;}"
        cTexto += CR + "span.EstiloCorreo17()"
        cTexto += CR + "{mso-style-type:personal-compose;"
        cTexto += CR + "font-family:""Calibri"",""sans-serif"";"
        cTexto += CR + "color:windowtext;}"
        cTexto += CR + "span.TextodegloboCar()"
        cTexto += CR + "{mso-style-name:""Texto de globo Car"";"
        cTexto += CR + "mso-style-priority:99;"
        cTexto += CR + "mso-style-link:""Texto de globo"";"
        cTexto += CR + "font-family:""Tahoma"",""sans-serif"";}"
        cTexto += CR + ".MsoChpDefault()"
        cTexto += CR + "{mso-style-type:export-only;"
        cTexto += CR + "font-family:""Calibri"",""sans-serif"";"
        cTexto += CR + "mso-fareast-language:EN-US;}"
        cTexto += CR + "@page WordSection1"
        cTexto += CR + "{size:612.0pt 792.0pt;"
        cTexto += CR + "margin:70.85pt 3.0cm 70.85pt 3.0cm;}"
        cTexto += CR + "div.WordSection1()"
        cTexto += CR + "{page:WordSection1;}"
        cTexto += CR + "--></style><!--[if gte mso 9]><xml>"
        cTexto += CR + "<o:shapedefaults v:ext=""edit"" spidmax=""1026"" />"
        cTexto += CR + "</xml><![endif]--><!--[if gte mso 9]><xml>"
        cTexto += CR + "<o:shapelayout v:ext=""edit"">"
        cTexto += CR + "<o:idmap v:ext=""edit"" data=""1"" />"

        cTexto += "</o:shapelayout></xml><![endif]--></head><body lang=ES link=blue vlink=purple><div class=WordSection1><p class=MsoNormal>"

        Return (cTexto)
    End Function

    Public Function PiéMail() As String
        Dim cTexto As String

        cTexto = "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>"

        Select Case Environment.UserName
            Case "rafael"
                cTexto += "Rafael Altungy"

            Case "miguel"
                cTexto += "Miguel Juez"

            Case "juancar"
                cTexto += "Juan Carlos Campos"

            Case "fernando"
                cTexto += "Fernando García-Monzón"

            Case "calin"
                cTexto += "Calin Orasanu"

            Case "agus"
                cTexto += "Agustín Moreno"

            Case Else
                cTexto += "Help Desk"
        End Select

        cTexto += "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><img width=341 height=33 id=""Imagen_x0020_1"" src=""\\decimas2018\Departamentos\Informatica\Software\Recursos\LogoPie.jpg"" alt=""Descripción: DecimasPolinesia peq""><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Campus Empresarial Tribeca</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Ctra. Fuencarral, 44</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Edificio 9, L-18<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>28108 - Alcobendas (Madrid)</span><span style='mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Dto. De Informática y Comunicaciones<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'>Tfno. 913295488 - Ext. "

        Select Case Environment.UserName
            Case "rafael"
                cTexto += "2053"

            Case "miguel"
                cTexto += "2012"

            Case "juancar"
                cTexto += "2037"

            Case "fernando"
                cTexto += "2040"

            Case "calin"
                cTexto += "2125"

            Case "agus"
                cTexto += "2236"

            Case Else
                cTexto += "2300"
        End Select

        cTexto += "<o:p></o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span><hr></hr></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='mso-fareast-language:ES'><o:p>&nbsp;</o:p></span></p><p class=MsoNormal><span style='font-size:7.5pt;color:#A6A6A6;mso-fareast-language:ES'>"
        cTexto += "Este correo electrónico, así como cualquiera de sus anexos, puede contener información confidencial. Su contenido es para uso exclusivo de sus destinatarios, por lo que queda prohibida la difusión, copia o utilización de dicha información por terceros. Si usted lo recibiera por error, por favor, notifíquelo al remitente y elimine el mensaje con todas sus copias."
        cTexto += "<br><br>SPORT STREET, S.L., como Responsable del tratamiento, le informa de que la finalidad del tratamiento es gestionar las comunicaciones realizadas a través del correo electrónico sobre los servicios prestados, información comercial o actividades realizadas por el Responsable. Sus datos se conservarán mientras exista un interés general mutuo para ello, con la legitimación del consentimiento del interesado o por la ejecución o desarrollo de un acuerdo. Sus datos no se cederán a terceros, salvo obligación legal o para alcanzar el fin antes expuesto. Podrá ejercer sus derechos de acceso, rectificación, supresión, oposición, así como otros derechos desarrollados en el Reglamento (UE) 2016/679, Reglamento General de Protección de Datos, enviado un email a atencionalcliente@decimas.es."
        cTexto += "</span><span style='color:#A6A6A6;mso-fareast-language:ES'><o:p></o:p></span></p><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>"
        Return (cTexto)
    End Function

    Public Function FechaBlanco(ByVal dFecha) As String
        If String.IsNullOrEmpty(dFecha.ToString) Then Return ("")
        If VarType(dFecha) <> VariantType.Date Then Return ("")

        Return (Format(dFecha, "dd/MM/yyyy"))
    End Function
End Module