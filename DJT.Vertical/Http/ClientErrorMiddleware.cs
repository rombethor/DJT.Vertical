using DJT.Vertical.Exceptions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DJT.Vertical.Http
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
            catch (BadRequestException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(ex.ValidationResult);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(ex.ValidationResult);
            }
            catch (ConflictException)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
            }
            catch (ForbiddenException)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
            catch (PaymentRequiredException)
            {
                context.Response.StatusCode = StatusCodes.Status402PaymentRequired;
            }
            catch (CustomStatusException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                if (ex.Body is not null)
                    await context.Response.WriteAsJsonAsync(ex.Body);
            }
        }
    }
}
