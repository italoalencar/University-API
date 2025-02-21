using University_API.Models;

namespace University_API.DTOs;

public record ReadTurmaDTO
{
    public int Id { get; init; }
    public int IdCurso { get; init; }
    public string Semestre { get; init; }
    public int? MaxAlunos { get; init; }
    public int? QtdeAlunos { get; init; }
    public ReadCursoDTO Curso { get; init; }
    public ReadDisciplinaDTO Disciplina { get; init; }

    public ReadTurmaDTO() { }

    public ReadTurmaDTO(int id, int idCurso, string semestre,
        int? maxAlunos, int? qtdeAlunos, ReadCursoDTO curso , ReadDisciplinaDTO disciplina)
    {
        Id = id;
        IdCurso = idCurso;
        Semestre = semestre;
        MaxAlunos = maxAlunos;
        QtdeAlunos = qtdeAlunos;
        Curso = curso;
        Disciplina = disciplina;
    }
}