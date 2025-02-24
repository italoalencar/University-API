using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class HorarioTurmaController : ControllerBase
{
    private readonly IHorarioTurmaService _service;
    public HorarioTurmaController(IHorarioTurmaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateHorario([FromBody] HorarioTurmaDTO horarioDTO)
    {
        var horarioCreated = _service.CreateHorario(horarioDTO);
        return Ok(horarioCreated);
    }

    [HttpGet("{idTurma}")]
    public IActionResult ReadHorariosByTurma(int idTurma)
    {
        var horariosDTO = _service.GetHorariosByTurma(idTurma);
        if (horariosDTO is null) return NotFound("Não há horários para essa turma ou a turma não existe!");
        return Ok(horariosDTO);
    }

    [HttpDelete("{idTurma}")]
    public IActionResult DeleteHorarios(int idTurma)
    {
        var deleted = _service.DeleteHorarios(idTurma);
        if (deleted) return NoContent();
        return NotFound();
    }
}
