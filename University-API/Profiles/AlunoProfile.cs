using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<Aluno, ReadAlunoDTO>()
            .ForMember(alunoDTO => alunoDTO.Curso,
            options => options.MapFrom(aluno => aluno.IdCursoNavigation));
        CreateMap<CreateAlunoDTO, Aluno>();
        CreateMap<UpdateAlunoDTO, Aluno>();
    }
}
