using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DJT.Vertical.Http
{
    /// <summary>
    /// Extension methods for using the components in this library
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds generic AuthService dependency and registers IRequestHandlers in the calling assembly
        /// </summary>
        /// <param name="services"></param>
        public static void AddVerticalComponents(this IServiceCollection services)
        {
            services.TryAddScoped<AuthService>();

            //TO DO: Use reflection to add IRequestHandler<,>
            var allTypes = Assembly.GetCallingAssembly().GetTypes();
            foreach(var type in allTypes)
            {
                var i = type.GetInterface("IRequestHandler`1")
                    ?? type.GetInterface("IRequestHandler`2")
                    ?? type.GetInterface("IRequestHandler`3");
                if (i is not null)
                    services.AddTransient(type);
            }
        }

        /// <summary>
        /// Adds client error handling middleware for web api
        /// </summary>
        /// <param name="app"></param>
        public static void UseVerticalComponents(this IApplicationBuilder app)
        {
            app.UseMiddleware<ClientErrorMiddleware>();
        }
    }
}
