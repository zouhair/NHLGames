Imports NAudio.CoreAudioApi

Namespace Utilities
    Public Class AdDetectionByVolume
        Inherits AdDetection

        Private ReadOnly _lastSoundTime As Dictionary(Of Integer, DateTime) = new Dictionary(Of Integer, DateTime)
        Private Property RequiredSilenceMilliseconds As Integer = 500
        Protected Overrides ReadOnly Property PollPeriodMilliseconds As Integer = 100
        Public Overrides Property SelectedDetectionType As AdDetectionTypeEnum = AdDetectionTypeEnum.Volume

        Protected Overrides Function IsAdCurrentlyPlaying() As Boolean
            Dim closedProcesses = _lastSoundTime.Keys.Where(Function(x) Not MediaPlayerProcesses.Contains(x)).ToList()
            Dim newProcesses = MediaPlayerProcesses.Where(Function(x) Not _lastSoundTime.Keys.Contains(x)).ToList()

            For Each closedProcess In closedProcesses
                _lastSoundTime.Remove(closedProcess)
            Next

            For Each newProcess In newProcesses
                AddOrUpdateLastSoundOccured(newProcess)
            Next

            For Each process In MediaPlayerProcesses
                If Math.Abs(GetCurrentVolume(process)) > 0.00001 Then
                    AddOrUpdateLastSoundOccured(process)
                End If
            Next

            Return _lastSoundTime.Values.All(Function(x) DateTime.Now - x > TimeSpan.FromMilliseconds(RequiredSilenceMilliseconds))
        End Function

        Private Sub AddOrUpdateLastSoundOccured(processId As Integer)
            If _lastSoundTime.ContainsKey(processId) Then
                _lastSoundTime(processId) = DateTime.Now
            Else 
                _lastSoundTime.Add(processId, DateTime.MinValue)
            End If
        End Sub

        Public Function GetCurrentVolume(processId As Integer) As Double
            Dim aMmDevices As New MMDeviceEnumerator()
            Dim defaultAudioEndPointDevice = aMmDevices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia)
            Dim sessionsDefaultAudioEndPointDevice = defaultAudioEndPointDevice.AudioSessionManager.Sessions

            For i As Integer = 0 To sessionsDefaultAudioEndPointDevice.Count
                If sessionsDefaultAudioEndPointDevice(i).GetProcessID <> processId Then Continue For
                Dim audioMeter As audioMeterInformation = sessionsDefaultAudioEndPointDevice(i).AudioMeterInformation
                Return audioMeter.MasterPeakValue
            Next

            Return 0.0
        End Function

    End Class
End Namespace
