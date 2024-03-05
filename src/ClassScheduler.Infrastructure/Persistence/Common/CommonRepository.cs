using ClassScheduler.Application.Interfaces.Persistence.Common;
using ClassScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Persistence;
public class CommonRepository<T>(ClassSchedulerDbContext context) : ICommonRepository<T>
{
    private readonly ClassSchedulerDbContext _context = context;
    public async Task<bool> SaveTrackedChangesAsync(CancellationToken cancellationToken)
    {
        var response = false;

        var entries = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
        var affectedRows = await _context.SaveChangesAsync(cancellationToken);
        if (affectedRows > 0) response = true;
        return response!;
    }
}