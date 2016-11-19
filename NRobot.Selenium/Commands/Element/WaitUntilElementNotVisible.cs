using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    internal class WaitUntilElementNotVisible
    {

        internal bool Execute(CommandParams param)
        {
            try
            {
                var locatecommand = new GetVisibleElement();
                IWebElement element = locatecommand.Execute(param);
                if (element.Displayed) throw new ContinueRetryException("Element is currently displayed");
                return true;
            }
            catch (ElementNotVisibleException)
            {
                //swallow - if not found then consider it not visible
                //loop if different exception
                return true;
            }
        }
    }
}
