using System;
using System.IO;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using AutomationTrial.Utility.Model.IO;
using AutomationTrial.Utility.Model.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace AutomationTrial.DevTests
{
    [TestFixture]
    public class TestExternalFiles
    {
        private ExternalFiles _externalFiles;
        private string _driverPath;
        [SetUp]
        public void Setup()
        {
            _externalFiles = new ExternalFiles();

        }
        [TestCase()]
        public void CanLaodEdge()
        {
            IWebDriver edgeDriver = null;
            try
            {
            _driverPath = _externalFiles.GetRepositoryFolder();
            edgeDriver = new EdgeDriver(_driverPath);
            edgeDriver.Navigate().GoToUrl("http://www.bing.com");
            var title = edgeDriver.Title;
         
                Assert.AreEqual(title, "Bing");
            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(InvalidOperationException)) Console.Out.WriteLine("Edge not installed in the system");
                Console.Error.WriteLine(exception);
                throw;
            }
            finally
            {
                edgeDriver?.Quit();
            }
        }

        [TestCase]
        public void CanLoadChrome()
        {
            IWebDriver googleChromeDriver = null;
            try
            {
            _driverPath = _externalFiles.GetRepositoryFolder();
            googleChromeDriver = new ChromeDriver(_driverPath);
            googleChromeDriver.Navigate().GoToUrl("http://www.google.com");
            var title = googleChromeDriver.Title;
          
                Assert.AreEqual(title, "Google");
            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(InvalidOperationException)) Console.Out.WriteLine("Chrome not installed in the system");
                Console.Error.WriteLine(exception);
                throw;
            }
            finally
            {
                googleChromeDriver?.Quit();
            }
        }

        [TestCase,Order(1)]
        public void SaveRegistrationData()
        {
            var randomDataGenerator= new TestDataGenerator();
            var registration = randomDataGenerator.GetRegistrationData();
            _externalFiles.Save(registration);
            var path = _externalFiles.GetRepositoryFolder();
            var appconfig=new AppConfiguration();
            var fileName = appconfig.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationFileName);
            path = Path.Combine(path, fileName);
            Assert.IsTrue(File.Exists(path));
        }

        [TestCase, Order(2)]
        public void ReadRegisteredData()
        {
           var registration= _externalFiles.LoadSavedObject();
           Assert.NotNull(registration);
        }

        [TestCase]
        public void ReadJsonExpectedpostData()
        {
            _externalFiles.LoadApiTestData();
        }
    }
}
