<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmError
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmError))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnMail = New System.Windows.Forms.Button()
        Me.txtPila = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtAdiccional = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTraza = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(197, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Se ha producido el siguiente error"
        '
        'txtError
        '
        Me.txtError.BackColor = System.Drawing.Color.White
        Me.txtError.Location = New System.Drawing.Point(200, 42)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtError.Size = New System.Drawing.Size(297, 93)
        Me.txtError.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Pila de llamadas"
        '
        'btnContinuar
        '
        Me.btnContinuar.Location = New System.Drawing.Point(132, 526)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(75, 23)
        Me.btnContinuar.TabIndex = 0
        Me.btnContinuar.Text = "&Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(225, 526)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnMail
        '
        Me.btnMail.Location = New System.Drawing.Point(322, 526)
        Me.btnMail.Name = "btnMail"
        Me.btnMail.Size = New System.Drawing.Size(75, 23)
        Me.btnMail.TabIndex = 2
        Me.btnMail.Text = "&Mail"
        Me.btnMail.UseVisualStyleBackColor = True
        '
        'txtPila
        '
        Me.txtPila.Location = New System.Drawing.Point(15, 221)
        Me.txtPila.Name = "txtPila"
        Me.txtPila.Size = New System.Drawing.Size(482, 134)
        Me.txtPila.TabIndex = 6
        Me.txtPila.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources._error
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(12, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 150)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'txtAdiccional
        '
        Me.txtAdiccional.BackColor = System.Drawing.Color.White
        Me.txtAdiccional.Location = New System.Drawing.Point(200, 163)
        Me.txtAdiccional.Multiline = True
        Me.txtAdiccional.Name = "txtAdiccional"
        Me.txtAdiccional.ReadOnly = True
        Me.txtAdiccional.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdiccional.Size = New System.Drawing.Size(297, 52)
        Me.txtAdiccional.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Información adiccional"
        '
        'txtTraza
        '
        Me.txtTraza.Location = New System.Drawing.Point(15, 386)
        Me.txtTraza.Name = "txtTraza"
        Me.txtTraza.Size = New System.Drawing.Size(482, 134)
        Me.txtTraza.TabIndex = 10
        Me.txtTraza.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 361)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Traza"
        '
        'FrmError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 571)
        Me.Controls.Add(Me.txtTraza)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAdiccional)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPila)
        Me.Controls.Add(Me.btnMail)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtError)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Error de programa"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtError As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnContinuar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnMail As Button
    Friend WithEvents txtPila As RichTextBox
    Friend WithEvents txtAdiccional As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTraza As RichTextBox
    Friend WithEvents Label4 As Label
End Class
