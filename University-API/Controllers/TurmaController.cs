using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class TurmaController : ControllerBase
{
    private readonly ITurmaService _service;

    public TurmaController(ITurmaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateTurma([FromBody] CreateTurmaDTO turmaDTO)
    {
        var turma = _service.Create(turmaDTO);
        return CreatedAtAction(nameof(ReadTurmaById), new { id = turma.Id }, turma);
    }

    [HttpGet]
    public IActionResult ReadCursos()
    {
        var cursos = _service.ReadAll();
        if (cursos is null) return NoContent();
        return Ok(cursos);
    }

    [HttpGet("{id}")]
    public IActionResult ReadTurmaById(int id)
    {
        var turma = _service.ReadById(id);
        if (turma is null) return NotFound();
        return Ok(turma);
    }

    [HttpPut]
    public IActionResult UpdateTurma([FromBody] UpdateTurmaDTO turmaDTO)
    {
        var updated = _service.Update(turmaDTO);
        if (updated) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTurma(int id)
    {
        var deleted = _service.Delete(id);
        if (deleted) return NoContent();
        return NotFound();
    }
}
