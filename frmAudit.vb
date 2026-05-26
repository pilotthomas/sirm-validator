Imports System.IO
Public Class frmAudit
    Private _mainForm As frmGetFileDocInfo
    Private _gridID As Integer
    Private _filePath As String
    Private _selectedFileName As String
    Private WithEvents _validatorServiceData As ValidatorData = ValidatorData.GetServiceData
    Private _gridFilter As String = String.Empty
    Private Sub btnFindInArchive_Click(sender As System.Object, e As System.EventArgs) Handles btnFindInArchive.Click
        txtMessage.Clear()
        If (File.Exists(_filePath)) Then
            txtMessage.Text = "File Exists: " & Path.GetFileName(_filePath)
        Else
            txtMessage.Text = "Can't find the File: " & Path.GetFileName(_filePath)
        End If
    End Sub

    Private Sub btnResubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnResubmit.Click
        Try
            Dim movePath As String = Path.Combine(SirmPaths.Instance.RecognizeFolder, _selectedFileName)
            File.Move(_filePath, movePath)
            If (File.Exists(movePath)) Then
                txtMessage.Text = "Success! Moved file back to be recognized"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ManualValidateButton_Click(sender As System.Object, e As System.EventArgs) Handles ManualValidateButton.Click
        Using client As New Maxum.EDM.Utilities.DoclinkMonitorService.DoclinkMonitorServiceClient
            client.SetImageIoFlags(_gridID, True, True, True)
            txtMessage.Text = _gridID.ToString & " Validation update Completed."
        End Using
    End Sub

    Public Sub GetAudit()
        Cursor = Cursors.WaitCursor()
        Try
            'Clear out the grid
            CalculateImageIoMessagesDataTableBindingSource.DataSource = Nothing
            grdAudit.Refresh()
            Me.txtMessage.Text = "Collecting Data............"
            ' The result will come back in the AuditDataComleted event of the object
            _validatorServiceData.GetAuditDataAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub grdAudit_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAudit.RowEnter
        Try

            _gridID = Int32.Parse(grdAudit.Rows(e.RowIndex).Cells("ID").FormattedValue.ToString())
            txtMessage.Clear()
            txtMessage.Text = "ID selected: " + _gridID.ToString()
            _selectedFileName = Me.grdAudit.Rows(e.RowIndex).Cells("Filename").Value.ToString()
            _filePath = System.IO.Path.Combine(SirmPaths.Instance.ArchiveFolder, _selectedFileName)
            If chkShowImage.Checked Then
                _mainForm.ShowImage(_filePath, sender, _selectedFileName)
            Else
                _mainForm.ShowImage(String.Empty, sender, _selectedFileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        GetAudit()

    End Sub

    Private Sub AppendFilter(ByVal textToAppend As String)
        If _gridFilter.Length > 0 Then
            _gridFilter = String.Format("{0} AND {1}", _gridFilter, textToAppend)
        Else
            _gridFilter = textToAppend
        End If
    End Sub

    Private Sub chkFileNotProcessed_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkFilterVerified.CheckedChanged, chkFileNotProcessed.CheckedChanged, chkImageNotProcessed.CheckedChanged
        Const fileProcessedFilter = "(FileProcessed = False)"
        Const verifiedFilter = "(EdmVerified = False OR EdmVerified1 = False)"
        Const imageProcessedFilter = "(ImagesProcessed = False)"

        _gridFilter = String.Empty

        If chkFileNotProcessed.Checked Then Me.AppendFilter(fileProcessedFilter)
        If chkFilterVerified.Checked Then Me.AppendFilter(verifiedFilter)
        If chkImageNotProcessed.Checked Then Me.AppendFilter(imageProcessedFilter)


        CalculateImageIoMessagesDataTableBindingSource.Filter = _gridFilter
    End Sub

    Public Sub New(parent As Form)
        If TypeOf (parent) Is frmGetFileDocInfo Then
            _mainForm = parent
        End If
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub _validatorServiceData_AuditDataComplete(data As EDM.Utilities.DoclinkMonitorService.AuditDataSet.CalculateImageIoMessagesDataTable) Handles _validatorServiceData.AuditDataComplete

        CalculateImageIoMessagesDataTableBindingSource.DataSource = data
        If data.Count = 0 Then
            txtMessage.Text = "Well I'm finished..." & vbCrLf & "But there's nothing to show!"
        End If
    End Sub

    Private Sub chkOverdue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverdue.CheckedChanged
        If sender.checked Then
            chkFileNotProcessed.Checked = False
            chkFilterVerified.Checked = False
            chkImageNotProcessed.Checked = False
            _gridFilter = "ReceivedDateTime < '" & Now.Subtract(New TimeSpan(0, 15, 0)) & "'"
        Else
            _gridFilter = String.Empty
        End If
        CalculateImageIoMessagesDataTableBindingSource.Filter = _gridFilter
    End Sub
End Class