Imports System.IO
Imports System
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data.Common
Imports SPI.XML
Imports Maxum.Invoices
Imports InvoicePaths = Maxum.CustomerInvoiceBatchCustomerInvoicesInvoiceNumberFilePaths
Imports System.Windows.Media.Imaging

Public Class Form1
    'Dim myBS As BindingSource

    'Const myArchiveFolder As String = "\\SPIS420\Sirm_Archive\"
    'Const serverRoot As String = "\\SPIS420\"
    'Private _image As Image = Nothing
    'Private _selectedBatch As String = String.Empty
    'Private _selectedFileName As String = String.Empty
    'Private _selectedPath As String = "\\Spis420\SIRM_UNKNOWN\" ' "\\spis420\imstore$\001\" '917\001917378-3818499.TIF" '"\\spis420\SIRM_Queue\Test\" ' 
    'Private _newWidth As Integer
    'Private _newHeight As Integer
    'Private _newImage As System.Drawing.Image

    'Public Sub New()

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    ' Me.Size = New Drawing.Size(960, 1080)
    'End Sub

    'Private Sub getfolders()
    '    Dim dirinfo As New DirectoryInfo(_selectedPath)
    '    Dim dirs() As DirectoryInfo = dirinfo.GetDirectories()
    '    Dim xnode As New TreeNode(_selectedPath)
    '    xnode.ImageIndex = 1
    '    FoldersTreeView.Nodes.Add(xnode)
    '    FoldersTreeView.SelectedNode = xnode
    '    For Each dir As DirectoryInfo In dirs
    '        Dim newnode As TreeNode = New TreeNode(dir.Name)
    '        newnode.ImageIndex = 0
    '        FoldersTreeView.SelectedNode.Nodes.Add(newnode)
    '    Next
    '    tsmiRotate.Enabled = False

    'End Sub

    'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DsData.vw_DocumentTypes' table. You can move, or remove it, as needed.
    '    Me.Vw_DocumentTypesTableAdapter.Fill(Me.DsData.vw_DocumentTypes)
    '    FoldersTreeView.ImageList = ImageList1
    '    getfolders()

    'End Sub

    'Private Sub FoldersTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles FoldersTreeView.AfterSelect
    '    Dim dirInfo As DirectoryInfo = Nothing
    '    If e.Node.Text <> "Collator" Then
    '        ImageListBox.Items.Clear()

    '        If e.Node.Text.StartsWith("\") Then
    '            dirInfo = New DirectoryInfo(e.Node.Text)
    '        Else
    '            _selectedBatch = _selectedPath & e.Node.Text
    '            dirInfo = New DirectoryInfo(_selectedBatch)
    '        End If

    '        Dim fi As FileInfo() = dirInfo.GetFiles
    '        'Dim myDate As Date = New Date(2009, 4, 10)
    '        For Each f As FileInfo In fi
    '            'If f.CreationTime > myDate Then
    '            If f.Extension.ToLower = ".tif" Then
    '                ImageListBox.Items.Add(f.Name)
    '            End If
    '            ' End If
    '        Next
    '    End If
    'End Sub

    'Private Sub ImageListBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageListBox.Click

    'End Sub

    'Private Sub ShowImage()
    '    Dim p As String


    '    p = _selectedBatch & "\" & _selectedFileName
    '    Try
    '        PictureBox1.Image = Nothing
    '        _image = System.Drawing.Image.FromFile(p)
    '        If PictureBox1.Height < PictureBox1.Width + 225 Then
    '            _newHeight = PictureBox1.Height
    '            _newWidth = CInt(_image.Width * (PictureBox1.Height / _image.Height))
    '        Else
    '            _newWidth = PictureBox1.Width
    '            _newHeight = CInt(_image.Height * (PictureBox1.Width / _image.Width))
    '        End If

    '        _newImage = New Bitmap(_newWidth, _newHeight)

    '        Dim newGraphic As Drawing.Graphics = System.Drawing.Graphics.FromImage(_newImage)

    '        newGraphic.DrawImage(_image, 0, 0, _newWidth, _newHeight)
    '        With newGraphic
    '            .CompositingMode = Drawing2D.CompositingMode.SourceCopy
    '            .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
    '            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
    '        End With
    '        Dim strm As New MemoryStream()

    '        _newImage.Save(strm, Imaging.ImageFormat.Tiff)
    '        Dim img As Image = Image.FromStream(strm)
    '        PictureBox1.Image = img
    '        PictureBox1.Refresh()
    '        strm.Close()
    '        strm.Dispose()
    '        strm = Nothing
    '        _image.Dispose()
    '        _image = Nothing

    '        'ImageView1.PictureViewer.Image = img
    '    Catch ex As FileNotFoundException
    '        MessageBox.Show("Can't Find the File", "Viewer")
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        tsmiRotate.Enabled = PictureBox1.Image IsNot Nothing
    '    End Try
    'End Sub

    'Private Sub ImageListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageListBox.SelectedIndexChanged
    '    If ImageListBox.SelectedIndex > -1 Then
    '        If PictureBox1.Image IsNot Nothing Then
    '            PictureBox1.Image.Dispose()
    '            PictureBox1.Image = Nothing
    '        End If

    '        _selectedFileName = ImageListBox.Items(ImageListBox.SelectedIndex).ToString()
    '        ShowImage()
    '    End If

    'End Sub


    'Private Sub Form1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    '    'Debug.WriteLine("Form Size Height:" & Me.Size.Height.ToString & "    Width: " & Me.Size.Width.ToString)
    '    'Debug.WriteLine("Pic Box: Height:  " & Me.PictureBox1.Size.Height.ToString & "   Width: " & PictureBox1.Size.Width.ToString)
    '    If _newImage IsNot Nothing AndAlso Me.WindowState <> FormWindowState.Minimized Then
    '        ShowImage()
    '    End If
    'End Sub

    'Private Sub tsmiRotate_Click(sender As System.Object, e As System.EventArgs) Handles tsmiRotate.Click

    '    _newImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
    '    PictureBox1.Image = _newImage
    '    Try
    '        ' This saves the rotate.
    '        Using strm As New MemoryStream()
    '            Dim tmpFilePath As String = _selectedBatch & Path.DirectorySeparatorChar & Path.GetFileNameWithoutExtension(_selectedFileName) & ".tmp"
    '            Dim filePath As String = _selectedBatch & Path.DirectorySeparatorChar & _selectedFileName
    '            _image.RotateFlip(RotateFlipType.Rotate180FlipNone)
    '            File.Move(filePath, tmpFilePath)
    '            _image.Save(strm, Imaging.ImageFormat.Tiff)
    '            EncodeTiffToCCITT4(strm, _selectedBatch & Path.DirectorySeparatorChar & _selectedFileName)
    '            If File.Exists(filePath) Then
    '                File.Delete(tmpFilePath)
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
    'Private Sub EncodeTiffToCCITT4(strm As Stream, ByVal destination As String)
    '    'Dim newSourceName As String = Path.GetFileNameWithoutExtension(source) & ".tmp"
    '    'File.Move(source, newSourceName)
    '    Using stream As New FileStream(destination, FileMode.Create)
    '        Dim encoder As New TiffBitmapEncoder()
    '        ' Using imageStreamSource As New FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read)

    '        Dim decoder As New TiffBitmapDecoder(strm, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
    '        encoder.Compression = TiffCompressOption.Ccitt4

    '        For i As Integer = 0 To decoder.Frames.Count - 1
    '            encoder.Frames.Add(decoder.Frames(i))
    '        Next

    '        encoder.Save(stream)
    '        ' imageStreamSource.Close()
    '        ' imageStreamSource.Dispose()
    '        'End Using
    '        stream.Close()
    '        stream.Dispose()
    '    End Using
    'End Sub

    'Private Sub tsmiRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tsmiRefresh.Click
    '    Dim dirInfo As New DirectoryInfo(_selectedBatch)
    '    Dim fi As FileInfo() = dirInfo.GetFiles("*.tif")
    '    'Dim myDate As Date = New Date(2009, 4, 10)
    '    ImageListBox.Items.Clear()
    '    For Each f As FileInfo In fi
    '        'If f.CreationTime > myDate Then
    '        If f.Extension.ToLower = ".tif" Then
    '            ImageListBox.Items.Add(f.Name)
    '        End If
    '    Next
    'End Sub


    'Private Sub btnSendToDoclink_Click(sender As System.Object, e As System.EventArgs) Handles btnSendToDoclink.Click
    '    'TODO check all conditions before copy.o

    '    If cboDocumentNumber.SelectedIndex > -1 AndAlso cboWorkflow.SelectedIndex > -1 AndAlso _newImage IsNot Nothing AndAlso txtOrderNumber.Text.Length > 6 Then

    '        Dim myGuid As String = String.Empty
    '        Dim oldFileName As String = _selectedBatch & "\" & _selectedFileName
    '        Dim split() As String = Path.GetFileNameWithoutExtension(oldFileName).Split(CChar("-"))
    '        If split.Count = 3 Then
    '            myGuid = split(2).ToString()
    '        Else
    '            Dim newGuid As Guid = Guid.NewGuid()
    '            myGuid = newGuid.ToString
    '        End If
    '        Dim newFileName As String = String.Format("{0}\{1}-{2}-{3}.tif", My.Settings.CompletedFolder, txtOrderNumber.Text, cboDocumentNumber.Text, myGuid.Replace("-", ""))

    '        Try
    '            File.Move(oldFileName, newFileName)
    '            If File.Exists(newFileName) Then
    '                File.Delete(oldFileName)
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try

    '        With ImageListBox
    '            Dim prevSelected As Integer = .SelectedIndex
    '            .Items.RemoveAt(prevSelected)
    '            .Refresh()
    '            If .Items.Count > 0 Then
    '                .SelectedIndex = prevSelected
    '                .Refresh()
    '            End If
    '        End With

    '    Else
    '        MessageBox.Show("Invalid Workflow Selection")
    '    End If

    'End Sub
End Class
