using BookLibraryAPI.AppLayer;
using BookLibraryAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            var host = builder.Configuration.GetSection("Host").Get<Host>() ?? new Host();
            builder.WebHost.UseKestrel(options =>
            {
                options.ListenAnyIP(host.Port, listenOptions =>
                {
                    listenOptions.UseHttps(); // HTTPS port
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddAppLayer();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Logging.AddConsole();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();
                if (dbContext.Database.IsRelational())
                {
                    dbContext.Database.Migrate();
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
