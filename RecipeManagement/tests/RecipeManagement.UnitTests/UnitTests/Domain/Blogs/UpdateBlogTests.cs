namespace RecipeManagement.UnitTests.UnitTests.Domain.Blogs;

using RecipeManagement.SharedTestHelpers.Fakes.Blog;
using RecipeManagement.Domain.Blogs;
using RecipeManagement.Domain.Blogs.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class UpdateBlogTests
{
    private readonly Faker _faker;

    public UpdateBlogTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_update_blog()
    {
        // Arrange
        var fakeBlog = FakeBlog.Generate();
        var updatedBlog = new FakeBlogForUpdateDto().Generate();
        
        // Act
        fakeBlog.Update(updatedBlog);

        // Assert
        fakeBlog.Name.Should().Be(updatedBlog.Name);
    }
    
    [Test]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var fakeBlog = FakeBlog.Generate();
        var updatedBlog = new FakeBlogForUpdateDto().Generate();
        fakeBlog.DomainEvents.Clear();
        
        // Act
        fakeBlog.Update(updatedBlog);

        // Assert
        fakeBlog.DomainEvents.Count.Should().Be(1);
        fakeBlog.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(BlogUpdated));
    }
}