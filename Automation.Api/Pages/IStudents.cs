using System;
using System.Collections.Generic;
using System.Text;
using Automation.Api.Components;
using Automation.Core.Components;

namespace Automation.Api.Pages
{
    public interface IStudents : IFluent, IPageNavigator<IStudents>, IMenu, ICreate<ICreateStudent>
    {
        IEnumerable<IStudent> Students();
        IStudents FindByName(string name);
    }
}
