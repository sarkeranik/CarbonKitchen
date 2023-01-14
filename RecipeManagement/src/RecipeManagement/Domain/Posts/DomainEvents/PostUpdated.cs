namespace RecipeManagement.Domain.Posts.DomainEvents;

public sealed class PostUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            