

namespace ClassScheduler.Application.Interfaces.Persistence.Common;
public interface ICommonRepository<T>
{
    public Task<bool> SaveTrackedChangesAsync(CancellationToken cancellationToken);
}