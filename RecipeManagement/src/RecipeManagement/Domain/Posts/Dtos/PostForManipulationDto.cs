namespace RecipeManagement.Domain.Posts.Dtos;

public abstract class PostForManipulationDto 
{
        public string Name { get; set; }
        public Guid? BlogId { get; set; }
}
