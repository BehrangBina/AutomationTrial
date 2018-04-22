using System;
using System.Linq;
using System.Threading;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using AutomationTrial.Utility.Model.IO;
using AutomationTrial.Utility.Model.PageItems;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace AutomationTrial.SystemTests.Steps
{
    [Binding,Order(2)]
    public class LoginRegisteredAccountSteps
    {
        private static LoginPage _loginPage;
        private static IWebDriver _driver;
        private static Registration _registration;
        private static ExternalFiles _externalFiles;
        
        public LoginRegisteredAccountSteps()
        {
            _loginPage = new LoginPage();
            _registration = new Registration();
            _externalFiles = new ExternalFiles();
        }
        [Given(@"I have valid registered account"), Order(5)]
        public void GivenIHaveValidRegisteredAccount()
        {
            _registration = _externalFiles.LoadSavedObject();
            Assert.IsNotNull(_registration);
        }
        [Given(@"I click and go to login page in ""(.*)"" browser"), Order(6)]
        public void GivenIClickAndGoToLoginPageInBrowser(string driverType) { 
            DriverType browserType = (DriverType)Enum.Parse(typeof(DriverType), driverType);
            _loginPage.OpenLoginPageInBrowser(browserType);
            _driver = _loginPage.GetDriver();
            Assert.AreEqual(_driver.Title, "Login - nopCommerce");
        }
        
        [When(@"I put my details"), Order(7)]
        public void WhenIPutMyDetails()
        {
            var loginTextbox = _loginPage.UserNameInput();
            _loginPage.SendDataToInput(loginTextbox,_registration.Username);
            var passwordTextBox = _loginPage.PasswordInput();
            _loginPage.SendDataToInput(passwordTextBox, _registration.Password);

        }

        [Then(@"I can login to the system successfully"), Order(8)]
        public void ThenICanLoginToTheSystemSuccessfully()
        {
            var loginButton = _loginPage.LoginButton();
            _loginPage.ClickOn(loginButton);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            bool logOut = _driver.FindElements(By.TagName("a")).Any(link => link.Text.Trim().Equals("Log out"));
            Assert.IsTrue(logOut, "logOut Button Exist");
            AfterTestRun();
        }

        
        public  void AfterTestRun()
        {
            _driver?.Quit();
        }
    }
}
