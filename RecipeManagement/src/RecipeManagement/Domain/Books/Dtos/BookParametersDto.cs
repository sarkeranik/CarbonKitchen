namespace RecipeManagement.Domain.Books.Dtos;

using SharedKernel.Dtos;

public sealed class BookParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}
