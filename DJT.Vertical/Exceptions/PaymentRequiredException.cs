using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Indicates a 402 status code response for the request.
    /// </summary>
    public class PaymentRequiredException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PaymentRequiredException()
        {
        }
    }
}
