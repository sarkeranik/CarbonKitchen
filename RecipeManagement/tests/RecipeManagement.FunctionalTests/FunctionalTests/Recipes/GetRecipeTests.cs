namespace RecipeManagement.FunctionalTests.FunctionalTests.Recipes;

using RecipeManagement.SharedTestHelpers.Fakes.Recipe;
using RecipeManagement.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetRecipeTests : TestBase
{
    [Test]
    public async Task get_recipe_returns_success_when_entity_exists()
    {
        // Arrange
        var fakeRecipe = FakeRecipe.Generate(new FakeRecipeForCreationDto().Generate());
        await InsertAsync(fakeRecipe);

        // Act
        var route = ApiRoutes.Recipes.GetRecord(fakeRecipe.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}