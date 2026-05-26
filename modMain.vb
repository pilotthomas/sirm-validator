Imports Maxum.EDM.Utilities.DoclinkMonitorService
Imports Maxum.EDM.Utilities

Module modMain
    <STAThread()>
    Public Sub Main()
        'Moved this to frmGetFileDocInfo constructor to retain the Windows AD plumbing.
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Try


            Dim args() As String = Environment.GetCommandLineArgs
            If args.Length > 1 AndAlso args(1) = "Auto" Then
                Debug.WriteLine("Arg: " & args(1).ToString)
                AutoResolve()
            Else
                Application.Run(New frmGetFileDocInfo())
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private _fileInfo As New CommonDataSet.GetDocumentInfoFromFileDataTable
    ''' <summary>
    ''' Automated process of the manual validation.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub AutoResolve()
        Try
            Dim prevStruct As New previousStruct()
            Dim result As AuditDataSet.CalculateImageIoMessagesDataTable = ValidatorData.GetServiceData().GetAuditData()
            Dim ta As New Maxum.CommonDataSetTableAdapters.GetDocumentInfoFromFileTableAdapter

            Dim query = From x In result.AsEnumerable()
                        Where x.ReceivedDateTime < Now.Subtract(New TimeSpan(0, 15, 0))
                        Order By x.Filename

            For Each row As AuditDataSet.CalculateImageIoMessagesRow In query
                If row.PageCount = 0 Then
                    ManualValidate(row.ID)
                Else
                    If prevStruct.Filename <> row.Filename OrElse prevStruct.Type <> row.Type Then
                        If prevStruct.Filename <> row.Filename Then
                            ta.Fill(_fileInfo, row.Filename)
                            Debug.WriteLine("Fill " & row.Filename)
                        End If
                        If _fileInfo.Rows.Count > 0 Then
                            If CType(_fileInfo.Rows(0), CommonDataSet.GetDocumentInfoFromFileRow).FilePageCount >= row.PageCount Then
                                Debug.WriteLine("Validate " & row.Filename & "  " & row.Type)
                                ManualValidate(row.ID)
                            End If
                        End If
                    End If

                    With prevStruct
                        .Filename = row.Filename
                        .Type = row.Type
                        .PageCount = row.PageCount
                    End With
                End If
            Next
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub
    Private Sub ManualValidate(ID As Integer)
        Using client As New DoclinkMonitorServiceClient
            client.SetImageIoFlags(ID, True, True, True)
        End Using

    End Sub
    Private Structure previousStruct
        Public Filename As String
        Public Type As String
        Public PageCount As Integer
        Public Guid As String
    End Structure
End Module
