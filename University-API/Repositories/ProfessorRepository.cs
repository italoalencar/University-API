using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface IProfessorRepository
{
    Professor Create(Professor professor);
    ICollection<Professor> ReadAll();
    Professor? ReadById(string matricula);
    bool Update(Professor professorAtualizado);
    bool Delete(string matricula);
}

public class ProfessorRepository : IProfessorRepository
{
    private readonly UniversityContext _context;

    public ProfessorRepository(UniversityContext context)
    {
        _context = context;
    }

    public Professor Create(Professor professor)
    {
        _context.Professores.Add(professor);
        _context.SaveChanges();
        return professor;
    }

    public ICollection<Professor> ReadAll()
    {
        return _context.Professores.ToList();
    }

    public Professor? ReadById(string matricula)
    {
        return _context.Professores.FirstOrDefault(prof => prof.Matricula.Equals(matricula));
    }

    public bool Update(Professor professorAtualizado)
    {
        var professor = _context.Professores.FirstOrDefault(prof => 
        prof.Matricula.Equals(professorAtualizado.Matricula));
        if (professor is null) return false;
        _context.Entry(professor).CurrentValues.SetValues(professorAtualizado);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(string matricula)
    {
        var professor = _context.Professores.FirstOrDefault(prof =>
        prof.Matricula.Equals(matricula));
        if (professor is null) return false;
        _context.Professores.Remove(professor);
        _context.SaveChanges();
        return true;
    }
}
