namespace RecipeManagement.SharedTestHelpers.Fakes.Book;

using AutoBogus;
using RecipeManagement.Domain.Books;
using RecipeManagement.Domain.Books.Dtos;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public sealed class FakeBookForUpdateDto : AutoFaker<BookForUpdateDto>
{
    public FakeBookForUpdateDto()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(b => b.ExampleIntProperty, b => b.Random.Number(50, 100000));
        //RuleFor(b => b.ExampleDateProperty, b => b.Date.Past());
    }
}