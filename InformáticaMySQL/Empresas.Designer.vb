<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpresas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCódigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTeléfono = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPoblación = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPostal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDirección = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCIF = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dvEmpresas = New System.Windows.Forms.DataGridView()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtODBC = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.dvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCódigo
        '
        Me.txtCódigo.BackColor = System.Drawing.Color.White
        Me.txtCódigo.Location = New System.Drawing.Point(95, 12)
        Me.txtCódigo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCódigo.MaxLength = 6
        Me.txtCódigo.Name = "txtCódigo"
        Me.txtCódigo.ReadOnly = True
        Me.txtCódigo.Size = New System.Drawing.Size(49, 22)
        Me.txtCódigo.TabIndex = 1
        Me.txtCódigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(95, 39)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(407, 22)
        Me.txtNombre.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'txtTeléfono
        '
        Me.txtTeléfono.BackColor = System.Drawing.Color.White
        Me.txtTeléfono.Location = New System.Drawing.Point(95, 224)
        Me.txtTeléfono.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTeléfono.MaxLength = 15
        Me.txtTeléfono.Name = "txtTeléfono"
        Me.txtTeléfono.ReadOnly = True
        Me.txtTeléfono.Size = New System.Drawing.Size(121, 22)
        Me.txtTeléfono.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 226)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 17)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Teléfono"
        '
        'txtProvincia
        '
        Me.txtProvincia.BackColor = System.Drawing.Color.White
        Me.txtProvincia.Location = New System.Drawing.Point(95, 167)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProvincia.MaxLength = 50
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(407, 22)
        Me.txtProvincia.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Provincia"
        '
        'txtPoblación
        '
        Me.txtPoblación.BackColor = System.Drawing.Color.White
        Me.txtPoblación.Location = New System.Drawing.Point(236, 142)
        Me.txtPoblación.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblación.MaxLength = 50
        Me.txtPoblación.Name = "txtPoblación"
        Me.txtPoblación.ReadOnly = True
        Me.txtPoblación.Size = New System.Drawing.Size(265, 22)
        Me.txtPoblación.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(151, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Población"
        '
        'txtPostal
        '
        Me.txtPostal.BackColor = System.Drawing.Color.White
        Me.txtPostal.Location = New System.Drawing.Point(95, 142)
        Me.txtPostal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPostal.MaxLength = 5
        Me.txtPostal.Name = "txtPostal"
        Me.txtPostal.ReadOnly = True
        Me.txtPostal.Size = New System.Drawing.Size(49, 22)
        Me.txtPostal.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Postal"
        '
        'txtDirección
        '
        Me.txtDirección.AcceptsReturn = True
        Me.txtDirección.BackColor = System.Drawing.Color.White
        Me.txtDirección.Location = New System.Drawing.Point(95, 68)
        Me.txtDirección.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDirección.Multiline = True
        Me.txtDirección.Name = "txtDirección"
        Me.txtDirección.ReadOnly = True
        Me.txtDirección.Size = New System.Drawing.Size(407, 68)
        Me.txtDirección.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Dirección"
        '
        'txtContacto
        '
        Me.txtContacto.BackColor = System.Drawing.Color.White
        Me.txtContacto.Location = New System.Drawing.Point(95, 196)
        Me.txtContacto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContacto.MaxLength = 50
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(407, 22)
        Me.txtContacto.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Contacto"
        '
        'txtCIF
        '
        Me.txtCIF.BackColor = System.Drawing.Color.White
        Me.txtCIF.Location = New System.Drawing.Point(236, 12)
        Me.txtCIF.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCIF.MaxLength = 20
        Me.txtCIF.Name = "txtCIF"
        Me.txtCIF.ReadOnly = True
        Me.txtCIF.Size = New System.Drawing.Size(121, 22)
        Me.txtCIF.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(185, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "CIF"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(313, 385)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 28)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(153, 385)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(100, 28)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(45, 385)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregar.TabIndex = 18
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dvEmpresas
        '
        Me.dvEmpresas.BackgroundColor = System.Drawing.Color.White
        Me.dvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvEmpresas.Location = New System.Drawing.Point(523, 12)
        Me.dvEmpresas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvEmpresas.Name = "dvEmpresas"
        Me.dvEmpresas.RowTemplate.Height = 24
        Me.dvEmpresas.Size = New System.Drawing.Size(283, 401)
        Me.dvEmpresas.TabIndex = 21
        '
        'picLogo
        '
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo.Location = New System.Drawing.Point(291, 226)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(158, 125)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 22
        Me.picLogo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(209, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Logotipo"
        '
        'txtODBC
        '
        Me.txtODBC.BackColor = System.Drawing.Color.White
        Me.txtODBC.Location = New System.Drawing.Point(95, 254)
        Me.txtODBC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtODBC.MaxLength = 15
        Me.txtODBC.Name = "txtODBC"
        Me.txtODBC.ReadOnly = True
        Me.txtODBC.Size = New System.Drawing.Size(121, 22)
        Me.txtODBC.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 17)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "ODBC"
        '
        'frmEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(819, 444)
        Me.Controls.Add(Me.txtODBC)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.dvEmpresas)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtCIF)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTeléfono)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtProvincia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPoblación)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPostal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDirección)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCódigo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmpresas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Empresas V03/18"
        CType(Me.dvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCódigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTeléfono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPoblación As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDirección As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCIF As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dvEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtODBC As TextBox
    Friend WithEvents Label10 As Label
End Class
