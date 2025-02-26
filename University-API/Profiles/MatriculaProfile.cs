using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class MatriculaProfile : Profile
{
    public MatriculaProfile() 
    {
        CreateMap<Matricula, ReadMatriculaDTO>();
        CreateMap<CreateMatriculaDTO, Matricula>();

        CreateMap<Nota, ReadNotaDTO>();
        CreateMap<CreateNotaDTO, Nota>();
    }
}
