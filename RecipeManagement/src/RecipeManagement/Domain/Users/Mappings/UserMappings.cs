namespace RecipeManagement.Domain.Users.Mappings;

using RecipeManagement.Domain.Users.Dtos;
using RecipeManagement.Domain.Users;
using Mapster;

public sealed class UserMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>();
        config.NewConfig<UserForCreationDto, User>()
            .TwoWays();
        config.NewConfig<UserForUpdateDto, User>()
            .TwoWays();
    }
}