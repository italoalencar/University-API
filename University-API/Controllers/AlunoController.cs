using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunoController(IAlunoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateAluno([FromBody] CreateAlunoDTO alunoDTO)
    {
        var aluno = _service.Create(alunoDTO);
        return CreatedAtAction(nameof(ReadAlunoById), new { matricula = aluno.Matricula }, aluno);
    }

    [HttpGet]
    public IActionResult ReadAlunos()
    {
        var alunos = _service.ReadAll();
        if (alunos is null) return NoContent();
        return Ok(alunos);
    }

    [HttpGet("{matricula}")]
    public IActionResult ReadAlunoById(string matricula)
    {
        var aluno = _service.ReadById(matricula);
        if (aluno is null) return NotFound();
        return Ok(aluno);
    }

    [HttpPut]
    public IActionResult UpdateAluno([FromBody] UpdateAlunoDTO alunoDTO)
    {
        var updated = _service.Update(alunoDTO);
        if (updated) return NoContent();
        return NotFound();
    }

    [HttpDelete("{matricula}")]
    public IActionResult DeleteAluno(string matricula)
    {
        var deleted = _service.Delete(matricula);
        if (deleted) return NoContent();
        return NotFound();
    }
}
