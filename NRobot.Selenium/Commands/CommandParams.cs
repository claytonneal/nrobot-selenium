using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace NRobot.Selenium.Commands
{
    class CommandParams
    {
        public By Locator { get; set; }
        public string InputData { get; set; }
    }
}
