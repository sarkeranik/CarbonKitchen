namespace RecipeManagement.UnitTests.UnitTests.Domain.Books;

using RecipeManagement.SharedTestHelpers.Fakes.Book;
using RecipeManagement.Domain.Books;
using RecipeManagement.Domain.Books.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class UpdateBookTests
{
    private readonly Faker _faker;

    public UpdateBookTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_update_book()
    {
        // Arrange
        var fakeBook = FakeBook.Generate();
        var updatedBook = new FakeBookForUpdateDto().Generate();
        
        // Act
        fakeBook.Update(updatedBook);

        // Assert
        fakeBook.Name.Should().Be(updatedBook.Name);
    }
    
    [Test]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var fakeBook = FakeBook.Generate();
        var updatedBook = new FakeBookForUpdateDto().Generate();
        fakeBook.DomainEvents.Clear();
        
        // Act
        fakeBook.Update(updatedBook);

        // Assert
        fakeBook.DomainEvents.Count.Should().Be(1);
        fakeBook.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(BookUpdated));
    }
}