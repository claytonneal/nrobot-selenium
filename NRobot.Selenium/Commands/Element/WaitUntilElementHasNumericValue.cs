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
    /// Command to wait until the elements text value matches numeric value supplied
    /// </summary>
    class WaitUntilElementHasNumericValue : Command
    {
        public WaitUntilElementHasNumericValue(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement(this._receiver);
            IWebElement element = (IWebElement)locatecommand.Execute(param);
            Double expected = Double.Parse(param.InputData);
            String textvalue = element.Text;
            Double value = Helpers.Keywords.ExtractNumberFromString(textvalue);
            if (value != expected) throw new Exception(String.Format("Numeric value not as expected, actual value is {0}",textvalue));
            return true;
        }
    }
}
