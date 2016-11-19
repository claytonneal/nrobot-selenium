using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRobot.Selenium.Commands
{
    internal class ContinueRetryException : Exception
    {
        internal ContinueRetryException() { }
        internal ContinueRetryException(string message) : base(message) { }
        internal ContinueRetryException(string message, Exception inner) : base(message, inner) { }
    }
}
