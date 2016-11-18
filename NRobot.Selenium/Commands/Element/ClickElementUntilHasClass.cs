using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    class ClickElementUntilHasClass
    {

        public Boolean Execute(CommandParams param)
        {
            var click = new ClickElement();
            click.Execute(param);
            var checkclass = new CheckElementHasClass();
            Boolean result = checkclass.Execute(param);
            if (!result) throw new ContinueRetryException(String.Format("Element does not have css class {0}", param.InputData));
            return true;
        }
    }
}
