namespace RecipeManagement.Domain.Books.DomainEvents;

public sealed class BookUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            