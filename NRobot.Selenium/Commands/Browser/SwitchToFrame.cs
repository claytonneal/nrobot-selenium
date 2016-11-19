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
    internal class SwitchToFrame
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement frame = (IWebElement)locatecommand.Execute(param);
            var driver = param.Application.GetDriver();
            driver.SwitchTo().Frame(frame);
            return true;
        }
    }
}
