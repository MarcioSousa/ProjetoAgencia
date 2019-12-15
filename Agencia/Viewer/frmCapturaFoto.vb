Imports AForge.Video.DirectShow
Imports AForge
Imports AForge.Imaging.Filters

Public Class frmCapturaFoto
    Private _video As VideoCaptureDevice = Nothing
    Private _resizeImagem As ResizeBilinear = Nothing
    Private _imagem As Image = Nothing
    Private _webcams As FilterInfoCollection = Nothing

    Public ReadOnly Property FotoCandidato As Image
        Get
            Return _imagem
        End Get
    End Property

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'Carrega todas as webcams conectadas ao computador
        _webcams = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        Try
            Call CarregarCameras(_webcams)
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NovaImagem(ByVal sender As Object, ByVal e As AForge.Video.NewFrameEventArgs)
        Me.picFoto.Image = _resizeImagem.Apply(e.Frame)
    End Sub

    Private Sub frmCapturaFoto_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _video Is Nothing Then
            _video.SignalToStop()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        _imagem = Me.picFoto.Image
        RemoveHandler _video.NewFrame, AddressOf NovaImagem
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Joga a coleção na combo para o usuario poder selecionar o dispositivo
    ''' </summary>
    ''' <param name="pCams">Coleção de cameras</param>
    ''' <remarks></remarks>
    Private Sub CarregarCameras(ByVal pCams As FilterInfoCollection)
        Try
            'adiciona uma a uma
            For Each cam As FilterInfo In pCams
                cmbWebCams.Items.Add(cam.Name)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Toda vez que mudar a seleção da webcam, mudará o dispositivo para tirar a foto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbWebCams_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWebCams.SelectedIndexChanged
        Dim _combo = CType(sender, ComboBox)

        'caso nao tenha nenhum item selecionado, nao habilitar o botão para fotografar
        If Not _combo.SelectedItem = Nothing Then
            Button1.Enabled = True
        Else
            Return
        End If

        Try
            'recebe o indice da camera selecionada pelo usuario
            Me._video = New VideoCaptureDevice(_webcams(_combo.SelectedIndex).MonikerString)

            'exibe como texto da janela o nome da webcam
            Me.Text = cmbWebCams.SelectedItem

            'deixa o video do tamanho do picturebox
            Me._resizeImagem = New ResizeBilinear(Me.picFoto.Width, Me.picFoto.Height)

            'adiciona o evento para receber os frames
            AddHandler _video.NewFrame, AddressOf NovaImagem

            'inicia a captura de imagem
            _video.Start()
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class