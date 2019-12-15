Public Class CargoPretendidoCurriculo
    Implements IDisposable

    Private _curriculo As Curriculo
    Private _cargo As Cargo
    Private _status As Char = ""
    Private _principal As Integer

    Public Property Curriculo As Curriculo
        Get
            Return _curriculo
        End Get
        Set(ByVal value As Curriculo)
            _curriculo = value
        End Set
    End Property

    Public Property Cargo As Cargo
        Get
            Return _cargo
        End Get
        Set(ByVal value As Cargo)
            _cargo = value
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

    Public Property Principal As Integer
        Get
            Return _principal
        End Get
        Set(ByVal value As Integer)
            _principal = value
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
