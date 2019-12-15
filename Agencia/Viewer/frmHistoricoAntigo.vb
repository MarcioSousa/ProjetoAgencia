Imports DTO
Imports BLL

Public Class frmHistoricoAntigo
    Private _codigo, _nome As String


    Public Sub New(ByVal pNomeCandidato As String, ByVal pCodigoCandidato As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _codigo = pCodigoCandidato
        _nome = pNomeCandidato
    End Sub

    Private Sub frmHistoricoAntigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = _nome

        Try
            Dim listaHistorico As List(Of HistoricoFB) = RegrasDeNegocio.GetHistorico(_codigo)

            If listaHistorico.Count = 0 Then
                MessageBox.Show("Este candidato nao possui historicos antigos.", "Candidato sem historico", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            For Each h In listaHistorico
                txtHistorico.Text += "Data/Hora: " & h.Data & vbCrLf & h.Historico & vbCrLf & "-----------------" & vbCrLf & vbCrLf
            Next
        Catch ex As Exception
            MessageBox.Show("Houve uma exceção: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class