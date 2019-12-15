Imports BLL
Imports DTO

Public Class frmCidade

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Cadastro de cidades[Novo registro]"

    End Sub

    Private Sub frmCidade_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim _cidade As New Cidade

        If txtCidade.Text = "" Then
            _cidade.Descricao = ""
        Else
            _cidade.Descricao = Me.txtCidade.Text
        End If

        If txtUf.Text = "" Then
            _cidade.UF = ""
        Else
            _cidade.UF = Me.txtUf.Text
        End If

        _cidade.Situacao = IIf(chkAtivo.Checked, "A", "I")

        Try
            RegrasDeNegocio.InserirCidade(_cidade)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub

    Private Sub txtCidade_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCidade.Leave
        Dim _texto = CType(sender, TextBox)
        _texto.Text = _texto.Text.ToUpper

    End Sub

    Private Sub txtUf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUf.Leave
        Dim _texto = CType(sender, TextBox)
        _texto.Text = _texto.Text.ToUpper
    End Sub

    Private Sub txtCidade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCidade.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUf_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUf.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class