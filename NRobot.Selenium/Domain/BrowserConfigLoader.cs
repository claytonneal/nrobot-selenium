using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class for loading and holding the browser configuration
    /// </summary>
    class BrowserConfigLoader
    {

        private const String configfile = "NRobot.Selenium.Config.yaml";

        //Load the config class
        public static BrowserConfig getConfig()
        {
            var input = new StreamReader(configfile);
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            return deserializer.Deserialize<BrowserConfig>(input);
        }
    }
}
