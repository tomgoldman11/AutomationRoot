using System;
using System.Collections.Generic;
using System.Text;
using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface IStudents : IPageNavigator<IStudents>, IMenu
    {
        IEnumerable<IStudent> Students();
        IStudents FindByName(string name);
    }
}
