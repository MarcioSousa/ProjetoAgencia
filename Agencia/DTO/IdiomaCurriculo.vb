Imports System.Collections.Generic

Public Class IdiomaCurriculo
    Implements IDisposable

    Private _idioma As Idioma
    Private _curriculo As Curriculo
    Private _nativo As IdiomaNativo
    Private _obs As String = ""
    Private _status As Char = ""

    Public Property Idioma As Idioma
        Get
            Return _idioma
        End Get
        Set(ByVal value As Idioma)
            _idioma = value
        End Set
    End Property

    Public Property Curriculo As Curriculo
        Get
            Return _curriculo
        End Get
        Set(ByVal value As Curriculo)
            _curriculo = value
        End Set
    End Property

    Public Property Nativo As IdiomaNativo
        Get
            Return _nativo
        End Get
        Set(ByVal value As IdiomaNativo)
            _nativo = value
        End Set
    End Property

    Public Property Obs As String
        Get
            Return _obs
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property

    Public Property Status As Char
        Get
            Return _status
        End Get
        Set(ByVal value As Char)
            _status = value
        End Set
    End Property

    Public Enum IdiomaNativo
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
