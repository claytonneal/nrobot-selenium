using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to hover over an element
    /// </summary>
    internal class HoverOverElement
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            var driver = param.Application.GetDriver();
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
            return true;
        }
    }
}
