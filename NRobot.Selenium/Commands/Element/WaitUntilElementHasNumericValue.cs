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
    internal class WaitUntilElementHasNumericValue
    {

        internal bool Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            double expected = double.Parse(param.InputData);
            string textvalue = element.Text;
            double value = Helpers.Keywords.ExtractNumberFromString(textvalue);
            if (value != expected) throw new ContinueRetryException(string.Format("Numeric value not as expected, actual value is {0}", textvalue));
            return true;
        }

    }
}
