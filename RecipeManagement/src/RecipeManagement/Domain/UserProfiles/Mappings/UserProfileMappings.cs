namespace RecipeManagement.Domain.UserProfiles.Mappings;

using RecipeManagement.Domain.UserProfiles.Dtos;
using RecipeManagement.Domain.UserProfiles;
using Mapster;

public sealed class UserProfileMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserProfile, UserProfileDto>();
        config.NewConfig<UserProfileForCreationDto, UserProfile>()
            .TwoWays();
        config.NewConfig<UserProfileForUpdateDto, UserProfile>()
            .TwoWays();
    }
}