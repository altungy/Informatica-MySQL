<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLíneaFacturaInterna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLíneaFacturaInterna))
        Me.dvArtículos = New System.Windows.Forms.DataGridView()
        Me.txtArtículo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripción = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comboProveedor = New System.Windows.Forms.ComboBox()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dvArtículos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvArtículos
        '
        Me.dvArtículos.BackgroundColor = System.Drawing.Color.White
        Me.dvArtículos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvArtículos.Location = New System.Drawing.Point(497, 16)
        Me.dvArtículos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvArtículos.Name = "dvArtículos"
        Me.dvArtículos.RowTemplate.Height = 24
        Me.dvArtículos.Size = New System.Drawing.Size(389, 315)
        Me.dvArtículos.TabIndex = 16
        '
        'txtArtículo
        '
        Me.txtArtículo.BackColor = System.Drawing.Color.White
        Me.txtArtículo.Location = New System.Drawing.Point(96, 16)
        Me.txtArtículo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtArtículo.MaxLength = 6
        Me.txtArtículo.Name = "txtArtículo"
        Me.txtArtículo.Size = New System.Drawing.Size(80, 22)
        Me.txtArtículo.TabIndex = 1
        Me.txtArtículo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Artículo"
        '
        'txtDescripción
        '
        Me.txtDescripción.Location = New System.Drawing.Point(96, 44)
        Me.txtDescripción.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescripción.Multiline = True
        Me.txtDescripción.Name = "txtDescripción"
        Me.txtDescripción.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripción.Size = New System.Drawing.Size(372, 141)
        Me.txtDescripción.TabIndex = 4
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.White
        Me.txtPrecio.Location = New System.Drawing.Point(96, 191)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 22)
        Me.txtPrecio.TabIndex = 6
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(32, 194)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 17)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Precio"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.White
        Me.txtFactura.Location = New System.Drawing.Point(96, 249)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFactura.MaxLength = 30
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(145, 22)
        Me.txtFactura.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(27, 252)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Factura"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Proveedor"
        '
        'comboProveedor
        '
        Me.comboProveedor.FormattingEnabled = True
        Me.comboProveedor.Location = New System.Drawing.Point(96, 219)
        Me.comboProveedor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboProveedor.Name = "comboProveedor"
        Me.comboProveedor.Size = New System.Drawing.Size(373, 24)
        Me.comboProveedor.TabIndex = 8
        '
        'btnFecha
        '
        Me.btnFecha.Enabled = False
        Me.btnFecha.Image = CType(resources.GetObject("btnFecha.Image"), System.Drawing.Image)
        Me.btnFecha.Location = New System.Drawing.Point(397, 246)
        Me.btnFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(28, 28)
        Me.btnFecha.TabIndex = 13
        Me.btnFecha.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(316, 249)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(75, 22)
        Me.txtFecha.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(253, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(244, 304)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 27)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(149, 304)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.Location = New System.Drawing.Point(283, 16)
        Me.txtSerie.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSerie.MaxLength = 30
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(185, 22)
        Me.txtSerie.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(187, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nº de serie"
        '
        'FrmLíneaFacturaInterna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(900, 345)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnFecha)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.comboProveedor)
        Me.Controls.Add(Me.txtDescripción)
        Me.Controls.Add(Me.txtArtículo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dvArtículos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmLíneaFacturaInterna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dvArtículos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dvArtículos As System.Windows.Forms.DataGridView
    Friend WithEvents txtArtículo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripción As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents comboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btnFecha As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
