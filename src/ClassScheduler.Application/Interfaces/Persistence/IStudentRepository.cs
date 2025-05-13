using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IStudentRepository
{
    public Task<bool> CreateStudentAsync(Student student);
    public Task<ICollection<Student>> GetStudentsListAsync();
    public Task<Student> GetAsync(Guid id);
    public Task<bool> DeleteAsync(Student student);
}