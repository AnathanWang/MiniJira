using MiniJira.Domain.Enums;

namespace MiniJira.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.ToDo;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Foreign key to Project
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}