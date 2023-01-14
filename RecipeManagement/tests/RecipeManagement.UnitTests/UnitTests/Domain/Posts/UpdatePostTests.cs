namespace RecipeManagement.UnitTests.UnitTests.Domain.Posts;

using RecipeManagement.SharedTestHelpers.Fakes.Post;
using RecipeManagement.Domain.Posts;
using RecipeManagement.Domain.Posts.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class UpdatePostTests
{
    private readonly Faker _faker;

    public UpdatePostTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_update_post()
    {
        // Arrange
        var fakePost = FakePost.Generate();
        var updatedPost = new FakePostForUpdateDto().Generate();
        
        // Act
        fakePost.Update(updatedPost);

        // Assert
        fakePost.Name.Should().Be(updatedPost.Name);
        fakePost.BlogId.Should().Be(updatedPost.BlogId);
    }
    
    [Test]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var fakePost = FakePost.Generate();
        var updatedPost = new FakePostForUpdateDto().Generate();
        fakePost.DomainEvents.Clear();
        
        // Act
        fakePost.Update(updatedPost);

        // Assert
        fakePost.DomainEvents.Count.Should().Be(1);
        fakePost.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PostUpdated));
    }
}