Imports DTO
Imports BLL

Public Class frmBuscaEntidade

    Private _lstEntidade As List(Of Entidade) = Nothing
    Private _entidade As Entidade = Nothing

    Private _alterar As Boolean

    Public ReadOnly Property Entidade As Entidade
        Get
            Return _entidade
        End Get
    End Property

    Public WriteOnly Property Alterar As Boolean
        Set(ByVal value As Boolean)
            _alterar = value
        End Set
    End Property

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Call Pesquisa()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Pesquisa()
        If txtEntidade.Text = "" Then
            MessageBox.Show("Digite pelo menos um parametro para efetuar a busca.", "Parametros inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            _lstEntidade = RegrasDeNegocio.GetEntidades(Me.txtEntidade.Text, IIf(chkAtivo.Checked, "A", "I"))

            If _lstEntidade.Count = 0 Then
                MessageBox.Show("Nenhuma entidade localizada.", "Parametro invalido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                dgvEntidades.DataSource = Nothing
                Return
            End If

            Me.dgvEntidades.DataSource = (From _entidade In _lstEntidade Select Codigo = _entidade.Codigo, Nome = _entidade.Descricao, Cidade = _entidade.Cidade.Descricao, UF = _entidade.Cidade.UF).ToList

            Me.Label3.Text = Me.dgvEntidades.RowCount & " Registro(s) encontrado(s)"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvEntidades_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEntidades.DoubleClick
        Dim grid As DataGridView = CType(sender, DataGridView)

        If grid.RowCount = 0 Then
            Return
        End If

        _entidade = (From ent In _lstEntidade Where ent.Codigo = grid.Rows(grid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

        Try
            If _alterar Then
                Dim alterarEntidade As New frmCadastroEntidadeEnsino(_entidade)
                alterarEntidade.ShowDialog()

                Call Pesquisa()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtEntidade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidade.KeyDown
        If e.KeyData = Keys.Return Then
            Try
                Call Pesquisa()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub pPrincipal_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pPrincipal.Resize
        Me.pPrincipal.Left = (Me.pPrincipal.Width / 2) - (pPrincipal.Width / 2)
    End Sub

    Private Sub dgvEntidades_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEntidades.KeyDown
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        If e.KeyData = Keys.Delete Then
            Dim _entidade As Entidade = (From _e In _lstEntidade Where _e.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

            If _entidade.Situacao = "I" Then
                MessageBox.Show("Esta entidade já se encontra inativa.", "Entidade ja inativa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Deseja deletar a entidade " & _entidade.Descricao & "?", "Deletar entidade", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _entidade.Situacao = "I"
                RegrasDeNegocio.AlterarEntidade(_entidade)
                Call Pesquisa()
            End If
        End If
    End Sub
End Class