using System;

namespace NRobot.Selenium.Commands
{
    internal class ExitRetryException : Exception
    {

        internal ExitRetryException() { }
        internal ExitRetryException(string message) : base(message) { }
        internal ExitRetryException(string message, Exception inner) : base(message, inner) { }

    }
}
