using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to click on an element
    /// </summary>
    internal class ClickElement
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            element.Click();
            return true;
        }

    }
}
