using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to switch browser context to child window
    /// </summary>
    internal class SwitchToChildWindow
    {

        internal bool Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var parenthandle = param.Application.ParentWindowHandle;
            var WindowHandles = driver.WindowHandles;
            if (WindowHandles.Count == 1) throw new ContinueRetryException("No child window exists");
            if (WindowHandles.Count > 2) throw new Exception("More than one child window is available");
            string ChildHandle = string.Empty;
            for (int counter = 0; counter < WindowHandles.Count; counter++)
            {
                if (!string.Equals(WindowHandles[counter], parenthandle))
                {
                    ChildHandle = WindowHandles[counter];
                    break;
                }
            }
            driver.SwitchTo().Window(ChildHandle);
            Trace.WriteLine(string.Format("Switched to child window {0}", ChildHandle));
            return true;
        }
    }
}
