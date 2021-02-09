using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Events
{
    interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
