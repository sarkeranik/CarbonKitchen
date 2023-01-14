namespace RecipeManagement.Domain.Posts.Mappings;

using RecipeManagement.Domain.Posts.Dtos;
using RecipeManagement.Domain.Posts;
using Mapster;

public sealed class PostMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostDto>();
        config.NewConfig<PostForCreationDto, Post>()
            .TwoWays();
        config.NewConfig<PostForUpdateDto, Post>()
            .TwoWays();
    }
}