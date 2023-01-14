namespace RecipeManagement.IntegrationTests.FeatureTests.Recipes;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using FluentAssertions;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using RecipeManagement.Domain.Recipes.Features;
using static TestFixture;
using SharedKernel.Exceptions;

public class AddRecipeCommandTests : TestBase
{
    [Test]
    public async Task can_add_new_recipe_to_db()
    {
        // Arrange
        var fakeRecipeOne = new FakeRecipeForCreationDto().Generate();

        // Act
        var command = new AddRecipe.Command(fakeRecipeOne);
        var recipeReturned = await SendAsync(command);
        var recipeCreated = await ExecuteDbContextAsync(db => db.Recipes
            .FirstOrDefaultAsync(r => r.Id == recipeReturned.Id));

        // Assert
        recipeReturned.RecipeId.Should().Be(fakeRecipeOne.RecipeId);
        recipeReturned.Title.Should().Be(fakeRecipeOne.Title);
        recipeReturned.Directions.Should().Be(fakeRecipeOne.Directions);
        recipeReturned.RecipeSourceLink.Should().Be(fakeRecipeOne.RecipeSourceLink);
        recipeReturned.Description.Should().Be(fakeRecipeOne.Description);
        recipeReturned.ImageLink.Should().Be(fakeRecipeOne.ImageLink);
        recipeReturned.Visibility.Should().Be(fakeRecipeOne.Visibility);

        recipeCreated.RecipeId.Should().Be(fakeRecipeOne.RecipeId);
        recipeCreated.Title.Should().Be(fakeRecipeOne.Title);
        recipeCreated.Directions.Should().Be(fakeRecipeOne.Directions);
        recipeCreated.RecipeSourceLink.Should().Be(fakeRecipeOne.RecipeSourceLink);
        recipeCreated.Description.Should().Be(fakeRecipeOne.Description);
        recipeCreated.ImageLink.Should().Be(fakeRecipeOne.ImageLink);
        recipeCreated.Visibility.Should().Be(fakeRecipeOne.Visibility);
    }
}