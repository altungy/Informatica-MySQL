<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChat
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChat))
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.dvChat = New System.Windows.Forms.DataGridView()
        Me.tActualiza = New System.Windows.Forms.Timer(Me.components)
        Me.btnBuzz = New System.Windows.Forms.Button()
        CType(Me.dvChat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(12, 343)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(776, 20)
        Me.txtMensaje.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(314, 392)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "&Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(411, 392)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'dvChat
        '
        Me.dvChat.AllowUserToAddRows = False
        Me.dvChat.AllowUserToDeleteRows = False
        Me.dvChat.AllowUserToOrderColumns = True
        Me.dvChat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dvChat.BackgroundColor = System.Drawing.Color.White
        Me.dvChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvChat.Location = New System.Drawing.Point(12, 11)
        Me.dvChat.Margin = New System.Windows.Forms.Padding(2)
        Me.dvChat.Name = "dvChat"
        Me.dvChat.RowTemplate.Height = 24
        Me.dvChat.Size = New System.Drawing.Size(776, 327)
        Me.dvChat.TabIndex = 0
        '
        'tActualiza
        '
        Me.tActualiza.Interval = 5000
        '
        'btnBuzz
        '
        Me.btnBuzz.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuzz.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.buzz
        Me.btnBuzz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuzz.Location = New System.Drawing.Point(738, 378)
        Me.btnBuzz.Name = "btnBuzz"
        Me.btnBuzz.Size = New System.Drawing.Size(50, 50)
        Me.btnBuzz.TabIndex = 4
        Me.btnBuzz.UseVisualStyleBackColor = False
        '
        'FrmChat
        '
        Me.AcceptButton = Me.btnEnviar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(800, 431)
        Me.Controls.Add(Me.btnBuzz)
        Me.Controls.Add(Me.dvChat)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.txtMensaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chat V04/19"
        Me.TopMost = True
        CType(Me.dvChat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMensaje As TextBox
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents dvChat As DataGridView
    Friend WithEvents tActualiza As Timer
    Friend WithEvents btnBuzz As Button
End Class
