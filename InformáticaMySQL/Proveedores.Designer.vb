<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProveedores
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
        Me.dvProveedores = New System.Windows.Forms.DataGridView()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.txtCIF = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPoblación = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPostal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDirección = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCódigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDíasPago = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDíaPago = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lvwContactos = New System.Windows.Forms.ListView()
        Me.btnEliminarContacto = New System.Windows.Forms.Button()
        Me.btnModificarContacto = New System.Windows.Forms.Button()
        Me.btnAgregarContacto = New System.Windows.Forms.Button()
        Me.comboFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.dvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvProveedores
        '
        Me.dvProveedores.BackgroundColor = System.Drawing.Color.White
        Me.dvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvProveedores.Location = New System.Drawing.Point(564, 21)
        Me.dvProveedores.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvProveedores.Name = "dvProveedores"
        Me.dvProveedores.RowTemplate.Height = 24
        Me.dvProveedores.Size = New System.Drawing.Size(424, 322)
        Me.dvProveedores.TabIndex = 31
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(191, 315)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(100, 28)
        Me.btnModificar.TabIndex = 24
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(83, 315)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(407, 315)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 28)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(299, 315)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(100, 28)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtCIF
        '
        Me.txtCIF.BackColor = System.Drawing.Color.White
        Me.txtCIF.Location = New System.Drawing.Point(273, 21)
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
        Me.Label8.Location = New System.Drawing.Point(223, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 17)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "CIF"
        '
        'txtProvincia
        '
        Me.txtProvincia.BackColor = System.Drawing.Color.White
        Me.txtProvincia.Location = New System.Drawing.Point(132, 176)
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
        Me.Label6.Location = New System.Drawing.Point(51, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Provincia"
        '
        'txtPoblación
        '
        Me.txtPoblación.BackColor = System.Drawing.Color.White
        Me.txtPoblación.Location = New System.Drawing.Point(273, 150)
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
        Me.Label5.Location = New System.Drawing.Point(188, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Población"
        '
        'txtPostal
        '
        Me.txtPostal.BackColor = System.Drawing.Color.White
        Me.txtPostal.Location = New System.Drawing.Point(132, 150)
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
        Me.Label4.Location = New System.Drawing.Point(73, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Postal"
        '
        'txtDirección
        '
        Me.txtDirección.AcceptsReturn = True
        Me.txtDirección.BackColor = System.Drawing.Color.White
        Me.txtDirección.Location = New System.Drawing.Point(132, 76)
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
        Me.Label3.Location = New System.Drawing.Point(51, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Dirección"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(132, 48)
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
        Me.Label2.Location = New System.Drawing.Point(63, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'txtCódigo
        '
        Me.txtCódigo.BackColor = System.Drawing.Color.White
        Me.txtCódigo.Location = New System.Drawing.Point(132, 21)
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
        Me.Label1.Location = New System.Drawing.Point(68, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(67, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 17)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Pago a"
        '
        'txtDíasPago
        '
        Me.txtDíasPago.BackColor = System.Drawing.Color.White
        Me.txtDíasPago.Location = New System.Drawing.Point(132, 242)
        Me.txtDíasPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDíasPago.MaxLength = 6
        Me.txtDíasPago.Name = "txtDíasPago"
        Me.txtDíasPago.ReadOnly = True
        Me.txtDíasPago.Size = New System.Drawing.Size(49, 22)
        Me.txtDíasPago.TabIndex = 17
        Me.txtDíasPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(188, 246)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "días"
        '
        'txtDíaPago
        '
        Me.txtDíaPago.BackColor = System.Drawing.Color.White
        Me.txtDíaPago.Location = New System.Drawing.Point(379, 242)
        Me.txtDíaPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDíaPago.MaxLength = 6
        Me.txtDíaPago.Name = "txtDíaPago"
        Me.txtDíaPago.ReadOnly = True
        Me.txtDíaPago.Size = New System.Drawing.Size(49, 22)
        Me.txtDíaPago.TabIndex = 20
        Me.txtDíaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(269, 246)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Día de pago"
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.Location = New System.Drawing.Point(132, 272)
        Me.txtDescuento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescuento.MaxLength = 6
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(49, 22)
        Me.txtDescuento.TabIndex = 22
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Descuento"
        '
        'lvwContactos
        '
        Me.lvwContactos.FullRowSelect = True
        Me.lvwContactos.GridLines = True
        Me.lvwContactos.Location = New System.Drawing.Point(55, 370)
        Me.lvwContactos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvwContactos.MultiSelect = False
        Me.lvwContactos.Name = "lvwContactos"
        Me.lvwContactos.Size = New System.Drawing.Size(736, 139)
        Me.lvwContactos.TabIndex = 27
        Me.lvwContactos.UseCompatibleStateImageBehavior = False
        Me.lvwContactos.View = System.Windows.Forms.View.Details
        '
        'btnEliminarContacto
        '
        Me.btnEliminarContacto.Location = New System.Drawing.Point(847, 462)
        Me.btnEliminarContacto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminarContacto.Name = "btnEliminarContacto"
        Me.btnEliminarContacto.Size = New System.Drawing.Size(100, 28)
        Me.btnEliminarContacto.TabIndex = 30
        Me.btnEliminarContacto.Text = "&Eliminar"
        Me.btnEliminarContacto.UseVisualStyleBackColor = True
        '
        'btnModificarContacto
        '
        Me.btnModificarContacto.Location = New System.Drawing.Point(847, 426)
        Me.btnModificarContacto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificarContacto.Name = "btnModificarContacto"
        Me.btnModificarContacto.Size = New System.Drawing.Size(100, 28)
        Me.btnModificarContacto.TabIndex = 29
        Me.btnModificarContacto.Text = "&Modificar"
        Me.btnModificarContacto.UseVisualStyleBackColor = True
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Location = New System.Drawing.Point(847, 390)
        Me.btnAgregarContacto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregarContacto.TabIndex = 28
        Me.btnAgregarContacto.Text = "&Agregar"
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'comboFormaPago
        '
        Me.comboFormaPago.FormattingEnabled = True
        Me.comboFormaPago.Location = New System.Drawing.Point(132, 206)
        Me.comboFormaPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboFormaPago.Name = "comboFormaPago"
        Me.comboFormaPago.Size = New System.Drawing.Size(267, 24)
        Me.comboFormaPago.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 209)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 17)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Forma de pago"
        '
        'FrmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1003, 532)
        Me.Controls.Add(Me.comboFormaPago)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnEliminarContacto)
        Me.Controls.Add(Me.btnModificarContacto)
        Me.Controls.Add(Me.btnAgregarContacto)
        Me.Controls.Add(Me.lvwContactos)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDíaPago)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDíasPago)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCIF)
        Me.Controls.Add(Me.Label8)
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
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dvProveedores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProveedores"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proveedores V02/17"
        CType(Me.dvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dvProveedores As System.Windows.Forms.DataGridView
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtCIF As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPoblación As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDirección As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCódigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDíasPago As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDíaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvwContactos As System.Windows.Forms.ListView
    Friend WithEvents btnEliminarContacto As System.Windows.Forms.Button
    Friend WithEvents btnModificarContacto As System.Windows.Forms.Button
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
    Friend WithEvents comboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
