using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace NHLGames.AdDetection
{
    [DataContract]
    public class AdDetectionSettings
    {
        private static readonly string m_fileName = @"./AdDetectionSettings.xml";

        private AdDetectionSettings()
        {
        }

        private AdDetectionSettings(bool isEnabled, List<string> enabledModules)
        {
            IsEnabled = isEnabled;
            EnabledModules = enabledModules;
        }

        private static AdDetectionSettings Default => new AdDetectionSettings(false, new List<string>());

        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }

        [DataMember]
        public List<string> EnabledModules { get; set; }


        public static AdDetectionSettings Load()
        {
            try
            {
                if (File.Exists(m_fileName))
                {
                    var s = new DataContractSerializer(typeof (AdDetectionSettings));
                    using (var fs = File.Open(m_fileName, FileMode.Open))
                    {
                        using (var reader = XmlReader.Create(fs))
                        {
                            return (AdDetectionSettings) s.ReadObject(reader);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Unable to load {m_fileName}. Using default config.");
            }

            var newConfig = Default;
            Save(newConfig);
            return newConfig;
        }

        public static void Save(AdDetectionSettings settings)
        {
            try
            {
                var s = new DataContractSerializer(typeof (AdDetectionSettings));
                using (var fs = File.Open(m_fileName, FileMode.Create))
                {
                    s.WriteObject(fs, settings);
                }
            }
            catch
            {
                Console.WriteLine($"Unable to save {m_fileName}");
            }
        }
    }
}