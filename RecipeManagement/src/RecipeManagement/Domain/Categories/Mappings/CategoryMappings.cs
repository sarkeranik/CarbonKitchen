namespace RecipeManagement.Domain.Categories.Mappings;

using RecipeManagement.Domain.Categories.Dtos;
using RecipeManagement.Domain.Categories;
using Mapster;

public sealed class CategoryMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>();
        config.NewConfig<CategoryForCreationDto, Category>()
            .TwoWays();
        config.NewConfig<CategoryForUpdateDto, Category>()
            .TwoWays();
    }
}