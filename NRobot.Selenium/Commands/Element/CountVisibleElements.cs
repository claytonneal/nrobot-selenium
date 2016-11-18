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
    /// Command to count the number of matching visible elements
    /// </summary>
    class CountVisibleElements
    {

        public String Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            IList<IWebElement> elements = driver.FindElements(param.Locator);
            if (elements == null) return "0";
            Int32 count = 0;
            foreach (IWebElement element in elements)
            {
                if (element.Displayed) count++;
            }
            return count.ToString();
        }
    }
}
