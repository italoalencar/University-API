using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface IAlunoRepository
{
    Aluno Create(Aluno aluno);
    ICollection<Aluno> ReadAll();
    Aluno? ReadById(string matricula);
    bool Update(Aluno alunoAtualizado);
    bool Delete(string matricula);
}

public class AlunoRepository : IAlunoRepository
{
    private readonly UniversityContext _context;

    public AlunoRepository(UniversityContext context)
    {
        _context = context;
    }

    public Aluno Create(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        _context.SaveChanges();
        return aluno;
    }


    public Aluno? ReadById(string matricula)
    {
        return _context.Alunos.FirstOrDefault(aluno => aluno.Matricula.Equals(matricula));
    }

    public ICollection<Aluno> ReadAll()
    {
        return _context.Alunos.ToList();
    }

    public bool Update(Aluno alunoAtualizado)
    {
        var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Matricula.Equals(alunoAtualizado.Matricula));
        if (aluno is null) return false;
        _context.Entry(aluno).CurrentValues.SetValues(alunoAtualizado);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(string matricula)
    {
        var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Matricula.Equals(matricula));
        if (aluno is null) return false;
        _context.Alunos.Remove(aluno);
        _context.SaveChanges();
        return true;
    }
}

