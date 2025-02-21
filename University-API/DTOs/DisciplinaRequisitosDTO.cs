namespace University_API.DTOs;

public record DisciplinaRequisitosDTO(string Cod, ICollection<string> PreRequisitos);
