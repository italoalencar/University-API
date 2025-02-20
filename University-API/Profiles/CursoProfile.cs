using AutoMapper;
using University_API.Models;
using University_API.DTOs;

namespace University_API.Profiles;

public class CursoProfile : Profile
{
    public CursoProfile() 
    {   
        CreateMap<Curso, ReadCursoDTO>().ReverseMap();
        CreateMap<CreateCursoDTO, Curso>();
    }
}
