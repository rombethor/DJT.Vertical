using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() { }

        public ForbiddenException(string? message) : base(message)
        {
        }
    }
}
