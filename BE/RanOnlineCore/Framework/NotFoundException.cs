using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode Code => HttpStatusCode.NotFound;
        public NotFoundException() : base()
        {

        }
    }
}
