using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateUserRejected()
        {

        }

        public CreateUserRejected(string email, 
            string reason, 
            string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
