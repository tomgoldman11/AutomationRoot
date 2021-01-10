using System;
using System.Collections.Generic;
using System.Text;
using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IPersonalDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent EnrollmentDate(DateTime enrollmentDate);  // public by default because of interface
        ICreateStudent FirstName(string firstName);
        ICreateStudent LastName(string lastName);
    }
}
