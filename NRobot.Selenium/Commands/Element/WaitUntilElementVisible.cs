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
    /// Command to wait until an element is visible
    /// </summary>
    internal class WaitUntilElementVisible
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            if (!element.Displayed) throw new ContinueRetryException("Element is not visible");
            return true;
        }
    }
}
