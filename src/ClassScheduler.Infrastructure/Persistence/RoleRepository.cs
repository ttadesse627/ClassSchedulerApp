using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class RoleRepository(ClassSchedulerDbContext context) : IRoleRepository
{
    private readonly ClassSchedulerDbContext _context = context;
    public async Task<ServiceResponse<int>> CreateRoleAsync(Role role, CancellationToken cancellationToken)
    {
        ServiceResponse<int> response = new();
        if (role is not null)
        {
            _context.Roles.Add(role);
            int i = await _context.SaveChangesAsync(cancellationToken);
            if (i > 0)
            {
                response.Data = 1;
                response.Success = true;
                response.Message = "Role created successfully!";
            }
            else
            {
                response.Success = false;
                response.Message = "Could not create a role";
            }
        }

        return response;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<List<Role>> GetRolesAsync(ICollection<Guid> roleIds)
    {
        List<Role> roles = [];
        if (roleIds.Count != 0)
        {
            roles.AddRange(await _context.Roles.Where(role => roleIds.Contains(Guid.Parse(role.Id))).ToListAsync());
        }
        return roles;
    }

    public async Task<Role?> GetAsync(Guid id)
    {
        var role = await _context.Roles.Include(role => role.Permissions).Where(r => r.Id == id.ToString()).FirstOrDefaultAsync();
        return role;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}