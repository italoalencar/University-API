using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorService _service;

    public ProfessorController(IProfessorService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateProfessor([FromBody] CreateProfessorDTO professorDTO)
    {
        var professor = _service.Create(professorDTO);
        return CreatedAtAction(nameof(ReadProfessorByMatricula), new { matricula = professor.Matricula}, professor);
    }

    [HttpGet]
    public IActionResult ReadProfessores()
    {
        var professores = _service.ReadAll();
        if (professores is null) return NoContent();
        return Ok(professores);
    }

    [HttpGet("{matricula}")]
    public IActionResult ReadProfessorByMatricula(string matricula)
    {
        var professor = _service.ReadById(matricula);
        if (professor is null) return NotFound();
        return Ok(professor);
    }

    [HttpPut]
    public IActionResult UpdateProfessor([FromBody] ReadProfessorDTO professorDTO)
    {
        var updated = _service.Update(professorDTO);
        if (updated) return NoContent();
        return NotFound();
    }

    [HttpDelete]
    public IActionResult DeleteProfessor(string matricula) 
    {
        var deleted = _service.Delete(matricula);
        if (deleted) return NoContent();
        return NotFound();
    }
}
