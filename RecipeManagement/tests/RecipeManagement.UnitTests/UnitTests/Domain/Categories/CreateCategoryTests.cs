namespace RecipeManagement.UnitTests.UnitTests.Domain.Categories;

using RecipeManagement.SharedTestHelpers.Fakes.Category;
using RecipeManagement.Domain.Categories;
using RecipeManagement.Domain.Categories.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class CreateCategoryTests
{
    private readonly Faker _faker;

    public CreateCategoryTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_create_valid_category()
    {
        // Arrange
        var categoryToCreate = new FakeCategoryForCreationDto().Generate();
        
        // Act
        var fakeCategory = Category.Create(categoryToCreate);

        // Assert
        fakeCategory.Name.Should().Be(categoryToCreate.Name);
    }

    [Test]
    public void queue_domain_event_on_create()
    {
        // Arrange + Act
        var fakeCategory = FakeCategory.Generate();

        // Assert
        fakeCategory.DomainEvents.Count.Should().Be(1);
        fakeCategory.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CategoryCreated));
    }
}