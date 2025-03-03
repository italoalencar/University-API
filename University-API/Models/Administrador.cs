using Microsoft.AspNetCore.Identity;

namespace University_API.Models;

public class Administrador : IdentityUser
{
    public DateOnly DataNasc { get; set; }
}
