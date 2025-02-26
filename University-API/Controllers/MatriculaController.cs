using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class MatriculaController : ControllerBase
{
    private readonly IMatriculaService _service;

    public MatriculaController(IMatriculaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateMatricula([FromBody] CreateMatriculaDTO matriculaDTO)
    {
        var matricula = _service.Create(matriculaDTO);
        return CreatedAtAction(nameof(ReadMatriculaById), new { id = matricula.Id }, matricula);
    }

    [HttpGet]
    public IActionResult ReadMatriculas()
    {
        var matriculas = _service.ReadAll();
        if (matriculas is null) return NoContent();
        return Ok(matriculas);
    }

    [HttpGet("{id}")]
    public IActionResult ReadMatriculaById(int id)
    {
        var matricula = _service.ReadById(id);
        if (matricula is null) return NotFound();
        return Ok(matricula);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMatricula(int id)
    {
        var deleted = _service.Delete(id);
        if (deleted) return NoContent();
        return NotFound();
    }
}

