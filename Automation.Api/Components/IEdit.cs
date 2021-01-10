using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IEdit<T> //Generic Interface
    {
        T Edit();
    }
}
