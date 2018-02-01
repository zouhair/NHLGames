Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Web.UI.WebControls.Expressions
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects

    Public Class GameWatchArguments

        Public Property Quality As StreamQuality = StreamQuality.best
        Public Property Is60Fps As Boolean = True
        Public Property Cdn As CdnType = CdnType.Akc
        Public Property Stream As GameStream = Nothing
        Public Property GameTitle As String = String.Empty
        Public Property PlayerPath As String = String.Empty
        Public Property PlayerType As PlayerTypeEnum = PlayerTypeEnum.None
        Public Property StreamerPath As String = String.Empty
        Public Property UseCustomStreamerArgs As Boolean = False
        Public Property CustomStreamerArgs As String = String.Empty
        Public Property UseCustomPlayerArgs As Boolean = False
        Public Property CustomPlayerArgs As String = String.Empty
        Public Property UseOutputArgs As Boolean = False
        Public Property PlayerOutputPath As String = String.Empty
        Public Property StreamLiveRewind As Integer = 5
        Public Property GameIsOnAir As Boolean = False
        Public Property StreamLiveReplayCode As LiveReplayCode = LiveReplayCode.Live
        Public Property StreamerType As StreamerTypeEnum = StreamerTypeEnum.None

        Public Overrides Function ToString() As String
            Return OutputArgs(False)
        End Function

        Public Overloads Function ToString(ByVal safeOutput As Boolean)
            Return OutputArgs(safeOutput)
        End Function

        Private Function GetStreamQuality() As String
            Dim selectedQualities = ""
            Dim addQuality = Quality
            Dim maxQuality = CType([Enum].GetValues(GetType(StreamQuality)), Integer()).Max()
            While addQuality < maxQuality
                selectedQualities &= addQuality.ToString().Substring(1) & ","
                addQuality = addQuality + 1
            End While
            selectedQualities &= StreamQuality.worst.ToString()
            Return selectedQualities
        End Function

        Private Function OutputArgs(ByVal safeOutput As Boolean) As String

            If String.IsNullOrEmpty(PlayerPath) OrElse PlayerType.Equals(PlayerTypeEnum.None) Then Console.WriteLine(English.errorPlayerPathEmpty)
            
            Dim result = PlayerArgs() & ReplayArgs()
            If UseCustomStreamerArgs Then result &= CustomStreamerArgs
            If Not safeOutput Then result &= NhlCookieArgs()
            result &= UserAgentArgs()
            result &= If (safeOutput, StreamLinkCensoredArgs(), StreamLinkArgs())
            result &= If (Is60Fps, StreamBestQualityArgs(), StreamQualityArgs)
            If UseOutputArgs Then result &= OutputArgs()

            Return result
            
        End Function

        Private Function PlayerArgs() As String
            Dim literalPlayerArgs = If (UseCustomPlayerArgs, CustomPlayerArgs, String.Empty)
            Select Case PlayerType
                Case PlayerTypeEnum.Mpv
                    Return $"--player ""{PlayerPath} --force-window=immediate --title """"{GameTitle}"""" --user-agent=User-Agent=""""{Common.UserAgent}"""" {literalPlayerArgs} "" "
                Case PlayerTypeEnum.Vlc
                    Return $"--player ""{PlayerPath} --meta-title """"{GameTitle}"""" {literalPlayerArgs} "" "
                Case PlayerTypeEnum.Mpc
                    Return $"--player ""{PlayerPath} {literalPlayerArgs} "" "
            End Select
            Return String.Empty
        End Function

        Private Function ReplayArgs() As String
            If GameIsOnAir Then
                If PlayerType.Equals(PlayerTypeEnum.Vlc) Then
                    Return $"--ringbuffer-size=2500K --hls-segment-threads=2 "
                Else If Not StreamLiveReplayCode.Equals(LiveReplayCode.Live) Then
                    Return $"--ringbuffer-size=4M --hls-segment-threads=2 --hls-live-edge={ReplayMinutes()} "
                Else
                    Return $"--ringbuffer-size=2500K --hls-segment-threads=2 --player-passthrough=hls "
                End If
            Else 
                If PlayerType.Equals(PlayerTypeEnum.Vlc) Then
                    Return $"--ringbuffer-size=8M --hls-segment-threads=2 "
                Else
                    Return $"--ringbuffer-size=8M --hls-segment-threads=2 --player-passthrough=hls "
                End If
            End If
        End Function

        Private Function ReplayMinutes() As Integer
            Select Case StreamLiveReplayCode
                Case LiveReplayCode.Rewind
                    Return StreamLiveRewind * 12
                Case LiveReplayCode.Replay
                    Return 9999
            End Select
            Return 12
        End Function

        Private Function NhlCookieArgs As String
            Return $" --http-cookie=""mediaAuth={Common.GetRandomString(240)} """
        End Function
        Private Function UserAgentArgs As String
            Return $" --http-header=""User-Agent={Common.UserAgent}"" "
        End Function
        Private Function StreamLinkArgs As String
            Return $"""hlsvariant://{Stream.StreamUrl.Replace("CDN", cdn.ToString().ToLower())} "
        End Function
        Private Function StreamLinkCensoredArgs() As String
            Return $"""hlsvariant://{English.msgCensoredStream} "
        End Function
        Private Function StreamBestQualityArgs As String
            Return $"name_key=bitrate"" best --http-no-ssl-verify "
        End Function
        Private Function StreamQualityArgs As String
            Return $""" {GetStreamQuality} --http-no-ssl-verify "
        End Function

        Private Function OutputArgs As String
            Dim outputPath As String = PlayerOutputPath.
                    Replace("(DATE)", DateHelper.GetPacificTime(Stream.Game.GameDate).ToString("yyyy-MM-dd")).
                    Replace("(HOME)", Stream.Game.HomeAbbrev).
                    Replace("(AWAY)", Stream.Game.AwayAbbrev).
                    Replace("(TYPE)", Stream.Type.ToString()).
                    Replace("(NETWORK)", Stream.Network)
            Dim suffix As Integer = 1
            Dim originalName = Path.GetFileNameWithoutExtension(outputPath)
            Dim originalExt = Path.GetExtension(outputPath)
            While (My.Computer.FileSystem.FileExists(outputPath))
                outputPath = Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(outputPath), originalName & "_" & suffix), originalExt)
                suffix += 1
            End While

            Return $"-f -o ""{outputPath}"" "
        End Function

        'Public Function test() As String

            'Dim streamQuality = GetStreamQuality()

            'If UsePlayerArgs Then
            '    literalPlayerArgs = PlayerArgs
            'End If

            'DEBUG "-v -l debug -h "

            'Dim titleArg As String = literalPlayerArgs

            'If PlayerType = PlayerTypeEnum.Vlc Then
            '    titleArg = String.Format("--meta-title{0}{1}{2}{1}{0}", space, dblQuot2, GameTitle)
            'ElseIf PlayerType = PlayerTypeEnum.Mpv Then
            '    titleArg = String.Format("--force-window=immediate{0}--title{0}{1}{2}{1}{0}--user-agent=User-Agent={1}{3}{1}{0}", space, dblQuot2, GameTitle, Common.UserAgent)
            'End If

            'If String.IsNullOrEmpty(PlayerPath) = False Then
            '    returnValue &= String.Format("--player{0}{1}{2}{0}{3}{4}{0}{1}{0}", space, dblQuot, PlayerPath, titleArg, literalPlayerArgs)
            'End If

            'If Not PlayerType.Equals(PlayerTypeEnum.Vlc) Then --player-passthrough=hls{0}
                'returnValue &= String.Format("--hls-segment-threads=6{0}--ringbuffer-size=32000", space)
            'End If

            'If safeOutput = False Then
                'returnValue &= String.Format("--http-cookie={0}mediaAuth={1}{2}{0}{2}", dblQuot, Common.GetRandomString(240), space)
            'End If

            'returnValue &= String.Format("--http-header={0}User-Agent={2}{0}{1}", dblQuot, space, Common.UserAgent)

            'If safeOutput = False Then
                'returnValue &= String.Format("{0}hlsvariant://", dblQuot)

                'returnValue &= Stream.StreamUrl

                'returnValue = returnValue.Replace("CDN", Cdn.ToString().ToLower()) & space
            'Else
            '    returnValue &= String.Format("{0}hlsvariant://{1}{2}", dblQuot, English.msgCensoredStream, space)
            'End If

            'If Is60Fps Then
                'returnValue &= String.Format("name_key=bitrate{0}{1}best{1}", dblQuot, space)
            'Else
                'returnValue &= dblQuot & space & streamQuality & space
            'End If

            'returnValue &= String.Format("--http-no-ssl-verify{0}", space)

            'If UseOutputArgs Then
            '    Dim outputPath As String = PlayerOutputPath.
            '            Replace("(DATE)", DateHelper.GetPacificTime(Stream.Game.GameDate).ToString("yyyy-MM-dd")).
            '            Replace("(HOME)", Stream.Game.HomeAbbrev).
            '            Replace("(AWAY)", Stream.Game.AwayAbbrev).
            '            Replace("(TYPE)", Stream.Type.ToString()).
            '            Replace("(NETWORK)", Stream.Network)
            '    Dim suffix As Integer = 1
            '    Dim originalName = Path.GetFileNameWithoutExtension(outputPath)
            '    Dim originalExt = Path.GetExtension(outputPath)
            '    While (My.Computer.FileSystem.FileExists(outputPath))
            '        outputPath = Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(outputPath), originalName & "_" & suffix), originalExt)
            '        suffix += 1
            '    End While

            '    returnValue &= "-f -o" & space & dblQuot & outputPath & dblQuot & space
            'End If

            'If UseCustomStreamerArgs Then
            '    returnValue &= CustomStreamerArgs & space
            'End If

            'Return returnValue
       ' End Function

End Class
End Namespace
