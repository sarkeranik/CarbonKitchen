namespace RecipeManagement.Domain.Books.DomainEvents;

public sealed class BookCreated : DomainEvent
{
    public Book Book { get; set; } 
}
            