using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Testing.Cases
{
    public class StudentDetails : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            //students to find
            var keyword = $"{testParams["keyword"]}";

            //perform test case
            var student = new FluentUi(Driver).ChangeContext<StudentsUi>($"{testParams["application"]}") // $ operator tranform the object into string.
                                              .FindByName(keyword)
                                              .Students()
                                              .First();

            // extract expected result
            var expected = student.FirstName();

            //assert
            return student.Details().FirstName().Equals(expected, StringComparison.OrdinalIgnoreCase);
                                      
        }
    }
}
