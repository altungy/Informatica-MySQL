<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFacturaciónInterna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturaciónInterna))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNúmero = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.comboTienda = New System.Windows.Forms.ComboBox()
        Me.dvLíneas = New System.Windows.Forms.DataGridView()
        Me.btnNueva = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminarLínea = New System.Windows.Forms.Button()
        Me.btnModificarLínea = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.btnÚltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        CType(Me.dvLíneas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número"
        '
        'txtNúmero
        '
        Me.txtNúmero.BackColor = System.Drawing.Color.White
        Me.txtNúmero.Location = New System.Drawing.Point(96, 20)
        Me.txtNúmero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNúmero.MaxLength = 6
        Me.txtNúmero.Name = "txtNúmero"
        Me.txtNúmero.ReadOnly = True
        Me.txtNúmero.Size = New System.Drawing.Size(80, 22)
        Me.txtNúmero.TabIndex = 1
        Me.txtNúmero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(245, 20)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(75, 22)
        Me.txtFecha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(192, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tienda"
        '
        'comboTienda
        '
        Me.comboTienda.FormattingEnabled = True
        Me.comboTienda.Location = New System.Drawing.Point(96, 48)
        Me.comboTienda.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboTienda.Name = "comboTienda"
        Me.comboTienda.Size = New System.Drawing.Size(375, 24)
        Me.comboTienda.TabIndex = 6
        '
        'dvLíneas
        '
        Me.dvLíneas.BackgroundColor = System.Drawing.Color.White
        Me.dvLíneas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvLíneas.Location = New System.Drawing.Point(12, 156)
        Me.dvLíneas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvLíneas.Name = "dvLíneas"
        Me.dvLíneas.RowTemplate.Height = 24
        Me.dvLíneas.Size = New System.Drawing.Size(480, 169)
        Me.dvLíneas.TabIndex = 17
        '
        'btnNueva
        '
        Me.btnNueva.Location = New System.Drawing.Point(169, 90)
        Me.btnNueva.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(75, 27)
        Me.btnNueva.TabIndex = 11
        Me.btnNueva.Text = "&Nueva"
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(169, 123)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 27)
        Me.btnModificar.TabIndex = 12
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(255, 90)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 27)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(255, 123)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 27)
        Me.btnEliminar.TabIndex = 14
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(336, 107)
        Me.btnListar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(75, 27)
        Me.btnListar.TabIndex = 15
        Me.btnListar.Text = "&Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(417, 107)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 27)
        Me.btnSalir.TabIndex = 16
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminarLínea
        '
        Me.btnEliminarLínea.Location = New System.Drawing.Point(296, 331)
        Me.btnEliminarLínea.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminarLínea.Name = "btnEliminarLínea"
        Me.btnEliminarLínea.Size = New System.Drawing.Size(75, 27)
        Me.btnEliminarLínea.TabIndex = 20
        Me.btnEliminarLínea.Text = "El&iminar"
        Me.btnEliminarLínea.UseVisualStyleBackColor = True
        '
        'btnModificarLínea
        '
        Me.btnModificarLínea.Location = New System.Drawing.Point(215, 331)
        Me.btnModificarLínea.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificarLínea.Name = "btnModificarLínea"
        Me.btnModificarLínea.Size = New System.Drawing.Size(75, 27)
        Me.btnModificarLínea.TabIndex = 19
        Me.btnModificarLínea.Text = "M&odificar"
        Me.btnModificarLínea.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(133, 331)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 27)
        Me.btnAgregar.TabIndex = 18
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnFecha
        '
        Me.btnFecha.Enabled = False
        Me.btnFecha.Image = CType(resources.GetObject("btnFecha.Image"), System.Drawing.Image)
        Me.btnFecha.Location = New System.Drawing.Point(336, 17)
        Me.btnFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(28, 28)
        Me.btnFecha.TabIndex = 4
        Me.btnFecha.UseVisualStyleBackColor = True
        '
        'btnÚltimo
        '
        Me.btnÚltimo.Image = Global.InformáticaMySQL.My.Resources.Resources.fin
        Me.btnÚltimo.Location = New System.Drawing.Point(129, 105)
        Me.btnÚltimo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnÚltimo.Name = "btnÚltimo"
        Me.btnÚltimo.Size = New System.Drawing.Size(31, 28)
        Me.btnÚltimo.TabIndex = 10
        Me.btnÚltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Image = Global.InformáticaMySQL.My.Resources.Resources.siguiente
        Me.btnSiguiente.Location = New System.Drawing.Point(91, 105)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(31, 28)
        Me.btnSiguiente.TabIndex = 9
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Image = Global.InformáticaMySQL.My.Resources.Resources.back
        Me.btnAnterior.Location = New System.Drawing.Point(51, 105)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(31, 28)
        Me.btnAnterior.TabIndex = 8
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Image = Global.InformáticaMySQL.My.Resources.Resources.top
        Me.btnPrimero.Location = New System.Drawing.Point(12, 105)
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(31, 28)
        Me.btnPrimero.TabIndex = 7
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'FrmFacturaciónInterna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(520, 369)
        Me.Controls.Add(Me.btnFecha)
        Me.Controls.Add(Me.btnÚltimo)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnPrimero)
        Me.Controls.Add(Me.btnEliminarLínea)
        Me.Controls.Add(Me.btnModificarLínea)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.dvLíneas)
        Me.Controls.Add(Me.comboTienda)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNúmero)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFacturaciónInterna"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturación interna V03/18"
        CType(Me.dvLíneas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNúmero As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comboTienda As System.Windows.Forms.ComboBox
    Friend WithEvents dvLíneas As System.Windows.Forms.DataGridView
    Friend WithEvents btnNueva As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnListar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEliminarLínea As System.Windows.Forms.Button
    Friend WithEvents btnModificarLínea As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnÚltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnFecha As System.Windows.Forms.Button
End Class
