Imports DTO
Imports BLL

Public Class frmBuscaEmpresa
    Private _empresas As List(Of Empresa)
    Private _alterar As Boolean
    Private _empresa As Empresa = Nothing

    Public ReadOnly Property Empresa As Empresa
        Get
            Return _empresa
        End Get
    End Property

    Public WriteOnly Property Alterar As Boolean
        Set(ByVal value As Boolean)
            _alterar = value
        End Set
    End Property

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Call Pesquisa()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Pesquisa()
        If txtNomeFan.Text = "" And txtRazSoc.Text = "" Then
            MessageBox.Show("Digite pelo menos um parametro para efetuar a busca.", "Parametros inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        Try
            _empresas = RegrasDeNegocio.GetEmpresas(Me.txtRazSoc.Text, Me.txtNomeFan.Text, IIf(chkAtivos.Checked, True, False))

            If _empresas.Count = 0 Then
                MessageBox.Show("Nenhuma empresa localizada.", "Parametro invalido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                Me.dgvEmpresas.DataSource = Nothing
            Else
                Me.dgvEmpresas.DataSource = (From _empresa In _empresas Select Codigo = _empresa.Codigo, RazSocial = _empresa.RazaoSocial, NomeFan = _empresa.NomeFantasia, _empresa.Cidade.Descricao, _empresa.Cidade.UF).ToList
            End If

            Label3.Text = dgvEmpresas.Rows.Count & " Registro(s) encontrado(s)"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub dgvEmpresas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEmpresas.DoubleClick
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        _empresa = (From _selecionado In _empresas Where _selecionado.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

        Try
            If _alterar Then
                Dim AlterarEmpresa As New frmCadastroEmpresa(_empresa)
                AlterarEmpresa.ShowDialog()

                Call Pesquisa()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRazSoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRazSoc.KeyDown, txtNomeFan.KeyDown
        If e.KeyData = Keys.Return Then
            Try
                Call Pesquisa()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub frmBuscaEmpresa_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub

    Private Sub dgvEmpresas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEmpresas.KeyDown
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        If e.KeyData = Keys.Delete Then
            Dim _empresa As Empresa = (From _e In _empresas Where _e.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

            If _empresa.Situacao = "I" Then
                MessageBox.Show("Esta empresa já se encontra inativa.", "Empresa inativa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Deseja deletar a empresa " & _empresa.NomeFantasia & "?", "Deletar empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _empresa.Situacao = "I"

                RegrasDeNegocio.AlterarEmpresa(_empresa)

                Call Pesquisa()
            End If
        End If
    End Sub
End Class