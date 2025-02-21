using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplinaController : ControllerBase
{
    private readonly IDisciplinaService _service;

    public DisciplinaController(IDisciplinaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateDisciplina([FromBody] CreateDisciplinaDTO disciplinaDTO)
    {
        var disciplina = _service.Create(disciplinaDTO);
        return CreatedAtAction(nameof(ReadDisciplinaByCod), new { cod = disciplina.Cod }, disciplina);
    }

    [HttpGet]
    public IActionResult ReadDisciplinas()
    {
        var disciplinas = _service.ReadAll();
        if (disciplinas is null) return NoContent();
        return Ok(disciplinas);
    }

    [HttpGet("{cod}")]
    public IActionResult ReadDisciplinaByCod(string cod)
    {
        var disciplina = _service.ReadById(cod);
        if (disciplina is null) return NotFound();
        return Ok(disciplina);
    }

    [HttpGet("{cod}/requisitos")]
    public IActionResult GetRequisitos(string cod)
    {
        var disciplinaRequisitosDTO = _service.GetRequisitos(cod);
        if (disciplinaRequisitosDTO is null) return NotFound();
        return Ok(disciplinaRequisitosDTO);
    }

    [HttpPut]
    public IActionResult UpdateDisciplina([FromBody] ReadDisciplinaDTO disciplinaDTO)
    {
        var updated = _service.Update(disciplinaDTO);
        if (updated) return NoContent();
        return NotFound();
    }

    [HttpDelete("{cod}")]
    public IActionResult DeleteDisciplina(string cod)
    {
        var deleted = _service.Delete(cod);
        if (deleted) return NoContent();
        return NotFound();
    }
}
