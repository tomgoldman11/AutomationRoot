using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Components
{
    interface IFluent
    {
        T ChangeContext<T>();
        T ChangeContext<T>(ILogger logger);
        T ChnageContext<T>(string application);
        T ChnageContext<T>(string application, ILogger logger);
    }
}
