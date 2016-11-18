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
    class ClickElement
    {

        public Boolean Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            element.Click();
            return true;
        }

    }
}
