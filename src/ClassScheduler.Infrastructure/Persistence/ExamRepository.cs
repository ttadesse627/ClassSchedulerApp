using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Infrastructure.Context;
using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class ExamRepository(ClassSchedulerDbContext dbContext): IExamRepository
{
    private readonly ClassSchedulerDbContext _dbContext = dbContext;

    public async Task<ServiceResponse<int>> Create(Exam Exam, CancellationToken cancellationToken)
    {
        
        _dbContext.Exams.Add(Exam);
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
    public async Task<ServiceResponse<Exam>> GetAsync(Guid id)
    {
        var response = new ServiceResponse<Exam>()
        {
            Data = await _dbContext.Exams.FindAsync(id)
        };
        if (response.Data is null)
        {
            response.Message = "No data is found";
        }
        return response;
    }
    public async Task<List<Exam>> GetAllAsync()
    {
        return await _dbContext.Exams.ToListAsync();;
    }

}