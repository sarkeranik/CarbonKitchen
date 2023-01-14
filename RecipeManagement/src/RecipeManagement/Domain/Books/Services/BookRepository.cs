namespace RecipeManagement.Domain.Books.Services;

using RecipeManagement.Domain.Books;
using RecipeManagement.Databases;
using RecipeManagement.Services;

public interface IBookRepository : IGenericRepository<Book>
{
}

public sealed class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly RecipesDbContext _dbContext;

    public BookRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
