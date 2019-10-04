<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOperador
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
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtExtensión = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCambiarPassword = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIDIncidencias = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCategoría = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.picIcono = New System.Windows.Forms.PictureBox()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(113, 12)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(336, 20)
        Me.txtNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Extensión"
        '
        'txtExtensión
        '
        Me.txtExtensión.Location = New System.Drawing.Point(113, 38)
        Me.txtExtensión.MaxLength = 5
        Me.txtExtensión.Name = "txtExtensión"
        Me.txtExtensión.Size = New System.Drawing.Size(51, 20)
        Me.txtExtensión.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "e-mail"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(113, 64)
        Me.txtemail.MaxLength = 128
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(336, 20)
        Me.txtemail.TabIndex = 5
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(10, 419)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(91, 419)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCambiarPassword
        '
        Me.btnCambiarPassword.Location = New System.Drawing.Point(36, 366)
        Me.btnCambiarPassword.Name = "btnCambiarPassword"
        Me.btnCambiarPassword.Size = New System.Drawing.Size(112, 23)
        Me.btnCambiarPassword.TabIndex = 16
        Me.btnCambiarPassword.Text = "&Cambiar password"
        Me.btnCambiarPassword.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "ID Incidencias"
        '
        'txtIDIncidencias
        '
        Me.txtIDIncidencias.Location = New System.Drawing.Point(113, 116)
        Me.txtIDIncidencias.MaxLength = 5
        Me.txtIDIncidencias.Name = "txtIDIncidencias"
        Me.txtIDIncidencias.Size = New System.Drawing.Size(51, 20)
        Me.txtIDIncidencias.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(69, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Login"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(113, 90)
        Me.txtLogin.MaxLength = 60
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(336, 20)
        Me.txtLogin.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Categoría e-mail"
        '
        'txtCategoría
        '
        Me.txtCategoría.Location = New System.Drawing.Point(113, 142)
        Me.txtCategoría.MaxLength = 128
        Me.txtCategoría.Name = "txtCategoría"
        Me.txtCategoría.Size = New System.Drawing.Size(336, 20)
        Me.txtCategoría.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Color e-mail"
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(113, 168)
        Me.txtColor.MaxLength = 128
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(336, 20)
        Me.txtColor.TabIndex = 13
        '
        'picIcono
        '
        Me.picIcono.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picIcono.Location = New System.Drawing.Point(48, 231)
        Me.picIcono.Name = "picIcono"
        Me.picIcono.Size = New System.Drawing.Size(100, 100)
        Me.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcono.TabIndex = 17
        Me.picIcono.TabStop = False
        '
        'picImagen
        '
        Me.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImagen.Location = New System.Drawing.Point(227, 231)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(222, 211)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 18
        Me.picImagen.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(79, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Icono"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(313, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Imagen"
        '
        'FrmOperador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(471, 465)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.picIcono)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCategoría)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtIDIncidencias)
        Me.Controls.Add(Me.btnCambiarPassword)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtExtensión)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmOperador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.picIcono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtExtensión As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCambiarPassword As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIDIncidencias As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCategoría As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtColor As TextBox
    Friend WithEvents picIcono As PictureBox
    Friend WithEvents picImagen As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
