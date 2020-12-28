using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IMenu
    {
        T Menu<T>(string menuName);
    }
}
 