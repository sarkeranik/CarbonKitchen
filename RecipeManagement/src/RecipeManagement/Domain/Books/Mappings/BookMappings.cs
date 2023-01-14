namespace RecipeManagement.Domain.Books.Mappings;

using RecipeManagement.Domain.Books.Dtos;
using RecipeManagement.Domain.Books;
using Mapster;

public sealed class BookMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Book, BookDto>();
        config.NewConfig<BookForCreationDto, Book>()
            .TwoWays();
        config.NewConfig<BookForUpdateDto, Book>()
            .TwoWays();
    }
}