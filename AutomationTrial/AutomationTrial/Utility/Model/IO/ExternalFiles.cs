using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using AutomationTrial.Utility.Enums;
using log4net;
using Newtonsoft.Json;

namespace AutomationTrial.Utility.Model.IO
{

    public class ExternalFiles
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ExternalFiles));

        private readonly AppConfiguration _appConfiguration;

        /// <summary>
        /// default constractor get working dir
        /// </summary>
        public ExternalFiles()
        {
            // _currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;
            _appConfiguration = new AppConfiguration();
        }

        /// <summary>
        /// loads the exe path of a driver based on its type
        /// </summary>
        /// <returns>Path of a driver </returns>
        public string GetRepositoryFolder()
        {
            {
                var driverLocation =
                    _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.WebDriverLocation);
                var projectDir = GetProjectDir();
                Log.Info($"Project Dir: {projectDir}");
                var path = Path.Combine(projectDir, driverLocation);
                Log.Info($"Driver Dir: {path}");
                return path;
            }
        }
        /// <summary>
        /// NUNit Runner loads assebly from user
        /// Have to navigate to assembly folder to get the rood project
        /// </summary>
        /// <returns>path to root project</returns>
        private string GetProjectDir()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var codebase = new Uri(assembly.EscapedCodeBase);
            var path = codebase.LocalPath;
            for (int i = 0; i < 3; i++)
            {
                path = Directory.GetParent(path).ToString();
            }
            return path;
        }
        public void Save(Registration registration)
        {
            string path = null;
            try
            {
                var fileName =
                    _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationFileName);
                path = GetRepositoryFolder();
                path = Path.Combine(path, fileName);
               // var outFile = File.Create(path);
                TextWriter tw = new StreamWriter(path);
                var formatter = new XmlSerializer(registration.GetType());
                formatter.Serialize(tw, registration);
                Log.Info($"Registration: {registration} saved in path: {path}");
            }
            catch(Exception exception)
            {
                Console.Out.WriteLine(exception);
                Log.Error($"#Could not save Registration: {registration} saved in path: {path}| exception: {exception}");
                throw;
            }
        }

        public Registration LoadSavedObject()
        {
            Registration registration = null;
            string path = null;
            try
            {
                var fileName =
                    _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationFileName);
                path = GetRepositoryFolder();
                path = Path.Combine(path, fileName);
                var reader = new XmlSerializer(typeof(Registration));
                var file = new StreamReader(path);
                registration = (Registration) reader.Deserialize(file);
                file.Close();
            }
            catch (Exception exception)
            {
                Log.Error($"#Could not load Registration: {registration} saved in path: {path} |exception: {exception}");
                throw;
            }
            return registration;

        }

        public List<Post> LoadApiTestData()
        {
            List<Post> expectedPostsList;
            string path = null;
            try
            {
                var fileName =
                    _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.ExpectedApiData);
                path = GetRepositoryFolder();
                path = Path.Combine(path, fileName);
                // read JSON directly from a file
                var jsonpostJsonData = File.ReadAllText(path);
                expectedPostsList = JsonConvert.DeserializeObject<List<Post>>(jsonpostJsonData);
               
            }
            catch (Exception exception)
            {
                Log.Error($"#Could not load expected json data  in path: {path} |exception: {exception}");
                throw;
            }
            return expectedPostsList;
        }
    }

}
