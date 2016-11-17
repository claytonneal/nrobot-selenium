using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands
{
    abstract class Command
    {

        protected BrowserApp _receiver;

        public Command(BrowserApp receiver)
        {
            _receiver = receiver;
        }

        public abstract Object Execute(CommandParams param);

    }
}
