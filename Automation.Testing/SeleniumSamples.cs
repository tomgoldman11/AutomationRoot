using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using OpenQA.Selenium.Edge;
using System.Drawing;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSamples
    {
        [TestMethod]
        public void WebDriverSamples()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();
        }
        
        [TestMethod]
        public void WebElementSamples()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }
        
        [TestMethod]
        public void SelectElementSamples()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.FindElement(By.XPath("//a[.='Courses']")).Click();
            IWebElement element = driver.FindElement(By.XPath("//select[@id='SelectedDepartment']"));
            var selectElement = new SelectElement(element); // SelectElement is BEST with COMBO BOXES.
            selectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();

            driver = new InternetExplorerDriver(); // internet explorer driver check
            driver.Navigate().GoToUrl("https://google.com");
            driver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GoToUrlSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            Thread.Sleep(2000);
            driver.Dispose(); 
        }

        [TestMethod]
        public void GetElementSample() //GetElement is Extension method we created in order to have the capability to wait for an element to appear
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void AsSelectSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();  
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            driver.FindElement(By.XPath("//select[@id='SelectedDepartment']")).AsSelect().SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementsSample() 
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            var elements = driver.GetElements(By.XPath("//ul/li")); 
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementSample() //Clicks only if the element is visible (GetElement could try to click an existing but not visible element which will cause an exception)
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            var elements = driver.GetVisibleElements(By.XPath("//ul/li"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetEnabledElementSample() 
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Hello");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void VerticalWindowScrollSample() 
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.Manage().Window.Size = new Size(100, 350);
            driver.VerticalWindowScroll(1000); //Scroll to point 1000 ( not 1000 pixels )
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ActionsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Actions().Click().Build().Perform(); //Last point will be the element itself because we moved to it inside Actions method.
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ForceClickSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).ForceClick();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SendKeysIntervalSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Hello", 1000);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ForceClearSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Hello",0).SendKeys(Keys.Home,0).ForceClear();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SubmitFormSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\web-drivers" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys("Alexander");
            driver.SubmitForm(0);
            Thread.Sleep(2000);
            driver.Dispose();
        }

    }//End Class

}//End Namespace
