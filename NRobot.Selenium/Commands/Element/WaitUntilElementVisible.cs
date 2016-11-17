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
    class WaitUntilElementVisible : Command
    {
        public WaitUntilElementVisible(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            if (!element.Displayed) throw new Exception("Element is not visible");
            return true;
        }
    }
}
