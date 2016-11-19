using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using OpenQA.Selenium;
using NRobot.Selenium.Commands;

namespace NRobot.Selenium.Domain
{
	/// <summary>
	/// Class representing a browser application
	/// </summary>
	internal class BrowserApp
    {

        private IWebDriver Driver;
        private BrowserConfig Config;

        //Constructor
        internal BrowserApp(BrowserConfig config)
        {
            this.Status = BrowserStatuses.Closed;
            this.Config = config;
            this.CommandTimeout = config.Commandtimeout;
            this.OpenBrowser();
            this.Identifier = BrowserManager.Instance.AddBrowserInstance(this);
            Trace.WriteLine(string.Format("Browser opened with ID, {0}", this.Identifier));
        }

        internal BrowserStatuses Status { get; private set; }
        internal int CommandTimeout { get; private set; }
        internal string Identifier { get; private set; }
        internal string ParentWindowHandle { get; private set; }

        //Get the driver for the browser
        internal IWebDriver GetDriver()
        {
            return this.Driver;
        }

        //set timeout for browser commands
        internal void SetCommandTimeout(int timeout)
        {
            if (timeout <= 0) throw new Exception("Command Timeout in seconds has to be greater than zero");
            this.Config.Commandtimeout = timeout;
            this.CommandTimeout = timeout;
            Trace.WriteLine(string.Format("Command timeout set to {0} seconds", timeout));
        }

        //set the timeout for page load
        internal void SetPageLoadTimeout(int timeout)
        {
            if (timeout <= 0) throw new Exception("Page Load Timeout in seconds has to be greater than zero");
            this.Config.Pageloadtimeout = timeout;
            Trace.WriteLine(string.Format("Page load timeout set to {0} seconds", timeout));
            if (this.Status == BrowserStatuses.Open)
            {
                this.Driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, timeout));
            }
        }

        //set the timeout for scripts
        internal void SetScriptTimeout(int timeout)
        {
            if (timeout <= 0) throw new Exception("Script Timeout in seconds has to be greater than zero");
            this.Config.Scripttimeout = timeout;
            Trace.WriteLine(string.Format("Script timeout set to {0} seconds", timeout));
            if (this.Status == BrowserStatuses.Open)
            {
                this.Driver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, timeout));
            }
        }

        //Closes the browser of the WebApp
        internal void CloseBrowser()
        {
            this.Driver.Close();
            this.Driver.Quit();
            BrowserManager.Instance.RemoveBrowserInstance(this.Identifier);
            this.Status = BrowserStatuses.Closed;
            this.Identifier = string.Empty;
            Trace.WriteLine(string.Format("Browser is closed with ID, {0}", this.Identifier));
        }

        //opens the browser
        private void OpenBrowser()
        {
            if (string.IsNullOrEmpty(this.Config.Url)) throw new Exception("No url specified to open browser to");
            
            //retry to open browser
            Exception lastexception = null;
            for (int retry = 0; retry < this.Config.Openretrycount; retry++)
            {
                Trace.WriteLine(string.Format("Attempt {0} to open browser", retry + 1));
                try
                {
                    this.Driver = DriverFactory.CreateDriver(this.Config);
                    this.Driver.Navigate().GoToUrl(this.Config.Url);
                    this.Status = BrowserStatuses.Open;
                    break;
                }
                catch (Exception e)
                {
                    lastexception = e;
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(this.Config.Openretrydelay));
            }
            if (this.Status != BrowserStatuses.Open) throw new Exception(string.Format("Unable to open browser after {0} attempts, last exception {1}", this.Config.Openretrycount, lastexception));
            Trace.WriteLine(string.Format("Browser is opened to url {0}", this.Config.Url));

            //retry to resize browser
            bool wasresized = false;
            for (int retry = 0; retry < this.Config.Openretrycount; retry++)
            {
                Trace.WriteLine(string.Format("Attempt {0} to resize browser", retry + 1));
                try
                {
                    this.ResizeBrowser(this.Config.Browsersize);
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
                this.Status = BrowserStatuses.Closed;
                this.Driver.Close();
                this.Driver.Quit();
                throw new Exception(string.Format("Unable to resize browser after {0} attempts, browser was closed, exception was {1}", this.Config.Openretrycount, lastexception));
            }

            //record window handle
            this.ParentWindowHandle = this.Driver.CurrentWindowHandle;
            
            //all worked
            Trace.WriteLine("Browser is opened and resized");

        }

        //Resizes the browser, called after browser is opened
        private void ResizeBrowser(BrowserSize size)
        {
            Trace.WriteLine(string.Format("Resizing browser to dimensions of {0} view", size));
            switch (size)
            {
                case BrowserSize.MOBILE:
                    this.Driver.Manage().Window.Size = new Size(360, 640);
                    break;
                case BrowserSize.TABLET:
                    this.Driver.Manage().Window.Size = new Size(1024, 768);
                    break;
                case BrowserSize.DESKTOP:
                    this.Driver.Manage().Window.Size = new Size(1366, 768);
                    break;
                default:
                    throw new Exception("Unknown browser size");
            }
            this.Driver.Navigate().GoToUrl(this.Config.Url);
        }

    }
}
