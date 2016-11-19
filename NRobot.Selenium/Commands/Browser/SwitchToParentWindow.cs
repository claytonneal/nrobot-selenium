using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to switch the browser context back to its parent window
    /// </summary>
    internal class SwitchToParentWindow
    {

        internal bool Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var parenthandle = param.Application.ParentWindowHandle;
            driver.SwitchTo().Window(parenthandle);
            Trace.WriteLine(string.Format("Switched to parent window {0}", parenthandle));
            return true;
        }

    }
}
