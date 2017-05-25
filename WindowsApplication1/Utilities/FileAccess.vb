Imports System.IO

Namespace Utilities

    Public Class FileAccess

        ''' <summary>
        ''' DirectoryInfo.GetFiles can cause AuthorizationException Errors, hence this function
        ''' </summary>
        ''' <param name="root">Root folder to search (eg. "C:\Program Files")</param>
        ''' <param name="searchPattern">Pattern to search for (eg. "vlc.exe" or "*.exe")</param>
        ''' <returns>List of paths</returns>
        Public Shared Function GetFiles(root As String, searchPattern As String) As List(Of String)
            Dim result As New List(Of String)()

            Dim pending As New Stack(Of String)()
            pending.Push(root)
            While pending.Count <> 0
                Dim path = pending.Pop()
                Dim [next] As String() = Nothing
                Try
                    [next] = Directory.GetFiles(path, searchPattern)
                Catch
                End Try
                If [next] IsNot Nothing AndAlso [next].Length <> 0 Then
                    result.AddRange([next])
                End If
                Try
                    [next] = Directory.GetDirectories(path)
                    For Each subdir As String In [next]
                        pending.Push(subdir)
                    Next
                Catch
                End Try
            End While

            Return result
        End Function


        Public Shared Function IsFileReadonly(path As String) As Boolean

            Dim attributes As FileAttributes = File.GetAttributes(path)
            Return (attributes And FileAttributes.[ReadOnly]) = FileAttributes.[ReadOnly]

        End Function


        Public Shared Sub RemoveReadOnly(path As String)

            Dim attributes As FileAttributes = File.GetAttributes(path)

            If (attributes And FileAttributes.[ReadOnly]) = FileAttributes.[ReadOnly] Then
                ' Make the file RW
                attributes = RemoveAttribute(attributes, FileAttributes.[ReadOnly])
                File.SetAttributes(path, attributes)
                Console.WriteLine(NHLGamesMetro.RmText.GetString("msgRemoveReadOnly"), path)
            End If

        End Sub

        Public Shared Sub AddReadonly(path As String)
            File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.ReadOnly)
            Console.WriteLine(NHLGamesMetro.RmText.GetString("msgAddReadOnly"), path)
        End Sub

        Public Shared Function RemoveAttribute(attributes As FileAttributes, attributesToRemove As FileAttributes) As FileAttributes
            Return attributes And Not attributesToRemove
        End Function


        Public Shared Function HasAccess(ByVal ltFullPath As String)
            Try
                Dim filePath As String = Path.Combine(ltFullPath, "test.txt")
                File.WriteAllText(filePath, NHLGamesMetro.RmText.GetString("msgTextTxtContent"))
                Using inputstreamreader As New StreamReader(filePath)
                    inputstreamreader.Close()
                End Using
                Using inputStream As FileStream = File.Open(filePath, FileMode.Open, IO.FileAccess.ReadWrite, FileShare.None)
                    inputStream.Close()
                    Return True
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class
End Namespace
