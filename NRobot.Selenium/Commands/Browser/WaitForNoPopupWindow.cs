using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to wait for popup window to close, and switch context back to parent window
    /// </summary>
    class WaitForNoPopupWindow : Command
    {
        public WaitForNoPopupWindow(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var driver = _receiver.GetDriver();
            var timeout = _receiver.CommandTimeout;
            var count = new GetOpenWindowCount(_receiver);
            var numwindows = (Int32)count.Execute(null);
            if (numwindows > 1) throw new Exception("Popup window is still open");
            var switchcmd = new SwitchToParentWindow(_receiver);
            switchcmd.Execute(null);
            return true;
        }
    }
}
