namespace RecipeManagement.Domain.Blogs.DomainEvents;

public sealed class BlogCreated : DomainEvent
{
    public Blog Blog { get; set; } 
}
            