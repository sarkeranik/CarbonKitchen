namespace RecipeManagement.SharedTestHelpers.Fakes.User;

using RecipeManagement.Domain.Users;
using RecipeManagement.Domain.Users.Dtos;

public class FakeUserBuilder
{
    private UserForCreationDto _creationData = new FakeUserForCreationDto().Generate();

    public FakeUserBuilder WithDto(UserForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public User Build()
    {
        var result = User.Create(_creationData);
        return result;
    }
}