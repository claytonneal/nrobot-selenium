using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    class WaitUntilElementNotVisible : Command
    {
        public WaitUntilElementNotVisible(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            try
            {
                var locatecommand = new GetVisibleElement(this._receiver);
                IWebElement element = (IWebElement)locatecommand.Execute(param);
                if (element.Displayed) throw new Exception("Element is currently displayed");
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
