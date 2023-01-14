namespace RecipeManagement.SharedTestHelpers.Fakes.Book;

using RecipeManagement.Domain.Books;
using RecipeManagement.Domain.Books.Dtos;

public class FakeBookBuilder
{
    private BookForCreationDto _creationData = new FakeBookForCreationDto().Generate();

    public FakeBookBuilder WithDto(BookForCreationDto dto)
    {
        _creationData = dto;
        return this;
    }
    
    public Book Build()
    {
        var result = Book.Create(_creationData);
        return result;
    }
}