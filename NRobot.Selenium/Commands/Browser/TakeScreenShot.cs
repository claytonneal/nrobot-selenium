using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Browser
{
    /// <summary>
    /// Command to take a screenshot from the browser
    /// </summary>
    class TakeScreenShot
    {

        public Boolean Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var filename = param.InputData;
            if (!filename.ToLower().Contains(".jpg"))
            {
                filename = filename + ".jpg";
            }
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            Screenshot shot = ((ITakesScreenshot)driver).GetScreenshot();
            shot.SaveAsFile(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            return true;
        }

    }
}
