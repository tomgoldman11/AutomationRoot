using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Framework.Ui.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUi : FluentUi, IStudents
    {
        public StudentsUi(IWebDriver driver) : base(driver)
        {

        }

        public StudentsUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {

        }

        public ICreateStudent Create()
        {
            Driver.GetEnabledElement(By.XPath("//a[contains(@href,'/Student/Create')]")).Click();
            return new CreateStudentUi(Driver);
        }

        public int CurrentPage()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='SearchString']")).SendKeys(name);
            Driver.SubmitForm(0);
            return this;
        }

        public T Menu<T>(string menuName)
        {
            throw new NotImplementedException();
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public int NumberOfPages()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
            var students = Driver.GetElements(By.XPath("//tbody/tr"));
            return students.Select(s => new StudentUi(Driver, s)); // for each element in students page, select the entire tablerow (IWebElement)
        }
    }
}
