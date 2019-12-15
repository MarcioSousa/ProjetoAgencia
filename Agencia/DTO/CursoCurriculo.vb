Public Class CursoCurriculo
    Implements IDisposable

    Private _curso As Curso
    Private _curriculo As Curriculo
    Private _dataInicial As Date
    Private _dataFinal As Date
    Private _concluido As Integer
    Private _obs As String = ""
    Private _certificado As String = ""
    Private _status As Char = ""

    Public Property Curso As Curso
        Get
            Return _curso
        End Get
        Set(ByVal value As Curso)
            _curso = value
        End Set
    End Property

    Public Property DataInicial As Date
        Get
            Return _dataInicial
        End Get
        Set(ByVal value As Date)
            _dataInicial = value
        End Set
    End Property

    Public Property DataFinal As Date
        Get
            Return _dataFinal
        End Get
        Set(ByVal value As Date)
            _dataFinal = value
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

    Public Property Concluido As Integer
        Get
            Return _concluido
        End Get
        Set(ByVal value As Integer)
            _concluido = value
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

    Public Property PathCertificado As String
        Get
            Return _certificado
        End Get
        Set(ByVal value As String)
            _certificado = value
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
