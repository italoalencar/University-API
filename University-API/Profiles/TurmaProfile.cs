using AutoMapper;
using University_API.DTOs;
using University_API.Models;

namespace University_API.Profiles;

public class TurmaProfile : Profile
{
    public TurmaProfile() 
    {
        CreateMap<Turma, ReadTurmaDTO>()
            .ForMember(turmaDTO => turmaDTO.Disciplina,
            options => options.MapFrom(turma => turma.CodDisciplinaNavigation))
            .ForMember(turmaDTO => turmaDTO.Curso,
            options => options.MapFrom(turma => turma.IdCursoNavigation));

        CreateMap<CreateTurmaDTO, Turma>();
        CreateMap<UpdateTurmaDTO, Turma>();
    }
}
