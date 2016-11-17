using System;
using System.Collections.Concurrent;

namespace NRobot.Selenium.Domain
{
    /// <summary>
    /// Class for managing all WebApp instances
    /// </summary>
    internal class BrowserManager
    {
        //singleton
        private static volatile BrowserManager instance;
        private static object syncRoot = new Object();

        //instance properties
        private ConcurrentDictionary<string, BrowserApp> BrowserInstances;

        //default constructor
        private BrowserManager() 
        {
            BrowserInstances = new ConcurrentDictionary<string, BrowserApp>();
        }

        //gets or creates the singleton instance
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
        internal BrowserApp getBrowserInstance(String identifier)
        {
            if (!BrowserInstances.Keys.Contains(identifier)) throw new Exception(String.Format("No browser with identifier {0} was found"));
            return BrowserInstances[identifier];
        }

        //Adds a browser instance
        internal string addBrowserInstance(BrowserApp instance)
        {
            lock(syncRoot)
            {
                Guid guid = Guid.NewGuid();
                var key = guid.ToString();
                BrowserInstances[key] = instance;
                return key;
            }
        }

        internal void removeBrowserInstance(String key)
        {
            lock(syncRoot)
            {
                BrowserApp browser;
                BrowserInstances.TryRemove(key, out browser);
            }
        }

    }
}
