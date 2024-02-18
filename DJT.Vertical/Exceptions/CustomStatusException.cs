using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Exceptions
{
    public class CustomStatusException : Exception
    {
        private readonly int _statusCode;
        public int StatusCode => _statusCode;

        private readonly object? _body;
        public object? Body => _body;

        public CustomStatusException(int statusCode)
        {
            _statusCode = statusCode;
        }

        public CustomStatusException(int statusCode, object? body)
        {
            _statusCode = statusCode;
            _body = body;
        }
    }
}
