namespace RecipeManagement.UnitTests.UnitTests.Domain.Books;

using RecipeManagement.SharedTestHelpers.Fakes.Book;
using RecipeManagement.Domain.Books;
using RecipeManagement.Domain.Books.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class CreateBookTests
{
    private readonly Faker _faker;

    public CreateBookTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_create_valid_book()
    {
        // Arrange
        var bookToCreate = new FakeBookForCreationDto().Generate();
        
        // Act
        var fakeBook = Book.Create(bookToCreate);

        // Assert
        fakeBook.Name.Should().Be(bookToCreate.Name);
    }

    [Test]
    public void queue_domain_event_on_create()
    {
        // Arrange + Act
        var fakeBook = FakeBook.Generate();

        // Assert
        fakeBook.DomainEvents.Count.Should().Be(1);
        fakeBook.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(BookCreated));
    }
}