<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizarCurriculo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCurriculo = New System.Windows.Forms.TextBox()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCurriculo
        '
        Me.txtCurriculo.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurriculo.Location = New System.Drawing.Point(11, 13)
        Me.txtCurriculo.Multiline = True
        Me.txtCurriculo.Name = "txtCurriculo"
        Me.txtCurriculo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCurriculo.Size = New System.Drawing.Size(600, 568)
        Me.txtCurriculo.TabIndex = 0
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(536, 578)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 1
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'frmVisualizarCurriculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 613)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.txtCurriculo)
        Me.Name = "frmVisualizarCurriculo"
        Me.Text = "Visualizar curriculo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCurriculo As System.Windows.Forms.TextBox
    Friend WithEvents btnSair As System.Windows.Forms.Button
End Class
