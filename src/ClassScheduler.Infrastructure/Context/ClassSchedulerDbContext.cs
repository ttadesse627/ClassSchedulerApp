using ClassScheduler.Domain.Configurations;
using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Context;
public class ClassSchedulerDbContext(DbContextOptions<ClassSchedulerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<PersonInfo> PersonInfos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Entity Configuration
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfig());
            modelBuilder.ApplyConfiguration(new InstructorEntityConfig());
            modelBuilder.ApplyConfiguration(new StudentEntityConfig());
        }
        #endregion
        base.OnModelCreating(modelBuilder);
    }

}