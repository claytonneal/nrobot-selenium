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
    /// Command to send keys to an element only if its empty
    /// </summary>
    class SendKeysToEmptyElement
    {

        public Boolean Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            string text = element.Text;
            if (!String.IsNullOrEmpty(text))
            {
                element.SendKeys(param.InputData);
            }
            return true;
        }
    }
}
