using DJT.Vertical.Exceptions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DJT.Vertical.AspNetCore
{
    /// <summary>
    /// Catches exceptions provided in DJT.Vertical.Exceptions and the ValidationException.
    /// Provides relevant HTTP responses.  This is Http pipeline middleware.
    /// </summary>
    /// <param name="next"></param>
    public class ClientErrorMiddleware(RequestDelegate next)
    {
        /// <summary>
        /// Invoke the middleware
        /// </summary>
        /// <param name="context">Current Http Context</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (VerticalException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                if (ex.Body is not null)
                    await context.Response.WriteAsJsonAsync(ex.Body);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(ex.ValidationResult);
            }
        }
    }
}
