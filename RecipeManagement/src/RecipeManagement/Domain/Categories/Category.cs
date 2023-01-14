namespace RecipeManagement.Domain.Categories;

using SharedKernel.Exceptions;
using RecipeManagement.Domain.Categories.Dtos;
using RecipeManagement.Domain.Categories.DomainEvents;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RecipeManagement.Domain.Books;


public class Category : BaseEntity
{
    public virtual string Name { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    public virtual ICollection<Book> Books { get; private set; }


    public static Category Create(CategoryForCreationDto categoryForCreationDto)
    {
        var newCategory = new Category();

        newCategory.Name = categoryForCreationDto.Name;

        newCategory.QueueDomainEvent(new CategoryCreated(){ Category = newCategory });
        
        return newCategory;
    }

    public Category Update(CategoryForUpdateDto categoryForUpdateDto)
    {
        Name = categoryForUpdateDto.Name;

        QueueDomainEvent(new CategoryUpdated(){ Id = Id });
        return this;
    }
    
    protected Category() { } // For EF + Mocking
}