namespace University_API.DTOs;

public record CreateProfessorDTO(string Matricula, string NomeCompleto, string Cpf, 
    string? AreaAtuacao, DateOnly? DataNasc, string? Telefone, string? Email);
