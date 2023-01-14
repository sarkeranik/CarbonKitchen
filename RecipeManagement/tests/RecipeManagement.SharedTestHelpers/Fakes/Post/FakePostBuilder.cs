namespace RecipeManagement.SharedTestHelpers.Fakes.Post;

using RecipeManagement.Domain.Posts;
using RecipeManagement.Domain.Posts.Dtos;

public class FakePostBuilder
{
    private PostForCreationDto _creationData = new FakePostForCreationDto().Generate();

    public FakePostBuilder WithDto(PostForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public Post Build()
    {
        var result = Post.Create(_creationData);
        return result;
    }
}