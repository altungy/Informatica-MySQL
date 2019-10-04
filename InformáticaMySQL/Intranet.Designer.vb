<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIntranet
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
        Me.wbIntranet = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbIntranet
        '
        Me.wbIntranet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbIntranet.Location = New System.Drawing.Point(0, 0)
        Me.wbIntranet.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbIntranet.Name = "wbIntranet"
        Me.wbIntranet.Size = New System.Drawing.Size(800, 450)
        Me.wbIntranet.TabIndex = 0
        '
        'FrmIntranet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.wbIntranet)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmIntranet"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Intranet V04/19"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wbIntranet As WebBrowser
End Class
