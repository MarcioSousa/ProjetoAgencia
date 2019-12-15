<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformacoesRestritas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optIndigina = New System.Windows.Forms.RadioButton()
        Me.optPardo = New System.Windows.Forms.RadioButton()
        Me.optNegro = New System.Windows.Forms.RadioButton()
        Me.optBranco = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optFumanteNao = New System.Windows.Forms.RadioButton()
        Me.optFumanteSim = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optTatuagemNao = New System.Windows.Forms.RadioButton()
        Me.optTatuagemSim = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optBoaAparenciaNao = New System.Windows.Forms.RadioButton()
        Me.optBoaAparenciaSim = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optIndigina)
        Me.GroupBox1.Controls.Add(Me.optPardo)
        Me.GroupBox1.Controls.Add(Me.optNegro)
        Me.GroupBox1.Controls.Add(Me.optBranco)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 115)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Raça"
        '
        'optIndigina
        '
        Me.optIndigina.AutoSize = True
        Me.optIndigina.Location = New System.Drawing.Point(6, 88)
        Me.optIndigina.Name = "optIndigina"
        Me.optIndigina.Size = New System.Drawing.Size(68, 17)
        Me.optIndigina.TabIndex = 17
        Me.optIndigina.Tag = "3"
        Me.optIndigina.Text = "Indígena"
        Me.optIndigina.UseVisualStyleBackColor = True
        '
        'optPardo
        '
        Me.optPardo.AutoSize = True
        Me.optPardo.Location = New System.Drawing.Point(6, 65)
        Me.optPardo.Name = "optPardo"
        Me.optPardo.Size = New System.Drawing.Size(53, 17)
        Me.optPardo.TabIndex = 16
        Me.optPardo.Tag = "2"
        Me.optPardo.Text = "Pardo"
        Me.optPardo.UseVisualStyleBackColor = True
        '
        'optNegro
        '
        Me.optNegro.AutoSize = True
        Me.optNegro.Location = New System.Drawing.Point(6, 19)
        Me.optNegro.Name = "optNegro"
        Me.optNegro.Size = New System.Drawing.Size(54, 17)
        Me.optNegro.TabIndex = 15
        Me.optNegro.Tag = "0"
        Me.optNegro.Text = "Negro"
        Me.optNegro.UseVisualStyleBackColor = True
        '
        'optBranco
        '
        Me.optBranco.AutoSize = True
        Me.optBranco.Checked = True
        Me.optBranco.Location = New System.Drawing.Point(6, 42)
        Me.optBranco.Name = "optBranco"
        Me.optBranco.Size = New System.Drawing.Size(59, 17)
        Me.optBranco.TabIndex = 18
        Me.optBranco.TabStop = True
        Me.optBranco.Tag = "1"
        Me.optBranco.Text = "Branco"
        Me.optBranco.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optFumanteNao)
        Me.GroupBox2.Controls.Add(Me.optFumanteSim)
        Me.GroupBox2.Location = New System.Drawing.Point(140, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(106, 115)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fumante?"
        '
        'optFumanteNao
        '
        Me.optFumanteNao.AutoSize = True
        Me.optFumanteNao.Checked = True
        Me.optFumanteNao.Location = New System.Drawing.Point(6, 42)
        Me.optFumanteNao.Name = "optFumanteNao"
        Me.optFumanteNao.Size = New System.Drawing.Size(45, 17)
        Me.optFumanteNao.TabIndex = 1
        Me.optFumanteNao.TabStop = True
        Me.optFumanteNao.Text = "Não"
        Me.optFumanteNao.UseVisualStyleBackColor = True
        '
        'optFumanteSim
        '
        Me.optFumanteSim.AutoSize = True
        Me.optFumanteSim.Location = New System.Drawing.Point(6, 20)
        Me.optFumanteSim.Name = "optFumanteSim"
        Me.optFumanteSim.Size = New System.Drawing.Size(42, 17)
        Me.optFumanteSim.TabIndex = 0
        Me.optFumanteSim.TabStop = True
        Me.optFumanteSim.Text = "Sim"
        Me.optFumanteSim.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optTatuagemNao)
        Me.GroupBox3.Controls.Add(Me.optTatuagemSim)
        Me.GroupBox3.Location = New System.Drawing.Point(253, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 115)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tatuagem a mostra?"
        '
        'optTatuagemNao
        '
        Me.optTatuagemNao.AutoSize = True
        Me.optTatuagemNao.Checked = True
        Me.optTatuagemNao.Location = New System.Drawing.Point(6, 41)
        Me.optTatuagemNao.Name = "optTatuagemNao"
        Me.optTatuagemNao.Size = New System.Drawing.Size(45, 17)
        Me.optTatuagemNao.TabIndex = 3
        Me.optTatuagemNao.TabStop = True
        Me.optTatuagemNao.Text = "Não"
        Me.optTatuagemNao.UseVisualStyleBackColor = True
        '
        'optTatuagemSim
        '
        Me.optTatuagemSim.AutoSize = True
        Me.optTatuagemSim.Location = New System.Drawing.Point(6, 19)
        Me.optTatuagemSim.Name = "optTatuagemSim"
        Me.optTatuagemSim.Size = New System.Drawing.Size(42, 17)
        Me.optTatuagemSim.TabIndex = 2
        Me.optTatuagemSim.TabStop = True
        Me.optTatuagemSim.Text = "Sim"
        Me.optTatuagemSim.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optBoaAparenciaNao)
        Me.GroupBox4.Controls.Add(Me.optBoaAparenciaSim)
        Me.GroupBox4.Location = New System.Drawing.Point(385, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(118, 115)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Boa aparência?"
        '
        'optBoaAparenciaNao
        '
        Me.optBoaAparenciaNao.AutoSize = True
        Me.optBoaAparenciaNao.Location = New System.Drawing.Point(6, 42)
        Me.optBoaAparenciaNao.Name = "optBoaAparenciaNao"
        Me.optBoaAparenciaNao.Size = New System.Drawing.Size(45, 17)
        Me.optBoaAparenciaNao.TabIndex = 5
        Me.optBoaAparenciaNao.TabStop = True
        Me.optBoaAparenciaNao.Text = "Não"
        Me.optBoaAparenciaNao.UseVisualStyleBackColor = True
        '
        'optBoaAparenciaSim
        '
        Me.optBoaAparenciaSim.AutoSize = True
        Me.optBoaAparenciaSim.Checked = True
        Me.optBoaAparenciaSim.Location = New System.Drawing.Point(6, 20)
        Me.optBoaAparenciaSim.Name = "optBoaAparenciaSim"
        Me.optBoaAparenciaSim.Size = New System.Drawing.Size(42, 17)
        Me.optBoaAparenciaSim.TabIndex = 4
        Me.optBoaAparenciaSim.TabStop = True
        Me.optBoaAparenciaSim.Text = "Sim"
        Me.optBoaAparenciaSim.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Observações:"
        '
        'txtObs
        '
        Me.txtObs.ForeColor = System.Drawing.Color.Blue
        Me.txtObs.Location = New System.Drawing.Point(16, 152)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(487, 62)
        Me.txtObs.TabIndex = 5
        '
        'cmdOK
        '
        Me.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOK.ForeColor = System.Drawing.Color.Red
        Me.cmdOK.Location = New System.Drawing.Point(428, 221)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.ForeColor = System.Drawing.Color.Blue
        Me.btnSair.Location = New System.Drawing.Point(348, 221)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 7
        Me.btnSair.Text = "Cancelar"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'frmInformacoesRestritas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(511, 253)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInformacoesRestritas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caracteristicas físicas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optIndigina As System.Windows.Forms.RadioButton
    Friend WithEvents optPardo As System.Windows.Forms.RadioButton
    Friend WithEvents optNegro As System.Windows.Forms.RadioButton
    Friend WithEvents optBranco As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optFumanteNao As System.Windows.Forms.RadioButton
    Friend WithEvents optFumanteSim As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optTatuagemNao As System.Windows.Forms.RadioButton
    Friend WithEvents optTatuagemSim As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optBoaAparenciaNao As System.Windows.Forms.RadioButton
    Friend WithEvents optBoaAparenciaSim As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents btnSair As System.Windows.Forms.Button
End Class
