using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to get the number of open windows the browser has
    /// </summary>
    class GetOpenWindowCount : Command
    {
        public GetOpenWindowCount(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            return driver.WindowHandles.Count;
        }
    }
}
