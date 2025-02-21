using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class DisciplinaProfile : Profile
{
    public DisciplinaProfile()
    {
        CreateMap<Disciplina, ReadDisciplinaDTO>().ReverseMap();
        CreateMap<CreateDisciplinaDTO, Disciplina>();
    }
}
