using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class UserRepository(ClassSchedulerDbContext context, UserManager<User> userManager) : IUserRepository
{
    private readonly ClassSchedulerDbContext _context = context;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<ServiceResponse<int>> CreateUserAsync(User user, string password)
    {
        ServiceResponse<int> response = new();
        if (user is not null && !string.IsNullOrEmpty(password))
        {
            var resp = await _userManager.CreateAsync(user, password);
            if (resp.Succeeded)
            {
                response.Data = 1;
                response.Success = resp.Succeeded;
                response.Message = "User created successfully!";
            }
            else
            {
                response.Success = resp.Succeeded;
                response.Errors?.AddRange(resp.Errors.Select(er => er.Code));
                response.Message = resp.Errors.Select(error => error.Description).ToString()!;
            }
        }

        return response;
    }

    public async Task<User> GetUserByUsernameAsync(string email)
    {
        User? user = null;
        if (!string.IsNullOrEmpty(email))
        {
            user = await _context.Users!.Where(user => user.Email == email).FirstOrDefaultAsync();
        }

        return user!;
    }
}