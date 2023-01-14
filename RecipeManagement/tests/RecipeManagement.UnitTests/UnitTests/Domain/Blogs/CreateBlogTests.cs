namespace RecipeManagement.UnitTests.UnitTests.Domain.Blogs;

using RecipeManagement.SharedTestHelpers.Fakes.Blog;
using RecipeManagement.Domain.Blogs;
using RecipeManagement.Domain.Blogs.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class CreateBlogTests
{
    private readonly Faker _faker;

    public CreateBlogTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_create_valid_blog()
    {
        // Arrange
        var blogToCreate = new FakeBlogForCreationDto().Generate();
        
        // Act
        var fakeBlog = Blog.Create(blogToCreate);

        // Assert
        fakeBlog.Name.Should().Be(blogToCreate.Name);
    }

    [Test]
    public void queue_domain_event_on_create()
    {
        // Arrange + Act
        var fakeBlog = FakeBlog.Generate();

        // Assert
        fakeBlog.DomainEvents.Count.Should().Be(1);
        fakeBlog.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(BlogCreated));
    }
}