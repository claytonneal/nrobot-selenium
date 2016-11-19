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
    internal class CheckElementHasClass
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            var cssClasses = element.GetAttribute("class");
            if (string.IsNullOrEmpty(cssClasses))
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
