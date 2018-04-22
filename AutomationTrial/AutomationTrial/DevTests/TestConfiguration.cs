using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using NUnit.Framework;

namespace AutomationTrial.DevTests
{
    /// <summary>
    /// Test Application configuration
    /// </summary>
    [TestFixture]
    public class TestConfiguration
    {
        private AppConfiguration _appConfiguration;
        /// <summary>
        /// Instanciate application configuration object
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _appConfiguration = new AppConfiguration();
        }
        /// <summary>
        /// Test That can get Url from Config
        /// </summary>
        [TestCase]
        public void TestGetApiUrlFromConfig()
        {
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.ApiUrl);
            Assert.AreEqual(url, "https://jsonplaceholder.typicode.com/posts");
        }

        [TestCase]
        public void TestGetRegistrationUrl()
        {
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationUrl);
            Assert.AreEqual(url, "https://www.nopcommerce.com/");
        }

        [TestCase]
        public void TestGetDiverPathFromHdd()
        {
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.WebDriverLocation);
            Assert.AreEqual(url, "ResourceRepo");
        }
    }
}
