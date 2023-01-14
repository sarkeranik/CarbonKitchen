namespace RecipeManagement.Domain.Blogs.Services;

using RecipeManagement.Domain.Blogs;
using RecipeManagement.Databases;
using RecipeManagement.Services;

public interface IBlogRepository : IGenericRepository<Blog>
{
}

public sealed class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    private readonly RecipesDbContext _dbContext;

    public BlogRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
