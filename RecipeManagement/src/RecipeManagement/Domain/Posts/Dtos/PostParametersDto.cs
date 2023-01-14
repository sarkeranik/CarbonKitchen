namespace RecipeManagement.Domain.Posts.Dtos;

using SharedKernel.Dtos;

public sealed class PostParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}
