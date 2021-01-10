using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IPersonalDetails
    {
        string FirstName();
        string LastName();
        DateTime EnrollmentDate();
    }
}
