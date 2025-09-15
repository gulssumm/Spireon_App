using Aspire.Hosting.Postgres;
using Projects;

namespace Spireon.Aspire;

public class AspireStartup
{
    public static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        // Add PostgreSQL database
        var postgres = builder.AddPostgres("postgres")
                              .WithDataVolume("spireon-postgres-data") 
                              .WithPgAdmin();

        var database = postgres.AddDatabase("spireondb");

        // Add resource name suffixes to avoid conflicts
        AddDemos(builder);

        var api = builder.AddProject<Projects.Spireon_API>("spireon-api")
                         .WithReference(database)
                         .WithExternalHttpEndpoints();

        builder.Build().Run();
    }

    private static void AddDemos(IDistributedApplicationBuilder builder)
    {
        IResourceBuilder<RedisResource> cache = builder.AddRedis("demo-cache");

        IResourceBuilder<ProjectResource> apiService = builder.AddProject<Demo_ApiService>("demo-api");

        builder.AddProject<Demo_Web>("demo-web")
               .WithExternalHttpEndpoints()
               .WithReference(cache)
               .WithReference(apiService);
    }
}