using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command that clicks on one element until another element becomes visible
    /// </summary>
    class ClickElementUntilAnotherElementDisplayed
    {

        public Boolean Execute(CommandParams param)
        {
            var click = new ClickElement();
            click.Execute(param);
            var locatecommand = new GetVisibleElement();
            var element = locatecommand.Execute(new CommandParams() { Application = param.Application, Locator = By.CssSelector(param.InputData) });
            return true;
        }
    }
}
