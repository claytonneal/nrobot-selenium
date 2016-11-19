using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class for loading and holding the browser configuration
    /// </summary>
    internal class BrowserConfigLoader
    {

        private const string Configfile = "NRobot.Selenium.Config.yaml";

        //Load the config class
        internal static BrowserConfig GetConfig()
        {
            var input = new StreamReader(Configfile);
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            return deserializer.Deserialize<BrowserConfig>(input);
        }
    }
}
