namespace RecipeManagement.Domain.Categories.Services;

using RecipeManagement.Domain.Categories;
using RecipeManagement.Databases;
using RecipeManagement.Services;

public interface ICategoryRepository : IGenericRepository<Category>
{
}

public sealed class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly RecipesDbContext _dbContext;

    public CategoryRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
