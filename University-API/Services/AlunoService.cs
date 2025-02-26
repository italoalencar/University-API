using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface IAlunoService
{
    ReadAlunoDTO Create(CreateAlunoDTO alunoDTO);
    ICollection<ReadAlunoDTO> ReadAll();
    ReadAlunoDTO? ReadById(string matricula);
    bool Update(UpdateAlunoDTO alunoDTO);
    bool Delete(string matricula);

}

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;
    private readonly IMapper _mapper;

    public AlunoService(IAlunoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadAlunoDTO Create(CreateAlunoDTO alunoDTO)
    {
        var aluno = _mapper.Map<Aluno>(alunoDTO);
        var alunoCreated = _repository.Create(aluno);
        var alunoCreatedDTO = _mapper.Map<ReadAlunoDTO>(alunoCreated);
        return alunoCreatedDTO;
    }

    public ICollection<ReadAlunoDTO> ReadAll()
    {
        var alunos = _repository.ReadAll();
        return _mapper.Map<List<ReadAlunoDTO>>(alunos);
    }

    public ReadAlunoDTO? ReadById(string matricula)
    {
        var aluno = _repository.ReadById(matricula);
        var alunoDTO = _mapper.Map<ReadAlunoDTO>(aluno);
        return alunoDTO;
    }


    public bool Update(UpdateAlunoDTO alunoDTO)
    {
        var aluno = _mapper.Map<Aluno>(alunoDTO);
        return _repository.Update(aluno);
    }

    public bool Delete(string matricula)
    {
        return _repository.Delete(matricula);
    }
}

