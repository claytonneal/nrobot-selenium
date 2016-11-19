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
    internal class WaitForNoPopupWindow
    {

        internal bool Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var count = new GetOpenWindowCount();
            var numwindows = Convert.ToInt32(count.Execute(param));
            if (numwindows > 1) throw new ContinueRetryException("Popup window is still open");
            var switchcmd = new SwitchToParentWindow();
            switchcmd.Execute(param);
            return true;
        }
    }
}
