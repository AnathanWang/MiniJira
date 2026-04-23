using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiniJira.Application.Interfaces;
using MiniJira.Domain.Entities;

namespace MiniJira.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectControllers : ControllerBase
{
    private readonly IProjectRepository _repository;

    public ProjectControllers(IProjectRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        var projects = await _repository.GetAllAsync();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
    {
        if (project == null)
        {
            return BadRequest("Данные проекта не заполнены");
        }

        if (_repository == null)
        {
            return StatusCode(500, "Ошибка сервера: Репозиторий не доступен");
        }

        try
        {
            if (project.Id == Guid.Empty) project.Id = Guid.NewGuid();
            if (project.CreatedAt == default) project.CreatedAt = DateTime.UtcNow;

            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка при сохранении: {ex.Message}");
        }
    }
}