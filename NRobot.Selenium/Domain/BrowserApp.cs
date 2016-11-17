using System;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Drawing;
using System.IO;
using NRobot.Selenium.Commands;

namespace NRobot.Selenium.Domain
{
	/// <summary>
	/// Class representing a browser application
	/// </summary>
	internal class BrowserApp
    {

        #region Properties

        public BrowserStatuses Status {get; protected set; }
        public int CommandTimeout { get; protected set; }
        public String Identifier { get; protected set; }
        public string ParentWindowHandle { get; protected set; }
        protected IWebDriver _driver;
        protected BrowserConfig Config;

        //Get the driver for the browser
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        #endregion

        # region Construct

        //Constructor
        public BrowserApp(BrowserConfig config)
        {
            Status = BrowserStatuses.Closed;
            this.Config = config;
            CommandTimeout = config.commandtimeout;
            OpenBrowser();
            Identifier = BrowserManager.Instance.addBrowserInstance(this);
            Trace.WriteLine(String.Format("Browser opened with ID, {0}", Identifier));
        }

        //opens the browser
        private void OpenBrowser()
        {
            if (String.IsNullOrEmpty(Config.url)) throw new Exception("No url specified to open browser to");
            
            //retry to open browser
            Exception lastexception = null;
            for (int retry = 0; retry < Config.openretrycount; retry++)
            {
                Trace.WriteLine(String.Format("Attempt {0} to open browser", (retry + 1)));
                try
                {
                    _driver = DriverFactory.CreateDriver(Config);
                    _driver.Navigate().GoToUrl(Config.url);
                    Status = BrowserStatuses.Open;
                    break;
                }
                catch (Exception e)
                {
                    lastexception = e;
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Config.openretrydelay));
            }
            if (Status != BrowserStatuses.Open) throw new Exception(String.Format("Unable to open browser after {0} attempts, last exception {1}", Config.openretrycount, lastexception));
            Trace.WriteLine(String.Format("Browser is opened to url {0}", Config.url));

            //retry to resize browser
            bool wasresized = false;
            for (int retry = 0; retry < Config.openretrycount; retry++)
            {
                Trace.WriteLine(String.Format("Attempt {0} to resize browser", (retry + 1)));
                try
                {
                    ResizeBrowser(Config.browsersize);
                    wasresized = true;
                    break;
                }
                catch (Exception e)
                {
                    lastexception = e;
                }
            }
            if (!wasresized)
            {
                Status = BrowserStatuses.Closed;
                _driver.Close();
                _driver.Quit();
                throw new Exception(String.Format("Unable to resize browser after {0} attempts, browser was closed, exception was {1}", Config.openretrycount, lastexception));
            }

            //record window handle
            ParentWindowHandle = _driver.CurrentWindowHandle;
            
            //all worked
            Trace.WriteLine("Browser is opened and resized");

        }

        //Resizes the browser, called after browser is opened
        private void ResizeBrowser(BrowserSize size)
        {
            Trace.WriteLine(String.Format("Resizing browser to dimensions of {0} view", size));
            switch (size)
            {
                case BrowserSize.MOBILE:
                    _driver.Manage().Window.Size = new Size(360, 640);
                    break;
                case BrowserSize.TABLET:
                    _driver.Manage().Window.Size = new Size(1024, 768);
                    break;
                case BrowserSize.DESKTOP:
                    _driver.Manage().Window.Size = new Size(1366, 768);
                    break;
                default:
                    throw new Exception("Unknown browser size");
            }
            _driver.Navigate().GoToUrl(Config.url);
        }

        #endregion

        #region Re-Configure

        //set timeout for browser commands
        internal void SetCommandTimeout(int timeout)
        {
            if (timeout <= 0) throw new Exception("Command Timeout in seconds has to be greater than zero");
            Config.commandtimeout = timeout;
            CommandTimeout = timeout;
            Trace.WriteLine(String.Format("Command timeout set to {0} seconds", timeout));
        }

        //set the timeout for page load
        internal void SetPageLoadTimeout(int timeout)
        {
            if (timeout <= 0) throw new Exception("Page Load Timeout in seconds has to be greater than zero");
            Config.pageloadtimeout = timeout;
            Trace.WriteLine(String.Format("Page load timeout set to {0} seconds", timeout));
            if (Status == BrowserStatuses.Open)
            {
                _driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, timeout));
            }
        }

        //set the timeout for scripts
		internal void SetScriptTimeout(int timeout)
		{
			if (timeout<=0) throw new Exception("Script Timeout in seconds has to be greater than zero");
			Config.scripttimeout = timeout;
			Trace.WriteLine(String.Format("Script timeout set to {0} seconds",timeout));
			if (Status == BrowserStatuses.Open)
			{
				_driver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0,0,timeout));
			}
		}

        #endregion

        #region Close

        //Closes the browser of the WebApp
        internal void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
            BrowserManager.Instance.removeBrowserInstance(Identifier);
            Status = BrowserStatuses.Closed;
            Identifier = String.Empty;
            Trace.WriteLine(String.Format("Browser is closed with ID, {0}", Identifier));
        }

        #endregion 

    }
}
