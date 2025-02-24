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

    bool AddProf(int id, string matricula);
    ICollection<Professor> GetProfs(int id);
    bool DeleteProf(int id, string matricula);
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


    public bool AddProf(int id, string matricula)
    {
        var turmaExists = _context.Turmas.Any(t => t.Id == id);
        var profExists = _context.Professores.Any(p => p.Matricula.Equals(matricula));
        if (turmaExists && profExists)
        {
            _context.TurmaProfessores.Add(new TurmaProfessor { IdTurma = id, MatriculaProf = matricula });
            _context.SaveChanges();
            return true;
        }
       
        return false;
    }

    public ICollection<Professor> GetProfs(int id)
    {
        return _context.TurmaProfessores
            .Where(tp => tp.IdTurma == id)
            .Select(tp => tp.MatriculaProfNavigation)
            .ToList()!;
    }

    public bool DeleteProf(int id, string matricula)
    {
        var turmaProf = _context.TurmaProfessores.FirstOrDefault(tp =>
        tp.IdTurma == id && tp.MatriculaProf.Equals(matricula));
        if (turmaProf is null) return false;
        _context.TurmaProfessores.Remove(turmaProf);
        _context.SaveChanges();
        return true;
    }
}

