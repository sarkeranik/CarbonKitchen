namespace RecipeManagement.Domain.Blogs;

using SharedKernel.Exceptions;
using RecipeManagement.Domain.Blogs.Dtos;
using RecipeManagement.Domain.Blogs.DomainEvents;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RecipeManagement.Domain.Posts;


public class Blog : BaseEntity
{
    public virtual string Name { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    public virtual ICollection<Post> Posts { get; private set; }


    public static Blog Create(BlogForCreationDto blogForCreationDto)
    {
        var newBlog = new Blog();

        newBlog.Name = blogForCreationDto.Name;

        newBlog.QueueDomainEvent(new BlogCreated(){ Blog = newBlog });
        
        return newBlog;
    }

    public Blog Update(BlogForUpdateDto blogForUpdateDto)
    {
        Name = blogForUpdateDto.Name;

        QueueDomainEvent(new BlogUpdated(){ Id = Id });
        return this;
    }
    
    protected Blog() { } // For EF + Mocking
}