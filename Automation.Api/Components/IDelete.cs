using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IDelete<T>
    {
        T Delete();
    }
}
