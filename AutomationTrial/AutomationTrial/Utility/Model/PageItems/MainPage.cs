using System;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model.Browser;
using log4net;
using OpenQA.Selenium;

namespace AutomationTrial.Utility.Model.PageItems
{
    class MainPage
    {
        private readonly AppConfiguration _appConfiguration;
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainPage));
        private IWebDriver _driver;
        private BrowserBase _browser;
        public MainPage()
        {
            _appConfiguration=new AppConfiguration();
           
        }
        public MainPage OpenMainInBrowser(DriverType driverType)
        {
            
            _browser = new BrowserBase(driverType);
            _driver = _browser.GetDriver();
            var url = _appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.RegistrationUrl);
           _driver.Navigate().GoToUrl(url);
            return this;
        }

        public IWebElement RegistrationLink()
        {
            IWebElement link = null;
            try
            {
                link = _driver.FindElement(By.ClassName("ico-register"));
            }
            catch (Exception exception)
            {
                Log.Error($"Registration link Not found: {exception}");
            }
            return link;
        }

        

        public void Close()
        {
            _driver?.Dispose();
        }


    }
}
