Imports BLL
Imports DTO

Public Class frmBuscaCurso

    Private _lstCursos As List(Of Curso)
    Private _curso As Curso = Nothing
    Private _alterar As Boolean

    Public ReadOnly Property Curso As Curso
        Get
            Return _curso
        End Get
    End Property

    Public WriteOnly Property Alterar As Boolean
        Set(ByVal value As Boolean)
            _alterar = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Pesquisa()
        Try
            If txtCurso.Text = "" Then
                MessageBox.Show("Digite pelo menos um parametro para efetuar a busca.", "Parametros inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            _lstCursos = RegrasDeNegocio.GetCursos(Me.txtCurso.Text, IIf(chkAtivo.Checked, "A", "I"))

            If _lstCursos.Count = 0 Then
                MessageBox.Show("Nenhum curso localizado.", "Parametro invalido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                Me.dgvCursos.DataSource = Nothing
                Return
            End If

            Me.dgvCursos.DataSource = (From _curso In Me._lstCursos Order By _curso.Entidade.Cidade.Descricao Select Codigo = _curso.Codigo, NomeCurso = _curso.Descricao, EntidadeEnsino = _curso.Entidade.Descricao, Local = _curso.Entidade.Cidade.Descricao, UF = _curso.Entidade.Cidade.UF).ToList

            Me.lblTotal.Text = dgvCursos.RowCount & " Registro(s) encontrado(s)"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Call Pesquisa()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub dgvCursos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCursos.DoubleClick
        Dim dgrid As DataGridView = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then Return

        _curso = (From c In _lstCursos Where c.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

        Try
            If _alterar Then
                Dim AlterarCurso As New frmCurso(_curso)
                AlterarCurso.ShowDialog()

                Me.Pesquisa()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCurso.KeyDown
        If e.KeyData = Keys.Return Then
            Try
                Call Pesquisa()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub frmBuscaCurso_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.pPrincipal.Left = (Me.Width / 2) - (pPrincipal.Width / 2)
    End Sub

    Private Sub dgvCursos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCursos.KeyDown
        Dim dgrid = CType(sender, DataGridView)

        If dgrid.RowCount = 0 Then
            Return
        End If

        If e.KeyData = Keys.Delete Then
            Dim _curso As Curso = (From c In _lstCursos Where c.Codigo = dgrid.Rows(dgrid.SelectedCells(0).RowIndex).Cells(0).Value).FirstOrDefault

            If _curso.Situacao = "I" Then
                MessageBox.Show("Este curso já se encontra inativo.", "Curso já inativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show("Deseja deletar o curso " & _curso.Descricao & "?", "Deletar curso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                _curso.Situacao = "I"

                RegrasDeNegocio.AlterarCurso(_curso)

                Call Pesquisa()
            End If
        End If
    End Sub
End Class