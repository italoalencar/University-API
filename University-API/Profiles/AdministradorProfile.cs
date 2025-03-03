using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class AdministradorProfile : Profile
{
    public AdministradorProfile()
    {
        CreateMap<CreateAdmDTO, Administrador>();
    }
}
