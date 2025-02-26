namespace University_API.DTOs;

public record CreateNotaDTO(string? Tipo, double Valor, double? Peso = 1);
