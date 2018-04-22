using System;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using AutomationTrial.Utility.Model.TestData;
using NUnit.Framework;

namespace AutomationTrial.DevTests
{
    [TestFixture()]
    class TestRandomGenerator
    {
        [TestCase()]
        public void TestGeneratingRandomData()
        {
            var aut = new TestDataGenerator();
            Registration registration = aut.GetRegistrationData();
            var appconf= new AppConfiguration();
            var path = appconf.GetApplicationConfigurationValue(ConfigurationEnums.WebDriverLocation);

            Console.Out.WriteLine();
        }
    }
}
