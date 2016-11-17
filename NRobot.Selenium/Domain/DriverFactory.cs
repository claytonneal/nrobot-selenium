using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace NRobot.Selenium.Domain
{
	/// <summary>
	/// Class to create a IWebDriver object with correct settings
	/// </summary>
	internal class DriverFactory
	{
		
        //Creates an instance of a webdriver
        internal static IWebDriver CreateDriver(BrowserConfig config)
		{
            //create local or remote
            IWebDriver result = null;
            switch (config.browserlocation)
			{
                case BrowserLocations.Local:
                    result = CreateLocalDriver(config);
                    break;
                case BrowserLocations.Remote:
                    result = CreateRemoteDriver(config);
                    break;
				default:
					throw new Exception("Unsupported browser location");
			}
            //set common settings
            //timeouts
            result.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, config.pageloadtimeout));
            result.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, config.pageloadtimeout));
            result.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(500));
            return result;
		}

        //Creates a local webdriver
        private static IWebDriver CreateLocalDriver(BrowserConfig config)
        {
            switch (config.browsername)
            {
                case BrowserNames.Firefox:
                    return new FirefoxDriver();
                case BrowserNames.Chrome:
                    return new ChromeDriver();
                case BrowserNames.IE11:
                    return new InternetExplorerDriver(GetLocalIeOptions());
                case BrowserNames.Edge:
                    return new EdgeDriver();
                default:
                    throw new Exception("Unsupported browser type");
            }
        }

        //Creates a remote webdriver
        private static IWebDriver CreateRemoteDriver(BrowserConfig config)
        {
            Uri huburl = new Uri(config.huburl);
            switch (config.browsername)
            {
                case BrowserNames.Firefox:
                    return new RemoteWebDriver(huburl, DesiredCapabilities.Firefox());
                case BrowserNames.Chrome:
                    return new RemoteWebDriver(huburl, DesiredCapabilities.Chrome());
                case BrowserNames.IE11:
                    return new RemoteWebDriver(huburl, GetRemoteIe11Capabilities());
                case BrowserNames.Edge:
                    return new RemoteWebDriver(huburl, DesiredCapabilities.Edge());
                default:
                    throw new Exception("Unsupported browser type");
            }
        }

        //Gets capabilities needed for IE11 in selenium grid
	    private static ICapabilities GetRemoteIe11Capabilities()
	    {
	        var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserName", "internet explorer");
            capabilities.SetCapability("version", "11");
            capabilities.SetCapability("ie.ensureCleanSession", true);
            capabilities.SetCapability("ignoreProtectedModeSettings", true);
	        return capabilities;
	    }

        //Gets options when running IE11 locally
	    private static InternetExplorerOptions GetLocalIeOptions()
	    {
	        var options = new InternetExplorerOptions {EnsureCleanSession = true, IntroduceInstabilityByIgnoringProtectedModeSettings = true};
	        return options;
	    }


	}
}
