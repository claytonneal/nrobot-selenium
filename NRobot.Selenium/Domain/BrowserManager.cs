using System;
using System.Collections.Concurrent;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class for managing all WebApp instances
    /// </summary>
    internal class BrowserManager
    {
        // singleton
        private static volatile BrowserManager instance;
        private static object syncRoot = new object();

        // instance properties
        private ConcurrentDictionary<string, BrowserApp> BrowserInstances;

        // default constructor
        private BrowserManager() 
        {
            this.BrowserInstances = new ConcurrentDictionary<string, BrowserApp>();
        }

        // gets or creates the singleton instance
        public static BrowserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BrowserManager();
                        }
                    }
                }

                return instance;
            }
        }

        //Gets a WebApp instance with specified identifier
        internal BrowserApp GetBrowserInstance(string identifier)
        {
            if (!this.BrowserInstances.Keys.Contains(identifier)) throw new Exception(string.Format("No browser with identifier {0} was found"));
            return this.BrowserInstances[identifier];
        }

        //Adds a browser instance
        internal string AddBrowserInstance(BrowserApp instance)
        {
            lock (syncRoot)
            {
                Guid guid = Guid.NewGuid();
                var key = guid.ToString();
                this.BrowserInstances[key] = instance;
                return key;
            }
        }

        internal void RemoveBrowserInstance(string key)
        {
            lock (syncRoot)
            {
                BrowserApp browser;
                this.BrowserInstances.TryRemove(key, out browser);
            }
        }

    }
}
