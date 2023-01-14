namespace RecipeManagement.UnitTests.UnitTests.Domain.Recipes;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.Domain.Recipes;
using RecipeManagement.Domain.Recipes.DomainEvents;
using Bogus;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

[Parallelizable]
public class UpdateRecipeTests
{
    private readonly Faker _faker;

    public UpdateRecipeTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_update_recipe()
    {
        // Arrange
        var fakeRecipe = FakeRecipe.Generate();
        var updatedRecipe = new FakeRecipeForUpdateDto().Generate();
        
        // Act
        fakeRecipe.Update(updatedRecipe);

        // Assert
        fakeRecipe.RecipeId.Should().Be(updatedRecipe.RecipeId);
        fakeRecipe.Title.Should().Be(updatedRecipe.Title);
        fakeRecipe.Directions.Should().Be(updatedRecipe.Directions);
        fakeRecipe.RecipeSourceLink.Should().Be(updatedRecipe.RecipeSourceLink);
        fakeRecipe.Description.Should().Be(updatedRecipe.Description);
        fakeRecipe.ImageLink.Should().Be(updatedRecipe.ImageLink);
        fakeRecipe.Visibility.Should().Be(updatedRecipe.Visibility);
    }
    
    [Test]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var fakeRecipe = FakeRecipe.Generate();
        var updatedRecipe = new FakeRecipeForUpdateDto().Generate();
        fakeRecipe.DomainEvents.Clear();
        
        // Act
        fakeRecipe.Update(updatedRecipe);

        // Assert
        fakeRecipe.DomainEvents.Count.Should().Be(1);
        fakeRecipe.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(RecipeUpdated));
    }
}