namespace RecipeManagement.SharedTestHelpers.Fakes.UserProfile;

using RecipeManagement.Domain.UserProfiles;
using RecipeManagement.Domain.UserProfiles.Dtos;

public class FakeUserProfileBuilder
{
    private UserProfileForCreationDto _creationData = new FakeUserProfileForCreationDto().Generate();

    public FakeUserProfileBuilder WithDto(UserProfileForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public UserProfile Build()
    {
        var result = UserProfile.Create(_creationData);
        return result;
    }
}