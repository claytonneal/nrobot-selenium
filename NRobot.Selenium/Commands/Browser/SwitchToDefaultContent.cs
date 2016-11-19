using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to switch browser context back to its default content
    /// </summary>
    internal class SwitchToDefaultContent
    {

        internal bool Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            driver.SwitchTo().DefaultContent();
            return true;
        }
    }
}
