using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    internal class ClickElementUntilHasClass
    {

        internal bool Execute(CommandParams param)
        {
            var click = new ClickElement();
            click.Execute(param);
            var checkclass = new CheckElementHasClass();
            bool result = checkclass.Execute(param);
            if (!result) throw new ContinueRetryException(string.Format("Element does not have css class {0}", param.InputData));
            return true;
        }
    }
}
