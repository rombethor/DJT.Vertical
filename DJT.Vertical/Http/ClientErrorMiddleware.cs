using DJT.Vertical.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Http
{
    public class ClientErrorMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                next(context);
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
