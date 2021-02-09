using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Events
{
    /// <summary>
    /// Event handlers should be implemented within services
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
