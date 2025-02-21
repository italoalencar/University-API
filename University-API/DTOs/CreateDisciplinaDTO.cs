namespace University_API.DTOs;

public record CreateDisciplinaDTO(string Cod, string Nome, int? CargaHoraria,
    string? Ementa, ICollection<string>? PreRequisitos);
