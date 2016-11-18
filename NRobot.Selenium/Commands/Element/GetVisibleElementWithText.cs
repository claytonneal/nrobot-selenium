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
    /// Command to find first visible element from locator, also with matching text value
    /// </summary>
    class GetVisibleElementWithText
    {

        public IWebElement Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var elements = driver.FindElements(param.Locator);
            foreach (IWebElement element in elements)
            {
                if (element.Displayed)
                {
                    var elementText = element.Text;
                    if (!String.IsNullOrEmpty(elementText))
                    {
                        if (String.Equals(elementText, param.InputData)) return element;
                    }
                }
            }
            throw new ElementNotVisibleException(String.Format("No visible elements matching selector with text value", param.InputData));
        }
    }
}
