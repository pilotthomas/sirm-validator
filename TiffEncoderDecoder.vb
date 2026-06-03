Imports System
Imports System.IO
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Security
Imports System.Runtime.InteropServices
Public NotInheritable Class TiffEncoderDecoder
    Public Shared Sub ImageToCcitt4(ByVal sourcePathAndFilename As String, ByVal destinationPathAndFilename As String)
        Using stream As New FileStream(destinationPathAndFilename, FileMode.Create)
            Dim encoder As New TiffBitmapEncoder()

            Dim imageStreamSource As New FileStream(sourcePathAndFilename, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim decoder As New TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)

            encoder.Compression = TiffCompressOption.Ccitt4
            For i As Integer = 0 To decoder.Frames.Count - 1
                encoder.Frames.Add(decoder.Frames(i))
            Next
            encoder.Save(stream)
            stream.Close()
        End Using
    End Sub

    Public Shared Function CreateOrderdMultipageTiff(ByVal sources As List(Of String), ByVal destinationPathAndFilename As String) As Boolean
        Dim orderedTiff As New TiffBitmapEncoder()
        Try
            orderedTiff.Compression = TiffCompressOption.Ccitt4

            For Each imageFilePath As String In sources
                If File.Exists(imageFilePath) Then
                    For Each bm As BitmapFrame In GetBitmapFrames(imageFilePath)
                        orderedTiff.Frames.Add(bm)
                    Next
                End If
            Next

            If File.Exists(destinationPathAndFilename) Then
                File.Delete(destinationPathAndFilename)
            End If
            Using stream As New FileStream(destinationPathAndFilename, FileMode.Create)
                orderedTiff.Save(stream)
                stream.Close()
            End Using
        Catch ex As Exception

        End Try

    End Function

    Public Shared Function GetBitmapFrames(ByVal source As String) As BitmapFrame()
        Dim frames() As BitmapFrame = Nothing
        If File.Exists(source) Then
            Using streamsource As New FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read)
                'Dim myUri As New Uri(source, UriKind.Absolute)
                Dim tbm As New TiffBitmapDecoder(streamsource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad)
                frames = Array.CreateInstance(GetType(BitmapFrame), tbm.Frames.Count)
                tbm.Frames.CopyTo(frames, 0)
            End Using

        End If

        Return frames
    End Function

    Public Shared Function SplitTiff(ByVal source As String) As List(Of String)
        ' In Progress
        Dim paths As New List(Of String)
        Try


            If File.Exists(source) Then
                Dim myGuid As String = Guid.NewGuid.ToString()
                Dim idx As Int16 = 0
                For Each bm As BitmapFrame In GetBitmapFrames(source)
                    Dim orderedTiff As New TiffBitmapEncoder()
                    orderedTiff.Compression = TiffCompressOption.Ccitt4
                    orderedTiff.Frames.Add(bm)
                    idx += 1
                    Dim prefix As String
                    If source.Split("-").Length > 0 Then
                        prefix = source.Split("-")(0)
                    Else
                        prefix = "VAL"
                    End If
                    Dim newFileName As String = String.Format("{0}-{1}-{2}.tif", prefix, myGuid, idx)
                    Dim destination As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\" & Path.GetFileName(newFileName)

                    If File.Exists(destination) Then
                        File.Delete(destination)
                    End If
                    Using stream As New FileStream(destination, FileMode.Create)
                        orderedTiff.Save(stream)
                        stream.Close()
                    End Using
                    paths.Add(destination)

                Next
            End If



        Catch ex As Exception

        End Try
        Return paths
    End Function

    Public Shared Function CreateTiffFromFileFrames(pageNumbers As List(Of Int16), ByVal source As String, ByVal destinationPathAndFilename As String) As Boolean
        Dim orderedTiff As New TiffBitmapEncoder()
        Dim ret As Boolean = False
        Try
            orderedTiff.Compression = TiffCompressOption.Ccitt4

            If File.Exists(source) Then
                Dim bm As BitmapFrame() = GetBitmapFrames(source)
                For Each i As Int16 In pageNumbers
                    orderedTiff.Frames.Add(bm(i - 1))
                Next
            End If

            If File.Exists(destinationPathAndFilename) Then
                File.Delete(destinationPathAndFilename)
            End If
            Using stream As New FileStream(destinationPathAndFilename, FileMode.Create)
                orderedTiff.Save(stream)
                stream.Close()
            End Using
            ret = True
        Catch ex As Exception
            Throw ex
        End Try

        Return ret
    End Function
End Class
