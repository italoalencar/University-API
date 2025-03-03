using Microsoft.AspNetCore.Identity;
using University_API.Models;

namespace University_API.Repositories;

public class AdministradorRepository
{
    private readonly UserManager<Administrador> _userManager;

    public AdministradorRepository(UserManager<Administrador> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> Create(Administrador adm, string senha) 
    { 
        return await _userManager.CreateAsync(adm, senha);
    }
}
