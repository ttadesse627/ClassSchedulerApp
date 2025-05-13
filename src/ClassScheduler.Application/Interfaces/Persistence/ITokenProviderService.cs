using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ITokenProviderService
{
    public Task<string> GenerateJWTTokenAsync(User userDetails);
}