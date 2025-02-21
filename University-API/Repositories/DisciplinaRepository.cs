using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface IDisciplinaRepository
{
    Disciplina Create(Disciplina disciplina, ICollection<PreRequisito> preRequisitos);
    ICollection<Disciplina> ReadAll();
    Disciplina? ReadById(string cod);
    ICollection<PreRequisito> GetRequisitos(string cod);
    bool Update(Disciplina disciplinaAtualizada);
    bool Delete(string cod);
}

public class DisciplinaRepository : IDisciplinaRepository
{
    private readonly UniversityContext _context;

    public DisciplinaRepository(UniversityContext context)
    {
        _context = context;
    }

    public Disciplina Create(Disciplina disciplina, ICollection<PreRequisito> preRequisitos)
    {
        _context.Disciplinas.Add(disciplina);

        foreach (var preRequisito in preRequisitos)
        {
            _context.PreRequisitos.Add(preRequisito);
        }
        _context.SaveChanges();
        return disciplina;
    }

    public ICollection<Disciplina> ReadAll()
    {
        return _context.Disciplinas.ToList();
    }

    public Disciplina? ReadById(string cod)
    {
        return _context.Disciplinas.FirstOrDefault(disc => disc.Cod.Equals(cod));
    }

    public bool Update(Disciplina disciplinaAtualizada)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(disc =>
        disc.Cod.Equals(disciplinaAtualizada.Cod));
        if (disciplina is null) return false;
        _context.Entry(disciplina).CurrentValues.SetValues(disciplinaAtualizada);
        _context.SaveChanges();
        return true;
    }

    public ICollection<PreRequisito> GetRequisitos(string cod)
    {
        return _context.PreRequisitos.Where(requisito => requisito.CodDisciplina!.Equals(cod)).ToList();
    }

    public bool Delete(string cod)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(disc =>
        disc.Cod.Equals(cod));
        if (disciplina is null) return false;
        _context.Disciplinas.Remove(disciplina);
        _context.SaveChanges();
        return true;
    }
}
