using System;
using System.Collections.Generic;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model.Browser;
using log4net;
using OpenQA.Selenium;

namespace AutomationTrial.Utility.Model.PageItems
{
    public class LoginPage
    {
        private readonly AppConfiguration _appConfiguration;
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginPage));
        private IWebDriver _driver;
        private BrowserBase _browser;
        private const string PageName = "login.aspx";
        private readonly Dictionary<string, string> _selectors;
        private string _elementName;

        public LoginPage()
        {
            _appConfiguration = new AppConfiguration();
            _selectors =  new Dictionary<string, string>
            {
                {"UserName", "ctl00$ctl00$cph1$cph1$ctrlCustomerLogin$LoginForm$UserName"},
                {"Password","ctl00$ctl00$cph1$cph1$ctrlCustomerLogin$LoginForm$Password" },
                {"Login", "ctl00$ctl00$cph1$cph1$ctrlCustomerLogin$LoginForm$LoginButton"}
            };
        }
        public void OpenLoginPageInBrowser(DriverType driverType)
        {
            _browser = new BrowserBase(driverType);
            _driver = _browser.GetDriver();
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationUrl);
            var endpoint = url + PageName;
            Log.Info($"Navigating to {endpoint}");
            _driver.Navigate().GoToUrl(endpoint);
        }

        public IWebElement UserNameInput()
        {
            var key = "UserName";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public IWebElement PasswordInput()
        {
            var key = "Password";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public void SendDataToInput(IWebElement element, string key)
        {
            Log.Info($"Sending '{key}' to {_elementName} ");
            element.SendKey(key);
        }

        public IWebElement LoginButton()
        {
            var key = "Login";
            _elementName = key;
            var selector = _selectors[key];
            var input = FindWebElement(selector, key);
            return input;
        }
        public void ClickOn(IWebElement element)
        {
            SharedActions.Click(element);
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

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
