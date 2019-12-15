Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports

Public Class frmViewer
    Public Sub New(ByVal pDataSet As DataSet)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Dim rptDoc As New ReportDocument

        Try
            rptDoc.Load(Utilidades.Utils.DiretorioRelatorio)

            rptDoc.SetDataSource(pDataSet)

            Me.CrystalReportViewer1.ReportSource = rptDoc

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Erro ao carregar curriculo. " & ex.Message, "Erro", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub
End Class