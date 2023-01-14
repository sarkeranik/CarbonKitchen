namespace RecipeManagement.FunctionalTests;

using RecipeManagement.Databases;
using RecipeManagement;
using AutoBogus;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
 
public class TestBase
{
    private static IServiceScopeFactory _scopeFactory;
    private static WebApplicationFactory<Program> _factory;
    protected static HttpClient FactoryClient  { get; private set; }

    [SetUp]
    public async Task TestSetUp()
    {
        _factory = FunctionalTestFixture.Factory;
        _scopeFactory = FunctionalTestFixture.ScopeFactory;
        FactoryClient = _factory.CreateClient(new WebApplicationFactoryClientOptions());

        AutoFaker.Configure(builder =>
        {
            // configure global autobogus settings here
            builder.WithDateTimeKind(DateTimeKind.Utc)
                .WithRecursiveDepth(3)
                .WithTreeDepth(1)
                .WithRepeatCount(1);
        });
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetService<ISender>();

        return await mediator.Send(request);
    }

    public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<RecipesDbContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public static async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<RecipesDbContext>();

        context.Add(entity);

        await context.SaveChangesAsync();
    }

    public static async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RecipesDbContext>();

        try
        {
            //await dbContext.BeginTransactionAsync();

            await action(scope.ServiceProvider);

            //await dbContext.CommitTransactionAsync();
        }
        catch (Exception)
        {
            //dbContext.RollbackTransaction();
            throw;
        }
    }

    public static async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RecipesDbContext>();

        try
        {
            //await dbContext.BeginTransactionAsync();

            var result = await action(scope.ServiceProvider);

            //await dbContext.CommitTransactionAsync();

            return result;
        }
        catch (Exception)
        {
            //dbContext.RollbackTransaction();
            throw;
        }
    }

    public static Task ExecuteDbContextAsync(Func<RecipesDbContext, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>()));

    public static Task ExecuteDbContextAsync(Func<RecipesDbContext, ValueTask> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>()).AsTask());

    public static Task ExecuteDbContextAsync(Func<RecipesDbContext, IMediator, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>(), sp.GetService<IMediator>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<RecipesDbContext, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<RecipesDbContext, ValueTask<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>()).AsTask());

    public static Task<T> ExecuteDbContextAsync<T>(Func<RecipesDbContext, IMediator, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<RecipesDbContext>(), sp.GetService<IMediator>()));

    public static Task<int> InsertAsync<T>(params T[] entities) where T : class
    {
        return ExecuteDbContextAsync(db =>
        {
            foreach (var entity in entities)
            {
                db.Set<T>().Add(entity);
            }
            return db.SaveChangesAsync();
        });
    }
}