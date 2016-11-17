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
    class HoverOverElement : Command
    {
        public HoverOverElement(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            var driver = _receiver.GetDriver();
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
            return true;
        }
    }
}
