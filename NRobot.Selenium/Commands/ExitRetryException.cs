using System;

namespace NRobot.Selenium.Commands
{
    class ExitRetryException : Exception
    {

        public ExitRetryException() { }
        public ExitRetryException(string message) : base(message) { }
        public ExitRetryException(string message, Exception inner)  : base(message, inner) { }

    }
}
