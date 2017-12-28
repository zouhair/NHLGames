Imports System.IO
Imports System.Net
Imports NHLGames.My.Resources

Namespace Utilities
    Public Class Common

        Public Const UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36"
        Private Const Timeout = 10000

        Public Shared Function GetRandomString(ByVal intLength As Integer)
            Const s = "abcdefghijklmnopqrstuvwxyz0123456789"
            Dim r As New Random
            Dim sb As New Text.StringBuilder

            For i = 1 To intLength
                Dim idx As Integer = r.Next(0, 35)
                sb.Append(s.Substring(idx, 1))
            Next

            Return sb.ToString()
        End Function
        
        Public Shared Function SetHttpWebRequest(address As String) As HttpWebRequest
            Dim defaultHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(New Uri(address)), HttpWebRequest)
            defaultHttpWebRequest.UserAgent = UserAgent
            defaultHttpWebRequest.Method = WebRequestMethods.Http.Get
            defaultHttpWebRequest.Proxy = Nothing
            defaultHttpWebRequest.ContentType = "text/plain"
            defaultHttpWebRequest.CookieContainer = New CookieContainer()
            defaultHttpWebRequest.CookieContainer.Add(New Cookie("mediaAuth", GetRandomString(240), String.Empty, "nhl.com"))
            defaultHttpWebRequest.Timeout = Timeout

            Return defaultHttpWebRequest
        End Function

        Public Shared Function SendWebRequest(ByVal address As String, Optional httpWebRequest As HttpWebRequest = Nothing) As Boolean
            If address Is Nothing AndAlso httpWebRequest Is Nothing Then Return False

            Dim myHttpWebRequest As HttpWebRequest
            Dim result As Boolean = False

            If httpWebRequest Is Nothing Then
                myHttpWebRequest = SetHttpWebRequest(address)
            Else 
                myHttpWebRequest = httpWebRequest
            End If

            Try
                Using myHttpWebResponse As HttpWebResponse = myHttpWebRequest.GetResponse()
                    result = (myHttpWebResponse.StatusCode = HttpStatusCode.OK)
                End Using
            Catch ex As Exception
            End Try

            Return result
        End Function

        Public Shared Async Function SendWebRequestAsync(ByVal address As String, Optional httpWebRequest As HttpWebRequest = Nothing) As Task(Of Boolean)
            If address Is Nothing AndAlso httpWebRequest Is Nothing Then Return False

            Dim myHttpWebRequest As HttpWebRequest
            Dim result As Boolean = False

            If httpWebRequest Is Nothing Then
                myHttpWebRequest = SetHttpWebRequest(address)
            Else 
                myHttpWebRequest = httpWebRequest
            End If

            Try
                Using myHttpWebResponse As HttpWebResponse = Await myHttpWebRequest.GetResponseAsync()
                    result = (myHttpWebResponse.StatusCode = HttpStatusCode.OK)
                End Using
            Catch
            End Try

            Return result
        End Function

        Public Shared Async Function SendWebRequestAndGetContentAsync(ByVal address As String, Optional httpWebRequest As HttpWebRequest = Nothing) As Task(Of String)
            Dim content = New MemoryStream()
            Dim myHttpWebRequest As HttpWebRequest

            If httpWebRequest Is Nothing Then
                myHttpWebRequest = SetHttpWebRequest(address)
            Else 
                myHttpWebRequest = httpWebRequest
            End If

            Try
                Using myHttpWebResponse As HttpWebResponse = Await myHttpWebRequest.GetResponseAsync()
                    If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                        Using reader As Stream = myHttpWebResponse.GetResponseStream()
                            reader.CopyTo(content)
                        End Using
                    End If
                End Using
            Catch
                content.Dispose()
                Return String.Empty
            End Try

            Dim result = Text.Encoding.UTF8.GetString(content.ToArray())
            content.Dispose()

            Return result
        End Function

        Public Shared Sub GetLanguage()
            Dim lang = ApplicationSettings.Read(Of String)(SettingsEnum.SelectedLanguage, String.Empty)

            If String.IsNullOrEmpty(lang) OrElse lang = NHLGamesMetro.RmText.GetString("lblEnglish") Then
                NHLGamesMetro.RmText = English.ResourceManager
            ElseIf lang = NHLGamesMetro.RmText.GetString("lblFrench") Then
                NHLGamesMetro.RmText = French.ResourceManager
            End If
        End Sub

        Public Async Shared Function CheckAppCanRun() As Task(Of Boolean)
            If Not File.Exists("NHLGames.exe.Config") Then
                FatalError(NHLGamesMetro.RmText.GetString("noConfigFile"))
                Return False
            Else If Not (Await InitializeForm.VersionCheck()) OrElse Not (Await SendWebRequestAsync("https://www.google.com")) Then
                FatalError(NHLGamesMetro.RmText.GetString("noWebAccess"))
                Return False
            End If

            Return True
        End Function

        Private Shared Sub FatalError(message As String)
            If InvokeElement.MsgBoxRed(message, NHLGamesMetro.RmText.GetString("msgFailure"), MessageBoxButtons.OK) = DialogResult.OK Then
                NHLGamesMetro.FormInstance.Close
            End If
        End Sub

    End Class
End Namespace
