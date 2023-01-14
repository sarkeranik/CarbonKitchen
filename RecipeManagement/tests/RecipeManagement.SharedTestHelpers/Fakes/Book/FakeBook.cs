namespace RecipeManagement.SharedTestHelpers.Fakes.Book;

using AutoBogus;
using RecipeManagement.Domain.Books;
using RecipeManagement.Domain.Books.Dtos;

public sealed class FakeBook
{
    public static Book Generate(BookForCreationDto bookForCreationDto)
    {
        return Book.Create(bookForCreationDto);
    }

    public static Book Generate()
    {
        return Generate(new FakeBookForCreationDto().Generate());
    }
}