namespace RecipeManagement.Domain.Blogs.Dtos;

using SharedKernel.Dtos;

public sealed class BlogParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}
