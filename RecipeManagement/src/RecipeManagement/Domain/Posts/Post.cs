namespace RecipeManagement.Domain.Posts;

using SharedKernel.Exceptions;
using RecipeManagement.Domain.Posts.Dtos;
using RecipeManagement.Domain.Posts.DomainEvents;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RecipeManagement.Domain.Blogs;


public class Post : BaseEntity
{
    public virtual string Name { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    [ForeignKey("Blog")]
    public virtual Guid? BlogId { get; private set; }
    public virtual Blog Blog { get; private set; }


    public static Post Create(PostForCreationDto postForCreationDto)
    {
        var newPost = new Post();

        newPost.Name = postForCreationDto.Name;
        newPost.BlogId = postForCreationDto.BlogId;

        newPost.QueueDomainEvent(new PostCreated(){ Post = newPost });
        
        return newPost;
    }

    public Post Update(PostForUpdateDto postForUpdateDto)
    {
        Name = postForUpdateDto.Name;
        BlogId = postForUpdateDto.BlogId;

        QueueDomainEvent(new PostUpdated(){ Id = Id });
        return this;
    }
    
    protected Post() { } // For EF + Mocking
}