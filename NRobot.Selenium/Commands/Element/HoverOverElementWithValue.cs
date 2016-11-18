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
    /// Hovers over an element that is found by the locator, and has matching text value
    /// </summary>
    class HoverOverElementWithValue
    {

        public Boolean Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElementWithText();
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            var driver = param.Application.GetDriver();
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
            return true;
        }
    }
}
