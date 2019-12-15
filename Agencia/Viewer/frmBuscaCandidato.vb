Imports DTO
Imports BLL

Public Class frmBuscaCandidato

    Private Candidatos As List(Of Candidato)
    Private _alterar As Boolean = False
    Private _candidato As Candidato = Nothing

    Public WriteOnly Property AlterarCandidato As Boolean
        Set(ByVal value As Boolean)
            _alterar = True
        End Set
    End Property

    Public ReadOnly Property Candidato As Candidato
        Get
            Return _candidato
        End Get
    End Property

    Private Sub Pesquisar()
        If txtNome.Text = "" And txtDocumento.Text = "" Then
            MessageBox.Show("Digite pelo menos um parametro para efetuar a busca.", "Parametros inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            Candidatos = RegrasDeNegocio.GetCandidatos(Me.txtNome.Text, Me.txtDocumento.Text, Me.chkAtivo.Checked)

            If Candidatos.Count = 0 Then
                MessageBox.Show("Nenhum candidato localizado!", "Parametro invalido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                Me.dgvCandidato.DataSource = Nothing
                Return
            End If

            Me.dgvCandidato.DataSource = (From _candidato In Candidatos Select _candidato.Codigo, _candidato.Nome, _candidato.Documento, _candidato.DataNascimento).ToList

            Me.Label3.Text = dgvCandidato.RowCount & " Registros encontrados"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            Call Pesquisar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCandidato.CellDoubleClick
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        _candidato = (From candidato In Candidatos Where candidato.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

        If _alterar Then
            Dim _alterarCandidato As New frmCandidato(_candidato)
            '_alterarCandidato.MdiParent = Application.OpenForms.OfType(Of frmPrincipal).FirstOrDefault
            _alterarCandidato.ShowDialog()

            Call Pesquisar()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtNome_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNome.KeyDown, txtDocumento.KeyDown
        If e.KeyData = Keys.Return Then
            Try
                Call Pesquisar()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK)
            End Try
        End If
    End Sub

    Private Sub dgvCandidato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCandidato.KeyDown
        Dim dgv = CType(sender, DataGridView)
        If dgv.RowCount = 0 Then Return

        If e.KeyData = Keys.Delete Then
            Dim _deletarCandidato As Candidato = (From candidato In Candidatos Where candidato.Codigo = dgv.Rows(dgv.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

            If _deletarCandidato.Situacao = "I" Then
                MessageBox.Show("Este candidato já se encontra inativo.", "Candidato já inativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Deseja excluir " & _deletarCandidato.Nome & "?", "Excluir candidato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _deletarCandidato.Situacao = "I"

                RegrasDeNegocio.AlterarCandidato(_deletarCandidato)

                Call Pesquisar()
            End If
        End If
    End Sub

    Private Sub frmBuscaCandidato_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub
End Class