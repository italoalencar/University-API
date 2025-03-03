using Microsoft.AspNetCore.Identity;
using University_API.Models;

namespace University_API.Repositories;

public class AdministradorRepository
{
    private readonly UserManager<Administrador> _userManager;
    private readonly SignInManager<Administrador> _signInManager;

    public AdministradorRepository(UserManager<Administrador> userManager, 
        SignInManager<Administrador> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> Create(Administrador adm, string senha) 
    { 
        return await _userManager.CreateAsync(adm, senha);
    }

    public async Task<SignInResult> Login(string username, string password)
    {
        return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }
}
