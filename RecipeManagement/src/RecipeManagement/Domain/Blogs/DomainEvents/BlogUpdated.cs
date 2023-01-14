namespace RecipeManagement.Domain.Blogs.DomainEvents;

public sealed class BlogUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            