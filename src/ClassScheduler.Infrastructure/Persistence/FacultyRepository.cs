using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Infrastructure.Context;
using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class FacultyRepository(ClassSchedulerDbContext dbContext): IFacultyRepository
{
    private readonly ClassSchedulerDbContext _dbContext = dbContext;

    public async Task<ServiceResponse<int>> Create(Faculty Faculty, CancellationToken cancellationToken)
    {
        
        _dbContext.Faculties.Add(Faculty);
        var response = new ServiceResponse<int>()
        {
            Data =  await _dbContext.SaveChangesAsync(cancellationToken)
        };
        if(response.Data > 0)
        {
            response.Message = "Successfully inserted!";
            response.Success = true;
        }
        return response;
    }
    public async Task<ServiceResponse<Faculty>> GetAsync(Guid id)
    {
        var response = new ServiceResponse<Faculty>()
        {
            Data = await _dbContext.Faculties.FindAsync(id)
        };
        if (response.Data is null)
        {
            response.Message = "No data is found";
        }
        return response;
    }
    public async Task<List<Faculty>> GetAllAsync()
    {
        return await _dbContext.Faculties.Include(faculty => faculty.Campus).ToListAsync();;
    }

}