using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 409 status response, indicating Conflict.
    /// </summary>
    public class ConflictException : Exception
    {
        /// <summary>
        /// Default exception
        /// </summary>
        public ConflictException() { }

        /// <summary>
        /// Provide a custom error message
        /// </summary>
        /// <param name="message"></param>
        public ConflictException(string? message) : base(message)
        {
        }
    }
}
