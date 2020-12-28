using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface ICreate<out T>
    {
        T Create();
    }
}
