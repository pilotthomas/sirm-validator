Imports SPI.Graphics.TiffManager
Imports System.IO
Imports System.Security.Permissions
Imports System.Drawing
Imports SPI.EDM.SIRM.Common

Public Class TiffSplitter
    Sub New(ByVal tempFilePath As String)
        _tempFilePath = tempFilePath
   End Sub
   Private _tempFilePath As String
    Public Property TempFilepath() As String
        Get
            Return _tempFilePath
        End Get
        Set(ByVal value As String)
            _tempFilePath = value
        End Set
    End Property

    Public Function GetFrameCount(ByVal filespec As String) As Integer

      Dim frameCount As Integer = 0
      Try
         If File.Exists(filespec) Then
            Using tm As New TiffManager
               tm.TempWorkingDir = TempFilepath
               tm.ImageFileName = filespec
               frameCount = tm.PageNumber
            End Using
         End If
      Catch ex As OutOfMemoryException
         frameCount = -1
      End Try
      Return frameCount

   End Function
    Private Function ValidatePath(ByVal pathToValidate As String) As Integer
        Dim err As Integer = 0
      Try
         If Right(pathToValidate, 1) <> Path.DirectorySeparatorChar Then
            pathToValidate += Path.DirectorySeparatorChar
         End If
         If Not Directory.Exists(pathToValidate) Then
            Directory.CreateDirectory(pathToValidate)
         End If
      Catch ioex As IOException
         err = 1
      End Try
    End Function
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    Public Function SplitTiff(ByVal fullPath As String, _
                            ByVal ResultOutputPath As String, _
                            ByVal maxPagesAllowed As Integer, _
                            ByVal appendedOrderedNumberPrefix As String, _
                            ByVal archivePath As String) As Boolean

      Dim ret As Boolean = False
      Dim filespec As String = String.Empty
      Dim filename As String = Path.GetFileName(fullPath)

      If File.Exists(fullPath) Then
         Dim pathsErrors As Integer = 0
         pathsErrors += ValidatePath(archivePath)
         pathsErrors += ValidatePath(TempFilepath)
         If pathsErrors = 0 Then

            ' If there is an archive path then save a copy to it.
            ' If no archive path then we Create a working directory and delete the file when we are finished.
            ' Otherwise copy the file to the archive path and use it as the working file.
            If archivePath = String.Empty Then
               Dim workingDirectory As String = My.Application.Info.DirectoryPath & "\HoldForProcess\"
               If Not Directory.Exists(workingDirectory) Then
                  Directory.CreateDirectory(workingDirectory)
               End If
               filespec = workingDirectory & filename
            Else
               filespec = archivePath & filename
            End If

            File.Copy(fullPath, filespec, True)
            If File.Exists(filespec) Then
               File.Delete(fullPath)
            End If

            ' Split the file to the destination.
            Dim pageCount As Integer = 0
            Using tm As New TiffManager
               With tm
                  .TempWorkingDir = TempFilepath
                  .ImageFileName = filespec
                  pageCount = .PageNumber
                  .BreakUpFile(maxPagesAllowed, _
                              Imaging.EncoderValue.CompressionCCITT4, _
                             ResultOutputPath & filename, appendedOrderedNumberPrefix)
               End With
               ret = True
            End Using

            ' If an archive path was not defined then delete the original from the temp processing directory.
            ' Else remove the Hidden attribute that was set by the process that sent the message to the tiffsplit MSMQ.
            If archivePath = String.Empty Then
               File.Delete(filespec)
            Else
               File.SetAttributes(filespec, FileAttributes.Normal)
            End If

            ' Assuming that the file processed correctly we will write the messages to the Queue for tracking.
            ' If the file did not process correctly then we have a record of what should have happened.
            If pageCount > maxPagesAllowed Then
               Dim remainder As Integer = pageCount Mod maxPagesAllowed
               Dim batch As Integer = (pageCount \ maxPagesAllowed)
               Dim loopCounter As Integer = 0

               Dim newFilenamePrefix As String = Path.GetFileNameWithoutExtension(filename) & appendedOrderedNumberPrefix
               For i As Integer = maxPagesAllowed To pageCount Step maxPagesAllowed
                  LogSirmImageToQueue(newFilenamePrefix & loopCounter.ToString & ".tif", maxPagesAllowed)
                  loopCounter += 1
               Next
               ' Pick up the strays
               If remainder > 0 Then
                  LogSirmImageToQueue(newFilenamePrefix & loopCounter.ToString & ".tif", remainder)
               End If
            End If

         Else
            Throw New ApplicationException("Archive or Temp Path could not be created")
         End If

      End If
      Return ret
   End Function

   Public Shared Sub LogSirmImageToQueue(ByVal filename As String, _
                                          ByVal imageCount As Integer)

      Dim msg As New SirmImageMessage
      With msg
         .Name = filename
         .GUID = String.Empty
         .FrameCount = CStr(imageCount)
         .Type = "Service"
         .Process = "TiffSplit"
         .RecievedFrom = My.Application.Info.AssemblyName
      End With

      QueueTasks.SendMessage(Of SirmImageMessage)(msg)

   End Sub

End Class
