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

Public Class FrmOperador
    Private _passedText As String
    Private nCódigo As Integer
    Private cPassword As String = ""

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmOperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtOperador As DataTable

        nCódigo = Val(_passedText)
        picIcono.Tag = ""
        picImagen.Tag = ""

        If nCódigo > 0 Then
            Dim cSQL As String = "SELECT * FROM operadores WHERE idoperador = " + _passedText
            dtOperador = CargaTabla(cSQL)

            txtNombre.Text = dtOperador.Rows(0)("nombre")
            txtExtensión.Text = dtOperador.Rows(0)("extension")
            txtemail.Text = dtOperador.Rows(0)("email")
            txtLogin.Text = dtOperador.Rows(0)("login")
            txtIDIncidencias.Text = dtOperador.Rows(0)("idincidencias").ToString
            txtCategoría.Text = dtOperador.Rows(0)("nombrecategoria").ToString
            txtColor.Text = dtOperador.Rows(0)("colorcategoria").ToString

            If Not String.IsNullOrEmpty(dtOperador.Rows(0)("icono").ToString) Then
                picIcono.Image = Image.FromFile(dtOperador.Rows(0)("icono"))
                picIcono.Tag = dtOperador.Rows(0)("icono")
            End If

            If Not String.IsNullOrEmpty(dtOperador.Rows(0)("imagen").ToString) Then
                picImagen.Image = Image.FromFile(dtOperador.Rows(0)("imagen"))
                picImagen.Tag = dtOperador.Rows(0)("imagen")
            End If
        Else
            btnCambiarPassword.Visible = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnCambiarPassword_Click(sender As Object, e As EventArgs) Handles btnCambiarPassword.Click
        If cUsuario = _passedText Then
            Dim oVentana As New frmCambiarPassword With {.PassedText = _passedText}
            oVentana.ShowDialog()
            cPassword = Cifra(oVentana.txtPassword1.Text)
            oVentana.Dispose()
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim conn = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = Conexión()}

        If nCódigo = 0 Then
            cSQL = "INSERT INTO operadores(nombre, extension, email, login, idincidencias, nombrecategoria, colorcategoria, icono, imagen) VALUES("
            cSQL += GrabaComillas(txtNombre.Text) + ", "
            cSQL += GrabaComillas(txtExtensión.Text) + ", "
            cSQL += GrabaComillas(txtemail.Text) + ", "
            cSQL += GrabaComillas(txtLogin.Text) + ", "
            cSQL += txtIDIncidencias.Text + ", "
            cSQL += GrabaComillas(txtCategoría.Text) + ", "
            cSQL += GrabaComillas(txtColor.Text) + ", "
            cSQL += GrabaComillas(picIcono.Tag.Replace("\", "\\")) + ", "
            cSQL += GrabaComillas(picImagen.Tag.Replace("\", "\\")) + ")"
        Else
            cSQL = "UPDATE operadores SET "
            cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
            cSQL += "extension = " + GrabaComillas(txtExtensión.Text) + ", "
            cSQL += "email = " + GrabaComillas(txtemail.Text) + ", "
            cSQL += "login = " + GrabaComillas(txtLogin.Text) + ", "
            cSQL += "idincidencias = " + txtIDIncidencias.Text + ", "
            cSQL += "nombrecategoria = " + GrabaComillas(txtCategoría.Text) + ", "
            cSQL += "colorcategoria = " + GrabaComillas(txtColor.Text) + ", "
            cSQL += "icono = " + GrabaComillas(picIcono.Tag.Replace("\", "\\")) + ", "
            cSQL += "imagen = " + GrabaComillas(picImagen.Tag.Replace("\", "\\"))
            cSQL += " WHERE idoperador = " + _passedText
        End If

        cmd = New MySqlCommand(cSQL, conn)
        conn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()

        If picImagen.Tag <> String.Empty Then frmMenú.picUsuario.Image = Image.FromFile(picIcono.Tag)
        Me.Close()
    End Sub

    Private Sub PicIcono_DoubleClick(sender As Object, e As EventArgs) Handles picIcono.DoubleClick
        Dim fImagen As New frmEscogerImagen(picIcono.Tag)

        If fImagen.ShowDialog() = DialogResult.OK Then
            picIcono.Image = Image.FromFile(fImagen.picImagen.Tag)
            picIcono.Tag = fImagen.picImagen.Tag
        End If
    End Sub

    Private Sub PicImagen_DoubleClick(sender As Object, e As EventArgs) Handles picImagen.DoubleClick
        Dim fImagen As New frmEscogerImagen(picImagen.Tag)

        If fImagen.ShowDialog() = DialogResult.OK Then
            picImagen.Image = Image.FromFile(fImagen.picImagen.Tag)
            picImagen.Tag = fImagen.picImagen.Tag
        End If
    End Sub
End Class