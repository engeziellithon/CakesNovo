using ElmahCore.Mvc;
using ElmahCore.Postgresql;
using Microsoft.AspNetCore.Http.Features;

namespace Cakes.Api.Extensions
{
    public static class ElmahSetup
    {
        public static void AddElmahSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmah<PgsqlErrorLog>(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.OnPermissionCheck = context => (context?.Connection.RemoteIpAddress != null && context?.Connection.LocalIpAddress != null);
            });
        }


        public static void UseElmahSetup(this IApplicationBuilder app)
        {
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/elmah", StringComparison.OrdinalIgnoreCase), appBuilder =>
            {
                appBuilder.Use(next =>
                {
                    return async ctx =>
                    {
                        ctx.Features.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;

                        await next(ctx);
                    };
                });
            });

            app.UseElmah();
        }

    }
}
