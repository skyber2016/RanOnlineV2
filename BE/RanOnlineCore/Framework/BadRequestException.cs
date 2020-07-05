using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "Validation error") : base(message) { }
    }
}
