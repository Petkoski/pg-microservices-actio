using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Command handlers should be implemented within services
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
