using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRobot.Selenium.Commands
{
    class ContinueRetryException : Exception
    {
        public ContinueRetryException() { }
        public ContinueRetryException(string message) : base(message) { }
        public ContinueRetryException(string message, Exception inner) : base(message, inner) { }
    }
}
