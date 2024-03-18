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
