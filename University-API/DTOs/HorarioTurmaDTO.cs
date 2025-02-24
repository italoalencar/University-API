namespace University_API.DTOs;

public record HorarioTurmaDTO(int IdTurma, string? DiaSemana, TimeOnly? Inicio, TimeOnly? Termino);
