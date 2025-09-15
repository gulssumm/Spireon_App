using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Demo.ApiService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services
        builder.Services.AddControllers();

        // Repository
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        var app = builder.Build();

        // Configure pipeline
        app.UseRouting();
        app.MapControllers();

        // Initialize database
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SpireonDbContext>();
            context.Database.EnsureCreated();
        }

        app.Run();
    }
}