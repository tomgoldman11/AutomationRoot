using Automation.Api.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Pages
{
    public interface IStudentDetails : IPersonalDetails
    {
        IEnrollment[] Enrollments();
    }
}
