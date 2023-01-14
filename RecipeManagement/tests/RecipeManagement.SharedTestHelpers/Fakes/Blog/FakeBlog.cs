namespace RecipeManagement.SharedTestHelpers.Fakes.Blog;

using AutoBogus;
using RecipeManagement.Domain.Blogs;
using RecipeManagement.Domain.Blogs.Dtos;

public sealed class FakeBlog
{
    public static Blog Generate(BlogForCreationDto blogForCreationDto)
    {
        return Blog.Create(blogForCreationDto);
    }

    public static Blog Generate()
    {
        return Generate(new FakeBlogForCreationDto().Generate());
    }
}