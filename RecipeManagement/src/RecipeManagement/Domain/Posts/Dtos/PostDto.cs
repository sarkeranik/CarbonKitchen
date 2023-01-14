namespace RecipeManagement.Domain.Posts.Dtos;

public sealed class PostDto 
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? BlogId { get; set; }
}
