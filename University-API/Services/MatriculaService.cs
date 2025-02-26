using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface IMatriculaService
{
    ReadMatriculaDTO Create(CreateMatriculaDTO matriculaDTO);
    ICollection<ReadMatriculaDTO> ReadAll();
    ReadMatriculaDTO? ReadById(int id);
    bool Delete(int id);

}

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _repository;
    private readonly IMapper _mapper;

    public MatriculaService(IMatriculaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadMatriculaDTO Create(CreateMatriculaDTO matriculaDTO)
    {
        var matricula = _mapper.Map<Matricula>(matriculaDTO);
        var matriculaCreated = _repository.Create(matricula);
        var matriculaCreatedDTO = _mapper.Map<ReadMatriculaDTO>(matriculaCreated);
        return matriculaCreatedDTO;
    }

    public ICollection<ReadMatriculaDTO> ReadAll()
    {
        var matriculas = _repository.ReadAll();
        return _mapper.Map<List<ReadMatriculaDTO>>(matriculas);
    }

    public ReadMatriculaDTO? ReadById(int id)
    {
        var matricula = _repository.ReadById(id);
        var matriculaDTO = _mapper.Map<ReadMatriculaDTO>(matricula);
        return matriculaDTO;
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}

