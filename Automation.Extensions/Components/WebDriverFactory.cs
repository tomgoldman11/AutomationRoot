using Automation.Extensions.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Extensions.Components
{
    public class WebDriverFactory
    {
        private readonly DriverParams driverParams;
        //public WebDriverFactory(string driverParamsJson)  ----- This is an option but not the best practice
        //{
        //    driverParams = LoadParams(driverParamsJson);
        //}

        public WebDriverFactory(string driverParamsJson) : this(LoadParams(driverParamsJson)) { } // this C'tor calls the C'tor underneath

        public WebDriverFactory(DriverParams driverParams)
        {
            this.driverParams = driverParams;
            if (string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
            {
                driverParams.Binaries = Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(driverParams.Source))
            {
                driverParams.Source = "NoSource";
            }
        }
        /// <summary>
        /// Generate web driver based on input params
        /// </summary>
        /// <returns> web driver instance </returns>
        public IWebDriver Get()
        {
            return driverParams.Source.ToUpper().Equals("REMOTE") ? GetRemoteDriver() : GetDriver();
        }

        //Local web drivers (routing to local host)
        private IWebDriver GetChrome() => new ChromeDriver(driverParams.Binaries);
        private IWebDriver GetEdge() => new EdgeDriver(driverParams.Binaries);
        private IWebDriver GetInternetExplorer() => new InternetExplorerDriver(driverParams.Binaries);

        private IWebDriver GetDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "EDGE": return GetEdge();
                case "IE": return GetInternetExplorer();
                case "CHROME":
                default: return GetChrome();
            }
        }

        //Remote web drivers
        private IWebDriver GetRemoteChrome() => new RemoteWebDriver(new Uri(driverParams.Binaries), new ChromeOptions());
        private IWebDriver GetRemoteEdge() => new RemoteWebDriver(new Uri(driverParams.Binaries), new EdgeOptions());
        private IWebDriver GetRemoteInternetExplorer() => new RemoteWebDriver(new Uri(driverParams.Binaries), new InternetExplorerOptions());

        private IWebDriver GetRemoteDriver()
        {
            switch (driverParams.Driver.ToUpper())
            {
                case "EDGE": return GetRemoteEdge();
                case "IE": return GetRemoteInternetExplorer();
                case "CHROME":
                default: return GetRemoteChrome();
            }
        }

        //Load Json into DriverParams object
        private static DriverParams LoadParams(string driverParamJson)
        {
            if (string.IsNullOrEmpty(driverParamJson))
            {
                return new DriverParams { Source = "Local", Driver = "Chrome", Binaries = "." }; // Default
            }
            return JsonConvert.DeserializeObject<DriverParams>(driverParamJson);
        }
    }
}
