namespace University_API.DTOs;

public record UpdateTurmaDTO(int Id, string CodDisciplina, int IdCurso,
    string Semestre, int? MaxAlunos, int? QtdeAlunos);

