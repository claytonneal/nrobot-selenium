using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRobot.Selenium.Commands
{
    /// <summary>
    /// Class to execute a Command using a retry pattern
    /// Will re-execute the command until either:
    /// - Command returns not Null
    /// - Command returns True
    /// - No more execptions from Command
    /// </summary>
    class RetryCommandInvoker<T>
    {
        protected Command _command;
        protected CommandParams _param;
        protected int _retrytimeout;

        public RetryCommandInvoker(Command command, CommandParams param, int retrytimeout)
        {
            _command = command;
            _param = param;
            _retrytimeout = retrytimeout;
        }

        public T Invoke()
        {
            T result = default(T);
            DateTime startTime = DateTime.Now;
            bool wasexception = false;
            string lastexceptionmessage = String.Empty;
            while (true)
            {
                TimeSpan duration = (DateTime.Now - startTime);
                if (duration.Seconds >= _retrytimeout) throw new Exception(String.Format("Timeout executing command, last exception {0}", lastexceptionmessage));
                try
                {
                    var objresult = _command.Execute(_param);
                    break;
                }
                catch (ExitRetryException exitexception)
                {
                    wasexception = true;
                    lastexceptionmessage = exitexception.Message;
                    break;
                }
                catch (Exception e)
                {
                    lastexceptionmessage = e.Message;
                }
            }
            if (wasexception) throw new Exception(String.Format("Command terminated retry pattern with exception: {0}", lastexceptionmessage));
            return result;
        }

    }
}
