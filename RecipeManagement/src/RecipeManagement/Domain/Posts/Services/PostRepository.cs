namespace RecipeManagement.Domain.Posts.Services;

using RecipeManagement.Domain.Posts;
using RecipeManagement.Databases;
using RecipeManagement.Services;

public interface IPostRepository : IGenericRepository<Post>
{
}

public sealed class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly RecipesDbContext _dbContext;

    public PostRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
