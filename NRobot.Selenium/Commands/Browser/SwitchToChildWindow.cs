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
    class SwitchToChildWindow : Command
    {
        public SwitchToChildWindow(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            var parenthandle = _receiver.ParentWindowHandle;
            var WindowHandles = driver.WindowHandles;
            if (WindowHandles.Count == 1) throw new Exception("No child window exists");
            if (WindowHandles.Count > 2) throw new Exception("More than one child window is available");
            string ChildHandle = String.Empty;
            for (int counter = 0; counter < WindowHandles.Count; counter++)
            {
                if (!String.Equals(WindowHandles[counter], parenthandle))
                {
                    ChildHandle = WindowHandles[counter];
                    break;
                }
            }
            driver.SwitchTo().Window(ChildHandle);
            Trace.WriteLine(String.Format("Switched to child window {0}", ChildHandle));
            return true;
        }
    }
}
