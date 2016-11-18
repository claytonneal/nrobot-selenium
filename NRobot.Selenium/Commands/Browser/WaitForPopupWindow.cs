using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to wait for a new browser window and switch context to it
    /// </summary>
    class WaitForPopupWindow
    {

        public Boolean Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var count = new GetOpenWindowCount();
            var numwindows = Convert.ToInt32(count.Execute(param));
            if (numwindows == 1) throw new ContinueRetryException("No popup window was detected");
            var switchcmd = new SwitchToChildWindow();
            switchcmd.Execute(param);
            return true;
        }
    }
}
