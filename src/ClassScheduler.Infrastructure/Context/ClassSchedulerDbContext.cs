using ClassScheduler.Domain.Configurations;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Context;
public class ClassSchedulerDbContext(DbContextOptions<ClassSchedulerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Campus> Campuses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DeptBatch> Batches { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Entity Configuration
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());
            modelBuilder.ApplyConfiguration(new DeptBatchEntityConfig());
            modelBuilder.ApplyConfiguration(new InstructorEntityConfig());
            modelBuilder.ApplyConfiguration(new StudentEntityConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionEntityConfig());
        }
        #endregion
        base.OnModelCreating(modelBuilder);

        #region Data Seeder Region
        {
            DataSeeder.SeedTime(modelBuilder);
        }
        #endregion
    }

}