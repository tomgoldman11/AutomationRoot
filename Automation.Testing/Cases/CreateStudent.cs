using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Testing.Cases
{
    public class CreateStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams) // DataDriven ( Get params from outside is a good principle, very abstractive )
        {
            //students to find
            var firstName = $"{testParams["firstName"]}";
            var lastName = $"{testParams["lastName"]}";

            //perform test case
            return new FluentUi(Driver).ChangeContext<StudentsUi>($"{testParams["application"]}") // $ operator tranform the object into string.
                                       .Create()
                                       .FirstName(firstName)
                                       .LastName(lastName)
                                       .EnrollmentDate(DateTime.Now)
                                       .Create()
                                       .FindByName(firstName)
                                       .Students()
                                       .Any();

        }
    }
}
