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
    class WaitUntilElementHasClass
    {

        public Boolean Execute(CommandParams param)
        {
            var command = new CheckElementHasClass();
            var result = command.Execute(param);
            if (!result) throw new ContinueRetryException(String.Format("Element does not have css class {0}", param.InputData));
            return true;
        }
    }
}
