Public Class User
    Public Shared Property CodigoUsuario As String
    Public Shared Property NomeUsuario As String
    Public Shared Property Situacao As Char
    Public Shared Property NomeLogin As String
    Public Shared Property ElevacaoUsuario As elevacao

    Public Enum Elevacao
        Administrador
        Limitado
    End Enum

End Class
