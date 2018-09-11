using Newtonsoft.Json;
using System;
using System.IO;
using webCleaner.Models;
using webCleaner.Options;

namespace webCleaner.Services
{
    public interface IConfigurationService
    {
        ConfigurationModel Load();
        void Save(ConfigurationModel model);
    }

    public class ConfigurationService: IConfigurationService
    {
        private readonly string appDataPath;
        private readonly string configFolderPath;
        private readonly string configFilePath;

        public ConfigurationService()
        {
            var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            configFolderPath = Path.Combine(appDataPath, appName);
            configFilePath = Path.Combine(configFolderPath, "config.json");
        }

        public ConfigurationModel Load()
        {
            if (!File.Exists(configFilePath))
                return new ConfigurationModel();

            using (StreamReader file = File.OpenText(configFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                var config = (ConfigurationModel)serializer.Deserialize(file, typeof(ConfigurationModel));
                if (config == null)
                    return new ConfigurationModel();
                return config;
            }
        }

        public void Save(ConfigurationModel model)
        {
            if (model == null)
                return;
            if (!Directory.Exists(configFolderPath))
                Directory.CreateDirectory(configFolderPath);

            using (StreamWriter file = File.CreateText(configFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, model);
            }
        }        
    }
}