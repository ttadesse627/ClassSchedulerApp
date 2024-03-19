using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ICourseRepository
{
    Task<bool> CreateAsync(Course course);
    Task<List<Course>> GetAllAsync();
}