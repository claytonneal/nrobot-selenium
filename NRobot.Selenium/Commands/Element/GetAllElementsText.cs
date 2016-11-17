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
    /// Command to get text from all matching elements
    /// </summary>
    class GetAllElementsText : Command
    {
        public GetAllElementsText(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            var elements = driver.FindElements(param.Locator);
            List<string> result = new List<string>();
            foreach (IWebElement element in elements)
            {
                if (element.Displayed) result.Add(element.Text);
            }
            if (result.Count == 0) throw new Exception("No elements found matching selector");
            return result.ToArray();
        }
    }
}
