<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPoblaciones
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
        Me.dvPoblaciones = New System.Windows.Forms.DataGridView()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblProvincia = New System.Windows.Forms.Label()
        Me.lblPoblación = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.comboProvincia = New System.Windows.Forms.ComboBox()
        Me.txtPoblación = New System.Windows.Forms.TextBox()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.dvPoblaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvPoblaciones
        '
        Me.dvPoblaciones.BackgroundColor = System.Drawing.Color.White
        Me.dvPoblaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvPoblaciones.Location = New System.Drawing.Point(12, 11)
        Me.dvPoblaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.dvPoblaciones.Name = "dvPoblaciones"
        Me.dvPoblaciones.RowTemplate.Height = 24
        Me.dvPoblaciones.Size = New System.Drawing.Size(593, 322)
        Me.dvPoblaciones.TabIndex = 0
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.Location = New System.Drawing.Point(9, 341)
        Me.lblCP.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(23, 13)
        Me.lblCP.TabIndex = 1
        Me.lblCP.Text = "CP"
        '
        'lblProvincia
        '
        Me.lblProvincia.AutoSize = True
        Me.lblProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvincia.Location = New System.Drawing.Point(99, 341)
        Me.lblProvincia.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(60, 13)
        Me.lblProvincia.TabIndex = 3
        Me.lblProvincia.Text = "Provincia"
        '
        'lblPoblación
        '
        Me.lblPoblación.AutoSize = True
        Me.lblPoblación.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblación.Location = New System.Drawing.Point(303, 341)
        Me.lblPoblación.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPoblación.Name = "lblPoblación"
        Me.lblPoblación.Size = New System.Drawing.Size(63, 13)
        Me.lblPoblación.TabIndex = 5
        Me.lblPoblación.Text = "Población"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(37, 338)
        Me.txtCP.MaxLength = 5
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(54, 20)
        Me.txtCP.TabIndex = 2
        '
        'comboProvincia
        '
        Me.comboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboProvincia.FormattingEnabled = True
        Me.comboProvincia.Location = New System.Drawing.Point(164, 338)
        Me.comboProvincia.Name = "comboProvincia"
        Me.comboProvincia.Size = New System.Drawing.Size(127, 21)
        Me.comboProvincia.TabIndex = 4
        '
        'txtPoblación
        '
        Me.txtPoblación.Location = New System.Drawing.Point(371, 338)
        Me.txtPoblación.Name = "txtPoblación"
        Me.txtPoblación.Size = New System.Drawing.Size(234, 20)
        Me.txtPoblación.TabIndex = 6
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(232, 371)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 8
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(322, 371)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmPoblaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(621, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.txtPoblación)
        Me.Controls.Add(Me.comboProvincia)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.lblPoblación)
        Me.Controls.Add(Me.lblProvincia)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.dvPoblaciones)
        Me.Name = "FrmPoblaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Poblaciones V09/18"
        CType(Me.dvPoblaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dvPoblaciones As DataGridView
    Friend WithEvents lblCP As Label
    Friend WithEvents lblProvincia As Label
    Friend WithEvents lblPoblación As Label
    Friend WithEvents txtCP As TextBox
    Friend WithEvents comboProvincia As ComboBox
    Friend WithEvents txtPoblación As TextBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents btnSalir As Button
End Class
