using System;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class to hold configuration from the NRobot.Selenium.Config.yaml file
    /// </summary>
    internal class BrowserConfig
    {
        internal string Huburl { get; set; }
        internal BrowserNames Browsername { get; set; }
        internal BrowserSize Browsersize { get; set; }
        internal BrowserLocations Browserlocation { get; set; }
        internal int Commandtimeout { get; set; }
        internal int Pageloadtimeout { get; set; }
        internal int Scripttimeout { get; set; }
        internal int Openretrycount { get; set; }
        internal int Openretrydelay { get; set; }
        internal string Url { get; set; }

    }
}
