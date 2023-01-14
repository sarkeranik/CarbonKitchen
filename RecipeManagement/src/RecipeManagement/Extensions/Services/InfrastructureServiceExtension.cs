namespace RecipeManagement.Extensions.Services;

using RecipeManagement.Databases;
using RecipeManagement.Resources;
using RecipeManagement.Services;
using Microsoft.EntityFrameworkCore;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, IWebHostEnvironment env)
    {
        // DbContext -- Do Not Delete
        var connectionString = EnvironmentService.DbConnectionString;
        if(string.IsNullOrWhiteSpace(connectionString))
        {
            // this makes local migrations easier to manage. feel free to refactor if desired.
            connectionString = env.IsDevelopment() 
                ? "Data Source=localhost,54768;Integrated Security=False;Database=dev_recipemanagement;User ID=SA;Password=#localDockerPassword#"
                : throw new Exception("DB_CONNECTION_STRING environment variable is not set.");
        }

        services.AddDbContext<RecipesDbContext>(options =>
            options.UseSqlServer(connectionString,
                builder => builder.MigrationsAssembly(typeof(RecipesDbContext).Assembly.FullName))
                            .UseSnakeCaseNamingConvention());

        services.AddHostedService<MigrationHostedService<RecipesDbContext>>();

        // Auth -- Do Not Delete
    }
}
