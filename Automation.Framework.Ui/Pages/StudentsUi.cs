using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public int CurrentPage()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
