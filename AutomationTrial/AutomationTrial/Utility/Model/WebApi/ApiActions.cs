using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutomationTrial.Utility.Enums;
using log4net;
using Newtonsoft.Json;

namespace AutomationTrial.Utility.Model.WebApi
{
    /// <summary>
    /// Executs Api Action Methods 
    /// </summary>
    public class ApiActions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ApiActions));
        private readonly Uri _uri;
        private List<Post> _postsList;

        /// <summary>
        /// Constractor Creates instance of AppConfiguration and get WebApi URL
        /// </summary>
        public ApiActions()
        {
            var appConfiguration = new AppConfiguration();
            _uri = new Uri(appConfiguration.GetApplicationConfigurationValue(ConfigurationEnums.ApiUrl));
            Log.Info($"Getting data from uri: {_uri}");
        }

        /// <summary>
        /// Gets Teh posts from API
        /// </summary>
        /// <returns>Collection of Posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            var httpClient = new HttpClient();
            var jsonResponse = await httpClient.GetStringAsync(_uri);
            try
            {
                _postsList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse);
                Log.Info($"Post found in the {_uri}: {_postsList.Count}");
            }
            catch (Exception exception)
            {
                Log.Error($"Could not get posts from {_uri} due to:\r\n {exception}");
            }

            return _postsList;
        }
    }
}
