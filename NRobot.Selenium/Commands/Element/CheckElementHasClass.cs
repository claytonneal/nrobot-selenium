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
    /// Command to check if element has specified css class
    /// </summary>
    class CheckElementHasClass : Command
    {
        public CheckElementHasClass(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            var cssClasses = element.GetAttribute("class");
            if (String.IsNullOrEmpty(cssClasses))
            {
                return false;
            }
            else
            {
                return cssClasses.Contains(param.InputData);
            }
        }
    }
}
