namespace RecipeManagement.Domain.Blogs.Mappings;

using RecipeManagement.Domain.Blogs.Dtos;
using RecipeManagement.Domain.Blogs;
using Mapster;

public sealed class BlogMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Blog, BlogDto>();
        config.NewConfig<BlogForCreationDto, Blog>()
            .TwoWays();
        config.NewConfig<BlogForUpdateDto, Blog>()
            .TwoWays();
    }
}