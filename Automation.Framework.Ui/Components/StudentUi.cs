using Automation.Api.Components;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi : FluentUi, IStudent
    {
        private readonly IWebElement dataRow;
        private string firstName;
        private string lastName;
        private DateTime enrollmentDate; 
        //C'tor
        public StudentUi(IWebDriver driver, IWebElement dataRow) : this(driver, new TraceLogger())
        {
            this.dataRow = dataRow;
            Build(this.dataRow);
        }
        private StudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {

        }

        //Actions
        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Details()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        //Data
        public DateTime EnrollmentDate()
        {
            return enrollmentDate;
        }

        public string FirstName()
        {
            return firstName;
        }

        public string LastName()
        {
            return lastName;
        }

        //Proccessing
        private void Build(IWebElement dataRow)
        {
            lastName = dataRow.FindElement(By.XPath("./td[1]")).Text.Trim(); // searching IWebElement inside IWebElement (table data inside table row)
            firstName = dataRow.FindElement(By.XPath("./td[2]")).Text.Trim();
            //Parse Date
            string dateString = dataRow.FindElement(By.XPath("./td[3]")).Text.Trim();
            DateTime.TryParse(dateString, out enrollmentDate);
        }

    }
}
