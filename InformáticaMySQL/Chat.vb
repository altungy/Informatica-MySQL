#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmChat
    Private cDestinatario, cRemitente As String
    Private dtChat As DataTable
    Private connMySQL As MySqlConnection
    Private nChat As Integer
    Private cSentido As Char
    'Private _passedText As String

    'Public Property [PassedText]() As String
    '    Get
    '        Return _passedText
    '    End Get
    '    Set(ByVal Value As String)
    '        _passedText = Value
    '    End Set
    'End Property

    Public Sub New(ByVal nParámetro As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nChat = nParámetro

        If nChat = 0 Then
            cSentido = "R"
        Else
            cSentido = "D"
            My.Computer.Audio.Play(My.Resources.horn, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nResultado As Integer
        Dim cSQL As String
        Dim cmd As MySqlCommand

        'nChat = Val(_passedText)
        If nChat = 0 Then cSentido = "R" Else cSentido = "D"

        connMySQL = New MySqlConnection(Conexión())

        If nChat = 0 Then
            Dim obj As New FrmParaChat()

            nResultado = obj.ShowDialog
            cDestinatario = obj.txtCon.Text
            obj.Dispose()
            obj = Nothing

            If nResultado = DialogResult.OK Then
                Me.Text = "Chat V04/19 - Para " + NombreUsuario(cDestinatario)
                cSQL = "INSERT INTO cabchat(de, para, cerrado) VALUES("
                cSQL += GrabaComillas(cUsuario) + ", "
                cSQL += GrabaComillas(cDestinatario) + ", 0)"
                cmd = New MySqlCommand(cSQL, connMySQL)
                connMySQL.Open()

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim st As StackTrace
                    st = New StackTrace(ex, True)
                    Dim obj2 As New FrmError(ex, "Alta chat", st)

                    nResultado = obj2.ShowDialog(Me)
                    If nResultado = DialogResult.Cancel Then Me.Close()
                End Try

                connMySQL.Close()

                cSQL = "SELECT idchat FROM cabchat ORDER BY idchat DESC LIMIT 1"
                dtChat = CargaTabla(cSQL)
                nChat = dtChat.Rows(0)("idchat")
            End If
        Else
            cSQL = "SELECT de FROM cabchat WHERE idchat = " + nChat.ToString
            dtChat = CargaTabla(cSQL)
            cRemitente = dtChat.Rows(0)("de")
            Me.Text = "Chat V04/19 - De " + NombreUsuario(cRemitente)
            nResultado = DialogResult.OK
        End If

        If nResultado = DialogResult.OK Then
            CargaChat()
            tActualiza.Start()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub CargaChat()
        Dim cSQL As String
        Static nRegistros As Integer = 0

        cSQL = "SELECT sentido, hora, mensaje FROM linchat WHERE idchat = " + nChat.ToString + " ORDER BY hora DESC"
        dtChat = CargaTabla(cSQL)

        With dvChat
            .ReadOnly = True
            .DataSource = dtChat
            .DataMember = dtChat.TableName
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
            .ColumnHeadersDefaultCellStyle.Font = New Font(dvChat.Font, FontStyle.Bold)

            .Columns(0).Visible = False

            With .Columns(1)
                .HeaderText = "Hora"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(2)
                .HeaderText = "Mensaje"
                .Width = 696
            End With

            For n = 0 To dvChat.RowCount - 1
                If dvChat.Rows(n).Cells(0).Value = "R" Then
                    dvChat.Rows(n).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    dvChat.Rows(n).DefaultCellStyle.ForeColor = Color.Green
                End If
            Next
        End With

        For Each row As DataGridViewRow In dvChat.SelectedRows
            row.Selected = False
        Next

        If nRegistros <> dtChat.Rows.Count Then
            If dtChat.Rows(0)("mensaje") = "zumbido" Then
                Shake()
            End If

            System.Media.SystemSounds.Beep.Play()
            nRegistros = dtChat.Rows.Count
        End If
    End Sub

    Private Sub Shake()
        My.Computer.Audio.Play(My.Resources.laser, AudioPlayMode.Background)

        For n = 1 To 1000
            Me.Left -= 10
            Me.Left += 10
        Next
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nResultado As Integer

        If String.IsNullOrEmpty(txtMensaje.Text) Then Return

        cSQL = "INSERT INTO linchat(idchat, sentido, hora, mensaje) VALUES("
        cSQL += nChat.ToString + ", "
        cSQL += GrabaComillas(cSentido) + ", "
        cSQL += GrabaComillas(Now.ToString("HH:mm:ss")) + ", "
        cSQL += GrabaComillas(txtMensaje.Text) + ")"
        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Línea chat", st)

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        End Try

        connMySQL.Close()
        CargaChat()
        txtMensaje.Text = ""
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nResultado As Integer

        cSQL = "SELECT cerrado FROM cabchat WHERE idchat = " + nChat.ToString
        dtChat = CargaTabla(cSQL)

        If dtChat.Rows.Count > 0 Then

            If dtChat.Rows(0)("cerrado") = 1 Then
                cSQL = "DELETE FROM cabchat WHERE idchat = " + nChat.ToString
            Else
                cSQL = "UPDATE cabchat SET cerrado = 1 WHERE idchat = " + nChat.ToString
            End If

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim st As StackTrace
                st = New StackTrace(ex, True)
                Dim obj As New FrmError(ex, "Cierre chat", st)

                nResultado = obj.ShowDialog(Me)
                If nResultado = DialogResult.Cancel Then Me.Close()
            End Try

            connMySQL.Close()
        End If

        lChatAbierto = False
    End Sub

    Private Sub TActualiza_Tick(sender As Object, e As EventArgs) Handles tActualiza.Tick
        Dim cSQL As String
        Dim lCerrado As Boolean = False

        cSQL = "SELECT cerrado FROM cabchat WHERE idchat = " + nChat.ToString
        dtChat = CargaTabla(cSQL)

        If dtChat.Rows.Count = 0 Then
            lCerrado = True
        Else
            If dtChat.Rows(0)("cerrado") = 1 Then
                lCerrado = True
            End If
        End If

        If lCerrado Then
            tActualiza.Stop()
            MsgBox("La otra parte ha cerrado el chat", MsgBoxStyle.Information, "Chat")
        Else
            CargaChat()
        End If
    End Sub

    Private Sub BtnBuzz_Click(sender As Object, e As EventArgs) Handles btnBuzz.Click
        txtMensaje.Text = "zumbido"
        BtnEnviar_Click(sender, e)
        Threading.Thread.Sleep(500)
    End Sub

    Private Function NombreUsuario(ByVal cCódigo As String) As String
        Dim cNombre As String = ""

        Select Case cCódigo
            Case "Agus"
                cNombre = "Agustín Moreno"

            Case "alberto"
                cNombre = "Alberto Macho"

            Case "calin"
                cNombre = "Calin Orasanu"

            Case "fernando"
                cNombre = "Fernando García-Monzón"

            Case "ignacio"
                cNombre = "Ignacio Lancho"

            Case "iker"
                cNombre = "Iker de Miguel"

            Case "juancar"
                cNombre = "Juan Carlos Campos"

            Case "miguel"
                cNombre = "Miguel Juez"

            Case "rafael"
                cNombre = "Rafael Altungy"
        End Select

        Return (cNombre)
    End Function
End Class