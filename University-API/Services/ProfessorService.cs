using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface IProfessorService
{
    ReadProfessorDTO Create(CreateProfessorDTO professorDTO);
    ICollection<ReadProfessorDTO> ReadAll();
    ReadProfessorDTO? ReadById(string matricula);
    bool Update(ReadProfessorDTO professorDTO);
    bool Delete(string matricula);
}

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _repository;
    private readonly IMapper _mapper;

    public ProfessorService(IProfessorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadProfessorDTO Create(CreateProfessorDTO professorDTO)
    {
        var professor = _mapper.Map<Professor>(professorDTO);
        var professorCreated = _repository.Create(professor);
        var professorCreatedDTO = _mapper.Map<ReadProfessorDTO>(professorCreated);
        return professorCreatedDTO;
    }

    public ICollection<ReadProfessorDTO> ReadAll()
    {
        var professores = _repository.ReadAll();
        return _mapper.Map<List<ReadProfessorDTO>>(professores);
    }

    public ReadProfessorDTO? ReadById(string matricula)
    {
        var professor = _repository.ReadById(matricula);
        var professorDTO = _mapper.Map<ReadProfessorDTO>(professor);
        return professorDTO;
    }

    public bool Update(ReadProfessorDTO professorDTO)
    {
        var professor = _mapper.Map<Professor>(professorDTO);
        return _repository.Update(professor);
    }

    public bool Delete(string matricula)
    {
        return _repository.Delete(matricula);
    }
}
