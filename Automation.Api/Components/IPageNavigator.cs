using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IPageNavigator<out T>
    {
        T Next();
        T Previous();
        int NumberOfPages();
        int CurrentPage();
    }
}
