namespace University_API.DTOs;

public record CreateAlunoDTO(string Matricula, string NomeCompleto, string Cpf, int IdCurso,
    DateOnly? DataNasc, string? Telefone, string? Email, int? AnoIngresso);
