using AutomationTrial.Utility.Enums;

namespace AutomationTrial.Utility.Facade
{
    /// <summary>
    /// Interface IConfiguration Facilitating configuration Actions
    /// </summary>
    internal interface IConfiguration
    {
        string GetApplicationConfigurationValue(ConfigurationEnums configurationEnums);
    }
}
