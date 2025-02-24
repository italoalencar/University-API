using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface ITurmaService
{
    ReadTurmaDTO Create(CreateTurmaDTO turmaDTO);
    ICollection<ReadTurmaDTO> ReadAll();
    ReadTurmaDTO? ReadById(int id);
    bool Update(UpdateTurmaDTO turmaDTO);
    bool Delete(int id);

    bool AddProf(int idTurma, string matriculaProf);
    ICollection<ReadProfessorDTO> GetProfsByTurma(int id);
    bool DeleteProfFromTurma(int idTurma, string matriculaProf);
}

public class TurmaService : ITurmaService
{
    private readonly ITurmaRepository _repository;
    private readonly IMapper _mapper;

    public TurmaService(ITurmaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadTurmaDTO Create(CreateTurmaDTO turmaDTO)
    {
        var turma = _mapper.Map<Turma>(turmaDTO);
        var turmaCreated = _repository.Create(turma);
        var turmaCreatedDTO = _mapper.Map<ReadTurmaDTO>(turmaCreated);
        return turmaCreatedDTO;
    }

    public ICollection<ReadTurmaDTO> ReadAll()
    {
        var turmas = _repository.ReadAll();
        return _mapper.Map<List<ReadTurmaDTO>>(turmas);
    }

    public ReadTurmaDTO? ReadById(int id)
    {
        var turma = _repository.ReadById(id);
        var turmaDTO = _mapper.Map<ReadTurmaDTO>(turma);
        return turmaDTO;
    }

    public bool Update(UpdateTurmaDTO turmaDTO)
    {
        var turma = _mapper.Map<Turma>(turmaDTO);
        return _repository.Update(turma);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }


    public bool AddProf(int idTurma, string matriculaProf)
    {
        return _repository.AddProf(idTurma, matriculaProf);
    }

    public ICollection<ReadProfessorDTO> GetProfsByTurma(int id)
    {
        var professores = _repository!.GetProfs(id);
        return _mapper!.Map<List<ReadProfessorDTO>>(professores);
    }

    public bool DeleteProfFromTurma(int idTurma, string matriculaProf)
    {
        return _repository.DeleteProf(idTurma, matriculaProf);
    }
}

