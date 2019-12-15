Imports System.Collections.Generic

Public Class Cidade
    Implements IDisposable

    Private _codigo As String = ""
    Private _descricao As String = ""
    Private _uf As String = ""
    Private _situacao As Char = ""
    Private _lstCandidatos As List(Of Candidato)

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property Descricao As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
        End Set
    End Property

    Public Property UF As String
        Get
            Return _uf
        End Get
        Set(ByVal value As String)
            _uf = value
        End Set
    End Property

    Public Property Situacao As Char
        Get
            Return _situacao
        End Get
        Set(ByVal value As Char)
            _situacao = value
        End Set
    End Property

    Public Property Candidatos As List(Of Candidato)
        Get
            Return _lstCandidatos
        End Get
        Set(ByVal value As List(Of Candidato))
            _lstCandidatos = value
        End Set
    End Property

    Public Sub New()
        _lstCandidatos = New List(Of Candidato)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
