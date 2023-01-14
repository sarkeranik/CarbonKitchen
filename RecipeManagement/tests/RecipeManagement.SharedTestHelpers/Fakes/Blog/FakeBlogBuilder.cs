namespace RecipeManagement.SharedTestHelpers.Fakes.Blog;

using RecipeManagement.Domain.Blogs;
using RecipeManagement.Domain.Blogs.Dtos;

public class FakeBlogBuilder
{
    private BlogForCreationDto _creationData = new FakeBlogForCreationDto().Generate();

    public FakeBlogBuilder WithDto(BlogForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public Blog Build()
    {
        var result = Blog.Create(_creationData);
        return result;
    }
}