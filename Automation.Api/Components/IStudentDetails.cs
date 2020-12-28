using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IStudentDetails
    {
        string FirstName();
        string LastName();
        DateTime EnrollmentDate();
    }
}
