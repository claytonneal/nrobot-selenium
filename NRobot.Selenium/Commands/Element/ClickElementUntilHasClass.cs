using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    class ClickElementUntilHasClass : Command
    {
        public ClickElementUntilHasClass(BrowserApp receiver) : base(receiver) { }

        public override object Execute(CommandParams param)
        {
            var click = new ClickElement(_receiver);
            click.Execute(param);
            var checkclass = new CheckElementHasClass(_receiver);
            var result = (Boolean)checkclass.Execute(param);
            if (!result) throw new Exception(String.Format("Element does not have css class {0}", param.InputData));
            return true;
        }
    }
}
