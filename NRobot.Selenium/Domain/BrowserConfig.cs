using System;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class to hold configuration from the NRobot.Selenium.Config.yaml file
    /// </summary>
    class BrowserConfig
    {
        public string huburl { get; set; }
        public BrowserNames browsername { get; set; }
        public BrowserSize browsersize { get; set; }
        public BrowserLocations browserlocation { get; set; }
        public int commandtimeout { get; set; }
        public int pageloadtimeout { get; set; }
        public int scripttimeout { get; set; }
        public int openretrycount { get; set; }
        public int openretrydelay { get; set; }
        public string url { get; set; }

    }
}
