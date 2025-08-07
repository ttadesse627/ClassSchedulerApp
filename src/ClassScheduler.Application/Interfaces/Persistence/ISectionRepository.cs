using ClassScheduler.Application.Interfaces.Persistence.Common;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Interfaces.Persistence;
public interface ISectionRepository : ICommonRepository<Section>
{
    public Task<bool> CreateSectionAsync(Section section);
    public Task<List<Section>> GetAllAsync();
    public Task<Section> GetAsync(Guid id);
    public Task<bool> DeleteAsync(Section section);
    public Task<bool> UpdateAsync(Section section);
}
