using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Domain.Model.Entities;
public class User : IdentityUser
{
    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
    public Student? Student { get; set; }
    public Instructor? Instructor { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<Role> Roles { get; set; } = [];

}