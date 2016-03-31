using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using NHLGames.AdDetection.Common;
using Prism.Commands;
using Prism.Mvvm;

namespace NHLGames.AdDetection
{
    public class AdDetectorViewModel : BindableBase
    {
        private readonly AdDetectionSettings m_settings;

        private bool m_adDetectingEnabled;

        private ObservableCollection<string> m_disabledModules;

        private DelegateCommand<string> m_disableModuleCommand;

        private ObservableCollection<string> m_enabledModules;

        private DelegateCommand<string> m_enableModuleCommand;

        private Dictionary<string, IAdModule> m_modules;

        private string m_selectedDisabledModule;


        private string m_selectedEnabledModule;

        public UserControl SettingsControl;

        public AdDetectorViewModel()
        {
            EnableModuleCommand.ObservesProperty(() => SelectedDisabledModule);
            DisableModuleCommand.ObservesProperty(() => SelectedEnabledModule);

            m_settings = AdDetectionSettings.Load();

            AdDetectingEnabled = m_settings.IsEnabled;

            ImportModules();
            RemoveUninstalledModulesFromConfig();

            EnabledModules =
                new ObservableCollection<string>(m_modules.Keys.Where(x => m_settings.EnabledModules.Contains(x)));
            DisabledModules =
                new ObservableCollection<string>(m_modules.Keys.Where(x => !m_settings.EnabledModules.Contains(x)));

            SettingsControl = new AdDetectorUserControl(this);

            //ScreenAdDetectionEngine engine = new ScreenAdDetectionEngine();
            var engine = new VolumeAdDetectionEngine();
            engine.Start(m_modules.Where(x => m_settings.EnabledModules.Contains(x.Key)).Select(x => x.Value).ToList());
        }

        public DelegateCommand<string> EnableModuleCommand
            => m_enableModuleCommand = m_enableModuleCommand ?? new DelegateCommand<string>(EnableModule, CanExecute);

        public DelegateCommand<string> DisableModuleCommand
            => m_disableModuleCommand = m_disableModuleCommand ?? new DelegateCommand<string>(DisableModule, CanExecute)
            ;

        public string SelectedDisabledModule
        {
            get { return m_selectedDisabledModule; }
            set
            {
                SetProperty(ref m_selectedDisabledModule, value);
                OnPropertyChanged();
            }
        }

        public string SelectedEnabledModule
        {
            get { return m_selectedEnabledModule; }
            set
            {
                SetProperty(ref m_selectedEnabledModule, value);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> EnabledModules
        {
            get { return m_enabledModules; }
            set { SetProperty(ref m_enabledModules, value); }
        }

        public ObservableCollection<string> DisabledModules
        {
            get { return m_disabledModules; }
            set { SetProperty(ref m_disabledModules, value); }
        }

        public bool AdDetectingEnabled
        {
            get { return m_adDetectingEnabled; }
            set
            {
                if (SetProperty(ref m_adDetectingEnabled, value))
                {
                    EnableChanged();
                }
            }
        }


        private bool CanExecute(string x)
        {
            return !string.IsNullOrWhiteSpace(x);
        }

        private void EnableModule(string module)
        {
            DisabledModules.Remove(module);
            EnabledModules.Add(module);

            m_settings.EnabledModules = EnabledModules.ToList();
            AdDetectionSettings.Save(m_settings);
        }

        private void DisableModule(string module)
        {
            EnabledModules.Remove(module);
            DisabledModules.Add(module);

            m_settings.EnabledModules = EnabledModules.ToList();
            AdDetectionSettings.Save(m_settings);
        }

        private void RemoveUninstalledModulesFromConfig()
        {
            var removedModules =
                m_settings.EnabledModules.Where(enabledModule => !m_modules.ContainsKey(enabledModule)).ToList();

            m_settings.EnabledModules.RemoveAll(x => removedModules.Contains(x));
            AdDetectionSettings.Save(m_settings);
        }

        private void ImportModules()
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var modulesDirectory = Directory.GetDirectories(assemblyDirectory + @"\AdModules");


            var catalog = new AggregateCatalog();
            foreach (var module in modulesDirectory)
            {
                catalog.Catalogs.Add(
                    new DirectoryCatalog(module));
            }

            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            m_modules = container.GetExportedValues<IAdModule>().ToDictionary(k => k.Title, v => v);
        }

        private void EnableChanged()
        {
            if (m_settings.IsEnabled != AdDetectingEnabled)
            {
                m_settings.IsEnabled = AdDetectingEnabled;

                AdDetectionSettings.Save(m_settings);
            }
        }
    }
}