namespace RecipeManagement.SharedTestHelpers.Fakes.Category;

using AutoBogus;
using RecipeManagement.Domain.Categories;
using RecipeManagement.Domain.Categories.Dtos;

public sealed class FakeCategory
{
    public static Category Generate(CategoryForCreationDto categoryForCreationDto)
    {
        return Category.Create(categoryForCreationDto);
    }

    public static Category Generate()
    {
        return Generate(new FakeCategoryForCreationDto().Generate());
    }
}