Imports System.IO
Imports System.Xml.Serialization


Public Class frmProcessAnalysis
    Private _idxGroupBy As Integer = 2
    Private _mainForm As frmGetFileDocInfo = Nothing
    Private _gridIsLoaded As Boolean = False
    Private _filterInProgress As Boolean

    Private Sub btnCallProc_Click(sender As System.Object, e As System.EventArgs) Handles btnCallProc.Click
        Try
            _gridIsLoaded = False
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            lblRefreshed.Text = String.Empty
            ' Clear out the data
            CommonDataSet.ListImageIO_IndexedIntoDoclink.Clear()
            grdAnalysis.Refresh()

            Dim start As String = String.Format("{0}/{1}/{2}", dtpStart.Value.Month, dtpStart.Value.Day, dtpStart.Value.Year)
            Dim endDate As String = String.Format("{0}/{1}/{2}", dtpEnd.Value.Month, dtpEnd.Value.Day, dtpEnd.Value.Year)
            ListImageIO_IndexedIntoDoclinkTableAdapter.Fill(CommonDataSet.ListImageIO_IndexedIntoDoclink, start, endDate)

            lblRefreshed.Text = "Last Refreshed on: " & Now

            ' Group by to remove duplicate entries for the same DocumentID. Get the last entry.

            For Each v As DataRowView In Me.ListImageIOIndexedIntoDoclinkBindingSource.List
                Dim r As CommonDataSet.ListImageIO_IndexedIntoDoclinkRow = DirectCast(v.Row, CommonDataSet.ListImageIO_IndexedIntoDoclinkRow)
                'If Not r.IsNewDocumentIDNull Then
                '    r.BeginEdit()
                '    r.DocumentType = "3- Repaginated"
                '    r.EndEdit()

                If r.DocumentType = String.Empty Then
                    If r.Destination.Contains("\") Then
                        If Directory.Exists(r.Destination) Then
                            If File.Exists(Path.Combine(r.Destination, r.BatchFolder, r.FileNameOrDocumentID)) Then
                                r.BeginEdit()
                                r.DocumentType = "2- Ready To Index"
                                r.EndEdit()
                            Else
                                r.BeginEdit()
                                r.DocumentType = "1- Paginated or Deleted"
                                r.EndEdit()
                            End If
                        End If
                    End If
                End If
            Next

            CommonDataSet.ListImageIO_IndexedIntoDoclink.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            grdAnalysis.Refresh()
            Cursor.Current = Cursors.Default
            _gridIsLoaded = True
        End Try

    End Sub

    Private Sub frmProcessAnalysis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpEnd.Value = DateAdd("d", 1, Now)
        SetIdxGroupBy(_idxGroupBy, sender, e)
    End Sub

    Private Sub SetIdxGroupBy(idx As Integer, sender As Object, e As EventArgs)
        Select Case idx
            Case 1
                DefaultToolStripMenuItem_Click(sender, e)
            Case 2
                IndexedByToolStripMenuItem_Click(sender, e)
        End Select
    End Sub

    Private Sub grdAnalysis_GroupText(sender As Object, e As C1.Win.C1TrueDBGrid.GroupTextEventArgs) Handles grdAnalysis.GroupText
        Try
            Dim grouptext As String = e.GroupText
            If grouptext = String.Empty Then
                grouptext = "Unknown"
            End If

            e.Text = grouptext & "  -  Count: " & CStr(e.EndRowIndex - e.StartRowIndex + 1)
        Catch ex As Exception
            ' don't care
        End Try


    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DefaultToolStripMenuItem.Click
        _idxGroupBy = 1
        grdAnalysis.GroupedColumns.Clear()
        grdAnalysis.GroupedColumns.Add(grdAnalysis.Columns("Destination"))
        grdAnalysis.GroupedColumns.Add(grdAnalysis.Columns("DocumentType"))
    End Sub

    Private Sub IndexedByToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IndexedByToolStripMenuItem.Click
        _idxGroupBy = 2
        grdAnalysis.GroupedColumns.Clear()
        grdAnalysis.GroupedColumns.Add(grdAnalysis.Columns("IndexedBy"))
        grdAnalysis.GroupedColumns.Add(grdAnalysis.Columns("Destination"))
        grdAnalysis.GroupedColumns.Add(grdAnalysis.Columns("DocumentType"))
    End Sub

    Private Sub OnRowChange(sender As Object)
        Dim selTxt As String = grdAnalysis.Columns("FilenameOrDocumentID").Text
        If Not Me._filterInProgress Then
            If _gridIsLoaded AndAlso chkViewImage.Checked Then
                grdAnalysis.Refresh()
                Application.DoEvents()
                Dim path As String = String.Empty
                If ListImageIOIndexedIntoDoclinkBindingSource.Current IsNot Nothing Then
                    Dim row As CommonDataSet.ListImageIO_IndexedIntoDoclinkRow = DirectCast(ListImageIOIndexedIntoDoclinkBindingSource.Current.row, CommonDataSet.ListImageIO_IndexedIntoDoclinkRow)

                    If row.ImagePath = String.Empty Then
                        path = System.IO.Path.Combine(row.Destination, row.BatchFolder, row.FileNameOrDocumentID)
                    Else
                        path = row.ImagePath
                    End If
                    If Not _filterInProgress Then
                        _mainForm.ShowImage(path, sender, row.FileNameOrDocumentID)
                    End If
                End If
                grdAnalysis.Focus()

            End If
        End If
    End Sub

    Private Sub grdAnalysis_Filter(sender As Object, e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdAnalysis.Filter


        _filterInProgress = True
        Dim pos As Integer = 0
        Dim newCond As String = e.Condition
        If e.Condition.Length > 0 Then
            CollapseAll()
            ' To colapse all just set the filter to empty
            'ListImageIOIndexedIntoDoclinkBindingSource.Filter = String.Empty
            Do Until pos < 0
                pos = e.Condition.IndexOf("'", pos + 1)
                If pos > 0 Then
                    If newCond.Substring(pos, 1) <> "*" Then
                        newCond = newCond.Insert(pos + 1, "*")
                    End If
                End If
            Loop
        End If

        ListImageIOIndexedIntoDoclinkBindingSource.Filter = newCond

        _filterInProgress = False

    End Sub

    Private Sub CollapseAll()
        Me.grdAnalysis.Row = 0
        For i As Integer = Me.grdAnalysis.Splits(0).Rows.Count - 1 To 0 Step -1
            Dim rtype As C1.Win.C1TrueDBGrid.RowTypeEnum = Me.grdAnalysis.Splits(0).Rows(i).RowType
            If rtype = C1.Win.C1TrueDBGrid.RowTypeEnum.ExpandedGroupRow Then
                ' Dim gr As C1.Win.C1TrueDBGrid.GroupRow = DirectCast(Me.grdAnalysis.Splits(0).Rows(i), C1.Win.C1TrueDBGrid.GroupRow)
                grdAnalysis.CollapseGroupRow(i)
            End If
        Next
    End Sub

    Private Sub grdAnalysis_RowColChange(sender As Object, e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdAnalysis.RowColChange
        OnRowChange(sender)
    End Sub

    Public Sub New(parent As Form)
        If TypeOf (parent) Is frmGetFileDocInfo Then
            _mainForm = parent
        End If
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

End Class