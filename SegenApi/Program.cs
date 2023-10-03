using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SegenApi.DbServices;

namespace SegenApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, collection) =>
                {
                    collection.RegisterDbServices(context.Configuration, context.HostingEnvironment);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }

    public static class AppRegistration
    {
        public static IServiceCollection RegisterDbServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            // Registering Db Context and Repository by default its Scoped
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                // This sensitive data logging is only for development purpose
                if (environment.IsDevelopment())
                {
                    options
                        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                        .EnableSensitiveDataLogging();
                }
            });
            // Register service as Scoped as it server one request at a time per http Call
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
    
}
