using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to click on element matching locator and text value
    /// </summary>
    class ClickElementWithTextValue : Command
    {
        public ClickElementWithTextValue(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElementWithText(_receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            element.Click();
            return true;
        }

    }
}
