namespace RecipeManagement.Domain.Posts.DomainEvents;

public sealed class PostCreated : DomainEvent
{
    public Post Post { get; set; } 
}
            