namespace RecipeManagement.Domain.Users;

using SharedKernel.Exceptions;
using RecipeManagement.Domain.Users.Dtos;
using RecipeManagement.Domain.Users.DomainEvents;
using FluentValidation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using RecipeManagement.Domain.UserProfiles;


public class User : BaseEntity
{
    public virtual string Name { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    [ForeignKey("UserProfile")]
    public virtual Guid? UserProfileId { get; private set; }
    public virtual UserProfile UserProfile { get; private set; }


    public static User Create(UserForCreationDto userForCreationDto)
    {
        var newUser = new User();

        newUser.Name = userForCreationDto.Name;
        newUser.UserProfileId = userForCreationDto.UserProfileId;

        newUser.QueueDomainEvent(new UserCreated(){ User = newUser });
        
        return newUser;
    }

    public User Update(UserForUpdateDto userForUpdateDto)
    {
        Name = userForUpdateDto.Name;
        UserProfileId = userForUpdateDto.UserProfileId;

        QueueDomainEvent(new UserUpdated(){ Id = Id });
        return this;
    }
    
    protected User() { } // For EF + Mocking
}