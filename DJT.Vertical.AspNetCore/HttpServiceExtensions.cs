using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DJT.Vertical.AspNetCore
{
    public static class HttpServiceExtensions
    {

        public static void AddVerticalHttpComponents(this IServiceCollection services)
        {
            services.AddVerticalComponents();

            services.TryAddScoped<AuthService>();
        }

        /// <summary>
        /// Adds client error handling middleware for web api
        /// </summary>
        /// <param name="app"></param>
        public static void UseVerticalHttpComponents(this IApplicationBuilder app)
        {
            app.UseMiddleware<ClientErrorMiddleware>();
        }
    }
}
