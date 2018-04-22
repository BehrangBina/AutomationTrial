using System;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace AutomationTrial.Utility.Model.Browser
{
    public class BrowserBase:IDisposable
    {
        private readonly IWebDriver _driver;

        public BrowserBase(DriverType driverType)
        {
            var externalFiles = new ExternalFiles();
            var path = externalFiles.GetRepositoryFolder();
            switch (driverType)
            {
                    case DriverType.Edge:
                        
                        _driver=new EdgeDriver(path);
                    break;
                    case DriverType.Chrome:
                        _driver=new ChromeDriver(path);
                        _driver.Manage().Window.Maximize();
                        var tabs = _driver.WindowHandles;
                        if (tabs.Count > 1)
                        {
                            _driver.SwitchTo().Window(tabs[1]);

                            _driver.Close();

                            _driver.SwitchTo().Window(tabs[0]);
                        }
                    break;
                   }
        }

        public IWebDriver GetDriver() => _driver;
        public void Dispose()=> _driver.Quit();
        
    }
}
