namespace RecipeManagement.UnitTests.UnitTests.Domain.Posts;

using RecipeManagement.SharedTestHelpers.Fakes.Post;
using RecipeManagement.Domain.Posts;
using RecipeManagement.Domain.Posts.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class CreatePostTests
{
    private readonly Faker _faker;

    public CreatePostTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_create_valid_post()
    {
        // Arrange
        var postToCreate = new FakePostForCreationDto().Generate();
        
        // Act
        var fakePost = Post.Create(postToCreate);

        // Assert
        fakePost.Name.Should().Be(postToCreate.Name);
        fakePost.BlogId.Should().Be(postToCreate.BlogId);
    }

    [Test]
    public void queue_domain_event_on_create()
    {
        // Arrange + Act
        var fakePost = FakePost.Generate();

        // Assert
        fakePost.DomainEvents.Count.Should().Be(1);
        fakePost.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(PostCreated));
    }
}