using System;
using System.Threading;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using AutomationTrial.Utility.Model.IO;
using AutomationTrial.Utility.Model.PageItems;
using AutomationTrial.Utility.Model.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AutomationTrial.SystemTests.Steps
{
    [Binding]
    public class RegisterNewAccountSteps
    {

        private readonly RegistrationPage _registrationPage;
        private  IWebDriver _driver;
        private  Registration _registration;
        private readonly ExternalFiles _externalFiles;

        
        public   RegisterNewAccountSteps()
        {
            _registrationPage= new RegistrationPage();
            _registration=new Registration();
            _externalFiles=new ExternalFiles();
        }
        [Given(@"Iam in the registration Page in ""(.*)"" browser")]
        public void GivenIamInTheRegistrationPageInBrowser(string driverType)
        {
            DriverType browserType = (DriverType)Enum.Parse(typeof(DriverType), driverType);
            _registrationPage.OpenRegistrationInBrowser(browserType);
            _driver = _registrationPage.GetDriver();
            Assert.AreEqual(_driver.Title, "Register - nopCommerce");
        }
        
        [Given(@"I have generated a random registration data")]
        public void GivenIHaveGeneratedARandomRegistrationData()
        {
            var testDataGenerator= new TestDataGenerator();
            _registration = testDataGenerator.GetRegistrationData();
            Assert.IsNotNull(_registration);
        }
        
        [When(@"I sned data to registration Page")]
        public void WhenISnedDataToRegistrationPage()
        {
            var firstName = _registrationPage.FirstNameInput();
            _registrationPage.SendDataToInput(firstName, _registration.FirstName);

            var lastName = _registrationPage.LastNameInput();
            _registrationPage.SendDataToInput(lastName, _registration.LastName);

            var email = _registrationPage.EmailInput();
            _registrationPage.SendDataToInput(email, _registration.Email);

            var password = _registrationPage.PasswordInput();
            _registrationPage.SendDataToInput(password, _registration.Password);

            var confirmPassword = _registrationPage.ConfirmPassWordInput();
            _registrationPage.SendDataToInput(confirmPassword, _registration.ConfirmPassword);

            var country = _registrationPage.CountryInput();
            _registrationPage.SendDataToInput(country, _registration.Country);
            var role = _registrationPage.RoleInput();

            var userName = _registrationPage.UserNameInput();
            _registrationPage.SendDataToInput(userName, _registration.Username);

            var newsLetter = _registrationPage.NewsLetter();
            if(!_registration.NewsLetter)_registrationPage.ClickOn(newsLetter);

            _registrationPage.SetRole(role,_registration.Roles.ToString());
        }
        
        [Then(@"I can register")]
        public void ThenICanRegister()
        {
            var registerButton = _registrationPage.SubmitButtonInput();
            _registrationPage.ClickOn(registerButton);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _externalFiles.Save(_registration);
            Thread.Sleep(2000);
            var submissionResult = _registrationPage.RegistrationResultTextInput().Text.Trim();
            Assert.AreEqual("Your registration completed",submissionResult);
            AfterTestRun();
        }

        
        public  void AfterTestRun()
        {
            _driver?.Quit();
        }
    }
}
