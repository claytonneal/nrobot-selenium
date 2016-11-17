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
    class ClickElementUntilAnotherElementDisplayed : Command
    {
        public ClickElementUntilAnotherElementDisplayed(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var click = new ClickElement(_receiver);
            click.Execute(param);
            var locatecommand = new GetVisibleElement(this._receiver);
            var element = locatecommand.Execute(new CommandParams() { Locator = By.CssSelector(param.InputData) });
            return true;
        }
    }
}
