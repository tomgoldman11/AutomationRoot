using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Api.Components
{
    public interface IEntityActions
    {
        object Edit();
        object Details();
        object Delete();
    }
}
