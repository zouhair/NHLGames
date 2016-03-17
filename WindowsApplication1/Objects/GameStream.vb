Imports System.Globalization
Imports Newtonsoft.Json.Linq

Public Class GameStream

    Public GameURL As String = ""
    Public VODURL As String = ""
    Public PlayBackID As String = ""
    Public Type As StreamType

    Public Enum StreamType
        Away
        Home
        National
        French
    End Enum

    Public ReadOnly Property Availability As String
        Get
            If IsAvailable Then
                Return "Watch"
            Else
                'Return "Unavailable"
                Return ""
            End If
        End Get
    End Property

    Public Property IsAvailable As Boolean = False

    Public Sub New()

    End Sub
    Public Sub New(game As Game, stream As JObject, availableGameIds As List(Of String), type As StreamType)

        Dim dateString As String = game.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/")
        Dim dateString2 As String = game.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        Dim feedType As String = stream.Property("mediaFeedType").Value.ToString().Replace("AWAY", "VISIT")

        Me.PlayBackID = stream.Property("mediaPlaybackId").Value.ToString()
        Me.GameURL = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & dateString & "/NHL_GAME_VIDEO_" & game.AwayAbbrev & game.HomeAbbrev & "_M2_" & feedType & "_" & dateString2 & "/master_wired60.m3u8"
        Me.VODURL = "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/" & dateString & "/NHL_GAME_VIDEO_" & game.AwayAbbrev & game.HomeAbbrev & "_M2_" & feedType & "_" & dateString2 & "/master_wired60.m3u8"
        Me.Type = type

        If availableGameIds.Contains(PlayBackID) Then
            IsAvailable = True
        End If
    End Sub

End Class
