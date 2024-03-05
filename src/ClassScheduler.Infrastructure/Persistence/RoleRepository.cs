using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Infrastructure.Persistence;
public class RoleRepository(ClassSchedulerDbContext context, RoleManager<Role> roleManager) : IRoleRepository
{
    private readonly ClassSchedulerDbContext _context = context;
    private readonly RoleManager<Role> _roleManager = roleManager;

    public async Task<ServiceResponse<int>> CreateRoleAsync(Role role)
    {
        ServiceResponse<int> response = new();
        if (role is not null)
        {
            var resp = await _roleManager.CreateAsync(role);
            if (resp.Succeeded)
            {
                response.Data = 1;
                response.Success = resp.Succeeded;
                response.Message = "Role created successfully!";
            }
            else
            {
                response.Success = resp.Succeeded;
                response.Errors?.AddRange(resp.Errors.Select(er => er.Code));
                response.Message = resp.Errors.Select(error => error.Description).ToString()!;
            }
        }

        return response;
        // new ServiceResponse<int>{
        //     Data = 1,
        //     Success = true,
        //     Message = "Successfully Created!",
        //     Errors = []
        // };
    }
}