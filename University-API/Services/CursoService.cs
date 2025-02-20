using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface ICursoService
{
    ReadCursoDTO Create(CreateCursoDTO cursoDTO);
    ICollection<ReadCursoDTO> ReadAll();
    ReadCursoDTO? ReadById(int id);
    bool Update(ReadCursoDTO cursoDTO);
    bool Delete(int id);

}

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;
    private readonly IMapper _mapper;

    public CursoService(ICursoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadCursoDTO Create(CreateCursoDTO cursoDTO)
    {
        var curso = _mapper.Map<Curso>(cursoDTO);
        var cursoCreated = _repository.Create(curso);
        var cursoCreatedDTO = _mapper.Map<ReadCursoDTO>(cursoCreated);
        return cursoCreatedDTO;
    }

    public ICollection<ReadCursoDTO> ReadAll()
    {
        var cursos = _repository.ReadAll();
        return _mapper.Map<List<ReadCursoDTO>>(cursos);
    }

    public ReadCursoDTO? ReadById(int id)
    {
        var curso = _repository.ReadById(id);
        var cursoDTO = _mapper.Map<ReadCursoDTO>(curso);
        return cursoDTO;
    }


    public bool Update(ReadCursoDTO cursoDTO)
    {
        var curso = _mapper.Map<Curso>(cursoDTO);
        return _repository.Update(curso);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}
