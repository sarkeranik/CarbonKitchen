namespace RecipeManagement.Domain.Books;

using SharedKernel.Exceptions;
using RecipeManagement.Domain.Books.Dtos;
using RecipeManagement.Domain.Books.DomainEvents;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RecipeManagement.Domain.Categories;


public class Book : BaseEntity
{
    public virtual string Name { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    public virtual ICollection<Category> Categories { get; private set; }


    public static Book Create(BookForCreationDto bookForCreationDto)
    {
        var newBook = new Book();

        newBook.Name = bookForCreationDto.Name;

        newBook.QueueDomainEvent(new BookCreated(){ Book = newBook });
        
        return newBook;
    }

    public Book Update(BookForUpdateDto bookForUpdateDto)
    {
        Name = bookForUpdateDto.Name;

        QueueDomainEvent(new BookUpdated(){ Id = Id });
        return this;
    }
    
    protected Book() { } // For EF + Mocking
}