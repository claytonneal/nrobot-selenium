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
    /// Command to wait until the element has a text value
    /// </summary>
    class WaitUntilElementHasText : Command
    {
        public WaitUntilElementHasText(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            String textvalue = element.Text;
            if (String.IsNullOrEmpty(textvalue))
            {
                throw new Exception("Element has no text value");
            }
            textvalue = textvalue.Trim();
            if (String.IsNullOrEmpty(textvalue))
            {
                throw new Exception("Element has no text value");
            }
            return textvalue;
        }
    }
}
