using Microsoft.EntityFrameworkCore;
using MiniJira.Domain.Entities;

namespace MiniJira.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tickets)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId);
    }
}