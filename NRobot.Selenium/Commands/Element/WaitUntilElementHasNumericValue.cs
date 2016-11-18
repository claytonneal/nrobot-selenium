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
    class WaitUntilElementHasNumericValue
    {

        public Boolean Execute(CommandParams param)
        {
            var locatecommand = new GetVisibleElement();
            IWebElement element = locatecommand.Execute(param);
            Double expected = Double.Parse(param.InputData);
            String textvalue = element.Text;
            Double value = Helpers.Keywords.ExtractNumberFromString(textvalue);
            if (value != expected) throw new ContinueRetryException(String.Format("Numeric value not as expected, actual value is {0}",textvalue));
            return true;
        }

    }
}
