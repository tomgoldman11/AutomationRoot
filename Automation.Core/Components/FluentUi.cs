using Automation.Core.Logging;
using OpenQA.Selenium;
using System;

namespace Automation.Core.Components
{
    public class FluentUi : IFluent // no need to create an instance of this class
    {
        public FluentUi(IWebDriver driver) : this(driver, new TraceLogger()) { }  // calls C'tor below

        public FluentUi(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }

        public IWebDriver Driver { get; }
        public ILogger Logger { get; }
        public T ChangeContext<T>()
        {
            var instance = Create<T>(null);
            Logger.Debug($"instance of [{GetType()?.FullName}] created");
            return instance;
        }

        public T ChangeContext<T>(ILogger logger)
        {
            var instance = Create<T>(logger);
            logger.Debug($"instance of [{GetType()?.FullName}] created");
            return instance;
        }


        public T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            var instance = Create<T>(logger);
            logger.Debug($"instance of [{GetType()?.FullName}] created");
            return instance;
        }

        public T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            var instance = Create<T>(null);
            Logger.Debug($"instance of [{GetType()?.FullName}] created");
            return instance;
        }

        private T Create<T>(ILogger logger) // creates a new object
        {
            return logger == null
                ? (T)Activator.CreateInstance(typeof(T), new object[] { Driver })
                : (T)Activator.CreateInstance(typeof(T), new object[] { Driver, logger });
        }
    }
}
