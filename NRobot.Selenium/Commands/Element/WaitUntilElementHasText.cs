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
    internal class WaitUntilElementHasText
    {

        internal string Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            string textvalue = element.Text;
            if (string.IsNullOrEmpty(textvalue))
            {
                throw new ContinueRetryException("Element has no text value");
            }
            textvalue = textvalue.Trim();
            if (string.IsNullOrEmpty(textvalue))
            {
                throw new ContinueRetryException("Element has no text value");
            }
            return textvalue;
        }
    }
}
