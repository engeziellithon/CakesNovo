using Cakes.Data.Context;
using Cakes.Data.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

namespace Cakes.Api.Extensions
{
    public static class AddServiceSetup
    {
        public static void AddServicesSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataService(configuration);
            services.AddPerformanceApiService();
        }

        public static void AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(opt =>
                    opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), opt =>
                opt.MigrationsAssembly("Cakes.Data")));

            services.AddTransient<ProductRepository>();
            services.AddTransient<ProductCategoryRepository>();

        }

        public static void AddPerformanceApiService(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();

            });
        }

        public static void AddCommandService(this IServiceCollection services)
        {

        }
    }
}
