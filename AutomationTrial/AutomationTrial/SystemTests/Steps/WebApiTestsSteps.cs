using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Model;
using AutomationTrial.Utility.Model.Browser;
using AutomationTrial.Utility.Model.IO;
using AutomationTrial.Utility.Model.WebApi;
using log4net;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AutomationTrial.SystemTests.Steps
{
    [Binding]
    public class WebApiTestsSteps
    {
        private readonly ExternalFiles _externalFiles;
        private BrowserBase _browser;
        private IWebDriver _driver;
        private readonly string _url;
        private List<Post> _postListInWebPage;
        private readonly ApiActions _apiActions;
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebApiTestsSteps));
        public WebApiTestsSteps()
        {
            _externalFiles=new ExternalFiles();
            var apiAppConfiguration = new AppConfiguration();
            _url = apiAppConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.ApiUrl);
            _apiActions=new ApiActions();
        }
        [Given(@"Navigate to web api posts\tin ""(.*)"" browser")]
        public void GivenNavigateToWebApiPostsInBrowser(string driverType)
        {
            var browserType = (DriverType)Enum.Parse(typeof(DriverType), driverType);
            _browser= new BrowserBase(browserType);
            _driver= _browser.GetDriver();
            _driver.Navigate().GoToUrl(_url);
            Log.Info("Navigating to "+_url);
            Assert.AreEqual(_driver.Url, "https://jsonplaceholder.typicode.com/posts");
        }


        [When(@"I read data from the page")]
        public async Task WhenIReadDataFromThePage()
        {
            _postListInWebPage =await  _apiActions.GetPosts();
            Log.Info($"There are {_postListInWebPage.Count} posts in the page");

        }
        
        [Then(@"presented data is the same as expected data")]
        public void ThenPresentedDataIsTheSameAsExpectedData()
        {
            var expectedPost = _externalFiles.LoadApiTestData();
            Log.Info($"There are {expectedPost.Count} expected posts");
            Assert.AreEqual(expectedPost.Count, _postListInWebPage.Count);
            foreach (var post in expectedPost)
            {
                var found = _postListInWebPage.Any(p 
                    => 
                p.Id==post.Id && p.UserId==post.UserId && p.Title==post.Title&&p.Body==post.Body
                );
               
                if (found)
                {
                    Log.Info($"Found Post: {post} ");
                }
                else
                {
                    Log.Error($"expected post: {post} was not found in the page");
                }
            }
            _driver.Quit();
        }
    }
}
