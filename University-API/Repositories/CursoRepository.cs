using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface ICursoRepository
{
    Curso Create(Curso curso);
    ICollection<Curso> ReadAll();
    Curso? ReadById(int id);
    bool Update(Curso curso);
    bool Delete(int id);
}

public class CursoRepository : ICursoRepository
{
    private readonly UniversityContext _context;

    public CursoRepository(UniversityContext context)
    {
        _context = context;
    }

    public Curso Create(Curso curso)
    {
        _context.Cursos.Add(curso);
        _context.SaveChanges();
        return curso;
    }


    public Curso? ReadById(int id)
    {
        return _context.Cursos.FirstOrDefault(curso => curso.Id == id);
    }

    public ICollection<Curso> ReadAll()
    {
        return _context.Cursos.ToList();
    }

    public bool Update(Curso cursoAtualizado)
    {
        var curso = _context.Cursos.FirstOrDefault(curso => curso.Id == cursoAtualizado.Id);
        if (curso is null) return false;
        _context.Entry(curso).CurrentValues.SetValues(cursoAtualizado);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
        if (curso is null) return false;
        _context.Cursos.Remove(curso);
        _context.SaveChanges();
        return true;
    }
}
