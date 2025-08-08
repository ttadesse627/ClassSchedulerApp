using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Infrastructure.Context;
using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class CampusRepository(ClassSchedulerDbContext dbContext): ICampusRepository
{
    private readonly ClassSchedulerDbContext _dbContext = dbContext;

    public async Task<ServiceResponse<int>> Create(Campus campus, CancellationToken cancellationToken)
    {
        
        _dbContext.Campuses.Add(campus);
        var response = new ServiceResponse<int>();
        try
        {
            response.Data = await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            if (exception is not null)
            {
                response.Message = exception.Message;
                response.Success = false;
            }
        }
        if(response.Data > 0)
        {
            response.Message = "Successfully inserted!";
            response.Success = true;
        }
        return response;
    }
    public async Task<ServiceResponse<Campus>> GetAsync(Guid id)
    {
        var response = new ServiceResponse<Campus>()
        {
            Data = await _dbContext.Campuses.FindAsync(id)
        };
        if (response.Data is null)
        {
            response.Message = "No data is found";
        }
        return response;
    }
    public async Task<List<Campus>> GetAllAsync()
    {
        return await _dbContext.Campuses.ToListAsync();;
    }

}