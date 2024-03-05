

using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface IUserRepository
{
    public Task<ServiceResponse<int>> CreateUserAsync(User user, string password);
    public Task<User> GetUserByUsernameAsync(string email);
}