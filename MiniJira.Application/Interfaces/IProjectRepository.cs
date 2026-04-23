using MiniJira.Domain.Entities;

namespace MiniJira.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<IEnumerable<Project>> GetAllAsync();
    Task AddAsync(Project project);
    void Update(Project project);
    void Delete(Project project);
    Task SaveChangesAsync();
}