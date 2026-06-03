Imports Maxum.EDM.Utilities.DoclinkMonitorService
Imports Maxum.EDM.Utilities
Public Class Automation
    Private Shared _fileInfo As New CommonDataSet.GetDocumentInfoFromFileDataTable
    Public Shared Sub AutoResolve()

        ValidatorData.GetServiceData()
        Dim prevStruct As New previousStruct()
        Dim result As AuditDataSet.CalculateImageIoMessagesDataTable = ValidatorData.GetServiceData().GetAuditData()
        result.DefaultView.RowFilter = "ReceivedDateTime < '" & Now.Subtract(New TimeSpan(0, 15, 0)) & "'"
        Dim ta As New Maxum.CommonDataSetTableAdapters.GetDocumentInfoFromFileTableAdapter
        For Each row As AuditDataSet.CalculateImageIoMessagesRow In result.Rows()
            If row.FrameCount = 0 Then
                ManualValidate(row.ID)
            Else
                If prevStruct.Filename <> row.Filename AndAlso prevStruct.Type <> row.Type Then

                    ta.Fill(_fileInfo, row.Filename)
                    If CType(_fileInfo.Rows(0), CommonDataSet.GetDocumentInfoFromFileRow).FilePageCount >= row.FrameCount Then
                        ManualValidate(row.ID)
                    End If
                End If

                With prevStruct
                    .Filename = row.Filename
                    .Type = row.Type
                    .PageCount = row.FrameCount
                End With
            End If
        Next
    End Sub
    Private Shared Sub ManualValidate(ID As Integer)
        Using client As New DoclinkMonitorServiceClient
            client.SetImageIoFlags(ID, True, True, True)
        End Using

    End Sub
    Private Structure previousStruct
        Public Filename As String
        Public Type As String
        Public PageCount As Integer
    End Structure
End Class
