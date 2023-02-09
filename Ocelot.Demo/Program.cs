using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Ocelot.Demo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

            builder.Configuration.AddJsonFile($"ocelot.{env}.json");

            builder.Services.AddOcelot();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.UseOcelot().Wait();

            app.Run();
        }
    }
}
