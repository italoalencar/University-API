using University_API.Data;
using University_API.Models;

namespace University_API.Repositories;

public interface IHorarioTurmaRepository
{
    HorarioTurma Create(HorarioTurma horario);
    ICollection<HorarioTurma> GetHorarios(int id);
    bool Delete(int idTurma);
}

public class HorarioTurmaRepository : IHorarioTurmaRepository
{
    private readonly UniversityContext _context;

    public HorarioTurmaRepository(UniversityContext context)
    {
        _context = context;
    }

    public HorarioTurma Create(HorarioTurma horario)
    {
        _context.HorarioTurmas.Add(horario);
        _context.SaveChanges();
        return horario;
    }

    public ICollection<HorarioTurma> GetHorarios(int idTurma)
    {
        return _context.HorarioTurmas.Where(horario => horario.IdTurma == idTurma).ToList();
    }

    public bool Delete(int idTurma)
    {
        var horarios = _context.HorarioTurmas.Where(h => h.IdTurma == idTurma).ToList();
        if (horarios is null) return false;
        foreach(var horario in horarios)
        {
            _context.HorarioTurmas.Remove(horario);
            _context.SaveChanges();
        }
        
        return true;
    }
}

