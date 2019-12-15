Imports System.Collections.Generic

Public Class Empresa
    Implements IDisposable

    Private _codigo As String = ""
    Private _nomeFantasia As String = ""
    Private _razSocial As String = ""
    Private _situacao As Char = ""
    Private _cliente As EmpresaCliente
    Private _cidade As Cidade

    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property NomeFantasia As String
        Get
            Return _nomeFantasia
        End Get
        Set(ByVal value As String)
            _nomeFantasia = value
        End Set
    End Property

    Public Property RazaoSocial As String
        Get
            Return _razSocial
        End Get
        Set(ByVal value As String)
            _razSocial = value
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

    Public Property Cliente As EmpresaCliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As EmpresaCliente)
            _cliente = value
        End Set
    End Property

    Public Property Cidade As Cidade
        Get
            Return _cidade
        End Get
        Set(ByVal value As Cidade)
            _cidade = value
        End Set
    End Property


    Public Enum EmpresaCliente
        Nao
        Sim
    End Enum

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
