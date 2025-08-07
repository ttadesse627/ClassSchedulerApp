using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Authentication;
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
        var resp = await _userManager.CreateAsync(user, password);
        if (resp.Succeeded)
        {
            await _userManager.AddClaimAsync(user, new Claim(CustomClaims.UserId, user.Id));
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

        return response;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        User? user = null;
        if (!string.IsNullOrEmpty(email))
        {
            user = await _context.Users!.Where(user => user.Email == email).FirstOrDefaultAsync();
        }

        return user!;
    }

    public async Task<(Result result, User? user)> AuthenticateUser(string userName, string password)
    {
        var user = await _context.Users.Include(user => user.Person).Include(user => user.Roles).Where(user => user.UserName == userName).FirstOrDefaultAsync();

        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            // var userRoles = await _userManager.GetRolesAsync(user);
            return (Result.Success(), user);

        }
        string[] errors = ["Invalid login"];

        return (Result.Failure(errors), null);

    }
}