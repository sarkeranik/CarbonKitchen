namespace RecipeManagement.Domain.Categories.DomainEvents;

public sealed class CategoryCreated : DomainEvent
{
    public Category Category { get; set; } 
}
            