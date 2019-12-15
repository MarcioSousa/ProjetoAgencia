Imports Utilidades

Public NotInheritable Class frmSplash

    Private Sub tmrStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStart.Tick
        Dim _timer = CType(sender, Timer)

        Try
            _timer.Enabled = False
            Utils.SetarParametros()
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(0)
        End Try

        Me.Visible = False
        Dim Login As New frmLogin
        Login.Show()
    End Sub
End Class
