using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DJT.Vertical.Http
{
    public static class ServiceExtensions
    {
        public static void AddVerticalComponents(IServiceCollection services)
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

        public static void UseVerticalComponents(IApplicationBuilder app)
        {
            app.UseMiddleware<ClientErrorMiddleware>();
        }
    }
}
