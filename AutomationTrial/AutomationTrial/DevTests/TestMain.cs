using System;
using System.Threading;
using AutomationTrial.Utility.Model.PageItems;
using AutomationTrial.Utility.Model.TestData;
using NUnit.Framework;

namespace AutomationTrial.DevTests
{
    [TestFixture()]
    class TestMain
    {
        private readonly MainPage _mainPage=new MainPage();
      /*  [TestCase()]
        public void OpenMain()
        {
            mainPage= new MainPage();
            var page = mainPage.OpenMainInBrowser(DriverType.Edge);
            var registrationlink = page.RegistrationLink();
            mainPage.Click(registrationlink);

        }*/
       /* [TestCase]
        public void RegisterPage()
        {
            var r = new RegistrationPage();
            r.OpenRegistrationInBrowser(DriverType.Edge);
            var f= r.FirstNameInput();
            var l = r.LastNameInput();
            var c = r.CountryInput();
            r.SendDataToInput(f,"ASD");
            r.SendDataToInput(l, "2");
            r.SendDataToInput(c, "Australia");

        }*/
        [TestCase]
        public void Generator()
        {
            var s = new RandomDataGenerator();
            var t=s.GenerateRandomString( 8);
            Assert.True(t.Length==8);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
           _mainPage.Close();
        }
    }
}
