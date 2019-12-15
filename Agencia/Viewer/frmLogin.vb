Imports BLL

Public Class frmLogin

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        If MessageBox.Show("Deseja sair do sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown, txtSenha.KeyDown
        If e.KeyData = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnLogar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogar.Click
        Dim _logado As Boolean = False

        Try
            RegrasDeNegocio.Login(Me.txtUsuario.Text, Me.txtSenha.Text)

            Dim _principal As New frmPrincipal
            _principal.Show()

            Me.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogin_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.txtUsuario.Focus()
    End Sub
End Class