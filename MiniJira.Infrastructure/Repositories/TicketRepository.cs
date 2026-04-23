using Microsoft.EntityFrameworkCore;
using MiniJira.Application.Interfaces;
using MiniJira.Domain.Entities;
using MiniJira.Infrastructure.Data;

namespace MiniJira.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;
    
    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        return await _context.Tickets.FindAsync(id);
    }

    public async Task<IEnumerable<Ticket>> GetByProjectIdAsync(Guid projectId)
    {
        return await _context.Tickets
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
    }

    public void Update(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
    }

    public void Delete(Ticket ticket)
    {
        _context.Tickets.Remove(ticket);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}