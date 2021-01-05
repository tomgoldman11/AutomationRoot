using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Ui.Pages
{
    public class CreateStudentUi : FluentUi, ICreateStudent
    {
        public CreateStudentUi(IWebDriver driver) : base(driver)
        {

        }

        public CreateStudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {

        }

        public IStudents BackToList()
        {
            throw new NotImplementedException();
        }

        public IStudents Create()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent EnrollmentDate(DateTime enrollmentDate)
        {
            throw new NotImplementedException();
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent LastName(string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
