using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University_API.Models;

namespace University_API.Services;

public class TokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(Administrador adm)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id", adm.Id),
            new Claim("username", adm.UserName),
            new Claim(ClaimTypes.DateOfBirth, adm.DataNasc.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
             _config["AppSettings:SymmetricSecurityKey"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
