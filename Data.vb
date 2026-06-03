Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.ServiceModel
Imports Maxum.EDM.Utilities.DoclinkMonitorService
Imports Maxum.EDM.Utilities
Imports System.Threading
<CallbackBehavior(AutomaticSessionShutdown:=False)>
Public NotInheritable Class ValidatorData

    'Public WithEvents AuditData As New AuditDataSet.CalculateImageIoMessagesDataTable
    ' Dim _proxy As DoclinkMonitorServiceClient
    Public Event AuditDataComplete(data As AuditDataSet.CalculateImageIoMessagesDataTable)
    Private Shared ReadOnly _instance As ValidatorData = New ValidatorData
    Private _uiContext As SynchronizationContext
    Private Sub New()
        _uiContext = SynchronizationContext.Current
    End Sub
    Public Shared Function GetServiceData() As ValidatorData
        Return _instance
    End Function
    Public Function GetAuditDataAsync() As Boolean
        Try
            Dim _proxy As New DoclinkMonitorServiceClient
            _proxy.BeginListDocumentExceptionsData(AddressOf OnCompletionGetAuditData, _proxy)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Sub OnCompletionGetAuditData(result As IAsyncResult)
        Dim ret As AuditDataSet.CalculateImageIoMessagesDataTable = Nothing
        Using _proxy As DoclinkMonitorServiceClient = CType(result.AsyncState, DoclinkMonitorServiceClient)
            ret = _proxy.EndListDocumentExceptionsData(result)
        End Using

        ' Need to call back to the UI thread to update.
        Dim cb As New SendOrPostCallback(AddressOf UpdateUI)
        _uiContext.Post(cb, ret)
        result.AsyncWaitHandle.Close()
    End Sub


    Private Sub UpdateUI(state As AuditDataSet.CalculateImageIoMessagesDataTable)
        RaiseEvent AuditDataComplete(state)
    End Sub

    Public Function GetAuditData() As AuditDataSet.CalculateImageIoMessagesDataTable
        Dim ret As AuditDataSet.CalculateImageIoMessagesDataTable = Nothing
        Using client As New DoclinkMonitorServiceClient
            ret = client.ListDocumentExceptionsData()
        End Using
        Return ret
    End Function

End Class


