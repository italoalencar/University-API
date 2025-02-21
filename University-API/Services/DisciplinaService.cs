using AutoMapper;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public interface IDisciplinaService
{
    ReadDisciplinaDTO Create(CreateDisciplinaDTO disciplinaDTO);
    ICollection<ReadDisciplinaDTO> ReadAll();
    ReadDisciplinaDTO? ReadById(string cod);
    DisciplinaRequisitosDTO GetRequisitos(string cod);
    bool Update(ReadDisciplinaDTO disciplinaDTO);
    bool Delete(string cod);
}

public class DisciplinaService : IDisciplinaService
{
    private readonly IDisciplinaRepository _repository;
    private readonly IMapper _mapper;

    public DisciplinaService(IDisciplinaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadDisciplinaDTO Create(CreateDisciplinaDTO disciplinaDTO)
    {
        var disciplina = new Disciplina
        {
            Cod = disciplinaDTO.Cod,
            Nome = disciplinaDTO.Nome,
            CargaHoraria = disciplinaDTO.CargaHoraria,
            Ementa = disciplinaDTO.Ementa
        };

        ICollection<PreRequisito> preRequisitos = new List<PreRequisito>();
        if (disciplinaDTO.PreRequisitos is not null)
        {
            foreach (var pre in disciplinaDTO.PreRequisitos)
            {
                preRequisitos.Add(new PreRequisito { CodDisciplina = disciplinaDTO.Cod, CodPreRequisito = pre });
            }
        }

        var disciplinaCreated = _repository.Create(disciplina, preRequisitos);
        var disciplinaCreatedDTO = _mapper.Map<ReadDisciplinaDTO>(disciplinaCreated);
        return disciplinaCreatedDTO;
        /*var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);
        var disciplinaCreated = _repository.Create(disciplina);
        var disciplinaCreatedDTO = _mapper.Map<ReadDisciplinaDTO>(disciplinaCreated);
        return disciplinaCreatedDTO;*/
    }

    public ICollection<ReadDisciplinaDTO> ReadAll()
    {
        var disciplinas = _repository.ReadAll();
        return _mapper.Map<List<ReadDisciplinaDTO>>(disciplinas);
    }

    public ReadDisciplinaDTO? ReadById(string cod)
    {
        var disciplina = _repository.ReadById(cod);
        var disciplinaDTO = _mapper.Map<ReadDisciplinaDTO>(disciplina);
        return disciplinaDTO;
    }

    public DisciplinaRequisitosDTO GetRequisitos(string cod)
    {
        var requisitos = _repository.GetRequisitos(cod);
        ICollection<string> requisitosList = new List<string>();
        foreach(var requisito in requisitos)
        {
            requisitosList.Add(requisito.CodPreRequisito!);
        }

        var disciplinaRequisitoDTO = new DisciplinaRequisitosDTO(cod, requisitosList);
        return disciplinaRequisitoDTO;
    }

    public bool Update(ReadDisciplinaDTO disciplinaDTO)
    {
        var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);
        return _repository.Update(disciplina);
    }

    public bool Delete(string cod)
    {
        return _repository.Delete(cod);
    }
}

