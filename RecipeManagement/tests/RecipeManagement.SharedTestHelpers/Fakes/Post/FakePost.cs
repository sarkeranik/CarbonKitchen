namespace RecipeManagement.SharedTestHelpers.Fakes.Post;

using AutoBogus;
using RecipeManagement.Domain.Posts;
using RecipeManagement.Domain.Posts.Dtos;

public sealed class FakePost
{
    public static Post Generate(PostForCreationDto postForCreationDto)
    {
        return Post.Create(postForCreationDto);
    }

    public static Post Generate()
    {
        return Generate(new FakePostForCreationDto().Generate());
    }
}