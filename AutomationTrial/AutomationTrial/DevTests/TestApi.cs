using System;
using System.Threading.Tasks;
using AutomationTrial.Utility.Model.WebApi;
using NUnit.Framework;

namespace AutomationTrial.DevTests
{
    /// <summary>
    /// Test The Web Api Functions
    /// </summary>
    [TestFixture]
    public class TestApi
    {
        /// <summary>
        /// Gets The Posts from Api 
        /// Tests won't run if there is any exception
        /// </summary>
        /// <returns>Task</returns>
        [TestCase]
        public async Task CanGetValueFromUrl()
        {
            var apiActions = new ApiActions();
            var result = await apiActions.GetPosts();
            Assert.That(result.Count > 0);
            foreach (var post in result) Console.WriteLine(post);
        }
    }
}
