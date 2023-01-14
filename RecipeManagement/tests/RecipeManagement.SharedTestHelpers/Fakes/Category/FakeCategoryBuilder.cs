namespace RecipeManagement.SharedTestHelpers.Fakes.Category;

using RecipeManagement.Domain.Categories;
using RecipeManagement.Domain.Categories.Dtos;

public class FakeCategoryBuilder
{
    private CategoryForCreationDto _creationData = new FakeCategoryForCreationDto().Generate();

    public FakeCategoryBuilder WithDto(CategoryForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public Category Build()
    {
        var result = Category.Create(_creationData);
        return result;
    }
}