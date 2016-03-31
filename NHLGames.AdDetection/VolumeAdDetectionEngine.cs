using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSCore.CoreAudioAPI;

namespace NHLGames.AdDetection
{
    public class VolumeAdDetectionEngine : AdDetectionEngineBase
    {
        private readonly Dictionary<int, DateTime> m_lastSoundTime = new Dictionary<int, DateTime>();
        protected override int PollPeriodMilliseconds => 100;

        private int m_requiredSilence => 500;

        protected override bool IsAdCurrentlyPlaying()
        {
            var closedProcesses = m_lastSoundTime.Keys.Where(x => !MediaPlayerProcesses.Contains(x)).ToList();
            var newProcesses = MediaPlayerProcesses.Where(x => !m_lastSoundTime.Keys.Contains(x)).ToList();
            foreach (var closedProcess in closedProcesses)
            {
                m_lastSoundTime.Remove(closedProcess);
            }


            foreach (var newProcess in newProcesses)
            {
                AddOrUpdateLastSoundOccured(newProcess);
            }


            foreach (var process in MediaPlayerProcesses)
            {
                if (Math.Abs(GetCurrentVolume(process)) > 0.00001)
                {
                    AddOrUpdateLastSoundOccured(process);
                }
            }


            if (m_lastSoundTime.Values.All(x => DateTime.Now - x > TimeSpan.FromMilliseconds(m_requiredSilence)))
            {
                return true;
            }


            return false;
        }

        private void AddOrUpdateLastSoundOccured(int processId)
        {
            if (m_lastSoundTime.ContainsKey(processId))
            {
                m_lastSoundTime[processId] = DateTime.Now;
            }
            else
            {
                m_lastSoundTime.Add(processId, DateTime.Now);
            }
        }


        public float GetCurrentVolume(int processId)
        {
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
            {
                foreach (var session in sessionEnumerator)
                {
                    using (var session2 = session.QueryInterface<AudioSessionControl2>())
                    {
                        if (session2.ProcessID == processId)
                        {
                            using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                            {
                                return audioMeterInformation.GetPeakValue();
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }
    }
}