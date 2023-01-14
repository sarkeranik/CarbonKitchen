namespace RecipeManagement.UnitTests.UnitTests.Domain.Categories;

using RecipeManagement.SharedTestHelpers.Fakes.Category;
using RecipeManagement.Domain.Categories;
using RecipeManagement.Domain.Categories.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class UpdateCategoryTests
{
    private readonly Faker _faker;

    public UpdateCategoryTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_update_category()
    {
        // Arrange
        var fakeCategory = FakeCategory.Generate();
        var updatedCategory = new FakeCategoryForUpdateDto().Generate();
        
        // Act
        fakeCategory.Update(updatedCategory);

        // Assert
        fakeCategory.Name.Should().Be(updatedCategory.Name);
    }
    
    [Test]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var fakeCategory = FakeCategory.Generate();
        var updatedCategory = new FakeCategoryForUpdateDto().Generate();
        fakeCategory.DomainEvents.Clear();
        
        // Act
        fakeCategory.Update(updatedCategory);

        // Assert
        fakeCategory.DomainEvents.Count.Should().Be(1);
        fakeCategory.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(CategoryUpdated));
    }
}