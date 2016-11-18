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
    class GetElementText
    {

        public String Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            var text = element.Text;
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }
            return text.Trim();
        }
    }
}
