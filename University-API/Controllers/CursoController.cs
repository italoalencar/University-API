using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _service;

    public CursoController(ICursoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateCurso([FromBody] CreateCursoDTO cursoDTO)
    {
        var curso = _service.Create(cursoDTO);
        return CreatedAtAction(nameof(ReadCursoById), new { id = curso.Id}, curso);
    }

    [HttpGet]
    public IActionResult ReadCursos()
    {
        var cursos = _service.ReadAll();
        if (cursos is null) return NoContent();
        return Ok(cursos);
    }

    [HttpGet("{id}")]
    public IActionResult ReadCursoById(int id)
    {
        var curso = _service.ReadById(id);
        if (curso is null) return NotFound();
        return Ok(curso);
    }

    [HttpPut]
    public IActionResult UpdateCurso([FromBody] ReadCursoDTO cursoDTO)
    {
        var updated = _service.Update(cursoDTO);
        if(updated) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCurso(int id)
    {
        var deleted = _service.Delete(id);
        if (deleted) return NoContent();
        return NotFound();
    }
}
