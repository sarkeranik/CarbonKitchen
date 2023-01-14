namespace RecipeManagement.Domain.UserProfiles.Services;

using RecipeManagement.Domain.UserProfiles;
using RecipeManagement.Databases;
using RecipeManagement.Services;

public interface IUserProfileRepository : IGenericRepository<UserProfile>
{
}

public sealed class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
{
    private readonly RecipesDbContext _dbContext;

    public UserProfileRepository(RecipesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
