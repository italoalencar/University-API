using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class HorarioTurmaProfile : Profile
{
    public HorarioTurmaProfile()
    {
        CreateMap<HorarioTurma, HorarioTurmaDTO>().ReverseMap();
    }
}
