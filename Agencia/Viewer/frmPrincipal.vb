Public Class frmPrincipal

    Private Sub PesquisarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PesquisarToolStripMenuItem.Click
        Dim PesquisarCandidato As New frmBuscaCandidato
        PesquisarCandidato.AlterarCandidato = True
        PesquisarCandidato.MdiParent = Me
        PesquisarCandidato.Show()
    End Sub

    Private Sub CadastrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastrarToolStripMenuItem.Click
        Dim CadastrarNovoCandidato As New frmCandidato
        CadastrarNovoCandidato.MdiParent = Me
        CadastrarNovoCandidato.Show()
    End Sub

    'Private Sub CadastrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastrarToolStripMenuItem1.Click
    '    Dim CadastrarCurriculo As New frmCurriculo
    '    CadastrarCurriculo.WindowState = FormWindowState.Maximized
    '    CadastrarCurriculo.MdiParent = Me
    '    CadastrarCurriculo.Show()
    'End Sub

    Private Sub CadastroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroToolStripMenuItem1.Click
        Dim CadastrarEntidadeEnsino As New frmCadastroEntidadeEnsino
        CadastrarEntidadeEnsino.MdiParent = Me
        CadastrarEntidadeEnsino.Show()
    End Sub

    Private Sub PesquisarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PesquisarToolStripMenuItem1.Click
        Dim PesquisarEntidade As New frmBuscaEntidade
        PesquisarEntidade.Alterar = True
        PesquisarEntidade.MdiParent = Me
        PesquisarEntidade.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroToolStripMenuItem2.Click
        Dim CadastroCurso As New frmCurso
        CadastroCurso.MdiParent = Me
        CadastroCurso.Show()
    End Sub

    Private Sub PesquisarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PesquisarToolStripMenuItem2.Click
        Dim BuscaCurso As New frmBuscaCurso
        BuscaCurso.Alterar = True
        BuscaCurso.MdiParent = Me
        BuscaCurso.Show()
    End Sub

    Private Sub CadastroToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroToolStripMenuItem3.Click
        Dim CadastroEmpresa As New frmCadastroEmpresa
        CadastroEmpresa.MdiParent = Me
        CadastroEmpresa.Show()
    End Sub

    Private Sub PesquisarToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PesquisarToolStripMenuItem3.Click
        Dim PesquisaEmpresa As New frmBuscaEmpresa
        PesquisaEmpresa.Alterar = True
        PesquisaEmpresa.MdiParent = Me
        PesquisaEmpresa.Show()
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tlsUsuario.Text = "USUARIO LOGADO:>> " & Utilidades.User.NomeLogin.ToUpper
        Me.tlsElevacao.Text = "ELEVAÇÃO:>> " & [Enum].GetName(GetType(Utilidades.User.Elevacao), Utilidades.User.ElevacaoUsuario).ToUpper
        Me.tlsHoraLogon.Text = "DATA E HORA DE LOGON:>> " & Now
    End Sub

    Private Sub frmPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Deseja sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Environment.Exit(0)
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SAIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAIRToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SoberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoberToolStripMenuItem.Click
        MessageBox.Show("Versão: " & My.Application.Info.Version.Revision & " (Revisao)")
    End Sub

    Private Sub CadastroToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CadastroToolStripMenuItem4.Click
        Dim _cidade As New frmCidade
        _cidade.MdiParent = Me
        _cidade.Show()
    End Sub
End Class