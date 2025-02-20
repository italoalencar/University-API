using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class ProfessorProfile : Profile
{
    public ProfessorProfile()
    {
        CreateMap<Professor, ReadProfessorDTO>().ReverseMap();
        CreateMap<CreateProfessorDTO, Professor>();
    }
}
