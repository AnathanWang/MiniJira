using Microsoft.EntityFrameworkCore;
using MiniJira.Application.Interfaces;
using MiniJira.Domain.Entities;
using MiniJira.Infrastructure.Data;

namespace MiniJira.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _context.Projects
            .Include(p => p.Tickets)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }
    
    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
    }

    public void Update(Project project)
    {
        _context.Projects.Update(project);
    }

    public void Delete(Project project)
    {
        _context.Projects.Remove(project);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}