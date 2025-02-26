namespace University_API.DTOs;

public record ReadAlunoDTO
{
    public string Matricula { get; init; }
    public string NomeCompleto { get; init; }
    public DateOnly? DataNasc { get; init; }
    public int? AnoIngresso { get; init; }
    public ReadCursoDTO Curso { get; init; }

    public ReadAlunoDTO() { }

    public ReadAlunoDTO(string matricula, string nomeCompleto, DateOnly? dataNasc, int? anoIngresso, ReadCursoDTO curso)
    {
        Matricula = matricula;
        NomeCompleto = nomeCompleto;
        DataNasc = dataNasc;
        AnoIngresso = anoIngresso;
        Curso = curso;
    }
}
    