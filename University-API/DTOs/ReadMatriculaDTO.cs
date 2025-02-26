namespace University_API.DTOs;

public record ReadMatriculaDTO(int Id, string MatriculaAluno, int IdTurma, DateTime? DataMatricula)
{
    public DateTime? DataMatricula { get; init; } = DataMatricula?.ToLocalTime();
}