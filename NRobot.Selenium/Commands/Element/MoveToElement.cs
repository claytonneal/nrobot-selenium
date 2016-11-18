using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to move focus to an element
    /// </summary>
    class MoveToElement
    {

        public Boolean Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            Actions action = new Actions(driver);
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            action.MoveToElement(element);
            return true;
        }
    }
}
