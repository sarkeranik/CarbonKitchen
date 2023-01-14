namespace RecipeManagement.Domain.Categories.Dtos;

using SharedKernel.Dtos;

public sealed class CategoryParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}
