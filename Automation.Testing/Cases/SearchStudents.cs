using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Automation.Framework.Ui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams) // DataDriven ( Get params from outside is a good principle, very abstractive )
        {
            //creating Driver for this case
            var driver = new WebDriverFactory(new DriverParams { Binaries = ".", Driver = $"{testParams["driver"]}" }).Get();

            //students to find
            var keyword = $"{testParams["keyword"]}";

            //perform test case
            return new FluentUi(driver).ChangeContext<StudentsUi>($"{testParams["application"]}")
                                       .FindByName(keyword) // $ operator tranform the object into string.
                                       .Students()
                                       .All(s => s.FirstName().Equals(keyword) || s.LastName().Equals(keyword));
         
        }
    }
}
