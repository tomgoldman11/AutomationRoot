﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Extensions.Components
{
    public static class WebDriverExtensions
    {
        public static IWebDriver GoToUrl(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            return driver; 
        }
        //Gives us default timeout
        public static IWebElement GetElement(this IWebDriver driver, By by) => GetElement(driver, by, TimeSpan.FromSeconds(15)); 
        public static IWebElement GetElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout); // reapeat until element is found or reaching timeout
            return wait.Until(d => d.FindElement(by));
        }
        public static SelectElement AsSelect(this IWebElement element) => new SelectElement(element);
        public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, By by) => GetElements(driver, by, TimeSpan.FromSeconds(15));
        public static ReadOnlyCollection<IWebElement> GetElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout); // reapeat until element is found or reaching timeout
            return wait.Until(d => d.FindElements(by));
        }
        public static IWebElement GetVisibleElement(this IWebDriver driver, By by) => GetVisibleElement(driver, by, TimeSpan.FromSeconds(15));
        public static IWebElement GetVisibleElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout); // reapeat until element is found or reaching timeout
            return wait.Until(d =>
            {
                var element = d.FindElement(by);
                return element.Displayed ? element : null;
            });
        }
        public static ReadOnlyCollection<IWebElement> GetVisibleElements(this IWebDriver driver, By by) => GetVisibleElements(driver, by, TimeSpan.FromSeconds(15));
        public static ReadOnlyCollection<IWebElement> GetVisibleElements(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout); // reapeat until element is found or reaching timeout
            return wait.Until(d =>
            {
                var elements = d.FindElements(by).Where(e => e.Displayed).ToList();
                return new ReadOnlyCollection<IWebElement>(elements);
            });
        }
        public static IWebElement GetEnabledElement(this IWebDriver driver, By by) => GetEnabledElement(driver, by, TimeSpan.FromSeconds(15));
        public static IWebElement GetEnabledElement(this IWebDriver driver, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout); // reapeat until element is found or reaching timeout
            return wait.Until(d =>
            {
                var element = d.FindElement(by);
                return element.Enabled ? element : null;
            });
        }
        public static IWebDriver VerticalWindowScroll(this IWebDriver driver, int scrollAmount)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scroll(0,{scrollAmount});");
            return driver;
        }
        public static Actions Actions(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var actions = new Actions(driver);
            return actions.MoveToElement(element);
        }
        public static IWebElement ForceClick(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element); //Performing click using JS, useful when you can't use actual click
            return element;
        }
        public static IWebElement SendKeys(this IWebElement element, string text, int interval)
        {
            foreach (char c in text)
            {
                element.SendKeys($"{c}"); //converting the char into string
                Thread.Sleep(interval);
            }
            return element;
        }
        public static IWebElement ForceClear(this IWebElement element)
        {
            var value = element.GetAttribute("value");
            element.SendKeys(Keys.End);
            for (int i = 0; i < value.Length; i++)
            {
                element.SendKeys(Keys.Backspace);
                Thread.Sleep(50);
            }
            return element; 
        }
        public static IWebDriver SubmitForm(this IWebDriver driver, int index)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"document.forms[{index}].submit();");
            return driver;
        }
        public static IWebDriver SubmitForm(this IWebDriver driver, string id)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"document.forms[\"{id}\"].submit();");
            return driver;
        }

    }//End Class 

}//End Namespace
 