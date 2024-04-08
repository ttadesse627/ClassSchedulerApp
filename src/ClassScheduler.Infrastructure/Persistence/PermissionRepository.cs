using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class PermissionRepository(ClassSchedulerDbContext context) : IPermissionRepository
{
    private readonly ClassSchedulerDbContext _context = context;
    public async Task<HashSet<string>> GetPermissionAsync(string userId)
    {
        ICollection<Role>[] roles = await _context.Set<User>()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();

        return roles.SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => p.Name).ToHashSet();
    }
}