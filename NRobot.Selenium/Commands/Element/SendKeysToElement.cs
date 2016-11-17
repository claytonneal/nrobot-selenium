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
    /// Command to send keys to an element
    /// </summary>
    class SendKeysToElement : Command
    {
        public SendKeysToElement(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            element.Click();    //For IE
            element.Clear();
            element.SendKeys(param.InputData);
            element.SendKeys(Keys.Tab);     //For IE
            return true;
        }
    }
}
