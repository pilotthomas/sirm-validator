Public Class SirmPaths
    Private Shared _instance As SirmPaths = Nothing
    Private _new As String = String.Empty
    Private _completed As String = String.Empty
    Private _archive As String = String.Empty
    Private _extendedArchive As String = String.Empty
    Private _pathsDataTable As CommonDataSet.ListSirmPathsDataTable = Nothing
    Public ReadOnly Property RecognizeFolder
        Get
            Return _new
        End Get
    End Property
    Public ReadOnly Property CompletedFolder
        Get
            Return _completed
        End Get
    End Property
    Public ReadOnly Property ArchiveFolder
        Get
            Return _archive
        End Get
    End Property
    Public ReadOnly Property ExtendedArchiveFolder
        Get
            Return _extendedArchive
        End Get
    End Property

    Private Sub New()
        If _pathsDataTable Is Nothing Then
            _pathsDataTable = New CommonDataSet.ListSirmPathsDataTable
            Dim ta As New CommonDataSetTableAdapters.ListSirmPathsTableAdapter
            'ta.ClearBeforeFill = False
            ta.Fill(_pathsDataTable)
            For Each r As CommonDataSet.ListSirmPathsRow In _pathsDataTable
                Select Case r.Name
                    Case "SirmArchive"
                        _archive = r.Value
                    Case "SirmExtendedArchive"
                        _extendedArchive = r.Value
                    Case "SirmNew"
                        _new = r.Value
                    Case "SirmCompleted"
                        _completed = r.Value
                End Select
            Next

        End If
    End Sub
    Public Shared ReadOnly Property Instance() As SirmPaths
        Get
            If _instance Is Nothing Then
                _instance = New SirmPaths
            End If
            Return _instance
        End Get
    End Property
End Class
