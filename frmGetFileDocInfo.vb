Imports System.IO
Imports System
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Threading
Imports System.Runtime.Remoting.Messaging
Imports System.Windows.Media.Imaging
Imports System.Runtime.InteropServices

Public Class frmGetFileDocInfo
    Private _archiveButtonSelectedBackColor As Color = Color.DeepSkyBlue
    Private _imageFrame As Integer = 0
    Private _imageFrameCount As Integer = 0
    Private _selectedBatch As String = String.Empty
    Private _selectedFileName As String = String.Empty
    Private _fileInfo As New CommonDataSet.GetDocumentInfoFromFileDataTable
    Private _paths As List(Of Paths) = Nothing
    Private _previousSelectedFileName As String
    Private _autorun As Boolean = False
    Public Sub New()
        Dim args() As String = Environment.GetCommandLineArgs
        If args.Length > 1 AndAlso args(1) = "Auto" Then
            Debug.WriteLine("Arg: " & args(1).ToString)
            _autorun = True
            Me.Visible = False
            AutoResolve()
        Else
            InitializeComponent()
            ' This call is required by the Windows Form Designer.
            ' Add any initialization after the InitializeComponent() call.
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            Dim pos As Integer = My.User.Name.IndexOf("\")
            Dim usr As String = My.User.Name.Substring(pos + 1, My.User.Name.Length - pos - 1)
            AdminToolStripMenuItem.Visible = My.Settings.SUser.Contains(usr.ToLower)
        End If
    End Sub

    'Private Sub ShowImage2()
    '    'Dim p As String


    '    ' p = _selectedBatch & "\" & _selectedFileName
    '    Try
    '        PictureBox1.Image = Nothing
    '        _image = System.Drawing.Image.FromFile(_selectedFileName)


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


    '        Dim g() As Guid = _newImage.FrameDimensionsList

    '        Dim d As New System.Drawing.Imaging.FrameDimension(g(0))
    '        Dim frameCount As Integer = _newImage.GetFrameCount(d)


    '        Dim img As Image = Image.FromStream(strm)
    '        PictureBox1.Image = img
    '        Try
    '            ' PictureBox1.Image.SelectActiveFrame(d, 1)
    '        Catch ex As Exception
    '            Debug.WriteLine(ex.ToString)
    '        End Try


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
    Private Sub ReleaseImage()
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
            PictureBox1.Refresh()
        End If
    End Sub
    Private Sub SetProgressTimer(enable As Boolean)
        With Timer1
            .Tag = String.Empty
            .Enabled = False
            ProgressBar1.Visible = enable

            If enable Then
                .Interval = 500
                .Enabled = True
            Else
                ProgressBar1.Value = 0
            End If
        End With
    End Sub

    Private Sub SetImageTimer(enable As Boolean, sender As Object)
        ' Turn on the timer to dispose the Image after n minutes
        With Timer1
            .Enabled = False
            .Tag = String.Empty

            If enable Then
                .Tag = "ShowImage"
                If sender Is btnViewArchive Then
                    .Interval = 60000 * 10
                Else
                    .Interval = 60000 * 2
                End If
                .Enabled = True
            End If
        End With
    End Sub
    Private Sub ShowImage(ByVal sender As System.Object)
        ReleaseImage()

        If Not File.Exists(_selectedFileName) Then Exit Sub
        Try
            If _previousSelectedFileName <> _selectedFileName OrElse sender IsNot Nothing Then
                PictureBox1.Image = System.Drawing.Image.FromFile(_selectedFileName)
            End If
            PictureBox1.Image.SelectActiveFrame(Imaging.FrameDimension.Page, _imageFrame - 1)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            SetImageTimer(True, sender)

        Catch ex As FileNotFoundException
            MessageBox.Show("Can't Find the File", "Viewer")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            tsmiRotate.Enabled = PictureBox1.Image IsNot Nothing
            UpdatePageLabel()
            ManagePageButtons()
        End Try
    End Sub

    Public Sub ShowImage(imagePath As String, sender As Object, Optional filenameOrDocumentID As String = "")

        txtFileName.Text = filenameOrDocumentID
        If imagePath.Length > 0 Then
            ClearForm()
            _selectedFileName = imagePath
            _imageFrame = 1
            ShowImage(sender)
        End If



    End Sub

    Private Sub ClearForm()
        txtInfo.Clear()
        txtInfo.Refresh()
        txtContent.Text = "Page 0 of 0 Pages"
        _imageFrameCount = 0
        _imageFrame = 0

        ManagePageButtons()
        ImageListBox.Items.Clear()
        ImageListBox.Refresh()
        btnViewArchive.BackColor = Color.White
        _fileInfo.Clear()
        btnViewArchive.Enabled = _fileInfo.Rows.Count > 0
    End Sub

    Private Sub ImageListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageListBox.SelectedIndexChanged
        If ImageListBox.SelectedIndex > -1 Then


            _selectedFileName = _paths(ImageListBox.SelectedIndex).PathAndFilename
            _imageFrame = 1
            ShowImage(Nothing)

            ' btnCopyFileToCollator.Enabled = IsDeletedItem()
            btnViewArchive.BackColor = Color.White
        End If

    End Sub

    Private Sub tsmiRotate_Click(sender As System.Object, e As System.EventArgs) Handles tsmiRotate.Click
        Try
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub EncodeTiffToCCITT4(strm As Stream, ByVal destination As String)
        Using stream As New FileStream(destination, FileMode.Create)
            Dim encoder As New TiffBitmapEncoder()
            Dim decoder As New TiffBitmapDecoder(strm, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            encoder.Compression = TiffCompressOption.Ccitt4

            For i As Integer = 0 To decoder.Frames.Count - 1
                encoder.Frames.Add(decoder.Frames(i))
            Next

            encoder.Save(stream)
        End Using
    End Sub

    Private Sub btnGetInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnGetInfo.Click
        Try
            If txtFileName.Text.Length > 0 Then
                If (Not IsNumeric(txtFileName.Text)) AndAlso (Not txtFileName.Text.ToUpper.EndsWith(".TIF")) Then
                    txtFileName.Text += ".Tif"
                    txtFileName.Refresh()
                End If
                btnViewArchive.BackColor = Color.White
                ReleaseImage()
                ClearForm()
                txtInfo.Text = "                              Retrieving Information.....  Please Wait......"
                SetProgressTimer(True)
                BackgroundWorker1.RunWorkerAsync(New Boolean)

            End If

        Catch ex As Exception
            SetProgressTimer(False)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            GetDocumentInfoFromFileTableAdapter.Fill(_fileInfo, txtFileName.Text)
            If BackgroundWorker1.CancellationPending Then
                e.Cancel = True
            End If
        Catch ex As Exception
            txtInfo.Text = "Error: " & ex.Message
        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            SetImageTimer(False, sender)
            If (Not e.Cancelled) Then
                _paths = New List(Of Paths)
                If _fileInfo.Rows.Count > 0 Then
                    GetUnknownInfo()
                Else
                    txtInfo.Text = "Nothing was found. Make sure your file name is correct."
                End If
                _imageFrame = 1
            End If
        Catch ex As Exception
            txtInfo.Text = "An Error occured during processing!" & vbCrLf & ex.Message
        Finally
            Cursor.Current = Cursors.Default
            SetProgressTimer(False)
            btnViewArchive.Enabled = _fileInfo.Rows.Count > 0
        End Try
    End Sub



    Private Sub GetUnknownInfo()
        Try
            txtInfo.Clear()
            ImageListBox.Items.Clear()
            If _fileInfo.Rows.Count > 0 Then
                Dim sb As New StringBuilder(1000)
                Dim totalDocsProcessed As Integer = 0

                Dim totaldocsInFile As Integer = 0
                Dim idx As Integer = 0
                Dim originalFileName As String = _fileInfo(0).OriginalFileName
                Dim renamedFileName As String = _fileInfo(0).RenamedFile

                Dim processedFile As StringBuilder = New StringBuilder
                Dim previousProcessedFile As String = String.Empty
                Dim pfi = From f In _fileInfo
                    Group By pf = f.ProcessedFile, f.DocumentID
                    Into splitfiles = Group
                    Select splitfiles

                If pfi IsNot Nothing Then
                    For Each r As Maxum.CommonDataSet.GetDocumentInfoFromFileRow() In pfi
                        With r(0)
                            ' If the document was split for OCR. There will be the master original and the splits that = all in the master.
                            If r(0).ProcessedFile <> renamedFileName AndAlso idx = 0 Then
                                processedFile.AppendLine(renamedFileName)
                            End If
                            ' Again taking into account for split files. Listing and adding the sums to equal total in the original document.
                            If previousProcessedFile <> .ProcessedFile Then
                                previousProcessedFile = .ProcessedFile
                                processedFile.AppendLine(.ProcessedFile)
                                totaldocsInFile += .FilePageCount
                            End If

                            If .DocumentID > 0 Then
                                idx += 1
                                totalDocsProcessed += .DocumentPageCount
                                ImageListBox.Items.Add("Found In Doclink - KeyValue: " & .KeyPropertyValue & "    DocumentID: " & .DocumentID & "    Pages: " & .DocumentPageCount & "   Type: " & .DocumentTypeName)
                                Dim newPath As New Paths With {.Index = idx, .PathAndFilename = r(0).DLDocumentPath}
                                newPath.PathAndFilename = .DLDocumentPath
                                _paths.Add(newPath)
                            End If

                            ' These are the not indexed or deleted.
                            If .DocumentID = 0 Then
                                For Each dr As CommonDataSet.GetDocumentInfoFromFileRow In r
                                    ' Yes it must be in here twice in case something weird happens.
                                    If previousProcessedFile <> dr.ProcessedFile Then
                                        previousProcessedFile = dr.ProcessedFile
                                        processedFile.AppendLine(dr.ProcessedFile)
                                        totaldocsInFile += dr.FilePageCount
                                    End If

                                    idx += 1
                                    totalDocsProcessed += .DocumentPageCount

                                    If File.Exists(.DocumentIdOrCollatorPath) Then
                                        ImageListBox.Items.Add("Not Indexed: " & dr.DocumentIdOrCollatorPath)
                                    Else
                                        ImageListBox.Items.Add("Not Found: " & dr.DocumentIdOrCollatorPath)
                                    End If

                                    Dim newPath As New Paths With {.Index = idx, .PathAndFilename = dr.DocumentIdOrCollatorPath}
                                    _paths.Add(newPath)
                                Next

                            End If
                        End With
                    Next
                End If
                sb.AppendLine("Original File: " & originalFileName)
                sb.AppendLine("Renamed: " & renamedFileName)
                sb.AppendLine("Original File Document Count: " & totaldocsInFile)
                sb.AppendLine("Processed File Count: " & totalDocsProcessed)
                sb.AppendLine("Archived: " & vbCrLf & processedFile.ToString)
                If totalDocsProcessed >= totaldocsInFile Then
                    sb.AppendLine("All documents accounted for.")
                End If
                txtInfo.Text = sb.ToString()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub UpdatePageLabel()
        _imageFrameCount = PictureBox1.Image.GetFrameCount(Imaging.FrameDimension.Page)

        Dim content As String = "Page " & _imageFrame & " of " & _imageFrameCount.ToString() & " Pages"
        txtContent.Text = content
        ImageListBox.Focus()
    End Sub

    Private Sub ManagePageButtons()
        btnPrevious.Enabled = _imageFrame > 1
        txtGoToPage.Clear()
        btnNext.Enabled = _imageFrame <> _imageFrameCount
        lblGoToPage.Enabled = _imageFrameCount > 1
        txtGoToPage.Enabled = _imageFrameCount > 1
        btnReleaseImage.Enabled = PictureBox1.Image IsNot Nothing
    End Sub

    Private Sub btnPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevious.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            If _imageFrame > 1 Then
                _imageFrame -= 1
                ShowImage(Nothing)
            End If

        Catch ex As Exception
            '
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            If _imageFrameCount > _imageFrame Then
                _imageFrame += 1
                ShowImage(Nothing)
            End If
        Catch ex As Exception
            '
        Finally
            Cursor.Current = Cursors.Default
        End Try


    End Sub

    Private Function IsDeletedItem() As Boolean
        Return ImageListBox.Items(ImageListBox.SelectedIndex).Substring(0, 7) = "DELETED"
    End Function

    Private Sub btnCopyFileToCollator_Click(sender As System.Object, e As System.EventArgs) Handles btnCopyFileToCollator.Click
        Try

            If IsDeletedItem() Then
                Dim p As Paths = _paths(ImageListBox.SelectedIndex)

                If Not Directory.Exists(Path.GetDirectoryName(p.DeletedOrigin)) Then
                    Directory.CreateDirectory(Path.GetDirectoryName(p.DeletedOrigin))
                End If

                File.Copy(p.PathAndFilename, p.DeletedOrigin)
                If File.Exists(p.DeletedOrigin) Then
                    txtInfo.AppendText("Copied to " & p.DeletedOrigin)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    'Private Sub cmsImageListBox_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '    Try
    '        Dim sb As New StringBuilder()
    '        If e.ClickedItem.Text = "Copy Selected" Then
    '            For Each i As String In ImageListBox.SelectedItems
    '                sb.AppendLine(i)
    '            Next
    '        End If
    '        If e.ClickedItem.Text = "Copy All" Then
    '            For Each i As String In ImageListBox.Items
    '                sb.AppendLine(i)
    '            Next
    '        End If
    '        If sb.Length > 0 Then
    '            Clipboard.SetText(sb.ToString)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub


    Private Sub CopySelectedToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles CopySelectedToolStripMenuItem.Click
        Dim sb As New StringBuilder()
        For Each i As String In ImageListBox.SelectedItems
            sb.AppendLine(i)
        Next
        If sb.Length > 0 Then
            Clipboard.SetText(sb.ToString)
        End If
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles CopyAllToolStripMenuItem.Click
        Dim sb As New StringBuilder()

        For Each i As String In ImageListBox.Items
            sb.AppendLine(i)
        Next



        Clipboard.SetText(sb.ToString)
    End Sub

    Private Sub tsmiCopyImage_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCopyImage.Click
        Cursor.Current = Cursors.WaitCursor
        Dim fileToCopy As String = _selectedFileName

        ' Is this an archived image?
        If btnViewArchive.BackColor = _archiveButtonSelectedBackColor Then
            Dim frameList As New List(Of Int16)
            frameList.Add(_imageFrame)
            Dim myGuid As String = Guid.NewGuid.ToString()
            Dim prefix As String
            If _selectedFileName.Split("-").Length > 0 Then
                prefix = _selectedFileName.Split("-")(0)
            Else
                prefix = "VAL"
            End If
            Dim newFileName As String = String.Format("{0}-{1}.tif", prefix, myGuid)
            Dim destination As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\" & Path.GetFileName(newFileName)
            If TiffEncoderDecoder.CreateTiffFromFileFrames(frameList, _selectedFileName, destination) Then
                fileToCopy = destination
            Else
                MessageBox.Show("Error creating document to copy.", "Copy Error")
            End If

        End If

        Clipboard.Clear()
        Dim sc As New System.Collections.Specialized.StringCollection()
        sc.Add(fileToCopy)
        Clipboard.SetFileDropList(sc)

        Cursor.Current = Cursors.Default


        'Dim p As Paths = _paths(ImageListBox.SelectedIndex)

        ' Dim img As Image
        ' PictureBox1.Image.Save()
        'Using strm1 As New MemoryStream()
        '    ' Put the frame in the stream
        '    orderedTiff.Save(strm1)
        '    Using img1 As New Bitmap(strm1)
        '        ' Create the new image with the calculated size
        '        '_newImage = New Bitmap(_newWidth, _newHeight)
        '        _newImage = New Bitmap(_image.Width, _image.Height)
        '        Dim newGraphic As Drawing.Graphics = System.Drawing.Graphics.FromImage(_newImage)
        '        'newGraphic.DrawImage(img1, 0, 0, _newWidth, _newHeight)
        '        newGraphic.DrawImage(img1, 0, 0, _image.Width, _image.Height)
        '        With newGraphic
        '            .CompositingMode = Drawing2D.CompositingMode.SourceCopy
        '            .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        '            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        '        End With
        '    End Using
    End Sub

    Private Sub tsmiCopyAllImages_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCopyAllImages.Click
        Cursor.Current = Cursors.WaitCursor
        Clipboard.Clear()
        Dim sc As New System.Collections.Specialized.StringCollection()
        If btnViewArchive.BackColor = _archiveButtonSelectedBackColor Then
            For Each s As String In TiffEncoderDecoder.SplitTiff(_selectedFileName)
                sc.Add(s)
            Next
        Else
            For Each p As Paths In _paths
                sc.Add(p.PathAndFilename)
            Next
        End If

        Clipboard.SetFileDropList(sc)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If Timer1.Tag = "ShowImage" Then
            SetImageTimer(False, sender)
            ReleaseImage()
            ManagePageButtons()
        Else
            ' Give the illusion that we know how much time it will take. Or show we are still alive.
            With ProgressBar1
                Select Case .Value
                    Case Is >= 100
                        .Value -= 10
                    Case Is >= 90
                        .Value += 2
                    Case Is < 50
                        .Value += 10
                    Case Else
                        .Value += 5
                End Select

            End With
        End If


    End Sub

    Private Sub btnViewArchive_Click(sender As System.Object, e As System.EventArgs) Handles btnViewArchive.Click
        Me.ImageListBox.ClearSelected()
        btnViewArchive.BackColor = _archiveButtonSelectedBackColor
        _selectedFileName = Path.Combine(SirmPaths.Instance.ArchiveFolder, _fileInfo(0).RenamedFile.ToString())
        If Not File.Exists(_selectedFileName) Then
            _selectedFileName = Path.Combine(SirmPaths.Instance.ExtendedArchiveFolder, _fileInfo(0).RenamedFile.ToString())
        End If
        If File.Exists(_selectedFileName) Then
            ShowImage(sender)
        Else
            MessageBox.Show("Cant find archived file.", "File Not Found")
        End If
    End Sub

    Private Sub ShowAnalysis()
        Dim frmAnalysis As New frmProcessAnalysis(Me)
        frmAnalysis.Show()
    End Sub

    Private Sub tsmiAnalysis_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAnalysis.Click
        ShowAnalysis()
    End Sub

    Private Sub txtGoToPage_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGoToPage.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And IsNumeric(txtGoToPage.Text) Then
            Dim page As Int32 = CInt(txtGoToPage.Text)
            If page > _imageFrameCount Then
                _imageFrame = _imageFrameCount
            Else
                _imageFrame = page
            End If
            ShowImage(Nothing)
        End If
    End Sub

    Private Sub txtGoToPage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGoToPage.TextChanged

    End Sub



    Private Sub ShowErrors()

    End Sub

    Private Sub ErrorReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ErrorReportToolStripMenuItem.Click
        Dim AuditForm As New frmAudit(Me)
        AuditForm.Show()

    End Sub

    Private Sub btnReleaseImage_Click(sender As System.Object, e As System.EventArgs) Handles btnReleaseImage.Click
        ReleaseImage()
        SetImageTimer(False, sender)
        ManagePageButtons()

    End Sub

    Private Sub frmGetFileDocInfo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If _autorun Then
            Me.Close()
        End If
    End Sub

    Private Sub txtFileName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFileName.TextChanged

    End Sub
End Class

Class Paths
    Private _pathAndFilename As String = String.Empty
    Private _filename As String = String.Empty
    Private _path As String = String.Empty
    Public Property DeletedOrigin() As String

    Public Property Index As Integer
    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _filename
        End Get
        Set(value As String)
            _filename = value
        End Set
    End Property
    Public Property PathAndFilename() As String
        Get
            Return _pathAndFilename
        End Get
        Set(value As String)
            _pathAndFilename = value
            _path = System.IO.Path.GetDirectoryName(value) & "\"
            _filename = System.IO.Path.GetFileName(value)
        End Set
    End Property
End Class

