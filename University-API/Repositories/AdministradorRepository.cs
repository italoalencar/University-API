using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
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

    public async Task<Administrador> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
        if (result.Succeeded)
        {
            return _userManager.Users.FirstOrDefault(user => 
            user.NormalizedUserName.Equals(username.ToUpper()))!;
        }
        throw new ApplicationException("Não foi possível efetuar o login.");
    }
}
