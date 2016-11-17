using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command that waits until element has specified css class
    /// </summary>
    class WaitUntilElementHasClass : Command
    {
        public WaitUntilElementHasClass(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var command = new CheckElementHasClass(_receiver);
            var result = (Boolean)command.Execute(param);
            if (!result) throw new Exception(String.Format("Element does not have css class {0}", param.InputData));
            return true;
        }
    }
}
