using AutoMapper;
using Microsoft.AspNetCore.Identity;
using University_API.DTOs;
using University_API.Models;
using University_API.Repositories;

namespace University_API.Services;

public class AdministradorService
{
    private readonly AdministradorRepository _repository;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;

    public AdministradorService(AdministradorRepository repository, IMapper mapper, TokenService tokenService)
    {
        _repository = repository;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<IdentityResult> CreateAdm(CreateAdmDTO admDTO)
    {
        var adm = _mapper.Map<Administrador>(admDTO);
        return await _repository.Create(adm, admDTO.Password);
    }

    public async Task<string> LoginAdm(LoginAdmDTO admDTO)
    {
        var usuario = await _repository.Login(admDTO.UserName, admDTO.Password);
        var token = _tokenService.GenerateToken(usuario);
        return token;
    }
}
