using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;
using OpenQA.Selenium;

namespace NRobot.Selenium.Commands
{
    class CommandParams
    {
        public BrowserApp Application { get; set; }
        public By Locator { get; set; }
        public string InputData { get; set; }
    }
}
