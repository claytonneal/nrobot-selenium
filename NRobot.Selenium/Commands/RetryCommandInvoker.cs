using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NRobot.Selenium.Commands
{
    /// <summary>
    /// Class to retry executing command until either:
    /// - Timeout
    /// - An exception is raised that is not in the ignore list
    /// - Command returns non null
    /// </summary>
    internal class RetryCommandInvoker
    {

        // List of ignored exceptions
        private static Type[] ignoredexceptions = 
        { 
            typeof(ElementNotVisibleException),
            typeof(StaleElementReferenceException),
            typeof(InvalidElementStateException),
            typeof(NoSuchElementException),
            typeof(NoSuchWindowException),
            typeof(NotFoundException),
            typeof(UnableToSetCookieException),
            typeof(ContinueRetryException)
         };

        /// <summary>
        /// Creates a DefaultWait to retry the command
        /// </summary>
        /// <typeparam name="TResult">Return type of the command</typeparam>
        /// <param name="command">The command delegate</param>
        /// <param name="param">The command parameters</param>
        /// <param name="retrytimeout">timeout in seconds</param>
        internal static TResult Invoke<TResult>(Func<CommandParams, TResult> command, CommandParams param, int retrytimeout)
        {
            var wait = new DefaultWait<CommandParams>(param);
            wait.PollingInterval = new TimeSpan(0, 0, 0, 1);
            wait.Timeout = new TimeSpan(0, 0, 0, retrytimeout);
            wait.IgnoreExceptionTypes(ignoredexceptions);
            try
            {
                return wait.Until<TResult>(command);
            }
            catch (WebDriverTimeoutException e)
            {
                Trace.WriteLine(string.Format("Timeout performing command : {0}", e.Message));
                throw e;
            }
        }

    }
}
