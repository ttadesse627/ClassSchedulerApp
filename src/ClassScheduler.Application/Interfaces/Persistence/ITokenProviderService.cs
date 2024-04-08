using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ITokenProviderService
{
    public Task<string> GenerateJWTTokenAsync((string userId, string userName, IList<string> roles) userDetails);
}