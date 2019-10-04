<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAlbaranes
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
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtAlbarán = New System.Windows.Forms.TextBox()
        Me.lblAlbarán = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnEspera = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblValorFacturación = New System.Windows.Forms.Label()
        Me.dvRC = New System.Windows.Forms.DataGridView()
        Me.lblEspera = New System.Windows.Forms.Label()
        Me.radioDécimas = New System.Windows.Forms.RadioButton()
        Me.groupEmpresa = New System.Windows.Forms.GroupBox()
        Me.radioAdidas = New System.Windows.Forms.RadioButton()
        Me.radioPolinesia = New System.Windows.Forms.RadioButton()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.txtPacking = New System.Windows.Forms.TextBox()
        Me.lblPacking = New System.Windows.Forms.Label()
        CType(Me.dvRC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupEmpresa.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(266, 99)
        Me.Label65.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(50, 13)
        Me.Label65.TabIndex = 12
        Me.Label65.Text = "Destino"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(22, 99)
        Me.Label64.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(44, 13)
        Me.Label64.TabIndex = 10
        Me.Label64.Text = "Origen"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(416, 12)
        Me.Label63.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(42, 13)
        Me.Label63.TabIndex = 4
        Me.Label63.Text = "Fecha"
        '
        'txtAlbarán
        '
        Me.txtAlbarán.BackColor = System.Drawing.Color.White
        Me.txtAlbarán.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlbarán.Location = New System.Drawing.Point(73, 10)
        Me.txtAlbarán.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAlbarán.MaxLength = 30
        Me.txtAlbarán.Name = "txtAlbarán"
        Me.txtAlbarán.ReadOnly = True
        Me.txtAlbarán.Size = New System.Drawing.Size(117, 20)
        Me.txtAlbarán.TabIndex = 1
        '
        'lblAlbarán
        '
        Me.lblAlbarán.AutoSize = True
        Me.lblAlbarán.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbarán.Location = New System.Drawing.Point(16, 12)
        Me.lblAlbarán.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAlbarán.Name = "lblAlbarán"
        Me.lblAlbarán.Size = New System.Drawing.Size(50, 13)
        Me.lblAlbarán.TabIndex = 0
        Me.lblAlbarán.Text = "Albarán"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 125)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Valor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(211, 125)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Valor facturación"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(25, 338)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 22)
        Me.btnBuscar.TabIndex = 19
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnEspera
        '
        Me.btnEspera.Location = New System.Drawing.Point(122, 338)
        Me.btnEspera.Name = "btnEspera"
        Me.btnEspera.Size = New System.Drawing.Size(80, 22)
        Me.btnEspera.TabIndex = 20
        Me.btnEspera.Text = "&Espera"
        Me.btnEspera.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(284, 338)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 22)
        Me.btnSalir.TabIndex = 21
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tipo"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(463, 12)
        Me.lblFecha.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(39, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "fecha"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(73, 74)
        Me.lblTipo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 8
        Me.lblTipo.Text = "tipo"
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOrigen.Location = New System.Drawing.Point(73, 99)
        Me.lblOrigen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(42, 13)
        Me.lblOrigen.TabIndex = 11
        Me.lblOrigen.Text = "origen"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDestino.Location = New System.Drawing.Point(321, 99)
        Me.lblDestino.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(48, 13)
        Me.lblDestino.TabIndex = 13
        Me.lblDestino.Text = "destino"
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(73, 125)
        Me.lblValor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(35, 13)
        Me.lblValor.TabIndex = 15
        Me.lblValor.Text = "valor"
        '
        'lblValorFacturación
        '
        Me.lblValorFacturación.AutoSize = True
        Me.lblValorFacturación.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorFacturación.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblValorFacturación.Location = New System.Drawing.Point(321, 125)
        Me.lblValorFacturación.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblValorFacturación.Name = "lblValorFacturación"
        Me.lblValorFacturación.Size = New System.Drawing.Size(35, 13)
        Me.lblValorFacturación.TabIndex = 17
        Me.lblValorFacturación.Text = "valor"
        '
        'dvRC
        '
        Me.dvRC.AllowUserToAddRows = False
        Me.dvRC.AllowUserToDeleteRows = False
        Me.dvRC.AllowUserToResizeRows = False
        Me.dvRC.BackgroundColor = System.Drawing.Color.White
        Me.dvRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvRC.Location = New System.Drawing.Point(145, 148)
        Me.dvRC.Margin = New System.Windows.Forms.Padding(2)
        Me.dvRC.Name = "dvRC"
        Me.dvRC.ReadOnly = True
        Me.dvRC.RowTemplate.Height = 24
        Me.dvRC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dvRC.Size = New System.Drawing.Size(214, 186)
        Me.dvRC.TabIndex = 18
        '
        'lblEspera
        '
        Me.lblEspera.AutoSize = True
        Me.lblEspera.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEspera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEspera.Location = New System.Drawing.Point(463, 74)
        Me.lblEspera.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEspera.Name = "lblEspera"
        Me.lblEspera.Size = New System.Drawing.Size(45, 13)
        Me.lblEspera.TabIndex = 9
        Me.lblEspera.Text = "espera"
        '
        'radioDécimas
        '
        Me.radioDécimas.AutoSize = True
        Me.radioDécimas.Checked = True
        Me.radioDécimas.Location = New System.Drawing.Point(4, 14)
        Me.radioDécimas.Margin = New System.Windows.Forms.Padding(2)
        Me.radioDécimas.Name = "radioDécimas"
        Me.radioDécimas.Size = New System.Drawing.Size(66, 17)
        Me.radioDécimas.TabIndex = 0
        Me.radioDécimas.TabStop = True
        Me.radioDécimas.Text = "Décimas"
        Me.radioDécimas.UseVisualStyleBackColor = True
        '
        'groupEmpresa
        '
        Me.groupEmpresa.Controls.Add(Me.radioAdidas)
        Me.groupEmpresa.Controls.Add(Me.radioPolinesia)
        Me.groupEmpresa.Controls.Add(Me.radioDécimas)
        Me.groupEmpresa.Location = New System.Drawing.Point(73, 34)
        Me.groupEmpresa.Margin = New System.Windows.Forms.Padding(2)
        Me.groupEmpresa.Name = "groupEmpresa"
        Me.groupEmpresa.Padding = New System.Windows.Forms.Padding(2)
        Me.groupEmpresa.Size = New System.Drawing.Size(214, 37)
        Me.groupEmpresa.TabIndex = 6
        Me.groupEmpresa.TabStop = False
        Me.groupEmpresa.Text = "Empresa"
        '
        'radioAdidas
        '
        Me.radioAdidas.AutoSize = True
        Me.radioAdidas.Location = New System.Drawing.Point(150, 14)
        Me.radioAdidas.Margin = New System.Windows.Forms.Padding(2)
        Me.radioAdidas.Name = "radioAdidas"
        Me.radioAdidas.Size = New System.Drawing.Size(57, 17)
        Me.radioAdidas.TabIndex = 2
        Me.radioAdidas.Text = "Adidas"
        Me.radioAdidas.UseVisualStyleBackColor = True
        '
        'radioPolinesia
        '
        Me.radioPolinesia.AutoSize = True
        Me.radioPolinesia.Location = New System.Drawing.Point(76, 14)
        Me.radioPolinesia.Margin = New System.Windows.Forms.Padding(2)
        Me.radioPolinesia.Name = "radioPolinesia"
        Me.radioPolinesia.Size = New System.Drawing.Size(67, 17)
        Me.radioPolinesia.TabIndex = 1
        Me.radioPolinesia.Text = "Polinesia"
        Me.radioPolinesia.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(381, 170)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 22)
        Me.btnEliminar.TabIndex = 22
        Me.btnEliminar.Text = "Borrar &RC"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtPacking
        '
        Me.txtPacking.BackColor = System.Drawing.Color.White
        Me.txtPacking.Location = New System.Drawing.Point(292, 9)
        Me.txtPacking.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacking.MaxLength = 30
        Me.txtPacking.Name = "txtPacking"
        Me.txtPacking.ReadOnly = True
        Me.txtPacking.Size = New System.Drawing.Size(117, 20)
        Me.txtPacking.TabIndex = 3
        '
        'lblPacking
        '
        Me.lblPacking.AutoSize = True
        Me.lblPacking.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPacking.Location = New System.Drawing.Point(206, 12)
        Me.lblPacking.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPacking.Name = "lblPacking"
        Me.lblPacking.Size = New System.Drawing.Size(77, 13)
        Me.lblPacking.TabIndex = 2
        Me.lblPacking.Text = "Packing List"
        '
        'FrmAlbaranes
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(540, 368)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.groupEmpresa)
        Me.Controls.Add(Me.lblEspera)
        Me.Controls.Add(Me.dvRC)
        Me.Controls.Add(Me.lblValorFacturación)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblDestino)
        Me.Controls.Add(Me.lblOrigen)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEspera)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txtPacking)
        Me.Controls.Add(Me.lblPacking)
        Me.Controls.Add(Me.txtAlbarán)
        Me.Controls.Add(Me.lblAlbarán)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAlbaranes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Albaranes V07/18"
        CType(Me.dvRC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupEmpresa.ResumeLayout(False)
        Me.groupEmpresa.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtAlbarán As System.Windows.Forms.TextBox
    Friend WithEvents lblAlbarán As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnEspera As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblValorFacturación As System.Windows.Forms.Label
    Friend WithEvents dvRC As System.Windows.Forms.DataGridView
    Friend WithEvents lblEspera As System.Windows.Forms.Label
    Friend WithEvents radioDécimas As System.Windows.Forms.RadioButton
    Friend WithEvents groupEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents radioAdidas As System.Windows.Forms.RadioButton
    Friend WithEvents radioPolinesia As System.Windows.Forms.RadioButton
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtPacking As TextBox
    Friend WithEvents lblPacking As Label
End Class
