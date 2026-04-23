using MiniJira.Domain.Entities;
using MiniJira.Domain.Enums;

namespace MiniJira.Application.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id);
    Task<IEnumerable<Ticket>> GetByProjectIdAsync(Guid projectId);
    Task AddAsync(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(Ticket ticket);
    Task SaveChangesAsync();
}