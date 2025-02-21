using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface ITurmaRepository
{
    Turma Create(Turma turma);
    ICollection<Turma> ReadAll();
    Turma? ReadById(int id);
    bool Update(Turma turmaAtualizada);
    bool Delete(int id);
}

public class TurmaRepository : ITurmaRepository
{
    private readonly UniversityContext _context;

    public TurmaRepository(UniversityContext context)
    {
        _context = context;
    }

    public Turma Create(Turma turma)
    {
        _context.Turmas.Add(turma);
        _context.SaveChanges();
        return turma;
    }

    public ICollection<Turma> ReadAll()
    {
        return _context.Turmas.ToList();
    }

    public Turma? ReadById(int id)
    {
        return _context.Turmas.FirstOrDefault(turma => turma.Id == id);
    }

    public bool Update(Turma turmaAtualizada)
    {
        var turma = _context.Turmas.FirstOrDefault(t => 
        t.Id == turmaAtualizada.Id);
        if (turma is null) return false;
        _context.Entry(turma).CurrentValues.SetValues(turmaAtualizada);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var turma = _context.Turmas.FirstOrDefault(t =>
        t.Id == id);
        if (turma is null) return false;
        _context.Turmas.Remove(turma);
        _context.SaveChanges();
        return true;
    }
}

