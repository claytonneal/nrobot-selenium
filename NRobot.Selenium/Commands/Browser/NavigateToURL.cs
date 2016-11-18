using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to navigate to a specified url
    /// </summary>
    class NavigateToURL
    {

        public Boolean Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            driver.Navigate().GoToUrl(param.InputData);
            return true;
        }

    }
}
