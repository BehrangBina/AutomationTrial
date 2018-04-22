using System;
using System.Collections.Generic;
using System.Threading;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model.Browser;
using log4net;
using OpenQA.Selenium;

namespace AutomationTrial.Utility.Model.PageItems
{
    /// <summary>
    /// Registration page object Model
    /// </summary>
    class RegistrationPage
    {
        private readonly AppConfiguration _appConfiguration;
        private static readonly ILog Log = LogManager.GetLogger(typeof(RegistrationPage));
        private IWebDriver _driver;
        private BrowserBase _browser;
        private const string PageName = "register.aspx";
        private readonly Dictionary<string, string> _selectors;
        private string _elementName;
        public RegistrationPage()
        {
            _selectors = new Dictionary<string, string>
            {
                {"FirstName","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$txtFirstName"},
                {"LastName","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$txtLastName"},
                {"Email","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$Email"},
                {"UserName","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$UserName"},
                {"Country","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$ddlCountry"},
                {"Role","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$ddlRole"},
                {"NewsLetter","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$cbNewsletter"},
                {"Password","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$Password" },
                {"ConfirmPassWord","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$CreateUserStepContainer$ConfirmPassword" },
                {"Submit","ctl00$ctl00$cph1$cph1$ctrlCustomerRegister$CreateUserForm$__CustomNav0$StepNextButton" },
                {"RegistrationResult","ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CompleteStepContainer_lblCompleteStep" }
            };
            _appConfiguration = new AppConfiguration();
        }
        public RegistrationPage OpenRegistrationInBrowser(DriverType driverType)
        {
            _browser = new BrowserBase(driverType);
            _driver = _browser.GetDriver();
          
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationUrl);
            var endpoint = url + PageName;
            Log.Info($"Navigating to {endpoint}");
            _driver.Navigate().GoToUrl(endpoint);
            return this;
        }

        public IWebElement FirstNameInput()
        {
            var key = "FirstName";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement LastNameInput()
        {
            var key = "LastName";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement EmailInput()
        {
            var key = "Email"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement UserNameInput()
        {
            var key = "UserName"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement CountryInput()
        {
            var key = "Country"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement RoleInput()
        {
            var key = "Role"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }

        public void SetRole(IWebElement element, string value)
        {
            SharedActions.SelectDropDownByValue(element, value);
        }
        public IWebElement NewsLetter()
        {
            var key = "NewsLetter"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement PasswordInput()
        {
            var key = "Password";
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement ConfirmPassWordInput()
        {
            var key = "ConfirmPassWord"; _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }

        public IWebElement SubmitButtonInput()
        {
            var key = "Submit";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;

        }

        public IWebElement RegistrationResultTextInput()
        {
            var key = "RegistrationResult";
            _elementName = key;
            var selector = _selectors[key];
            var input = _driver.FindElement(By.Id(selector));
            return input;
        }

        private IWebElement FindWebElement(string element, string key)
        {
            IWebElement input = null;
            try
            {
                input = _driver.FindElement(By.Name(element));
                Log.Info($"Found input for Key:{key} Name:{element}");
            }
            catch (Exception exception)
            {
                Log.Error($"#input for Key:{key} Name:{element} Not found: {exception}");
            }
            return input;
        }

        public void SendDataToInput(IWebElement element, string key)
        {
            Log.Info($"Sending '{key}' to {_elementName} ");
            element.SendKey(key);
        }

        public void ClickOn(IWebElement element)
        {
            SharedActions.Click(element);
        }
        public IWebDriver GetDriver() => _driver;
    }
}
