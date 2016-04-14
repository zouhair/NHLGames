using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using NHLGames.AdDetection.Common;
using UserControl = System.Windows.Controls.UserControl;

namespace NHLGames.AdDetection.Modules.OBS
{
    /// <summary>
    ///     A template of a sample module
    ///     See Spotify module for an implemented example.
    /// </summary>
    /// <remarks>
    ///     Export attribute is required so that it is loaded by the main program.
    ///     You must also output to NhlGames\AdModules\ModuleName folder to be loaded properly.
    /// </remarks>
    [Export(typeof(IAdModule))]
    public class ObsModule : IAdModule
    {
        private readonly ObsModuleViewModel m_viewModel;
        public ObsModule()
        {
            m_viewModel = new ObsModuleViewModel();
        }
        /// <summary>
        ///     The title of your module.
        /// </summary>
        public string Title => "OBS Scene Changer (incomplete)";

        /// <summary>
        ///     A description of your module.
        /// </summary>
        public string Description => "Emulates pressing the keys you configured when an ad starts and stops to automatically change scenes for you.";

        /// <summary>
        ///     An optional WPF control if you need configurable options.
        ///     You are responsible for listening to changes and auto-saving them.
        /// </summary>
        public UserControl SettingsControl => m_viewModel.SettingsControl;

        public void Initialize()
        {
            //Initialization code that your module needs to function for it to work
            //You are responsible for making sure your plugin is initialized in your AdStart/Stop methods.
        }

        public void AdStarted()
        {
            var settings = ObsModuleSettings.Load();

            string toSend = String.Empty;
            if (settings.AdSceneCtrl)
            {
                toSend += "^";
            }
            if (settings.AdSceneAlt)
            {
                toSend += "%";
            }
            if (settings.AdSceneShift)
            {
                toSend += "+";
            }

            toSend += settings.AdSceneChar;

            if (!String.IsNullOrEmpty(toSend))
            {
                SendKeys.SendWait(toSend);
            }
        }

        public void AdEnded()
        {
            var settings = ObsModuleSettings.Load();

            string toSend = String.Empty;
            if (settings.GameSceneCtrl)
            {
                toSend += "^";
            }
            if (settings.GameSceneAlt)
            {
                toSend += "%";
            }
            if (settings.GameSceneShift)
            {
                toSend += "+";
            }

            toSend += settings.GameSceneChar;

            if (!String.IsNullOrEmpty(toSend))
            {
                SendKeys.SendWait(toSend);
            }
        }

        public void Stop()
        {
            //The action to perform when your module is disabled (Not disposed, it can be Initialized again after if it's enabled.
        }
    }
}