Public Class frmEscogerImagen
    Private cImagen

    Public Sub New(ByVal cFichero As String)
        ' This call is required by the designer.
        InitializeComponent()

        If cFichero = Nothing Then
            cImagen = ""
        Else
            cImagen = cFichero
        End If
    End Sub

    Private Sub EscogerImagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(cImagen) Then
            txtImagen.Text = cImagen
            picImagen.Image = Image.FromFile(cImagen)
        End If
    End Sub

    Private Sub BtnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Dim fd As OpenFileDialog = New OpenFileDialog With {
            .Title = "Escoger imagen",
            .InitialDirectory = "\\decimas2018\Departamentos\Informatica\ICONOS INFORMATICA\",
            .Filter = "Ficheros imagen|*.jpg;*.png;*.gif;*.bmp",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }

        If fd.ShowDialog() = DialogResult.OK Then
            txtImagen.Text = fd.FileName
            picImagen.Image = Image.FromFile(txtImagen.Text)
            picImagen.Tag = fd.FileName
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class