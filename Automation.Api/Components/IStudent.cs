using Automation.Api.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IStudent : IPersonalDetails, IDetails<IStudentDetails>, IDelete<object>, IEdit<object>
    {

    }
}
