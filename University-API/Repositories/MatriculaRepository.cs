using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface IMatriculaRepository
{
    Matricula Create(Matricula matricula);
    ICollection<Matricula> ReadAll();
    Matricula? ReadById(int id);
    bool Delete(int id);
    bool AddNota(int id, Nota nota);
    ICollection<Nota> GetNotas(int id);
    bool DeleteNota(int idNota);
}

public class MatriculaRepository : IMatriculaRepository
{
    private readonly UniversityContext _context;

    public MatriculaRepository(UniversityContext context)
    {
        _context = context;
    }

    public Matricula Create(Matricula matricula)
    {
        matricula.DataMatricula = DateTime.UtcNow; //capturando a data de efetuação da matricula
        _context.Matriculas.Add(matricula);
        _context.SaveChanges();
        return matricula;
    }


    public Matricula? ReadById(int id)
    {
        return _context.Matriculas.FirstOrDefault(matricula => matricula.Id == id);
    }

    public ICollection<Matricula> ReadAll()
    {
        return _context.Matriculas.ToList();
    }

    public bool Delete(int id)
    {
        var matricula = _context.Matriculas.FirstOrDefault(matricula => matricula.Id == id);
        if (matricula is null) return false;
        _context.Matriculas.Remove(matricula);
        _context.SaveChanges();
        return true;
    }


    public bool AddNota(int id, Nota nota)
    {
        var matriculaExists = _context.Matriculas.Any(m => m.Id == id);
        if (matriculaExists)
        {
            nota.IdMatricula = id;
            _context.Notas.Add(nota);
            _context.SaveChanges();
            return true;
        }    

        return false;
    }

    public ICollection<Nota> GetNotas(int id)
    {
        return _context.Notas.Where(nota => nota.IdMatricula == id).ToList();
    }

    public bool DeleteNota(int idNota)
    {
        var nota = _context.Notas.FirstOrDefault(nota => 
        nota.Id == idNota);
        if (nota is null) return false;
        _context.Notas.Remove(nota);
        _context.SaveChanges();
        return true;
    }
}

