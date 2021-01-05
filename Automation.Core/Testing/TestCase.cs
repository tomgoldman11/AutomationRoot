using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        //Fields
        
        private IDictionary<string, object> testParams;
        private int attempts;
        private ILogger logger;

        protected TestCase() //C'tor
        {
            testParams = new Dictionary<string, object>();
            attempts = 1;
            logger = new TraceLogger();
        }

        //Components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);
        public TestCase Execute()
        {
            for (int i = 0; i < attempts; i++)
            {
                Driver = Get();
                try
                {
                    Actual = AutomationTest(testParams);
                    if(Actual)
                    {
                        break;
                    }
                    logger.Debug($"[{GetType()?.FullName}] failed on attempt [{i + 1 }]");
                }
                catch(AssertInconclusiveException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (NotImplementedException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                finally
                {
                    Driver?.Close();  // ?. Operator: accessing Driver only if its not NULL
                    Driver?.Dispose();
                }
            }
            return this;
        }

        //Properties
        public bool Actual { get; private set; }

        public IWebDriver Driver { get; private set; }

        //Configurations
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            this.testParams = testParams;
            return this;
        }
        public TestCase WithNumberOfAttempts(int numberOfAttempts)
        {
            attempts = numberOfAttempts;
            return this;
        }
        public TestCase WithLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }

        //Setup
        private IWebDriver Get()
        {
            //Default
            var driverParams = new DriverParams { Binaries = ".", Driver = "CHROME" };

            //Change Driver if exists
            if(testParams.ContainsKey("driver") == true)
            {
                driverParams.Driver = $"{testParams["driver"]}";
            }

            //Create Driver
            return new WebDriverFactory(driverParams).Get();
        }

    }
}
 