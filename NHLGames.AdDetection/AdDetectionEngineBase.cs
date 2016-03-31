using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHLGames.AdDetection.Common;
using NHLGames.AdDetection.Properties;

namespace NHLGames.AdDetection
{
    public abstract class AdDetectionEngineBase
    {
        private List<int> m_mediaPlayerProcesses;

        private List<IAdModule> m_modules = new List<IAdModule>();

        protected abstract int PollPeriodMilliseconds { get; }

        private bool m_previousAdPlayingState;

        private bool m_firstAdCheck;

        protected ReadOnlyCollection<int> MediaPlayerProcesses => new ReadOnlyCollection<int>(m_mediaPlayerProcesses);

        internal void AddModule(IAdModule module)
        {
            lock (m_modules)
            {
                m_modules.Add(module);
                Task.Run(() => module.Initialize());
            }
        }

        internal void RemoveModule(string moduleName)
        {
            lock (m_modules)
            {
                var toRemove = m_modules.Where(x => x.Title == moduleName);

                foreach (var adModule in toRemove)
                {
                    m_modules.Remove(adModule);
                }
            }
        }

        internal void Start(List<IAdModule> modules)
        {
            m_previousAdPlayingState = false;
            m_firstAdCheck = true;

            foreach (var adModule in modules)
            {
                AddModule(adModule);
            }

            Task.Run(() => LoopForever());
        }

        public void LoopForever()
        {
            while (true)
            {
                try
                {
                    if (!MediaPlayerIsPlaying())
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        continue;
                    }

                    var newAdPlayingState = IsAdCurrentlyPlaying();

                    if (m_firstAdCheck || newAdPlayingState != m_previousAdPlayingState)
                    {
                        m_firstAdCheck = false;
                        m_previousAdPlayingState = newAdPlayingState;
                        NotifyModules();
                    }
                }
                catch (Exception e)
                {
                    Utilities.WriteLineWithTime($"Unexpected Exception: {e.Message}");
                }

                Thread.Sleep(PollPeriodMilliseconds);
            }
        }

        protected abstract bool IsAdCurrentlyPlaying();

        private bool MediaPlayerIsPlaying()
        {
            var vlcProcesses =
                Process.GetProcessesByName("vlc").Where(x => x.MainWindowTitle == @"fd://0 - VLC media player" || x.MainWindowTitle.ToLower().Contains(" vs ")).Select(x => x.Id);

            var mpc64Processes =
                Process.GetProcessesByName("MPC-HC64").Where(x => x.MainWindowTitle == @"stdin" || x.MainWindowTitle.ToLower().Contains(" vs ")).Select(x => x.Id);

            var mpc32Processes =
                Process.GetProcessesByName("MPC-HC").Where(x => x.MainWindowTitle == @"stdin" || x.MainWindowTitle.ToLower().Contains(" vs ")).Select(x => x.Id);

            m_mediaPlayerProcesses = vlcProcesses.Concat(mpc64Processes).Concat(mpc32Processes).ToList();


            return m_mediaPlayerProcesses.Count != 0;
        }

        private void NotifyModules()
        {
            lock (m_modules)
            {
                foreach (var module in m_modules)
                {
                    if (m_previousAdPlayingState)
                    {
                        Task.Run(() => module.AdStarted());
                    }
                    else
                    {
                        Task.Run(() => module.AdEnded());
                    }
                }
            }
        }
    }
}