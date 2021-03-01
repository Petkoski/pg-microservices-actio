using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Auth
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        /// <summary>
        /// Tells client for how long the token is available
        /// </summary>
        public long Expires { get; set; }
    }
}
