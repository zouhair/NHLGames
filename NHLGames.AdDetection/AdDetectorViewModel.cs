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

        private ObservableCollection<IAdModule> m_disabledModules;

        private DelegateCommand<IAdModule> m_disableModuleCommand;

        private ObservableCollection<IAdModule> m_enabledModules;

        private DelegateCommand<IAdModule> m_enableModuleCommand;

        private Dictionary<string, IAdModule> m_modules;


        private IAdModule m_selectedModule;

        public UserControl SettingsControl;

        public AdDetectorViewModel()
        {
            EnableModuleCommand.ObservesProperty(() => SelectedModule);
            DisableModuleCommand.ObservesProperty(() => SelectedModule);

            m_settings = AdDetectionSettings.Load();

            AdDetectingEnabled = m_settings.IsEnabled;

            ImportModules();
            RemoveUninstalledModulesFromConfig();

            EnabledModules =
                new ObservableCollection<IAdModule>(m_modules.Where(x => m_settings.EnabledModules.Contains(x.Key)).Select(x => x.Value));
            DisabledModules =
                new ObservableCollection<IAdModule>(m_modules.Where(x => !m_settings.EnabledModules.Contains(x.Key)).Select(x => x.Value));

            SettingsControl = new AdDetectorUserControl(this);

            //ScreenAdDetectionEngine engine = new ScreenAdDetectionEngine();
            var engine = new VolumeAdDetectionEngine();
            engine.Start(m_modules.Where(x => m_settings.EnabledModules.Contains(x.Key)).Select(x => x.Value).ToList());
        }

        public DelegateCommand<IAdModule> EnableModuleCommand
            => m_enableModuleCommand = m_enableModuleCommand ?? new DelegateCommand<IAdModule>(EnableModule, CanEnableModuleExecute);

        public DelegateCommand<IAdModule> DisableModuleCommand
            => m_disableModuleCommand = m_disableModuleCommand ?? new DelegateCommand<IAdModule>(DisableModule, CanDisableModuleExecute)
            ;

        public IAdModule SelectedModule
        {
            get { return m_selectedModule; }
            set
            {
                SetProperty(ref m_selectedModule, null);

                SetProperty(ref m_selectedModule, value);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IAdModule> EnabledModules
        {
            get { return m_enabledModules; }
            set { SetProperty(ref m_enabledModules, value); }
        }

        public ObservableCollection<IAdModule> DisabledModules
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


        private bool CanDisableModuleExecute(IAdModule x)
        {
            return x != null && m_enabledModules.Contains(x);
        }

        private bool CanEnableModuleExecute(IAdModule x)
        {
            return x != null && m_disabledModules.Contains(x);
        }

        private void EnableModule(IAdModule module)
        {
            DisabledModules.Remove(module);
            EnabledModules.Add(module);

            m_settings.EnabledModules = EnabledModules.Select(x => x.Title).ToList();
            AdDetectionSettings.Save(m_settings);
        }

        private void DisableModule(IAdModule module)
        {
            EnabledModules.Remove(module);
            DisabledModules.Add(module);

            m_settings.EnabledModules = EnabledModules.Select(x => x.Title).ToList();
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