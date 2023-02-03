using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public int Code { get; set; }
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
