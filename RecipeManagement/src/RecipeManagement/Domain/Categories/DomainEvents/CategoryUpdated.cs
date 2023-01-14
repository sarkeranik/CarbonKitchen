namespace RecipeManagement.Domain.Categories.DomainEvents;

public sealed class CategoryUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            