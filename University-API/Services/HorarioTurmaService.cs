using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface IHorarioTurmaService
{
    HorarioTurmaDTO CreateHorario(HorarioTurmaDTO horario);
    ICollection<HorarioTurmaDTO> GetHorariosByTurma(int idTurma);
    bool DeleteHorarios(int idTurma);
}

public class HorarioTurmaService : IHorarioTurmaService
{
    private readonly IHorarioTurmaRepository _repository;
    private readonly IMapper _mapper;

    public HorarioTurmaService(IHorarioTurmaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public HorarioTurmaDTO CreateHorario(HorarioTurmaDTO horarioDTO)
    {
        var horario = _mapper.Map<HorarioTurma>(horarioDTO);
        var horarioCreated = _repository.Create(horario);
        var horarioCreatedDTO = _mapper.Map<HorarioTurmaDTO>(horarioCreated);
        return horarioCreatedDTO;
    }

    public ICollection<HorarioTurmaDTO> GetHorariosByTurma(int idTurma)
    {
        var horarios = _repository.GetHorarios(idTurma);
        var horariosDTO = _mapper.Map<List<HorarioTurmaDTO>>(horarios);
        return horariosDTO;
    }

    public bool DeleteHorarios(int idTurma)
    {
        return _repository.Delete(idTurma);
    }
}

