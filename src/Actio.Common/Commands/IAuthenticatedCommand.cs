using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Mark command to require authenticated user
    /// </summary>
    public interface IAuthenticatedCommand
    {
        Guid UserId { get; set; }
    }
}
