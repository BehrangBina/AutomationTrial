using System;
using System.Configuration;
using AutomationTrial.Utility.Enums;
using AutomationTrial.Utility.Facade;
using log4net;
using log4net.Config;

namespace AutomationTrial.Utility.Model
{
    /// <summary>
    ///     Gets Configuration Values By Enum
    /// </summary>
    public class AppConfiguration : IConfiguration
    {
        /// <summary>
        ///     Enabling Log4Net  Instance
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(AppConfiguration));

        /// <summary>
        ///     Constractor
        ///     1- Set Configuration Values
        /// </summary>
        public AppConfiguration()
        {
          
            XmlConfigurator.Configure();
        }

        /// <summary>
        ///     Gets a configuration values from dictionary of configurations
        /// </summary>
        /// <param name="configurationEnums">Configuration Name Key</param>
        /// <returns>String configuration value based on provided key</returns>
        public string GetApplicationConfigurationValue(ConfigurationEnums configurationEnums)
        {
            string configuraltionVal = null;
            try
            {
                var enumValue = configurationEnums.ToString();
                configuraltionVal = ConfigurationManager.AppSettings[enumValue];
                Log.Info($"| Enum: {configurationEnums} | Key: {configurationEnums} | value: {configuraltionVal}|");
                return configuraltionVal;
            }
            catch (Exception exception)
            {
                Log.Error(
                    $"Not found in app.config {nameof(configuraltionVal)}| Enum: {configuraltionVal} | Key: {configurationEnums} | value: {configuraltionVal}|\r\nException: {exception}");
            }

            return configuraltionVal;
        }
    }
}
