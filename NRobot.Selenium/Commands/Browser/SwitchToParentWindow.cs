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
    class SwitchToParentWindow : Command
    {
        public SwitchToParentWindow(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            var parenthandle = _receiver.ParentWindowHandle;
            driver.SwitchTo().Window(parenthandle);
            Trace.WriteLine(String.Format("Switched to parent window {0}", parenthandle));
            return true;
        }
    }
}
