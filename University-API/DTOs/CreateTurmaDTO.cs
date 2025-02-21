namespace University_API.DTOs;

public record CreateTurmaDTO(string CodDisciplina, int IdCurso, 
    string Semestre, int? MaxAlunos, int? QtdeAlunos);
