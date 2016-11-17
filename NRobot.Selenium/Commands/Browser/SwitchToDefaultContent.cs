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
    class SwitchToDefaultContent : Command
    {
        public SwitchToDefaultContent(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            driver.SwitchTo().DefaultContent();
            return true;
        }
    }
}
