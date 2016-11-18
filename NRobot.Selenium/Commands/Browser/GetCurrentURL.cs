using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to get the current browser url
    /// </summary>
    class GetCurrentURL
    {

        public String Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            return driver.Url;
        }

    }
}
