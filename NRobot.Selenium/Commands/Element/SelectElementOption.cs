using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to select a drop down list item
    /// </summary>
    class SelectElementOption : Command
    {
        public SelectElementOption(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            SelectElement select = new SelectElement(element);
            select.SelectByText(param.InputData);
            return true;
        }
    }
}
