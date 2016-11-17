using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Commands.Element;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to switch the browser context to specified iframe
    /// </summary>
    class SwitchToFrame : Command
    {
        public SwitchToFrame(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement frame = (IWebElement)locatecommand.Execute(param);
            var driver = _receiver.GetDriver();
            driver.SwitchTo().Frame(frame);
            return true;
        }
    }
}
