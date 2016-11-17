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
    /// Command to get the text of an element
    /// </summary>
    class GetElementText : Command
    {
        public GetElementText(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            var text = element.Text;
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }
            return text.Trim();
        }
    }
}
