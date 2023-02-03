using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Shared.Exceptions
{
    public class UnauthorizedException : UnauthorizedAccessException
    {
        public int Code { get; set; }
        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
